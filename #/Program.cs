using System.Collections.Generic ;
using System.Diagnostics ;
using System.Collections ;
using System.Reflection ;
using System.Linq ;
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
class Program
	{
	static List<Line>    list = new List<Line>() ;
	static List<Method>  methodset = new List<Method>() ;
	static public string Composite()
		{
		string program = "" ;
		foreach( Line l in list )
			{
			program += l ;
			}
		return program ;
		}
	static public void Start()
		{
		var l = new Line() ;
		l.Add( "#include <BCL.HPP>" ) ;
		}
	public override string ToString()
		{
		return Composite() ;
		}
	public class Line
		{
		static int counter ;
		bool numbered = false ;
		List<string> list = new List<string>() ;
		public Line()
			{
			Program.list.Add( this ) ;
			list.Add( "//#line " + counter++ ) ;
			numbered = false ;
			}
		public Line( bool numbered )
			{
			Program.list.Add( this ) ;
			if( this.numbered = numbered )
				list.Add( "#line " + counter++ ) ;
			}
		public void Add( string text )
			{
			list.Add( text ) ;
			}
		static public implicit operator string( Line t )
			{
			string line = "" ;
			foreach( string s in t.list )
				line += s + "\n" ;
			return line ;
			}
		public override string ToString()
			{
			return this ;
			}
		}
	public class Declaration
		{
		Line header = new Line() ;
		Line body = new Line( false ) ;
		Line footer = new Line( false ) ;
		public Declaration() : base()
			{
			body.Add(   "\t{" ) ;
			footer.Add( " \t}" ) ;
			}
		public Line Header
			{
			get { return header ; }
			}
		public Line Footer
			{
			get { return footer ; }
			}
		public void Add( string text )
			{
			body.Add( text ) ;
			}
		public void Statement( string text )
			{
			body.Add( "\t" + text + " ;" ) ;
			}
		static public implicit operator string( Declaration d )
			{
			return d.header + d.body + d.footer ;
			}
		public override string ToString()
			{
			return header + body + footer ;
			}
		}
	static public void C_Main()
		{
		var d = new Declaration() ;
		d.Header.Add( "int main( int argc , char** args , char** env )" ) ;
		d.Statement( "const void** stack = alloca(0)" ) ;
		d.Statement( this_start_class + "$Main()" ) ;
		}
	static public void C_Objects()
		{
	    foreach( string class_symbol in virtualset.Keys )
			{
			var c = ((Program.C_Struct) virtualset[class_symbol]) ;
			c.Compose() ;
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
		public void Compose()
			{
			var d = new Declaration() ;
			d.Header.Add( "struct "+ Type + " " + Symbol + " =" ) ;
			foreach( string s in list )
				d.Add( "\t" + s + " ," ) ;
			d.Footer.Add( "\t;" ) ;
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
		public void Compose()
			{
			if( IsFlowControl )
				return ;
			var d = new Declaration() ;
			d.Header.Add( "static inline void " + Instruction + "$" + ID
				+ "( const void** stack"
				+ ( HasArgs ? ", const void** args" : "" )
				+ " )" ) ;
			foreach( string s in list )
				d.Statement( s ) ;
			}
		static public implicit operator string( Oprand d )
			{
			if( d.IsFlowControl )
				return d.list[0] ;
			return d.Instruction + "$" + d.ID + "( stack " + ( d.HasArgs ? ", args )" : ")" ) ;
			}
		public void Statement( string text )
			{
			list.Add( text ) ;
			}
		}
	static public void Methods()
		{
		foreach( Program.Method m in methodset )
			m.Compose() ;
		}
	public class Method
		{
		List<object> list = new List<object>() ;
		List<string> labels = new List<string>() ;
		public bool    Virtual ;
		public bool    Static ;
		public bool    CallConvInstance ;
		public string  Type ;
		public string  ClassSymbol ;
		public string  Name ;
		public string  SigArgTypes ;
		public int     SigArgs ;
		public int     MaxStack ;
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
		public void Compose()
			{
			foreach( object o in list )
				if( o is Oprand )
					(o as Oprand).Compose() ;
			var d = new Program.Declaration() ;
			string p = "" ;
			int args = SigArgs + ( CallConvInstance ? 1 : 0 ) ;
			if( Virtual )
				p = "struct _string " ;
			else
				p = "void " ;
			p += ClassSymbol + Name + SigArgTypes ;
			if( args == 0 )
				p += "()" ;
			else
				p += "( const void** args )" ;
			d.Header.Add( p ) ;
			d.Statement( "const void** stack = alloca( " + MaxStack + " )" ) ;
			foreach( object o in list )
				{
				if( o is Oprand )
					d.Statement( (string) (o as Oprand) ) ;
				else
					{
					string label = (string) o ;
					if( labels.Contains( label ) )
						d.Add( "\t" + label + " :" ) ;
					}
				}
			if( Virtual )
				d.Statement( "return *(struct _string *)*stack" ) ;
			}
		}
	}
}
