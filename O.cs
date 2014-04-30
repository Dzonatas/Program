//|#(!)using System;
using System.Text.RegularExpressions ;
using System.Collections.Generic ;

public partial class A335
{
static Dictionary<string,object> virtualset = new Dictionary<string,object>() ;

class Stack
	{
	static System.Collections.Generic.Stack<object> stack = new System.Collections.Generic.Stack<object>() ;
	public class Item
		{
		public Xo_t Rule ;
		public Item()
			{
			Rule = this_xo_t ;
			}
		public class Token : Item
			{
			public xyzzyy  State ;
			public _.Token _Token ;
			public Token( xyzzyy _0, _.Token _1 )
				{
				State = _0 ;
				_Token = _1 ;
				}
			static public explicit operator string( Token t )
				{
				return t._Token._ ;
				}
			public override string ToString()
					{
					return _Token.ToString() ;
					}
			}
		}
	static public void Dump()
		{
		while( stack.Count > 0 )
			{
			object o = stack.Pop() ;
			if( o is object[] )
				foreach( object i in (object[])o )
					log( "[stack.o#] "+ ( i == null ? "null" : i).ToString() ) ;
			else
				log( "[stack] "+o.ToString() ) ;
			log( "[program]\n" + this_program ) ;
			}
		}
	static public void Push( object o )
		{
		stack.Push( o ) ;
		o = null ;
		}
	static private object stack_pop()
		{
		object o = stack.Pop() ;
		string s ;
		if( o is object[] ) 
			{
			s = "{ " ;
			foreach( object i in (object[])o )
				s += ( i == null ? "null" : i ).ToString() + " , ";
			}
		else
			s = o.ToString() ;
		log( "[pop] " + s ) ;
		return o ;
		}
	static public object[] Pop()
		{
		object[] o = new object[ 1 + this_xo_t.rhs.Length ] ;
		for( int i = this_xo_t.rhs.Length ; i > 0 ; i-- )
			{
			var _ = stack.Count > 0 ? stack.Peek() : null ;
			if( _ == null )
				o[i] = null ;
			else
			if( _ is Item.Token )
				{
				Item.Token t = (Item.Token)_ ;
				string rhs = this_xo_t.rhs[i-1].s ;
				if( rhs[0] == '\'' )
					{
					if(	rhs[1] == t._Token._[0] )
						o[i] = stack_pop() ;
					else
						o[i] = null ;
					}
				else
				if( rhs[0] == '"' )
					{
					if( rhs == '"'+t._Token._+'"' )
						o[i] = stack_pop() ;
					else
						o[i] = null ;
					}
				else
				if( rhs[0] == '$' )
					{
					if( rhs == t._Token._ )
						o[i] = stack_pop() ;
					else
						o[i] = null ;
					}
				else
					{
					if( rhs == rhs.ToUpper() )
						o[i] = stack_pop() ;
					else
						o[i] = null ;
					}
				}
			else
			if( _ is object[] )
				{
				object[] _o = (object[]) _ ;
				string lhs = ((Xo_t)(_o[0])).lhs.s ;
				string rhs = this_xo_t.rhs[i-1].s ;
				log( "[Stack.Pop] lhs="+lhs+"   rhs="+rhs ) ;
				if( lhs == rhs )
					o[i] = stack_pop() ;
				else
					o[i] = null ;
				}
			else
				throw new System.NotImplementedException( "Unknown type on stack." ) ;
			}
		o[0] = this_xo_t ;
		return o ;
		}
	}

static private string resolve_type( object _type )
	{
	string s = "" ;
	object[] o = (object[])_type ;
	for( int i = 1 ; i < o.Length ; i++ )
		{
		if( o[i] is Stack.Item.Token )
			{
			string t = (string) (Stack.Item.Token)o[i] ;
			t = Regex.Replace( t, "[^A-Za-z_0-9/]", "_" ).Replace( "/", "$" ) ;
			if( s.EndsWith("$") || t == "$" )
				s += t ;
			else
				s += ( i == 1 ? "" : "_" ) + t ;
			}
		else
		if( o[i] is object[] )
			s += ( ( i == 1 || s.EndsWith("$") || s.EndsWith("__") ) ? "" : "_" ) + resolve_type( o[i] ) ;
		else
			throw new System.NotImplementedException( "Unresolved type." ) ;
		}
	return s ;
	}

static private string resolve_typeSpec( object _typeSpec )
	{
	string s = (string) resolve_type( ((object[])_typeSpec)[1] ) ;
	if( s.StartsWith( "class_" ) )
		s = s.Substring( 6 ) ;
	else
	if( s.StartsWith( "valuetype_" ) )
		s = s.Substring( 10 ) ;
	if( s.StartsWith( "__mscorlib__" ) )
		return "BCL$$" + s.Substring( 12 ) ;
	else
	if( s.StartsWith( "__corlib__" ) )
		return "BCL$$" + s.Substring( 10 ) ;
	switch( s )
		{
		case "object" : return "BCL$$System_Object" ;
		case "string" : return "BCL$$System_String" ;
		}
	return s ;
	}

static private bool resolved_methAttr_contains_virtual( object _methAttr )
	{
	object[] o = (object[])_methAttr ;
	for( int i = 1 ; i < o.Length ; i++ )
		{
		if( o[i] is Stack.Item.Token )
			{
			string t = (string) (Stack.Item.Token)o[i] ;
			if( "virtual" == (string) t )
				return true ;
			}
		else
		if( o[i] is object[] )
			{
			if( resolved_methAttr_contains_virtual( o[i] ) )
				return true ;
			}
		else
		if( ! ( o[i] == null ) )
			throw new System.NotImplementedException( "Unresolved methAttr." ) ;
		}
	return false ;
	}

static private object[] id_ID()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] name1_id()
	{
	object[] o = Stack.Pop() ;
	o[1] = ((object[])o[1])[1] ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] assemblyRefHead___assembly___extern__name1()
	{
	object[] o = Stack.Pop() ;
	o[3] = ((object[])o[3])[1] ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] int32_INT64()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] asmOrRefDecl___ver__int32_____int32_____int32_____int32()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}
	
