partial class A335
{
static string branch ;
static void Branch_i( string input )
	{
	foreach( string s in input.Split( new char[] { '\n' } ) )
		if( s.Length > 2 && s[0] == '*' )
			{
			branch = s.Substring( 2 ).Trim() ;
			return ;
			}
	}
public static string Branch
	{
	get { return branch ; }
	}
}