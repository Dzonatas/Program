partial class A335
{
public partial class Method
	{
	public partial class Decl : Automatrix
		{
		Decls node ;
		public Decls Node
			{
			set { node = value ; }
			get { return node ; }
			}
		protected int     MaxStack
			{
			set { head.MaxStack = value ; C.MaxStack = value ; }
			}
		protected SigArgs0     Locals
			{
			set { head.Locals = new Method.Locals( value ) ; }
			}
		public C_Label Label
			{
			get {
				if( this is methodDecl_id____ )
					return (this as methodDecl_id____).Label ;
				else
					return C_Label.Empty ;
				}
			}
		static public C_Label Find( C_Symbol id )
			{
			foreach( Decl i in Decls.Thread )
				if( i.Label != null && id == i.Label )
					return i.Label ;
			return null ;
			}
		protected Program.C_Oprand NewOprand( string instr )
			{
			return head.NewOprand( instr ) ;
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
	protected override void main()
		{
		MaxStack = int.Parse( Arg2.Token ) ;
		}
	}

public partial class   methodDecl_localsHead__init______sigArgs0____
	: Method.Decl   {
	protected override void main()
		{
		Locals = Arg4 ;
		}
	protected new Argument Locals
		{
		set {
			base.Locals = (SigArgs0) (Automatrix) value ;
			}
		}
	}

public partial class   methodDecl_id____
	: Method.Decl   {
	C_Label label ;
	protected override void main()
		{
		label = C_Label.Acquire( Arg1.Token ) ;
		}
	public new C_Label Label
		{
		get { return label ; }
		}
	}

public partial class   methodDecl_instr
	: Method.Decl	{
	protected override void main()
		{
		(Argv[1] as A335.Instr).Decl = this ;
		}
	static public implicit operator C699.c(methodDecl_instr mdi)
		{
		return mdi.Argv[1] as Instr ;
		}
	}
}
