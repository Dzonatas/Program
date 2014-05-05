//|#(!)using System;
using System.Text.RegularExpressions ;
using System.Collections.Generic ;
using System.Diagnostics ;

public partial class A335
{
static Dictionary<string,object> virtualset = new Dictionary<string,object>() ;
static List<object> freeset = new List<object>() ;

class Object : Stack.Item
	{
	protected object[] o ;
	public Object( object[] _ ) : base()
		{
		Debug.WriteLine( "<A Object " + GetType().Name + " />"  ) ;
		o = _ ;
		}
	public Object( int n ) : base()
		{
		Debug.WriteLine( "<A Object " + GetType().Name + ">"  ) ;
		o = new object[n+1] ;
		Stack.Pop( ref o ) ;
		o[0] = this ;
		Debug.WriteLine( "</A>"  ) ;
		}
	public Stack.Item this[int n]
		{
		get { return (Stack.Item) o[n] ; }
		set { o[n] = value ; }
		}
	}

class Argument
	{
	object arg ;
	public Argument( ref object o )
		{
		Debug.WriteLine( "<A Arg/> " + o.ToString() ) ;
		arg = o ;
		}
	public object this[int n]
		{
		get {
			if( arg is object[] )
				return ((object[])arg)[n] ;
			if( arg is Object )
				return ((Object)arg)[n] ;
			if( arg is Stack.Item.Token )
				return ((Object)arg)[n] ;
			return null ;
			}
		}
	public object[] Args		{ get { return arg as object[] ; } }
	public string Token
		{
		get {
			if( arg is Stack.Item.Token )
				return (arg as Stack.Item.Token)._Token._ ;
			if( arg is Automatrix )
				{
				Automatrix a = arg as Automatrix ;
				for( int i = 1 ; i < a.Length ; i++ )
					{
					if( a.Args[i] is Stack.Item.Token )
						return (a.Args[i] as Stack.Item.Token)._Token._ ;
					if( a.Args[i] is Automatrix )
						return new Argument( ref a.Args[i] ).Token ;
					}
				}
			throw new System.NotImplementedException( "Unresolved casts to dotted names." ) ;
			}
		}
	public string ResolveType()
		{
		string s = "" ;
		if( arg is Stack.Item.Token )
			{
			string t = (string) (Stack.Item.Token)arg ;
			t = Regex.Replace( t, "[^A-Za-z_0-9/]", "_" ).Replace( "/", "$" ) ;
			return t ;
			}
		if( arg is Automatrix )
			{
			return (arg as Automatrix).ResolveType() ;
			}
		for( int i = 1 ; i < Args.Length ; i++ )
			{
			if( Args[i] is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token)Args[i] ;
				t = Regex.Replace( t, "[^A-Za-z_0-9/]", "_" ).Replace( "/", "$" ) ;
				if( s.EndsWith("$") || t == "$" )
					s += t ;
				else
					s += ( i == 1 ? "" : "_" ) + t ;
				}
			else
			if( Args[i] is Automatrix )
				s += ( ( i == 1 || s.EndsWith("$") || s.EndsWith("__") ) ? "" : "_" )
					+ ( Args[i] as Automatrix ).ResolveType() ;
			else
				throw new System.NotImplementedException( "Unresolved type." ) ;
			}
		return s ;
		}
	public string ResolveTypeSpec()
		{
		string s = (string) ResolveType() ;
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
	public bool ResolvedMethAttrContainsVirtual
		{
		get {
			if( arg is methAttr_methAttr__virtual_ )
				return true ;
			if( arg is Automatrix )
				return ( arg as Automatrix ).ResolvedMethAttrContainsVirtual ;
			if( arg is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token) arg ;
				if( "virtual" == (string) t )
					return true ;
				return false ;
				}
			if( arg is Stack.Item.Empty )
				return false ;
			throw new System.NotImplementedException( "Unresolved methAttr." ) ;
			}
		}
	}

