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
		int i = 0 ;
		foreach( Line l in list )
			{
			program += "#line " + i++ + "\n" ;
			program += l ;
			if( ! program.EndsWith( "\n" ) )
				program += "\n" ;
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
		List<string> list = new List<string>() ;
		public Line()
			{
			Program.list.Add( this ) ;
			}
		public void Add( string text )
			{
			list.Add( text ) ;
			}
		public override string ToString()
			{
			string line = "" ;
			foreach( string s in list )
				line += s ;
			return line ;
			}
		}
	static public void C_Main()
		{
		Program.Add
			(
			"int main( int argc , char** args , char** env )\n" +
	        "        {\n" +
	        "        const void** stack = alloca(0) ;\n" +
	        "        " + this_start_class + "$Main() ;\n" +
	        "        }\n\n"
	        ) ;
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