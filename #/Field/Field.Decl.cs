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
		public virtual string ToStructField( Class.Head h )
			{
			throw new System.NotImplementedException() ;
			}
		}
	}

public partial class   fieldDecl___field__repeatOpt_fieldAttr_type_id_atOpt_initOpt
	: Field.Decl	{
	public override string ToStructField( Class.Head h )
			{
			string field = string.Empty ;
			A335.Type type = Argv[4] as A335.Type ;
			if( h.ValueType )
				field += C699.C.Struct( type, Arg5.Token ) ;
			else
				field += C699.C.Struct( type, h.Symbol + "$" + Arg5.Token ) ;
			field += " ;" ;
			return field ;
			}
	}
}
