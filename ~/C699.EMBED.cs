//namespace C {
public partial class C699 {
	#if !EMBED
	static System.Diagnostics.ProcessStartInfo psi ;
	static C699()
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/cc" ) ;
		psi.WorkingDirectory         = System.Extensions.var_.GUID(0.1) ;
		psi.Arguments                = "" ;
		psi.UseShellExecute          = false ;
		psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = true ;
		psi.RedirectStandardInput    = true ;
		psi.CreateNoWindow           = true ;
		}
	static public string Embed( string text )
		{
		const string embed_i = "embed.c" ; //i2c99
		var sw = Current.Path.CreateText( embed_i ) ;
		sw.WriteLine( "#include <stdio.h>" ) ;
		sw.WriteLine( "#include <xcb/xcb.h>" ) ;
		sw.WriteLine( "#include <inttypes.h>" ) ;
		sw.WriteLine( C.Int+KeyedWord.Main+'('+C.Int.ArgC+','+C.Charpp.ArgV+','+C.Charpp.Env+')'+'{' ) ;
		sw.WriteLine( text ) ;
		sw.WriteLine( C.Return+'0'+';' ) ;
		sw.WriteLine( '}' ) ;
		sw.Close() ;
		psi.Arguments = "-o a."+embed_i+" -std=c99 "+embed_i ;
		//psi.Arguments = "-std=c99 "+embed_i ;
		System.Text.StringBuilder sb = new System.Text.StringBuilder() ;
		System.Diagnostics.Process p ;
		//try {
			p= System.Diagnostics.Process.Start(psi) ;
			p.StandardInput.AutoFlush = true ;
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
	#endif
}//}
