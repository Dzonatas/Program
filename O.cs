//|#(!)using System;
using System.Text.RegularExpressions ;

public partial class A335
{

static private void _0_0_1()
	{
	var    _2 = stack_pop() ;
	var    _1 = stack.Count > 0 ? stack.Peek() : null ;
	if( ! ( _1 is object[] ) )
		{
		stack.Push( new object[] { this_xo_t, _2 } ) ;
		return ;
		}
	if( _2 is object[] && ((Xo_t)((object[])_2)[0]).lhs.s == ((Xo_t)(((object[])_1)[0])).rhs[1].s )
		{
		object[] o = (object[])stack_pop() ;
		System.Array.Resize( ref o, o.Length + 1 ) ;
		o[ o.Length - 1 ] = _2 ;
		stack.Push( o ) ;
		return ;
		}
	if( _2 is Item && xo_t[((Item)_2).state.x][((Item)_2).state.y].s == ((Xo_t)(((object[])_1)[0])).rhs[0].s )
		{
		object[] o = (object[])stack_pop() ;
		System.Array.Resize( ref o, o.Length + 1 ) ;
		o[ o.Length - 1 ] = _2 ;
		stack.Push( o ) ;
		}
	else
		{
		stack.Push( new object[] { this_xo_t, _2 } ) ;
		}
	}
		
static private object[] id_ID()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] name1_id()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, ((object[])_1)[1] } ) ;
	return null ;
	}

static private object[] assemblyRefHead___assembly___extern__name1()
	{
	var   _3 = stack_pop() ;
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, ((object[])_3)[1] } ) ;
	return null ;
	}

static private object[] int32_INT64()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] asmOrRefDecl___ver__int32_____int32_____int32_____int32()
	{
	var   _5 = stack_pop() ; stack_pop() ;
	var   _4 = stack_pop() ; stack_pop() ;
	var   _3 = stack_pop() ; stack_pop() ;
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, ((object[])_2)[1], ((object[])_3)[1], ((object[])_4)[1], ((object[])_5)[1] } ) ;
	return null ;
	}
	
static private object[] assemblyRefDecl_asmOrRefDecl()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] assemblyRefDecls_assemblyRefDecls_assemblyRefDecl()
	{
	_0_0_1() ;
	return null ;
	}
	
static private object[] decl_assemblyRefHead_____assemblyRefDecls____()
	{
	var    _4 = stack_pop() ;
	var    _3 = stack_pop() ;
	var    _2 = stack_pop() ;
	var    _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1, _3 } ) ;
	return null ;
	}

static private object[] decls_decls_decl()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] id_SQSTRING()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] assemblyHead___assembly__asmAttr_name1()
	{
	var   _3 = stack_pop() ;
	var   _2 = new object[] {} ;
	while( stack.Peek() is object[] )
		{
		System.Array.Resize( ref _2, _2.Length + 1 ) ;
		_2[ _2.Length - 1 ] = stack_pop() ;
		}
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _2, ((object[])_3)[1] } ) ;
	return null ;
	}

static private object[] assemblyDecl___hash___algorithm__int32()
	{
	var   _3 = stack_pop() ;
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, ((object[])_3)[1] } ) ;
	return null ;
	}

static private object[] assemblyDecls_assemblyDecls_assemblyDecl()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] assemblyDecl_asmOrRefDecl()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] decl_assemblyHead_____assemblyDecls____()
	{
	var    _4 = stack_pop() ;
	var    _3 = stack_pop() ;
	var    _2 = stack_pop() ;
	var    _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1, _3 } ) ;
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
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] slashedName_name1()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, ((object[])_1)[1] } ) ;
	return null ;
	}

static private object[] className_____name1_____slashedName()
	{
	var   _4 = stack_pop() ;
	var   _3 = stack_pop() ;
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	this_className  = Regex.Replace( ((Item)((object[])_2)[1]).token._, "[^A-Za-z_0-9]", "_") ;
	this_className += "$$" ;
	this_className += Regex.Replace( ((Item)((object[])_4)[1]).token._, "[^A-Za-z_0-9]", "_") ;
	stack.Push( new object[] { this_xo_t, _1, ((object[])_2)[1], _3, ((object[])_4)[1] } ) ;
	return null ;
	}

static private object[] extendsClause__extends__className()
	{
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _2 } ) ;
	return null ;
	}

