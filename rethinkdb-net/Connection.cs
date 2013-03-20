﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using ProtoBuf;
using RethinkDb.Spec;

namespace RethinkDb
{
    public sealed class Connection : IDisposable
    {
        private static TaskFactory taskFactory = new TaskFactory();
        private static TimeSpan connectTimeout = TimeSpan.FromSeconds(30);
        private static TimeSpan runQueryTimeout = TimeSpan.FromSeconds(30);
        private static byte[] connectHeader = null;

        private Socket socket;
        private NetworkStream stream;
        private long nextToken = 1;

        public Connection()
        {
            DatumConverterFactory = new DataContractDatumConverterFactory();
        }

        public IDatumConverterFactory DatumConverterFactory
        {
            get;
            set;
        }

        public async Task Connect(params EndPoint[] endpoints)
        {
            var cancellationToken = new CancellationTokenSource(connectTimeout).Token;

            foreach (var ep in endpoints)
            {
                IEnumerable<IPEndPoint> resolvedIpEndpoints = null;
                if (ep is DnsEndPoint)
                {
                    var dnsEndpoint = (DnsEndPoint)ep;
                    try
                    {
                        var ips = await Dns.GetHostAddressesAsync(dnsEndpoint.Host);
                        resolvedIpEndpoints = ips.Select(ip => new IPEndPoint(ip, dnsEndpoint.Port));
                    }
                    catch (Exception)
                    {
                        // FIXME: Log: DNS resolution failed
                        continue;
                    }
                }
                else if (ep is IPEndPoint)
                {
                    resolvedIpEndpoints = Enumerable.Repeat((IPEndPoint)ep, 1);
                }
                else
                {
                    // FIXME: custom exception
                    throw new ArgumentException("Unexpected type of System.Net.EndPoint");
                }

                foreach (var ipEndpoint in resolvedIpEndpoints)
                {
                    try
                    {
                        await DoTryConnect(ipEndpoint, cancellationToken);
                        return;
                    }
                    catch (TaskCanceledException)
                    {
                        // FIXME: Log: timeout occurred trying to connect
                        throw;
                    }
                    catch (Exception)
                    {
                        // FIXME: Log: exception occurred trying to connect
                        continue;
                    }
                }
            }

            // FIXME: Custom exception class
            throw new Exception("Failed to resolve a connectable address.");
        }

        private async Task DoTryConnect(IPEndPoint endpoint, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new TaskCanceledException();

            Socket socket = null;
            NetworkStream stream = null;

            try
            {
                socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                await taskFactory.FromAsync(
                    (asyncCallback, asyncState) => socket.BeginConnect(endpoint.Address, endpoint.Port, asyncCallback, asyncState),
                    ar => socket.EndConnect(ar),
                    null
                );

                if (connectHeader == null)
                {
                    var header = BitConverter.GetBytes((int)Spec.Version.V0_1);
                    if (!BitConverter.IsLittleEndian)
                        Array.Reverse(header, 0, header.Length);
                    connectHeader = header;
                }

                stream = new NetworkStream(socket, true);
                await stream.WriteAsync(connectHeader, 0, connectHeader.Length, cancellationToken);

                this.socket = socket;
                this.stream = stream;
            }
            catch (Exception)
            {
                if (stream != null)
                {
                    try
                    {
                        stream.Close();
                        stream.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }
                if (socket != null)
                {
                    try
                    {
                        socket.Close();
                        socket.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }
                throw;
            }
        }

        private async Task ReadMyBytes(byte[] buffer, CancellationToken cancellationToken)
        {
            int totalBytesRead = 0;
            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, totalBytesRead, buffer.Length, cancellationToken);
                totalBytesRead += bytesRead;

                if (bytesRead == 0)
                    throw new EndOfStreamException("Network stream closed while attempting to read.");
                else if (totalBytesRead == buffer.Length)
                    break;
            }
        }

        internal ulong GetNextToken()
        {
            return (ulong)Interlocked.Increment(ref nextToken);
        }

        internal async Task<Response> InternalRunQuery(Spec.Query query)
        {
            var cancellationToken = new CancellationTokenSource(runQueryTimeout).Token;

            using (var memoryBuffer = new MemoryStream(1024))
            {
                Serializer.Serialize(memoryBuffer, query);

                var data = memoryBuffer.ToArray();
                var header = BitConverter.GetBytes(data.Length);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(header, 0, header.Length);

                await stream.WriteAsync(header, 0, header.Length, cancellationToken);
                await stream.WriteAsync(data, 0, data.Length, cancellationToken);
            }

            byte[] headerSize = new byte[4];
            await ReadMyBytes(headerSize, cancellationToken);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(headerSize, 0, headerSize.Length);
            var respSize = BitConverter.ToInt32(headerSize, 0);

            byte[] retVal = new byte[respSize];
            await ReadMyBytes(retVal, cancellationToken);
            using (var memoryBuffer = new MemoryStream(retVal))
            {
                var response = Serializer.Deserialize<Response>(memoryBuffer);
                return response;
            }
        }

        public async Task<T> Query<T>(IDatumConverter<T> converter, ISingleObjectQuery queryObject)
        {
            var query = new Spec.Query();
            query.token = GetNextToken();
            query.type = Spec.Query.QueryType.START;
            query.query = queryObject.GenerateTerm();

            var response = await InternalRunQuery(query);

            switch (response.type)
            {
                case Response.ResponseType.SUCCESS_SEQUENCE:
                case Response.ResponseType.SUCCESS_ATOM:
                    if (response.response.Count != 1)
                        throw new InvalidOperationException(String.Format("Expected 1 object, received {0}", response.response.Count));
                    return converter.ConvertDatum(response.response[0]);
                case Response.ResponseType.CLIENT_ERROR:
                case Response.ResponseType.COMPILE_ERROR:
                case Response.ResponseType.RUNTIME_ERROR:
                    // FIXME: more robust error handling
                    throw new Exception("Error: " + response.response[0].r_str);
                default:
                    throw new InvalidOperationException("Unhandled response type in FetchSingleObject<T>");
            }
        }

