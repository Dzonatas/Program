using Debug = System.Console ;
partial class Automaton
	{
	int          rule          ;
	ulong        shiftset_i    ;
	bool         lookahead_b   ;
	bool         volatile_b    ;
	bool         reduction_v   ;
	bool         goto_v        ;
	System.Func<int,int> reductionset_s ;
	System.Func<int,ulong> gotoset_s ;
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
		ulong t ;
		if( ! ( volatile_b || lookahead_b ) )
			{
			token_HasValue = false ;
			t = shiftset_i ;
			}
		else
		if( (reduction_v ? rule : rule = reductionset_s( b.yy )) != (-(int)__default) )
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
			xyzzy = new planet( t ) ;
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
