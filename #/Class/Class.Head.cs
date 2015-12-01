partial class A335
{
public partial class Class : Automatrix
	{
	public partial class Head : Class
		{
		Method.Head                 cctor     ;
		C_Type                      type      ;
		protected Class.Decl        classDecl ;
		protected Decls             decls     ;
		protected ExtendsClause     extends   ;
		public virtual string       Symbol    { get { return string.Empty ; } }
		public C_Type               Type
			{
			get	{
				if( type != null )
					return type ;
				C_Symbol[] idset ;
				if( classDecl == null )
					idset = new C_Symbol[1] { new C_Symbol( Arg3.Token ) } ;
				else
					{
					var outer = classDecl.Node.Head ;
					idset = new C_Symbol[outer.Type.Count+1] ;
					int i ;
					for( i = 0 ; i < outer.Type.Count ; i++ )
						idset[i] = outer.Type[i] ;
					idset[i] = new C_Symbol( Arg3.Token ) ;
					}
				return type = new C_Type( idset ) ;
				}
			}
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
		public void Declared( Decls d, Decl cd )
			{
			if( d != null )
				{
				d.Head  = this ;
				decls = d ;
				}
			classDecl = cd ;
			}
		}
	}

public partial class   classHead___class__classAttr_id_extendsClause_implClause
	: Class.Head	{
	public override string Symbol
		{
		get	{ return classDecl == null ? Arg3.Token : classDecl.Node.Head.Symbol + "$" + Arg3.Token ;	}
		}
	protected override void main()
		{
		extends = Argv[4] as ExtendsClause ;
		}
	protected override void render()
		{
		var sw = Current.Path.CreateText( Symbol + ".h" ) ;
		if( ValueType )
			sw.WriteLine( "struct "+Symbol+" {" ) ;
		foreach( Decl decl in decls )
			if( decl is classDecl_fieldDecl )
				sw.WriteLine( (decl as classDecl_fieldDecl).FieldDecl.ToStructField(this) ) ;
		if( ValueType )
			sw.WriteLine( "} ;" ) ;
		sw.Close() ;
		}
	}
}
