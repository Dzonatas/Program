using System.Diagnostics ;
using System.Extensions ;
using System.Reflection ;
using System.Linq ;
using System ;
//using System.Runtime ;//[br_ide:(('target'![branch:.]))

partial class A335
{
static private void beginning( ref planet b )  //_FIXT:_not_replicative,_8*2=16_effective_nybbles,_4_integers_used,_spase
	{
	State      state = stateset[b.zz] ;
	setstate:
	request( ref state ) ;
	planet     xyzzy ;
	int rule = -1 ;

	Debug.WriteLine( "[State] " + state ) ;
	if( ! token.HasValue )
		{
		token = input( ref Hacked.Materials.H.Line ) ;
		Debug.WriteLine( "[Token] " + token ) ;
		}
	if( state.lookaheadset.Contains( xml_translate[token.Value.c] ) )
		{
		b.yy = xml_translate[token.Value.c] ;
		Debug.WriteLine( "[Lookahead] " + token + " -> " + b.yy ) ;
		goto reduce ;
		}
	if( state.shiftset.ContainsKey( xml_translate[token.Value.c] ) )
		{
		b.yy  = xml_translate[token.Value.c] ;
		Stack.Push( new Stack.Item.Token( b, token.Value ) ) ;
		token = null ;
		Transition t = state.transitionset[ state.shiftset[b.yy] ] ;
		xyzzy = new planet( t.item.rule, t.item.point, t.state, _default ) ;
		Debug.WriteLine( "[Shift] " + t ) ;
		goto new_state ;
		}
	reduce :
	foreach( Reduction rr in state.reductionset )
		if( rr == b.yy )
			{
			if( ! rr.enabled )
				{
				Debug.WriteLine( "[Disabled] " + rr + " ( " + b.yy + " -> " + xo_t[rr.rule] + " ) " ) ;
				continue ;
				}
			Debug.WriteLine( "[Reductionset] " + rr + " ( " + b.yy + " -> " + xo_t[rr.rule] + " ) " ) ;
			b.yy = xo_t[rr.rule] ;
			rule = rr.rule ;
			if( state.gotoset.ContainsKey( b.yy ) )
				goto transit ;
			this_xo_t = xo_t[rr.rule] ;
			goto jump ;
			}
	if( state.default_reduction.HasValue )
		{
		rule = state.reductionset[state.default_reduction.Value].rule ;
		b.yy = xo_t[rule] ;
		}
	transit:
	if( state.gotoset.ContainsKey( b.yy ) )
		{
		Transition t = state.transitionset[ state.gotoset[b.yy] ] ;
		xyzzy = new planet( t.item.rule, t.item.point, t.state, (int)_default ) ;
		Debug.WriteLine( "[Goto] " + t ) ;
		goto new_state ;
		}
	Debug.WriteLine( "[Default] " + b.yy ) ;
	if( b.yy == _default && ! state.default_reduction.HasValue )
		{
		Debug.WriteLine( "[OOP!] Expected default, and this state has no default. Token = " + token ) ;
		throw new System.NotImplementedException( "Missed token?" ) ;
		}
	this_xo_t = xo_t[rule] ;
	jump :
	Debug.WriteLine( "[reduce] " + this_xo_t.ReductionMethod ) ;
	if( this_xo_t.ReductionMethod == "id_ID" )
		{
		Stack.Push( new id_ID() ) ;
		}
	else
	if( this_xo_t.ReductionMethod == "name1_id" )
		{
		Stack.Push( new name1_id() ) ;
		}
	else
	if( this_xo_t.ReductionMethod == "instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____" )
		{
		Stack.Push( new instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____() ) ;
		}
	else
	if( this_xo_t.ReductionMethod == "methodDecl_instr" )
		{
		Stack.Push( new methodDecl_instr() ) ;
		}
	else
	if( this_xo_t.ReductionMethod ==
		"methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName"
		+ "_____sigArgs0_____implAttr____" )
		{
		Stack.Push( new methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____() ) ;
		}
	else
	if( automatrix.ContainsKey(this_xo_t.ReductionMethod) )
		{
		object o = automatrix[this_xo_t.ReductionMethod].InvokeMember( null ,
			            System.Reflection.BindingFlags.CreateInstance  ,
			                                               null , null , null ) ;			                                                    ;
		Stack.Push( (Automatrix) o ) ;
		}
	else
		Debug.WriteLine( "[beginning] Defaulted on "+this_xo_t.ReductionMethod ) ;
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
		b.yy = xo_t[bb.rule] ;
		}
	if( state.gotoset.ContainsKey( b.yy ) )
		{
		Transition t = state.transitionset[ state.gotoset[b.yy] ] ;
		xyzzy = new planet( t.item.rule, t.item.point, t.state, (int)_default ) ;
		goto new_state ;
		}
	if( token.Value.c != 0 )
		throw new System.NotImplementedException( "token != $end" ) ;
	return ;
	}



