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
	
	log( "[State] " + state ) ;
	if( ! token.HasValue ) 
		{
		token = input( ref Hacked.Materials.H.Line ) ;
		log( "[Token] " + token ) ;
		}
	if( state.lookaheadset.Contains( xml_translate[token.Value.c] ) )
		{
		b.yy = xml_translate[token.Value.c] ;
		log( "[Lookahead] " + token + " -> " + b.yy ) ;
		goto reduce ;
		}
	if( state.shiftset.ContainsKey( xml_translate[token.Value.c] ) )
		{
		b.yy  = xml_translate[token.Value.c] ;
		Stack.Push( new Stack.Item.Token( b, token.Value ) ) ;
		token = null ;
		Transition t = state.transitionset[ state.shiftset[b.yy] ] ;
		xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, _default ) ;
		log( "[Shift] " + t ) ;
		goto _jump ;
		}
	reduce :
	foreach( Reduction rr in state.reductionset )
		if( rr == b.yy )
			{
			if( ! rr.enabled )
				{
				log( "[Disabled] " + rr + " ( " + b.yy + " -> " + xo_t[rr.rule] + " ) " ) ;
				continue ;
				}
			log( "[Reductionset] " + rr + " ( " + b.yy + " -> " + xo_t[rr.rule] + " ) " ) ;
			b.yy = xo_t[rr.rule] ;
			goto transit ;
			}
	if( state.default_reduction.HasValue )
		b.yy = xo_t[state.reductionset[state.default_reduction.Value].rule] ;
	transit:
	if( state.gotoset.ContainsKey( b.yy ) )
		{
		Transition t = state.transitionset[ state.gotoset[b.yy] ] ;
		xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, (int)_default ) ;
		log( "[Goto] " + t ) ;
		goto _jump ;
		}
	log( "[Default] " + b.yy ) ;
	if( b.yy == _default && ! state.default_reduction.HasValue )
		{
		log( "[OOP!] Expected default, and this state has no default. Token = " + token ) ;
		throw new System.NotImplementedException( "Missed token?" ) ;
		}
	this_xo_t = xo_t[state.reductionset[state.default_reduction.Value].rule] ;
	try {
		log( "[reduce] " + this_xo_t.ReductionMethod ) ;
		typeof(A335).InvokeMember( this_xo_t.ReductionMethod, 
			System.Reflection.BindingFlags.InvokeMethod |
			System.Reflection.BindingFlags.NonPublic |
			System.Reflection.BindingFlags.Static,
			null, null, null ) ;
		}
	catch( System.MissingMemberException e )
		{
		log( "["+e.GetType().ToString()+"] " + e.Message ) ;
		Stack.Push( Stack.Pop() ) ;
		}
	throw new ReducedAcception( state.reductionset[state.default_reduction.Value].rule ) ;

	_jump :
	try {
		jump_( ref xyzzy ) ;
		b.yy = xyzzy.yy ; 
		}
	catch ( ReducedAcception bb )
		{
		if( --bb.backup > 0 )
			throw bb ;
		b.yy = xo_t[bb.rule] ;
		}
	if( state.gotoset.ContainsKey( b.yy ) )
		{
		Transition t = state.transitionset[ state.gotoset[b.yy] ] ;
		xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, (int)_default ) ;
		goto _jump ;
		}
	if( token.Value.c != 0 )
		throw new System.NotImplementedException( "token != $end" ) ;
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


