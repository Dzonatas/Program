using Debug = System.Console ;
partial class Automaton
	{
	long         rule          ;
	long         shiftset_i    ;
	bool         lookahead_b   ;
	bool         volatile_b    ;
	bool         reduction_v   ;
	bool         goto_v        ;
	System.Func<int,long> reductionset_s ;
	System.Func<int,long> gotoset_s ;
	static Tokenset.Token         token ;
	static bool  token_HasValue   = false ;
	static int   backup ;
	public Automaton( System.Func<Automaton,long> _set )
		{
		shiftset_i = _set( this ) ;
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
		internal planet( int x, int y, int z )
			{
			this.x  = x ;
			this.y  = y ;
			this.zz = z ;
			if( ! token_HasValue )
				{
				token = Tokenset.Input ;
				token_HasValue = true ;
				}
			auto = new Automaton( xo_a[z] ) ;
			if( auto.volatile_b )
				this.yy = (int)__default ;
			else
				this.yy = token.point ;
			}
		internal planet( ulong rps )
			{
			this.x  = (int) ((rps & (((ulong)ushort.MaxValue)<<32)) >> 32) ;
			this.y  = (int) ((rps &   (((ulong)byte.MaxValue)<<16)) >> 16) ;
			this.zz = (int) ((rps &  ((ulong)ushort.MaxValue))) ;
			if( ! token_HasValue )
				{
				token = Tokenset.Input ;
				token_HasValue = true ;
				}
			auto = new Automaton( xo_a[this.zz] ) ;
			if( auto.volatile_b )
				this.yy = (int)__default ;
			else
				this.yy = token.point ;
			}
		public override string ToString()
				{
				return string.Format("_{0}_{1}_{2}_{3}",x,y,zz,yy) ;
				}
		}
	int deploy( ref planet b )
		{
		planet     xyzzy ;
		long t = shiftset_i ;
		if( ! ( volatile_b || lookahead_b ) )
			token_HasValue = false ;
		else
		if( t <= __default )
			{
			if( t == __default )
				t = -rule ;
			else
				t = -( rule = (reduction_v ? rule : reductionset_s( b.yy )) ) ;
			b.yy = xo_t[t] ;
			if( goto_v || (t = gotoset_s( b.yy )) == __default )
				{
				//Auto( this_xo_t ) ;
				backup = xo_l[-rule] ;
				return (int)rule ;
				}
			}
		do	{
			xyzzy = new planet( (ulong)t ) ;
			if( (t = xyzzy.auto.deploy( ref xyzzy )) >= 0 )
				b.yy = xyzzy.yy ;
			else
				{
				if( --backup > 0 )
					return (int)t ;
				b.yy = xo_t[-t] ;
				}
			} while( (! goto_v) && (t = gotoset_s( b.yy )) != __default ) ;
		if( token.c != 0 )
			throw new System.NotImplementedException( "token != $end" ) ;
		return 0 ;
		}
	}