class Automatrix : Object
	{
	public Automatrix() : base( this_xo_t.rhs.Length ) 
		{
		Debug.WriteLine( "<A Automatrix " + GetType().Name + "/>"  ) ;
		main() ;
		Debug.WriteLine( "</A>" ) ;
		}
	public new Argument this[int n]
		{
		get { Debug.WriteLine( GetType().Name + '[' + n + ']'  ) ; return new Argument( ref o[n] ) ; }
		set { o[n] = value ; }
		}
	virtual protected void main() {}
	public Argument Arg0		{ get { return new Argument( ref o[0x00] ) ; } }
	public Argument Arg1		{ get { return new Argument( ref o[0x01] ) ; } }
	public Argument Arg2		{ get { return new Argument( ref o[0x02] ) ; } }
	public Argument Arg3		{ get { return new Argument( ref o[0x03] ) ; } }
	public Argument Arg4		{ get { return new Argument( ref o[0x04] ) ; } }
	public Argument Arg5		{ get { return new Argument( ref o[0x05] ) ; } }
	public Argument Arg6		{ get { return new Argument( ref o[0x06] ) ; } }
	public Argument Arg7		{ get { return new Argument( ref o[0x07] ) ; } }
	public Argument Arg8		{ get { return new Argument( ref o[0x08] ) ; } }
	public Argument Arg9		{ get { return new Argument( ref o[0x09] ) ; } }
	public Argument ArgA		{ get { return new Argument( ref o[0x0A] ) ; } }
	public Argument ArgB		{ get { return new Argument( ref o[0x0B] ) ; } }
	public Argument ArgC		{ get { return new Argument( ref o[0x0C] ) ; } }
	public Argument ArgD		{ get { return new Argument( ref o[0x0D] ) ; } }
	public Argument ArgE		{ get { return new Argument( ref o[0x0E] ) ; } }
	public Argument ArgF		{ get { return new Argument( ref o[0x0F] ) ; } }
	public object[] Args		{ get { return o ; } }
	public int Length
		{
		get { return o.Length ; }
		}
	public string ResolveType()
		{
		string s = "" ;
		for( int i = 1 ; i < Args.Length ; i++ )
			{
			if( Args[i] is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token)Args[i] ;
				t = Regex.Replace( t, "[^A-Za-z_0-9/]", "_" ).Replace( "/", "$" ) ;
				if( s.EndsWith("$") || t == "$" )
					s += t ;
				else
					s += ( i == 1 ? "" : "_" ) + t ;
				}
			else
			if( Args[i] is Automatrix )
				s += ( ( i == 1 || s.EndsWith("$") || s.EndsWith("__") ) ? "" : "_" )
					+ ((Automatrix)Args[i] ).ResolveType() ;
			else
				throw new System.NotImplementedException( "Unresolved type." ) ;
			}
		return s ;
		}
	public bool ResolvedMethAttrContainsVirtual
		{
		get {
			for( int i = 1 ; i < Args.Length ; i++ )
				{
				if( Args[i] is methAttr_methAttr__virtual_ )
					return true ;
				if( Args[i] is Automatrix )
					{
					if( ( Args[i] as Automatrix ).ResolvedMethAttrContainsVirtual )
						return true ;
					continue ;
					}
				if( Args[i] is Stack.Item.Token )
					{
					string t = (string) (Stack.Item.Token)Args[i] ;
					if( "virtual" == (string) t )
						return true ;
					continue ;
					}
				if( ( Args[i] is Stack.Item.Empty ) )
					continue ;
				throw new System.NotImplementedException( "Unresolved methAttr." ) ;
				}
			return false ;
			}
		}
	public override string ToString()
		{
		return string.Format("[Automatrix] " + Rule.ReductionMethod );
		}
	}

[Automaton] class   id_ID
	: Automatrix	{
	protected override void main()
		{
		Debug.WriteLine( "[DEBUG:id_ID] " + Arg1.Token ) ;
		}
	}


[Automaton] class   name1_id
	: Automatrix {}

[Automaton] class   assemblyRefHead___assembly___extern__name1
	: Automatrix {}

[Automaton] class   int32_INT64
	: Automatrix {}

[Automaton] class   asmOrRefDecl___ver__int32_____int32_____int32_____int32
	: Automatrix {}
	
[Automaton] class   assemblyRefDecl_asmOrRefDecl
	: Automatrix {}

[Automaton] class   assemblyRefDecls_assemblyRefDecls_assemblyRefDecl
	: Automatrix {}
	
[Automaton] class   decl_assemblyRefHead_____assemblyRefDecls____
	: Automatrix {}

[Automaton] class   decls_decls_decl
	: Automatrix {}

[Automaton] class   id_SQSTRING
	: Automatrix {}

[Automaton] class   assemblyHead___assembly__asmAttr_name1
	: Automatrix {}

[Automaton] class   assemblyDecl___hash___algorithm__int32
	: Automatrix {}

[Automaton] class   assemblyDecls_assemblyDecls_assemblyDecl
	: Automatrix {}

[Automaton] class   assemblyDecl_asmOrRefDecl
	: Automatrix {}

