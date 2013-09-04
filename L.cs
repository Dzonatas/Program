using System;//<NOUN L/>

public partial class A335
{

class log_enter
	{
	#region OPT:UNION
	System.Guid UUID ;
	DateTime dt ; //_linked[,_linq]
	#endregion OPT
	State    f ;
	public override string ToString()
			{
			return string.Format("[log_enter]{0}",dt);
			}
	public log_enter()
		{
		f = this_state ;
		dt = DateTime.Now ;
		}
	}
/*
#region micro
<s></> | <s>&stride.through;</t=strike.>
#endregion micro
#region micro_l
#endregion micro_l
*/
}
