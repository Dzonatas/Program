using System.Text.RegularExpressions ;
using System.Collections.Generic ;
using System.Extensions ;
using System.Diagnostics ;
using System.Collections ;
using System.Reflection ;
using System.Linq ;
using System.IO ;
using System ;

//http://icyspherical.blogspot.com/2012/05/singletons-c-to-c-main-primer-and.html

namespace Application
	{
	public sealed class Program
		{
		static public Action<string[]>          Parse      = (args) => {} ;
		static public Action                    Initialize = () => {} ;
		static public Action                    Run        = () => {} ;

		static Dictionary< string, object   >   singletons = new Dictionary< string, object >() ;

		[AttributeUsage(AttributeTargets.Class)]
		public class SingletonAttribute : Attribute	{}
		public class ExtentAttribute    : Attribute	{}
		public class ExtendedAttribute  : Attribute	{}
		
		static Program()
			{
			#if DEBUG && CONSOLE
				Debug.Listeners.Add(  new TextWriterTraceListener( Console.Out )  ) ;
			#elif DEBUG
				A335.log_ready() ;
				Debug.Listeners.Add(  new TextWriterTraceListener( A335.log_output )  ) ;
			#else
				AppDomain.CurrentDomain.UnhandledException += unhandled ;
			#endif
#if !CPP_FLOW
			instantiate() ;
#endif
			}

#if CPP_FLOW
		public static void Main( string[] args )
			{
			instantiate() ;
			Parse( args ) ;
			Initialize() ;
			Run() ;

			#if DEBUG
				singletons.Clear() ;
				GC.Collect() ;
				GC.WaitForPendingFinalizers() ;
				Debug.WriteLine( "Program ended." ) ;
			#endif
			
			Environment.Exit( 0 ) ;
			}
#endif

		static void unhandled( object o, UnhandledExceptionEventArgs args )
			{
			Exception e = (Exception)args.ExceptionObject ;
			#if CONSOLE
			Console.Write( "UNHANDLED EXCEPTION: " ) ;
			Console.WriteLine( e ) ;
			//Console.Flush() ;
			#else
			A335.log( "UNHANDLED EXCEPTION: " ) ;
			A335.log( e.ToString() ) ;
			#endif

			Environment.Exit( 1 ) ;
			}

		static void instantiate()
			{
			IEnumerable<Type> types =
				from  type in Assembly.GetExecutingAssembly().GetTypes()
				from  atrb in Attribute.GetCustomAttributes( type )
				where atrb is SingletonAttribute
				select type ;
			
			foreach( Type t in types  )
				{
				#if DEBUG_SINGLETON
				Debug.WriteLine( "Singleton: " + t.ToString() ) ;
				#endif
				try
					{
					object o = t.InvokeMember( null,
						BindingFlags.DeclaredOnly
						| BindingFlags.NonPublic 
						| BindingFlags.Instance
						| BindingFlags.CreateInstance ,
			        	null, null, null );
					singletons[ t.ToString() ] = o ;					        
					}
				catch( System.MissingMethodException )
					{
					throw new MissingMethodException( "Class '" + t.ToString() + "' attributed for 'Program.Singleton' instantiation, yet it lacks a private constructor." ) ;
					}
		 		}
			}
		}
	}

