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


[Automaton] class   classHead___class__classAttr_id_extendsClause_implClause
	: Automatrix	{
	protected override void main()
		{
		this_class_id = Arg3.Token ;
		this_class_symbol += ( System.String.IsNullOrEmpty( this_class_symbol ) ? "" : "$" ) ;
		this_class_symbol +=  this_class_id ;
		}
	}

[Automaton] class   callConv__instance__callConv
	: Automatrix	{
	protected override void main()
		{
		this_callConv_instance = true ;
		}
	}

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
		Debug.WriteLine( "[methodDecl_instr] stack={0} args={1}", this_stack_offset, args ) ;
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
				Debug.WriteLine( "[---] sigArgs={0} ", this_instr_sigArgs ) ;
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
					Debug.WriteLine( " [methodDecl_instr] this_stack={0} offset={1}", this_stack.Length, this_stack_offset ) ;
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
			case "LDC_I4_0" :
				this_program += "\n        stack[" + this_stack_offset.ToString() + "] = 0 ;" ;
				this_stack_offset++ ;
				break ;
			case "LDC_I4_1" :
				this_program += "\n        stack[" + this_stack_offset.ToString() + "] = 0 ;" ;
				this_stack_offset++ ;
				break ;
			case "LDC_I4_2" :
				this_program += "\n        stack[" + this_stack_offset.ToString() + "] = 0 ;" ;
				this_stack_offset++ ;
				break ;
			case "STELEM_REF" :
				this_stack_offset-- ;
				this_stack_offset-- ;
				this_stack_offset-- ;
				break ;
			case "NEWARR" :
				this_stack_offset++ ;
				this_stack_offset-- ;
				break ;
			case "STSFLD" :
				this_stack_offset-- ;
				break ;
			case "LDSFLD" :
				this_stack_offset++ ;
				break ;
			case "STLOC_0" :
				this_stack_offset-- ;
				break ;
			case "STLOC_1" :
				this_stack_offset-- ;
				break ;
			case "STLOC_2" :
				this_stack_offset-- ;
				break ;
			case "STLOC_3" :
				this_stack_offset-- ;
				break ;
			case "LDLOC_0" :
				this_stack_offset++ ;
				break ;
			case "LDLOC_1" :
				this_stack_offset++ ;
				break ;
			case "LDLOC_2" :
				this_stack_offset++ ;
				break ;
			case "LDLOC_3" :
				this_stack_offset++ ;
				break ;
			case "DUP" :
				this_stack_offset++ ;
				this_stack_offset-- ;
				this_stack_offset++ ;
				break ;
			case "SWITCH" :
				this_stack_offset-- ;
				break ;
			case "BR" :
				break ;
			case "LDELEM_REF" :
				this_stack_offset++ ;
				this_stack_offset-- ;
				this_stack_offset-- ;
				break ;
			default :
				Debug.WriteLine( "[methodDecl_instr] Defaulted on " + this_instr ) ;
				break ;
			}
		Debug.WriteLine( "[methodDecl_instr] stack={0}", this_stack_offset ) ;
		this_program += "\n        }\n\n" ;
		this_instr_sigArg_types = null ;
		this_instr_sigArgs = 0 ;
		this_instr_callConv_instance = false ;
		log( "[instr] "+ this_instr ) ;
		}
	}

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

[Automaton] class   methAttr_methAttr__static_
	: Automatrix	{
	protected override void main()
		{
		this_method_static = true ;
		}
	}

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

[Automaton] class   sigArgs1_sigArgs1_____sigArg
	: Automatrix	{
	protected override void main()
		{
		this_sigArgs++ ;
		}
	}

[Automaton] class   classDecl_classHead_____classDecls____
	: Automatrix	{
	protected override void main()
		{
		string[] s = this_class_symbol.Split( '$' ) ;
		this_class_symbol = System.String.Join( "$", s, 0, s.Length - 1 ) ;
		}
	}

[Automaton] class   sigArg_paramAttr_type_id
	: Automatrix {
	protected override void main()
		{
		this_sigArg_types += "$" + Arg2.ResolveType() +'_'+ Arg3.Token ;
		}
	}

[Automaton] class   sigArgs0_sigArgs1
	: Automatrix {}

[Automaton] class   customType_callConv_type_typeSpec________ctor______sigArgs0____
	: Automatrix {
	protected override void main()
		{
		this_sigArgs = 0 ;
		this_sigArg_types = null ;
		}
	}

[Automaton] class   methodDecl_localsHead__init______sigArgs0____
	: Automatrix {
	protected override void main()
		{
		this_sigArgs = 0 ;
		this_sigArg_types = null ;
		}
	}

}


namespace org.com.net.edu.mil.us
	{
	//(([zero-copy|copy-paste]-buffer))-to-the-wall.
	}