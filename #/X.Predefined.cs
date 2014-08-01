namespace X.Predefined
	{
	using System.Runtime.InteropServices ;

	using KeySym    = System.IntPtr ;         //_symbolic_form_with_cultural_extensions,_UNIX(TM)
	using iKeySym   = System.IntPtr ;         //_hardware_hack,_MAC,_IPv6,Token<COLOREDMAP>,_LOGO
	using Pixmap    = System.IntPtr ;
	using Font      = System.IntPtr ;
	using Drawable  = System.IntPtr ;         //_window,_pixmap
	using Rectangle = System.IntPtr ;         //X-defined-default:[x,y]:=upper-left
	using Colormap  = System.IntPtr ;
	using Display   = System.IntPtr ;
	using Visual    = System.IntPtr ;

	public enum Atom
		{
		Default,
		Primary,            Secondary,           Arc,              Atom,              Bitmap,
		Cardinal,           Colormap,            Cursor,           CutBuffer0,        CutBuffer1,
		CutBuffer2,         CutBuffer3,          CutBuffer4,       CutBuffer5,        CutBuffer6,
		CutBuffer7,         Drawable,            Font,             Integer,           Pixmap,
		Point,              Rectangle,           ResourceManager,  RGB_Color_map,     RGB_Best_map,
		RGB_Blue_map,       RGB_Default_map,     RGB_Gray_map,     RGB_Green_map,     RGB_Red_map,
		String,             VisualID,            Window,           WM_Command,        WM_Hints,
		WM_ClientMachine,   WM_IconName,         WM_IconSize,      WM_Name,           WM_NormalHints,
		WM_SizeHints,       WM_ZoomHints,        MinSpace,         NormSpace,         MaxSpace,
		EndSpace,           SuperscriptX,        SuperscriptY,     SubscriptX,        SubscriptY,
		UnderlinePosition,  UnderlineThickness,  StrikeoutAscent,  StrikeoutDescent,  ItalicAngle,
		X_Height,           QuadWidth,           Weight,           PointSize,         Resolution,
		Copyright,          Notice,              FontName,         URN,               FullName,
		CapHeight,          WM_Class,            WM_TransientFor
		}

	static class Symbol
		{
		static readonly KeySym   SCROLL_LOCK    = (KeySym)  0xFF14 ;
		static          iKeySym  SCROLL         = (iKeySym) null   ;
		static          iKeySym  LOCK           = (iKeySym) null   ;
		static readonly KeySym   PAUSE_BREAK    = (KeySym)  null   ;
		static          iKeySym  PAUSE          = (iKeySym) 0xFF13 ;
		static          iKeySym  BREAK          = (iKeySym) 0xFF6B ;
		static readonly KeySym   PRTSCR_SYSREQ  = (KeySym)  null   ;
		static          iKeySym  PRINT_SCREEN   = (iKeySym) null   ;
		static          iKeySym  PRINT          = (iKeySym) 0xFF61 ;
		static          iKeySym  SCREEN         = (iKeySym) null   ;
		static          iKeySym  SYSTEM_REQUEST = (iKeySym) 0xFF15 ;
		static          iKeySym  SYSTEM         = (iKeySym) null   ;
		static          iKeySym  REQUEST        = (iKeySym) null   ;
		}

	[StructLayout(LayoutKind.Sequential)]
	public struct Values {              /* Imported page 115 libX11.pdf. */
		public int     Function              ; /* logical operation */
		public ulong   PlaneMask             ; /* plane mask */
		public ulong   Foreground            ; /* foreground pixel */
		public ulong   Background            ; /* background pixel */
		public int     LineWidth             ; /* line width (in pixels) */
		int            LineStyle             ; /* LineSolid, LineOnOffDash, LineDoubleDash */
		int            CapStyle              ; /* CapNotLast, CapButt, CapRound, CapProjecting */
		int            JoinStyle             ; /* JoinMiter, JoinRound, JoinBevel */
		int            FillStyle             ; /* FillSolid, FillTiled, FillStippled FillOpaqueStippled*/
		int            FillRule              ; /* EvenOddRule, WindingRule */
		int            ArcMode               ; /* ArcChord, ArcPieSlice */
		Pixmap         Tile                  ; /* tile pixmap for tiling operations */
		Pixmap         Stipple               ; /* stipple 1 plane pixmap for stippling */
		int            TsXOrigin             ; /* offset for tile or stipple operations */
		int            TsYOrigin             ;
		Font           Font                  ; /* default text font for text operations */
		int            SubwindowMode         ; /* ClipByChildren, IncludeInferiors */
		public bool    GraphicsExposures     ; /* boolean, should exposures be generated */
		int            ClipXOrigin           ; /* origin for clipping */
		int            ClipYOrigin           ;
		Pixmap         ClipMask              ; /* bitmap clipping; other calls for rects */
		int            DashOffset            ; /* patterned/dashed line information */
		char           Dashes                ;
		} /* C */ ;

	public static class GCValue
		{
		public static ulong Function          = (1L<<0) ;
		public static ulong PlaneMask         = (1L<<1) ;
		public static ulong Foreground        = (1L<<2) ;
		public static ulong Background        = (1L<<3) ;
		public static ulong LineWidth         = (1L<<4) ;
		public static ulong LineStyle         = (1L<<5) ;
		public static ulong CapStyle          = (1L<<6) ;
		public static ulong JoinStyle         = (1L<<7) ;
		public static ulong FillStyle         = (1L<<8) ;
		public static ulong FillRule          = (1L<<9) ;
		public static ulong Tile              = (1L<<10) ;
		public static ulong Stipple           = (1L<<11) ;
		public static ulong TileStipXOrigin   = (1L<<12) ;
		public static ulong TileStipYOrigin   = (1L<<13) ;
		public static ulong Font              = (1L<<14) ;
		public static ulong SubwindowMode     = (1L<<15) ;
		public static ulong GraphicsExposures = (1L<<16) ;
		public static ulong ClipXOrigin       = (1L<<17) ;
		public static ulong ClipYOrigin       = (1L<<18) ;
		public static ulong ClipMask          = (1L<<19) ;
		public static ulong DashOffset        = (1L<<20) ;
		public static ulong DashList          = (1L<<21) ;
		public static ulong ArcMode           = (1L<<22) ;
		public static long Simple            = (1L<<23)-1 ;
		}

	public static class GX
		{
		public static int  Clear           = 0x0 ; // 0
		public static int  And             = 0x1 ; // src AND dst
		public static int  AndReverse      = 0x2 ; // src AND NOT dst
		public static int  Copy            = 0x3 ; // src
		public static int  AndInverted     = 0x4 ; // (NOT src) AND dst
		public static int  Noop            = 0x5 ; // dst
		public static int  Xor             = 0x6 ; // src XOR dst
		public static int  Or              = 0x7 ; // src OR dst
		public static int  Nor             = 0x8 ; // (NOT src) AND (NOT dst)
		public static int  Equiv           = 0x9 ; // (NOT src) XOR dst
		public static int  Invert          = 0xa ; // NOT dst
		public static int  OrReverse       = 0xb ; // src OR (NOT dst)
		public static int  CopyInverted    = 0xc ; // NOT src
		public static int  OrInverted      = 0xd ; // (NOT src) OR dst
		public static int  Nand            = 0xe ; // (NOT src) OR (NOT dst)
		public static int  Set             = 0xf ; // 1
		}

	[StructLayout(LayoutKind.Sequential)]
	public struct XColor
		{
		public ulong  Pixel                      ; /* pixel value */
		public ushort Red, Green, Blue           ; /* rgb values */
		public char   Flags                      ; /* DoRed, DoGreen, DoBlue */
		char pad;
		}

	[StructLayout(LayoutKind.Sequential,Size=1024)]
	public struct XAnyEvent
		{
		public int           Type                 ;
		public ulong         Serial               ; /* # of last request processed by server */
		public bool          SendEvent            ; /* true if this came from a SendEvent request */
		public Display       Display              ; /* Display the event was read from */
		public Drawable      Window               ;
		//long[] pad ; //24
		}

	[StructLayout(LayoutKind.Sequential)]
	public struct XC_Event
		{
		public int           Type                 ;
		public ulong         Serial               ; /* # of last request processed by server */
		public bool          SendEvent            ; /* true if this came from a SendEvent request */
		public Display       Display              ; /* Display the event was read from */
		public Drawable      Window               ;
		public System.IntPtr CodePage             ;
		/* C# */
		}

	[StructLayout(LayoutKind.Explicit)]
	public struct XEvent {
		[FieldOffset(0)] public int          Type  ; /* must not be changed */
		[FieldOffset(0)] public XAnyEvent    XAny  ;
		[FieldOffset(0)] public XC_Event     XCC   ; //_CSS,_MAP,"work",code...
		/*
		XKeyEvent xkey;
		XButtonEvent xbutton;
		XMotionEvent xmotion;
		XCrossingEvent xcrossing;
		XFocusChangeEvent xfocus;
		XExposeEvent xexpose;
		XGraphicsExposeEvent xgraphicsexpose;
		XNoExposeEvent xnoexpose;
		XVisibilityEvent xvisibility;
		XCreateWindowEvent xcreatewindow;
		XDestroyWindowEvent xdestroywindow;
		XUnmapEvent xunmap;
		XMapEvent xmap;
		XMapRequestEvent xmaprequest;
		XReparentEvent xreparent;
		XConfigureEvent xconfigure;
		XGravityEvent xgravity;
		XResizeRequestEvent xresizerequest;
		XConfigureRequestEvent xconfigurerequest;
		XCirculateEvent xcirculate;
		XCirculateRequestEvent xcirculaterequest;
		XPropertyEvent xproperty;
		XSelectionClearEvent xselectionclear;
		XSelectionRequestEvent xselectionrequest;
		XSelectionEvent xselection;
		XColormapEvent xcolormap;
		XClientMessageEvent xclient;
		XMappingEvent xmapping;
		XErrorEvent xerror;
		XKeymapEvent xkeymap;
		long pad[24];
		*/
	} /* C */ ;

	public class Color
		{
		// Tango Palette
		public const ulong      ButterLight          = 0xfce94f ;
		public const ulong      Butter               = 0xEDD400 ;
		public const ulong      ButterDark           = 0xc4a000 ;
		public const ulong      OrangeLight          = 0xfcaf3e ;
		public const ulong      Orange               = 0xF57900 ;
		public const ulong      OrangeDark           = 0xce5c00 ;
		public const ulong      ChocolateLight       = 0xe9b96e ;
		public const ulong      Chocolate            = 0xC17D11 ;
		public const ulong      ChocolateDark        = 0x8f5902 ;
		public const ulong      ChameleonLight       = 0x8ae234 ;
		public const ulong      Chameleon            = 0x73D216 ;
		public const ulong      ChameleonDark        = 0x4e9a06 ;
		public const ulong      SkyBlueLight         = 0x729fcf ;
		public const ulong      SkyBlue              = 0x3465a4 ;
		public const ulong      SkyBlueDark          = 0x204A87 ;
		public const ulong      PlumLight            = 0xad7fa8 ;
		public const ulong      Plum                 = 0x75507B ;
		public const ulong      PlumDark             = 0x5c3566 ;
		public const ulong      ScarletRedLight      = 0xef2929 ;
		public const ulong      ScarletRed           = 0xCC0000 ;
		public const ulong      ScarletRedDark       = 0xa40000 ;
		public const ulong      AluminiumExtraLight  = 0xEEEEEC ;
		public const ulong      AluminiumLight       = 0xD3D7CF ;
		public const ulong      AluminiumMediumLight = 0xBABDB6 ;
		public const ulong      AluminiumMediumDark  = 0x888A85 ;
		public const ulong      AluminiumDark        = 0x555753 ;
		public const ulong      AluminiumExtraDark   = 0x2e3426 ;
		}

	[StructLayout(LayoutKind.Sequential)]
	public struct VisualInfo
		{
		public System.IntPtr  Visual ;
		public System.Int64   VisualID ;
		public System.Int32   Screen ;
		public System.UInt32  Depth ;
		public System.Int32   Class ;
		public System.Int64   RedMask ;
		public System.Int64   GreenMask ;
		public System.Int64   BlueMask ;
		public System.Int32   ColormapSize ;
		public System.Int32   BitsPerRGB ;
		}

	[StructLayout(LayoutKind.Sequential)]
	public struct SetWindowAttributes
		{
		public System.Int32 background_pixmap; /* background, None, or ParentRelative */
		public ulong background_pixel; /* background pixel */
		public System.Int32 border_pixmap; /* border of the window or CopyFromParent */
		public ulong border_pixel; /* border pixel value */
		public int bit_gravity; /* one of bit gravity values */
		public int win_gravity; /* one of the window gravity values */
		public int backing_store; /* NotUseful, WhenMapped, Always */
		public ulong backing_planes; /* planes to be preserved if possible */
		public ulong backing_pixel; /* value to use in restoring planes */
		public bool save_under; /* should bits under be saved? (popups) */
		public long event_mask; /* set of events that should be saved */
		public long do_not_propagate_mask; /* set of events that should not propagate */
		public bool override_redirect; /* boolean value for override_redirect */
		public System.IntPtr colormap; /* color map to be associated with window */
		public System.IntPtr cursor; /* cursor to be displayed (or None) */
		}

	public static class CW
		{
		public static ulong 	BackPixmap       = (1L<<0)  ;
		public static ulong 	BackPixel        = (1L<<1)  ;
		public static ulong 	BorderPixmap     = (1L<<2)  ;
		public static ulong 	BorderPixel      = (1L<<3)  ;
		public static ulong 	BitGravity       = (1L<<4)  ;
		public static ulong 	WinGravity       = (1L<<5)  ;
		public static ulong 	BackingStore     = (1L<<6)  ;
		public static ulong 	BackingPlanes    = (1L<<7)  ;
		public static ulong 	BackingPixel     = (1L<<8)  ;
		public static ulong 	OverrideRedirect = (1L<<9)  ;
		public static ulong 	SaveUnder        = (1L<<10) ;
		public static ulong 	EventMask        = (1L<<11) ;
		public static ulong 	DontPropagate    = (1L<<12) ;
		public static ulong 	Colormap         = (1L<<13) ;
		public static ulong 	Cursor           = (1L<<14) ;
		}
}
