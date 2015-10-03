partial class A335
{
public partial class   methodDecl___entrypoint_
	: Method.Decl   {
	protected override void main()
		{
		EntryPoint = this ;
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
	: Method.Decl   {}

public partial class   methodDecl_id____
	: Method.Decl   {
	protected override void main()
		{
		Enlist() ;
		Label = C_Label.Acquire( Arg1.Token ) ;
		}
	}

public partial class   methodDecl_instr
	: Method.Decl	{
	protected override void main()
		{
		Enlist() ;
		Instr = Argv[1] as Instr ;
		Instr.C_OprandHasArgs = ( 0 < Args ) ;
		Instr.Defined() ;
		//Debug.WriteLine( "[methodDecl_instr] stack={0}", C.StackOffset ) ;
		}
	}
}
