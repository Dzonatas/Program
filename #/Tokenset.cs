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
	#endif
	}
