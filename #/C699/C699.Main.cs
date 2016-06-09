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
		}
	public static readonly string Args = '('+C.Int.ArgC+','+C.Char.p.p.ArgV+','+C.Char.p.p.Env+')' ;
	}
}
