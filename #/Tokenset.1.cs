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
		sw.WriteLine( "static Token[] tokenset =\n\t{" ) ;
		while( (t = input())._ != "$end" )
			{
			System.Array.Resize( ref tokenset, tokenset.Length+1 ) ;
			tokenset[tokenset.Length-1] = t ;
			sw.WriteLine( "\tnew Token"+t+"," ) ;
			}
		System.Array.Resize( ref tokenset, tokenset.Length+1 ) ;
		tokenset[tokenset.Length-1] = t ;
		sw.WriteLine( "\tnew Token"+t+"\n\t} ;\n}" ) ;
		sw.Close() ;
		}
	}
