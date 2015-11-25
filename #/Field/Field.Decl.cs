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
		public virtual string ToStructField() { throw new System.NotImplementedException() ; }
		}
	}

public partial class   fieldDecl___field__repeatOpt_fieldAttr_type_id_atOpt_initOpt
	: Field.Decl	{
	protected override void main()
			{
			field = string.Empty ;
			A335.Type type = Argv[4] as A335.Type ;
			field += C699.C.Struct( type, Class.Symbol + "$" + Arg5.Token ) ;
			field += " ;" ;
			}
	public override string ToStructField()
			{
			string field = string.Empty ;
			A335.Type type = Argv[4] as A335.Type ;
			field += C699.C.Struct( type, Arg5.Token ) ;
			field += " ;" ;
			return field ;
			}
	}
}
