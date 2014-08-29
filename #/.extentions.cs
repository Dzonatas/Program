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
		public static string GUID(this double _)
			{
			int i = _.CompareTo(0.0) == 0 ? 0 : int.Parse(_.ToString().Split('.')[1]) ;
			switch(i)
				{
				case 0: return "5a7160ed-13d5-4923-a1f9-3e32a47d558a" ;
				case 1: return @"/tmp/."+(0.0).GUID()+".d" ;
				case 2: return           (0.1).GUID()  +"/.git" ;
				default: throw new System.NotSupportedException() ;
				}
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
			public static IntPtr OpenDisplay(this double _, out IntPtr display)
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

		[DllImport("libX11", EntryPoint = "XServerVendor")]
			extern static IntPtr server_vendor(IntPtr display) ;
			public static IntPtr ServerVendor(this IntPtr display, out IntPtr sv )
			{
			sv = server_vendor( display ) ;
			return display ;
			}

		[DllImport("libX11", EntryPoint = "XCreateSimpleWindow")]
			extern static IntPtr window_create_simple(IntPtr display, IntPtr window, int x, int y, uint width, uint height, uint border_width, ulong border, ulong background) ;
			public static IntPtr CreateSimpleWindow(this IntPtr display, out Drawable d )
			{
			int     s  = screen_default(display) ;
			IntPtr  r  = root_window( display, s ) ;
			ulong pixel_border = pixel_server( display, s ) ;
			ulong pixel_background = pixel_client( display, s ) ;
			d = window_create_simple(display, r, 3, 3, 300, 300, 1, pixel_border, pixel_background ) ;
			return display ;
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
			extern static void next_event(IntPtr display, out XEvent _event) ;
			public static void NextEvent(this IntPtr display, out XEvent _event)
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
			extern static IntPtr gc_create(IntPtr display, Drawable d, ulong value_mask, ref Values values)  ;
			public static IntPtr CreateGC(this IntPtr display, Drawable d, ulong mask, ref Values values, out IntPtr xgc )
			{
			xgc = gc_create( display, d, mask, ref values ) ;
			return display ;
			}

		[DllImport("libX11", EntryPoint = "XGetGCValues")]
			extern static void gc_values(IntPtr display, IntPtr gc, ulong valuemask, out Values values )  ;
			public static IntPtr GCValues(this IntPtr display, IntPtr gc, ulong valuemask, out Values values )
			{
			gc_values(display,gc,valuemask, out values) ;
			return display ;
			}

		[DllImport("libX11", EntryPoint = "XCopyGC")]
			extern static void gc_copy(IntPtr display, IntPtr gc, ulong valuemask, IntPtr xgc )  ;
			public static void CopyGC(this IntPtr display, IntPtr gc, ulong valuemask, IntPtr xgc )
			{
			gc_copy(display,gc,valuemask, xgc) ;
			}

		[DllImport("libX11", EntryPoint = "XChangeGC")]
			extern static void gc_change(IntPtr display, IntPtr gc, ulong valuemask, ref Values values )  ;
			public static void ChangeGC(this IntPtr display, IntPtr gc, ulong valuemask, ref Values values )
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

		[DllImport("libX11", EntryPoint = "XSetWindowColormap")]
			extern static void set_window_colormap(System.IntPtr display, Drawable d, IntPtr colormap )  ;
			public static void SetWindowColormap(this IntPtr display, Drawable d, IntPtr colormap )
			{
			set_window_colormap(display,d,colormap) ;
			}

		[DllImport("libX11", EntryPoint = "XParseColor")]
			extern static void color_parse(System.IntPtr diplay, IntPtr colormap, string name, out XColor color)  ;
			public static void ParseColor(this IntPtr display, IntPtr colormap, string name, out XColor color)
			{
			color_parse(display,colormap, name, out color) ;
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

