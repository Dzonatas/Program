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
		a.rps = xo_a[0](a) ;
		}
	static int yy ;
	long rps ;
	static long _edge( Automaton a )
		{
		log( "(V)" ) ;
		int i = (int) edge_case( a ) ;
		edge_case = null ;
		return i ;
		}
	int deploy()
		{
		do	{
			int i ;
			Automaton a = new Automaton() ;
			i = (int) xo_a[ (rps &  ((long)ushort.MaxValue)) ](a) ;
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
			} while( (! goto_v) && (rps = gotoset_s( yy )) != __default ) ;
		if( token.c != 0 )
			throw new System.NotImplementedException( "token != $end" ) ;
		return 0 ;
		}
	}
