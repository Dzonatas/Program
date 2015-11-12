partial class A335
{
#if BEGINNING
static private void beginning( ref planet b )  //_FIXT:_not_replicative,_8*2=16_effective_nybbles,_4_integers_used,_spase
	{
	State      state = stateset[b.zz] ;
	setstate:
	this_state = state ;
	planet     xyzzy ;
	int rule = -1 ; // 9.9.Delete() ;

	#if DEBUG_STATE
	Debug.WriteLine( "[State] " + state ) ;
	#endif
	if( ! token.HasValue )
		{
		token = Tokenset.Input ;
		#if !DEBUG_TOKEN
		Debug.WriteLine( "[Token] " + token ) ;
		#endif
		}
	if( state.Lookaheadset.Contains( xml_translate[token.Value.c] ) )
		{
		b.yy = xml_translate[token.Value.c] ;
		#if DEBUG_LOGICAL_ALPHABET
		Debug.WriteLine( "[Lookahead] " + token + " -> " + b.yy ) ;
		#endif
		goto reduce ;
		}
	for( int i = 0 ; i < state.Shiftset.GetLength(0) ; i++ )
		if( state.Shiftset[i,0] == xml_translate[token.Value.c] )
	//if( state.Shiftset.ContainsKey( xml_translate[token.Value.c] ) )
		{
		b.yy  = xml_translate[token.Value.c] ;
		Stack.Push( new Stack.Item.Token( /*b,*/ token.Value ) ) ;
		token = null ;
		Transition t = state.Transitionset[ state.Shiftset[i,1] ] ;
		xyzzy = new planet( (int)t.item.rule, t.item.point, t.state, _default ) ;
		#if DEBUG_SHIFT
		Debug.WriteLine( "[Shift] " + t ) ;
		#endif
		goto new_state ;
		}
	reduce :
	foreach( Reduction rr in state.Reductionset )
		if( rr == b.yy )
			{
			if( ! rr.enabled )
				{
				#if DEBUG_DISABLED
				Debug.WriteLine( "[Disabled] " + rr + " ( " + b.yy + " -> " + xo_t[rr.rule] + " ) " ) ;
				#endif
				continue ;
				}
			#if DEBUG_REDUCTIONSET
			Debug.WriteLine( "[Reductionset] " + rr + " ( " + b.yy + " -> " + xo_t[rr.rule] + " ) " ) ;
			#endif
			rule = (int)rr.rule ; // 9.9.Post([rule]) ;
			b.yy = Rule.Set[rule].Symbol ;
			for( int i = 0 ; i < state.Gotoset.GetLength(0) ; i++ )
				if( state.Gotoset[i,0] == b.yy )
			//if( state.Gotoset.ContainsKey( b.yy ) )
				goto transit ;
			goto jump ;
			}
	if( state.Default_reduction.HasValue )
		{
		rule = (int)state.Reductionset[state.Default_reduction.Value].rule ; // 9.9.Post([rule]) ; ...
		b.yy = Rule.Set[rule].Symbol ;
		}
	transit:
	for( int i = 0 ; i < state.Gotoset.GetLength(0) ; i++ )
		if( state.Gotoset[i,0] == b.yy )
	//if( state.Gotoset.ContainsKey( b.yy ) )
		{
		Transition t = state.Transitionset[ state.Gotoset[i,1] ] ;
		xyzzy = new planet( (int)t.item.rule, t.item.point, t.state, (int)_default ) ;
		#if DEBUG_GOTO
		Debug.WriteLine( "[Goto] " + t ) ;
		#endif
		goto new_state ;
		}
	#if DEBUG_DEFAULT
	Debug.WriteLine( "[Default] " + b.yy ) ;
	#endif
	if( b.yy == _default && ! state.Default_reduction.HasValue )
		{
		Debug.WriteLine( "[OOP!] Expected default, and this state has no default. Token = " + token ) ;
		throw new System.NotImplementedException( "Missed token?" ) ;
		}
	jump :
	#if DEBUG_REDUCE
	Debug.WriteLine( "[reduce] " + this_xo_t.ReductionMethod ) ;
	#endif
	Auto( rule ) ;
	throw new ReducedAcception( rule ) ;

	new_state :
	try {
		beginning( ref xyzzy ) ;
		b.yy = xyzzy.yy ;
		}
	catch ( ReducedAcception bb )
		{
		if( --bb.backup > 0 )
			throw bb ;
		b.yy = Rule.Set[bb.rule].Symbol ;
		}
	for( int i = 0 ; i < state.Gotoset.GetLength(0) ; i++ )
		if( state.Gotoset[i,0] == b.yy )
	//if( state.Gotoset.ContainsKey( b.yy ) )
		{
		Transition t = state.Transitionset[ state.Gotoset[i,1] ] ;
		xyzzy = new planet( (int)t.item.rule, t.item.point, t.state, (int)_default ) ;
		goto new_state ;
		}
	if( token.Value.c != 0 )
		throw new System.NotImplementedException( "token != $end" ) ;
	return ;
	}
#endif


static string b_two_c_ ;//;//#(<#>)'['([public|private]:"BIT":...)']'
string binary_compiles_and_linked_p ;//;_FIX:'&'
static int    b_v      ;//view:locution[,view:orbit]

//[static____] /*{::}*/ string                     b_io_path_four ; //{:(_counted):} //blit.prompt.IPVI(.ico)

static string b_list = "" ;

/*
static void Build()
	{
	Xo_t.Build() ;
	}
*/


static int b_muon_css     ;                          //_FIXT:_second,_hexed,<s>tainted</>,'/\_.css'
static char b_custom_map  ;                          //sd['map'] = '.custom "map":.ctor(binary) = (...)'
#region MUONS_b
static string b_xhtml_css ; /*$...trigraphs...$*/    //_FIX:tainted,_second
static string [,] b_xhtml ; /*$...digraphs....$*/    //_FIX:tainted,_css[,_streaming{},_lock_matrix[_SSE4]]
#endregion MUONS_b

//_FIX:can't_type_it(_here),<s>_breaks_kernel</s>,_FIXT:down_on_obvious_[...]_scanner,_said$dart[,_dirty_async_begin]
//_FIXT:BSD,_or_SELINIX_WITH_GAC[,_plan9...][,_[ref:ms]_linq][,Intel_b[l]_][,ARM]
//_FIXT:coLinux,_spliced_MICROSOFT_and_LINUX[_static][,_skew][,_hardened][[_ribbon]]

//_.

//_.console.yield(<t`_x.y>) modem ;
//_.elevation.up(dome)

//_.mono.down
//_.character.mode.ascii.up ;;
//_.character.mode.unicode.up(__) ;
//_.c.down

/*

jo <restricted,dome>{
	Decimal   center ;
	reserved  word ;     //_FIXT:$default,_researched,_said,_etc[,_used] [...remote...]
	//object    remote ;_USED,_null_or_array_splice|split,[_unknown::]
}

jo remote_lock : System.Attribute  //_rep()_is_not_DO_replication,_[quantum]_mechanics
	{
	// nop ;_ms
	}	


jo remote_lock <restricted,domain>{
	//_C,_trivial_unmarshal[,_fastcall[2]]
	}
	
jo var{
	//_do_nothing,_variously_;_unbeeps;_noise_as_signal_as_gc
}

[.class] jo b_atomatrix ;_tut[][]->[,]
//[bo.jo]  'bo:[a]' b_atomatrix_i ;_URN_i(_blurb'{:':}'),_<embed>{_interactive_i}</embed t=i[d]>,_FIX:.class(_injection)(_FIXT:([[[.]post],[[.]get]])[_A335|_BSD])

jo dunce{//$default
	$end.assert(center==$[,elevation.down==true]) ;_symbol_s[,_said]
	}//=>$account[,$[<-]idol][$->idle](javascript:overflows->space_(t|nt),_no_style,_[xhtml|*]wrap[,_dae])

jo synopsis{} ;[_delegate_rt_[default_|_|*]]
	jo`{server:default:dome} ;
*///	jo`{urn:number:atomatrice:atomatrix:_}  //_$D#$

//[.unix] jo b_atomatrix_i ; //_unmanaged,<s>[,_$class(_modifiers)]</s>,_beyond_terminal_default(_if_else_["if"(_tainted)|_BSD])[,_GNU]

#region SCHEMA_b
//delegate b_schema [=...] ;

//_.c.library.remote.down
//_.c.up
/*//_.apu.gpu.override.up   //_replicates_i,_google_play,_!bad[,__.social]
//_.arm.gpu.override.up
//_.console.bypass.         /*$singularity$useless[::]*/

/*********************************************************************\
*`_.academic.grade.down
* _.academic.security.bypass.  /*$standard$disabled[::]*//*
* _.academic.security.static.single.file.up  /*$standard$disabled[::]*//*
* _.academic.grade.gpa.up
* _.academic.grade.down
* _.
\*********************************************************************/

//_FIX:idles,<s>leases</s>,_request(ref_)[respond,]
//_.X[3,11].'ribbon'.up
//.urn:[image]:'X[3,11]':xml.up(:[,.ribbon])
//_.NET.up(__)

#endregion SCHEMA_b	

static void B_end()
	{
	}

//_.{::}     //_FIXT:_.soundex.up(__ipvsix)_idle[,]/\_.,_: new "Geospatial"() ;
//_.elevation.down(dome)

//_.apu.APPiDNA.up              //[auto-ice(:)]_lock{()}((_x.y)),_IPIV|IPVI_X([Q,BIT])  //_up_NOTE: O1 radius.step.out(.wm:default) ;(_NT)

/*
(_.intranet._,urn:atomatrix:atomatrix:__)         //A[^|]B
#region macro
A | [_bio] 'bump'
B | 'f'- "bump"
C ()
#endregion macro
#region micro
<img:BIT.QR> | .NET.BIT (.NET.MASK.BIT)
{::} := /\_.,t`,__,_[{::}]_[,[_]_x.y]                 //_FIX:.soundex,_lexical_eval.down
<BLURB> | archive:
<BLOB>  | archive::
<BLOB>  | archive:MIME-TYPE:
#endregion micro
*/
}

namespace B
	{
	public class BRandomColor : System.Random
		{
		D2 random ;
		D2 color ;
		public D2 Value
			{
			get { return random ; }
			set { random = value ; }
			}
		public new System.Func<D2> Next ;
		};
	}
