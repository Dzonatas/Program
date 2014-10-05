partial class A335
{
[Automaton] class   instr_INSTR_BRTARGET_id
	: Instr.BrTarget {
	protected override void BRTARGET()
		{
		switch( Op )
			{
			case "BR" :
				oprand.C.Statement( C699.Goto.Label(Id) ) ;
				return ;
			case "BGE" :
				C.Pop() ;
				C.Pop() ;
				oprand.C.Statement( C699.Goto.Label(Id) ) ;
				return ;
			default :
				log( "[INSTR_BRTARGET] Defaulted on " + Op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____
	: Instr.Method	{
	protected override void METHOD()
		{
		var d = oprand.C ;
		d.HasArgs = ( 0 < Args ) ;
		switch( Op )
			{
			case "CALL":
				{
				//Debug.WriteLine( "[---] sigArgs={0} ", this_instr_sigArgs ) ;
				int iargs = Args ;
				var data = C.Hangup( iargs ) ;
				if( _SigArgs0 != null )
					{
					try {
						int i = CallConvInstance ? 1 : 0 ;
						_SigArgs0.ForEach( (a) =>
							{
							if( a._Type != data[i].Type )
								{
								//type=pet( "nexus:CTS:get0,sphere,cube,square,point", a, data );
								}
							} ) ;
						}
					catch( System.Exception e )
						{
						/*
								this_program += "static struct _object obj = { 0 } ;" ;
								this_program += "obj.this = (void*) stack["+offset+"] ;" ;
								this_program += "stack[" + offset + "] =  &obj;" ;
						*/
						}
					}
				C_Symbol symbol = null ;
				Program.C_Function.Require( _Call ) ;
				if( _Type == "string" )
					{
					symbol = new C_Symbol() ;
					d.Statement( C699.C.Static(C699.String,symbol) ) ;
					freeset.Add( C.StackOffset ) ;
					if( iargs == 0 )
						d.Statement( C699.C.Restricted(symbol).Equate(C699.C.Function(_Call)) ) ;
					else
						d.Statement( C699.C.Restricted(symbol).Equate(C699.C.Function(_Call,C699.Stack.Pointer(C.StackOffset))) ) ;
					d.Statement( C699.Stack.Index(C.StackOffset).Equate("&"+symbol) ) ;
					}
				else
					{
					if( iargs == 0 )
						d.Statement( C699.C.Function(_Call) ) ;
					else
						d.Statement( C699.C.Function(_Call,C699.Stack.Pointer(C.StackOffset)) ) ;
					}
				if( _Type != "void" )
					C.Push( _Type ) ;
				break ;
				}
			case "NEWOBJ":
				{
				var symbol = new C_Symbol() ;
				var _class = _TypeSpec ;
				int iargs  = Args ;
				C.Hangup( iargs - 1 ) ;
				d.Statement( C699.C.Extern.Void.Function(_Call,C699.C.Const.Voidpp) ) ;
				d.Statement( C699.C.Extern.Struct(C699.Object(0),_class) ) ;
				d.Statement( C699.C.Const.Static(C699.Object(0)).Equate(symbol,"&"+_class) ) ;
				d.Statement( C699.Stack.Index(C.StackOffset).Equate("&"+symbol) ) ;
				if( iargs == 0 )
					d.Statement( C699.C.Function(_Call) ) ;
				else
					d.Statement( C699.C.Function(_Call,C699.C.Restricted("stack+"+C.StackOffset)) ) ;
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
	protected override void TYPE( Argument typeSpec )
		{
		switch( Op )
			{
			case "NEWARR" :
				object o = C.Pop() ;
				C.Push( _C_ARY ) ;
				break ;
			default :
				log( "[INSTR_TYPE] Defaulted on " + Op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_FIELD_type_id
	: Instr.Field   {
	protected override void main()
		{
		Op = Arg1.Token ;
		FIELD( Arg2, Arg3 ) ;
		}
	protected void FIELD( Argument type, Argument id )
		{
		switch( Op )
			{
			default :
				log( "[INSTR_FIELD-2] Defaulted on " + Op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_FIELD_type_typeSpec______id
	: Instr.Field   {
	protected override void main()
		{
		Op = Arg1.Token ;
		FIELD( Arg2, Arg3, Arg5 ) ;
		}
	protected void FIELD( Argument type, Argument typeSpec, Argument id )
		{
		switch( Op )
			{
			case "LDSFLD" :
				C.Push( C_Type.Acquire( "_C_LDSFLD" ) ) ;
				break ;
			case "STSFLD" :
				C.Pop() ;
				break ;
			default :
				log( "[INSTR_FIELD-3] Defaulted on " + Op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_SWITCH_____labels____
	: Instr.Switch  {
	protected override void main()
		{
		Op = Arg1.Token ;
		SWITCH( Arg3 ) ;
		}
	protected void SWITCH( Argument labels )
		{
		switch( Op )
			{
			case "SWITCH" :
				C.Pop() ;
				break ;
			default :
				log( "[INSTR_SWITCH] Defaulted on " + Op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_NONE
	: Instr.None    {
	protected override void NONE()
		{
		var d = oprand.C ;
		switch( Op )
			{
			case "LDARG_0":
				{
				C_Type type ;
				if( A335.Method.Head.Current.CallConvInstance )
					type = d.Method.ThisType ;
				else
					type = d.Method.Args[0] ;
				d.Statement( C699.Stack.Index(C.StackOffset).Equate("args[0]") ) ;
				C.Push1( type ) ;
				break ;
				}
			case "RET":
				{
				var typedef = Program.C_TypeDef.Acquire("string") ;
				string field = typedef.Struct[1] ;
				foreach( object z in freeset )
					{
					if( z is int )
						d.Statement( C699.Free('('+'('+C699.String+'*'+')'+C699.Stack.Index((int)z)+')'+"->"+field ) ) ;
					}
				freeset.Clear() ;
				break ;
				}
			case "LDC_I4_0" :
				d.Statement( C699.Stack.Index(C.StackOffset).Equate("0") ) ;
				C.Push( C_I4_0 ) ;
				break ;
			case "LDC_I4_1" :
				d.Statement( C699.Stack.Index(C.StackOffset).Equate("1") ) ;
				C.Push( C_I4_1 ) ;
				break ;
			case "LDC_I4_2" :
				d.Statement( C699.Stack.Index(C.StackOffset).Equate("2") ) ;
				C.Push( C_I4_2 ) ;
				break ;
			case "LDC_I4_3" :
				d.Statement( C699.Stack.Index(C.StackOffset).Equate("3") ) ;
				C.Push( C_I4_3 ) ;
				break ;
			case "DUP" :
				var t = C.Pop() as C_Type ;
				C.Push( t ) ;
				C.Push( t ) ;
				break ;
			case "LDELEM_REF" :
				C.Pop() ;
				C.Pop() ;
				C.Push( C_Type.Acquire( "_C_" + Op ) ) ;
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
				C.Push( C_Type.Acquire( "_C_LDLOC_0" ) ) ;
				break ;
			case "LDLOC_1" :
				C.Push( C_Type.Acquire( "_C_LDLOC_1" ) ) ;
				break ;
			case "LDLOC_2" :
				C.Push( C_Type.Acquire( "_C_LDLOC_2" ) ) ;
				break ;
			case "LDLOC_3" :
				C.Push( C_Type.Acquire( "_C_LDLOC_3" ) ) ;
				break ;
			case "ADD" :
				C.Pop() ;
				C.Pop() ;
				C.Push( C_Type.Acquire( "_C_" + Op ) ) ;
				break ;
			default :
				log( "[INSTR_NONE] Defaulted on " + Op ) ;
				return ;
			}
		}
	}

[Automaton] class   instr_INSTR_STRING_compQstring
	: Instr.String {
	protected override void STRING( Argument compQstring )
		{
		var d = oprand.C ;
		switch( Op )
			{
			case "LDSTR":
				{
				var c = C699.C.Const.Static(C699.String) ;
				var s = new C_Symbol() ;
				var args = this_string.Length.ToString()+','+'"'+this_string+'"' ;
				d.Statement( c.Equate(s,args) ) ;
				d.Statement( C699.Stack.Index(C.StackOffset).Equate("&"+s) ) ;
				C.Push( "string" ) ;
				break ;
				}
			default :
				log( "[INSTR_STRING] Defaulted on " + Op ) ;
				return ;
			}
		}
	}
}