[Automaton] class   decl_assemblyHead_____assemblyDecls____
	: Automatrix {}

[Automaton] class   classAttr_classAttr__private_
	: Automatrix {}

[Automaton] class   classAttr_classAttr__auto_
	: Automatrix {}

[Automaton] class   classAttr_classAttr__ansi_
	: Automatrix {}

[Automaton] class   classAttr_classAttr__beforefieldinit_
	: Automatrix {}

[Automaton] class   fieldAttr_fieldAttr__private_
	: Automatrix {}

[Automaton] class   fieldAttr_fieldAttr__static_
	: Automatrix {}

[Automaton] class   name1_DOTTEDNAME
	: Automatrix {}

[Automaton] class   slashedName_name1
	: Automatrix {}

[Automaton] class   className_____name1_____slashedName
	: Automatrix {}

[Automaton] class   extendsClause__extends__className
	: Automatrix {}

[Automaton] class   classHead___class__classAttr_id_extendsClause_implClause
	: Automatrix	{
	protected override void main()
		{
		this_class_id = Arg3.Token ;
		this_class_symbol += ( System.String.IsNullOrEmpty( this_class_symbol ) ? "" : "$" ) ;
		this_class_symbol +=  this_class_id ;
		}
	}

[Automaton] class   methodHeadPart1___method_
	: Automatrix {}

[Automaton] class   methAttr_methAttr__public_
	: Automatrix {}

[Automaton] class   methAttr_methAttr__hidebysig_
	: Automatrix {}

[Automaton] class   methAttr_methAttr__specialname_
	: Automatrix {}

[Automaton] class   methAttr_methAttr__rtspecialname_
	: Automatrix {}

[Automaton] class   callKind__default_
	: Automatrix {}

[Automaton] class   callConv_callKind
	: Automatrix {}

[Automaton] class   callConv__instance__callConv
	: Automatrix	{
	protected override void main()
		{
		this_callConv_instance = true ;
		}
	}

[Automaton] class   type__void_
	: Automatrix {}

[Automaton] class   methodName___ctor_
	: Automatrix {}

[Automaton] class   methodName___cctor_
	: Automatrix {}

[Automaton] class   implAttr_implAttr__cil_
	: Automatrix {}

[Automaton] class   implAttr_implAttr__managed_
	: Automatrix {}

[Automaton] class   methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____
	: Automatrix	{
	protected override void main()
		{
		if( Args[6] is methodName___ctor_ )
			this_method_name = "_ctor" ;
		else
			this_method_name = "$" + Arg6.Token ;
		this_method_type = Arg5.ResolveType() ;
		this_method_sigArgs = this_sigArgs ;
		this_method_sigArg_types = this_sigArg_types ;
		this_method_callConv_instance = this_callConv_instance ;
		this_method_virtual = Arg2.ResolvedMethAttrContainsVirtual ;
		if( this_method_virtual )
			{
			if( ! virtualset.ContainsKey( this_class_symbol ) )
				virtualset.Add( this_class_symbol, new List<string>() ) ;
			((List<string>) virtualset[this_class_symbol]).Add( this_method_name + this_sigArg_types ) ;
			}
		this_sigArgs = 0 ;
		this_sigArg_types = null ;
		this_callConv_instance = false ;
		}
	}

[Automaton] class   methodDecl___maxstack__int32
	: Automatrix	{
	protected override void main()
		{
		this_maxstack = int.Parse( Arg2.Token ) ;
		this_stack = new string[this_maxstack] ;
		}
	}

[Automaton] class   methodDecls_methodDecls_methodDecl
	: Automatrix {}

[Automaton] class   methodDecl_id____
	: Automatrix {}

[Automaton] class   instr_INSTR_NONE
	: Automatrix {}

