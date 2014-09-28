using X.Predefined ;
using XIP = System.IntPtr ;

namespace X {
using System ;
using System.Runtime.InteropServices ;
static public partial class Y
	{
	static readonly ulong[] aluminate =
		{
		global::X.Predefined.Color.AluminiumExtraLight,
		global::X.Predefined.Color.AluminiumLight,
		global::X.Predefined.Color.AluminiumMediumLight,
		global::X.Predefined.Color.AluminiumMediumDark,
		global::X.Predefined.Color.AluminiumDark,
		global::X.Predefined.Color.AluminiumExtraDark
		} ;
	static uint[] _aluminate ;
	static readonly ulong[] palette =
		{
		0 ,
		global::X.Predefined.Color.Butter,
		global::X.Predefined.Color.Orange,
		global::X.Predefined.Color.Chocolate,
		global::X.Predefined.Color.Chameleon,
		global::X.Predefined.Color.SkyBlue,
		global::X.Predefined.Color.Plum,
		global::X.Predefined.Color.ScarletRed
		} ;
	static uint[] _palette ;
	static public void Z( uint x, uint y, int z )
		{
		Point_t p = new Point_t( (ushort)x, (ushort)y ) ;
		if( x < 300 && y < 300 )
			xcb_poly_point( ki, 0, _window, _palette[z], (uint)1, ref p ) ;
		}
	static XIP ki ;
	static XIP setup ;
	static int screen_i ;
	static XIP screen ;
	static uint root ;
	static uint foreground ;
	static uint _window ;
	static public void MapZ()
		{
		ki         = xcb_connect( ":0", out screen_i ) ;
		setup      = xcb_get_setup( ki ) ;
		screen     = xcb_setup_roots_iterator( setup ).screen ;
		var s      = (Screen_t) Marshal.PtrToStructure( screen , typeof(Screen_t) ) ;
		root       = s.root ;
		foreground = xcb_generate_id( ki ) ;
		uint mask  = 4 | 65536 ; //foreground|graphic_expose
		Values2 v  = new Values2( s.black_pixel , 0 ) ;

		xcb_create_gc( ki, foreground, root, mask, ref v ) ;

		mask       = 2 | 65536 ; //planemask|graphic_expose
		_aluminate = new uint[aluminate.Length] ;
		for( int i = 0 ; i < aluminate.Length ; i++ )
			{
			_aluminate[i] = xcb_generate_id( ki ) ;
			v._0  = (uint)aluminate[i] ;
			xcb_create_gc( ki, _aluminate[i], root, mask, ref v ) ;
			}
		_palette   = new uint[palette.Length] ;
		for( int i = 1 ; i < palette.Length ; i++ )
			{
			_palette[i] = xcb_generate_id( ki ) ;
			v._0  = (uint)palette[i] ;
			xcb_create_gc( ki, _palette[i], root, mask, ref v ) ;
			}
		mask      = 1  ;        //function
		_palette[0] = xcb_generate_id( ki ) ;
		v._0  = 0 ; //clear
		xcb_create_gc( ki, _palette[0], root, mask, ref v ) ;

		_window    = xcb_generate_id( ki ) ;
		mask       = 2 | 2048 ;  //cw_back_pixel|cw_event_mask
		Values2 vv = new Values2( s.white_pixel , 32768 ) ; //event_mask_expose

		xcb_create_window( ki, 0, _window, root, 0, 0, 800, 1280, 1, 1, s.root_visual, mask, ref vv ) ;
		xcb_map_window( ki, _window ) ;
		xcb_flush( ki ) ;

		var e = xcb_wait_for_event( ki ) ;
		xcb_free( e ) ;

		}
	static XAnyEvent zone ;
	static public void Sync()
		{
		xcb_flush( ki ) ;
		//sync( Display, false ) ;
		}
	static bool next()
		{
		var e = xcb_wait_for_event( ki ) ;
		xcb_free( e ) ;
		/*
		next_event( Display, out _event ) ;
		switch( _event.Type )
			{
			case 4:
				if( zone.Type != _event.Type )
					{
					XStart.ip = zone ;
					return false ;
					}
				break ;
			case 5:
				if( zone.Type != _event.Type )
					{
					XStop.time = zone ;
					return false ;
					}
				break ;
			default:
				zone = _event.XAny ;
				//QuickResponseEncodedSplash( ref _event.XAny ) ;
				return true ;
			}
		*/
		return true ;
		}
	static public void Window()
		{
		/*
		for(zone = XStart.ip;next();)
			System.Console.WriteLine( "zone: {0} {1}", _event.Type, _event.XAny.Serial ) ;
		*/
		}
	static public void Next()
		{
		next() ;
		}
	class XStart : A335.Zone.Start
		{
		public static XAnyEvent ip = new XAnyEvent() ;
		}
	class XStop  : A335.Zone.Stop
		{
		public static XAnyEvent time = new XAnyEvent() ;
		}
	static int px = 20 ;
	static int py = 20 ;
	static public void Print( string text )
		{
		//rectify( Display, drawable, overlay, 0, 0 ) ;
		/*
		int x = px ;
		XIP f = query_font( Display, gcontext_from_gc( gc ) ) ;
		int w = text_width( f, text, text.Length ) ;
		px += w ;
		if( px > 280 )
			{
			x = px = 20 ;
			py += 20 ;
			}
		draw_string( Display, drawable, gc, x, py, text, text.Length ) ;
		*/
		System.Console.Write( text ) ;
		}
		/*
	static public void Z( uint x, uint y, int r, int g, int b )
		{
		//values.PlaneMask = (ulong)( r<<16 | g<<8 | b ) ;
		//gc_change( Display, gc, GCValue.PlaneMask, ref values ) ;
		if( x < 300 && y < 300 )
			draw_point( Display, drawable, gc, (int)x, (int)y ) ;
		}
		*/
	[DllImport("libxcb.so.1")] extern static XIP              xcb_connect( string display, out int screen ) ;
	[DllImport("libxcb.so.1")] extern static uint             xcb_generate_id( XIP connection ) ;
	[DllImport("libxcb.so.1")] extern static XIP              xcb_get_setup( XIP connection ) ;
	[DllImport("libxcb.so.1")] extern static ScreenIterator   xcb_setup_roots_iterator( XIP setup ) ;
	[DllImport("libxcb.so.1")] extern static uint             xcb_create_gc( XIP connection, uint foreground, uint window, uint mask, ref Values2 values ) ;
	[DllImport("libxcb.so.1")] extern static uint             xcb_create_window( XIP connection, byte depth, uint window, uint sid, short x, short y, ushort width, ushort height, ushort border, ushort _class, uint visual, uint mask, ref Values2 values ) ;
	[DllImport("libxcb.so.1")] extern static uint             xcb_map_window( XIP connection, uint window ) ;
	[DllImport("libxcb.so.1")] extern static uint             xcb_flush( XIP connection ) ;
	[DllImport("libxcb.so.1")] extern static XIP              xcb_wait_for_event( XIP connection ) ;
	[DllImport("libc.so.6", EntryPoint="free")] extern static void             xcb_free( XIP memory ) ;
	[DllImport("libxcb.so.1")] extern static XIP              xcb_poly_point( XIP connection, byte mode, uint drawable, uint gc, uint npoints, ref Point_t point ) ;
	}
}

namespace Current {
public static class Interval
	{
	static int nop = 0 ;
	static Interval()
		{
		psi = new System.Diagnostics.ProcessStartInfo( "/bin/sleep", "0" ) ;
		psi.UseShellExecute          = false ;
		psi.RedirectStandardOutput   = false ;
		psi.RedirectStandardInput    = false ;
		psi.CreateNoWindow           = true ;
		}
	public static void NOP()
		{
		var p = System.Diagnostics.Process.Start(psi) ;
		p.WaitForExit() ;
		p.Close() ;
		X.Y.Sync() ;
		}
	internal static System.Diagnostics.ProcessStartInfo psi ;
	}
}
