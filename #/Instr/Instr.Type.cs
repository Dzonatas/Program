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
				var t = C.Pop() ;
				C699.c c = C699.Stack.Deref(C699.C.Int) ;
				var typeSpec = Argv[2] as A335.Type.Spec ;
				oprand.C.Statement( C699.Stack.Assign( typeSpec.newarr(c) ) ) ;
				C.Push( _C_ARY ) ;
				}
				break ;
			default :
				log( "[INSTR_TYPE] Defaulted on " + Op ) ;
				return ;
			}
		}
	}
}
