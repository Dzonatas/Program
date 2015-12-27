public class Test5
	{
	static System.Func<int,string> text ;
	static string[] word = new string[] { "Hello", " ", "World" } ;

	static void Main( string[] args )
		{
		text = (i) => { return word[i] ; } ;
		System.Console.Write( text(0) ) ;
		System.Console.Write( text(1) ) ;
		System.Console.WriteLine( text(2) ) ;
		}
	}
