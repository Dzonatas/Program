namespace Cluster {
using System.Extensions ;
public static class Cli
	{
	static System.Diagnostics.ProcessStartInfo  psi ;
	static System.Diagnostics.Process           p ;
	static System.Action<string>                put ;
	static System.Func<string>                  get ;
	static System.Text.StringBuilder            sb ;
	static Cli()
		{
		get = () => { return string.Empty ; } ;
		put = (o) => {} ;
		sb = new System.Text.StringBuilder() ;
		psi   = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env" ) ;
		psi.UseShellExecute          = false ;
		psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = true ;
		psi.RedirectStandardInput    = true ;
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
		p.WaitForExit() ;
		p.Close() ;
		}
	static public void reset()
		{
		put( get() ) ;
		get = () => { return string.Empty ; } ;
		put = (o) => {} ;
		sb.Clear() ;
		}
	static public void NoOperation()
		{
		reset() ;
		}
	static public void Start( string clicmd )
		{
		Start( clicmd, put ) ;
		}
	static public void Start( string clicmd, string input )
		{
		reset() ;
		sb.Append( input ) ;
		start( clicmd, put ) ;
		}
	static public void Start( string clicmd, System.Action<string> put )
		{
		reset() ;
		start( clicmd, put ) ;
		}
	static public void Idle()
		{
		if( ! p.HasExited )
			p.WaitForExit() ;
		reset() ;
		}
	static public void Refine()
		{
		p.WaitForExit() ;
		reset() ;
		}
	static void start( string clicmd, System.Action<string> put )
		{
		psi.Arguments = clicmd ;
		Cli.put = put ;
		Cli.get = () => { set() ; return sb.ToString() ; } ;
		p = System.Diagnostics.Process.Start(psi) ;
		if( sb.Length != 0 )
			{
			p.StandardInput.Write( sb.ToString() ) ;
			p.StandardInput.Flush() ;
			p.StandardInput.Close() ;
			}
		}
	static public void AutoStart( string clicmd )
		{
		reset() ;
		var d = psi.WorkingDirectory ;
		psi.WorkingDirectory = 0.1.GUID() ;
		start( clicmd, put ) ;
		psi.WorkingDirectory = d ;
		}
	static public void Copy( string arg1, string arg2 )
		{
		Start( "cp"+' '+arg1+' '+arg2 ) ;
		}
	static public void Relink( string arg1, string arg2 )
		{
		Shell.system( "for file in "+arg2+" ; do ln -fs "+arg1+" $file ; done" ) ;
		}
	static public void Time( string arg1 )
		{
		Shell.system( "for i in 1 2 3 4 5 6 7 8 9 ; do time -f %E "+arg1+" >dev>null ; done" ) ;
		}
	static public void Build( string arg1 )
		{
		Shell.system( "cd "+0.1.GUID()+" && xbuild /nologo /verbosity:quiet "+arg1 ) ;
		}
	}
}