static private object[] assemblyRefDecl_asmOrRefDecl()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] assemblyRefDecls_assemblyRefDecls_assemblyRefDecl()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}
	
static private object[] decl_assemblyRefHead_____assemblyRefDecls____()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] decls_decls_decl()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] id_SQSTRING()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] assemblyHead___assembly__asmAttr_name1()
	{
	object[] o = Stack.Pop() ;
	Stack.Push( new object[] { this_xo_t, o[2], ((object[])o[3])[1] } ) ;
	return null ;
	}

static private object[] assemblyDecl___hash___algorithm__int32()
	{
	object[] o = Stack.Pop() ;
	o[3] = ((object[])o[3])[1] ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] assemblyDecls_assemblyDecls_assemblyDecl()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] assemblyDecl_asmOrRefDecl()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] decl_assemblyHead_____assemblyDecls____()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] classAttr_classAttr__private_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] classAttr_classAttr__auto_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] classAttr_classAttr__ansi_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] classAttr_classAttr__beforefieldinit_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] name1_DOTTEDNAME()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] slashedName_name1()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] className_____name1_____slashedName()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] extendsClause__extends__className()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] classHead___class__classAttr_id_extendsClause_implClause()
	{
	object[] o = Stack.Pop() ;
	this_class_id = (string) (Stack.Item.Token)((object[])o[3])[1] ;
	this_class_symbol += ( System.String.IsNullOrEmpty( this_class_symbol ) ? "" : "$" ) ;
	this_class_symbol +=  this_class_id ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] methodHeadPart1___method_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methAttr_methAttr__public_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methAttr_methAttr__hidebysig_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methAttr_methAttr__specialname_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methAttr_methAttr__rtspecialname_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] callKind__default_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] callConv_callKind()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] callConv__instance__callConv()
	{
	this_callConv_instance = true ;
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] type__void_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methodName___ctor_()
	{
	object[] o = Stack.Pop() ;
	o[1] = "_ctor" ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] implAttr_implAttr__cil_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] implAttr_implAttr__managed_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____()
	{
	object[] o = Stack.Pop() ;
	if( ((object[])o[6])[1] is string )
		this_method_name = (string) ((object[])o[6])[1] ;
	else
		this_method_name = "$" + (string) (Stack.Item.Token)((object[])o[6])[1] ;
	this_method_type = resolve_type( o[5] ) ;
	this_method_sigArgs = this_sigArgs ;
	this_method_sigArg_types = this_sigArg_types ;
	this_method_callConv_instance = this_callConv_instance ;
	if( resolved_methAttr_contains_virtual( o[2] ) )
		{
		if( ! virtualset.ContainsKey( this_class_symbol ) )
			virtualset.Add( this_class_symbol, new List<string>() ) ;
		((List<string>) virtualset[this_class_symbol]).Add( this_method_name + this_sigArg_types ) ;
		}
	this_sigArgs = 0 ;
	this_sigArg_types = null ;
	this_callConv_instance = false ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] methodDecl___maxstack__int32()
	{
	object[] o = Stack.Pop() ;
	this_maxstack = int.Parse( (string) (Stack.Item.Token)((object[])o[2])[1] ) ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] methodDecls_methodDecls_methodDecl()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methodDecl_id____()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] instr_INSTR_NONE()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methodDecl_instr()
	{
	object[] o = Stack.Pop() ;
	this_instr = (string) (Stack.Item.Token)((object[])o[1])[1] ;
	this_instr = System.Text.RegularExpressions.Regex.Replace( this_instr, "[^A-Za-z_0-9]", "_").ToUpper() ;
	string i = System.Guid.NewGuid().ToString() ;
	i = System.Text.RegularExpressions.Regex.Replace( i, "[^A-Za-z_0-9]", "_").ToLower() ;
	this_instr_list += (System.String.IsNullOrEmpty(this_instr_list) ? "" : "\n")
					 + this_instr + "$" + i ;
	int args = this_method_sigArgs + ( this_method_callConv_instance ? 1 : 0 ) ;
	this_program += "static inline void " + this_instr + "$" + i ;
	if( args == 0 )
		this_program += "( const void** stack )\n        {" ;
	else
		this_program += "( const void** stack , const void** args )\n        {" ;
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
			{
			int iargs = this_instr_sigArgs + ( this_instr_callConv_instance ? 1 : 0 ) ;
			this_stack_offset -= iargs ;
			this_program += "\n        " + this_instr_symbol ;
			if( iargs == 0 )
				this_program += "() ;" ;
			else
				this_program += "(stack+" + this_stack_offset.ToString() + ") ;" ;
			if( this_instr_type != "void" )
				this_stack_offset++ ;
			break ;
			}
		case "RET":
			break ;
		case "NEWOBJ":
			{
			int iargs = this_instr_sigArgs + ( this_instr_callConv_instance ? 1 : 0 ) ;
			this_stack_offset++ ;
			this_stack_offset -= iargs ;
			this_program += "\n        extern void " + this_instr_symbol + "( const void** ) ;" ;
			this_program += "\n        extern struct _object " + this_instr_class_symbol + " ;" ;
			this_program += "\n        static const struct _object obj = { &" + this_instr_class_symbol + " } ;" ;
			this_program += "\n        stack[" + this_stack_offset.ToString() + "] = &obj ;" ;
			this_program += "\n        " + this_instr_symbol ;
			if( iargs == 0 )
				this_program += "() ;" ;
			else
				this_program += "(stack+" + this_stack_offset.ToString() + ") ;" ;
			this_stack_offset++ ;
			break ;
			}
		}
	this_program += "\n        }\n\n" ;
	this_instr_sigArg_types = null ;
	this_instr_sigArgs = 0 ;
	this_instr_callConv_instance = false ;
	log( "[instr] "+ this_instr ) ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] type__valuetype__className()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] typeSpec_type()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____()
	{
	object[] o = Stack.Pop() ;
	if( ((object[])o[6])[1] is string )
		this_methodName = (string) ((object[])o[6])[1] ;
	else
		this_methodName = "$" + (string) (Stack.Item.Token)((object[])o[6])[1] ;
	this_instr_type = resolve_type( o[3] ) ;
	this_instr_class_symbol = resolve_typeSpec( o[4] ) ;
	this_instr_symbol = this_instr_class_symbol + this_methodName + this_sigArg_types ;
	this_instr_sigArgs = this_sigArgs ;
	this_instr_sigArg_types = this_sigArg_types ;
	this_instr_callConv_instance = this_callConv_instance ;
	this_sigArgs = 0 ;
	this_sigArg_types = null ;
	this_callConv_instance = false ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] classDecl_methodHead_methodDecls____()
	{
	object[] o = Stack.Pop() ;
	string p = "" ;
	int args = this_method_sigArgs + ( this_method_callConv_instance ? 1 : 0 ) ;
	p = "void " + this_class_symbol+this_method_name+this_method_sigArg_types ;
	if( args == 0 )
		p += "()" ;
	else
		p += "( const void** args )" ;
	string s = "" ;
	foreach( string ss in this_instr_list.Split('\n') )
		{
		if( ss == "" )
			{
			s += "\n        " ;
			continue ;
			}
		s += "\n        " + ss+"( stack " + ( args == 0 ? ") ;" : ", args ) ;" ) ;
		}
	p += "\n        {"
	   + "\n        const void** stack = alloca( "+this_maxstack.ToString()+" ) ;"
	   + s 
	   + "\n        }" ;
	log( p ) ;
	this_program += p + "\n\n" ;
	this_instr_list = "" ;
	this_stack_offset = 0 ;
	this_method_static = false ;
	this_method_callConv_instance = false ;
	this_method_sigArg_types = null ;
	this_method_sigArgs = 0 ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] classDecls_classDecls_classDecl()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methAttr_methAttr__static_()
	{
	Stack.Push( Stack.Pop() ) ;
	this_method_static = true ;
	return null ;
	}

