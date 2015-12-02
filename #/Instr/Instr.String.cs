partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class String : Instr {}
	}

public partial class   instr_INSTR_STRING_compQstring
	: Instr.String {
	protected override void render()
		{
		var compQstring = (string) (Argv[2] as compQstring_QSTRING) ;
		switch( Op )
			{
			case "LDSTR":
				{
				var args = compQstring.Length.ToString()+','+'"'+compQstring+'"' ;
				var vt   = oprand.C.Allocate(C699.String.p, args) ;
				oprand.C.PushRef( vt ) ;
				break ;
				}
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}
}
