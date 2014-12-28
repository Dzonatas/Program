public static partial class Tokenset
	{
	static int index = 0 ;
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
	}
