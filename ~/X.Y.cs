using X.Predefined ;
using XIP = System.IntPtr ;

namespace X {
using System ;
using System.Runtime.InteropServices ;
static public partial class Y
	{
	static public void Z( uint x, uint y, int z )
		{
		Point_t p = new Point_t( (ushort)x, (ushort)y ) ;
//		p.x = (ushort)x ;
//		p.y = (ushort)y ;
		/*
		IntPtr _gc ;
		if( z < 0 ? false : true )
			_gc = c[z] ;
		else
			_gc = gc_erase ;
		*/
		if( x < 300 && y < 300 )
			xcb_poly_point( ki, 0, _window, foreground, (uint)1, ref p ) ;
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

		_window    = xcb_generate_id( ki ) ;
		mask       = 2 | 2048 ;  //cw_back_pixel|cw_event_mask
		Values2 vv = new Values2( s.white_pixel , 32768 ) ; //event_mask_expose

		xcb_create_window( ki, 0, _window, root, 0, 0, 800, 1280, 1, 1, s.root_visual, mask, ref vv ) ;
		xcb_map_window( ki, _window ) ;
		xcb_flush( ki ) ;

		var e = xcb_wait_for_event( ki ) ;
		xcb_free( e ) ;

		//padD() ;
		}
	/*
	static Values values ;
	static internal XIP gc ;
	static internal XIP gc_erase ;
	static public ulong   mask = GCValue.Function | GCValue.PlaneMask | GCValue.Background | GCValue.Foreground ;
	static void padD()
		{
		values.Function  = GX.Clear ;
		gc_erase = gc_create( Display, drawable, GCValue.Function, ref values ) ;
		gc_values( Display, gc_default(Display,screen_default(Display)), mask, out values ) ;
		values.Function  = GX.Set ;
		gc = gc_create( Display, drawable, mask, ref values ) ;
		select_input( Display, drawable, 0xFFFFFF ) ;
		mapD() ;
		}
	*/
	/*
	static XIP[] c ;
	static void mapD()
		{
		c = new XIP[6] ;
		for( int i = 0 ; i < 6 ; i++ )
			{
			values.PlaneMask = cs6(i) ;
			c[i] = gc_create( Display, drawable, mask, ref values ) ;
			}
		map_window( Display, drawable ) ;
		}
	static ulong cs6( int i )
		{
		switch( i )
			{
			case 0 : return global::X.Predefined.Color.AluminiumExtraLight ;
			case 1 : return global::X.Predefined.Color.AluminiumLight ;
			case 2 : return global::X.Predefined.Color.AluminiumMediumLight ;
			case 3 : return global::X.Predefined.Color.AluminiumMediumDark ;
			case 4 : return global::X.Predefined.Color.AluminiumDark ;
			case 5 :
			default : return global::X.Predefined.Color.AluminiumExtraDark ;
			}
		}
	*/
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
	static ulong serial ;
	static ulong window = 3 ;
	static ulong response( ref XAnyEvent e )
		{
		switch( e.Type )
			{
			case 0 : return global::X.Predefined.Color.AluminiumExtraLight ;
			case 1 : return global::X.Predefined.Color.AluminiumLight ;
			case 2 : return global::X.Predefined.Color.AluminiumMediumLight ;
			case 3 : return global::X.Predefined.Color.AluminiumMediumDark ;
			case 4 : return global::X.Predefined.Color.AluminiumDark ;
			case 5 : return global::X.Predefined.Color.AluminiumExtraDark ;
			}
		if( serial == e.Serial )
			++window ;
		else
			window = 3 ;
		serial = e.Serial ;
		switch( window )
			{
			case 0 : return global::X.Predefined.Color.Butter ;
			case 1 : return global::X.Predefined.Color.Orange ;
			case 2 : return global::X.Predefined.Color.Chocolate ;
			case 3 : return global::X.Predefined.Color.Chameleon ;
			case 4 : return global::X.Predefined.Color.SkyBlue ;
			case 5 : return global::X.Predefined.Color.Plum ;
			case 6 : return global::X.Predefined.Color.ScarletRed ;
			default: return ( e.SendEvent ? ulong.MinValue : 0xFFFFFF ) ;
			}
		}
	static public void QuickResponseEncodedSplash( ref XAnyEvent e )
		{
		//values.PlaneMask = response( ref e ) ;
		//gc_change( Display, gc, GCValue.PlaneMask, ref values ) ;
		for( uint x = 0 ; x < 300 ; x++ )
			for( uint y = 0 ; y < 300 ; y++ )
				X.Y.Z( y, x, 1 ) ;
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
