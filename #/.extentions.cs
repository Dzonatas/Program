namespace System.Extensions
	{
	using System.Text.RegularExpressions ;
	using System.Runtime.InteropServices ;
	using System.Drawing ;
	using X.Predefined ;
	using Drawable  = System.IntPtr ;         //_window,_pixmap
	using Rectangle = System.IntPtr ;         //X-defined-default:[x,y]:=upper-left
	#if SCREEN
	using Screen    = _.screen ;
	#endif
	public enum _var
		{
		DEFAULT,                             //"Native Variant"
		COMPUTED_SQSTRING,                   //https://plus.google.com/113166633786671863217/posts/1az1UfVuWmW
		XELF                                 //rooted-X11-o,XOpenDisplay(IntPtr),...
		}
	public static class var_
		{
		static int digits ;
		static System.Decimal sid ;
		public static int _(this int d)
			{
			switch(d)
				{
				case (int)_var.DEFAULT: return digits ;
				default: return ((sid - (System.Decimal)digits) > 0.0m) ? (int)_var.DEFAULT : d ;
				}
			//throw new Exception("[Affinity]=[Infinite]+[Finite]") ;
			}
		public static int _default(this int d, int _sid)
			{
			return digits = (int) System.Decimal.Truncate(sid = _sid) ;
			}
		public static int _default(this int d, System.Decimal _sid)
			{
			return digits = (int) System.Decimal.Truncate(sid = _sid) ;
			}
		public static int node(this int d, int M, int N) //inode ~:= ʄnode
			{
			return 0 ; //i<1.000…<HDR
			}
		public static void Beep(this int d)
			{
			#if SCREEN
			Screen.Glitched(d) ;
			#endif
			}

		public static A335.C_Type UnsignedInt(this System.Guid d)
			{
			string id = "_" + System.Text.RegularExpressions.Regex.Replace( d.ToString(), "[^A-Za-z_0-9]", "_").ToLower() ;
			id += "_unsigned_int" ;
			return A335.C_Type.Acquire( id ) ;
			}
		public static A335.C_Type Char_(this System.Guid d)
			{
			string id = "_" + System.Text.RegularExpressions.Regex.Replace( d.ToString(), "[^A-Za-z_0-9]", "_").ToLower() ;
			id += "_char_p" ;
			return A335.C_Type.Acquire( id ) ;
			}
		public static string ToID(this System.Guid d)
			{
			return Regex.Replace( d.ToString(), "[^A-Za-z_0-9]", "_").ToLower() ;
			}
		public static string ToStemString(this string d)
			{
			string a = d ;
			a = Regex.Replace( a, "[^A-Za-z_0-9]", "_") ;
			a = a.ToUpper() ;
			return "_" + a ;
			//return "_" + Regex.Replace( d, "[^A-Za-z_0-9]", "_").ToUpper() ;
			}

		//[Oprand({'B', 'l'})]
		[DllImport("libX11", EntryPoint = "XOpenDisplay")]
			extern static IntPtr display_open([MarshalAs(UnmanagedType.LPStr)] string display ) ;
			public static void OpenDisplay(this string _, out IntPtr display)
			{
			#if DEBUG || DIRECTX
			//IceSetHostBasedAuthProc(listener,always_true) ;
			#elif WIN8 || VAX
			//IceSetHostBasedAuthProc(listener,trait) ;
			#endif
			display = display_open(_) ;
			}

		[DllImport("libX11", EntryPoint = "XServerVendor")]
			extern static string server_vendor(IntPtr display) ;
			public static string ServerVendor(this IntPtr display)
			{
			return server_vendor( display ) ;
			}

		[DllImport("libX11", EntryPoint = "XCreateSimpleWindow")]
			extern static IntPtr window_create_simple(IntPtr display, IntPtr window, int x, int y, uint width, uint height, uint border_width, ulong border, ulong background) ;
			public static void CreateSimpleWindow(this IntPtr display, out Drawable d )
			{
			int     s  = screen_default(display) ;
			IntPtr  r  = root_window( display, s ) ;
			ulong pixel_border = pixel_server( display, s ) ;
			ulong pixel_background = pixel_client( display, s ) ;
			d = window_create_simple(display, r, 3, 3, 300, 300, 1, pixel_border, pixel_background ) ;
			}

		[DllImport("libX11", EntryPoint = "XDefaultGC")]
			extern static IntPtr default_gc(IntPtr display, int scrnum) ;
			public static IntPtr DefaultGC(this IntPtr display, int scrnum)
			{
			return default_gc( display, scrnum ) ;
			}

		[DllImport("libX11", EntryPoint = "XMapWindow")]
			extern static void map_window(IntPtr display, IntPtr window) ;
			public static void MapWindow(this IntPtr display, IntPtr window)
			{
			map_window( display, window ) ;
			}

		[DllImport("libX11", EntryPoint = "XNextEvent")]
			extern static void next_event(IntPtr display, out XAnyEvent _event) ;
			public static void NextEvent(this IntPtr display, out XAnyEvent _event)
			{
			next_event( display, out _event ) ;
			}

		[DllImport("libX11", EntryPoint = "XCloseDisplay")]
			extern static void display_close(IntPtr display) ;
			public static void CloseDisplay(this IntPtr display)
			{
			display_close(display) ;
			}

		[DllImport("libX11", EntryPoint = "XFree")]
			extern static void free(IntPtr data) ;
			//public static void Free(this IntPtr display, IntPtr data)
			//{
			//free(data) ;
			//}

		[DllImport("libX11", EntryPoint = "XInternAtom")]
			extern static IntPtr intern_atom(IntPtr display, string name, bool only_if_exists) ;
			public static IntPtr InternAtom(this IntPtr display, string name, bool only_if_exists)
			{
			return intern_atom(display,name,only_if_exists) ;
			}

		[DllImport("libX11", EntryPoint = "XInternAtoms")]
			extern static IntPtr intern_atoms(IntPtr display, string [] names, int nnames, bool only_if_exists, IntPtr [] atoms) ;
			public static void InternAtoms(this IntPtr display, string [] names, int nnames, bool only_if_exists, IntPtr [] atoms)
			{
			intern_atoms(display,names,nnames,only_if_exists,atoms) ;
			}

		#if VERBOSE || DEBUG
		[DllImport("libX11", EntryPoint = "XGetAtomName")]
			extern static IntPtr get_atom_name(IntPtr display, IntPtr atom) ;
			public static Guid GetAtom(this IntPtr display, IntPtr atom)
			{
			IntPtr data = get_atom_name(display,atom) ;
			Guid guid = new Guid( Marshal.PtrToStringAuto(data) ) ;
			free(data) ;
			return guid ;
			}
		#endif

		#if DEBUG
		//[DllImport("libX11", EntryPoint = "XGetAtomName")]
			//extern static IntPtr get_atom_name(IntPtr display, IntPtr atom) ;
			public static string GetDefaultAtom(this IntPtr display, IntPtr atom)
			{
			IntPtr data = get_atom_name(display,atom) ;
			string s = Marshal.PtrToStringAuto(data) ;
			free(data) ;
			return s ;
			}
		#endif

		[DllImport("libX11", EntryPoint = "XRootWindow")]
			extern static IntPtr root_window(IntPtr display, int screen) ;
			public static IntPtr RootWindow(this IntPtr display, int screen)
			{
			return root_window(display,screen) ;
			}

		[DllImport("libX11", EntryPoint = "XDefaultRootWindow")]
			extern static IntPtr default_root_window(IntPtr display) ;
			public static IntPtr DefaultRootWindow(this IntPtr display)
			{
			return default_root_window(display) ;
			}

		[DllImport("libX11", EntryPoint = "XQueryTree")]
			extern static void query_tree(System.IntPtr display, IntPtr window, out IntPtr root, out IntPtr sid, out IntPtr items, out int nitems) ;
			public static void QueryTree(this IntPtr display, IntPtr window, out IntPtr root, out IntPtr sid, out IntPtr items, out int nitems)
			{
			query_tree(display, window, out root, out sid, out items, out nitems) ;
			}
			
		[DllImport("libX11", EntryPoint = "XListProperties")]
			extern static IntPtr list_properties(System.IntPtr display, IntPtr window, out int nitems) ;
			public static IntPtr [] ListProperties(this IntPtr display, IntPtr window)
			{
			int nitems ;
			IntPtr ip = list_properties(display, window, out nitems) ;
			System.IntPtr [] list = new System.IntPtr[nitems] ;
			for( int i = 0 ; i < nitems ; i++ )
				list[i] = (IntPtr)Marshal.PtrToStructure((IntPtr)(ip + IntPtr.Size * i), typeof(IntPtr)) ;
			free(ip) ;
			return list ;
			}
			
		#if !SAFE
		[DllImport("libX11", EntryPoint = "XSetStandardProperties")]
			extern static void set_standard_properties(System.IntPtr display, IntPtr window, string window_name, string icon_name, IntPtr pixmap, string [] argv, int argc, IntPtr hints)  ;
			public static void SetStandardProperties(this IntPtr display, IntPtr window, string window_name, string icon_name, IntPtr pixmap, string [] argv, int argc, IntPtr hints)
			{
			set_standard_properties(display,window,window_name,icon_name,pixmap,argv,argc,hints) ;
			}
		#endif
			
		[DllImport("libX11", EntryPoint = "XCreatePixmap")]
			extern static IntPtr pixmap_create(System.IntPtr display, Drawable d, uint width, uint height, uint depth) ;
			public static IntPtr CreatePixmap(this IntPtr display, Drawable d, uint width, uint height, uint depth)
			{
			return pixmap_create(display,d,width,height,depth) ;
			}

		[DllImport("libX11", EntryPoint = "XFreePixmap")]
			extern static void pixmap_free(System.IntPtr display, IntPtr pixmap)  ;
			public static void FreePixmap(this IntPtr display, IntPtr pixmap)
			{
			pixmap_free(display,pixmap) ;
			}
		
		[DllImport("libX11", EntryPoint = "XCreateGC")]
			extern static IntPtr gc_create(IntPtr display, Drawable d, long value_mask, ref Values values)  ;
			public static void CreateGC(this IntPtr display, Drawable d, long mask, ref Values values, out IntPtr xgc )
			{
			xgc = gc_create( display, d, mask, ref values ) ;
			}

		[DllImport("libX11", EntryPoint = "XGetGCValues")]
			extern static void gc_values(IntPtr display, IntPtr gc, long valuemask, out Values values )  ;
			public static void GCValues(this IntPtr display, IntPtr gc, long valuemask, out Values values )
			{
			gc_values(display,gc,valuemask, out values) ;
			}

		[DllImport("libX11", EntryPoint = "XCopyGC")]
			extern static void gc_copy(IntPtr display, IntPtr gc, long valuemask, IntPtr xgc )  ;
			public static void CopyGC(this IntPtr display, IntPtr gc, long valuemask, IntPtr xgc )
			{
			gc_copy(display,gc,valuemask, xgc) ;
			}

		[DllImport("libX11", EntryPoint = "XChangeGC")]
			extern static void gc_change(IntPtr display, IntPtr gc, long valuemask, ref Values values )  ;
			public static void ChangeGC(this IntPtr display, IntPtr gc, long valuemask, ref Values values )
			{
			gc_change(display,gc,valuemask, ref values) ;
			}

		[DllImport("libX11", EntryPoint = "XSetLineAttributes")]
			extern static void set_line_attributes(IntPtr display, IntPtr gc, int line_width, int line_style, int cap_style, int join_style ) ;
		
		[DllImport("libX11", EntryPoint = "XFreeGC")]
			extern static void gc_free(IntPtr display, IntPtr gc)  ;
			public static void FreeGC(this IntPtr display, IntPtr gc)
			{
			gc_free(display,gc) ;
			}
		
		[DllImport("libX11", EntryPoint = "XDefaultVisual")]
			extern static IntPtr visual_default(System.IntPtr display, int scrnum)  ;
			public static IntPtr DefaultVisual(this IntPtr display, int scrnum)
			{
			return visual_default(display,scrnum) ;
			}
		
			public static IntPtr DefaultResolution(this IntPtr display)
			{
			#if CHROMEBOOK //BUG: https://code.google.com/p/chromium/issues/detail?id=180913
			/* return */ full_volume() ;  //full_screen+
			#else
			return visual_default(display,0)/*.rez*/ ;  //given,_FIXT:anti-aliasing
			#endif
			}

		[DllImport("libX11", EntryPoint = "XDefaultScreen")]
			extern static int screen_default(System.IntPtr display)  ;
			public static int DefaultScreen(this IntPtr display)
			{
			return screen_default(display) ;
			}

		[DllImport("libX11", EntryPoint = "XDefaultGC")]
			extern static IntPtr gc_default(System.IntPtr display, int scrnum )  ;
			public static IntPtr DefaultGC(this IntPtr display)
			{
			#if !SERVER && !CLIENT
			return gc_default(display,screen_default(display)) ;
			#else
			return gc_default(display,scrnum) ;
			#endif
			}

		[DllImport("libX11", EntryPoint = "XCreateColormap")]
			extern static IntPtr colormap_create(System.IntPtr display, Drawable d, IntPtr visual, int alloc )  ;
			public static IntPtr CreateColormap(this IntPtr display, Drawable d, IntPtr visual, int alloc )
			{
			return colormap_create(display,d,visual,alloc) ;
			}

		[DllImport("libX11", EntryPoint = "XDefaultColormap")]
			extern static IntPtr colormap_default(System.IntPtr display, int scrnum )  ;
			public static IntPtr DefaultColormap(this IntPtr display, int scrnum )
			{
			return colormap_default(display,scrnum) ;
			}

		[DllImport("libX11", EntryPoint = "XLookupColor")]
			extern static int color_lookup(System.IntPtr diplay, IntPtr colormap, string name, out XColor softcolor, out XColor hardcolor)  ;
			public static int LookupColor(this IntPtr display, IntPtr colormap, string name, out XColor softcolor, out XColor hardcolor)
			{
			return color_lookup(display,colormap, name, out softcolor, out hardcolor) ;
			}

		[DllImport("libX11", EntryPoint = "XAllocColor")]
			extern static int color_alloc(System.IntPtr display, IntPtr colormap, ref XColor color )  ;
			public static int AllocColor(this IntPtr display, IntPtr colormap, ref XColor color )
			{
			return color_alloc(display,colormap, ref color) ;
			}

		[DllImport("libX11", EntryPoint = "XBlackPixel")]
			extern static ulong pixel_client(System.IntPtr display, int scrnum )  ;
			public static ulong ServerPixel(this IntPtr display, int scrnum )
			{
			#if !SERVER
			return pixel_client(display,0) ;
			#else
			return pixel_server(display,scrnum) ;
			#endif
			}

		[DllImport("libX11", EntryPoint = "XWhitePixel")]
			extern static ulong pixel_server(System.IntPtr display, int scrnum )  ;
			public static ulong ClientPixel(this IntPtr display, int scrnum )
			{
			#if !CLIENT
			return pixel_server(display,0) ;
			#else
			return pixel_client(display,scrnum) ;
			#endif
			}

		[DllImport("libX11", EntryPoint = "XDrawRectangle")]
			extern static IntPtr draw_py(System.IntPtr display, Drawable d, IntPtr gc, int x, int y, uint width, uint height )  ;
			public static IntPtr Stitch(this IntPtr display, int x, int y )
			{
			#if STYX
			return draw_py(display,default_root_window(display),gc_default(display,0),x,y,0,0) ;
			#else
			return draw_py(display,default_root_window(display),gc_default(display,0),x,y,(uint)x+3,(uint)y+3) ;
			#endif
			}

		[DllImport("libX11", EntryPoint = "XDrawPoint")]
			extern static IntPtr draw_point(System.IntPtr display, Drawable d, IntPtr gc, int x, int y )  ;
			public static IntPtr DrawPoint(this IntPtr display, Drawable d, IntPtr gc, int x, int y )
			{
			return draw_point(display,d,gc,x,y) ;
			}

		[DllImport("libX11", EntryPoint = "XFlushGC")]
			extern static IntPtr gc_flush(System.IntPtr display, IntPtr gc )  ;
			public static IntPtr FlushGC(this IntPtr display, IntPtr gc )
			{
			return gc_flush(display,gc) ;
			}

		[DllImport("libX11", EntryPoint = "XSetForeground")]
			extern static IntPtr set_foreground(System.IntPtr display, IntPtr gc, ulong fg )  ;
			public static IntPtr SetForeground(this IntPtr display, IntPtr gc, ulong fg )
			{
			return set_foreground(display,gc,fg) ;
			}

		[DllImport("libX11", EntryPoint = "XSelectInput")]
			extern static IntPtr select_input(System.IntPtr display, Drawable d, ulong fg )  ;
			public static IntPtr SelectInput(this IntPtr display, Drawable d, ulong fg )
			{
			return select_input(display,d,fg) ;
			}

		[DllImport("libX11", EntryPoint = "XRotateWindowProperties")]
			extern static IntPtr rotate_window_properties(System.IntPtr display, IntPtr window, ref IntPtr atoms, int nproperties, int npositions) ;
			public static IntPtr RotateWindowProperties(this IntPtr display, IntPtr window, ref IntPtr atoms, int nproperties, int npositions )
			{
			#if intel_LEGACY && !TSC
			if(nproperties.GetHashCode()==0)
				kill_client(display,window) ;
			#endif
			return rotate_window_properties(display,window,ref atoms,nproperties,npositions) ;
			//_real: rotate_properties(blitter,delta,atoms) ;
			}

		public static IntPtr Start(this Nullable<Rectangle> a)
			{
			return a.Value ;                   //IntPtr[]-unsized[,_blitter_array]
			}

		[DllImport("libX11", EntryPoint = "XKillClient")]
			extern static IntPtr kill_client(System.IntPtr display, IntPtr xid) ;
			public static IntPtr KillClient(this IntPtr display, IntPtr xid)
			{
			#if BAD
			GC.SuppressFinalize(xid.GetHashCode()) ;
			#if !Synchronous
			initialize_threads() ;
			#endif
			#endif
			return kill_client(display,xid) ;  //_base_sid,_embedded_colormap_free
			}

		#if !Synchronous
		[DllImport("libX11", EntryPoint = "XInitThreads")]
			extern static IntPtr initialize_threads() ;
		#endif

		#if !KERNING
		[DllImport("libX11", EntryPoint = "XBell")]
			extern static IntPtr ring(System.IntPtr display, IntPtr ___cent) ;
			public static IntPtr Ring(this IntPtr display, IntPtr ___cent)
			{
			return ring(display,(IntPtr)((int)___cent&0x8F)) ; //^mask:=00000001000000010000000100000111
			}
		#endif

		[DllImport("libX11", EntryPoint = "XGetIconSizes")]
			extern static IntPtr get_icon_sizes(System.IntPtr display, Drawable w, out IntPtr list, out int nlist ) ;
			public static IntPtr GetIconSizes(this IntPtr display, Drawable w, out IntPtr list, out int nlist )
			{
			return get_icon_sizes(display,w,out list,out nlist) ;
			}
			
		public static void Draw(this IntPtr display, Drawable w)
			{
			A335.Channel vblit = new A335.Channel() ;
			//ops=vblist_ht(https://developers.google.com/maps/documentation/javascript/overlays)
			//_compile_ops_to_script_xml_with_context_endpoint
			//_store_folded_exec_on_DOTTEDNAME(s)
			}

		[DllImport("libX11", EntryPoint = "XChangeSaveSet")]
			extern static IntPtr change_saveset(System.IntPtr display, Drawable w, int change_mode) ;
			public static IntPtr ChangeSaveset(this IntPtr display, Drawable w, bool delete)
			{
			int insert_or_delete = delete ? 1 : 0 ;
			return change_saveset(display,w,insert_or_delete) ;
			}

		[DllImport("libX11", EntryPoint = "XAddToSaveSet")]
			extern static IntPtr addto_saveset(System.IntPtr display, Drawable w) ;
			public static IntPtr AddToSaveset(this IntPtr display, Drawable w)
			{
			return addto_saveset(display,w) ;
			}

		[DllImport("libX11", EntryPoint = "XRemoveFromSaveSet")]
			extern static IntPtr removefrom_saveset(System.IntPtr display, Drawable w) ;
			public static IntPtr RemoveFromSaveset(this IntPtr display, Drawable w)
			{
			return removefrom_saveset(display,w) ;
			}

		[DllImport("libX11", EntryPoint = "XReparentWindow")]
			extern static IntPtr rectify(System.IntPtr display, Drawable w, IntPtr sid, int x, int y) ;
			public static IntPtr Rectify(this IntPtr display, Drawable w, IntPtr sid, int x, int y)
			{
			return rectify(display,w,sid,x,y) ;
			}

		[DllImport("libX11", EntryPoint = "XGetGeometry")]
			extern static IntPtr get_geometry(System.IntPtr display, Drawable d, out IntPtr root, out int x, out int y, out uint width, out uint height, out uint border, out uint depth) ;
			public static IntPtr GetGeometry(this IntPtr display, Drawable d, out IntPtr root, out int x, out int y, out uint width, out uint height, out uint border, out uint depth)
			{
			return get_geometry(display,d, out root, out x, out y, out width, out height, out border, out depth) ;
			}

		}

	}

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
}
