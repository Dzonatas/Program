//using System;//<NOUN L/>

public partial class A335
{
static string log_file ;

static public void log_ready()
	{
	log_file = "/tmp/5a7160ed-13d5-4923-a1f9-3e32a47d558a.log.text" ;
	/*
		(
		(System.Runtime.InteropServices.GuidAttribute)
		//System.AppDomain.CurrentDomain.DomainManager.EntryAssembly.GetCustomAttributes(
		(typeof(A335).Assembly.GetCustomAttributes(
			typeof(System.Runtime.InteropServices.GuidAttribute), true
			)[0])
		).Value	+ ".txt" ;
	*/
	output = System.IO.File.CreateText( log_file ) ;
	}

static public void log( string s )
	{
	if( output == null )
		log_ready() ;
	output.WriteLine( s ) ;
	output.Flush() ;
	}
	
static private void log_o( object[] o )
	{
	string s = "["+o.ToString()+"]" ;
	foreach( object i in o )
		s += " " + i.ToString() ;
	log( s ) ;		
	}

class log_enter
	{
	#region OPT:UNION
	System.Guid UUID ;
	System.DateTime dt ; //_linked[,_linq]
	#endregion OPT
	Anchor.Lock ʄ ;
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
