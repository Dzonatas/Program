using Debug = System.Console ;
partial class Automaton
	{
	long         transit_i    ;
	bool         lookahead_b   ;
	bool         volatile_b    ;
	bool         goto_v        ;
	System.Func<int,ulong> gotoset_s ;
	static System.Func<Automaton,long> edge_case ;
	Tokenset.Token                _token ;
	static Tokenset.Token         token ;
	static bool  token_HasValue   = false ;
	static int   backup ;
	static global::Item auto ;
	public Automaton( System.Func<Automaton,long> _set )
		{
		transit_i = _set( this ) ;
		}
	static void log( string point )
		{
		System.Console.Write( point ) ;
		}
	static void log_end()
		{
		System.Console.WriteLine() ;
		}
	struct planet
		{
		internal int        x ;
		internal int        y ;
		internal int        zz ;
		internal int        yy ;
		internal Automaton  auto ;
		internal planet( ulong rps )
			{
			this.x  = (int) ((rps & (((ulong)ushort.MaxValue)<<32)) >> 32) ;
			this.y  = (int) ((rps &   (((ulong)byte.MaxValue)<<16)) >> 16) ;
			this.zz = (int) ((rps &  ((ulong)ushort.MaxValue))) ;
			this.yy = (int) __default ;
			if( ! token_HasValue )
				{
				token = Tokenset.Input ;
				token_HasValue = true ;
				}
			auto = new Automaton( xo_a[this.zz] ) ;
			}
		public override string ToString()
				{
				return string.Format("_{0}_{1}_{2}_{3}",x,y,zz,yy) ;
				}
		}
	static void planet_0()
		{
		planet b = new planet(0) ;
		b.auto.deploy( ref b ) ;
		}
	int deploy( ref planet b )
		{
		planet     xyzzy ;
		ulong t ;
		if( transit_i > 0 && transit_i <= __default )
			log( "("+transit_i+")" ) ;
		if( ! ( volatile_b || lookahead_b ) )
			{
			_token = token ;
			token_HasValue = false ;
			t = (ulong)transit_i ;
			}
		else
		if( transit_i <= 0 )
			{
			if( token_HasValue )
				_token = Tokenset.Empty ;
			if( goto_v )
				return (int)transit_i ;
			if( (t = gotoset_s( xo_t[-transit_i] )) == __default )
				return xo_r[-transit_i]() ;
			}
		else
			t = (ulong)transit_i ;
		do	{
			xyzzy = new planet( t ) ;
			xyzzy.auto._token = _token ;
			int i ;
			if( (i = xyzzy.auto.deploy( ref xyzzy )) >= 0 )
				b.yy = xyzzy.yy ;
			else
				{
				(auto as bis.Auto).Argv = _token ;
				if( --backup > 0 )
					return (int)i ;
				b.yy = xo_t[-i] ;
				(auto as bis.Auto).Splice() ;
				}
			} while( (! goto_v) && (t = gotoset_s( b.yy )) != __default ) ;
		if( token.c != 0 )
			throw new System.NotImplementedException( "token != $end" ) ;
		return 0 ;
		}
	}
