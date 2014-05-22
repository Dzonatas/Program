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
		var d = Instr.Declare( Arg1.Token ) ;
		d.HasArgs = ( 0 < Args ) ;
		switch( d.Instruction )
			{
			default :
				//Debug.WriteLine( "[methodDecl_instr] Defaulted on " + d.Instruction ) ;
				break ;
			}
		//Debug.WriteLine( "[methodDecl_instr] stack={0}", C.StackOffset ) ;
		Instr.Method.SigArgTypes = null ;
		Instr.Method.SigArgs = 0 ;
		Instr.Method.CallConvInstance = false ;
		log( "[instr] "+ d.Instruction ) ;
		Instr.Declared() ;
		}
	}
}
