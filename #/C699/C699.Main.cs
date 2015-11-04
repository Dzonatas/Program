partial class C699
{
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
}
