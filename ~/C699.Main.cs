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
	}
partial class Program
	{
	public static System.IO.StreamWriter C699_Main_Function___WriteTo__C699_Main_FileStructure__()
		{
		var c = C_Function.FromSymbol( A335.Main.Symbol ) ;
		c.Args = "( "+C699.KeyedWord.Int+" argc , "+C699.KeyedWord.Char+"** args , "+C699.KeyedWord.Char+"** env )" ;
		var e = A335.Method.EntryPoint.Head ;
		if( A335.Method.cctorset.Contains(e.ClassType) )
			{
			c.Statement( C699.C.Extern.Void+" " + e.ClassType + "_cctor()" ) ;
			c.Statement( e.ClassType + "_cctor()" ) ;
			}
		c.Statement( C699.C.Extern.Void + e.ClassType + "$Main()" ) ;
		c.Statement( e.ClassType + "$Main()" ) ;
		c.WriteTo( C699.Main.FileStructure ) ;
		return C699.Main.FileStructure ;
		}
	}
}
