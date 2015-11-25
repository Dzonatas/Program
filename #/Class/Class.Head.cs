partial class A335
{
public partial class Class : Automatrix
	{
	static protected Head classHead ;
	public partial class Head : Class
		{
		Decls decls ;
		Method.Head                 cctor   ;
		protected Head              outer   ;
		protected C_Type            type    ;
		protected ExtendsClause     extends ;
		public new virtual string   Symbol { get { return string.Empty ; } }
		public Head                 Outer  { get { return outer ; } }
		public new C_Type           Type   { get { return type ; } }
		public bool ValueType
			{
			get {
				if( extends == null )
					return false ;
				if( C699.KeyedWord.Struct == extends )
					return true ;
				return false ;
				}
			}
		public new Decls Decls
			{
			set { decls = value ; }
			get { return decls  ; }
			}
		public Method.Head Cctor
			{
			get { return cctor ; }
			set { cctor = value ; }
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
		extends = Argv[4] as ExtendsClause ;
		}
	}
}
