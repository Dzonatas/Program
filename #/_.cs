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
		#if CONSOLE
		prompt( string_t ) ;
		#endif
		}
	}
	
#if CONSOLE
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
#endif

public static void assimulation( string input )
	{
	//In re: "assimilated" -> icyspherical.blogspot.com/2010/07/why-resthttp-based-client-side.html
	xml = new System.Xml.XmlTextReader( new System.IO.StringReader( input ) ) ;
	while( xml.Read() && ! ( xml.NodeType == System.Xml.XmlNodeType.Element && xml.Name == "xml" ) ) ;
	}

#if SCREEN	
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
		#if ASYNC || MONITOR
		ʄ.Ring((System.IntPtr)d) ; //_blit_offset_d_length_masked
		#endif
		}
	public static void DrawCode()
		{
		ʄ.Stitch(0,0) ;
		}
	}
#endif

internal static class shell
	{
	internal static System.Diagnostics.ProcessStartInfo psi ;
	static shell()
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env", "DISPLAY=:2 "+
			#if DEBIAN
			// "schroot -u " + Application.Parameter.Value("cgroup") +
			// " -c " + Application.Parameter.Value("systemd") +
			// " /usr/bin/env DISPLAY=host:2 " +
			#endif
			Cluster.Parameter.Value("shell") ) ;
		psi.UseShellExecute          = false ;
		psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = true ;
		psi.CreateNoWindow           = true ;
		}
	}

#if DEBUG && WINDOWS
//[Program.Extent]
public static class Windows
	{
	internal static System.Diagnostics.ProcessStartInfo psi ;
	#if !X45 && !RJ45
	public static bool RT = true ;
	#else
	public static bool RT ;
	#endif
	#if LINUX_APU_MMCONFIG_BUG && !MAINFRAME
	public static byte [] fastmem = new fastmem[int.MaxValue] ;  //FIX:_ktap_first_2GB
	#elif !LINUX_APU_MMCONFIG_BUG && !VMX
	public static System.IntPtr Assembly = (System.IntPtr)System.Int32.MaxValue ;
	#endif
	static Windows()
		{
		#if !WIRELESS
		RT = Application.Parameter.Value("wired") == "false" ;
		#endif
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env",
			"DISPLAY="
			#if !FDDI
			 + (RT ? "card" : "entity" )
			#endif
			+":2 "+ 
			"schroot -c windowsid"
			#if PXE_ENTITY || SCHROOT_DIRECTORY
			+" "+ Application.Parameter.Value("shell")
			#endif
			) ;
		psi.UseShellExecute          = false ;
		psi.StandardOutputEncoding   = System.Text.Encoding.UTF8 ;
		psi.RedirectStandardOutput   = true ;
		psi.CreateNoWindow           = false ;
		}
	}
#elif WINDOWS || TOR

//[Program.Extended]
public static class Windows
	{
	internal static System.Diagnostics.ProcessStartInfo psi ;
	static Windows()
		{
		#if SILVERLIGHT || STEAM || TOR
		psi = new System.Diagnostics.ProcessStartInfo
			(
			"/usr/bin/env",
			"DISPLAY=:2 rdesktop -f -O -r sound:remote"
			) ;
		#if !AG || RT || ENGINEER
		psi.UseShellExecute          = true ;
		#else
		psi.UseShellExecute          = false ;
		#endif
		psi.StandardOutputEncoding   = System.Text.Encoding.UTF16 ;
		psi.RedirectStandardOutput   = true ;
		#if CONTROL
		psi.CreateNoWindow           = true ;
		#else
		psi.CreateNoWindow           = false ;
		#endif
		#endif
		}
	}

#elif AMP

//[Program.Extended]
public static class Windows
	{
	internal static System.Diagnostics.ProcessStartInfo psi ;
	static Windows()
		{
		psi = new System.Diagnostics.ProcessStartInfo
			(
			"/usr/bin/env",
			"DISPLAY=:2 rdesktop -f -O -r sound:local"
			) ;
		psi.UseShellExecute          = false ;
		psi.StandardOutputEncoding   = System.Text.Encoding.Unicode ; //default='&'
		psi.RedirectStandardOutput   = true ;
		#if ATM && MESA
		psi.CreateNoWindow           = true ;
		#else // EQ || SOUNDEX
		psi.CreateNoWindow           = false ;
		#endif
		}
	}

#else //DefaultCulture="Arabic German"

//[Program.Extended]
public static class Windows
	{
	#if ALPHA  //&& LINUX_APU_MMCONFIG_BUG
	public static System.IntPtr Assembly = (System.IntPtr)512 ; //first_page_voided
	#endif
	static Windows()
		{
		#if SILVERLIGHT
		psi = new System.Diagnostics.ProcessStartInfo
			(
			"/usr/bin/env",
			"DISPLAY=:2 rdesktop -f -O -r sound:off"
			#if FDDI || PXE_ENTITY
			+ " -r lspci"
			#endif
			) ;
		#if !AG || RT
		psi.UseShellExecute          = true ;
		#else
		psi.UseShellExecute          = false ;
		#endif
		psi.StandardOutputEncoding   = System.Text.Encoding.UTF32 ;
		psi.RedirectStandardOutput   = true ;
		#if CONTROL || (ATM && MESA)
		psi.CreateNoWindow           = true ;
		#else
		psi.CreateNoWindow           = false ;
		#endif
		#endif
		}
	}

