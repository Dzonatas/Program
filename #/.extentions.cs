namespace System.Extensions
	{
	using System.Runtime.InteropServices ;
	using System.Drawing ;
	using Drawable  = System.IntPtr ;         //_window,_pixmap
	using Rectangle = System.IntPtr ;         //X-defined-default:[x,y]:=upper-left
	using Screen    = _.screen ;
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
			//throw new Exception("[Affinty]=[Infinite]+[Finite]") ;
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
			Screen.Glitched(d) ;
			}


		//[Oprand({'B', 'l'})]
		[DllImport("libX11", EntryPoint = "XOpenDisplay")]
			extern static IntPtr display_open([MarshalAs(UnmanagedType.LPStr)] string display ) ;
			public static void OpenDisplay(this IntPtr _, out IntPtr display)
			{
			#if DEBUG || DIRECTX
			//IceSetHostBasedAuthProc(listener,always_true) ;
			#elif WIN8 || VAX
			//IceSetHostBasedAuthProc(listener,trait) ;
			#endif
			display = display_open(":2") ;
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
			extern static IntPtr gc_create(System.IntPtr display, Drawable d, IntPtr value_mask, ref IntPtr values)  ;
			public static IntPtr CreateGC(this IntPtr display, Drawable d, IntPtr value_mask, ref IntPtr values)
			{
			return gc_create(display,d,value_mask,ref values) ;
			}
		
		[DllImport("libX11", EntryPoint = "XFreeGC")]
			extern static void gc_free(System.IntPtr display, IntPtr gc)  ;
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

		[DllImport("libX11", EntryPoint = "XDefaultColormap")]
			extern static IntPtr colormap_default(System.IntPtr display, int scrnum )  ;
			public static IntPtr DefaultColormap(this IntPtr display, int scrnum )
			{
			return colormap_default(display,scrnum) ;
			}

		[DllImport("libX11", EntryPoint = "XLookupColor")]
			extern static int color_lookup(System.IntPtr display, IntPtr colormap, ref IntPtr softcolor, ref IntPtr hardcolor)  ;
			public static int LookupColor(this IntPtr display, IntPtr colormap, ref IntPtr softcolor, ref IntPtr hardcolor)
			{
			return color_lookup(display,colormap, ref softcolor, ref hardcolor) ;
			}

		[DllImport("libX11", EntryPoint = "XAllocColor")]
			extern static int color_alloc(System.IntPtr display, IntPtr colormap, ref IntPtr color )  ;
			public static int AllocColor(this IntPtr display, IntPtr colormap, ref IntPtr color )
			{
			return color_alloc(display,colormap, ref color) ;
			}

		[DllImport("libX11", EntryPoint = "XBlackPixel")]
			extern static IntPtr pixel_client(System.IntPtr display, int scrnum )  ;
			public static IntPtr ServerPixel(this IntPtr display, int scrnum )
			{
			#if !SERVER
			return pixel_client(display,0) ;
			#else
			return pixel_server(display,scrnum) ;
			#endif
			}

		[DllImport("libX11", EntryPoint = "XWhitePixel")]
			extern static IntPtr pixel_server(System.IntPtr display, int scrnum )  ;
			public static IntPtr ClientPixel(this IntPtr display, int scrnum )
			{
			#if !CLIENT
			return pixel_server(display,0) ;
			#else
			return pixel_client(display,scrnum) ;
			#endif
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

	using KeySym    = System.IntPtr ;         //_symbolic_form_with_cultural_extensions,_UNIX(TM)
	using iKeySym   = System.IntPtr ;         //_hardware_hack,_MAC,_IPv6,Token<COLOREDMAP>,_LOGO

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

	class Symbol
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

	}
