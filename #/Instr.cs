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
		string methodName = System.String.Empty ;
		if( Argv[6] is methodName___ctor_ )
			methodName = "_ctor" ;
		else
			methodName = "$" + Arg6.Token ;
		Type          = C_Type.Acquire( Arg3.ResolveType() ) ;
		Class         = C_Type.Acquire( Arg4.ResolveTypeSpec() ) ;
		Symbol        = C_Symbol.Acquire( Class + methodName + SigArg.Types() ) ;
		SigArgs       = SigArg.Count() ;
		SigArgTypes   = SigArg.Types() ;
		CallConvList  = A335.CallConv.List ;
		SigArg.Clear() ;
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
