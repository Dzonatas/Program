//using System.C.IDE.MonoDevelop;//C.I.S.("ecma.cproj")
using System.Text.RegularExpressions ;
using System ;

partial class A335
{
#if COPY
#endif

partial class Program
	{
	static public C_Symbol C_Symbol_Aquire( string symbol )
		{
		C_Symbol c ;
		if( ! symbolset.ContainsKey( symbol ) )
			symbolset.Add( symbol, c = new C_Symbol( symbol ) ) ;
		else
			c = symbolset[symbol] ;
		return c ;
		}
	static public C_Type C_Type_Acquire( string symbol )
		{
		C_Type c;
		if( ! typeset.ContainsKey( symbol ) )
			typeset.Add( symbol, c = new C_Type( symbol ) ) ;
		else
			c = typeset[symbol] ;
		return c ;
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
	Guid ID ;
	string symbol ;
	internal C_Symbol( string symbol )
		{
		this.symbol = symbol ;
		ID = Guid.NewGuid() ;
		}
	public C_Symbol()
		{
		ID = Guid.NewGuid() ;
		symbol = "_" + Regex.Replace( ID.ToString(), "[^A-Za-z_0-9]", "_").ToLower() ;
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

public class C_Type
	{
	C_Symbol symbol ;
	//Guid ID ;
	public C_Type( string symbol )
		{
		//ID = Guid.NewGuid() ;
		this.symbol = C_Symbol.Acquire( symbol ) ;
		}
	static public C_Type Acquire( string symbol )
		{
		return Program.C_Type_Acquire( symbol ) ;
		}
	static public implicit operator string( C_Type c )
		{
		return c.symbol ;
		}
	static public implicit operator C_Symbol( C_Type c )
		{
		if( c.symbol == "string" )
			return C_Symbol.Acquire( "struct _string" ) ;
		return c.symbol ;
		}
	public string Type
		{
		get
			{
			string text = symbol ;
			if( text.EndsWith( "_unsigned_int" ) )
				return "unsigned int" ;
			if( text.EndsWith( "_char_p" ) )
				return "char*" ;
			throw new System.NotSupportedException( "Unknown type." ) ; //_ID_ID_ID_...
			}
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
