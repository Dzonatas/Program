//namespace C {
public partial class C699 {
	public static class Main
		{
		public static File.Structure FileStructure ;
		const string entry = "program" ;
		static Main()
			{
			FileStructure = File.C( entry ) ;
			FileStructure.WriteLine( "#include <BCL.HPP>" ) ;
			}
		}
	public static class File
		{
		public struct Structure
			{
			public string FileName ;
			System.IO.StreamWriter sw ;
			public Structure WriteLine( string line )
				{
				sw.WriteLine( line ) ;
				return this ;
				}
			internal Structure( string filename )
				{
				FileName = filename ;
				sw = Current.Path.CreateText( filename + ".c" ) ;
				}
			public static implicit operator System.IO.StreamWriter( Structure s )
				{
				return s.sw ;
				}
			public void Close()
				{
				sw.Close() ;
				}
			}
		public static Structure C( string filename )
			{
			return new Structure( filename ) ;
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
	public void WriteTo( C699.File.Structure fs )
		{
		Program.C_Function.FromSymbol( Symbol ).WriteTo( fs ) ;
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
