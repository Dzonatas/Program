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
		public static readonly string Args = '('+C.Int.ArgC+','+C.Charpp.ArgV+','+C.Charpp.Env+')' ;
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
	public readonly static C_Symbol     Symbol = C_Symbol.Acquire( C699.KeyedWord.Main ) ;
	}
partial class Program
	{
	public static System.IO.StreamWriter C699_Main_Function___WriteTo__C699_Main_FileStructure__()
		{
		var c = C_Function.FromSymbol( A335.Main.Symbol ) ;
		c.Args = C699.Main.Args ;
		var e = A335.Method.EntryPoint.Head ;
		if( string.Join( "!", Class.Cctors).Contains( e.ClassType ) )
		//if( e.Cctor )
			{
			c.Statement( C699.C.Extern.Void.Cctor(e.ClassType) ) ;
			c.Statement( C699.C.Cctor(e.ClassType) ) ;
			}
		c.Statement( C699.C.Extern.Void.Function(e.ClassType,  "Main") ) ;
		c.Statement( C699.C.Function(e.ClassType, "Main") ) ;
		c.WriteTo( C699.Main.FileStructure ) ;
		return C699.Main.FileStructure ;
		}
	}
}
