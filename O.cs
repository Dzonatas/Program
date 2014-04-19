//|#(!)using System;

public partial class A335
{
static public System.IO.StreamWriter output ;

static private void _0_0_1()
	{
	var    _2 = stack.Pop() ;
	var    _1 = stack.Count > 0 ? stack.Peek() : null ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	if( ! ( _1 is object[] ) )
		{
		stack.Push( new object[] { _0, _2 } ) ;
		return ;
		}
	if( _2 is object[] && ((Xo_t)((object[])_2)[0]).lhs.s == ((Xo_t)(((object[])_1)[0])).rhs[1].s )
		{
		object[] o = (object[])stack.Pop() ;
		System.Array.Resize( ref o, o.Length + 1 ) ;
		o[ o.Length - 1 ] = _2 ;
		stack.Push( o ) ;
		return ;
		}
	if( _2 is Item && xo_t[((Item)_2).state.x][((Item)_2).state.y].s == ((Xo_t)(((object[])_1)[0])).rhs[0].s )
		{
		object[] o = (object[])stack.Pop() ;
		System.Array.Resize( ref o, o.Length + 1 ) ;
		o[ o.Length - 1 ] = _2 ;
		stack.Push( o ) ;
		}
	else
		{
		stack.Push( new object[] { _0, _2 } ) ;
		}
	}
		
static private object[] id_ID()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ; //_VM_traces_null_object[],_need_finvoke()_like_pinvoke()_to_opt_out,_optimize_InvokeMethod
	}

static private object[] name1_id()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, ((object[])_1)[1] } ) ;
	return null ;
	}

static private object[] assemblyRefHead___assembly___extern__name1()
	{
	var   _3 = stack.Pop() ;
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, ((object[])_3)[1] } ) ;
	return null ;
	}

static private object[] int32_INT64()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] asmOrRefDecl___ver__int32_____int32_____int32_____int32()
	{
	var   _5 = stack.Pop() ; stack.Pop() ;
	var   _4 = stack.Pop() ; stack.Pop() ;
	var   _3 = stack.Pop() ; stack.Pop() ;
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, ((object[])_2)[1], ((object[])_3)[1], ((object[])_4)[1], ((object[])_5)[1] } ) ;
	return null ;
	}
	
static private object[] assemblyRefDecl_asmOrRefDecl()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] assemblyRefDecls_assemblyRefDecls_assemblyRefDecl()
	{
	_0_0_1() ;
	return null ;
	}
	
static private object[] decl_assemblyRefHead_____assemblyRefDecls____()
	{
	var    _4 = stack.Pop() ;
	var    _3 = stack.Pop() ;
	var    _2 = stack.Pop() ;
	var    _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, _3 } ) ;
	return null ;
	}

static private object[] decls_decls_decl()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] id_SQSTRING()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] assemblyHead___assembly__asmAttr_name1()
	{
	var   _3 = stack.Pop() ;
	var   _2 = new object[] {} ;
	while( stack.Peek() is object[] )
		{
		System.Array.Resize( ref _2, _2.Length + 1 ) ;
		_2[ _2.Length - 1 ] = stack.Pop() ;
		}
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _2, ((object[])_3)[1] } ) ;
	return null ;
	}

static private object[] assemblyDecl___hash___algorithm__int32()
	{
	var   _3 = stack.Pop() ;
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, ((object[])_3)[1] } ) ;
	return null ;
	}

static private object[] assemblyDecls_assemblyDecls_assemblyDecl()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] assemblyDecl_asmOrRefDecl()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] decl_assemblyHead_____assemblyDecls____()
	{
	var    _4 = stack.Pop() ;
	var    _3 = stack.Pop() ;
	var    _2 = stack.Pop() ;
	var    _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, _3 } ) ;
	return null ;
	}

static private object[] classAttr_classAttr__private_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] classAttr_classAttr__auto_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] classAttr_classAttr__ansi_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] classAttr_classAttr__beforefieldinit_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] name1_DOTTEDNAME()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] slashedName_name1()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, ((object[])_1)[1] } ) ;
	return null ;
	}

static private object[] className_____name1_____slashedName()
	{
	var   _4 = stack.Pop() ;
	var   _3 = stack.Pop() ;
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, ((object[])_2)[1], _3, ((object[])_4)[1] } ) ;
	return null ;
	}

static private object[] extendsClause__extends__className()
	{
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _2 } ) ;
	return null ;
	}

