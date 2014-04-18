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
	
	if( ! token.HasValue ) 
		{
		token = input( ref Hacked.Materials.H.Line ) ;
		}
	if( state.lookaheadset.Contains( xml_translate[token.Value.c] ) )
		{
		b.yy = xml_translate[token.Value.c] ;
		goto reduce ;
		}
	if( state.shiftset.ContainsKey( xml_translate[token.Value.c] ) )
		{
		b.yy  = xml_translate[token.Value.c] ;
		//stack.Push( new Item( token.Value, b ) ) ;
		token = null ;
		Transition t = state.transitionset[ state.shiftset[b.yy] ] ;
		state.zlog.Add( t ) ;
		xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, _default ) ;
		goto _jump ;
		}
	reduce :
	foreach( Reduction rr in state.reductionset )
		if( rr == b.yy )
			{
			state.zlog.Add( rr ) ;
			b.yy = xo_t[rr.rule] ;
			if( ! rr.enabled )
				2.Beep() ;
			goto transit ;
			}
	if( state.default_reduction.HasValue )
		b.yy = xo_t[state.reductionset[state.default_reduction.Value].rule] ;
	transit:
	if( state.gotoset.ContainsKey( b.yy ) )
		{
		Transition t = state.transitionset[ state.gotoset[b.yy] ] ;
		state.zlog.Add( t ) ;
		xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, (int)_default ) ;
		goto _jump ;
		}
	default_ : //_select( ʄ )_{(-_reduce:)_backup:_reduce_reduce:_yacc:_...default_}
	int r = state.reductionset[state.default_reduction.Value].rule ;
	object[] o = new object[0] ;
	try {
		string f = xo_t[r].lhs.s ;
		foreach( Xo i in xo_t[r].rhs )
			{
			System.Array.Resize( ref o, o.Length + 1 ) ;
			//o[ o.Length - 1 ] = stack.Pop() ;
			f += "_"+i.s ;
			}
		System.Array.Resize( ref o, o.Length + 1 ) ;
		o[ o.Length - 1 ] = xo_t[r] ;
		System.Array.Reverse( o ) ;
		f = System.Text.RegularExpressions.Regex.Replace( f, "[^A-Za-z_0-9]", "_") ;
		o = (object[])typeof(A335).InvokeMember( f, 
		System.Reflection.BindingFlags.InvokeMethod |
		System.Reflection.BindingFlags.NonPublic |
		System.Reflection.BindingFlags.Static,
		null, null, new object[1] { o } ) ;
		//stack.Push( o ) ;
		}
	catch( System.MissingMemberException e )
		{
		output.WriteLine( e.Message ) ;
		output.Flush() ;
		stack.Push( o ) ;
//		throw new System.NotImplementedException( System.String.Format("[A335] {0}", e.Message) ) ;
		}
	throw new ReducedAcception( r ) ;

	_jump :
	try {
		jump_( ref xyzzy ) ;
		b.yy = xyzzy.yy ; 
		}
	catch ( ReducedAcception bb )
		{
		state.zlog.Add( bb ) ;
		if( --bb.backup > 0 )
			throw bb ;
		b.yy = xo_t[bb.rule] ;
		}
	if( state.gotoset.ContainsKey( b.yy ) )
		{
		Transition t = state.transitionset[ state.gotoset[b.yy] ] ;
		state.zlog.Add( t ) ;
		xyzzy = new xyzzyy( t.item.rule, t.item.point, t.state, (int)_default ) ;
		goto _jump ;
		}
	if( token.Value.c != 0 )
		throw new System.NotImplementedException( "token != $end" ) ;
	return ;
	}
	
static private object[] id_ID( object[] o )
	{
	return o ;
	}

static private object[] name1_id( object[] o )
	{
	return o ;
	}

static private object[] assemblyRefHead___assembly___extern__name1( object[] o )
	{
	return o ;
	}

static private object[] int32_INT64( object[] o )
	{
	return o ;
	}

static private object[] asmOrRefDecl___ver__int32_____int32_____int32_____int32( object[] o )
	{
	return o ;
	}
	

static private object[] assemblyRefDecl_asmOrRefDecl( object[] o )
	{
	return o ;
	}

