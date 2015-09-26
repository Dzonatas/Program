partial class A335
{
[Automaton] public class   methodHeadPart1___method_
	: Method.Head.Part1   {}

[Automaton] public class   methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____
	: Method.Head   {
	protected override void methodHead()
		{
		Type              = Arg5 ;
		Name              = arg6_methodname() ;
		SigArgs0          = Arg8 ;
		CallConv          = Arg3 ;
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
	protected new Argument SigArgs0
		{
		set {
			if ( value is Argument )
				{
				var a = (Automatrix) value ;
				if( a is Automatrix )
					base.SigArgs0 = a as SigArgs0 ;
				}
			}
		}
	protected Argument CallConv
		{
		set { CallConvList = (((Automatrix) value) as CallConv).List ; }
		}
	}
}
