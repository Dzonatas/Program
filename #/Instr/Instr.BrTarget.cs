partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class BrTarget : Instr
		{
		protected A335.Method.Decl target ;
		}
	public class LabelNotFoundException : System.Exception
		{
		public LabelNotFoundException(string label) : base(label) {}
		}
	}

public partial class   instr_INSTR_BRTARGET_id
	: Instr.BrTarget {
	protected override void _prerender()
		{
		foreach( A335.Method.Decl d in decl.Node )
			if( d is methodDecl_id____ && (d as methodDecl_id____).Arg1.Token == Arg2.Token )
				{
				(d as methodDecl_id____).Required = true ;
				target = d ;
				return ;
				}
		throw new LabelNotFoundException( Arg2.Token ) ;
		}
	protected override void render()
		{
		oprand.BrTarget = true ;
		string id = target as methodDecl_id____ ;
		switch( Op )
			{
			case "BR" :
				oprand.C.GotoStatement( id ) ;
				return ;
			case "BRFALSE" :
				{
				var a = C.Pop().StackDeref ;
				#if HPP
				oprand.C.IfGotoStatement( Id ) ;
				oprand.C.Evaluate = (c) => { c.Statement( C699.C.Return("1") ) ; } ;
				#else
				oprand.C.Statement( C699.C.If( a.EqualTo.Zero, C699.C.Goto( id ) ) ) ;
				#endif
				}
				return ;
			case "BRTRUE_S" :
			case "BRTRUE" :
				{
				var a = C.Pop().StackDeref ;
				oprand.C.Statement( C699.C.If( a.NotEqualTo.Zero, C699.C.Goto( id ) ) ) ;
				}
				return ;
			case "BGE" :
				{
				var b = C.Pop().StackDeref ;
				var a = C.Pop().StackDeref ;
				#if HPP
				oprand.C.IfGotoStatement( Id ) ;
				oprand.C.Evaluate = (c) => { c.Statement( C699.C.Return("1") ) ; } ;
				#else
				oprand.C.Statement( C699.C.If( a, ">=", b , C699.C.Goto( id ) ) ) ;
				#endif
				}
				return ;
			case "BLE" :
				{
				var b = C.Pop().StackDeref ;
				var a = C.Pop().StackDeref ;
				oprand.C.Statement( C699.C.If( a, "<=", b , C699.C.Goto( id ) ) ) ;
				}
				return ;
			case "BEQ" :
				{
				var b = C.Pop().StackDeref ;
				var a = C.Pop().StackDeref ;
				#if HPP
				oprand.C.IfGotoStatement( Id ) ;
				oprand.C.Evaluate = (c) => { c.Statement( C699.C.Return("1") ) ; } ;
				#else
				oprand.C.Statement( C699.C.If( a, "==", b , C699.C.Goto( id ) ) ) ;
				#endif
				}
				return ;
			case "BLT" :
				{
				var b = C.Pop().StackDeref ;
				var a = C.Pop().StackDeref ;
				oprand.C.Statement( C699.C.If( a, "<", b , C699.C.Goto( id ) ) ) ;
				}
				return ;
			case "BNE_UN" :
				{
				var b = C.Pop().StackDeref ;
				var a = C.Pop().StackDeref ;
				oprand.C.Statement( C699.C.If( a, "!=", b , C699.C.Goto( id ) ) ) ;
				}
				return ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}

public partial class   instr_INSTR_BRTARGET_int32
	: Instr.BrTarget {
	protected override void main()
		{
		throw new System.NotImplementedException( Op ) ;
		}
	}
}
