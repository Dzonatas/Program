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
	var win = initscr() ;
	//cbreak() ;
	//noecho() ;
	//intrflush(win, false) ;
	//keypad(win, true) ;
	wgetch(win) ;
	endwin() ;
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
}
