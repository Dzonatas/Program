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
				throw new System.NotImplementedException( Op ) ;
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
		string _id = id.Token.Replace('<', '_').Replace('>', '_') ;
		C699.c symbol = new C699.c( typeSpec_s + "$" + _id ) ;
		switch( Op )
			{
			case "LDSFLD" :
				oprand.C.Push( symbol, type ) ;
				break ;
			case "STSFLD" :
				oprand.C.Statement(	symbol.Equate( C.Pop().StackCast ) ) ;
				break ;
			case "LDSFLDA" :
				oprand.C.Push( new C699.c("&"+symbol), ((C_Type)type).Ref ) ;
				break ;
			case "LDFLD" :
				{
				var vt = C.Pop() ;
				oprand.C.Push( new C699.c("("+vt.StackDeref+")->"+_id), type ) ;
				}
				break ;
			case "STFLD" :
				{
				var value = C.Pop() ;
				var obj   = C.Pop() ;
				oprand.C.Statement( new C699.c("("+obj.StackDeref+")->"+_id).Equate( value.StackCast ) ) ;
				}
				break ;
			case "LDFLDA" :
				C.Pop() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				oprand.C.Push( C699.C.Three, C_I4_3 ) ; //bogus
				break ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}
}
