partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class String : Instr
		{
		protected override void render()
			{
			string s = (string) (compQstring_QSTRING)Argv[2] ;
			STRING( s ) ;
			}
		protected virtual void STRING( string compQstring ) {}
		}
	}

public partial class   instr_INSTR_STRING_compQstring
	: Instr.String {
	protected override void STRING( string compQstring )
		{
		var d = oprand.C ;
		switch( Op )
			{
			case "LDSTR":
				{
				var c = C_Type.ConstStatic(C699.String) ;
				var s = new C_Symbol() ;
				var args = compQstring.Length.ToString()+','+'"'+compQstring+'"' ;
				d.Statement( c.TypeSpec.Equate(s,args) ) ;
				d.Push( new C699.c("&"+s), c ) ;
				break ;
				}
			default :
				log( "[INSTR_STRING] Defaulted on " + Op ) ;
				return ;
			}
		}
	}
}