public partial class A335
{
partial class Program
	{
	static Dictionary<string,object> virtualset = new Dictionary<string,object>() ;
	static List<Method>  methodset = new List<Method>() ;
	static List<string>  cctorset = new List<string>() ;
	static Dictionary<string,C_Function> c_functionset = new Dictionary<string, C_Function>() ;
	static Dictionary<string,C_Symbol> symbolset = new Dictionary<string, C_Symbol>() ;
	static Dictionary<C_Symbol,C_Type> typeset = new Dictionary<C_Symbol, C_Type>() ;
	static Dictionary<string,C_TypeDef> typedefset = new Dictionary<string, C_TypeDef>() ;
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
		current_working_directory() ;
		Program.WriteC_Main() ;
		Program.WriteMethods() ;
		Program.WriteC_Objects() ;
		}
	static public C_Symbol StructObject
		{
		get { return C_Symbol.Acquire( "struct _object" ) ; }
		}
	static public C_Symbol StructObject_
		{
		get { return C_Symbol.Acquire( "struct _object*" ) ; }
		}
	static public C_Symbol StructString
		{
		get { return C_Symbol.Acquire( "struct _string" ) ; }
		}
	static public C_Symbol StructString_
		{
		get { return C_Symbol.Acquire( "struct _string*" ) ; }
		}
	static public C_Function jiffy( string description )
		{
		return C.This = C_Method.CreateFunction( description ) ;
		}
	static public Type Function
		{
		get { return typeof(C_Function) ; }
		}
	public _TypeDef TypeDef
		{
		get { return new _TypeDef() ; }
		}
	public class _TypeDef
		{
		public C_Struct String
			{
			get { return C_TypeDef.CreateStructure( "string" ) ; }
			}
		public C_Struct Object
			{
			get { return C_TypeDef.CreateStructure( "object" ) ; }
			}
		}
	public class C_Method
		{
		//Guid ID ;
		//public List<C_Symbol>  NameSpace = new List<C_Symbol>() ;
		public List<C_Symbol>  ClassName = new List<C_Symbol>() ;
		public C_Symbol        Name ;
		public List<C_Type>    Args  = new List<C_Type>() ;
		public C_Type          Type ;
		public C_Function      Function ;
		/*
		public C_Method()
			{
			//ID = Guid.NewGuid() ;
			}
		*/
		public C_Method( C_Type context )
			{
			//ID = Guid.NewGuid() ;
			foreach( string s in (string[]) context )
				ClassName.Add( C_Symbol_Acquire( s ) ) ;
			}
		public C_Type ClassType
			{
			get {
				var type = new string[ClassName.Count];
				int i = 0 ;
				foreach( C_Symbol symbol in ClassName )
					type[i++] = symbol ;
				//type[i] = Name ;
				return C_Type.Acquire( type ) ;
				}
			}
		public C_Type ThisType
			{
			get {
				var type = new string[ClassName.Count+2];
				type[0] = new C_Undefined() ;
				int i = 1 ;
				foreach( C_Symbol symbol in ClassName )
					type[i++] = symbol ;
				type[i] = Name ;
				return C_Type.Acquire( type ) ;
				}
			}
		static public C_Function CreateFunction( string typedef )
			{
			C_Method m ;
			C_Function c ;
			var context = new string[] { "System" } ;
			m = new C_Method( C_Type.Acquire( context ) ) ;
			//m.NameSpace.Add( C_Symbol.Acquire( "BCL" ) ) ;
			//m.NameSpace.Add( C_Symbol.Acquire( "System" ) ) ;
			Match y = Regex.Match( typedef, @"^(?<type>\S+)\s" ) ;
			if( y.Success )
				m.Type = C_Type.Acquire( y.Groups[ "type" ].Value ) ;
			Match x = Regex.Match( typedef, @"^(\S+\s|)(?<classname>\S+)::(?<methodname>[^\(]+)(\((?<args>\S+)\)|)" ) ;
			if( ! x.Success )
				throw new System.NotImplementedException( typedef ) ;
			switch( x.Groups[ "classname" ].Value )
				{
				case "object"  : m.ClassName.Add( C_Symbol.Acquire( "Object" ) ) ; break ;
				case "console" : m.ClassName.Add( C_Symbol.Acquire( "Console" ) ) ; break ;
				case "string"  : m.ClassName.Add( C_Symbol.Acquire( "String" ) ) ; break ;
				default        : throw new System.NotImplementedException( typedef ) ;
				}
			string name ;
			switch( name = x.Groups[ "methodname" ].Value )
				{
				case ".ctor"   : m.Name = C_Symbol.Acquire( "_ctor" ) ; break ;
				default        : m.Name = C_Symbol.Acquire( "$" + name ) ; break ;
				}
			string args = x.Groups[ "args" ].Value ;
			if( ! String.IsNullOrEmpty( args ) )
				foreach( string a in x.Groups[ "args" ].Value.Split( ',' ) )
					m.Args.Add( C_Type.Acquire( a ) ) ;
			c = m.CreateFunction() ;
			c.Static = true ;
			c.Inline = true ;
			c.Args = "( const void** args )" ;
			return c ;
			}
		public C_Function CreateFunction()
			{
			string ns = "" ;
			/*
			foreach( C_Symbol e in NameSpace )
				{
				if( ns != "" )
					ns += "$$" ;
				ns += e ;
				}
			*/
			string cn = "" ;
			foreach( C_Symbol e in ClassName )
				{
				if( cn != "" )
					cn += "$" ;
				cn += e ;
				}
			string a = "" ;
			foreach( C_Type e in Args )
				{
				if( a != "" )
					a += "$" ;
				a += e ;
				}
			string s = "" ;
			s += /*ns + "_" +*/ cn + Name + ( a == "" ? "" : "$" + a ) ;
			C_Symbol symbol = C_Symbol.Acquire( s ) ;
			Function = C_Function.FromSymbol( symbol ) ;
			Function.Method = this ;
			if( Type != null )
				Function.Type = Type ;
			return Function ;
			}
		}
	static public void WriteC_Main()
		{
		StreamWriter sw = File.CreateText( directory.FullName + "/" + "program.c" ) ;
		var c = C_Function.FromSymbol( "main" ) ;
		c.Args = "( int argc , char** args , char** env )" ;
		if( cctorset.Contains(this_start_method.ClassSymbol) )
			{
			c.Statement( "extern void " + this_start_method.ClassSymbol + "_cctor()" ) ;
			c.Statement( this_start_method.ClassSymbol + "_cctor()" ) ;
			}
		c.Statement( "extern void " + this_start_method.ClassSymbol + "$Main()" ) ;
		c.Statement( this_start_method.ClassSymbol + "$Main()" ) ;
		c.WriteTo( sw ) ;
		sw.WriteLine( "#include <BCL.HPP>" ) ;
		C_TypeDef.WriteTo( sw ) ;
		foreach( C_Function f in c_functionset.Values )
			{
			if( f.Required && ( f.Symbol.StartsWith( "BCL$" ) || f.Symbol.StartsWith( "System" ) ) )
				{
				f.WriteTo( sw ) ;
				}
			}
		foreach( Program.Method m in methodset )
			m.WriteInclude( sw ) ;
	    foreach( string class_symbol in virtualset.Keys )
			C_Struct.FromSymbol( class_symbol ).WriteInclude( sw ) ;
		sw.Close() ;
		}
	static public void WriteC_Objects()
		{
	    foreach( string class_symbol in virtualset.Keys )
			{
			StreamWriter sw = File.CreateText( directory.FullName + "/" + class_symbol + ".c" ) ;
			var c = ((C_Struct) virtualset[class_symbol]) ;
			c.WriteTo( sw ) ;
			sw.Close() ;
			}
		}
	public class C_TypeDef
		{
		C_Symbol symbol ;
		C_Type   alias ;
		public C_Struct Struct ;
		C_TypeDef( string symbol, C_Type alias )
			{
			//ID = Guid.NewGuid() ;
			this.symbol = C_Symbol.Acquire( symbol ) ;
			this.alias  = alias ;
			}
		static public C_TypeDef Acquire( string symbol )
			{
			C_TypeDef c;
			if( typedefset.ContainsKey( symbol ) )
				c = typedefset[symbol] ;
			else
				typedefset.Add( symbol, c = new C_TypeDef( symbol, C_Type.Acquire( String.Empty ) ) ) ;
			return c ;
			}
		static public C_Struct CreateStructure( string type )
			{
			C_Struct s = new C_Struct() ;
			s.Type = "_" + type ;
			s.TypeDef = Acquire( type ) ;
			s.TypeDef.Struct = s ;
			return s ;
			}
		static public void WriteTo( StreamWriter sw )
			{
			foreach( C_TypeDef t in typedefset.Values )
				t.Struct.WriteTo( sw ) ;
			}
		}
	public class C_Struct
		{
		public string Type ;
		public string Symbol ;
		public C_TypeDef TypeDef ;
		List<string> list = new List<string>() ;
		List<C_Type> parameterset = new List<C_Type>() ;
		public C_Struct()
			{
			Type = "_object" ;
			}
		public void Add( string text )
			{
			list.Add( text ) ;
			}
		public C_Struct Parameter( C_Type symbol )
			{
			list.Add( symbol.Type + " " + symbol ) ;
			parameterset.Add( symbol ) ;
			return this ;
			}
		public C_Struct Parameter( C_Symbol symbol, string text )
			{
			list.Add( symbol + " " + text ) ;
			return this ;
			}
		public C_Type this[int n]
			{
			get{ return parameterset[n] ; }
			}
		public void Assign( string text )
			{
			list.Add( "." + text + " = " + Symbol + text ) ;
			}
		public void WriteInclude( StreamWriter sw )
			{
			sw.WriteLine( "#include \"" + Symbol + ".c\"" ) ;
			}
		public void WriteTo( StreamWriter sw )
			{
			if( Symbol != null )
				{
				sw.WriteLine( "struct "+ Type + " " + Symbol + " =" ) ;
				sw.WriteLine( "\t{" ) ;
				foreach( string s in list )
					sw.WriteLine( "\t" + s + " ," ) ;
				sw.WriteLine( "\t} ;" ) ;
				}
			else
				{
				sw.WriteLine( "struct "+ Type ) ;
				sw.WriteLine( "\t{" ) ;
				foreach( string s in list )
					sw.WriteLine( "\t" + s + " ;" ) ;
				sw.WriteLine( "\t} ;" ) ;
				}
			sw.WriteLine() ;
			}
		static public C_Struct FromSymbol( string S )
			{
			C_Struct c ;
			if( ! virtualset.ContainsKey( S ) )
				{
				c = new C_Struct() ;
				c.Symbol = S ;
				virtualset.Add( S, c ) ;
				}
			else
				c = virtualset[S] as C_Struct ;
			return c ;
			}
		}
	public class C_Oprand
		{
		C_Symbol label ;
		C_Function function ;
		public string Instruction ;
		public string ID ;
		public bool HasArgs ;
		public bool BrTarget ;
		List<string> list = new List<string>() ;
		public C_Symbol Label
			{
			set { label = value ; }
			get { return label ; }
			}
		public C_Method Method
			{
			get { return function.Method ; }
			}
		public C_Oprand( C_Function function, string instr )
			{
			this.function = function ;
			ID = Guid.NewGuid().ToID() ;
			Instruction = System.Text.RegularExpressions.Regex.Replace( instr, "[^A-Za-z_0-9]", "_").ToUpper() ;
			}
		static public implicit operator string( C_Oprand d )
			{
			if( d.BrTarget && d.Instruction == "BR" )
				return d.list[0] ;
			if( d.BrTarget )
				return "if( " + d.Instruction + "$" + d.ID + "( stack " + ( d.HasArgs ? ", args )" : ")" ) + " ) " + d.list[0] ;
			return d.Instruction + "$" + d.ID + "( stack " + ( d.HasArgs ? ", args )" : ")" ) ;
			}
		public C_Oprand Statement( string text )
			{
			list.Add( text ) ;
			return this ;
			}
		public C_Oprand Jump( string id )
			{
			list.Add( "goto " + id ) ;
			return this ;
			}
		public C_Oprand AssignStack( int offset, string text )
			{
			return Statement( "stack[" + offset + "] = " + text ) ;
			}
		public C_Oprand AssignStaticConst( C_Symbol type, C_Symbol symbol, string text )
			{
			return Statement( "static const " + type + " " + symbol + " = " + text ) ;
			}
		public C_Oprand LocalStatic( C_Symbol type, C_Symbol symbol )
			{
			return Statement( "static " + type + " " + symbol ) ;
			}
		public C_Oprand ExternCall( C_Symbol symbol )
			{
			return Statement( "extern void " + symbol + "( const void** )" ) ;
			}
		public C_Oprand Extern( C_Symbol type, C_Type symbol )
			{
			return Statement( "extern " + type + " " + symbol  ) ;
			}
		public C_Oprand Call( C_Symbol symbol )
			{
			return Statement( symbol + "()"  ) ;
			}
		public C_Oprand Call( C_Symbol symbol, string args )
			{
			return Statement( symbol + "( " + args + " )"  ) ;
			}
		public C_Oprand CallAssign( C_Symbol item, C_Symbol symbol )
			{
			return Statement( item + " = " + symbol + "()"  ) ;
			}
		public C_Oprand CallAssign( C_Symbol item, C_Symbol symbol, string args )
			{
			return Statement( item + " = " + symbol + "( " + args + " )"  ) ;
			}
		public C_Oprand FreeStackString( int offset )
			{
			C_TypeDef typedef = typedefset["string"] ;
			string field = typedef.Struct[1] ;
			return Statement( "free( ((struct _string *)stack[" + offset + "])->"+field+" )" ) ;
			}
		public void WriteTo( StreamWriter sw )
			{
			if( BrTarget && Instruction == "BR" )
				return ;
			var c = C_Function.FromSymbol( Instruction + "$" + ID ) ;
			if( BrTarget )
				c.Bool = true ;
			c.Static = true ;
			c.Inline = true ;
			c.HasArgs = HasArgs ;
			switch( Instruction )
				{
				case "BGE" :
					c.Statement( "return 1" ) ;
					break ;
				default:
					foreach( string s in list )
						c.Statement( s ) ;
					break ;
				}
			c.WriteTo( sw ) ;
			}
		}
	static public void WriteMethods()
		{
		foreach( Program.Method m in methodset )
			m.Write() ;
		}
	}

