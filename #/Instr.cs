partial class A335
{
[Automaton] class   instr_INSTR_BRTARGET_id
	: Instr.BrTarget {
	protected override void brtarget()
		{
		A335.method.RegisterLabel( Id ) ;
		switch( Op )
			{
			case "BR" :
				oprand.C.Jump( Id ) ;
				return ;
			case "BGE" :
				C.Pop() ;
				C.Pop() ;
				oprand.C.Jump( Id ) ;
				return ;
			default :
				log( "[INSTR_BRTARGET] Defaulted on " + Op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____
	: Instr.Method	{
	protected override void method()
		{
		var d = oprand.C ;
		d.HasArgs = ( 0 < Args ) ;
		switch( Op )
			{
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
				if( A335.type == "string" )
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
				if( A335.type != "void" )
					C.Push( A335.type ) ;
				break ;
				}
			case "NEWOBJ":
				{
				var symbol = new C_Symbol() ;
				var _class = A335.typespec ;
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
			default :
				log( "[INSTR_METHOD] Defaulted on " + Op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_TYPE_typeSpec
	: Instr.Type    {
	protected override void main()
		{
		field( Arg1.Token, Arg2 ) ;
		}
	protected void field( string op, Argument typeSpec )
		{
		var d = Declare( op ) ;
		switch( d.Instruction )
			{
			case "NEWARR" :
				C.Push( null ) ;
				C.Pop() ;
				break ;
			default :
				log( "[INSTR_TYPE] Defaulted on " + op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_FIELD_type_id
	: Instr.Field   {
	protected override void main()
		{
		field( Arg1.Token, Arg2, Arg3 ) ;
		}
	protected void field( string op, Argument type, Argument id )
		{
		var d = Declare( op ) ;
		switch( d.Instruction )
			{
			default :
				log( "[INSTR_FIELD-2] Defaulted on " + op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_FIELD_type_typeSpec______id
	: Instr.Field   {
	protected override void main()
		{
		field( Arg1.Token, Arg2, Arg3, Arg5 ) ;
		}
	protected void field( string op, Argument type, Argument typeSpec, Argument id )
		{
		var d = Declare( op ) ;
		switch( d.Instruction )
			{
			case "LDSFLD" :
				C.Push( null ) ;
				break ;
			case "STSFLD" :
				C.Pop() ;
				break ;
			default :
				log( "[INSTR_FIELD-3] Defaulted on " + op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_SWITCH_____labels____
	: Instr.Switch  {
	protected override void main()
		{
		_switch( Arg1.Token, Arg3 ) ;
		}
	protected void _switch( string op, Argument labels )
		{
		var d = Declare( op ) ;
		switch( d.Instruction )
			{
			case "SWITCH" :
				C.Pop() ;
				break ;
			default :
				log( "[INSTR_SWITCH] Defaulted on " + op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_NONE
	: Instr.None    {
	protected override void main()
		{
		none( Arg1.Token ) ;
		}
	protected void none( string op )
		{
		var d = Declare( op ) ;
		switch( d.Instruction )
			{
			case "LDARG_0":
				{
				C_Type type ;
				if( A335.method.CallConvInstance )
					type = d.Method.ThisType ;
				else
					type = d.Method.Args[0] ;
				d.AssignStack( C.StackOffset, "args[0]" ) ;
				C.Push1( type ) ;
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
			case "DUP" :
				C.Pop() ;
				C.Push( null ) ;
				C.Push( null ) ;
				break ;
			case "LDELEM_REF" :
				C.Pop() ;
				C.Pop() ;
				C.Push( null ) ;
				break ;
			case "STELEM_REF" :
				C.Pop() ;
				C.Pop() ;
				C.Pop() ;
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
			case "ADD" :
				C.Pop() ;
				C.Pop() ;
				C.Push( null ) ;
				break ;
			default :
				log( "[INSTR_NONE] Defaulted on " + op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_STRING_compQstring
	: Instr.String {
	protected override void main()
		{
		_string( Arg1.Token, Arg2 ) ;
		}
	protected void _string( string op, Argument compQstring )
		{
		var d = Declare( op ) ;
		switch( d.Instruction )
			{
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
			default :
				log( "[INSTR_STRING] Defaulted on " + op ) ;
				return ;
			}
		}
	}
}
