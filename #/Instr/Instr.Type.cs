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
				var size      = C699.SizeOf(new C699.c(C699.KeyedWord.Int),C699.C.One) ;
				var array     = C699.Malloc( C699.SizeOf( typeSpec, new C699.c("_length") ).plus(size) ).plus(size) ;
				var offset    = C699.Stack.Offset ;
				oprand.C.Statement( new C699.c(C699.KeyedWord.Int+" _length ="+length) ) ;
				oprand.C.Push( array, C_Type.Acquire( ((C699.c)typeSpec).p ) ) ;
				oprand.C.Statement( new C699.c("(("+C699.KeyedWord.Int+"*)"+C699.Stack.Index(offset)+")[-1]=_length") ) ;
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
			case "ISINST" :
				{
				//var vt = C.Peak() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				//oprand.C.Push( null, null ) ; //default
				}
				break ;
			case "LDOBJ" :
				{
				C.Pop() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				oprand.C.Push( C699.C.Zero, C_Type.Acquire( C699.C.Void.p ) ) ; // bogus
				}
				break ;
			case "CONSTRAINED_" :
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				break ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}
}
