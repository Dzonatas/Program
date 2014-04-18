//using System;//<NOUN L/>

public partial class A335
{

static public void log( string s )
	{
	if( output == null )
		output = System.IO.File.CreateText( "/tmp/output.c" ) ;
	output.WriteLine( s ) ;
	output.Flush() ;
	}

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
		ʄ = new Anchor.Lock(this_state) ;
		#else
		ʄ = new Anchor.Lock(ʄ) ;
		ʄ.f = this_state ;
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
