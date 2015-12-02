partial class A335
{
public class C_Type
	{
	C_Symbol[] idset ;
	internal C_Type( string[] symbolset )
		{
		idset = new C_Symbol[symbolset.Length] ;
		int i = 0 ;
		foreach( string s in symbolset )
			idset[i++] = C_Symbol.Acquire( s ) ;
		}
	internal C_Type( C_Symbol[] symbolset )
		{
		idset = symbolset ;
		}
	internal C_Type( C_Symbol symbol )
		{
		idset    = new C_Symbol[2] ;
		idset[0] = new C_Undefined() ;
		idset[1] = symbol ;
		}
	C_Type( string symbol )
		: this( C_Symbol.Acquire( symbol ) )
		{}
	static public C_Type Acquire( string type )
		{
		return Program.C_Type_Acquire( C_Symbol.Acquire( type ) ) ;
		}
	static public C_Type Acquire( C_Symbol symbol )
		{
		return Program.C_Type_Acquire( symbol ) ;
		}
	static public C_Type Acquire( string[] symbolset )
		{
		return Program.C_Type_Acquire( symbolset ) ;
		}
	static public C_Type Acquire( C_Symbol[] symbolset )
		{
		return Program.C_Type_Acquire( symbolset ) ;
		}
	static public C_Type Undefined
		{
		get { return C_Type.Acquire( new C_Undefined() ) ; }
		}
	static public implicit operator string( C_Type c )
		{
		string s = null ;
		foreach( C_Symbol symbol in c.idset )
			{
			if( symbol is C_Undefined && s == null )
				continue ;
			s += ( s == null ? string.Empty : "$" ) + symbol ;
			}
		return s ;
		}
	static public explicit operator string[]( C_Type c )
		{
		string[] s = new string[c.idset.Length] ;
		int i = 0 ;
		foreach( C_Symbol symbol in c.idset )
			s[i++] = symbol ;
		return s ;
		}
	public int Count
		{
		get { return idset.Length ; }
		}
	public C_Symbol this[int n]
		{
		get { return idset[n] ; }
		}
	static public C_Type ConstStatic( C699.c typeSpec )
		{
		var s = new C_Symbol[2] ;
		s[0] = C_Symbol.Acquire( C699.KeyedWord.Const+' '+C699.KeyedWord.Static ) ;
		s[1] = C_Symbol.Acquire( ((string)typeSpec).Trim() ) ;
		return Program.C_Type_Acquire( s ) ;
		}
	static public C_Type Const( C699.c typeSpec )
		{
		var s = new C_Symbol[2] ;
		s[0] = C_Symbol.Acquire( C699.KeyedWord.Const ) ;
		s[1] = C_Symbol.Acquire( ((string)typeSpec).Trim() ) ;
		return Program.C_Type_Acquire( s ) ;
		}
	static public C_Type Static( C699.c typeSpec )
		{
		var s = new C_Symbol[2] ;
		s[0] = C_Symbol.Acquire( C699.KeyedWord.Static ) ;
		s[1] = C_Symbol.Acquire( ((string)typeSpec).Trim() ) ;
		return Program.C_Type_Acquire( s ) ;
		}
	public C699.c Spec
		{
		get { return new C699.c(idset[idset.Length-1]+' ') ; }
		}
	public C699.c TypeSpec
		{
		get { return new C699.c(string.Join(" ", (string[])this)+' ') ; }
		}
	public C_Type Deref
		{
		get {
			var ids = (string[]) this ;
			var s = ids[ids.Length-1] ;
			var i = s.LastIndexOf('*') ;
			if( i == -1 )
				throw new System.NotImplementedException() ;
			var t = ids[ids.Length-1] = s.Substring(0,i) + s.Substring(i+1) ;
			if( s == t )
				throw new System.NotImplementedException() ;
			return C_Type.Acquire( ids ) ;
			}
		}
	public C_Type Ref
		{
		get {
			var ids = (string[]) this ;
			var s = ids[ids.Length-1] ;
			var i = s.LastIndexOf('*') ;
			if( i == -1 )
				s += " " ;
			s += "*" ;
			ids[ids.Length-1] = s ;
			return C_Type.Acquire( ids ) ;
			}
		}
	public string Type
		{
		get
			{
			string text = idset[idset.Length-1] ;
			if( text.EndsWith( "_unsigned_int" ) )
				return "unsigned int" ;
			if( text.EndsWith( "_char_p" ) )
				return "char*" ;
			if( text.EndsWith( "_p" ) && text != "_p" )
				{
				string capitol = text.Substring( text.Length - "_p".Length ) ;
				if( capitol == capitol.ToUpper() )
					return capitol + "_type" ;
				throw new System.NotSupportedException() ;
				}
			throw new UndefinedTypeException() ; //_ID_ID_ID_...
			}
		}
	public class UndefinedTypeException : System.Exception		{}
	}

static C_Type C_I4_0 = C_Type.Const( C699.C.Int ) ;
static C_Type C_I4_1 = C_Type.Const( C699.C.Int ) ;
static C_Type C_I4_2 = C_Type.Const( C699.C.Int ) ;
static C_Type C_I4_3 = C_Type.Const( C699.C.Int ) ;
static C_Type C_I4_4 = C_Type.Const( C699.C.Int ) ;
static C_Type C_I4_5 = C_Type.Const( C699.C.Int ) ;
static C_Type C_I4_6 = C_Type.Const( C699.C.Int ) ;
static C_Type C_I4_7 = C_Type.Const( C699.C.Int ) ;
static C_Type C_I4_8 = C_Type.Const( C699.C.Int ) ;
static C_Type C_I4_9 = C_Type.Const( C699.C.Int ) ;
}