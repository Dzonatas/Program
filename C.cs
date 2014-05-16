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
	public C_Symbol StringConcat( string a, string b, string c )
		{
		C_TypeDef typedef = typedefset["string"] ;
		string _length = typedef.Struct[0] ;
		string _string = typedef.Struct[1] ;
		This.Statement( "static struct _string s" )
			.Statement( "s."+_length+" = a."+_length+" + b."+_length+" + c."+_length )
			.Statement( "s."+_string+" = malloc(a."+_length+" + b."+_length+" + c."+_length+")" )
			.Statement( "strncpy( s."+_string+", a."+_string+", a."+_length+" )" )
			.Statement( "strncpy( &s."+_string+"[a."+_length+"], b."+_string+", b."+_length+" )" )
			.Statement( "strncpy( &s."+_string+"[a."+_length+"+b."+_length+"], c."+_string+", c."+_length+" )" )
			;
		return C_Symbol.Acquire( "s" ) ;
		}
	public C_Function This ;
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
