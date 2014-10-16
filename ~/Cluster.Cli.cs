namespace Cluster {
using System.Extensions ;
public static class Cli
	{
	static System.Diagnostics.ProcessStartInfo  psi ;
	static System.Diagnostics.Process           p ;
	static System.Action<string>                put ;
	static System.Text.StringBuilder            sb ;
	static Cli()
		{
		put = (o) => {} ;
		sb = new System.Text.StringBuilder() ;
		psi   = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env" ) ;
		psi.UseShellExecute          = false ;
		psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = true ;
		psi.RedirectStandardInput    = false ;
		psi.CreateNoWindow           = false ;
		psi.WindowStyle              = System.Diagnostics.ProcessWindowStyle.Normal ;
		psi.Arguments                = "" ;
		//psi.EnvironmentVariables     = new System.Collections.Specialized.StringDictionary()  ;
		//psi.LoadUserProfile
		//psi.Password
		//psi.UserName
		}
	static void set()
		{
		while(!p.StandardOutput.EndOfStream)
			{
			string x = p.StandardOutput.ReadLine() ;
			if( x == null )
				break ;
			sb.AppendLine( x ) ;
			}
		goto done ;
		done:
		p.WaitForExit() ;
		p.Close() ;
		}
	static public void reset()
		{
		if( p != null )
			set() ;
		put( sb.ToString() ) ;
		put = (o) => {} ;
		sb.Clear() ;
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
	static public void Start( string clicmd, System.Action<string> put )
		{
		reset() ;
		psi.Arguments = clicmd ;
		p = System.Diagnostics.Process.Start(psi) ;
		Cli.put = put ;
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
