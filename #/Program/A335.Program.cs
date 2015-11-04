using System.Collections.Generic ;
using System.Text.RegularExpressions ;
using System.Extensions ;

partial class A335
{
public partial class Program
	{
	static Dictionary<string,object>      virtualset    = new Dictionary<string,object>() ;
	static Dictionary<string,C_Function>  c_functionset = new Dictionary<string, C_Function>() ;
	static Dictionary<string,C_Symbol>    symbolset     = new Dictionary<string, C_Symbol>() ;
	static Dictionary<C_Symbol,C_Type>    typeset       = new Dictionary<C_Symbol, C_Type>() ;
	static Dictionary<string,C_TypeDef>   typedefset    = new Dictionary<string, C_TypeDef>() ;
	static Program C = new Program() ;
	static C_Type[] stack = new C_Type[0] ;
	static int stack_offset ;
	static int stack_down ;
	//static uint effective_symbolic_objective_credit ;
	public C_Function This ;
	Program()
		{
		}
	public Program( Automatrix auto )
		{
		}
	public Program Language
		{
		get { return this ; }
		}
	static public void Write()
		{
		Program.WriteC_Main() ;
		A335.Method.Write() ;
		Program.WriteC_Objects() ;
		}
	static public C_Function jiffy( string description )
		{
		return C.This = C_Method.CreateFunction( description ) ;
		}
	static public System.Type Function
		{
		get { return typeof(C_Function) ; }
		}
	static public void WriteC_Main()
		{
		var sw = C699_Main_Function___WriteTo__C699_Main_FileStructure__() ;
		foreach( C_TypeDef t in typedefset.Values )
			t.Struct.WriteTo( sw ) ;
		foreach( C_Function f in c_functionset.Values )
			{
			if( f.Required && ( f.Symbol.StartsWith( "BCL$" ) || f.Symbol.StartsWith( "System" ) ) )
				{
				f.WriteTo( sw ) ;
				}
			}
		foreach( string i in Class.Types )
			sw.WriteLine( "#include \""+i+".h\"" ) ;
		A335.Method.WriteIncludesTo( sw ) ;
	    foreach( string class_symbol in virtualset.Keys )
			C_Struct.FromSymbol( class_symbol ).WriteInclude( sw ) ;
		sw.Close() ;
		}
	static public void WriteC_Objects()
		{
	    foreach( string class_symbol in virtualset.Keys )
			{
			var sw = Current.Path.CreateText( class_symbol + ".c" ) ;
			var c = ((C_Struct) virtualset[class_symbol]) ;
			c.WriteTo( sw ) ;
			sw.Close() ;
			}
		}
	static string c_guid()
		{
		return "_" + System.Text.RegularExpressions.Regex.Replace
			( System.Guid.NewGuid().ToString(), "[^A-Za-z_0-9]", "_" ).ToLower() ;
		}
	static C_Type _UnsignedInt()
		{
		return C_Type.Acquire( c_guid() + "_unsigned_int" ) ;
		}
	static C_Type _Char_()
		{
		return C_Type.Acquire( c_guid() + "_char_p" ) ;
		}
	static public void Begin()
		{
		C_Type _length = _UnsignedInt() ;
		C_Type _string = _Char_() ;
		C.TypeDef.String
			.Parameter( _length )
			.Parameter( _string )
			;
		C.TypeDef.Object
			.Parameter( C699.Object(1) , "this" )
			.Parameter( C699.String, C699.C.Restricted("(*$ToString)").Tut(C699.C.Const.Voidpp) )
			;
		jiffy( "object::.ctor" )
			;
		jiffy( "console::WriteLine(string)" )
			.ConstLocalArg0
			.StandardOutputWriteLocal( _string , _length )
			.StandardOutputWriteLine()
			;
		jiffy( "string string::Concat(object,object,object)" )
			.Register( C699.String )
			.Register( C699.String )
			.Register( C699.String )
			.Let( C[0] ).Equal.ManagedArgument( 0 )
			.Let( C[1] ).Equal.ManagedArgument( 1 )
			.Let( C[2] ).Equal.ManagedArgument( 2 )
			.Return( C.StringConcat( C[0], C[1], C[2] ) )
			;
		jiffy( "string string::Concat(string,string)" )
			.ConstLocalArg( 0 )
			.ConstLocalArg( 1 )
			.Return( C.StringConcatLocal0Local1() )
			;
		//jiffy( pet( "fetch::", cube, sphere ) )
		//	;
		}
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
		var symbol = C_Symbol_Acquire( string.Join( ",", symbolset ) ) ;
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
			_symbol += ( _symbol == null ? string.Empty : "," ) + i ;
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
		var    s_length = C699.C.Literal( "s."   + _length) ;
		var    s_string = C699.C.Literal( "s."   + _string) ;
		var    a_length = C699.C.Literal(a + "." + _length) ;
		var    a_string = C699.C.Literal(a + "." + _string) ;
		var    b_length = C699.C.Literal(b + "." + _length) ;
		var    b_string = C699.C.Literal(b + "." + _string) ;
		var    c_length = C699.C.Literal(c + "." + _length) ;
		var    c_string = C699.C.Literal(c + "." + _string) ;
		This.Statement( C699.C.Static(C699.String,"s") )
			.Statement( s_length.Equate(a_length+" + "+b_length+" + "+c_length) )
			.Statement( s_string.Equate("malloc( "+a_length+" + "+b_length+" + "+c_length+" )" ) )
			.Statement( C699.Strncpy(s_string,a_string,a_length) )
			.Statement( C699.Strncpy('&'+s_string+'['+a_length+']',b_string,b_length) )
			.Statement( C699.Strncpy('&'+s_string+'['+a_length+'+'+b_length+']',c_string,c_length) )
			;
		return C_Symbol.Acquire( "s" ) ;
		}
	public C_Symbol StringConcatLocal0Local1()
		{
		C_TypeDef typedef = typedefset["string"] ;
		string _length = typedef.Struct[0] ;
		string _string = typedef.Struct[1] ;
		var    s_length = C699.C.Literal( "s."   + _length) ;
		var    s_string = C699.C.Literal( "s."   + _string) ;
		var    a_length = C699.C.Literal("_local0->" + _length) ;
		var    a_string = C699.C.Literal("_local0->" + _string) ;
		var    b_length = C699.C.Literal("_local1->" + _length) ;
		var    b_string = C699.C.Literal("_local1->" + _string) ;
		This.Statement( C699.C.Static(C699.String,"s") )
			.Statement( s_length.Equate(a_length+" + "+b_length) )
			.Statement( s_string.Equate("malloc( "+a_length+" + "+b_length+" )" ) )
			.Statement( C699.Strncpy(s_string,a_string,a_length) )
			.Statement( C699.Strncpy('&'+s_string+'['+a_length+']',b_string,b_length) )
			;
		return C_Symbol.Acquire( "s" ) ;
		}
	public C_Function Register( C_Function f, C699.c type, string name )
		{
		C_Literal literal ;
		if( register == null )
			{
			register = new C_Literal[1] ;
			literal = register[0] ;
			}
		else
			{
			System.Array.Resize( ref register, register.Length + 1 ) ;
			literal = register[ register.Length - 1 ] ;
			}
		literal.Function  = f ;
		literal.Type      = type ;
		literal.Name      = C699.C.Literal(name) ;
		register[ register.Length - 1 ] = literal ;
		This.Statement( C699.C.Struct(type,name) ) ;
		return f ;
		}
	static void stack_add( C_Type type )
		{
		System.Array.Resize( ref stack, stack.Length+1 ) ;
		stack[stack.Length-1] = type ;
		}
	public int StackOffset
		{
		get { return stack_offset - stack_down ; }
		}
	#if MICRODATA
	public void Push( Microdata stack_item_data )
		{
		stack[stack_offset] = stack_item_data ;
		stack_offset++ ;
		}
	public void Push1( C_Type string_line_x )
		{
		Push( new Microdata( true, string_line_x ) ) ;
		}
	public void Push( C_Type string_line )
		{
		Push( new Microdata( false, string_line ) ) ;
		}
	#else
	public void Push1( C_Type string_line_x )
		{
		stack[stack_offset] = string_line_x ;
		stack_offset++ ;
		}
	public void Push( C_Type string_line )
		{
		if( string_line == null )
			string_line = null ;
		stack[stack_offset] = string_line ;
		stack_offset++ ;
		}
	#endif
	public void Push( string type )
		{
		Push( C_Type.Acquire( type ) ) ;
		}
	public C_Type Pop()
		{
		stack_offset-- ;
		return stack[stack_offset] ;
		}
	#if MICRODATA
	public object Pop()
		{
		stack_offset-- ;
		return stack[stack_offset] ;
		}
	public List<Microdata> Hangup( int iargs )
		{
		var list = new List<Microdata>() ;
		stack_offset -= iargs ;
		for( int i = 0 ; i < iargs ; i++ )
			list.Add( stack[stack_offset+i] ) ;
		return list ;
		}
	#else
	public C_Type[] Hangup( int iargs )
		{
		if( iargs < 1 )
			return new C_Type[] {} ;
		var list = new C_Type[iargs] ;
		stack_offset -= iargs ;
		for( int i = 0 ; i < iargs ; i++ )
			list[i] = stack[stack_offset+i] == null ? C_Type.Undefined : stack[stack_offset+i] ;
		return list ;
		}
	#endif
	public void Hangdown()
		{
		stack_down = stack_offset ;
		}
	public int MaxStack
		{
		set {
			if( stack_offset + value > stack.Length )
				{
				//stack.Capacity += value ;
				for( int i = 0 ; i < value ; i++ )
					stack_add( null ) ;
				}
			}
		}
	public static System.IO.StreamWriter C699_Main_Function___WriteTo__C699_Main_FileStructure__()
		{
		var c = C_Function.FromSymbol( A335.Main.Symbol ) ;
		c.Args = C699.Main.Args ;
		c.Type = C699.C.Int ;
		var e = A335.Method.EntryPoint.Head ;
		if( string.Join( "!", Class.Cctors).Contains( e.ClassType ) )
		//if( e.Cctor )
			{
			c.Statement( C699.C.Extern.Void.Cctor(e.ClassType) ) ;
			c.Statement( C699.C.Cctor(e.ClassType) ) ;
			}
		c.Statement( C699.C.Extern.Void.Function(e.ClassType,  "Main") ) ;
		c.Statement( C699.C.Function(e.ClassType, "Main") ) ;
		c.Statement( C699.C.Return("0") ) ;
		c.WriteTo( C699.Main.FileStructure ) ;
		return C699.Main.FileStructure ;
		}
	}
}

