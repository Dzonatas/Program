partial class A335
{
[Automaton] class   instr_INSTR_BRTARGET_id
	: Instr.BrTarget {
	protected override void main()
		{
		ID = Arg2.Token ;
		}
	}

[Automaton] class   instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____
	: Instr.Method	{
	protected override void main()
		{
		CallConvList  = A335.CallConv.List ;
		Type          = Arg3 ;
		TypeSpec      = Arg4 ;
		// '::'
		Symbol        = _arg6_methodname() ;
		// '('
		SigArgs       = SigArg.Count() ;
		SigArgTypes   = SigArg.Types() ;
		SigArg.Clear() ;
		// ')'
		}
	C_Symbol _arg6_methodname()
		{
		string symbol = A335.typespec + arg6_methodname() + SigArg.Types() ;
		return C_Symbol.Acquire( symbol ) ;
		}
	string arg6_methodname()
		{
		return        Argv[6] is methodName___ctor_
			? _ctor
			: Nameset[2] + Arg6.Token
			;
		}
	}

[Automaton] class   instr_INSTR_TYPE_typeSpec
	: Instr.Type    {}

[Automaton] class   instr_INSTR_FIELD_type_id
	: Instr.Field   {}

[Automaton] class   instr_INSTR_FIELD_type_typeSpec______id
	: Instr.Field   {}

[Automaton] class   instr_INSTR_SWITCH_____labels____
	: Instr.Switch  {}

[Automaton] class   instr_INSTR_NONE
	: Instr.None    {}
}
