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
	static readonly string[,] file =
		{
		{ "~/", "X.Y.cs" },
		{ "#/", "X.Predefined.cs" },
		{ "#/", "Tokenset.cs" },
		{ "#/", "Automaton.1.cs" },
		{ "",   "Z.cs" },
		{ "~/", "C699.cs" },
		{ "~/", "C699.free.cs" }
		} ;
	static public string Embed( string[] compile )
		{
		string files = "" ;
		for( int i = 0 ; i < file.GetLength(0) ; i++ )
			{
			var f = "../../"+file[i,0]+file[i,1] ;
			files += " "+file[i,1] ;
			Cli.Copy( f, Current.Path.Entry( file[i,1] ) ) ;
			}
		foreach( string filename in compile )
			if( ! files.Contains( filename ) )
				files += " "+Current.Path.Entry( filename ) ;
		string infrastruct = Current.Path.Entry( "infrastructure.exe" ) ;
		Cli.AutoStart(
			#if LEAN_AND_MEAN
			"gmcs -define:EMBED -nostdlib" //-main:_accept.A335
			#else
			"gmcs -define:EMBED -nowarn:0169,219,414,649"
			#endif
			+ files
			+ " "+Current.Path.Entry("tokenset.cs")
			+ " "
			+ "-out:" + infrastruct
			) ;
		return infrastruct ;
		}
	}
}


