//namespace C {
public partial class C699 {
	public static class Main
		{
		const string entry = "program" ;
		public static System.IO.StreamWriter C()
			{
			var sw = File.C( entry ) ;
			sw.WriteLine( "#include <BCL.HPP>" ) ;
			return sw ;
			}
		}
	public static class File
		{
		public static System.IO.StreamWriter C( string filename )
			{
			return Current.Path.CreateText( filename + ".c" ) ;
			}
		}
}//}

public partial class A335
{
public class Main
	{
	public readonly static C_Symbol     Symbol = C_Symbol.Acquire( "main" ) ;
	public static          C699_Function   Function
		{
		get { return new C699_Function( A335.Main.Symbol ) ; }
		}
	}
public struct C699_Function
	{
	public C_Symbol Symbol ;
	public C699_Function( C_Symbol symbol )
		{
		Symbol = symbol ;
		}
	public void WriteTo( System.IO.StreamWriter sw )
		{
		Program.C_Function.FromSymbol( Symbol ).WriteTo( sw ) ;
		}
	}
partial class Program
	{
	public static C699_Function C699_Main_Function()
		{
		var c = C_Function.FromSymbol( A335.Main.Symbol ) ;
		c.Args = "( int argc , char** args , char** env )" ;
		var e = A335.Method.EntryPoint.Head ;
		if( A335.Method.cctorset.Contains(e.ClassType) )
			{
			c.Statement( "extern void " + e.ClassType + "_cctor()" ) ;
			c.Statement( e.ClassType + "_cctor()" ) ;
			}
		c.Statement( "extern void " + e.ClassType + "$Main()" ) ;
		c.Statement( e.ClassType + "$Main()" ) ;
		return new C699_Function( A335.Main.Symbol ) ;
		}
	}
}
