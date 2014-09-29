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
partial class Program
	{
	public static C_Function C699_Main_Function()
		{
		var c = C_Function.FromSymbol( "main" ) ;
		c.Args = "( int argc , char** args , char** env )" ;
		var e = A335.Method.EntryPoint.Head ;
		if( A335.Method.cctorset.Contains(e.ClassType) )
			{
			c.Statement( "extern void " + e.ClassType + "_cctor()" ) ;
			c.Statement( e.ClassType + "_cctor()" ) ;
			}
		c.Statement( "extern void " + e.ClassType + "$Main()" ) ;
		c.Statement( e.ClassType + "$Main()" ) ;
		return c ;
		}
	}
}
