using System.Runtime.InteropServices ;
using System.Extensions ;
static class Review	{
public static void Cloud()
	{
	Board() ;
	//vi /tmp/*.[cs|c|h|hpp]  //...->(i.i)
	}
public static void Board()
	{
	var term = System.Environment.GetEnvironmentVariable("TERM") ;
	if( term != "xterm" )
		return ;
	var w = initscr() ;
	cbreak() ;
	noecho() ;
	intrflush(w, false) ;
	keypad(w, true) ;
	wborder(w, 0, 0, 0, 0, 0, 0, 0, 0) ;

	panel_dir(w,0.1.GUID()) ;

	wmove(w,0,0) ;
	wgetch(w) ;
	endwin() ;
	}
static void panel_dir(System.IntPtr w, string path)
	{
	var d = opendir(path) ;
	var e = readdir(d) ;
	int i = 1 ;
	int x = getmaxx(w) ;
	while( e != System.IntPtr.Zero )
		{
		var s = (dirent_t) Marshal.PtrToStructure( e , typeof(dirent_t) ) ;
		var t = System.Text.Encoding.ASCII.GetString(s.name) ;
		wmove(w,i++,1) ;
		waddnstr(w,t,x) ;
		e = readdir(d) ;
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
