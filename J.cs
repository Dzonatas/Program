using System.Extensions ;

public partial class A335
{
const int ʄ = (int)_var.DEFAULT ; //.0 ; //var ʄ_ = ʄ._ ;
//const int j_ECMA_script_v = 00.000 ;//API := [ <CONSTANT> | specific_n ]:(/Re/ST(ART:OPTIONS]/#)(/_)
//const int j_script_jXSsLT = 00.000 ;//API := [ <CONSTANT> | specific_n ]:(/Re/ST(ART:OPTIONS]/#):xsString := [API:]
//const int j_script_jXSsLT_ = 0.00  ;//ABI := (/Re/ST(ART:OPTIONS]/#):xsString := [API:]
//const int j_script_jXSsLT__ =0.0   ;//RTP := (./ST/#):[(ABI)] //data:https://github.com/XSockets/WebRTC
//(t`)._x.y
static void jump_( ref xyzzyy b )  //_FIXT:_not_replicative,_8*2=16_effective_nybbles,_4_integers_used,_spase
	{
	State      state = stateset[b.zz] ;
	setstate:
	request( ref state ) ;
	xyzzyy     xyzzy ;
	
	//xo_ = xo_t[b.x][b.y] ;
	if( b.yy > _default )
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
			2.Beep() ;
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
			token = input( ref Hacked.Materials.H.Line ) ;
		if( b.yy == xml_translate[token.Value.c] )
			System.Console.SetCursorPosition(0,0) ;
		b.yy = xml_translate[token.Value.c] ;
		}
	reduce :
	if( state.lookaheadset.Contains( b.yy ) )
		2.Beep() ;
	foreach( Reduction rr in state.reductionset )
		if( rr == b.yy )
			if( b.yy == _default && state.lookaheadset.Count == 0 )
				{
				state.zlog.Add( rr ) ;
				goto default_ ;
				}
			else
			if( b.yy == _default )
					2.Beep() ;
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
		2.Beep() ;
	if( ! token.HasValue ) 
		token = input( ref Hacked.Materials.H.Line ) ;
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
					xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, ʄ._() ) ; //((int)_default)._ ) ; //_FIX:jo{t`_x.y}[^_`']{{_entity[':']}}[,_s[,_bit[-bit]]][^_`'] //"bottoms-out" on contextual deduction between locked states and convexion //_PIT:default:'IMacro' := alias ? exception, (schrooted-)'ice'-acception ;
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


