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
			case "INITOBJ" :
				{
				var vt = C.Pop() ;
				var typeSpec  = Argv[2] as A335.Type.Spec ;
				oprand.C.Statement( vt.StackDeref
					.Equate( C699.Malloc( C699.SizeOf( typeSpec, C699.C.One ) ) ) ) ;
				}
				break ;
			case "LDELEMA" :
				{
				var index = C.Pop() ;
				var array = C.Pop() ;
				var typeSpec  = Argv[2] as A335.Type.Spec ;
				oprand.C.Push( array.StackArray(index.StackDeref), C_Type.Acquire( ((C699.c)typeSpec).p ) ) ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				}
				break ;
			case "STOBJ" :
				{
				C.Pop() ;
				C.Pop() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				}
				break ;
			case "BOX" :
				{
				C.Pop() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				oprand.C.Push( C699.C.Three, C_I4_3 ) ; //bogus
				}
				break ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}
}
