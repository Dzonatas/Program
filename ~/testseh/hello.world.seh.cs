namespace SEH
{
public class TestSEH
	{
	static void Main( string[] args )
		{
		try {
			throw new System.Exception() ;
		}
		catch	
			{
			System.Console.WriteLine( "Hello World" ) ;
			}
		}
	}
}
