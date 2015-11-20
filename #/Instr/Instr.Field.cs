partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class Field : Instr
		{
		}
	}

public partial class   instr_INSTR_FIELD_type_id
	: Instr.Field   {
	protected override void render()
		{
		FIELD( Arg2, Arg3 ) ;
		}
	protected void FIELD( Argument type, Argument id )
		{
		switch( Op )
			{
			default :
				log( "[INSTR_FIELD-2] Defaulted on " + Op ) ;
				return ;
			}
		}
	}

public partial class   instr_INSTR_FIELD_type_typeSpec______id
	: Instr.Field   {
	protected override void render()
		{
		FIELD( Argv[2] as A335.Type, Arg3, Arg5 ) ;
		}
	protected void FIELD( A335.Type type, Argument typeSpec, Argument id )
		{
		string typeSpec_s = string.Join( "$", ((Automatrix)typeSpec).ResolveType() ) ;
		C699.c symbol = new C699.c( typeSpec_s + "$" + id.Token ) ;
		switch( Op )
			{
			case "LDSFLD" :
				oprand.C.Push( symbol, type ) ;
				break ;
			case "STSFLD" :
				oprand.C.Statement(	symbol.Equate( C.Pop().StackCast ) ) ;
				break ;
			default :
				log( "[INSTR_FIELD-3] Defaulted on " + Op ) ;
				return ;
			}
		}
	}
}
