partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class Var : Instr {}
	}

public partial class   instr_INSTR_VAR_int32
	: Instr.Var    {
	protected override void render()
		{
		switch( Op )
			{
			case "LDLOCA_S":
				var i = int.Parse( Arg2.Token ) ;
				var loc = decl.Node.Head.Locals[i] ;
				oprand.C.Push( new C699.c("&"+loc.Symbol), ((C_Type)loc.Type).Ref ) ;
				break ;
			case "STARG_S":
				C.Pop() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				break ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}
}
