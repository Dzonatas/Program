partial class A335
{
static public System.IO.StreamWriter  log_output ;

static public void log_ready()
	{
	/*
		(
		(System.Runtime.InteropServices.GuidAttribute)
		//System.AppDomain.CurrentDomain.DomainManager.EntryAssembly.GetCustomAttributes(
		(typeof(A335).Assembly.GetCustomAttributes(
			typeof(System.Runtime.InteropServices.GuidAttribute), true
			)[0])
		).Value	+ ".txt" ;
	*/
	log_output = Current.Path.CreateText( "log.text" ) ;
	log_output.AutoFlush = true ;
	}

static public void log( string s )
	{
	if( log_output == null )
		log_ready() ;
	log_output.WriteLine( s ) ;
	log_output.Flush() ;
	}
	
static private void log_o( object[] o )
	{
	string s = "["+o.ToString()+"]" ;
	foreach( object i in o )
		s += " " + i.ToString() ;
	log( s ) ;		
	}
}
