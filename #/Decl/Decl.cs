partial class A335
{
public partial class Decl : Automatrix
	{
	Decls node ;
	public Decls Node
		{
		set { node = value ; }
		}
	}

public partial class   decl_classHead_____classDecls____
	: Decl	{
	protected override void main()
		{
		Class.Declared() ;
		}
	}

public partial class   decl_assemblyHead_____assemblyDecls____
	: Decl	{}

public partial class   decl_assemblyRefHead_____assemblyRefDecls____
	: Decl	{}

public partial class   decl_moduleHead
	: Decl	{}

}
