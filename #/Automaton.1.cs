using Debug = System.Console ;
partial class Automaton
	{
	bool         goto_v        ;
	System.Func<int,int> gotoset_s ;
	static System.Func<int> edge_case ;
	Tokenset.Token                _token ;
	static Tokenset.Token         token ;
	static bool  token_HasValue   = false ;
	static int   backup ;
	static global::Item auto ;
	Automaton()
		{
		if( ! token_HasValue )
			{
			token = Tokenset.Input ;
			token_HasValue = true ;
			}
		}
	static void log( string point )
		{
		System.Console.Write( point ) ;
		}
	static void log_end()
		{
		System.Console.WriteLine() ;
		}
	static int yy ;
	int rps ;
	int deploy( int i )
		{
		do	{
			if( i > 0 )
				throw new System.NotImplementedException( "-range/+index condition" ) ;
			else
			if( i < 0 )
				{
				(auto as bis.Auto).Argv = _token ;
				if( --backup > 0 )
					return (int)i ;
				//yy = xo_t[-i] ;
				(auto as bis.Auto).Splice() ;
				}
			else
				yy = (int)__default ;
			} while( (! goto_v) && (i = (int) gotoset_s( yy )) != __default ) ;
		if( token.c != 0 )
			throw new System.NotImplementedException( "token != $end" ) ;
		return 0 ;
		}
	}
