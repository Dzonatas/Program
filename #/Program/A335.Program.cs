using System.Collections.Generic ;
using System.Extensions ;

partial class A335
{
public partial class Program : C699
	{
	static Dictionary<string,object>      virtualset    = new Dictionary<string,object>() ;
	static Dictionary<string,C_Function>  c_functionset = new Dictionary<string, C_Function>() ;
	static Dictionary<string,C_Symbol>    symbolset     = new Dictionary<string, C_Symbol>() ;
	static Dictionary<C_Symbol,C_Type>    typeset       = new Dictionary<C_Symbol, C_Type>() ;
	static Dictionary<string,C_TypeDef>   typedefset    = new Dictionary<string, C_TypeDef>() ;
	static C_ValueType[] stack    = new C_ValueType[0] ;
	static C_ValueType[] freeset  = new C_ValueType[0] ;
	public struct C_ValueType
		{
		public C_Symbol  Symbol ;
		public int       Offset ;
		public C_Type    Type   ;
		public c       StackElement
			{
			get { return Stack.Index(Offset) ; }
			}
		public c       StackCast
			{
			get { return new c("("+Type.Spec+")"+StackElement) ; }
			}
		public c       StackDeref
			{
			get {
				var _cast = ((string)Type.Spec).Trim() ;
				if( _cast == KeyedWord.Long )
					return new c("("+_cast+")"+StackElement) ;
				return new c("*("+_cast+")"+StackElement) ;
				}
			}
		public c       StackArray(string i)
			{
			return new c("(("+Type.Spec+")"+StackElement+")["+i+"]") ;
			}
		}
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
	static public void Write( A335.Stack.IStart start )
		{
		WriteC_Main( start ) ;
		foreach( Automatrix a in (Automatrix)start )
			if( a is Method.Head )
				(a as Method.Head).WriteMethod() ;
		WriteC_Objects() ;
		}
	static public void WriteC_Main( A335.Stack.IStart start )
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
		foreach( Automatrix a in (Automatrix)start )
			if( a is Class.Head )
				sw.WriteLine( "#include \"{0}.h\"", (a as Class.Head).Symbol ) ;
		foreach( Automatrix a in (Automatrix)start )
			if( a is Method.Head )
				(a as Method.Head).WriteInclude(sw) ;
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
		return "_" + Guid.NewGuid().ToID() ;
		}
	static C_Type _UnsignedInt()
		{
		return C_Type.Acquire( c_guid() + "_unsigned_int" ) ;
		}
	static C_Type _Char_()
		{
		return C_Type.Acquire( c_guid() + "_char_p" ) ;
		}
	static public C_Function jiffy( Program c, string description )
		{
		return c.This = C_Method.CreateFunction( description ) ;
		}
	static public void Begin()
		{
		var c = new Program() ;
		C_Type _length = _UnsignedInt() ;
		C_Type _string = _Char_() ;
		c.TypeDef.String
			.Parameter( _length )
			.Parameter( _string )
			;
		c.TypeDef.Object
			.Parameter( C699.Object(1) , "this" )
			.Parameter( C699.String, C.Restricted("(*$ToString)").Tut(C.Const.Voidpp) )
			;
		jiffy( c, "object::.ctor" )
			;
		jiffy( c, "console::WriteLine(string)" )
			.ConstLocalArg0
			.StandardOutputWriteLocal( _string , _length )
			.StandardOutputWriteLine()
			;
		jiffy( c, "console::Write(string)" )
			.ConstLocalArg0
			.StandardOutputWriteLocal( _string , _length )
			;
		var l = new C_Literal[3] ;
		jiffy( c, "string string::Concat(object,object,object)" )
			.Register(ref l[0], C699.String)
			.Register(ref l[1], C699.String)
			.Register(ref l[2], C699.String)
			.Let( l[0] ).Equal.ManagedArgument( 0 )
			.Let( l[1] ).Equal.ManagedArgument( 1 )
			.Let( l[2] ).Equal.ManagedArgument( 2 )
			.Return( c.StringConcat( l[0], l[1], l[2] ) )
			;
		jiffy( c, "string string::Concat(string,string)" )
			.ConstLocalArg( 0 )
			.ConstLocalArg( 1 )
			.Return( c.StringConcatLocal0Local1() )
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
		var    s_length = C.Literal( "s."   + _length) ;
		var    s_string = C.Literal( "s."   + _string) ;
		var    a_length = C.Literal(a + "." + _length) ;
		var    a_string = C.Literal(a + "." + _string) ;
		var    b_length = C.Literal(b + "." + _length) ;
		var    b_string = C.Literal(b + "." + _string) ;
		var    c_length = C.Literal(c + "." + _length) ;
		var    c_string = C.Literal(c + "." + _string) ;
		This.Statement( C.Static(C699.String,"s") )
			.Statement( s_length.Equate(a_length+" + "+b_length+" + "+c_length) )
			.Statement( s_string.Equate( C699.Malloc( a_length.plus(b_length).plus(c_length) ) ) )
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
		var    s_length = C.Literal( "s."   + _length) ;
		var    s_string = C.Literal( "s."   + _string) ;
		var    a_length = C.Literal("_local0->" + _length) ;
		var    a_string = C.Literal("_local0->" + _string) ;
		var    b_length = C.Literal("_local1->" + _length) ;
		var    b_string = C.Literal("_local1->" + _string) ;
		This.Statement( C.Static(C699.String,"s") )
			.Statement( s_length.Equate(a_length+" + "+b_length) )
			.Statement( s_string.Equate( C699.Malloc( a_length.plus(b_length) ) ) )
			.Statement( C699.Strncpy(s_string,a_string,a_length) )
			.Statement( C699.Strncpy('&'+s_string+'['+a_length+']',b_string,b_length) )
			;
		return C_Symbol.Acquire( "s" ) ;
		}
	static void stack_add( C_Type type )
		{
		System.Array.Resize( ref stack, stack.Length+1 ) ;
		stack[stack.Length-1] = new C_ValueType() { Type = type } ;
		}
	void Push( C_Type type )
		{
		stack[stack_offset] = new C_ValueType() { Type = type } ;
		stack_offset++ ;
		}
	public C_ValueType Peak()
		{
		var vt = stack[stack_offset-1] ;
		vt.Offset = stack_offset-1 ;
		return vt ;
		}
	public C_ValueType Pop()
		{
		stack_offset-- ;
		var vt = stack[stack_offset] ;
		vt.Offset = stack_offset ;
		return vt ;
		}
	public C_Type[] Hangup( int iargs )
		{
		if( iargs < 1 )
			return new C_Type[] {} ;
		var list = new C_Type[iargs] ;
		stack_offset -= iargs ;
		for( int i = 0 ; i < iargs ; i++ )
			list[i] = stack[stack_offset+i].Type == null ? C_Type.Undefined : stack[stack_offset+i].Type ;
		return list ;
		}
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
		c.Type = C.Int ;
		var e = A335.Method.EntryPoint.Node.Head ;
		var cctor = e.ClassDecl.Node.Head.Cctor ;
		if( cctor != null && cctor.Cctor )
			{
			c.Statement( C.Extern.Void.Cctor(e.ClassDecl.Node.Head.Type) ) ;
			c.Statement( C.Cctor(e.ClassDecl.Node.Head.Type) ) ;
			}
		string a = e.Function.Args == null ? string.Empty : e.Function.Args.Replace("(","").Replace(")","") ;
		string b = e.Function.Args == null ? string.Empty : "(const void**)args" ;
		c.Statement( C.Extern.Void.Function(e.Function.Symbol, new c(a)) ) ;
		c.Statement( C.Function(e.Function.Symbol, new c(b)) ) ;
		c.Statement( C.Return(C.Zero) ) ;
		c.WriteTo( C699.Main.FileStructure ) ;
		return C699.Main.FileStructure ;
		}
	}
}

