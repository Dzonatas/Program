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
		public static long Function          = (1L<<0) ;
		public static long PlaneMask         = (1L<<1) ;
		public static long Foreground        = (1L<<2) ;
		public static long Background        = (1L<<3) ;
		public static long LineWidth         = (1L<<4) ;
		public static long LineStyle         = (1L<<5) ;
		public static long CapStyle          = (1L<<6) ;
		public static long JoinStyle         = (1L<<7) ;
		public static long FillStyle         = (1L<<8) ;
		public static long FillRule          = (1L<<9) ;
		public static long Tile              = (1L<<10) ;
		public static long Stipple           = (1L<<11) ;
		public static long TileStipXOrigin   = (1L<<12) ;
		public static long TileStipYOrigin   = (1L<<13) ;
		public static long Font              = (1L<<14) ;
		public static long SubwindowMode     = (1L<<15) ;
		public static long GraphicsExposures = (1L<<16) ;
		public static long ClipXOrigin       = (1L<<17) ;
		public static long ClipYOrigin       = (1L<<18) ;
		public static long ClipMask          = (1L<<19) ;
		public static long DashOffset        = (1L<<20) ;
		public static long DashList          = (1L<<21) ;
		public static long ArcMode           = (1L<<22) ;
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

	[StructLayout(LayoutKind.Explicit)]
	public struct XEvent {
		[FieldOffset(0)] public int          Type  ; /* must not be changed */
		[FieldOffset(0)] public XAnyEvent    XAny  ;
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

}

