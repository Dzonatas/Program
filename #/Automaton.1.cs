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
		Automaton a = new Automaton() ;
		a.deploy( xo_a[0](a) ) ;
		}
	static int yy ;
	int deploy( long rps )
		{
		do	{
			int i ;
			Automaton a = new Automaton() ;
			rps = xo_a[ (rps &  ((long)ushort.MaxValue)) ](a) ;
			if( rps > 0 )
				i = a.deploy( rps ) ;
			else
			if( a.goto_v )
				i = (int)rps ;
			else
				{
				log( "\n{"+rps ) ;
				long t = a.gotoset_s(  /*yy=*/  xo_t[-rps] ) ;
				log( ","+t+"}" ) ;
				if( t == __default )
					i = xo_r[-rps]() ;
				else
					i = a.deploy( t ) ;
				}
			if( i < 0 )
				{
				(auto as bis.Auto).Argv = _token ;
				if( --backup > 0 )
					return (int)i ;
				yy = xo_t[-i] ;
				(auto as bis.Auto).Splice() ;
				}
			else
				yy = (int)__default ;
			} while( (! goto_v) && (rps = gotoset_s( yy )) != __default ) ;
		if( token.c != 0 )
			throw new System.NotImplementedException( "token != $end" ) ;
		return 0 ;
		}
	}
