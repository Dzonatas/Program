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
	protected override void main()
		{
		Op = Arg1.Token ;
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
	protected override void main()
		{
		Op = Arg1.Token ;
		FIELD( Arg2, Arg3, Arg5 ) ;
		}
	protected void FIELD( Argument type, Argument typeSpec, Argument id )
		{
		C699.c t = new C699.c() ;
		switch( string.Join( " ", ((Automatrix)type).ResolveType() ) )
			{
			case "string [ ]":	t = C699.String ; break ;
			default: throw new System.NotImplementedException() ;
			}
		string typeSpec_s = string.Join( "$", ((Automatrix)typeSpec).ResolveType() ) ;
		C699.c symbol = new C699.c( typeSpec_s + "$" + id.Token ) ;
		switch( Op )
			{
			case "LDSFLD" :
				oprand.C.Statement( C699.Stack.Assign(C.StackOffset, symbol) ) ;
				C.Push( C_Type.Acquire( t ) ) ;
				break ;
			case "STSFLD" :
				C.Pop() ;
				oprand.C.Statement(
					symbol.Equate( C699.Stack.CastIndex(C.StackOffset, C699.String ) )
					) ;
				break ;
			default :
				log( "[INSTR_FIELD-3] Defaulted on " + Op ) ;
				return ;
			}
		}
	}
}
