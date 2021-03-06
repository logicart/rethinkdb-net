//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: RethinkDb.Spec.proto
namespace RethinkDb.Spec
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"VersionDummy")]
  public partial class VersionDummy : global::ProtoBuf.IExtensible
  {
    public VersionDummy() {}
    
    [global::ProtoBuf.ProtoContract(Name=@"Version")]
    public enum Version
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"V0_1", Value=1063369270)]
      V0_1 = 1063369270,
            
      [global::ProtoBuf.ProtoEnum(Name=@"V0_2", Value=1915781601)]
      V0_2 = 1915781601
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Query")]
  public partial class Query : global::ProtoBuf.IExtensible
  {
    public Query() {}
    

    private Query.QueryType _type = Query.QueryType.START;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Query.QueryType.START)]
    public Query.QueryType type
    {
      get { return _type; }
      set { _type = value; }
    }

    private Term _query = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"query", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Term query
    {
      get { return _query; }
      set { _query = value; }
    }

    private long _token = default(long);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"token", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long token
    {
      get { return _token; }
      set { _token = value; }
    }

    private bool _OBSOLETE_noreply = (bool)false;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"OBSOLETE_noreply", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool OBSOLETE_noreply
    {
      get { return _OBSOLETE_noreply; }
      set { _OBSOLETE_noreply = value; }
    }
    private readonly global::System.Collections.Generic.List<Query.AssocPair> _global_optargs = new global::System.Collections.Generic.List<Query.AssocPair>();
    [global::ProtoBuf.ProtoMember(6, Name=@"global_optargs", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Query.AssocPair> global_optargs
    {
      get { return _global_optargs; }
    }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"AssocPair")]
  public partial class AssocPair : global::ProtoBuf.IExtensible
  {
    public AssocPair() {}
    

    private string _key = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string key
    {
      get { return _key; }
      set { _key = value; }
    }

    private Term _val = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"val", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Term val
    {
      get { return _val; }
      set { _val = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"QueryType")]
    public enum QueryType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"START", Value=1)]
      START = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CONTINUE", Value=2)]
      CONTINUE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STOP", Value=3)]
      STOP = 3
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Frame")]
  public partial class Frame : global::ProtoBuf.IExtensible
  {
    public Frame() {}
    

    private Frame.FrameType _type = Frame.FrameType.POS;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Frame.FrameType.POS)]
    public Frame.FrameType type
    {
      get { return _type; }
      set { _type = value; }
    }

    private long _pos = default(long);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"pos", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long pos
    {
      get { return _pos; }
      set { _pos = value; }
    }

    private string _opt = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"opt", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string opt
    {
      get { return _opt; }
      set { _opt = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"FrameType")]
    public enum FrameType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"POS", Value=1)]
      POS = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OPT", Value=2)]
      OPT = 2
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Backtrace")]
  public partial class Backtrace : global::ProtoBuf.IExtensible
  {
    public Backtrace() {}
    
    private readonly global::System.Collections.Generic.List<Frame> _frames = new global::System.Collections.Generic.List<Frame>();
    [global::ProtoBuf.ProtoMember(1, Name=@"frames", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Frame> frames
    {
      get { return _frames; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Response")]
  public partial class Response : global::ProtoBuf.IExtensible
  {
    public Response() {}
    

    private Response.ResponseType _type = Response.ResponseType.SUCCESS_ATOM;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Response.ResponseType.SUCCESS_ATOM)]
    public Response.ResponseType type
    {
      get { return _type; }
      set { _type = value; }
    }

    private long _token = default(long);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"token", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long token
    {
      get { return _token; }
      set { _token = value; }
    }
    private readonly global::System.Collections.Generic.List<Datum> _response = new global::System.Collections.Generic.List<Datum>();
    [global::ProtoBuf.ProtoMember(3, Name=@"response", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Datum> response
    {
      get { return _response; }
    }
  

    private Backtrace _backtrace = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"backtrace", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Backtrace backtrace
    {
      get { return _backtrace; }
      set { _backtrace = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"ResponseType")]
    public enum ResponseType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"SUCCESS_ATOM", Value=1)]
      SUCCESS_ATOM = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SUCCESS_SEQUENCE", Value=2)]
      SUCCESS_SEQUENCE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SUCCESS_PARTIAL", Value=3)]
      SUCCESS_PARTIAL = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CLIENT_ERROR", Value=16)]
      CLIENT_ERROR = 16,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COMPILE_ERROR", Value=17)]
      COMPILE_ERROR = 17,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RUNTIME_ERROR", Value=18)]
      RUNTIME_ERROR = 18
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Datum")]
  public partial class Datum : global::ProtoBuf.IExtensible
  {
    public Datum() {}
    

    private Datum.DatumType _type = Datum.DatumType.R_NULL;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Datum.DatumType.R_NULL)]
    public Datum.DatumType type
    {
      get { return _type; }
      set { _type = value; }
    }

    private bool _r_bool = default(bool);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"r_bool", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool r_bool
    {
      get { return _r_bool; }
      set { _r_bool = value; }
    }

    private double _r_num = default(double);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"r_num", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(double))]
    public double r_num
    {
      get { return _r_num; }
      set { _r_num = value; }
    }

    private string _r_str = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"r_str", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string r_str
    {
      get { return _r_str; }
      set { _r_str = value; }
    }
    private readonly global::System.Collections.Generic.List<Datum> _r_array = new global::System.Collections.Generic.List<Datum>();
    [global::ProtoBuf.ProtoMember(5, Name=@"r_array", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Datum> r_array
    {
      get { return _r_array; }
    }
  
    private readonly global::System.Collections.Generic.List<Datum.AssocPair> _r_object = new global::System.Collections.Generic.List<Datum.AssocPair>();
    [global::ProtoBuf.ProtoMember(6, Name=@"r_object", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Datum.AssocPair> r_object
    {
      get { return _r_object; }
    }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"AssocPair")]
  public partial class AssocPair : global::ProtoBuf.IExtensible
  {
    public AssocPair() {}
    

    private string _key = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string key
    {
      get { return _key; }
      set { _key = value; }
    }

    private Datum _val = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"val", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Datum val
    {
      get { return _val; }
      set { _val = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"DatumType")]
    public enum DatumType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"R_NULL", Value=1)]
      R_NULL = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"R_BOOL", Value=2)]
      R_BOOL = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"R_NUM", Value=3)]
      R_NUM = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"R_STR", Value=4)]
      R_STR = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"R_ARRAY", Value=5)]
      R_ARRAY = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"R_OBJECT", Value=6)]
      R_OBJECT = 6
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Term")]
  public partial class Term : global::ProtoBuf.IExtensible
  {
    public Term() {}
    

    private Term.TermType _type = Term.TermType.DATUM;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Term.TermType.DATUM)]
    public Term.TermType type
    {
      get { return _type; }
      set { _type = value; }
    }

    private Datum _datum = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"datum", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Datum datum
    {
      get { return _datum; }
      set { _datum = value; }
    }
    private readonly global::System.Collections.Generic.List<Term> _args = new global::System.Collections.Generic.List<Term>();
    [global::ProtoBuf.ProtoMember(3, Name=@"args", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Term> args
    {
      get { return _args; }
    }
  
    private readonly global::System.Collections.Generic.List<Term.AssocPair> _optargs = new global::System.Collections.Generic.List<Term.AssocPair>();
    [global::ProtoBuf.ProtoMember(4, Name=@"optargs", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Term.AssocPair> optargs
    {
      get { return _optargs; }
    }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"AssocPair")]
  public partial class AssocPair : global::ProtoBuf.IExtensible
  {
    public AssocPair() {}
    

    private string _key = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string key
    {
      get { return _key; }
      set { _key = value; }
    }

    private Term _val = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"val", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Term val
    {
      get { return _val; }
      set { _val = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"TermType")]
    public enum TermType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"DATUM", Value=1)]
      DATUM = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAKE_ARRAY", Value=2)]
      MAKE_ARRAY = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAKE_OBJ", Value=3)]
      MAKE_OBJ = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"VAR", Value=10)]
      VAR = 10,
            
      [global::ProtoBuf.ProtoEnum(Name=@"JAVASCRIPT", Value=11)]
      JAVASCRIPT = 11,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR", Value=12)]
      ERROR = 12,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IMPLICIT_VAR", Value=13)]
      IMPLICIT_VAR = 13,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DB", Value=14)]
      DB = 14,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TABLE", Value=15)]
      TABLE = 15,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET", Value=16)]
      GET = 16,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_ALL", Value=78)]
      GET_ALL = 78,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQ", Value=17)]
      EQ = 17,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NE", Value=18)]
      NE = 18,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LT", Value=19)]
      LT = 19,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LE", Value=20)]
      LE = 20,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GT", Value=21)]
      GT = 21,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GE", Value=22)]
      GE = 22,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NOT", Value=23)]
      NOT = 23,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ADD", Value=24)]
      ADD = 24,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SUB", Value=25)]
      SUB = 25,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MUL", Value=26)]
      MUL = 26,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DIV", Value=27)]
      DIV = 27,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MOD", Value=28)]
      MOD = 28,
            
      [global::ProtoBuf.ProtoEnum(Name=@"APPEND", Value=29)]
      APPEND = 29,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PREPEND", Value=80)]
      PREPEND = 80,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DIFFERENCE", Value=95)]
      DIFFERENCE = 95,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_INSERT", Value=88)]
      SET_INSERT = 88,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_INTERSECTION", Value=89)]
      SET_INTERSECTION = 89,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_UNION", Value=90)]
      SET_UNION = 90,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_DIFFERENCE", Value=91)]
      SET_DIFFERENCE = 91,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SLICE", Value=30)]
      SLICE = 30,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SKIP", Value=70)]
      SKIP = 70,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LIMIT", Value=71)]
      LIMIT = 71,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INDEXES_OF", Value=87)]
      INDEXES_OF = 87,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CONTAINS", Value=93)]
      CONTAINS = 93,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GETATTR", Value=31)]
      GETATTR = 31,
            
      [global::ProtoBuf.ProtoEnum(Name=@"KEYS", Value=94)]
      KEYS = 94,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HAS_FIELDS", Value=32)]
      HAS_FIELDS = 32,
            
      [global::ProtoBuf.ProtoEnum(Name=@"WITH_FIELDS", Value=96)]
      WITH_FIELDS = 96,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLUCK", Value=33)]
      PLUCK = 33,
            
      [global::ProtoBuf.ProtoEnum(Name=@"WITHOUT", Value=34)]
      WITHOUT = 34,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MERGE", Value=35)]
      MERGE = 35,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BETWEEN", Value=36)]
      BETWEEN = 36,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REDUCE", Value=37)]
      REDUCE = 37,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAP", Value=38)]
      MAP = 38,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FILTER", Value=39)]
      FILTER = 39,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CONCATMAP", Value=40)]
      CONCATMAP = 40,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ORDERBY", Value=41)]
      ORDERBY = 41,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DISTINCT", Value=42)]
      DISTINCT = 42,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COUNT", Value=43)]
      COUNT = 43,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IS_EMPTY", Value=86)]
      IS_EMPTY = 86,
            
      [global::ProtoBuf.ProtoEnum(Name=@"UNION", Value=44)]
      UNION = 44,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NTH", Value=45)]
      NTH = 45,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GROUPED_MAP_REDUCE", Value=46)]
      GROUPED_MAP_REDUCE = 46,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GROUPBY", Value=47)]
      GROUPBY = 47,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INNER_JOIN", Value=48)]
      INNER_JOIN = 48,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OUTER_JOIN", Value=49)]
      OUTER_JOIN = 49,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQ_JOIN", Value=50)]
      EQ_JOIN = 50,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ZIP", Value=72)]
      ZIP = 72,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSERT_AT", Value=82)]
      INSERT_AT = 82,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DELETE_AT", Value=83)]
      DELETE_AT = 83,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CHANGE_AT", Value=84)]
      CHANGE_AT = 84,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SPLICE_AT", Value=85)]
      SPLICE_AT = 85,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COERCE_TO", Value=51)]
      COERCE_TO = 51,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPEOF", Value=52)]
      TYPEOF = 52,
            
      [global::ProtoBuf.ProtoEnum(Name=@"UPDATE", Value=53)]
      UPDATE = 53,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DELETE", Value=54)]
      DELETE = 54,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REPLACE", Value=55)]
      REPLACE = 55,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSERT", Value=56)]
      INSERT = 56,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DB_CREATE", Value=57)]
      DB_CREATE = 57,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DB_DROP", Value=58)]
      DB_DROP = 58,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DB_LIST", Value=59)]
      DB_LIST = 59,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TABLE_CREATE", Value=60)]
      TABLE_CREATE = 60,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TABLE_DROP", Value=61)]
      TABLE_DROP = 61,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TABLE_LIST", Value=62)]
      TABLE_LIST = 62,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INDEX_CREATE", Value=75)]
      INDEX_CREATE = 75,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INDEX_DROP", Value=76)]
      INDEX_DROP = 76,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INDEX_LIST", Value=77)]
      INDEX_LIST = 77,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FUNCALL", Value=64)]
      FUNCALL = 64,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BRANCH", Value=65)]
      BRANCH = 65,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ANY", Value=66)]
      ANY = 66,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALL", Value=67)]
      ALL = 67,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FOREACH", Value=68)]
      FOREACH = 68,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FUNC", Value=69)]
      FUNC = 69,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ASC", Value=73)]
      ASC = 73,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DESC", Value=74)]
      DESC = 74,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INFO", Value=79)]
      INFO = 79,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MATCH", Value=97)]
      MATCH = 97,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SAMPLE", Value=81)]
      SAMPLE = 81,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DEFAULT", Value=92)]
      DEFAULT = 92
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}