//|#(!)using System;
using System.Text.RegularExpressions ;
using System.Collections.Generic ;
using System.Diagnostics ;

public partial class A335
{
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


[Automaton] class   id_ID
	: Automatrix	{}

[Automaton] class   classHead___class__classAttr_id_extendsClause_implClause
	: Class.Head	{
	protected override void main()
		{
		ID = Arg3.Token ;
		}
	}

[Automaton] class   callConv__instance__callConv
	: Automatrix	{
	protected override void main()
		{
		this_callConv_instance = true ;
		}
	}

[Automaton] class   methodHeadPart1___method_
	: Method.Head   {
	protected override void main()
		{
		NewMethod( Class.Symbol ) ;
		}
	}

[Automaton] class   methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____
	: Method.Head   {
	protected override void main()
		{
		if( Args[6] is methodName___ctor_ )
			Name = "_ctor" ;
		else
		if( Args[6] is methodName___cctor_ )
			{
			Name = "_cctor" ;
			RegisterCctor() ;
			}
		else
			Name = "$" + Arg6.Token ;
		Type              = Arg5.ResolveType() ;
		SigArgs           = SigArg.Count() ;
		SigArgTypes       = SigArg.Types() ;
		CallConvInstance  = this_callConv_instance ;
		Virtual           = Arg2.ResolvedMethAttrContainsVirtual ;
		CreateFunction() ;
		SigArg.Clear() ;
		this_callConv_instance = false ;
		}
	}

[Automaton] class   methodDecl___maxstack__int32
	: Method.Decl   {
	protected override void main()
		{
		MaxStack = int.Parse( Arg2.Token ) ;
		}
	}

[Automaton] class   methodDecl_instr
	: Method.Decl	{
	protected override void main()
		{
		var d = NewOprand( Arg1.Token ) ;
		int args = SigArgs + ( CallConvInstance ? 1 : 0 ) ;
		d.HasArgs = args > 0 ;
		Debug.WriteLine( "[methodDecl_instr] stack={0} args={1}", C.StackOffset, args ) ;
		switch( d.Instruction )
			{
			case "LDARG_0":
				{
				string type ;
				if( CallConvInstance )
					type = d.Method.ClassNameType ;
				else
					type = d.Method.Args[0].Type ;
				d.AssignStack( C.StackOffset, "args[0]" ) ;
				C.Push( type ) ;
				break ;
				}
			case "LDSTR":
				{
				var symbol = new C_Symbol() ;
				d.AssignStaticConst( Program.StructString, symbol,
					"{ "
					+ this_string.Length.ToString() + " , "
					+ '"' + this_string + '"'
					+ " }" ) ;
				d.AssignStack( C.StackOffset, "&" + symbol ) ;
				C.Push( "string" ) ;
				break ;
				}
			case "CALL":
				{
				var _call  = C_Symbol.Acquire( this_instr_symbol ) ;
				Debug.WriteLine( "[---] sigArgs={0} ", this_instr_sigArgs ) ;
				int iargs = this_instr_sigArgs + ( this_instr_callConv_instance ? 1 : 0 ) ;
				C.Hangup( iargs ) ;
				/*
				if( !System.String.IsNullOrEmpty(this_instr_sigArg_types) )
					{
					string[] s = this_instr_sigArg_types.Split( '$' ) ;
					for( int a = ( this_instr_callConv_instance ? 2 : 1 ) ; a < iargs ; a++ )
						{
						int offset = C.StackOffset+a-1+( this_instr_callConv_instance ? 1 : 0 ) ;
						if( s[a] != this_stack[offset] )
							{
							this_program += "static struct _object obj = { 0 } ;" ;
							this_program += "obj.this = (void*) stack["+offset+"] ;" ;
							this_program += "stack[" + offset + "] =  &obj;" ;
							}
						}
					}
				*/
				string item = "" ;
				C_Symbol symbol = null ;
				Program.C_Function.Require( this_instr_symbol ) ;
				if( this_instr_type == "string" )
					{
					symbol = new C_Symbol() ;
					d.LocalStatic( Program.StructString, symbol ) ;
					//d.Statement( "static struct _string item" + C.StackOffset.ToString() ) ;
					item = symbol + " = " ;
					freeset.Add( C.StackOffset ) ;
					if( iargs == 0 )
						d.CallAssign( symbol, _call ) ;
					else
						d.CallAssign( symbol, _call, "stack+" + C.StackOffset ) ;
					d.AssignStack( C.StackOffset, "&" + symbol ) ;
					}
				else
					{
					if( iargs == 0 )
						d.Call( _call ) ;
					else
						d.Call( _call, "stack+" + C.StackOffset ) ;
					}
				if( this_instr_type != "void" )
					C.Push( this_instr_type ) ;
				break ;
				}
			case "RET":
				{
				foreach( object z in freeset )
					{
					if( z is int )
						d.FreeStackString( (int) z ) ;
					}
				freeset.Clear() ;
				break ;
				}
			case "NEWOBJ":
				{
				var symbol = new C_Symbol() ;
				var _class = C_Symbol.Acquire( this_instr_class_symbol ) ;
				var _call  = C_Symbol.Acquire( this_instr_symbol ) ;
				int iargs = this_instr_sigArgs + ( this_instr_callConv_instance ? 1 : 0 ) ;
				C.Hangup( iargs - 1 ) ;
				d.ExternCall( _call ) ;
				d.Extern( Program.StructObject, _class ) ;
				d.AssignStaticConst( Program.StructObject, symbol, "{ &" + _class + " }" ) ;
				d.AssignStack( C.StackOffset, "&" + symbol ) ;
				if( iargs == 0 )
					d.Call( _call ) ;
				else
					d.Call( _call, "stack+" + C.StackOffset ) ;
				C.Push( "object" ) ;
				break ;
				}
			case "LDC_I4_0" :
				d.AssignStack( C.StackOffset, "0" ) ;
				C.Push( null ) ;
				break ;
			case "LDC_I4_1" :
				d.AssignStack( C.StackOffset, "0" ) ;
				C.Push( null ) ;
				break ;
			case "LDC_I4_2" :
				d.AssignStack( C.StackOffset, "0" ) ;
				C.Push( null ) ;
				break ;
			case "LDC_I4_3" :
				d.AssignStack( C.StackOffset, "0" ) ;
				C.Push( null ) ;
				break ;
			case "STELEM_REF" :
				C.Pop() ;
				C.Pop() ;
				C.Pop() ;
				break ;
			case "NEWARR" :
				C.Push( null ) ;
				C.Pop() ;
				break ;
			case "STSFLD" :
				C.Pop() ;
				break ;
			case "LDSFLD" :
				C.Push( null ) ;
				break ;
			case "STLOC_0" :
				C.Pop() ;
				break ;
			case "STLOC_1" :
				C.Pop() ;
				break ;
			case "STLOC_2" :
				C.Pop() ;
				break ;
			case "STLOC_3" :
				C.Pop() ;
				break ;
			case "LDLOC_0" :
				C.Push( null ) ;
				break ;
			case "LDLOC_1" :
				C.Push( null ) ;
				break ;
			case "LDLOC_2" :
				C.Push( null ) ;
				break ;
			case "LDLOC_3" :
				C.Push( null ) ;
				break ;
			case "DUP" :
				C.Pop() ;
				C.Push( null ) ;
				C.Push( null ) ;
				break ;
			case "SWITCH" :
				C.Pop() ;
				break ;
			case "BR" :
				d.Statement( "goto " + this_instr_brtarget_id ) ;
				d.IsFlowControl = true ;
				RegisterLabel( this_instr_brtarget_id ) ;
				break ;
			case "BGE" :
				C.Pop() ;
				C.Pop() ;
				d.Statement( "goto " + this_instr_brtarget_id ) ;
				d.IsFlowControl = true ;
				RegisterLabel( this_instr_brtarget_id ) ;
				break ;
			case "ADD" :
				C.Pop() ;
				C.Pop() ;
				C.Push( null ) ;
				break ;
			case "LDELEM_REF" :
				C.Pop() ;
				C.Pop() ;
				C.Push( null ) ;
				break ;
			default :
				Debug.WriteLine( "[methodDecl_instr] Defaulted on " + d.Instruction ) ;
				break ;
			}
		Debug.WriteLine( "[methodDecl_instr] stack={0}", C.StackOffset ) ;
		this_instr_sigArg_types = null ;
		this_instr_sigArgs = 0 ;
		this_instr_callConv_instance = false ;
		log( "[instr] "+ d.Instruction ) ;
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
		this_instr_symbol = this_instr_class_symbol + this_methodName + SigArg.Types() ;
		this_instr_sigArgs = SigArg.Count() ;
		this_instr_sigArg_types = SigArg.Types() ;
		this_instr_callConv_instance = this_callConv_instance ;
		SigArg.Clear() ;
		this_callConv_instance = false ;
		}
	}

[Automaton] class   classDecl_methodHead_methodDecls____
	: Class.Decl	{
	protected override void main()
		{
		C.Hangdown() ;
		}
	}

[Automaton] class   methAttr_methAttr__static_
	: Method.Attr   {
	protected override void main()
		{
		Static = true ;
		}
	}

[Automaton] class   methAttr_methAttr__specialname_
	: Method.Attr   {
	protected override void main()
		{
		//this_method.SpecialName = true ;
		}
	}

[Automaton] class   methodDecl___entrypoint_
	: Method.Decl   {
	protected override void main()
		{
		EntryPoint() ;
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

[Automaton] class   decl_classHead_____classDecls____
	: Automatrix	{
	protected override void main()
		{
		Class.Declared() ;
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

[Automaton] class   classDecl_classHead_____classDecls____
	: Class.Decl	{
	protected override void main()
		{
		Declared() ;
		}
	}

[Automaton] class   customType_callConv_type_typeSpec________ctor______sigArgs0____
	: Automatrix {
	protected override void main()
		{
		SigArg.Clear() ;
		}
	}

[Automaton] class   methodDecl_localsHead__init______sigArgs0____
	: Method.Decl   {
	protected override void main()
		{
		SigArg.Clear() ;
		}
	}

[Automaton] class   methodDecl_id____
	: Method.Decl   {
	protected override void main()
		{
		Label = C_Symbol.Acquire( Arg1.Token ) ;
		}
	}

[Automaton] class   instr_INSTR_BRTARGET_id
	: Automatrix {
	protected override void main()
		{
		this_instr_brtarget_id = Arg2.Token ;
		}
	}
}


namespace org.com.net.edu.mil.us
	{
	//(([zero-copy|copy-paste]-buffer))-to-the-wall.
	}