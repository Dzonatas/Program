//using System.C.IDE.MonoDevelop;//C.I.S.("ecma.cproj")
using System.Extensions ;
using System.Text.RegularExpressions ;
using System ;

partial class A335
{

partial class Program
	{
	static internal C_Symbol C_Symbol_Acquire( string symbol )
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
		var symbol = C_Symbol_Acquire( String.Join( ",", symbolset ) ) ;
		C_Type c ;
		if( ! typeset.ContainsKey( symbol ) )
			typeset.Add( symbol, c = new C_Type( symbolset ) ) ;
		else
			c = typeset[symbol] ;
		return c ;
		}
	static internal C_Type C_Type_Acquire( C_Symbol[] symbolset )
		{
		string _symbol = null ;
		foreach( string i in symbolset )
			_symbol += ( _symbol == null ? String.Empty : "," ) + i ;
		var symbol = C_Symbol_Acquire( _symbol ) ;
		C_Type c ;
		if( ! typeset.ContainsKey( symbol ) )
			typeset.Add( symbol, c = new C_Type( symbolset ) ) ;
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
		: base( Regex.Replace( Guid.NewGuid().ToString(), "[^A-Za-z_0-9]", "_").ToUpper() )
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
			s += ( s == null ? String.Empty : "$" ) + symbol ;
			}
		return s ;
		}
	static public implicit operator C_Symbol( C_Type c )
		{
		if( (string) c == "string" )
			return C_Symbol.Acquire( "struct _string" ) ;
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
			throw new System.NotImplementedException( "Undefined type." ) ; //_ID_ID_ID_...
			}
		}
	}

static C_Type C_I4_0 = C_Type.Acquire( "C_I4_0" ) ;
static C_Type C_I4_1 = C_Type.Acquire( "C_I4_1" ) ;
static C_Type C_I4_2 = C_Type.Acquire( "C_I4_2" ) ;
static C_Type C_I4_3 = C_Type.Acquire( "C_I4_3" ) ;
static C_Type _C_ARY = C_Type.Acquire( "_C_ARY" ) ;

class C_Label
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
		Array.Resize( ref labelset, labelset.Length +1 ) ;
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

class Class
	{
	static C_Symbol[] idset = new C_Symbol[0] ;
	static void idset_add( string id )
		{
		Array.Resize( ref idset, idset.Length +1 ) ;
		idset[idset.Length - 1] = C_Symbol.Acquire( id ) ;
		return ;
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
	static public C_Type Type
		{
		get { return C_Type.Acquire( idset ) ; }
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


namespace Current {
#if WORK
static class Work
	{
	const  string     path = @"/tmp/.5a7160ed-13d5-4923-a1f9-3e32a47d558a.d" ;
	static string  current = path ;
	static XEvent        _ ;
	static class        DI
		{
		static System.IO.DirectoryInfo directory ;
		static DI()
			{
			directory = new System.IO.DirectoryInfo(path) ;
			if( directory.Exists )
				return ;
			directory = System.IO.Directory.CreateDirectory(path) ;
			if( directory.Exists )
				return ;
			throw new System.NotSupportedException( "Obtained path collusion." ) ;
			}
		}
	}
#endif
public static class Estate
	{
	const  string     path = @"/tmp/.5a7160ed-13d5-4923-a1f9-3e32a47d558a.d/.git" ;
	//const  string      uri = @"git:5a7160ed-13d5-4923-a1f9-3e32a47d558a:master" ;
	static class        DI
		{
		static System.IO.DirectoryInfo directory ;
		static DI()
			{
			directory = new System.IO.DirectoryInfo(path) ;
			if( directory.Exists )
				return ;
			throw new System.NotImplementedException( "Obtained region collusion." ) ;
			}
		}
	public static class        Current__System_File
		{
		static public string Path
			{
			get { return "PANZOR/" + path ; }
			}
		static System.IO.DirectoryInfo directory ;
		static Current__System_File()
			{
			//return:git.head:System.File.cs
			throw new System.NotImplementedException( "Initialized." ) ;
			}
		}
	}
static class Path
	{
	const  string     path = @"/tmp/.5a7160ed-13d5-4923-a1f9-3e32a47d558a.d" ;
	static System.IO.DirectoryInfo directory ;
	static Path()
		{
		directory = new System.IO.DirectoryInfo(path) ;
		if( directory.Exists )
			return ;
		directory = System.IO.Directory.CreateDirectory(path) ;
		if( directory.Exists )
			return ;
		throw new System.NotSupportedException( "Obtained path collusion." ) ;
		}
	static public System.IO.StreamWriter CreateText( string name )
		{
		return System.IO.File.CreateText( path + "/" + name ) ;
		}
	}
}
