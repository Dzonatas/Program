using J.ext ;

public partial class A335
{
const int ʄ = (int)_var.DEFAULT ; //.0 ; //var ʄ_ = ʄ._ ;
//const int j_ECMA_script_v = 00.000 ;//API := [ <CONSTANT> | specific_n ]:(/Re/ST(ART:OPTIONS]/#)(/_)
//const int j_script_jXSsLT = 00.000 ;//API := [ <CONSTANT> | specific_n ]:(/Re/ST(ART:OPTIONS]/#):xsString := [API:]
//const int j_script_jXSsLT_ = 0.00  ;//ABI := (/Re/ST(ART:OPTIONS]/#):xsString := [API:]
//const int j_script_jXSsLT__ =0.0   ;//RTP := (./ST/#):[(ABI)]
//const var javascript = {...} ;_atomic,_QM,_precursory,_aot,</include.(flags)>'URN:(F#)'"p.ioN___"<o/o>...,_/\_._x.y
static void jump_( ref xyzzyy b )  //_FIXT:_not_replicative,_8*2=16_effective_nybbles,_4_integers_used,_spase
	{
	State      state = stateset[b.zz] ;
	setstate:
	request( ref state ) ;
	xyzzyy     xyzzy ;
	debug = b.zz == 168 ? true : debug ;
	if( debug || b.zz == 109 )
		System.Console.Beep() ; //System.Voxel.Dump([System.Console.Beep(),_debug]);
	
	//xo_ = xo_t[b.x][b.y] ;
	if( b.yy > _default )           //_debug:_token_"falls_through",_literally,list{}_OR_enlist(RT),_debug:[default:,"0.0"];
		goto nt ;
	if( b.yy == _default && ! token.HasValue )
		{
		if( state.transitionset.Length == 0 )
			goto reduce ;
		if( state.lookaheadset.Count == 0 )
			{
			if( state.default_item.HasValue )
				{
				b.yy = xo_t[state.itemset[state.default_item.Value].rule] ;
				goto transit ;
				}
			}
		else
			System.Console.Beep() ;
		if( state.default_item.HasValue )
			{
			/*
			i = state.itemset[state.default_item.Value] ;
			_xo = i ;
			if( ! _xo.Left )
				foreach( Transition tt in state.transitionset )
					if( tt == xo_t[i.rule][i.point] )
						{
						xyzzy = new xyzzyy( i.rule, i.point, tt.state, (int)_default ) ;
						goto _jump ;
						}
			*/
			}
		if( state.transitionset[0].type == "goto" )
			goto reduce ;
		}
	
	//if( token.HasValue )
	//	Console.Beep() ;
		
	if( state.transitionset.Length > 0 )
		{
		if( ! token.HasValue ) 
			token = input() ;
		if( b.yy == xml_translate[token.Value.c] )
			System.Console.SetCursorPosition(0,0) ;
		b.yy = xml_translate[token.Value.c] ;
		}
	reduce :
	if( state.lookaheadset.Contains( b.yy ) )
		System.Console.Beep() ;
	foreach( Reduction rr in state.reductionset )
		if( rr == b.yy )
			if( b.yy == _default && state.lookaheadset.Count == 0 )
				{
				state.zlog.Add( rr ) ;
				goto default_ ;
				}
			else
			if( b.yy == _default )
					System.Console.Beep() ;
	transit:
	foreach( Transition t in state.transitionset )
		if( t == b.yy )
			{
			state.zlog.Add( t ) ;
			if( t.type == "shift" )
				{
				token = null ;
				xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, b.yy ) ;
				goto _jump ;
				}
			xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, (int)_default ) ;
			goto _jump ;
			}
	default_ : //_Item(<t`>).imaginary=true
	throw new ReducedAcception( state.reductionset[state.default_reduction.Value].rule ) ;

	_jump :
	try {
		jump_( ref xyzzy ) ;
		}
	catch ( ReducedAcception bb )
		{
		state.zlog.Add( bb ) ;
		if( --bb.backup > 0 )
			throw bb ;
		xyzzy.yy = xo_t[bb.rule] ;
		goto _jump ;
		}
	if( b.yy == xyzzy.yy )
		System.Console.Beep() ;
	if( ! token.HasValue ) 
		token = input() ;
	b.yy = xyzzy.yy ; 
	if( b.yy > _default )
		goto nt ;
	goto setstate ;
	nt:	{
		if( state.transitionset.Length > 0 )
			{
			foreach( Transition t in state.transitionset )
				if( t == b.yy )
					{
					state.zlog.Add( b.yy ) ;
					state.zlog.Add( t ) ;
					xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, ʄ._() ) ; //((int)_default)._ ) ; //_FIX:jo{t`_x.y}[^_`']{{_entity[':']}}[,_s[,_bit[-bit]]][^_`'] //"bottoms-out" on contextual deduction between locked states and convexion //_PIT:default:'IMacro' := alias ? exception, 'ice'-acception ;
					goto _jump ;
					}
			}
		state.zlog.Add( b.yy ) ;
		}
	return ;
	}

/*
atomic struct jo : <T,t> [, [remote]]    //_if(T==$undefined) T=$anonymous,t=$global
	{
	[remote] var() { default: return [ice] lock<T,t> {} }  //_FIX:(RT)_gen_t,_no_ice_no_ms
	}
	
jo
 {
 if( $caller == $this )....   //_P!=NP,_remote_is_caller_or_local_([in]_inverse)
 	return $this.method() ; //<blob/>
 return $caller.method() ; //_FIX:breaks_DOTTEDNAME,_FIXT:used_space_not_'.',_ecma_"default"?_WS_OR_$$ //<blurb/>
 }
*/

}


namespace J.ext
	{
	public enum _var
		{
		DEFAULT,
		COMPUTED_SQSTRING                    //https://plus.google.com/113166633786671863217/posts/1az1UfVuWmW
		}
	public static class var_
		{
		static int digits ;
		static System.Decimal sid ;
		public static int _(this int d)
			{
			switch(d)
				{
				case (int)_var.DEFAULT: return digits ;
				default: return ((sid - (System.Decimal)digits) > 0.0m) ? (int)_var.DEFAULT : d ;
				}
			//throw new Exception("[Affinty]=[Infinite]+[Finite]") ;
			}
		public static int _default(this int d, int _sid)
			{
			return digits = (int) System.Decimal.Truncate(sid = _sid) ;
			}
		public static int _default(this int d, System.Decimal _sid)
			{
			return digits = (int) System.Decimal.Truncate(sid = _sid) ;
			}
		public static int node(this int d, int M, int N) //inode ~:= ʄnode
			{
			return 0 ; //i<1.000…<HDR
			}
		}
	}
