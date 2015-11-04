partial class C699
{
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
}
