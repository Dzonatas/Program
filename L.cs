//using System;//<NOUN L/>

public partial class A335
{

class log_enter
	{
	#region OPT:UNION
	System.Guid UUID ;
	System.DateTime dt ; //_linked[,_linq]
	#endregion OPT
	Anchor.Lock ʄ ;
	bool     RT = _.Windows.RT ;
	public override string ToString()
			{
			return string.Format("[log_enter]{0}{1}",RT,dt);
			}
	public log_enter()
		{
		#if CONSISTENT
		ʄ = new Anchor.Lock(ʄ) ;
		#else
		//f = this_state ;
		ʄ = new Anchor.Lock(ʄ) ;
		#endif
		dt = System.DateTime.Now ;
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
