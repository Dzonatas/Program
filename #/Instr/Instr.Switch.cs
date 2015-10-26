partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class Switch : Instr
		{
		}
	}

public partial class   instr_INSTR_SWITCH_____labels____
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
}
