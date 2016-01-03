partial class A335
{
public partial class Class : Automatrix
	{
	public partial class Decl : Class
		{
		protected Decls node ;
		public Decls Node
			{
			set { node = value ; }
			get { return node ; }
			}
		}
	}

public partial class   classDecl_customAttrDecl
	: Class.Decl {}

public partial class   classDecl_methodHead_methodDecls____
	: Class.Decl	{
	protected override void main()
		{
		var methodHead = Method.Declared( Argv[1] as Method.Head, Argv[2] as Method.Decls ) ;
		methodHead.ClassDecl = this ;
		#if HPP
		string symbol = Class.Type + methodHead.Name ;
		Instr.WriteList( symbol, Instr.List ) ;
		#else
		//Instr hpp = Instr.List ;
		#endif
		//C.Hangdown() ;
		}
	protected override void render()
		{
		var methodHead = Argv[1] as Method.Head ;
		C.Hangdown() ;
		methodHead.WriteMethod() ;
		}
	}

public partial class   classDecl_classHead_____classDecls____
	: Class.Decl	{
	protected override void main()
		{
		(Argv[1] as Head).Declared( Argv[3] as Decls, this ) ;
		}
	}

public partial class   classDecl_fieldDecl
	: Class.Decl	{
	public Field.Decl FieldDecl
		{
		get { return (Argv[1] as Field.Decl) ; }
		}
	}

public partial class   classDecl_propHead_____propDecls____
	: Class.Decl	{}
}



