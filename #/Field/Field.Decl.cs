public partial class A335
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
			string type = string.Join( "$", Arg4.ResolveType() ) ;
			switch( type )
				{
				case "string$[$]":
					field += C699.C.Struct( C699.String.p, Class.Symbol + "$" + Arg5.Token ) ;
					break ;
				default:
					throw new System.NotImplementedException() ;
				}
			field += " ;" ;
			}
	}



}
