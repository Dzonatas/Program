public static partial class Tokenset
	{
	static Token[] tokenset ;
	public static Token Input
		{
		get {
			if( tokenset == null )
				return input() ;
			Token t = tokenset[index] ;
			if( t._ != "$end")
				index++ ;
			return t ;
		    }
		}
	public static void Lift()
		{
		Token t ;
		tokenset = new Token[0] ;
		var sw = Current.Path.CreateText( "tokenset.cs" ) ;
		sw.WriteLine( "public static partial class Tokenset {" ) ;
		sw.WriteLine( "static object[,] tokenset =\n\t{" ) ;
		while( (t = input())._ != "$end" )
			{
			System.Array.Resize( ref tokenset, tokenset.Length+1 ) ;
			tokenset[tokenset.Length-1] = t ;
			sw.WriteLine( "\t{{ '\\u{0:X4}', \"{1}\", {2}, {3} }},",
				System.Convert.ToInt16(t.c),
				t._,
				t.terminal.ToString().ToLower(),
				t.point ) ;
			}
		System.Array.Resize( ref tokenset, tokenset.Length+1 ) ;
		tokenset[tokenset.Length-1] = t ;
		sw.WriteLine( "\t{{ '\\u{0:X4}', \"{1}\", {2}, {3} }}"+"\t}} ;\n}}",
			System.Convert.ToInt16(t.c),
			t._,
			t.terminal.ToString().ToLower(),
			t.point ) ;
		sw.Close() ;
		}
	}
