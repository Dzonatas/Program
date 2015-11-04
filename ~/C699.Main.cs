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
