using System.Extensions ;
using Application ;
using Application.Orbs ;

public partial class _
{
static System.IntPtr ʄ ;
static System.Xml.XmlTextReader   xml ;

public class exception : System.Exception
	{
	public exception()
		{
		prompt( string_t ) ;
		}
	}
	
public static char prompt( Token t )
	{
	int x = System.Console.WindowHeight-1 ; //t.c == '$' ? System.Console.WindowHeight-1 : 0 ;
	System.Console.SetCursorPosition(0,x) ;
	System.Console.ForegroundColor = System.ConsoleColor.Cyan ;
	System.Console.BackgroundColor = System.ConsoleColor.Blue ;
	System.Console.Write( t + "_" ) ;
	System.Console.ResetColor() ;
	System.Console.Write( "> _" ) ;
	System.Console.SetCursorPosition(System.Console.CursorLeft-1,x) ;
	System.ConsoleKeyInfo cki = System.Console.ReadKey( x == 0 ? true : false ) ;
	System.Console.SetCursorPosition(0,x) ;
	System.Console.Write( "> {0}_{1}", t._, cki.KeyChar ) ;
	for( int y = System.Console.CursorLeft ; y < System.Console.WindowWidth ; y++ )
		System.Console.Write( ' ' ) ;
	System.Console.SetCursorPosition(0,23) ;
	return cki.KeyChar ;
	}

public static void assimulation()
	{
	string input = read() ;
	xml = new System.Xml.XmlTextReader( new System.IO.StringReader( input ) ) ;
	while( xml.Read() && ! ( xml.NodeType == System.Xml.XmlNodeType.Element && xml.Name == "xml" ) ) ;
	}
	
internal static class screen
	{
	internal static System.Diagnostics.ProcessStartInfo psi ;
	static System.Diagnostics.Process process ;
	static screen()
		{
		object[] o = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute),true) ;
		
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env","Xnest :2 -name '" + (o[0] as System.Reflection.AssemblyTitleAttribute).Title +"'" ) ;
		psi.UseShellExecute = false ;
		//psi.StandardOutputEncoding = System.Text.Encoding.ASCII ;
		//psi.RedirectStandardOutput = true ;
		//psi.CreateNoWindow = true ;
		}
	static System.IntPtr      window ;
	static System.IntPtr      root ;
	static System.IntPtr      sid ;
	static System.IntPtr      items ;
	static int                nitems ;
	static System.IntPtr      atomatrix ;
	static System.IntPtr      core ;
	static System.IntPtr []   vector ;
	static System.IntPtr []   default_list ;
	static readonly string [] strings =
			{
			System.Guid.NewGuid().ToString(),
			System.Guid.NewGuid().ToString(),
			System.Guid.NewGuid().ToString(),
			System.Guid.NewGuid().ToString(),
			System.Guid.NewGuid().ToString(),
			System.Guid.NewGuid().ToString(),
			null
			} ;
	static int             argc        = 0 ;
	static string []       argv        = {} ;
	static string          icon_name   = "" ;
	static string          window_name = "" ;
	#if NOT_APU
	static System.IntPtr   pixmap ;
	#else
	static System.IntPtr[] pixmap      = new System.IntPtr[4096] ;
	#endif
	static System.IntPtr   hints ;
	internal static void start()
		{
		int  x, y ;
		uint width, height, border, depth ;
		process = System.Diagnostics.Process.Start(psi) ;
		vector  = new System.IntPtr[7] ;
		ʄ.OpenDisplay( out ʄ ) ;
		OrbAtom a = new OrbAtom(ʄ) ;
		Atom<OrbAtom> b = new Atom<OrbAtom>() ;
		b.Orbit = ʄ ;
		ʄ.InternAtoms( strings, strings.Length-1, false, vector ) ;
		ʄ.GetGeometry( window = ʄ.RootWindow(0),
			out root, out x, out y, out width, out height, out border, out depth) ;
		default_list = ʄ.ListProperties( root ) ;
		#if APU || !XGPU
		for( int i = 0 ; i < pixmap.Length ; i++ )
			pixmap[i]  = ʄ.CreatePixmap( window, width, height, depth ) ;
		ʄ.SetStandardProperties( window, window_name, icon_name, pixmap[0], argv, argc, hints ) ;
		#else
		pixmap  = ʄ.CreatePixmap( window, width, height, depth ) ;
		ʄ.SetStandardProperties( window, window_name, icon_name, pixmap, argv, argc, hints ) ;
		#endif
		System.IntPtr [] list = ʄ.ListProperties( window ) ;
		System.IntPtr key_book = list[0] ;   //list.Start() ;
		return ;				
		//System.IntPtr HDR = ʄ.CreatePixmap( windows, 256, 2.0 ) ;
		//System.Console.WriteLine( "DA={0}", ʄ.GetDefaultAtom(list[0]) ) ;
		//vector[6]  = ʄ.ListProperties( ʄ.RootWindow(), nitems )[0] ;
		/*
		vector[0]  = ʄ.InternAtom( System.Guid.NewGuid().ToString(), false ) ;
		vector[1]  = ʄ.InternAtom( System.Guid.NewGuid().ToString(), false ) ;
		ʄ.QueryTree( ʄ.RootWindow(), out root, out sid, out items, out nitems ) ;
		vector[2]  = ʄ.InternAtom( System.Guid.NewGuid().ToString(), false ) ;
		vector[3]  = ʄ.InternAtom( System.Guid.NewGuid().ToString(), false ) ;
		vector[4]  = ʄ.InternAtom( System.Guid.NewGuid().ToString(), false ) ;
		vector[5]  = ʄ.InternAtom( System.Guid.NewGuid().ToString(), false ) ;
		*/
		//System.Console.WriteLine("NITEMS={0}",nitems) ;
		//System.Guid atom = ʄ.GetAtom( atomatrix ) ;
		//System.Console.WriteLine("ATOM={0}",atom) ;
		//int n ;
		//vector[6]  = ʄ.ListProperties( ʄ.RootWindow(), out nitems ) ;
		//_atom:dottedname:scroll.bars
		//System.Console.WriteLine("NITEMS={0}",nitems) ;
		//depth=n(atoms)+nitems
		//string [] names = { "atomatrix", "core", "window", "root", "sid", "items", "" } ;
		//ʄ.InternAtoms( names, names.Length, false, vector ) ;
		}
	public static void Glitched(int d)
		{
		ʄ.Ring((System.IntPtr)d) ; //_blit_offset_d_length_masked
		}
	}

