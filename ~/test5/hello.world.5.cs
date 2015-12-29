public class Test5
	{
	static void Main( string[] args )
		{
		System.Func<string> text = () => { return "Hello World" ; } ;
		System.Console.WriteLine( text() ) ;
		}
	}
