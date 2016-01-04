partial class A335
{
public partial class Class : Automatrix
	{
	public partial class Head : Class
		{
		static private Head[]       classified = new Head[0] ;
		Method.Head                 cctor     ;
		C_Type                      type      ;
		protected Class.Decl        classDecl ;
		protected Decls             decls     ;
		protected ExtendsClause     extends   ;
		protected NameSpaceHead     nameSpaceHead ;
		public virtual string       Symbol    { get { return string.Empty ; } }
		public NameSpaceHead        NameSpaceHead
			{
			set { nameSpaceHead = value ; }
			}
		public C_Type               Type
			{
			get	{
				if( type != null )
					return type ;
				C_Symbol[] idset ;
				if( classDecl == null && nameSpaceHead == null )
					idset = new C_Symbol[1] { new C_Symbol( Arg3.Token ) } ;
				else
				if( classDecl == null && nameSpaceHead != null )
					idset = new C_Symbol[2] { C_Symbol.Acquire( nameSpaceHead ), new C_Symbol( Arg3.Token ) } ;
				else
					{
					var outer = classDecl.Node.Head ;
					int count = outer.Type.Count + ( nameSpaceHead == null ? 0 : 1 ) ;
					idset = new C_Symbol[count+1] ;
					int i = 0 ;
					if( nameSpaceHead != null )
						idset[i++] = C_Symbol.Acquire( nameSpaceHead ) ;
					for( ; i < count ; i++ )
						idset[i] = outer.Type[i] ;
					idset[i] = new C_Symbol( Arg3.Token ) ;
					}
				return type = new C_Type( idset ) ;
				}
			}
		public C699.c Extends
			{
			get	{
				if( extends == null )
					return C699.Object("object") ;
				return extends ;
				}
			}
		public bool ValueType
			{
			get {
				if( extends == null )
					return false ;
				return extends.ExtendedValueType ;
				}
			}
		public bool ExtendedSystemObject
			{
			get {
				if( extends == null )
					return false ;
				return extends.ExtendedSystemObject ;
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
			System.Array.Resize( ref classified, classified.Length+1 ) ;
			classified[classified.Length-1] = this ;
			}
		static public Head Find( Type.Spec typeSpec )
			{
			return Find( (string)((C699.c)typeSpec) ) ;
			}
		static public Head Find( string typeSpec )
			{
			foreach( Head h in classified )
				if( typeSpec == h.Symbol )
					return h ;
			throw new System.NotImplementedException() ;
			}
		}
	}

public partial class   classHead___class__classAttr_id_extendsClause_implClause
	: Class.Head	{
	public override string Symbol
		{
		get	{
			return classDecl == null
				? ( (nameSpaceHead == null ? "" : nameSpaceHead + "$" ) + Arg3.Token )
				: classDecl.Node.Head.Symbol + "$" + Arg3.Token ;
			}
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
		else
			{
			sw.WriteLine( "struct "+Symbol+" {" ) ;
			sw.WriteLine( "\t"+Extends+" base ;" ) ;
			}
		if( decls != null )
			foreach( Decl decl in decls )
				{
				if( decl is classDecl_fieldDecl )
					{
					var fd = (decl as classDecl_fieldDecl).FieldDecl ;
					if( ! fd.Static )
						sw.WriteLine( fd.ToStructField(this) ) ;
					}
				else
				if( decl is classDecl_methodHead_methodDecls____ )
					{
					var mh = (decl.Argv[1] as Method.Head) ;
					if( mh.Virtual )
						sw.WriteLine( mh.ToStructMember(this) ) ;
					}
				}
		sw.WriteLine( "} ;" ) ;
		sw.Close() ;
		sw = Current.Path.CreateText( Symbol + ".c" ) ;
		if( decls != null )
			foreach( Decl decl in decls )
				if( decl is classDecl_fieldDecl )
					{
					var fd = (decl as classDecl_fieldDecl).FieldDecl ;
					if( fd.Static )
						sw.WriteLine( fd.ToStructField(this) ) ;
					}
		sw.Close() ;
		}
	}
}
