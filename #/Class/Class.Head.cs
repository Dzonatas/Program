partial class A335
{
public partial class Class : Automatrix
	{
	static protected Head classHead ;
	public partial class Head : Class
		{
		Decls decls ;
		protected Head              outer ;
		protected C_Type            type ;
		public new virtual string   Symbol { get { return string.Empty ; } }
		public Head                 Outer  { get { return outer ; } }
		public new C_Type           Type   { get { return type ; } }
		public new Decls Decls
			{
			set { decls = value ; }
			get { return decls  ; }
			}
		}
	}

public partial class   classHead___class__classAttr_id_extendsClause_implClause
	: Class.Head	{
	public override string Symbol
		{
		get	{ return outer == null ? Arg3.Token : outer.Symbol + "$" + Arg3.Token ;	}
		}
	protected override void main()
		{
		outer = classHead ;
		classHead = this ;
		C_Symbol[] idset ;
		if( outer == null )
			idset = new C_Symbol[1] { new C_Symbol( Arg3.Token ) } ;
		else
			{
			idset = new C_Symbol[outer.Type.Count+1] ;
			int i ;
			for( i = 0 ; i < outer.Type.Count ; i++ )
				idset[i] = outer.Type[i] ;
			idset[i] = new C_Symbol( Arg3.Token ) ;
			}
		type = new C_Type( idset ) ;
		}
	}
}