static private object[] classHead___class__classAttr_id_extendsClause_implClause()
	{
	var   _  = stack.Pop() ;
	object   _5 ;
	object   _4 ;
	if( ((Xo_t)(((object[])_)[0])).lhs.s == "implClause" )
		{
		_5 = _ ;
		_4 = stack.Pop() ;
		}
	else
		{
		_5 = null ;
		_4 = _ ;
		}
	var   _3 = stack.Pop() ;
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _2, _3, _4, _5 } ) ;
	return null ;
	}

static private object[] methodHeadPart1___method_()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0 } ) ;
	return null ;
	}

static private object[] methAttr_methAttr__public_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] methAttr_methAttr__hidebysig_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] methAttr_methAttr__specialname_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] methAttr_methAttr__rtspecialname_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] callKind__default_()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0 } ) ;
	return null ;
	}

static private object[] callConv_callKind()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] callConv__instance__callConv()
	{
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, _2 } ) ;
	return null ;
	}

static private object[] type__void_()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0 } ) ;
	return null ;
	}

static private object[] methodName___ctor_()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0 } ) ;
	return null ;
	}

static private object[] implAttr_implAttr__cil_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] implAttr_implAttr__managed_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____()
	{
	var   _B = stack.Pop() ;
	var   _A = stack.Pop() ;
	var   _9 = stack.Pop() ;
	//var   _8 = stack.Pop() ;
	var   _7 = stack.Pop() ;
	var   _6 = stack.Pop() ;
	var   _5 = stack.Pop() ;
	var   _4 = stack.Peek() ;
	if( _4 is object[] && ((Xo_t)(((object[])_4)[0])).lhs.s == "paramAttr" )
		_4 = stack.Pop() ;
	else
		_4 = null ;
	var   _3 = stack.Pop() ;
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, _2, _3, _4, _5, _6, _A } ) ;
	return null ;
	}

static private object[] methodDecl___maxstack__int32()
	{
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _2 } ) ;
	return null ;
	}

static private object[] methodDecls_methodDecls_methodDecl()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] methodDecl_id____()
	{
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] instr_INSTR_NONE()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] methodDecl_instr()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] type__valuetype__className()
	{
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, _2 } ) ;
	return null ;
	}

static private object[] typeSpec_type()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____()
	{
	var   _9 = stack.Pop() ;
	//var   _8 = stack.Pop() ;
	var   _7 = stack.Pop() ;
	var   _6 = stack.Pop() ;
	var   _5 = stack.Pop() ;
	var   _4 = stack.Pop() ;
	var   _3 = stack.Pop() ;
	var   _2 = stack.Pop() ;
	//var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _2, _3, _4, _6 } ) ;
	return null ;
	}

static private object[] classDecl_methodHead_methodDecls____()
	{
	var   _3 = stack.Pop() ;
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, _2 } ) ;
	return null ;
	}

static private object[] classDecls_classDecls_classDecl()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] methAttr_methAttr__static_()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] methodName_name1()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, ((object[])_1)[1] } ) ;
	return null ;
	}

static private object[] methodDecl___entrypoint_()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0 } ) ;
	return null ;
	}

static private object[] compQstring_QSTRING()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] instr_INSTR_STRING_compQstring()
	{
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, _2 } ) ;
	return null ;
	}

static private object[] type__class__className()
	{
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _2 } ) ;
	return null ;
	}

static private object[] type__string_()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0 } ) ;
	return null ;
	}

static private object[] sigArg_paramAttr_type()
	{
	var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, _2 } ) ;
	return null ;
	}

static private object[] sigArgs1_sigArg()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] sigArgs0_sigArgs1()
	{
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1 } ) ;
	return null ;
	}

static private object[] decl_classHead_____classDecls____()
	{
	var   _4 = stack.Pop() ;
	var   _3 = stack.Pop() ;
	//var   _2 = stack.Pop() ;
	var   _1 = stack.Pop() ;
	Xo_t  _0 = xo_t[this_state.reductionset[this_state.default_reduction.Value].rule] ;
	stack.Push( new object[] { _0, _1, _3 } ) ;
	return null ;
	}

static private object[] START_decls()
	{
	return null ;
	}

static private object[] _accept_START__end()
	{
	return null ;
	}

}


namespace org.com.net.edu.mil.us
	{
	//(([zero-copy|copy-paste]-buffer))-to-the-wall.
	}