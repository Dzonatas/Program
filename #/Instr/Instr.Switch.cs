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
	protected override void render()
		{
		SWITCH( Arg3 ) ;
		}
	protected void SWITCH( Argument labels )
		{
		switch( Op )
			{
			case "SWITCH" :
				C.Pop() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				break ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}
}