partial class Program
	{
	public class Method
		{
		C_Method       method ;
		C_Function     function ;
		public Instr   Instrset ;
		List<string>   labelset = new List<string>() ;
		public A335.Method.Head Head ;
		public bool    CallConvInstance ;
		public bool    Bool
			{
			set { function.Bool = value ; }
			}
		public string  Type
			{
			set { method.Type = C_Type.Acquire( value ) ; }
			get { return (string) method.Type ; }
			}
		public string  Name
			{
			set { method.Name = C_Symbol_Acquire( value ) ; }
			get { return (string) method.Name ; }
			}
		public string  SigArgTypes ;
		public int     SigArgs ;
		public string  ClassSymbol
			{
			get { return (string) method.ClassType ; }
			}
		public int     MaxStack
			{
			set { C.MaxStack = value ; }
			}
		bool _virtual ;
		public bool    Virtual
			{
			set {
				if( ( _virtual = value ) )
					{
					C_Struct c = C_Struct.FromSymbol( ClassSymbol ) ;
					c.Assign( Name + SigArgTypes ) ;
					}
				}
			}
		public Method( C_Type context )
			{
			method = new C_Method( context ) ;
			methodset.Add( this ) ;
			}
		public void RegisterLabel( string text )
			{
			labelset.Add( text ) ;
			}
		public void RegisterCctor()
			{
			cctorset.Add( ClassSymbol ) ;
			}
		public void WriteInclude( StreamWriter sw )
			{
			sw.WriteLine( "#include \"" + ClassSymbol + Name + SigArgTypes + ".c\"" ) ;
			}
		public void CreateFunction()
			{
			foreach( string a in SigArg.Typeset )
				method.Args.Add( C_Type.Acquire( a ) ) ;
			function = C_Function.FromSymbol( ClassSymbol + Name + SigArgTypes ) ;
			function.Method = method ;
			}
		public C_Oprand NewOprand( string instr )
			{
			var d = new C_Oprand( function, instr ) ;
			d.Label = A335.Method.Decl.Label ;
			A335.Method.Decl.Label = C_Symbol.Acquire( System.String.Empty ) ;
			return d ;
			}
		public void Write()
			{
			var c = function ;
			StreamWriter sw = File.CreateText( directory.FullName + "/" + c.Symbol + ".c" ) ;
			for( Instr i = Instrset ; i is Instr ; i = i.Next )
				i._C_Oprand.WriteTo( sw ) ;
			int args = SigArgs + ( CallConvInstance ? 1 : 0 ) ;
			if( _virtual )
				c.Type = C_Symbol.Acquire( "struct _string" ) ;
			if( args == 0 )
				c.Args = "()" ;
			else
				c.Args = "( const void** args )" ;
			c.Statement( "const void** stack = alloca( " + Head.MaxStack + " * sizeof(void*) )" ) ;
			for( Instr i = Instrset ; i is Instr ; i = i.Next )
				{
				string label = i._C_Oprand.Label ;
				if( System.String.Empty == label )
					c.Statement( (string) i._C_Oprand ) ;
				else
					{
					if( labelset.Contains( label ) )
						c.Label( label ) ;
					c.Statement( (string) i._C_Oprand ) ;
					}
				}
			if( _virtual )
				c.Statement( "return *(struct _string *)*stack" ) ;
			c.WriteTo( sw ) ;
			sw.Close() ;
			}
		}
	}

}
