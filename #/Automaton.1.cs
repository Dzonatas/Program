using Debug = System.Console ;
partial class Automaton
	{
	bool         goto_v        ;
	System.Func<int,long> gotoset_s ;
	static System.Func<Automaton,long> edge_case ;
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
	static void planet_0()
		{
		int   yy  = (int)__default ;
		Automaton a = new Automaton() ;
		a.deploy( xo_a[0](a), ref yy ) ;
		}
	int deploy( long rps, ref int yy )
		{
		long t ;
		if( rps <= 0 )
			{
			if( goto_v )
				return (int)rps ;
			log( "\n{"+rps ) ;
			t = gotoset_s( /* yy= */ xo_t[-rps] ) ;
			log( ","+t+"}" ) ;
			if( t == __default )
				return xo_r[-rps]() ;
			}
		else
			t = rps ;
		do	{
			int i ;
			int y = (int)__default ;
			Automaton a = new Automaton() ;
			//a._token = _token ;
			if( (i = a.deploy( xo_a[ (t &  ((long)ushort.MaxValue)) ](a), ref y )) >= 0 )
				yy = y ;
			else
				{
				(auto as bis.Auto).Argv = _token ;
				if( --backup > 0 )
					return (int)i ;
				yy = xo_t[-i] ;
				(auto as bis.Auto).Splice() ;
				}
			} while( (! goto_v) && (t = gotoset_s( yy )) != __default ) ;
		if( token.c != 0 )
			throw new System.NotImplementedException( "token != $end" ) ;
		return 0 ;
		}
	}
