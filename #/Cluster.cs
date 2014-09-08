namespace Cluster {
public static class Shell
	{
	static System.Diagnostics.ProcessStartInfo psi ;
	static public string Dpkg__p_LSB()
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", "dpkg -p LSB" ) ;
		psi.UseShellExecute          = false ;
		psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = true ;
		psi.RedirectStandardInput    = true ;
		psi.CreateNoWindow           = true ;
		//var f = System.IO.File.OpenText( hello ) ;
		System.Text.StringBuilder sb = new System.Text.StringBuilder() ;
		System.Diagnostics.Process p ;
		//try {
			p= System.Diagnostics.Process.Start(psi) ;
			//string s = f.ReadToEnd() ;
			p.StandardInput.AutoFlush = true ;
			//p.StandardInput.Write( s ) ;
			p.WaitForInputIdle() ;
			p.StandardInput.Close() ;
			while(!p.StandardOutput.EndOfStream)
				{
				string x = p.StandardOutput.ReadLine() ;
				if( x == null )
					break ;
				sb.Append( x ) ;
				sb.Append( '\n' ) ;
				}
			goto done ;
			//} catch {}
		done:
		p.WaitForExit() ;
		return sb.ToString() ;
		}
	}
}


