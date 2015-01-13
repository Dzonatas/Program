using Debug = System.Console ;
partial class Automaton
	{
	int[,]       gotoset       ;
	int[]        stateset      ;
	int[]        ruleset       ;
	int[]        pointset      ;
	int[,]       reductionset  ;
	int          _default      ;
	bool         lookahead_b   ;
	int          shiftset_i    ;
	bool         volatile_b    = false ;
	bool         reduction_v   = false ;
	bool         goto_v        = false ;
	System.Func<int,int> reductionset_s ;
	System.Func<int,int> gotoset_s ;
	static Tokenset.Token         token ;
	static bool  token_HasValue   = false ;
	static int   backup ;
	public Automaton( System.Action<Automaton> _set )
		{
		_set( this ) ;
		}
	static void log( string point )
		{
		System.Console.Write( point ) ;
		}
	static void log_end()
		{
		System.Console.WriteLine() ;
		}
	void unshift( System.Action _rule )
		{
		_rule() ;
		}
	void Goto( System.Action<Automaton> new_state )
		{
		new Automaton( new_state ) ;
		}
	static void shift( System.Action<Automaton> _set )
		{
		token = Tokenset.Input ;
		new Automaton( _set ) ;
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
			this.yy = __default ;
			if( ! token_HasValue )
				{
				token = Tokenset.Input ;
				token_HasValue = true ;
				}
			auto = new Automaton( xo_a[z] ) ;
			}
		internal planet( int x, int y, int zz, int yy )
			{
			this.x = x ;
			this.y = y ;
			this.zz = zz ;
			this.yy = yy ;
			if( ! token_HasValue )
				{
				token = Tokenset.Input ;
				token_HasValue = true ;
				}
			auto = new Automaton( xo_a[zz] ) ;
			}
		public override string ToString()
				{
				return string.Format("_{0}_{1}_{2}_{3}",x,y,zz,yy) ;
				}
		}
	int deploy( ref planet b )
		{
		planet     xyzzy ;
		int rule = -1 ;
		int x ;
		if( ! volatile_b )
			{
			if( lookahead_b )
				b.yy = token.point ;
			else
				{
				b.yy  = token.point ;
				token_HasValue = false ;
				int t = shiftset_i ;
				xyzzy = new planet( ruleset[t], pointset[t], stateset[t] ) ;
				goto new_state ;
				}
			}
		if( ! reduction_v )
			{
			if( ( x = reductionset_s( b.yy ) ) != reductionset.GetLength(0) )
				{
				rule = reductionset[x,1] ;
				b.yy = xo_t[rule] ;
				if( ! goto_v )
					if( ( x = gotoset_s( b.yy ) ) != gotoset.GetLength(0) )
						{
						int t = gotoset[x,1] ;
						xyzzy = new planet( ruleset[t], pointset[t], stateset[t], __default ) ;
						goto new_state ;
						}
				goto jump ;
				}
			if( _default != -1 )
				{
				rule = reductionset[_default,1] ;
				b.yy = xo_t[rule] ;
				}
			}
		if( ! goto_v )
			if( ( x = gotoset_s( b.yy ) ) != gotoset.GetLength(0) )
				{
				int t = gotoset[x,1] ;
				xyzzy = new planet( ruleset[t], pointset[t], stateset[t], __default ) ;
				goto new_state ;
				}
		if( b.yy == __default && _default == -1 )
			{
			throw new System.NotImplementedException( "Missed token?" ) ;
			}
		jump :
		//Auto( this_xo_t ) ;
		backup = xo_l[rule] ;
		return -rule ;

		new_state :
		rule = xyzzy.auto.deploy( ref xyzzy ) ;
		if( rule >= 0 )
			b.yy = xyzzy.yy ;
		else
			{
			if( --backup > 0 )
				return rule ;
			b.yy = xo_t[-rule] ;
			}
		if( ! goto_v )
			{
			if( ( x = gotoset_s( b.yy ) ) != gotoset.GetLength(0) )
				{
				int t = gotoset[x,1] ;
				xyzzy = new planet( ruleset[t], pointset[t], stateset[t], __default ) ;
				goto new_state ;
				}
			}
		if( token.c != 0 )
			throw new System.NotImplementedException( "token != $end" ) ;
		return 0 ;
		}
	}
