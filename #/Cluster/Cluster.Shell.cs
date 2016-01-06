namespace Cluster
{
public static partial class Shell
	{
	[System.Runtime.InteropServices.DllImport( "libc.so.6" )]	public extern  static   int             system(string command) ;
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
	static public string Dpkg__p_START()
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", "sensors" ) ;
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

namespace Cluster
{
public static partial class Shell
	{
	readonly static char[] MSB = new char[] { ' ', '.' } ;
	static string[] _sys_power_state     = { "", "", "", "", "", "", "", "", "" } ;
	public static int Cat__sys_power_state()
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", "cat /sys/power/state" ) ;
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
		return ( _sys_power_state = sb.ToString().Split( MSB ) ).Length ;
		}
	public static int Test__sys_class___sys_power_state_() //Test__sys_class.(_sys_power_state)
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", "cat /sys/class/" + _sys_power_state[0]  ) ;
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
		return sb.ToString().Split( MSB ).Length ;
		}
	static public int Sensors___grep_ALARM()
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", "rgrep --mmap /sys/class ALARM" ) ; //XHAL
		psi.UseShellExecute          = true ;
		//psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = false ;
		psi.RedirectStandardInput    = false ;
		psi.CreateNoWindow           = true ;
		//var f = System.IO.File.OpenText( hello ) ;
		//System.Text.StringBuilder sb = new System.Text.StringBuilder() ;
		System.Diagnostics.Process p ;
		//try {
			p= System.Diagnostics.Process.Start(psi) ;
			//string s = f.ReadToEnd() ;
			//p.StandardInput.AutoFlush = true ;
			//p.StandardInput.Write( s ) ;
			p.WaitForInputIdle() ;
			//p.StandardInput.Close() ;
			/*
			while(!p.StandardOutput.EndOfStream)
				{
				string x = p.StandardOutput.ReadLine() ;
				if( x == null )
					break ;
				sb.Append( x ) ;
				sb.Append( '\n' ) ;
				}
			*/
			goto done ;
			//} catch {}
		done:
		p.WaitForExit() ;
		return p.ExitCode ;
		}
	static public int RT()
		{
		#if PRIMED
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", Application.Parameter.Value("primer") ) ;
		#else
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", "xinit -- :0 -layout \"Default\"" ) ; //XHAL
		#endif
		psi.UseShellExecute          = true ;
		//psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = false ;
		psi.RedirectStandardInput    = false ;
		psi.CreateNoWindow           = true ;
		//var f = System.IO.File.OpenText( hello ) ;
		//System.Text.StringBuilder sb = new System.Text.StringBuilder() ;
		System.Diagnostics.Process p ;
		//try {
			p= System.Diagnostics.Process.Start(psi) ;
			//string s = f.ReadToEnd() ;
			//p.StandardInput.AutoFlush = true ;
			//p.StandardInput.Write( s ) ;
			p.WaitForInputIdle() ;
			//p.StandardInput.Close() ;
			/*
			while(!p.StandardOutput.EndOfStream)
				{
				string x = p.StandardOutput.ReadLine() ;
				if( x == null )
					break ;
				sb.Append( x ) ;
				sb.Append( '\n' ) ;
				}
			*/
			goto done ;
			//} catch {}
		done:
		p.WaitForExit() ;
		return p.ExitCode ;
		}
	static System.Diagnostics.Process p_temp ;
	static public System.Diagnostics.Process Xnest()
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", "Xnest :2" ) ;
		psi.UseShellExecute          = true ;
		//psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = false ;
		psi.RedirectStandardInput    = false ;
		psi.CreateNoWindow           = true ;
		System.Diagnostics.Process p ;
			p= System.Diagnostics.Process.Start(psi) ;
		return (p_temp = p) ;
		}
	static private System.Diagnostics.Process _p_temp
		{
		get { return p_temp ; }
		}
	}
}
