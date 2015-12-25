partial class A335
{
public partial class Decl : Automatrix
	{
	Decls node ;
	public Decls Node
		{
		set { node = value ; }
		get { return node  ; }
		}
	}

public partial class   decl_classHead_____classDecls____
	: Decl	{
	protected override void main()
		{
		(Argv[1] as Class.Head).Declared( Argv[3] as Class.Decls, null ) ;
		}
	}

public partial class   decl_assemblyHead_____assemblyDecls____
	: Decl	{}

public partial class   decl_assemblyRefHead_____assemblyRefDecls____
	: Decl	{}

public partial class   decl_moduleHead
	: Decl	{}

public partial class   decl_nameSpaceHead_____decls____
	: Decl
	{
	protected override void main()
		{
		foreach( Decl d in (Argv[3] as Decls) )
			{
			if( d is decl_classHead_____classDecls____ )
				( d.Argv[1] as Class.Head )
					.NameSpaceHead = Argv[1] as nameSpaceHead___namespace__name1 ;
			else
			if( d is decl_nameSpaceHead_____decls____ )
				( d.Argv[1] as NameSpaceHead )
					._NameSpaceHead = Argv[1] as nameSpaceHead___namespace__name1 ;
			}
		}
	}
}
