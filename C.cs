partial class A335
{


public class C_Symbol
	{
	string symbol ;
	public static string ToStemString(string d)
		{
		string a = d ;
		a = System.Text.RegularExpressions.Regex.Replace( a, "[^A-Za-z_0-9]", "_") ;
		a = a.ToUpper() ;
		return "_" + a ;
		//return "_" + Regex.Replace( d, "[^A-Za-z_0-9]", "_").ToUpper() ;
		}
	public static string ToID(System.Guid d)
		{
		return System.Text.RegularExpressions.Regex.Replace( d.ToString(), "[^A-Za-z_0-9]", "_").ToLower() ;
		}
	public string By_p()
		{
		string pid = ToStemString( System.Guid.NewGuid().ToString() ) ;
		if( this.symbol[0] == '_' )  //Logical+ID,^'_'[<IDc>]+,(P==NP)=>>(P!=NP)
			return pid + this.symbol + "_p" ;
		string symbol ;
		symbol = "_" + ToStemString( this.symbol ) ;
		return pid + symbol + "_p" ;
		}
	internal C_Symbol( string symbol )
		{
		this.symbol = symbol ;
		}
	public C_Symbol()
		{
		symbol = "_" + ToID( System.Guid.NewGuid() ) ;
		}
	static public C_Symbol Acquire( string symbol )
		{
		return Program.C_Symbol_Acquire( symbol ) ;
		}
	static public implicit operator string( C_Symbol c )
		{
		return c.symbol ;
		}
	}

public class C_Undefined : C_Symbol
	{
	public C_Undefined()
		: base( System.Text.RegularExpressions.Regex.Replace( System.Guid.NewGuid().ToString(), "[^A-Za-z_0-9]", "_").ToUpper() )
		{}
	}

public class C_Type
	{
	C_Symbol[] idset ;
	//internal string StemString ;
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
	static public implicit operator C_Symbol( C_Type c )
		{
		if( (string) c == "string" )
			return C_Symbol.Acquire( C699.String ) ;
		return c.idset[c.idset.Length-1] ;
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

public class C_Label
	{
	C_Symbol  label ;
	bool      required ;
	static C_Label[] labelset = new C_Label[0] ;
	C_Label( string label )
		{
		this.label = C_Symbol.Acquire( label ) ;
		}
	C_Label( C_Symbol symbol )
		{
		label = symbol ;
		}
	static public C_Label Acquire( C_Symbol symbol )
		{
		C_Label label = A335.Method.Decl.Find( symbol ) ;
		if( label != null )
			return label ;
		for( int i = 0 ; i < labelset.Length ; i++ )
			{
			if( labelset[i].label == symbol )
				return labelset[i] ;
			}
		System.Array.Resize( ref labelset, labelset.Length +1 ) ;
		return labelset[labelset.Length-1] = new C_Label( symbol ) ;
		}
	static public C_Label Acquire( string symbol )
		{
		return Acquire( C_Symbol.Acquire( symbol ) ) ;
		}
	static public C_Label Require( string symbol )
		{
		C_Label label = Acquire( symbol ) ;
		label.required = true ;
		return label ;
		}
	static public C_Label Empty = new C_Label( System.String.Empty ) ;
	public bool Required
		{
		get { return required ; }
		}
	static public implicit operator string( C_Label label )
		{
		return label.label ;
		}
	}


public class Channel   // : X-Window
	{
	//VisualType:StaticGray|StaticColor|GrayScale
	//WINGRAVITY:Static
	//BITGRAVITY:Static
	//Depth:Array
	//oprands:
	System.IntPtr  display ;
	System.IntPtr  screen  ;
	System.IntPtr  sid     ;
	System.IntPtr  line    ;
	#if CAIRO
	System.IntPtr  flush   ;
	#endif
	//rez:
	object []      items   ;
	}

#region macro
/*
<COMPQSTRING> | <compQstring item-scope item-i/>
*/
#endregion macro
}

namespace System.Extensions
	{
	public static class C_Type_
		{
		}
	}