#endif

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
	#if DEBUG_INPUT
	int x = System.Console.CursorTop ;
	int y = System.Console.CursorLeft ;
	#endif
	if( xml.Read() )
		{
		switch( xml.NodeType )
			{
			case System.Xml.XmlNodeType.Element:
				{
				string [] s = xml.Name.Split("_-".ToCharArray()) ;
				xml.Read() ;
				string text = xml.Value ;
				return new Token( (char)int.Parse( s[1] ), text ) ; //_point3D:___(s[2,text]),_xor_URN:s[0]:_
				}
			case System.Xml.XmlNodeType.EntityReference:
				{
				string [] s = xml.Name.Split("_".ToCharArray()) ;
				xml.Read() ;
				string text = xml.Value ;
				return new Token( (char)int.Parse( s[2] ), text ) ; //s[1]_estate
				}
			}
		}
	Token t = new Token( '\0', "$end" ) ;
	#if DEBUG_INPUT && CONSOLE
	if( !ended ) prompt( t ) ;
	#endif
	ended = true ;
	#if DEBUG_INPUT
	System.Console.SetCursorPosition(y,x) ;
	#endif
	return t ;
	}

public static string xml_reader()
	{
	return
	 "var s = System.IO.File.OpenText( \"/tmp/" + 0.0.GUID() + ".il.xml\" ) ;\n"
	+"var t = s.ReadToEnd() ;\n"
	+"var e = t.GetEnumerator() ;\n"
	+"//string INSTANCE_entity ;\n"
	+"string n = string.Empty ;\n"
	+"string l = string.Empty ;\n"
	+"string p = string.Empty ;\n"
	+"bool process = false ;\n"
	+"while( e.MoveNext() )\n"
	+"	{\n"
	#if DEBUG
	+"	Current.Interval.NOP() ;\n"
	#endif
	+"	if( e.Current == '<' )\n"
	+"		{\n"
	+"		if( process )\n"
	+"			{ iDNA.Text( l ) ; X.Y.Z( l ) ; }\n"
	+"		l = string.Empty ;\n"
	+"		e.MoveNext() ;\n"
	+"		if( e.Current == '_' )\n"
	+"			{\n"
	+"			process = true ;\n"
	+"			e.MoveNext() ;\n"
	+"			while( e.Current >= '0' && '9' >= e.Current )\n"
	+"				{\n"
	+"				n += e.Current ;\n"
	+"				e.MoveNext() ;\n"
	+"				}\n"
	+"			iDNA.Element( n ) ;\n"
	+"			}\n"
	+"		else\n"
	+"			process = false ;\n"
	+"		while( e.Current != '>' )\n"
	+"			e.MoveNext() ;\n"
	+"		n = string.Empty ;\n"
	+"		continue ;\n"
	+"		}\n"
	+"	if( e.Current == '&' )\n"
	+"		{\n"
	+"		if( process )\n"
	+"			{ iDNA.Text( l ) ; X.Y.Z( l ) ; }\n"
	+"		l = string.Empty ;\n"
	+"		e.MoveNext() ;\n"
	+"		if( e.Current == '_' )\n"
	+"			{\n"
	+"			process = true ;\n"
	+"			e.MoveNext() ;\n"
	+"			/*\n"
	+"			while( e.Current >= '0' && '9' >= e.Current )\n"
	+"				{\n"
	+"				n += e.Current ;\n"
	+"				e.MoveNext() ;\n"
	+"				}\n"
	+"			*/\n"
	+"			while( e.Current != '_' )\n"
	+"				e.MoveNext() ;\n"
	+"			e.MoveNext() ;\n"
	+"			while( e.Current >= '0' && '9' >= e.Current )\n"
	+"				{\n"
	+"				n += e.Current ;\n"
	+"				e.MoveNext() ;\n"
	+"				}\n"
	+"			iDNA.EntityReference( n ) ;\n"
	+"			}\n"
	+"		else\n"
	+"			process = false ;\n"
	+"		while( e.Current != ';' )\n"
	+"			e.MoveNext() ;\n"
	+"		n = string.Empty ;\n"
	+"		continue ;\n"
	+"		}\n"
	+"	if( process )\n"
	+"		{\n"
	+"		l += e.Current ;\n"
	+"		if( p != string.Empty )\n"
	+"			{\n"
	+"			for( int i = int.Parse(p) ; i > 1 ; --i )\n"
	+"				{\n"
	+"				e.MoveNext() ;\n"
	+"				l += e.Current ;\n"
	+"				}\n"
	+"			p = string.Empty ;\n"
	+"			}\n"
	+"		}\n"
	+"	}\n"
	+"s.Close() ;\n" ;
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

