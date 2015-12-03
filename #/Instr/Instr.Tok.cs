partial class A335
{
partial class Instr : Automatrix
	{
	public partial class Tok : Instr {}
	}

public partial class   instr_instr_tok_head_ownerType
	: Instr.Tok     {
	protected override void render()
		{
		switch( Op )
			{
			case "LDTOKEN" :
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				oprand.C.Push( C699.C.Three, C_I4_3 ) ; //bogus
				break ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}

public partial class   instr_tok_head_INSTR_TOK
	: Automatrix    {}
}
