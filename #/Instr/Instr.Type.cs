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
				var length    = C.Pop().StackDeref ;
				var typeSpec  = Argv[2] as A335.Type.Spec ;
				var array     = C699.Malloc( C699.SizeOf( typeSpec, length ) ) ;
				oprand.C.Push( array, C_Type.Acquire( ((C699.c)typeSpec).p ) ) ;
				}
				break ;
			default :
				log( "[INSTR_TYPE] Defaulted on " + Op ) ;
				return ;
			}
		}
	}
}
