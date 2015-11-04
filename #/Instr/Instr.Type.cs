partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class Type : Instr
		{
		protected override void main()
			{
			Op = Arg1.Token ;
			TYPE( Arg2 ) ;
			}
		protected virtual void TYPE( Argument typeSpec ) {}
		}
	}

public partial class   instr_INSTR_TYPE_typeSpec
	: Instr.Type    {
	protected override void TYPE( Argument typeSpec )
		{
		switch( Op )
			{
			case "NEWARR" :
				{
				var t = C.Pop() ;
				C699.c c = C699.Stack.Deref(C.StackOffset,C699.C.Int) ;
				C_Symbol s = t ;
				string token = string.Join( "$", ((Automatrix)typeSpec).ResolveType() ) ;
				switch( token )
					{
					case "int32":
						c = c.Equate( "(void*)"+s ) ;
						break ;
					case "[$mscorlib$]$System$String":
						c = C699.SizeOf( C699.String, c ) ;
						oprand.C.Statement(
							C699.Stack.Assign(C.StackOffset, C699.Malloc(c))
							);
						break ;
					default:
						throw new System.NotImplementedException() ;
					}
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
