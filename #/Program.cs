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
class Program
	{
	static Dictionary<string,object> virtualset = new Dictionary<string,object>() ;
	static List<Method>  methodset = new List<Method>() ;
	static List<string>  cctorset = new List<string>() ;
	public class C_Function
		{
		public bool Static ;
		public bool Inline ;
		public bool Void
			{
			set {
				if( value )
					Type = "void" ;
				}
			}
		public bool Bool
			{
			set {
				if( value )
					Type = "int" ;
				}
			}
		public string Type ;
		public string Symbol ;
		public bool   HasArgs ;
		public string Args ;
		List<string> list = new List<string>() ;
		public C_Function( string symbol )
			{
			Type = "void" ;
			Symbol = symbol ;
			}
		public void Statement( string line )
			{
			list.Add( "\t" + line + " ;" ) ;
			}
		public void Label( string label )
			{
			list.Add( "\t" + label + " ;" ) ;
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
			}
		}
	static public void WriteC_Main()
		{
		var c = new C_Function( "main" ) ;
		c.Args = "( int argc , char** args , char** env )" ;
		if( cctorset.Contains(this_start_method.ClassSymbol) )
			{
			c.Statement( "extern void " + this_start_method.ClassSymbol + "_cctor()" ) ;
			c.Statement( this_start_method.ClassSymbol + "_cctor()" ) ;
			}
		c.Statement( "extern void " + this_start_method.ClassSymbol + "$Main()" ) ;
		c.Statement( this_start_method.ClassSymbol + "$Main()" ) ;
		c.WriteTo( program_output ) ;
		program_output.WriteLine( "#include <BCL.HPP>" ) ;
		foreach( Program.Method m in methodset )
			m.WriteInclude( program_output ) ;
	    foreach( string class_symbol in virtualset.Keys )
			C_Struct.FromSymbol( class_symbol ).WriteInclude( program_output ) ;
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
			var c = new C_Function( Instruction + "$" + ID ) ;
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
			var c = new C_Function( ClassSymbol + Name + SigArgTypes ) ;
			StreamWriter sw = File.CreateText( directory.FullName + "/" + c.Symbol + ".c" ) ;
			foreach( object o in list )
				if( o is Oprand )
					(o as Oprand).WriteTo( sw ) ;
			int args = SigArgs + ( CallConvInstance ? 1 : 0 ) ;
			if( Virtual )
				c.Type = "struct _string" ;
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
						c.Label( "\t" + label + " :" ) ;
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
