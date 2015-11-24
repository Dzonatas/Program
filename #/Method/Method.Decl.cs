partial class A335
{
public partial class Method
	{
	public partial class Decl : Automatrix
		{
		protected Decls node ;
		public Decls Node
			{
			set { node = value ; }
			get { return node ; }
			}
		}
	}

public partial class   methodDecl___entrypoint_
	: Method.Decl   {
	protected override void main()
		{
		Method.EntryPoint = this ;
		}
	}

public partial class   methodDecl___maxstack__int32
	: Method.Decl   {
	protected override void prerender()
		{
		node.Head.MaxStack = C.MaxStack = int.Parse( Arg2.Token ) ;
		}
	}

public partial class   methodDecl_localsHead__init______sigArgs0____
	: Method.Decl   {
	protected override void prerender()
		{
		node.Head.Locals = new Method.Locals( Argv[4] as SigArgs0 ) ;
		}
	}

public partial class   methodDecl_id____
	: Method.Decl   {
	bool required ;
	public bool Required
		{
		set { required = value ; }
		get { return required ; }
		}
	static public implicit operator string( methodDecl_id____ mdi )
		{
		return mdi.Arg1.Token ;
		}
	protected override void render()
		{
		if( required )
			Node.Head.Function.Label( Arg1.Token ) ;
		}
	}

public partial class   methodDecl_instr
	: Method.Decl	{
	protected override void main()
		{
		(Argv[1] as A335.Instr).Decl = this ;
		}
	protected override void render()
		{
		node.Head.Function.Statement( Argv[1] as Instr ) ;
		}
	}
}