        public Task<T> Query<T>(ISingleObjectQuery queryObject)
        {
            return Query<T>(DatumConverterFactory.Get<T>(), queryObject);
        }

        public Task<DmlResponse> Write(IDatumConverter<DmlResponse> converter, IDmlQuery queryObject)
        {
            return Query<DmlResponse>(DatumConverterFactory.Get<DmlResponse>(), queryObject);
        }

        public Task<DmlResponse> Write(IDmlQuery queryObject)
        {
            return Write(DatumConverterFactory.Get<DmlResponse>(), queryObject);
        }

        public IAsyncEnumerator<T> Query<T>(IDatumConverter<T> converter, ISequenceQuery queryObject)
        {
            return new QueryEnumerator<T>(this, converter, queryObject);
        }

        public IAsyncEnumerator<T> Query<T>(ISequenceQuery queryObject)
        {
            return Query(DatumConverterFactory.Get<T>(), queryObject);
        }

        public async Task<DmlResponse> Write<T>(IDatumConverter<T> converter, IDatumConverter<DmlResponse> dmlResponseConverter, IWriteQuery<T> queryObject)
        {
            var query = new Spec.Query();
            query.token = GetNextToken();
            query.type = Spec.Query.QueryType.START;
            query.query = queryObject.GenerateTerm(converter);

            var response = await InternalRunQuery(query);

            switch (response.type)
            {
                case Response.ResponseType.SUCCESS_SEQUENCE:
                case Response.ResponseType.SUCCESS_ATOM:
                    if (response.response.Count != 1)
                        throw new InvalidOperationException(String.Format("Expected 1 object, received {0}", response.response.Count));
                    return dmlResponseConverter.ConvertDatum(response.response[0]);
                case Response.ResponseType.CLIENT_ERROR:
                case Response.ResponseType.COMPILE_ERROR:
                case Response.ResponseType.RUNTIME_ERROR:
                    // FIXME: more robust error handling
                    throw new Exception("Error: " + response.response[0].r_str);
                default:
                    throw new InvalidOperationException("Unhandled response type in FetchSingleObject<T>");
            }
        }

        public Task<DmlResponse> Write<T>(IDatumConverter<T> converter, IWriteQuery<T> queryObject)
        {
            return Write(converter, DatumConverterFactory.Get<DmlResponse>(), queryObject);
        }

        public Task<DmlResponse> Write<T>(IWriteQuery<T> queryObject)
        {
            return Write(DatumConverterFactory.Get<T>(), DatumConverterFactory.Get<DmlResponse>(), queryObject);
        }

        private class QueryEnumerator<T> : IAsyncEnumerator<T>
        {
            private readonly Connection connection;
            private readonly IDatumConverter<T> converter;
            private readonly ISequenceQuery queryObject;

            private Spec.Query query = null;
            private Response lastResponse = null;
            private int lastResponseIndex = 0;

            public QueryEnumerator(Connection connection, IDatumConverter<T> converter, ISequenceQuery queryObject)
            {
                this.connection = connection;
                this.converter = converter;
                this.queryObject = queryObject;
            }

            public T Current
            {
                get
                {
                    if (lastResponse == null || lastResponseIndex == -1)
                        throw new InvalidOperationException("Call MoveNext first");
                    else if (lastResponseIndex >= lastResponse.response.Count)
                        throw new InvalidOperationException("You moved past the end of the enumerator");
                    else
                        return converter.ConvertDatum(lastResponse.response[lastResponseIndex]);
                }
            }

            private async Task ReissueQuery()
            {
                lastResponse = await connection.InternalRunQuery(query);
                lastResponseIndex = -1;

                if (lastResponse.type != Response.ResponseType.SUCCESS_SEQUENCE &&
                    lastResponse.type != Response.ResponseType.SUCCESS_PARTIAL)
                {
                    throw new Exception("Unexpected response type to query");
                }
            }

            public async Task<bool> MoveNext()
            {
                if (lastResponse == null)
                {
                    query = new Spec.Query();
                    query.token = connection.GetNextToken();
                    query.type = Spec.Query.QueryType.START;
                    query.query = this.queryObject.GenerateTerm();
                    await ReissueQuery();
                }

                if (lastResponseIndex < (lastResponse.response.Count - 1))
                {
                    lastResponseIndex += 1;
                    return true;
                }

                if (lastResponse.type == Response.ResponseType.SUCCESS_SEQUENCE)
                {
                    return false;
                }
                else if (lastResponse.type == Response.ResponseType.SUCCESS_PARTIAL)
                {
                    query.type = RethinkDb.Spec.Query.QueryType.CONTINUE;
                    query.query = null;
                    await ReissueQuery();
                    return await MoveNext();
                }
                else
                {
                    throw new InvalidOperationException("Unreachable code; ReissueQuery should prevent reaching this condition");
                }
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (stream != null)
            {
                try
                {
                    stream.Close();
                    stream.Dispose();
                }
                catch (Exception)
                {
                }
                stream = null;
            }
            if (socket != null)
            {
                try
                {
                    socket.Close();
                    socket.Dispose();
                }
                catch (Exception)
                {
                }
                socket = null;
            }
        }

        #endregion
    }
}