static private object[] assemblyRefDecls_assemblyRefDecls_assemblyRefDecl( object[] o )
	{
	return o ;
	}
	
static private object[] decl_assemblyRefHead_____assemblyRefDecls____( object[] o ) { return o ; }
static private object[] decls_decls_decl( object[] o ) { return o ; }
static private object[] id_SQSTRING( object[] o ) { return o ; }
static private object[] assemblyHead___assembly__asmAttr_name1( object[] o ) { return o ; }
static private object[] assemblyDecl___hash___algorithm__int32( object[] o ) { return o ; }
static private object[] assemblyDecls_assemblyDecls_assemblyDecl( object[] o ) { return o ; }
static private object[] assemblyDecl_asmOrRefDecl( object[] o ) { return o ; }
static private object[] decl_assemblyHead_____assemblyDecls____( object[] o ) { return o ; }
static private object[] classAttr_classAttr__private_( object[] o ) { return o ; }
static private object[] classAttr_classAttr__auto_( object[] o ) { return o ; }
static private object[] classAttr_classAttr__ansi_( object[] o ) { return o ; }
static private object[] classAttr_classAttr__beforefieldinit_( object[] o ) { return o ; }
static private object[] name1_DOTTEDNAME( object[] o ) { return o ; }
static private object[] slashedName_name1( object[] o ) { return o ; }
static private object[] className_____name1_____slashedName( object[] o ) { return o ; }
static private object[] extendsClause__extends__className( object[] o ) { return o ; }
static private object[] classHead___class__classAttr_id_extendsClause_implClause( object[] o ) { return o ; }
static private object[] methodHeadPart1___method_( object[] o ) { return o ; }
static private object[] methAttr_methAttr__public_( object[] o ) { return o ; }
static private object[] methAttr_methAttr__hidebysig_( object[] o ) { return o ; }
static private object[] methAttr_methAttr__specialname_( object[] o ) { return o ; }
static private object[] methAttr_methAttr__rtspecialname_( object[] o ) { return o ; }
static private object[] callKind__default_( object[] o ) { return o ; }
static private object[] callConv_callKind( object[] o ) { return o ; }
static private object[] callConv__instance__callConv( object[] o ) { return o ; }
static private object[] type__void_( object[] o ) { return o ; }
static private object[] methodName___ctor_( object[] o ) { return o ; }
static private object[] implAttr_implAttr__cil_( object[] o ) { return o ; }
static private object[] implAttr_implAttr__managed_( object[] o ) { return o ; }
static private object[] methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____( object[] o ) { return o ; }
static private object[] methodDecl___maxstack__int32( object[] o ) { return o ; }
static private object[] methodDecls_methodDecls_methodDecl( object[] o ) { return o ; }
static private object[] methodDecl_id____( object[] o ) { return o ; }
static private object[] instr_INSTR_NONE( object[] o ) { return o ; }
static private object[] methodDecl_instr( object[] o ) { return o ; }
static private object[] type__valuetype__className( object[] o ) { return o ; }
static private object[] typeSpec_type( object[] o ) { return o ; }
static private object[] instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____( object[] o ) { return o ; }
static private object[] classDecl_methodHead_methodDecls____( object[] o ) { return o ; }
static private object[] classDecls_classDecls_classDecl( object[] o ) { return o ; }
static private object[] methAttr_methAttr__static_( object[] o ) { return o ; }
static private object[] methodName_name1( object[] o ) { return o ; }
static private object[] methodDecl___entrypoint_( object[] o ) { return o ; }
static private object[] compQstring_QSTRING( object[] o ) { return o ; }
static private object[] instr_INSTR_STRING_compQstring( object[] o ) { return o ; }
static private object[] type__class__className( object[] o ) { return o ; }
static private object[] type__string_( object[] o ) { return o ; }
static private object[] sigArg_paramAttr_type( object[] o ) { return o ; }
static private object[] sigArgs1_sigArg( object[] o ) { return o ; }
static private object[] sigArgs0_sigArgs1( object[] o ) { return o ; }
static private object[] decl_classHead_____classDecls____( object[] o ) { return o ; }
static private object[] START_decls( object[] o ) { return o ; }
static private object[] _accept_START__end( object[] o ) { return o ; }


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


