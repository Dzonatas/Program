//using System.C.IDE.MonoDevelop;//C.I.S.("ecma.cproj")
using System.Extensions ;
using System.Text.RegularExpressions ;
using System ;

partial class A335
{
#if COPY
#endif

partial class Program
	{
	static internal C_Symbol C_Symbol_Aquire( string symbol )
		{
		C_Symbol c ;
		if( ! symbolset.ContainsKey( symbol ) )
			symbolset.Add( symbol, c = new C_Symbol( symbol ) ) ;
		else
			c = symbolset[symbol] ;
		return c ;
		}
	static internal C_Type C_Type_Acquire( C_Symbol symbol )
		{
		C_Type c;
		if( ! typeset.ContainsKey( symbol ) )
			typeset.Add( symbol, c = new C_Type( symbol ) ) ;
		else
			c = typeset[symbol] ;
		return c ;
		}
	static internal C_Type C_Type_Acquire( string[] symbolset )
		{
		return C_Type_Acquire( C_Symbol_Aquire( String.Join( ",", symbolset ) ) ) ;
		}
	public C_Symbol StringConcat( C_Literal a, C_Literal b, C_Literal c )
		{
		C_TypeDef typedef = typedefset["string"] ;
		string _length = typedef.Struct[0] ;
		string _string = typedef.Struct[1] ;
		string s_length = "s." + _length ;
		string s_string = "s." + _string ;
		string a_length = a + "." + _length ;
		string a_string = a + "." + _string ;
		string b_length = b + "." + _length ;
		string b_string = b + "." + _string ;
		string c_length = c + "." + _length ;
		string c_string = c + "." + _string ;
		This.Statement( "static struct _string s" )
			.Statement( s_length+" = "+a_length+" + "+b_length+" + "+c_length )
			.Statement( s_string+" = malloc( "+a_length+" + "+b_length+" + "+c_length+" )" )
			.Statement( "strncpy( "+s_string+", "+a_string+", "+a_length+" )" )
			.Statement( "strncpy( &"+s_string+"["+a_length+"], "+b_string+", "+b_length+" )" )
			.Statement( "strncpy( &"+s_string+"["+a_length+"+"+b_length+"], "+c_string+", "+c_length+" )" )
			;
		return C_Symbol.Acquire( "s" ) ;
		}
	public C_Function This ;
	C_Literal[] register ;
	public C_Function Register( C_Function f, C_Symbol type, string name )
		{
		C_Literal literal ;
		if( register == null )
			{
			register = new C_Literal[1] ;
			literal = register[0] ;
			}
		else
			{
			Array.Resize( ref register, register.Length + 1 ) ;
			literal = register[ register.Length - 1 ] ;
			}
		literal.Function  = f ;
		literal.Type      = type ;
		literal.Name      = name ;
		register[ register.Length - 1 ] = literal ;
		This.Statement( type + " " + name ) ;
		return f ;
		}
	public struct C_Literal
		{
		public C_Function  Function ;
		public C_Symbol    Type ;
		public string      Name ;
		public override string ToString()
				{
				return Name ;
				}
		}
	public C_Literal this[int n]
		{
		get {
			return register[n] ;
			}
		}
	public C_Literal this[string name]
		{
		get {
			foreach( C_Literal literal in register )
				if( name == literal.Name )
					return literal ;
			throw new FieldAccessException( name ) ;
			}
		}
	}

public class C_Symbol
	{
	string symbol ;
	public string By_p()
		{
		string pid = Guid.NewGuid().ToString().ToStemString() ;
		if( this.symbol[0] == '_' )  //Logical+ID,^'_'[<IDc>]+,(P==NP)=>>(P!=NP)
			return pid + this.symbol + "_p" ;
		string symbol ;
		symbol = "_" + this.symbol.ToStemString() ;
		return pid + symbol + "_p" ;
		}
	internal C_Symbol( string symbol )
		{
		this.symbol = symbol ;
		}
	public C_Symbol()
		{
		symbol = "_" + Guid.NewGuid().ToID() ;
		}
	static public C_Symbol Acquire( string symbol )
		{
		return Program.C_Symbol_Aquire( symbol ) ;
		}
	static public implicit operator string( C_Symbol c )
		{
		return c.symbol ;
		}
	}

public class C_Undefined : C_Symbol
	{
	public C_Undefined()
		: base( Regex.Replace( Guid.NewGuid().ToString(), "[^A-Za-z_0-9]", "_").ToUpper() )
		{}
	}

public class C_Type
	{
	C_Symbol[] idset ;
	/*//internal string StemString ;
	internal C_Type( C_Symbol[] symbolset )
		{
		idset    = new C_Symbol[ 1 + symbolset.Length ] ;
		idset[0] = new C_Undefined() ;
		symbolset.CopyTo( idset, 1 ) ;
		}*/
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
	static public implicit operator string( C_Type c )
		{
		return c.idset[c.idset.Length-1] ;
		}
	static public implicit operator C_Symbol( C_Type c )
		{
		if( (string) c == "string" )
			return C_Symbol.Acquire( "struct _string" ) ;
		return c.idset[c.idset.Length-1] ;
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
			throw new System.NotImplementedException( "Unknown type." ) ; //_ID_ID_ID_...
			}
		}
	}

class Class
	{
	static C_Symbol[] idset = new C_Symbol[0] ;
	static void idset_add( string id )
		{
		Array.Resize( ref idset, idset.Length +1 ) ;
		idset[idset.Length - 1] = C_Symbol.Acquire( id ) ;
		}
	public class Head : Automatrix
		{
		static public string ID
			{
			set { idset_add( value ) ;  }
			}
		}
	public class Decl : Automatrix
		{
		public void Declared()
			{
			Array.Resize( ref idset, idset.Length -1 ) ;
			}
		}
	static public string Symbol
		{
		get {
			string s = null ;
			foreach( string i in idset )
				s += ( s == null ? String.Empty : "$" ) + i ;
			return s ;
			}
		}
	static public void Declared()
		{
		Array.Resize( ref idset, String.Empty.Length ) ;
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
