using Debug = System.Console ;
partial class Automaton
	{
	int[,]       gotoset       ;
	int[]        stateset      ;
	int[]        ruleset       ;
	int[]        pointset      ;
	int[,]       reductionset  ;
	int          rule          ;
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
			if( ! token_HasValue )
				{
				token = Tokenset.Input ;
				token_HasValue = true ;
				}
			auto = new Automaton( xo_a[z] ) ;
			if( auto.volatile_b )
				this.yy = __default ;
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
		int t ;
		if( ! ( volatile_b || lookahead_b ) )
			{
			token_HasValue = false ;
			t = shiftset_i ;
			}
		else
		if( (! reduction_v) && (rule = reductionset_s( b.yy )) != (-__default) )
			{
			b.yy = xo_t[rule] ;
			if( goto_v || (t = gotoset_s( b.yy )) == __default )
				{
				//Auto( this_xo_t ) ;
				backup = xo_l[rule] ;
				return -rule ;
				}
			}
		else
			throw new System.NotImplementedException() ;
		do	{
			xyzzy = new planet( ruleset[t], pointset[t], stateset[t] ) ;
			if( (rule = xyzzy.auto.deploy( ref xyzzy )) >= 0 )
				b.yy = xyzzy.yy ;
			else
				{
				if( --backup > 0 )
					return rule ;
				b.yy = xo_t[-rule] ;
				}
			} while( (! goto_v) && (t = gotoset_s( b.yy )) != __default ) ;
		if( token.c != 0 )
			throw new System.NotImplementedException( "token != $end" ) ;
		return 0 ;
		}
	}