static private object[] classHead___class__classAttr_id_extendsClause_implClause()
	{
	var   _5 = stack.Peek() ;
	if( ((Xo_t)(((object[])_5)[0])).lhs.s == this_xo_t.rhs[4].s )
		_5 = stack_pop() ;
	else
		_5 = null ;
	var   _4 = stack_pop() ;
	var   _3 = stack_pop() ;
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	this_class_id = ( (Item)((object[])_3)[1] ).token._ ;
	stack.Push( new object[] { this_xo_t, _2, _3, _4, _5 } ) ;
	return null ;
	}

static private object[] methodHeadPart1___method_()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t } ) ;
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
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t } ) ;
	return null ;
	}

static private object[] callConv_callKind()
	{
	var   _1 = stack.Peek() ;
	if( _1 is object[] && ((Xo_t)((object[])_1)[0]).lhs.s == this_xo_t.rhs[0].s )
		_1 = stack_pop() ;
	else
		_1 = null ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] callConv__instance__callConv()
	{
	var   _2 = stack_pop() ;
	var   _1 = stack.Peek() ;
	if( _1 is Item && '"'+((Item)_1).token._+'"' == this_xo_t.rhs[0].s )
		_1 = stack_pop() ;
	else
		_1 = null ;
	this_callConv_instance = true ;
	stack.Push( new object[] { this_xo_t, _1, _2 } ) ;
	return null ;
	}

static private object[] type__void_()
	{
	var   _1 = stack_pop() ;
	this_method_type = "void" ;
	this_type_void = true ;
	stack.Push( new object[] { this_xo_t } ) ;
	return null ;
	}

static private object[] methodName___ctor_()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, "_ctor" } ) ;
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
	var   _B = stack_pop() ;
	var   _A = stack_pop() ;
	var   _9 = stack_pop() ;
	//var   _8 = stack_pop() ;
	var   _7 = stack_pop() ;
	var   _6 = stack_pop() ;
	var   _5 = stack_pop() ;
	var   _4 = stack.Peek() ;
	if( _4 is object[] && ((Xo_t)(((object[])_4)[0])).lhs.s == this_xo_t.rhs[3].s )
		_4 = stack_pop() ;
	else
		_4 = null ;
	var   _3 = stack_pop() ;
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	if( ((object[])_6)[1] is string )
		this_method_name = (string) ((object[])_6)[1] ;
	else
		this_method_name = "$" + ( (Item)((object[])_6)[1] ).token._ ;
	if( this_method_name == "$Main" )
		this_start_class = this_class_id ;
	stack.Push( new object[] { this_xo_t, _1, _2, _3, _4, _5, _6, _A } ) ;
	return null ;
	}

static private object[] methodDecl___maxstack__int32()
	{
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _2 } ) ;
	return null ;
	}

static private object[] methodDecls_methodDecls_methodDecl()
	{
	_0_0_1() ;
	return null ;
	}

static private object[] methodDecl_id____()
	{
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] instr_INSTR_NONE()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] methodDecl_instr()
	{
	var   _1 = stack_pop() ;
	this_instr = ( (Item)((object[])_1)[1] ).token._ ;
	this_instr = System.Text.RegularExpressions.Regex.Replace( this_instr, "[^A-Za-z_0-9]", "_").ToUpper() ;
	string i = System.Guid.NewGuid().ToString() ;
	i = System.Text.RegularExpressions.Regex.Replace( i, "[^A-Za-z_0-9]", "_").ToLower() ;
	this_instr_list += (System.String.IsNullOrEmpty(this_instr_list) ? "" : "\n")
					 + this_instr + "$" + i ;
	this_program += "static inline void " + this_instr + "$" + i + "( const void** stack , const void** args )\n        {" ;
	switch( this_instr )
		{
		case "LDARG_0":
			this_program += "\n        stack[" + this_stack_offset.ToString() + "] = args[0] ;" ;
			this_stack_offset++ ;
			break ;
		case "LDSTR":
			this_program += "\n        static const struct _string s = { "
				+ this_string.Length.ToString()
				+ " , \"" + this_string + "\" } ;" ;
			this_program += "\n        stack[" + this_stack_offset.ToString() + "] = &s ;" ;
			this_stack_offset++ ;
			break ;
		case "CALL":
			string name = "" ;
			name += this_className + this_methodName ;
			int args = this_sigArgs + ( this_callConv_instance ? 1 : 0 ) ;
			this_stack_offset -= args ;
			if( args == 0 )
				this_program += "\n        " + name + "() ;" ;
			else
				this_program += "\n        " + name + "(stack+" + this_stack_offset.ToString() + ") ;" ;
			if( !this_type_void )
				this_stack_offset++ ;
			break ;
		case "RET":
			break ;
		}
	this_callConv_instance = false ;
	this_sigArgs = 0 ;
	this_type_void = false ;
	this_program += "\n        }\n\n" ;
	log( "[instr] "+ this_instr ) ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] type__valuetype__className()
	{
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1, _2 } ) ;
	return null ;
	}

