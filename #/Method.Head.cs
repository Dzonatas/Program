partial class A335
{
[Automaton] class   methodHeadPart1___method_
	: Method.Head.Part1   {}

[Automaton] class   methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____
	: Method.Head   {
	protected override void methodHead()
		{
		Type              = Arg5 ;
		Name              = arg6_methodname() ;
		SigArgs           = SigArg.Count() ;
		SigArgTypes       = SigArg.Types() ;
		CallConvList      = A335.CallConv.List ;
		AttrList          = Method.Attr.List ;
		}
	C_Symbol arg6_methodname()
		{
		return        Argv[6] is methodName___ctor_
			? _ctor : Argv[6] is methodName___cctor_
			? _cctor
			: C_Symbol.Acquire( Nameset[2] + Arg6.Token )
			;
		}
	}
}
