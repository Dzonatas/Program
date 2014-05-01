public class Test3
	{
	static string[] text = { "Hello", "World" } ;
	static void Main()
		{
		int i = 0 ;
		string a, b = "" ;
		label:
		switch( i )
			{
			case 0  : a = text[0] ; break ;
			case 2  : a = text[1] ; break ;
			default : a = " "     ; break ;
			}
		b += a ;
		if( ++i < 3 )
			goto label ;
		System.Console.WriteLine( b ) ;
		}
	}
