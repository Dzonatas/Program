using Debug = System.Console ;
partial class Automaton
	{
	int[]        lookaheadset  ;
	int[,]       shiftset      ;
	int[,]       gotoset       ;
	string[]     typeset       ;
	int[]        symbolset     ;
	int[]        stateset      ;
	int[]        ruleset       ;
	int[]        pointset      ;
	int[,]       reductionset  ;
	int          _default      ;
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
			this.x = x ;
			this.y = y ;
			this.zz = z ;
			this.yy = 0 ;
			auto = new Automaton( xo_a[z] ) ;
			}
		internal planet( int x, int y, int zz, int yy )
			{
			this.x = x ;
			this.y = y ;
			this.zz = zz ;
			this.yy = yy ;
			auto = new Automaton( xo_a[zz] ) ;
			}
		internal planet transition( int z )
			{
			return new planet( x, y, z, yy ) ;
			}
		public override string ToString()
				{
				return string.Format("_{0}_{1}_{2}_{3}",x,y,zz,yy) ;
				}
		}
	class item : global::Item
		{
		static item[]  stack = new item[0] ;
		planet         point ;
		Tokenset.Token token ;
		public item( planet _point, Tokenset.Token token )
			{
			System.Array.Resize( ref stack, stack.Length+1 ) ;
			stack[stack.Length-1] = this ;
			}
		}
	void deploy( ref planet b )
		{
		planet     xyzzy ;
		int rule = -1 ; // 9.9.Delete() ;

		#if !DEBUG_STATE
		Debug.WriteLine( "[State] " + b.zz ) ;
		#endif
		if( ! token_HasValue )
			{
			token = Tokenset.Input ;
			token_HasValue = true ;
			#if !DEBUG_TOKEN
			Debug.WriteLine( "[Token] " + token ) ;
			#endif
			}
		foreach( int i in lookaheadset ) if( i == token.point )
			{
			b.yy = token.point ;
			#if !DEBUG_LOGICAL_ALPHABET
			Debug.WriteLine( "[Lookahead] " + token + " -> " + b.yy ) ;
			#endif
			goto reduce ;
			}
		for( int i = 0 ; i < shiftset.GetLength(0) ; i++ )
			if( shiftset[i,0] == token.point )
			{
			b.yy  = token.point ;
			new item( b, token ) ;
			token_HasValue = false ;
			int t = shiftset[i,1] ;
			xyzzy = new planet( ruleset[t], pointset[t], stateset[t], __default ) ;
			#if !DEBUG_SHIFT
			Debug.WriteLine( "[Shift] " + t ) ;
			#endif
			goto new_state ;
			}
		reduce :
		for( int i = 0 ; i < reductionset.GetLength(0) ; i++ )
			if( reductionset[i,0] == b.yy )
				{
				if( reductionset[i,2] == 0  )
					{
					#if DEBUG_DISABLED
					Debug.WriteLine( "[Disabled] " + rr + " ( " + b.yy + " -> " + xo_t[rr.rule] + " ) " ) ;
					#endif
					continue ;
					}
				rule = reductionset[i,1] ; // 9.9.Post([rule]) ;
				#if !DEBUG_REDUCTIONSET
				Debug.WriteLine( "[Reductionset]  ( " + b.yy + " -> " + xo_t[rule] + " ) " ) ;
				#endif
				b.yy = xo_t[rule] ;
				for( int z = 0 ; z < gotoset.GetLength(0) ; z++ )
					if( gotoset[z,0] == b.yy )
						goto transit ;
				goto jump ;
				}
		if( _default != -1 )
			{
			rule = reductionset[_default,1] ; // 9.9.Post([rule]) ; ...
			b.yy = xo_t[rule] ;
			}
		transit:
		for( int i = 0 ; i < gotoset.GetLength(0) ; i++ )
			if( gotoset[i,0] == b.yy )
			{
			int t = gotoset[i,1] ;
			xyzzy = new planet( ruleset[t], pointset[t], stateset[t], __default ) ;
			#if DEBUG_GOTO
			Debug.WriteLine( "[Goto] " + t ) ;
			#endif
			goto new_state ;
			}
		#if !DEBUG_DEFAULT
		Debug.WriteLine( "[Default] " + b.yy ) ;
		#endif
		if( b.yy == __default && _default == -1 )
			{
			#if DEBUG_OOP
			Debug.WriteLine( "[OOP!] Expected default, and this state has no default. Token = " + token ) ;
			#endif
			throw new System.NotImplementedException( "Missed token?" ) ;
			}
		jump :
		#if !DEBUG_REDUCE
		Debug.WriteLine( "[reduce] " + rule ) ;
		#endif
		//Auto( this_xo_t ) ;
		throw new ReducedAcception( rule ) ;

		new_state :
		try {
			b.auto.deploy( ref xyzzy ) ;
			b.yy = xyzzy.yy ;
			}
		catch ( ReducedAcception bb )
			{
			if( --bb.backup > 0 )
				throw bb ;
			b.yy = xo_t[bb.rule] ;
			}
		for( int i = 0 ; i < gotoset.GetLength(0) ; i++ )
			if( gotoset[i,0] == b.yy )
			{
			int t = gotoset[i,1] ;
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