static private object[] methodName_name1()
	{
	object[] o = Stack.Pop() ;
	o[1] = ((object[])o[1])[1] ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] methodDecl___entrypoint_()
	{
	if( System.String.IsNullOrEmpty(this_class_symbol) )
		throw new System.NotImplementedException( "entrypoint outside class" ) ;
	this_start_class = this_class_symbol ;
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] compQstring_QSTRING()
	{
	object[] o = Stack.Pop() ;
	this_string = (string) (Stack.Item.Token)o[1] ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] instr_INSTR_STRING_compQstring()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] type__class__className()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] type__string_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] sigArg_paramAttr_type()
	{
	object[] o = Stack.Pop() ;
	this_sigArg_types += "$" + resolve_type( o[2] ) ;
	Stack.Push( o ) ;
	return null ;
	}

static private object[] sigArgs1_sigArg()
	{
	this_sigArgs++ ;
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] sigArgs0_sigArgs1()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] decl_classHead_____classDecls____()
	{
	this_class_id = "" ;
	this_class_symbol = "" ;
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] START_decls()
	{
	object[] o = Stack.Pop() ;
	this_program += "int main( int argc , char** args , char** env )\n" +
                    "        {\n" +
                    "        const void** stack = alloca(0) ;\n" +
                    "        " + this_start_class + "$Main() ;\n" +
                    "        }\n\n" ;
    foreach( string class_symbol in virtualset.Keys )
		{
		List<string> l = (List<string>) virtualset[class_symbol] ;
		this_program += "struct _object " + class_symbol + " =\n" +
		                "        {\n" ;
		foreach( string s in l )
			this_program += "        ." + s + " = " + class_symbol + s + " ,\n" ;
		this_program += "        } ;\n\n" ;
		}
	Stack.Push( o ) ;
	return null ;
	}

