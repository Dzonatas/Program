using X.Predefined ;
using XIP = System.IntPtr ;

namespace X  {
static public partial class Y
			{
			public static System.IntPtr OpenDisplay(this double _, out System.IntPtr display)
			{
			#if ECMA || ( DEBUG || DIRECTX )
			//IceSetHostBasedAuthProc(listener,always_true) ;
			#elif BUILD || ( WIN8 || VAX )
			//IceSetHostBasedAuthProc(listener,trait) ;
			#endif
			switch(_.CompareTo(0.0))
				{
				case 0: return display = display_open(":0") ;
				default:
					{
					string s = _.ToString().Replace(".",":") ;
					return display = display_open(":"+s) ;
					}
				}
			}
		}
}


namespace X {
using System ;
using System.Runtime.InteropServices ;
static public partial class Y
	{
	static Random bit = new Random() ;
	static XIP Display ;
	static XIP Vendor ;
	static public XEvent _event ;
	static internal XIP drawable ;
	static XIP Image ;
	static VisualInfo visual_info ;
	static SetWindowAttributes window_attr ;
	static public void Z( uint x, uint y, int z )
		{
		IntPtr _gc ;
		if( z < 0 ? false : true )
			_gc = c[z] ;
		else
			_gc = gc_erase ;
		if( x < 300 && y < 300 )
			draw_point( Display, drawable, _gc, (int)x, (int)y ) ;
		}
	static public void MapZ()
		{
		Display = display_open( ":0" ) ;
		Vendor  = server_vendor( Display ) ;
		int     s  = screen_default( Display ) ;
		IntPtr  r  = root_window( Display, s ) ;
		IntPtr  d  = default_root_window( Display ) ;
		ulong pixel_border = pixel_server( Display, s ) ;
		ulong pixel_background = pixel_client( Display, s ) ;
		match_visual_info( Display, screen_default(Display), 32, 4, out visual_info );
//		window_attr.colormap = (System.Int32)colormap_create( Display, default_root_window( Display ), visual_info.Visual, 0 ) ;
		//change_window_attributes( Display, drawable, (1L<<13), ref window_attr ) ;
		//drawable = window_create_simple(Display, r, 3, 3, 300, 300, 1, pixel_border, pixel_background ) ;
		window_attr = new SetWindowAttributes() ;
		window_attr.colormap = colormap_create( Display, default_root_window( Display ), visual_info.Visual, 0 ) ;
		window_attr.border_pixel =  0 ; //pixel_border ;
		window_attr.background_pixel = 0 ; //pixel_background ;
		drawable = window_create(Display, d, 3, 3, 300, 300, 1, (int)visual_info.Depth, 1, (XIP)visual_info.Visual, CW.BackPixel | CW.BorderPixel | CW.Colormap, ref window_attr ) ;
		System.Console.WriteLine( "X-ServerVendor: {0}", Vendor ) ;
		padD() ;
		}
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
	static XAnyEvent zone ;
	static public void Sync()
		{
		sync( Display, false ) ;
		}
	static bool next()
		{
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
		return true ;
		}
	static public void Window()
		{
		for(zone = XStart.ip;next();)
			System.Console.WriteLine( "zone: {0} {1}", _event.Type, _event.XAny.Serial ) ;
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
	static public void Z( uint x, uint y, int r, int g, int b )
		{
		values.PlaneMask = (ulong)( r<<16 | g<<8 | b ) ;
		gc_change( Display, gc, GCValue.PlaneMask, ref values ) ;
		if( x < 300 && y < 300 )
			draw_point( Display, drawable, gc, (int)x, (int)y ) ;
		}
	[DllImport("libX11", EntryPoint = "XDefaultRootWindow")] extern static IntPtr default_root_window(IntPtr display) ;
	[DllImport("libX11", EntryPoint = "XDrawPoint")] extern static IntPtr draw_point(XIP display, XIP drawable, XIP gc, int x, int y )  ;
	[DllImport("libX11", EntryPoint = "XRootWindow")] extern internal static IntPtr root_window(IntPtr display, int screen) ;
	[DllImport("libX11", EntryPoint = "XBlackPixel")] extern static ulong pixel_client(System.IntPtr display, int scrnum )  ;
	[DllImport("libX11", EntryPoint = "XWhitePixel")] extern static ulong pixel_server(System.IntPtr display, int scrnum )  ;
	[DllImport("libX11", EntryPoint = "XOpenDisplay")] extern static IntPtr display_open([MarshalAs(UnmanagedType.LPStr)] string display ) ;
	[DllImport("libX11", EntryPoint = "XServerVendor")] extern static IntPtr server_vendor(IntPtr display) ;
	[DllImport("libX11", EntryPoint = "XDefaultScreen")] extern static int screen_default(System.IntPtr display)  ;
	[DllImport("libX11", EntryPoint = "XCreateSimpleWindow")] extern static XIP window_create_simple(XIP display, XIP window, int x, int y, uint width, uint height, uint border_width, ulong border, ulong background) ;
	[DllImport("libX11", EntryPoint = "XCreateWindow")] extern static XIP window_create(XIP display, XIP sid, int x, int y, uint width, uint height, uint border_width, int depth, uint clas_, XIP visual, ulong mask, ref SetWindowAttributes attributes ) ;
	[DllImport("libX11", EntryPoint = "XCreateGC")]    extern static IntPtr gc_create(XIP display, XIP d, ulong value_mask, ref Values values)  ;
	[DllImport("libX11", EntryPoint = "XGetGCValues")] extern static void gc_values(IntPtr display, IntPtr gc, ulong valuemask, out Values values )  ;
	[DllImport("libX11", EntryPoint = "XDefaultGC")]   extern static IntPtr gc_default(System.IntPtr display, int scrnum )  ;
	[DllImport("libX11", EntryPoint = "XSelectInput")] extern static IntPtr select_input(System.IntPtr display, XIP d, ulong fg )  ;
	[DllImport("libX11", EntryPoint = "XMapWindow")]   extern static void map_window(IntPtr display, IntPtr window) ;
	[DllImport("libX11", EntryPoint = "XNextEvent")]   extern static void next_event(IntPtr display, out XEvent _event) ;
	[DllImport("libX11", EntryPoint = "XPeekEvent")]   extern static void peek_event(IntPtr display, out XEvent _event) ;
	[DllImport("libX11", EntryPoint = "XChangeGC")] extern static void gc_change(IntPtr display, IntPtr gc, ulong valuemask, ref Values values )  ;
	[DllImport("libX11", EntryPoint = "XMatchVisualInfo")] extern static void match_visual_info(IntPtr display, int scrnum, int depth, int _class, out X.Predefined.VisualInfo info )  ;
	[DllImport("libX11", EntryPoint = "XSetWindowColormap")] extern static void set_window_colormap(System.IntPtr display, XIP drawable, IntPtr colormap )  ;
	[DllImport("libX11", EntryPoint = "XCreateColormap")] extern static IntPtr colormap_create( XIP display, XIP drawable, XIP visual, int alloc )  ;
	[DllImport("libX11", EntryPoint = "XChangeWindowAttributes")] extern static void change_window_attributes(IntPtr display, IntPtr drawable, ulong valuemask, ref SetWindowAttributes values ) ;
	[DllImport("libX11", EntryPoint = "XSync")]   extern static void sync(IntPtr display, bool discard) ;
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
