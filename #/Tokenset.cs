public static partial class Tokenset
	{
	static int index = 0 ;
	#if EMBED
	public static string[] Argv
		{
		get {
			string[] p = new string[tokenset.GetLength(0)] ;
			for( int i = 0 ; i < p.Length ; i++ )
				p[i] = (string)tokenset[i,1] ;
			return p ;
		    }
		}
	public static string[] Points
		{
		get {
			string[] p = new string[tokenset.GetLength(0)] ;
			for( int i = 0 ; i < p.Length ; i++ )
				p[i] = ((int)tokenset[i,3]).ToString() ;
			return p ;
		    }
		}
	#else
	public static _.Token Input
		{
		get {
			char c   = (char)(int)tokenset[index,0] ;
			string s = (string)tokenset[index,1] ;
			bool b   = ((int)tokenset[index,2])==0?false:true ;
			int p    = (int)tokenset[index,3] ;
			if( s != "$end")
				index++ ;
			return new _.Token( c, s, b, p ) ;
		    }
		}
	#endif
	}
