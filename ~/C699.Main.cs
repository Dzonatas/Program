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
