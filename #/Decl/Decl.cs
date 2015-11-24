partial class A335
{
public partial class Decl : Automatrix
	{
	Decls node ;
	public Decls Node
		{
		set { node = value ; }
		}
	static public void WriteIncludesTo( Stack.IStart start, System.IO.StreamWriter tw )
		{
		Decls decls = (Decls) (START_decls) start ;
		foreach( Decl d in decls )
			if( d is decl_classHead_____classDecls____ )
				(d as decl_classHead_____classDecls____).WriteIncludesTo( tw ) ;
		}
	static public void WriteMethods( Stack.IStart start)
		{
		Decls decls = (Decls) (START_decls) start ;
		foreach( Decl d in decls )
			if( d is decl_classHead_____classDecls____ )
				(d as decl_classHead_____classDecls____).WriteMethods() ;
		}
	}

public partial class   decl_classHead_____classDecls____
	: Decl	{
	protected override void main()
		{
		Class.Declared( Argv[1] as Class.Head, Argv[3] as Class.Decls ) ;
		}
	public void WriteIncludesTo( System.IO.StreamWriter sw )
		{
		(Argv[3] as Class.Decls).WriteIncludesTo( sw ) ;
		}
	public void WriteMethods()
		{
		(Argv[3] as Class.Decls).WriteMethods() ;
		}
	}

public partial class   decl_assemblyHead_____assemblyDecls____
	: Decl	{}

public partial class   decl_assemblyRefHead_____assemblyRefDecls____
	: Decl	{}

public partial class   decl_moduleHead
	: Decl	{}

}
