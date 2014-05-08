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
	static List<Line> list = new List<Line>() ;
	static public void Add( string text )
		{
		Line l = new Line() ;
		l.Add( text ) ;
		}
	static public string Composite()
		{
		string program = "" ;
		foreach( Line l in list )
			{
			program += l + "\n" ;
			}
		return program ;
		}
	static public void Start()
		{
		Add( "#include <BCL.HPP>\n\n" ) ;
		}
	public override string ToString()
		{
		return Composite() ;
		}
	public class Line
		{
		static int counter ;
		List<string> list = new List<string>() ;
		public Line()
			{
			Program.list.Add( this ) ;
			list.Add( "#line " + counter++ ) ;
			}
		public Line( bool numbered )
			{
			Program.list.Add( this ) ;
			if( numbered )
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
			body.Add(   "        {" ) ;
			footer.Add( "        }" ) ;
			}
		public Line Header
			{
			get { return header ; }
			}
		public void Add( string text )
			{
			body.Add( text ) ;
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
		d.Add( "        const void** stack = alloca(0) ;\n" ) ;
		d.Add("        " + this_start_class + "$Main() ;\n" ) ;
		var l = new Line() ;
		l.Add( d ) ;
		}
	static public void C_Objects()
		{
	    foreach( string class_symbol in virtualset.Keys )
			{
			Program.C_Object( class_symbol ) ;
			}
		}
	static public void C_Object( string class_symbol )
		{
		List<string> l = (List<string>) virtualset[class_symbol] ;
		string p = "" ;
		foreach( string s in l )
			p += "        ." + s + " = " + class_symbol + s + " ,\n" ;
		Program.Add
			(
			"struct _object " + class_symbol + " =\n" +
			"        {\n" +
			p +
			"        } ;\n\n"
			) ;
		}
	}
}