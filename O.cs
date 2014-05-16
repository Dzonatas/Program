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

[Automaton] class   methodHeadPart1___method_
	: Automatrix {
	protected override void main()
		{
		this_method = new Program.Method() ;
		this_method.ClassSymbol = this_class_symbol ;
		}
	}

[Automaton] class   methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____
	: Automatrix	{
	protected override void main()
		{
		if( Args[6] is methodName___ctor_ )
			this_method.Name = "_ctor" ;
		else
		if( Args[6] is methodName___cctor_ )
			{
			this_method.Name = "_cctor" ;
			this_method.RegisterCctor() ;
			}
		else
			this_method.Name = "$" + Arg6.Token ;
		this_method.Type              = Arg5.ResolveType() ;
		this_method.SigArgs           = this_sigArgs ;
		this_method.SigArgTypes       = this_sigArg_types ;
		this_method.CallConvInstance  = this_callConv_instance ;
		this_method.Virtual           = Arg2.ResolvedMethAttrContainsVirtual ;
		this_sigArgs = 0 ;
		this_sigArg_types = null ;
		this_callConv_instance = false ;
		}
	}

[Automaton] class   methodDecl___maxstack__int32
	: Automatrix	{
	protected override void main()
		{
		this_method.MaxStack = int.Parse( Arg2.Token ) ;
		this_stack = new string[this_method.MaxStack] ;
		}
	}

[Automaton] class   methodDecl_instr
	: Automatrix	{
	protected override void main()
		{
		var d = C.Oprand( Arg1.Token ) ;
		this_method.Add( d ) ;
		int args = this_method.SigArgs + ( this_method.CallConvInstance ? 1 : 0 ) ;
		d.HasArgs = args > 0 ;
		Debug.WriteLine( "[methodDecl_instr] stack={0} args={1}", this_stack_offset, args ) ;
		switch( d.Instruction )
			{
			case "LDARG_0":
				d.AssignStack( this_stack_offset, "args[0]" ) ;
				this_stack[this_stack_offset] = "object" ;
				this_stack_offset++ ;
				break ;
			case "LDSTR":
				{
				var symbol = new C_Symbol() ;
				d.AssignStaticConst( Program.StructString, symbol,
					"{ "
					+ this_string.Length.ToString() + " , "
					+ '"' + this_string + '"'
					+ " }" ) ;
				d.AssignStack( this_stack_offset, "&" + symbol ) ;
				this_stack[this_stack_offset] = "string" ;
				this_stack_offset++ ;
				break ;
				}
			case "CALL":
				{
				var _call  = C_Symbol.Acquire( this_instr_symbol ) ;
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
					//d.Statement( "static struct _string item" + this_stack_offset.ToString() ) ;
					item = symbol + " = " ;
					freeset.Add( this_stack_offset ) ;
					if( iargs == 0 )
						d.CallAssign( symbol, _call ) ;
					else
						d.CallAssign( symbol, _call, "stack+" + this_stack_offset ) ;
					d.AssignStack( this_stack_offset, "&" + symbol ) ;
					}
				else
					{
					if( iargs == 0 )
						d.Call( _call ) ;
					else
						d.Call( _call, "stack+" + this_stack_offset ) ;
					}
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
				this_stack_offset++ ;
				this_stack_offset -= iargs ;
				d.ExternCall( _call ) ;
				d.Extern( Program.StructObject, _class ) ;
				d.AssignStaticConst( Program.StructObject, symbol, "{ &" + _class + " }" ) ;
				d.AssignStack( this_stack_offset, "&" + symbol ) ;
				if( iargs == 0 )
					d.Call( _call ) ;
				else
					d.Call( _call, "stack+" + this_stack_offset ) ;
				this_stack[this_stack_offset] = "object" ;
				this_stack_offset++ ;
				break ;
				}
			case "LDC_I4_0" :
				d.AssignStack( this_stack_offset, "0" ) ;
				this_stack_offset++ ;
				break ;
			case "LDC_I4_1" :
				d.AssignStack( this_stack_offset, "0" ) ;
				this_stack_offset++ ;
				break ;
			case "LDC_I4_2" :
				d.AssignStack( this_stack_offset, "0" ) ;
				this_stack_offset++ ;
				break ;
			case "LDC_I4_3" :
				d.AssignStack( this_stack_offset, "0" ) ;
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
				d.Statement( "goto " + this_instr_brtarget_id ) ;
				d.IsFlowControl = true ;
				this_method.RegisterLabel( this_instr_brtarget_id ) ;
				break ;
			case "BGE" :
				this_stack_offset-- ;
				this_stack_offset-- ;
				d.Statement( "goto " + this_instr_brtarget_id ) ;
				d.IsFlowControl = true ;
				this_method.RegisterLabel( this_instr_brtarget_id ) ;
				break ;
			case "ADD" :
				this_stack_offset-- ;
				this_stack_offset-- ;
				this_stack_offset++ ;
				break ;
			case "LDELEM_REF" :
				this_stack_offset++ ;
				this_stack_offset-- ;
				this_stack_offset-- ;
				break ;
			default :
				Debug.WriteLine( "[methodDecl_instr] Defaulted on " + d.Instruction ) ;
				break ;
			}
		Debug.WriteLine( "[methodDecl_instr] stack={0}", this_stack_offset ) ;
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
		this_stack_offset = 0 ;
		}
	}

[Automaton] class   methAttr_methAttr__static_
	: Automatrix	{
	protected override void main()
		{
		this_method.Static = true ;
		}
	}

[Automaton] class   methAttr_methAttr__specialname_
	: Automatrix {
	protected override void main()
		{
		//this_method.SpecialName = true ;
		}
	}

[Automaton] class   methodDecl___entrypoint_
	: Automatrix	{
	protected override void main()
		{
		if( System.String.IsNullOrEmpty(this_class_symbol) )
			throw new System.NotImplementedException( "entrypoint outside class" ) ;
		this_start_method = this_method ;
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

[Automaton] class   methodDecl_id____
	: Automatrix {
	protected override void main()
		{
		this_method.AddLabel( Arg1.Token ) ;
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