static private object[] _accept_START__end()
	{
	object[] o = Stack.Pop() ;
	if( o[1] != null && o[2] != null )
		return null ;
	log( "[OOP!] _accept_START__end != {START,.end}" ) ;
	return null ;
	}

static private object[] publicKeyTokenHead___publickeytoken_________()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] hexbytes_HEXBYTE()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] hexbytes_hexbytes_HEXBYTE()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] bytes_hexbytes()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] assemblyRefDecl_publicKeyTokenHead_bytes____()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] customType_callConv_type_typeSpec________ctor______sigArgs0____()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] customHead___custom__customType________()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] customAttrDecl_customHead_bytes____()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] asmOrRefDecl_customAttrDecl()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] moduleHead___module__name1()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] classAttr_classAttr__public_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] type__object_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methAttr_methAttr__private_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] slashedName_slashedName_____name1()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] className_slashedName()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] sigArgs1_sigArgs1_____sigArg()
	{
	this_sigArgs++ ;
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] classAttr_classAttr__nested___private_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] methAttr_methAttr__virtual_()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] classDecl_classHead_____classDecls____()
	{
	string[] s = this_class_symbol.Split( '$' ) ;
	this_class_symbol = System.String.Join( "$", s, 0, s.Length - 1 ) ;
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

static private object[] decl_moduleHead()
	{
	Stack.Push( Stack.Pop() ) ;
	return null ;
	}

}


namespace org.com.net.edu.mil.us
	{
	//(([zero-copy|copy-paste]-buffer))-to-the-wall.
	}