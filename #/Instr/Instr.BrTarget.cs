partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class BrTarget : Instr
		{
		protected C_Label Id ;
		protected override void main()
			{
			Id = C_Label.Require( Arg2.Token ) ;
			}
		protected override void render()
			{
			oprand.BrTarget = true ;
			BRTARGET() ;
			}
		protected virtual void BRTARGET() {}
		}
	}

public partial class   instr_INSTR_BRTARGET_id
	: Instr.BrTarget {
	protected override void BRTARGET()
		{
		switch( Op )
			{
			case "BR" :
				oprand.C.GotoStatement( Id ) ;
				return ;
			case "BRFALSE" :
				{
				C.Pop() ;
				var a = C699.Stack.Deref(C699.C.Int) ;
				#if HPP
				oprand.C.IfGotoStatement( Id ) ;
				oprand.C.Evaluate = (c) => { c.Statement( C699.C.Return("1") ) ; } ;
				#else
				oprand.C.Statement( C699.C.If( a.EqualTo.Zero, C699.C.Goto( Id ) ) ) ;
				#endif
				}
				return ;
			case "BGE" :
				{
				C.Pop() ;
				var b = C699.Stack.Deref(C699.C.Int) ;
				C.Pop() ;
				var a = C699.Stack.Deref(C699.C.Int) ;
				#if HPP
				oprand.C.IfGotoStatement( Id ) ;
				oprand.C.Evaluate = (c) => { c.Statement( C699.C.Return("1") ) ; } ;
				#else
				oprand.C.Statement( C699.C.If( a, ">=", b , C699.C.Goto( Id ) ) ) ;
				#endif
				}
				return ;
			case "BEQ" :
				{
				C.Pop() ;
				var b = C699.Stack.Deref(C699.C.Int) ;
				C.Pop() ;
				var a = C699.Stack.Deref(C699.C.Int) ;
				#if HPP
				oprand.C.IfGotoStatement( Id ) ;
				oprand.C.Evaluate = (c) => { c.Statement( C699.C.Return("1") ) ; } ;
				#else
				oprand.C.Statement( C699.C.If( a, "==", b , C699.C.Goto( Id ) ) ) ;
				#endif
				}
				return ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}
}
