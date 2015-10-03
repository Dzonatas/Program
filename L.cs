//using System;//<NOUN L/>

public partial class A335
{

class log_enter
	{
	#region OPT:UNION
	System.Guid UUID ;
	System.DateTime dt ; //_linked[,_linq]
	#endregion OPT
	#if DEBUG_ANCHOR
	Anchor.Lock ʄ ;
	#endif
	#if WINDOWS
	bool     RT = _.Windows.RT ;
	public override string ToString()
			{
			return string.Format("[log_enter]{0}{1}",RT,dt);
			}
	#else
	public override string ToString()
			{
			return string.Format("[log_enter] {0}",dt);
			}
	#endif
	#if DEBUG_ANCHOR
	public log_enter()
		{
		#if CONSISTENT
		ʄ = new Anchor.Lock(this_state) ;
		#else
		ʄ = new Anchor.Lock(ʄ) ;
		ʄ.f = this_state ;
		#endif
		dt = System.DateTime.Now ;
		}
	#endif
	}
/*
#region micro
<s></> | <s>&stride.through;</t=strike.>
#endregion micro
#region micro_l
#endregion micro_l
*/
}