static string b_two_c_ ;//;//#(<#>)'['([public|private]:"BIT":...)']'
string binary_compiles_and_linked_p ;//;_FIX:'&'
static int    b_v      ;//view:locution[,view:orbit]

//[static____] /*{::}*/ string                     b_io_path_four ; //{:(_counted):} //blit.prompt.IPVI(.ico)

static void Begin()
	{
	var types =
		from  type in Assembly.GetExecutingAssembly().GetTypes()
		from  atrb in Attribute.GetCustomAttributes( type )
		where atrb is AutomatonAttribute
		select type ;
	foreach( Type t in types  )
		{
		automatrix.Add( t.Name , t ) ;
		}
	_.assimulation() ;
	//Console.WriteLine( "symbolset={0} tokenset={1}", xml_symbolset.Count, xml_tokenset.Count ) ;
	/*
	foreach( State s in stateset )
		{
		if( s.itemset.Length == 0 )
			throw new NotImplementedException() ;
		if( s.itemset.Length == 1 )
			y++ ;
		if( s.itemset.Length == 1 && s.reductionset.Length == 0 )
			zz++ ;
		if( s.itemset.Length == 1 && s.transitionset.Length == 0 )
			yy++ ;
		if( s.transitionset.Length == 0 && s.reductionset.Length == 0 )
			throw new NotImplementedException() ;
		if( s.reductionset.Length == 1 && s.reductionset[0] != _default )
			throw new NotImplementedException() ;
		if( s.reductionset.Length >  1 && s.reductionset[0] == _default )
			throw new NotImplementedException() ;
		if( s.transitionset.Length == 1 && s.reductionset.Length == 1 && s.transitionset[0] == s.reductionset[0] )
			throw new NotImplementedException() ;
		if( s.itemset.Length < s.transitionset.Length )
			throw new NotImplementedException() ;
		if( s.itemset.Length > 1 && s.itemset.Length == s.transitionset.Length && s.reductionset.Length != 0 )
			throw new NotImplementedException() ;
		if( s.itemset.Length == s.transitionset.Length && s.reductionset.Length != 0 )
			throw new NotImplementedException() ;
		if( s.itemset.Length + s.reductionset.Length < s.transitionset.Length )
			throw new NotImplementedException() ;
		if( s.transitionset.Length == 0 && s.itemset.Length <= s.reductionset.Length && s.reductionset[s.reductionset.Length-1] != _default )
			throw new NotImplementedException() ;
		if( s.transitionset.Length == 0 && s.reductionset[s.reductionset.Length-1] != _default )
			throw new NotImplementedException() ;
		x++ ;
		}
	if( y != (zz + yy) )
		throw new NotImplementedException() ;
	//Console.WriteLine("x={0} y={1} z={2} yy={3}",x,y,zz,yy ) ;
	*/
	#if SCREEN
	_.screen.DrawCode() ;
	#endif
	this_program = "#include <BCL.HPP>\n\n" ;
	planet b = new planet(0,0,0,(-ʄ)._default(_default)) ;
	beginning( ref b ) ;
	Stack.Dump() ;
	program_ready() ;
	program( this_program ) ;
	program_output.Close() ;
	if( log_output != null )
		{
		log_output.Close() ;
		#if !DEBUG
		throw new System.NotImplementedException( "[/tmp/output.c] Logged" ) ;
		#endif
		}
	//_.prompt(_.string_t) ;
	}

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