[Automaton] class   methodDecl_instr
	: Automatrix	{
	protected override void main()
		{
		this_instr = Arg1.Token ;
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
				this_stack[this_stack_offset] = "object" ;
				this_stack_offset++ ;
				break ;
			case "LDSTR":
				this_program += "\n        static const struct _string s = { "
					+ this_string.Length.ToString()
					+ " , \"" + this_string + "\" } ;" ;
				this_program += "\n        stack[" + this_stack_offset.ToString() + "] = &s ;" ;
				this_stack[this_stack_offset] = "string" ;
				this_stack_offset++ ;
				break ;
			case "CALL":
				{
				int iargs = this_instr_sigArgs + ( this_instr_callConv_instance ? 1 : 0 ) ;
				this_stack_offset -= iargs ;
				/*
				if( !System.String.IsNullOrEmpty(this_instr_sigArg_types) )
					{
					string[] s = this_instr_sigArg_types.Split( '$' ) ;
					for( int a = ( this_instr_callConv_instance ? 2 : 1 ) ; a < iargs ; a++ )
						{
						int offset = this_stack_offset+a-1+( this_instr_callConv_instance ? 1 : 0 ) ;
						if( s[a] != this_stack[offset] )
							{
							this_program += "\n        static struct _object obj = { 0 } ;" ;
							this_program += "\n        obj.this = (void*) stack["+offset+"] ;" ;
							this_program += "\n        stack[" + offset + "] =  &obj;" ;
							}
						}
					}
				*/
				this_program += "\n        " ;
				if( this_instr_type == "string" )
					{
					this_program += "static struct _string item" + this_stack_offset.ToString() + " ;"
						+ "\n        item" + this_stack_offset.ToString() + " = " ;
					freeset.Add( this_stack_offset ) ;
					}
				this_program += this_instr_symbol ;
				if( iargs == 0 )
					this_program += "() ;" ;
				else
					this_program += "(stack+" + this_stack_offset.ToString() + ") ;" ;
				if( this_instr_type == "string" )
					this_program += "\n        stack[" + this_stack_offset.ToString() + "] = "
						+ "&item" + this_stack_offset.ToString() + " ;" ;
				if( this_instr_type != "void" )
					{
					this_stack[this_stack_offset] = this_instr_type ;
					this_stack_offset++ ;
					}
				break ;
				}
			case "RET":
				{
				foreach( object z in freeset )
					{
					if( z is int )
						this_program += "\n        free( ((struct _string *)stack[" + z + "])->string ) ;" ;
					}
				freeset.Clear() ;
				break ;
				}
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
				this_stack[this_stack_offset] = "object" ;
				this_stack_offset++ ;
				break ;
				}
			}
		this_program += "\n        }\n\n" ;
		this_instr_sigArg_types = null ;
		this_instr_sigArgs = 0 ;
		this_instr_callConv_instance = false ;
		log( "[instr] "+ this_instr ) ;
		}
	}

[Automaton] class   type__valuetype__className
	: Automatrix {}

[Automaton] class   typeSpec_type
	: Automatrix {}

[Automaton] class   instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____
	: Automatrix	{
	protected override void main()
		{
		if( Args[6] is methodName___ctor_ )
			this_methodName = "_ctor" ;
		else
			this_methodName = "$" + Arg6.Token ;
		this_instr_type = Arg3.ResolveType() ;
		this_instr_class_symbol = Arg4.ResolveTypeSpec() ;
		this_instr_symbol = this_instr_class_symbol + this_methodName + this_sigArg_types ;
		this_instr_sigArgs = this_sigArgs ;
		this_instr_sigArg_types = this_sigArg_types ;
		this_instr_callConv_instance = this_callConv_instance ;
		this_sigArgs = 0 ;
		this_sigArg_types = null ;
		this_callConv_instance = false ;
		}
	}

[Automaton] class   classDecl_methodHead_methodDecls____
	: Automatrix	{
	protected override void main()
		{
		string p = "" ;
		int args = this_method_sigArgs + ( this_method_callConv_instance ? 1 : 0 ) ;
		if( this_method_virtual )
			p = "struct _string " ;
		else
			p = "void " ;
		p += this_class_symbol+this_method_name+this_method_sigArg_types ;
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
		if( this_method_virtual )
			s += "\n        return *(struct _string *)*stack ;" ;
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
		}
	}

[Automaton] class   classDecls_classDecls_classDecl
	: Automatrix {}

[Automaton] class   methAttr_methAttr__static_
	: Automatrix	{
	protected override void main()
		{
		this_method_static = true ;
		}
	}

[Automaton] class   methodName_name1
	: Automatrix {}

[Automaton] class   methodDecl___entrypoint_
	: Automatrix	{
	protected override void main()
		{
		if( System.String.IsNullOrEmpty(this_class_symbol) )
			throw new System.NotImplementedException( "entrypoint outside class" ) ;
		this_start_class = this_class_symbol ;
		}
	}

[Automaton] class   compQstring_QSTRING
	: Automatrix	{
	protected override void main()
		{
		this_string = Arg1.Token ;
		}
	}

[Automaton] class   instr_INSTR_STRING_compQstring
	: Automatrix {}

[Automaton] class   type__class__className
	: Automatrix {}

[Automaton] class   type__string_
	: Automatrix {}