static private object[] typeSpec_type()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____()
	{
	var   _9 = stack_pop() ;
	//var   _8 = stack_pop() ;
	var   _7 = stack_pop() ;
	var   _6 = stack_pop() ;
	var   _5 = stack_pop() ;
	var   _4 = stack_pop() ;
	var   _3 = stack_pop() ;
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	if( ((object[])_6)[1] is string )
		this_methodName = (string) ((object[])_6)[1] ;
	else
		this_methodName = "$" + ( (Item)((object[])_6)[1] ).token._ ;
	stack.Push( new object[] { this_xo_t, _1, _2, _3, _4, _6 } ) ;
	return null ;
	}

static private object[] classDecl_methodHead_methodDecls____()
	{
	var   _3 = stack_pop() ;
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	string p = "" ;
	p = "static inline void " + this_class_id+this_method_name + "(const void** args)" ;
	string s = "" ;
	foreach( string ss in this_instr_list.Split('\n') )
		{
		if( ss == "" )
			{
			s += "\n        " ;
			continue ;
			}
		s += "\n        " + ss+"( stack , args ) ;" ;
		}
	p += "\n        {"
	   + "\n        const void** stack = alloca(1) ;"
	   + s 
	   + "\n        }" ;
	log( p ) ;
	this_program += p + "\n\n" ;
	this_instr_list = "" ;
	this_stack_offset = 0 ;
	this_sigArgs = 0 ;
	this_type_void = false ;
	this_method_static = false ;
	this_callConv_instance = false ;
	stack.Push( new object[] { this_xo_t, _1, _2 } ) ;
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
	this_method_static = true ;
	return null ;
	}

static private object[] methodName_name1()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, ((object[])_1)[1] } ) ;
	return null ;
	}

static private object[] methodDecl___entrypoint_()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t } ) ;
	return null ;
	}

static private object[] compQstring_QSTRING()
	{
	var   _1 = stack_pop() ;
	this_string = ((Item)_1).token._ ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] instr_INSTR_STRING_compQstring()
	{
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1, _2 } ) ;
	return null ;
	}

static private object[] type__class__className()
	{
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _2 } ) ;
	return null ;
	}

static private object[] type__string_()
	{
	var   _1 = stack_pop() ;
	this_method_type = "string" ;
	stack.Push( new object[] { this_xo_t } ) ;
	return null ;
	}

static private object[] sigArg_paramAttr_type()
	{
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1, _2 } ) ;
	return null ;
	}

static private object[] sigArgs1_sigArg()
	{
	var   _1 = stack_pop() ;
	this_sigArgs++ ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] sigArgs0_sigArgs1()
	{
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1 } ) ;
	return null ;
	}

static private object[] decl_classHead_____classDecls____()
	{
	var   _4 = stack_pop() ;
	var   _3 = stack_pop() ;
	var   _2 = stack_pop() ;
	var   _1 = stack_pop() ;
	stack.Push( new object[] { this_xo_t, _1, _3 } ) ;
	return null ;
	}

static private object[] START_decls()
	{
	this_program += "int main( int argc , char** args , char** env )\n" +
                    "        {\n" +
                    "        const void** stack = alloca(0) ;\n" +
                    "        " + this_start_class + "_ctor(stack) ;\n" +
                    "        " + this_start_class + "$Main(stack) ;\n" +
                    "        }\n\n" ;
	return null ;
	}

static private object[] _accept_START__end()
	{
	var _end = stack_pop() ;
	if( _end is Item && ((Item)_end).token.c == 0 )
		return null ;
	log( "[OOP!] _accept_START__end != end" ) ;
	return null ;
	}

}


namespace org.com.net.edu.mil.us
	{
	//(([zero-copy|copy-paste]-buffer))-to-the-wall.
	}