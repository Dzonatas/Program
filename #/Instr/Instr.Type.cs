partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class Type : Instr {}
	}

public partial class   instr_INSTR_TYPE_typeSpec
	: Instr.Type    {
	protected override void render()
		{
		switch( Op )
			{
			case "NEWARR" :
				{
				var c = C.Pop().StackDeref ;
				var typeSpec = Argv[2] as A335.Type.Spec ;
				oprand.C.Push( typeSpec.newarr(c), typeSpec ) ;
				}
				break ;
			default :
				log( "[INSTR_TYPE] Defaulted on " + Op ) ;
				return ;
			}
		}
	}
}
