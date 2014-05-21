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
		CallConvInstance  = CallConv.Instance ;
		Virtual           = Arg2.ResolvedMethAttrContainsVirtual ;
		CreateFunction() ;
		SigArg.Clear() ;
		CallConv.Instance = null ;
		}
	class CallConv
		{
		static public Microdata Instance
			{
			get { return new Microdata( this_callConv_instance ) ; }
			set { this_callConv_instance = false ; }
			}
		}
	}
}
