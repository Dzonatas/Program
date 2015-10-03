namespace Cluster {
//	[0.0::window,geometry:full.screen:0]
class system {
static system() {
 ///www.debian.org/News/2014/20140908
 /* X.Y.MapZ() */
}
public class Post {} ;
public class Put {} ;
public class Get {} ;
public class Delete {} ;
} ;
public static class Inbox {} ;  //(CTS)->MIME_t
public static class Outbox {} ; //MIME_t->(CTS)
public class Social
	{
	public class Security
		{
		static System.IO.MemoryStream license ;
		static Security() { license = null ; }
		public struct register
			{
			public int[]     _SSNo ;
			public string[]  _NAMe ;
			public A335.Zone _DISp ;
			//system.ARM[]   __PCi ;
			}
		}
	} ; //MIME_t->(MIME)
public interface Screen
	{
	Idol      Saver        { set ; get ; }
	Idle      Word         { set ; get ; }
	double    BackAngle    { set ; get ; }
	bool      Standard     { set ; get ; }
	bool      UnifiedPort  { set ; get ; } //IPv6-UDP-Content-Length:[0|#]
	Passport  Present      { set ; }
	}
public class Passport
	{
	System.DateTime[] dt ;
	System.DateTime[] prefixed ;
	System.DateTime[] suffixed ;
	System.DateTime[] objected ;
	}
public class Idle {} ;
public class Idol {} ;
public class Logical {} ;
public class Presence {} ;
}

namespace Cluster {
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


