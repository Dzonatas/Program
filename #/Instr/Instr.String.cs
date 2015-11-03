partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class String : Instr
		{
		protected override void main()
			{
			Op = Arg1.Token ;
			STRING( Arg2 ) ;
			}
		protected virtual void STRING( Argument compQstring ) {}
		}
	}

public partial class   instr_INSTR_STRING_compQstring
	: Instr.String {
	protected override void STRING( Argument compQstring )
		{
		var d = oprand.C ;
		switch( Op )
			{
			case "LDSTR":
				{
				var c = C699.C.Const.Static(C699.String) ;
				var s = new C_Symbol() ;
				var args = this_string.Length.ToString()+','+'"'+this_string+'"' ;
				d.Statement( c.Equate(s,args) ) ;
				d.Statement( C699.Stack.Assign(C.StackOffset, new C699.c("&"+s) ) ) ;
				C.Push( "string" ) ;
				break ;
				}
			default :
				log( "[INSTR_STRING] Defaulted on " + Op ) ;
				return ;
			}
		}
	}
}