[Automaton] class   sigArg_paramAttr_type
	: Automatrix	{
	protected override void main()
		{
		this_sigArg_types += "$" + Arg2.ResolveType() ;
		}
	}

[Automaton] class   sigArgs1_sigArg
	: Automatrix	{
	protected override void main()
		{
		this_sigArgs++ ;
		}
	}

[Automaton] class   sigArgs0_sigArgs1
	: Automatrix {}

[Automaton] class   decl_classHead_____classDecls____
	: Automatrix	{
	protected override void main()
		{
		this_class_id = "" ;
		this_class_symbol = "" ;
		}
	}

[Automaton] class   START_decls
	: Automatrix	{
	protected override void main()
		{
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
		}
	}

[Automaton] class   _accept_START__end
	: Automatrix	{
	protected override void main()
		{
		if( o[1] != null && o[2] != null )
			return ;
		log( "[OOP!] _accept_START__end != {START,.end}" ) ;
		}
	}

[Automaton] class   publicKeyTokenHead___publickeytoken_________
	: Automatrix {}

[Automaton] class   hexbytes_HEXBYTE
	: Automatrix {}

[Automaton] class   hexbytes_hexbytes_HEXBYTE
	: Automatrix {}

[Automaton] class   bytes_hexbytes
	: Automatrix {}

[Automaton] class   assemblyRefDecl_publicKeyTokenHead_bytes____
	: Automatrix {}

[Automaton] class   customType_callConv_type_typeSpec________ctor______sigArgs0____
	: Automatrix {}

[Automaton] class   customHead___custom__customType________
	: Automatrix {}

[Automaton] class   customAttrDecl_customHead_bytes____
	: Automatrix {}

[Automaton] class   asmOrRefDecl_customAttrDecl
	: Automatrix {}

[Automaton] class   moduleHead___module__name1
	: Automatrix {}

[Automaton] class   classAttr_classAttr__public_
	: Automatrix {}

[Automaton] class   type__object_
	: Automatrix {}

[Automaton] class   methAttr_methAttr__private_
	: Automatrix {}

[Automaton] class   slashedName_slashedName_____name1
	: Automatrix {}

[Automaton] class   className_slashedName
	: Automatrix {}

[Automaton] class   sigArgs1_sigArgs1_____sigArg
	: Automatrix	{
	protected override void main()
		{
		this_sigArgs++ ;
		}
	}

[Automaton] class   classAttr_classAttr__nested___private_
	: Automatrix {}

[Automaton] class   methAttr_methAttr__virtual_
	: Automatrix {}

[Automaton] class   classDecl_classHead_____classDecls____
	: Automatrix	{
	protected override void main()
		{
		string[] s = this_class_symbol.Split( '$' ) ;
		this_class_symbol = System.String.Join( "$", s, 0, s.Length - 1 ) ;
		}
	}

[Automaton] class   decl_moduleHead
	: Automatrix {}

[Automaton] class   bounds1_bound
	: Automatrix {}

[Automaton] class   type_type_____bounds1____
	: Automatrix {}

[Automaton] class   fieldDecl___field__repeatOpt_fieldAttr_type_id_atOpt_initOpt
	: Automatrix {}

[Automaton] class   classDecl_fieldDecl
	: Automatrix {}

[Automaton] class   typeSpec_className
	: Automatrix {}

[Automaton] class   instr_INSTR_TYPE_typeSpec
	: Automatrix {}

[Automaton] class   instr_INSTR_FIELD_type_id
	: Automatrix {}

[Automaton] class   decls
	: Automatrix {}

[Automaton] class   instr_INSTR_FIELD_type_typeSpec______id
	: Automatrix {}

[Automaton] class   localsHead___locals_
	: Automatrix {}

[Automaton] class   type__int32_
	: Automatrix {}

[Automaton] class   sigArg_paramAttr_type_id
	: Automatrix {
	protected override void main()
		{
		this_sigArg_types += "$" + Arg2.ResolveType() +'_'+ Arg3.Token ;
		}
	}

[Automaton] class   methodDecl_localsHead__init______sigArgs0____
	: Automatrix {}

[Automaton] class   labels_id
	: Automatrix {}

[Automaton] class   labels_id_____labels
	: Automatrix {}

[Automaton] class   instr_INSTR_SWITCH_____labels____
	: Automatrix {}

[Automaton] class   instr_INSTR_BRTARGET_id
	: Automatrix {}
}


namespace org.com.net.edu.mil.us
	{
	//(([zero-copy|copy-paste]-buffer))-to-the-wall.
	}