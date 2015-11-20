partial class A335
{
public partial class Field
	{
	public partial class Decl : Automatrix
		{
		protected string field ;
		public static implicit operator string( Decl decl )
			{
			return decl.field ;
			}
		}
	}

public partial class   fieldDecl___field__repeatOpt_fieldAttr_type_id_atOpt_initOpt
	: Field.Decl	{
	protected override void main()
			{
			field = string.Empty ;
			A335.Type type = Argv[4] as A335.Type ;
			switch( Argv[4] as A335.Type )
				{
				case "string_sqbr":
					field += C699.C.Struct( type, Class.Symbol + "$" + Arg5.Token ) ;
					break ;
				default:
					throw new System.NotImplementedException() ;
				}
			field += " ;" ;
			}
	}



}
