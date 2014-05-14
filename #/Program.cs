using System.Text.RegularExpressions ;
using System.Collections.Generic ;
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
				#if DEBUG
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
	static Dictionary<string,C_Type> typeset = new Dictionary<string, C_Type>() ;
	static public void Write()
		{
		current_working_directory() ;
		Program.WriteC_Main() ;
		Program.WriteMethods() ;
		Program.WriteC_Objects() ;
		}
	public class C_Symbol
		{
		//Guid ID ;
		string symbol ;
		C_Symbol( string symbol )
			{
			this.symbol = symbol ;
			//ID = Guid.NewGuid() ;
			}
		static public C_Symbol Acquire( string symbol )
			{
			C_Symbol c ;
			if( ! symbolset.ContainsKey( symbol ) )
				symbolset.Add( symbol, c = new C_Symbol( symbol ) ) ;
			else
				c = symbolset[symbol] ;
			return c ;
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
			C_Type c;
			if( ! typeset.ContainsKey( symbol ) )
				typeset.Add( symbol, c = new C_Type( symbol ) ) ;
			else
				c = typeset[symbol] ;
			return c ;
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
		}
	public class C_Method
		{
		//Guid ID ;
		public List<C_Symbol>  NameSpace = new List<C_Symbol>() ;
		public List<C_Symbol>  ClassName = new List<C_Symbol>() ;
		public C_Symbol        Name ;
		public List<C_Type>    Args  = new List<C_Type>() ;
		public C_Type          Type ;
		public C_Function      Function ;
		public C_Method()
			{
			//ID = Guid.NewGuid() ;
			}
		static public C_Function CreateFunction( string typedef )
			{
			C_Method m ;
			C_Function c ;
			m = new C_Method() ;
			m.NameSpace.Add( C_Symbol.Acquire( "BCL" ) ) ;
			m.NameSpace.Add( C_Symbol.Acquire( "System" ) ) ;
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
			foreach( C_Symbol e in NameSpace )
				{
				if( ns != "" )
					ns += "$$" ;
				ns += e ;
				}
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
			s += ns + "_" + cn + Name + ( a == "" ? "" : "$" + a ) ;
			C_Symbol symbol = C_Symbol.Acquire( s ) ;
			Function = C_Function.FromSymbol( symbol ) ;
			Function.Method = this ;
			if( Type != null )
				Function.Type = Type ;
			return Function ;
			}
		}
	public class C_Function
		{
		//Guid ID ;
		public C_Method Method ;
		public bool Static ;
		public bool Inline ;
		public bool Void
			{
			set {
				if( value )
					Type = C_Symbol.Acquire( "void" ) ;
				}
			}
		public bool Bool
			{
			set {
				if( value )
					Type = C_Symbol.Acquire( "int" ) ;
				}
			}
		public C_Symbol Type ;
		C_Symbol symbol ;
		public string Symbol ;
		public bool   HasArgs ;
		public string Args ;
		public bool   Written ;
		public bool   Required ;
		List<string> list = new List<string>() ;
		C_Function( string symbol )
			{
			Void = true ;
			this.symbol = C_Symbol.Acquire( symbol ) ;
			Symbol = symbol ;
			//ID = Guid.NewGuid() ;
			}
		static public C_Function FromSymbol( string symbol )
			{
			C_Symbol s = C_Symbol.Acquire( symbol ) ;
			return FromSymbol( s ) ;
			}
		static public C_Function FromSymbol( C_Symbol symbol )
			{
			C_Function c ;
			if( ! c_functionset.ContainsKey( symbol ) )
				c_functionset.Add( symbol, c = new C_Function( symbol ) ) ;
			else
				c = c_functionset[symbol] ;
			return c ;
			}
		static public void Require( string symbol )
			{
			C_Function c ;
			if( ! c_functionset.ContainsKey( symbol ) )
				c_functionset.Add( symbol, c = new C_Function( symbol ) ) ;
			else
				c = c_functionset[symbol] ;
			c.Required = true ;
			c_functionset[symbol].Required = true ;
			}
		public void Statement( string line )
			{
			bool eos = ( line.StartsWith( "if" ) && ! line.Contains( "goto" ) )  || line.StartsWith( "else" ) ;
			list.Add( "\t" + line + ( eos ? "" : " ;" ) ) ;
			}
		public void Label( string label )
			{
			list.Add( "\t" + label + " :" ) ;
			}
		public void WriteTo( StreamWriter sw )
			{
			var line = new List<string>() ;
			if( Static )
				line.Add( "static" ) ;
			if( Inline )
				line.Add( "inline" ) ;
			line.Add( Type ) ;
			line.Add( Symbol ) ;
			string a ;
			if( Args == null )
				a = "( const void** stack"
				+ ( HasArgs ? ", const void** args" : "" )
				+ " )" ;
			else
				a = Args ;
			sw.WriteLine( String.Join( " ", line ) + a ) ;
			sw.WriteLine( "\t{" ) ;
			foreach( string s in list )
				sw.WriteLine( s ) ;
			sw.WriteLine( "\t}" ) ;
			sw.WriteLine() ;
			Written = true ;
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
		foreach( C_Function f in c_functionset.Values )
			{
			if( f.Required && f.Symbol.StartsWith( "BCL$" ) )
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
	public class C_Struct
		{
		public string Type ;
		public string Symbol ;
		List<string> list = new List<string>() ;
		public C_Struct()
			{
			Type = "_object" ;
			}
		public void Add( string text )
			{
			list.Add( text ) ;
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
			sw.WriteLine( "struct "+ Type + " " + Symbol + " =" ) ;
			sw.WriteLine( "\t{" ) ;
			foreach( string s in list )
				sw.WriteLine( "\t" + s + " ," ) ;
			sw.WriteLine( "\t} ;" ) ;
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
	public class Oprand
		{
		public string Instruction ;
		public string ID ;
		public bool HasArgs ;
		public bool IsFlowControl ;
		List<string> list = new List<string>() ;
		public Oprand( string instr )
			{
			string id = Guid.NewGuid().ToString() ;
			id = System.Text.RegularExpressions.Regex.Replace( id, "[^A-Za-z_0-9]", "_").ToLower() ;
			ID = id ;
			instr = System.Text.RegularExpressions.Regex.Replace( instr, "[^A-Za-z_0-9]", "_").ToUpper() ;
			Instruction = instr ;
			}
		static public implicit operator string( Oprand d )
			{
			if( d.IsFlowControl && d.Instruction == "BR" )
				return d.list[0] ;
			if( d.IsFlowControl )
				return "if( " + d.Instruction + "$" + d.ID + "( stack " + ( d.HasArgs ? ", args )" : ")" ) + " ) " + d.list[0] ;
			return d.Instruction + "$" + d.ID + "( stack " + ( d.HasArgs ? ", args )" : ")" ) ;
			}
		public void Statement( string text )
			{
			list.Add( text ) ;
			}
		public void WriteTo( StreamWriter sw )
			{
			if( IsFlowControl && Instruction == "BR" )
				return ;
			var c = C_Function.FromSymbol( Instruction + "$" + ID ) ;
			if( IsFlowControl )
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
	public class Method
		{
		List<object> list = new List<object>() ;
		List<string> labels = new List<string>() ;
		public bool    Static ;
		public bool    CallConvInstance ;
		public string  Type ;
		public string  ClassSymbol ;
		public string  Name ;
		public string  SigArgTypes ;
		public int     SigArgs ;
		public int     MaxStack ;
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
			get {
				return _virtual ;
				}
			}
		public Method()
			{
			methodset.Add( this ) ;
			}
		public void Add( Oprand oprand )
			{
			list.Add( oprand ) ;
			}
		public void AddLabel( string text )
			{
			list.Add( text ) ;
			}
		public void RegisterLabel( string text )
			{
			labels.Add( text ) ;
			}
		public void RegisterCctor()
			{
			cctorset.Add( ClassSymbol ) ;
			}
		public void WriteInclude( StreamWriter sw )
			{
			sw.WriteLine( "#include \"" + ClassSymbol + Name + SigArgTypes + ".c\"" ) ;
			}
		public void Write()
			{
			var c = C_Function.FromSymbol( ClassSymbol + Name + SigArgTypes ) ;
			StreamWriter sw = File.CreateText( directory.FullName + "/" + c.Symbol + ".c" ) ;
			foreach( object o in list )
				if( o is Oprand )
					(o as Oprand).WriteTo( sw ) ;
			int args = SigArgs + ( CallConvInstance ? 1 : 0 ) ;
			if( Virtual )
				c.Type = C_Symbol.Acquire( "struct _string" ) ;
			if( args == 0 )
				c.Args = "()" ;
			else
				c.Args = "( const void** args )" ;
			c.Statement( "const void** stack = alloca( " + MaxStack + " )" ) ;
			foreach( object o in list )
				{
				if( o is Oprand )
					c.Statement( (string) (o as Oprand) ) ;
				else
					{
					string label = (string) o ;
					if( labels.Contains( label ) )
						c.Label( label ) ;
					}
				}
			if( Virtual )
				c.Statement( "return *(struct _string *)*stack" ) ;
			c.WriteTo( sw ) ;
			sw.Close() ;
			}
		}
	}
}
