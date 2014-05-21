partial class A335
{
[Automaton] class   methodDecl___entrypoint_
	: Method.Decl   {
	protected override void main()
		{
		EntryPoint() ;
		}
	}

[Automaton] class   methodDecl___maxstack__int32
	: Method.Decl   {
	protected override void main()
		{
		MaxStack = int.Parse( Arg2.Token ) ;
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

[Automaton] class   methodDecl_instr
	: Method.Decl	{
	protected override void main()
		{
		var d = NewOprand( Arg1.Token ) ;
		d.HasArgs = ( 0 < Args ) ;
		switch( d.Instruction )
			{
			case "LDARG_0":
				{
				C_Type type ;
				if( CallConvInstance )
					type = d.Method.ThisType ;
				else
					type = d.Method.Args[0] ;
				d.AssignStack( C.StackOffset, "args[0]" ) ;
				C.Push1( type ) ;
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
				var _call  = Instr.Method.Symbol ;
				//Debug.WriteLine( "[---] sigArgs={0} ", this_instr_sigArgs ) ;
				int iargs = Instr.Method.SigArgs + ( Instr.Method.CallConvInstance ? 1 : 0 ) ;
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
				Program.C_Function.Require( Instr.Method.Symbol ) ;
				if( Instr.Method.Type == "string" )
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
				if( Instr.Method.Type != "void" )
					C.Push( Instr.Method.Type ) ;
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
				var _class = Instr.Method.Class ;
				var _call  = C_Symbol.Acquire( Instr.Method.Symbol ) ;
				int iargs = Instr.Method.SigArgs + ( Instr.Method.CallConvInstance ? 1 : 0 ) ;
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
				d.Statement( "goto " + Instr.BrTarget.ID ) ;
				d.IsFlowControl = true ;
				RegisterLabel( Instr.BrTarget.ID ) ;
				break ;
			case "BGE" :
				C.Pop() ;
				C.Pop() ;
				d.Statement( "goto " + Instr.BrTarget.ID ) ;
				d.IsFlowControl = true ;
				RegisterLabel( Instr.BrTarget.ID ) ;
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
				//Debug.WriteLine( "[methodDecl_instr] Defaulted on " + d.Instruction ) ;
				break ;
			}
		//Debug.WriteLine( "[methodDecl_instr] stack={0}", C.StackOffset ) ;
		Instr.Method.SigArgTypes = null ;
		Instr.Method.SigArgs = 0 ;
		Instr.Method.CallConvInstance = false ;
		log( "[instr] "+ d.Instruction ) ;
		}
	}
}
