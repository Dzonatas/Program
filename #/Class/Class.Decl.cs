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
		static protected bool Cctor
			{
			set { cctor_add( Class.Symbol ) ; }
			}
		}
	}

public partial class   classDecl_methodHead_methodDecls____
	: Class.Decl	{
	protected override void main()
		{
		var methodHead = Method.Declared( Argv[1] as Method.Head, Argv[2] as Method.Decls ) ;
		if( methodHead.Cctor )
			Cctor = true ;
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
		C.Hangdown() ;
		}
	}

public partial class   classDecl_classHead_____classDecls____
	: Class.Decl	{
	protected override void main()
		{
		Declared( Argv[1] as Head, Argv[3] as Decls ) ;
		}
	}

public partial class   classDecl_fieldDecl
	: Class.Decl	{
	public static implicit operator string( classDecl_fieldDecl decl )
		{
		return decl.Argv[1] as Field.Decl ;
		}
	}
}