internal static class shell
	{
	internal static System.Diagnostics.ProcessStartInfo psi ;
	static shell()
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", "DISPLAY=:2 "+
			#if DEBUGS
			// "schroot -c debug-glx-sid /usr/bin/env DISPLAY=host:2 " +
			#endif
			"bash" ) ;
		psi.UseShellExecute          = false ;
		psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = true ;
		psi.CreateNoWindow           = false ;
		}
	}

static string read()
	{
	System.Text.StringBuilder sb = new System.Text.StringBuilder() ;
	System.Diagnostics.Process p ;
	try {
		p= System.Diagnostics.Process.Start(shell.psi) ;
		while(true)
			{
			string x = p.StandardOutput.ReadLine() ;
			if( x == null )
				break ;
			sb.Append( x ) ;
			sb.Append( '\n' ) ;
			}
		goto done ;
		} catch {}
	done:
	p.WaitForExit() ;
	return sb.ToString() ;
	}

/*
public struct (O(QR))(^)__
	{
	Token Association ; //[array:]
	//x [IHAVE,sendme]
	//y [ihave,SENDME]
        (Token "0.00000xbf"("con"-"(vexed)")) ;: '//y' -> . //_disables_comments_... ...(WORD) :'weak'.lnk.
	//zz   [MATERIALS,pixels]
	//y(y) [materials,PIXELS]
	Token Contribution ; //[tab:]
	}(.vm_p)((OPRAND))__FIXT:(Earth:)[UNICODED].known(...ASL)((default:"second-hand"(I.O)))
*/
	
static bool ended ;
public static Token input()
	{
	int x = System.Console.CursorTop ;
	int y = System.Console.CursorLeft ;
	if( xml.Read() && xml.NodeType == System.Xml.XmlNodeType.Element )
		{
		string [] s = xml.Name.Split("_-".ToCharArray()) ;
		xml.Read() ;
		string text = xml.Value ;
		return new Token( (char)int.Parse( s[1] ), text ) ; //_point3D:___(s[2,text]),_xor_URN:s[0]:_
		}
	Token t = new Token( '$', "$end" ) ;
	if( !ended ) prompt( t ) ;
	ended = true ;
	System.Console.SetCursorPosition(y,x) ;
	return t ;
	}

#region micro
//<bisect> | bisect: PLINE
//<o/o>    | O.no.#(One^H)
#endregion micro
//completion:(loop)(((_second))-('Sound'))
#region macro_d
//<o/o specific_n=n>    | [(->)(./#/O.cs)((_)s)](<(o)/(o)>)_FIX:("requires"_)lexical.up(Decimal "grammar"(0.0))
#endregion macro_d
#region micro_d
#if USED_PATENTS
//<o/o specific_n=n.[1-9](+)>    //_patented
#if UUCP_GOV_QUADGRAPH
//<o/o specific_n=d.[123456789](+)>    //__Open.gov.mil
//<o/o specific_n=d.[123456789](+)>    //MAP.GOV.MIL.d.(\123456789).[+objects,-terrain]
#endif
#endif
#endregion micro_d

}

