public static partial class Tokenset
	{
	static _.Token[] tokenset ;
	public static _.Token Input
		{
		get {
			if( tokenset == null )
				return _.input() ;
			_.Token t = tokenset[index] ;
			if( t._ != "$end")
				index++ ;
			return t ;
		    }
		}
	public static void Lift()
		{
		_.Token t ;
		tokenset = new _.Token[0] ;
		var sw = Current.Path.CreateText( "tokenset.cs" ) ;
		sw.WriteLine( "public static partial class Tokenset {" ) ;
		sw.WriteLine( "static object[,] tokenset =\n\t{" ) ;
		while( (t = _.input())._ != "$end" )
			{
			System.Array.Resize( ref tokenset, tokenset.Length+1 ) ;
			tokenset[tokenset.Length-1] = t ;
			sw.WriteLine( "\t{ "+((int)t.c)+", \""+t._+"\", "+(t.terminal?'1':'0')+", "+t.point+" }," ) ;
			}
		System.Array.Resize( ref tokenset, tokenset.Length+1 ) ;
		tokenset[tokenset.Length-1] = t ;
		sw.WriteLine( "\t{ "+((int)t.c)+", \""+t._+"\", "+(t.terminal?'1':'0')+", "+t.point+" }" ) ;
		sw.WriteLine( "\t} ;\n}" ) ;
		sw.Close() ;
		}
	}
