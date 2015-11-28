partial class C699
{
public static class Main
	{
	public static File.Structure FileStructure ;
	const string entry = "program" ;
	static Main()
		{
		if( Cluster.Parameter.Value("output") == "false" )
			FileStructure = File.C( entry ) ;
		else
			FileStructure = File.C( Cluster.Parameter.Value("output") ) ;
		FileStructure.WriteLine( "#include <BCL.HPP>" ) ;
		}
	public static readonly string Args = '('+C.Int.ArgC+','+C.Charpp.ArgV+','+C.Charpp.Env+')' ;
	}
}
