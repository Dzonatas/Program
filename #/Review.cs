using System.Runtime.InteropServices ;
using System.Extensions ;
static class Review	{
static bool cloud ;
public static void Cloud()
	{
	cloud = true ;
	Board() ;
	//vi /tmp/*.[cs|c|h|hpp]  //...->(i.i)
	}
#if !UX
public static void Board()
	{
	var term = System.Environment.GetEnvironmentVariable("TERM") ;
	if( ! ( term == "xterm" || term == "linux" ) )
		return ;
	var w = initscr() ;
	int y = getmaxy(w) ;
	endwin() ;
	var dt = dirent.top(0.1.GUID(),y-3) ;
	if( term != "xterm" )
		return ;
	w = initscr() ;
	cbreak() ;
	noecho() ;
	intrflush(w, false) ;
	keypad(w, true) ;
	wborder(w, 0, 0, 0, 0, 0, 0, 0, 0) ;

	panel_dir(w,dt) ;

	wmove(w,0,0) ;
	wgetch(w) ;
	endwin() ;
	}
#else //i3
public static void Board()
	{
	var term = System.Environment.GetEnvironmentVariable("TERM") ;
	if( ! ( term == "xterm" || term == "linux" ) )
		return ;
	int y ;
	if( term == "xterm" )
		{
		var _w = initscr() ;
		y = getmaxy(_w) ;
		endwin() ;
		}
	else
		y = byte.MaxValue ; //atomically
	var dt = dirent.top(0.1.GUID(),y-3) ;
	if( term != "xterm" )
		return ;
	var w = initscr() ;
	cbreak() ;
	noecho() ;
	intrflush(w, false) ;
	keypad(w, true) ;
	wborder(w, 0, 0, 0, 0, 0, 0, 0, 0) ;

	panel_dir(w,dt) ;

	wmove(w,0,0) ;
	waddstr(w,"<menu><space>&st10xX#") ;
	input:
	var c = wgetch(w) ;
	if( c == 27 )
		i3m( "fullscreen" ) ;
	else
	if( c == 32 )
		i3m( "floating toggle" ) ;
	else
	if( c == '1' )
		i3m( "border 1pixel" ) ;
	else
	if( c == '0' )
		i3m( "border normal" ) ;
	//else
	if( ! ( c == 'x' || c == 'X' ) )
		goto input ;
	endwin() ;
	if( c == 'X' )
		i3m( "exec /usr/bin/xterm" ) ;
	else
		{
		System.Console.WriteLine() ;
		System.Console.WriteLine("c={0} {1}",c,(char)c) ;
		}
	}
static System.Diagnostics.ProcessStartInfo psi ;
static public void i3m( string m )
	{
	if( psi == null )
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/i3-msg" ) ;
		psi.CreateNoWindow           = true ;
		psi.UseShellExecute          = true ;
		//psi.StandardOutputEncoding   = System.Text.Encoding.ASCII ;
		psi.RedirectStandardOutput   = false ;
		psi.RedirectStandardInput    = false ;
		}
	psi.Arguments = m ;
	var p= System.Diagnostics.Process.Start(psi) ;
	p.WaitForExit() ;
	return ;
	}
#endif
class dirent
	{
	string  path ;
	ulong   inode ;
	byte    type ;
	string  name ;
	public static dirent[] top( string path, int entries )
		{
		var d = opendir(path) ;
		var de = new dirent[entries] ;
		int i ;
		const int _PC_NAME_MAX = 3 ;
		var maxd = pathconf(path,_PC_NAME_MAX) ;
		if( maxd > byte.MaxValue || maxd == -1 )
			throw new System.Exception("University.") ;
		var g = Marshal.AllocHGlobal( Marshal.SizeOf(typeof(dirent_t)) ) ;
		var gp = Marshal.AllocHGlobal( Marshal.SizeOf(typeof(System.IntPtr)) ) ;
		for( i = 0 ; i < entries ; /**/ )
			{
			if( 0 != readdir_r(d,g,gp) ) break ;
			var sp = (System.IntPtr) Marshal.PtrToStructure( gp , typeof(System.IntPtr) ) ;
			if( sp == System.IntPtr.Zero ) break ;
			var s = (dirent_t) Marshal.PtrToStructure( sp , typeof(dirent_t) ) ;
			var _dirent   = new dirent() ;
			_dirent.type  = s.type ;
			_dirent.inode = s.inode ;
			_dirent.name  = System.Text.Encoding.ASCII.GetString(s.name) ;
			#if !UTF7
			var z = _dirent.name.IndexOf((char)0) ; //"safe"
			_dirent.name  = System.Text.Encoding.ASCII.GetString(s.name,0,z) ; //fixt
			#endif
			_dirent.path  = path ;
			if( _dirent.name.Contains(".") && _dirent.name[0] != '.' )
				de[i++]         = _dirent ;
			}
		closedir(d) ;
		if( i < entries )
			System.Array.Resize( ref de, i ) ;
		Marshal.FreeHGlobal(g) ;
		Marshal.FreeHGlobal(gp) ;
		return de ;
		}
	public static implicit operator ulong( dirent d )
		{
		return d.inode ;
		}
	public static implicit operator string( dirent d )
		{
		return d.name ;
		}
	}
static void panel_dir(System.IntPtr w, dirent[] dt)
	{
	int i = 1 ;
	int mx = getmaxx(w) ;
	foreach( var p in dt )
		{
		wmove(w,i++,1) ;
		string s = p ;
		int x = s.Length < mx ? s.Length : mx ;
		waddnstr(w,p,x) ;
		}
	}

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   System.IntPtr   initscr() ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             cbreak() ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             noecho() ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             nonl() ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             intrflush(System.IntPtr window, bool value) ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             keypad(System.IntPtr window, bool value) ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             wgetch(System.IntPtr window) ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             endwin() ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             waddch(System.IntPtr window, uint ch) ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             waddstr(System.IntPtr window, string s) ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             waddnstr(System.IntPtr window, string s, int length) ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             wmove(System.IntPtr window, int y, int x) ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             getmaxx(System.IntPtr window) ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             getmaxy(System.IntPtr window) ;

[System.Runtime.InteropServices.DllImport( "libncurses.so.5" )]
public extern  static   int             wborder(System.IntPtr window, uint left, uint right, uint top, uint bot, uint tl, uint tr, uint bl, uint br) ;

[DllImport( "libc.so.6" )]
public extern  static   System.IntPtr   opendir(string path) ;

[DllImport( "libc.so.6" )]
public extern  static   int             closedir(System.IntPtr d) ;

[DllImport( "libc.so.6" )]
public extern  static   System.IntPtr   readdir(System.IntPtr d) ;

[DllImport( "libc.so.6" )]
public extern  static   int             readdir_r(System.IntPtr d, System.IntPtr buffer, System.IntPtr result) ;

[DllImport( "libc.so.6" )]
public extern  static   long            pathconf(string path, int name) ;

[StructLayout(LayoutKind.Sequential)]
struct dirent_t
	{
	public ulong   inode ;
	public long    next  ;
	public ushort  length ;
	public byte    type ;
	[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst=256)]
	public byte[]  name ;
	}
}
