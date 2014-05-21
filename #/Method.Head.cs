partial class A335
{
[Automaton] class   methodHeadPart1___method_
	: Method.Head   {
	protected override void main()
		{
		NewMethod( Class.Type ) ;
		}
	}

[Automaton] class   methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____
	: Method.Head   {
	protected override void main()
		{
		Name              = arg6_methodname() ;
		Type              = C_Type.Acquire( Arg5.ResolveType() ) ;
		SigArgs           = SigArg.Count() ;
		SigArgTypes       = SigArg.Types() ;
		CallConvList      = A335.CallConv.List ;
		AttrList          = Method.Attr.List ;
		CreateFunction() ;
		SigArg.Clear() ;
		}
	string[] name = { "_ctor", "_cctor", "$" } ;
	string arg6_methodname()
		{
		if( Argv[6] is methodName___ctor_ )
			return name[0] ;
		else
		if( Argv[6] is methodName___cctor_ )
			{
			RegisterCctor() ;
			return name[1] ;
			}
		return name[2] + Arg6.Token ;
		}
	}
}
