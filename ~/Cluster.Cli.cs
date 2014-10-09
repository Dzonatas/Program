namespace Cluster {
using System.Extensions ;
public static class Cli
	{
	static System.Diagnostics.ProcessStartInfo  psi ;
	static System.Diagnostics.Process           p ;
	static Cli()
		{
		psi   = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env" ) ;
		psi.UseShellExecute          = false ;
		//psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = false ;
		psi.RedirectStandardInput    = false ;
		psi.CreateNoWindow           = false ;
		psi.WindowStyle              = System.Diagnostics.ProcessWindowStyle.Normal ;
		psi.Arguments                = "" ;
		//psi.EnvironmentVariables     = new System.Collections.Specialized.StringDictionary()  ;
		//psi.LoadUserProfile
		//psi.Password
		//psi.UserName
		}
	static public void reset()
		{
		if( p == null )
			return ;
		if( ! p.HasExited )
			p.WaitForExit() ;
		p.Close() ;
		}
	static public void NoOperation()
		{
		reset() ;
		}
	static public void Start( string clicmd )
		{
		reset() ;
		psi.Arguments = clicmd ;
		p = System.Diagnostics.Process.Start(psi) ;
		}
	static public void AutoStart( string clicmd )
		{
		reset() ;
		var d = psi.WorkingDirectory ;
		psi.WorkingDirectory = 0.1.GUID() ;
		psi.Arguments = clicmd ;
		p = System.Diagnostics.Process.Start(psi) ;
		psi.WorkingDirectory = d ;
		}
	}
}
