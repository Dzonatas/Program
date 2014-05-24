partial class A335
{
[Automaton] class   methodDecl___entrypoint_
	: Method.Decl   {
	protected override void main()
		{
		EntryPoint() ;
		}
	}

[Automaton] class   methodDecl___maxstack__int32
	: Method.Decl   {
	protected override void main()
		{
		MaxStack = int.Parse( Arg2.Token ) ;
		}
	}

[Automaton] class   methodDecl_localsHead__init______sigArgs0____
	: Method.Decl   {
	protected override void main()
		{
		SigArg.Clear() ;
		}
	}

[Automaton] class   methodDecl_id____
	: Method.Decl   {
	protected override void main()
		{
		Label = C_Symbol.Acquire( Arg1.Token ) ;
		}
	}

[Automaton] class   methodDecl_instr
	: Method.Decl	{
	protected override void main()
		{
		var instr = Argv[1] as Instr ;
		instr.C_OprandHasArgs = ( 0 < Args ) ;
		instr.Defined() ;
		//Debug.WriteLine( "[methodDecl_instr] stack={0}", C.StackOffset ) ;
		}
	}
}
