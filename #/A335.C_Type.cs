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

static C_Type C_I4_0 = C_Type.Acquire( "C_I4_0" ) ;
static C_Type C_I4_1 = C_Type.Acquire( "C_I4_1" ) ;
static C_Type C_I4_2 = C_Type.Acquire( "C_I4_2" ) ;
static C_Type C_I4_3 = C_Type.Acquire( "C_I4_3" ) ;
static C_Type _C_ARY = C_Type.Acquire( "_C_ARY" ) ;
}