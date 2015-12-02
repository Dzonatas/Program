partial class A335
{
partial class Instr : Automatrix
	{
	public partial class I : Instr {}
	}

public partial class   instr_INSTR_I_int32
	: Instr.I       {
	protected override void render()
		{
		switch( Op )
			{
			case "LDC_I4_S" :
			case "LDC_I4" :
				oprand.C.Push( new C699.c( Arg2.Token ), C_Type.Acquire( C699.C.Int ) ) ;
				break ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}
}