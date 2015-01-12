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
	System.Func<int,int> reductionset_s ;
	System.Func<int,int> gotoset_s ;
	static Tokenset.Token         token ;
	static bool  token_HasValue   = false ;
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
	void deploy( ref planet b )
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
			x = reductionset_s( b.yy ) ;
			if( x != reductionset.GetLength(0) )
				{
				rule = reductionset[x,1] ;
				b.yy = xo_t[rule] ;
				for( int z = 0 ; z < gotoset.GetLength(0) ; z++ )
					if( gotoset[z,0] == b.yy )
						goto transit ;
				goto jump ;
				}
			if( _default != -1 )
				{
				rule = reductionset[_default,1] ;
				b.yy = xo_t[rule] ;
				}
			}
		transit:
		x = gotoset_s( b.yy ) ;
		if( x != gotoset.GetLength(0) )
			if( gotoset[x,0] == b.yy )
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
		throw new ReducedAcception( rule ) ;

		new_state :
		try {
			xyzzy.auto.deploy( ref xyzzy ) ;
			b.yy = xyzzy.yy ;
			}
		catch ( ReducedAcception bb )
			{
			if( --bb.backup > 0 )
				throw bb ;
			b.yy = xo_t[bb.rule] ;
			}
		x = gotoset_s( b.yy ) ;
		if( x != gotoset.GetLength(0) )
			{
			int t = gotoset[x,1] ;
			xyzzy = new planet( ruleset[t], pointset[t], stateset[t], __default ) ;
			goto new_state ;
			}
		if( token.c != 0 )
			throw new System.NotImplementedException( "token != $end" ) ;
		return ;
		}
	public class ReducedAcception : System.Exception
		{
		public int     rule ;
		public int     backup ;
		public ReducedAcception( int rule )
			{
			this.rule = rule  ;
			this.backup = xo_l[rule] ;
			}
		public override string ToString()
				{
				return string.Format("[ReducedAcception={0}]{1}",backup,xo_t[rule]);
				}
		}
	}
