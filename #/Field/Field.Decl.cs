partial class A335
{
public partial class Field
	{
	public partial class Decl : Automatrix
		{
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
			string     field ;
			A335.Type  type  = Argv[4] as A335.Type ;
			string     id    = Arg5.Token.Replace('<', '_').Replace('>', '_') ;
			if( h.ValueType )
				field = C699.C.Struct( type, id ) ;
			else
				field = C699.C.Struct( type, h.Symbol + "$" + id ) ;
			field += " ;" ;
			return field ;
			}
	}
}
