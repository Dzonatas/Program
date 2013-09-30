namespace System.Extensions
	{
	using System.Runtime.InteropServices ;
	using System.Drawing ;
	using Drawable = System.IntPtr ;         //_window,_pixmap
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
			

		//[Oprand({'B', 'l'})]
		[DllImport("libX11", EntryPoint = "XOpenDisplay")]
			extern static IntPtr display_open([MarshalAs(UnmanagedType.LPStr)] string display ) ;
			public static void OpenDisplay(this IntPtr _, out IntPtr display)
			{
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

		[DllImport("libX11", EntryPoint = "XGetAtomName")]
			extern static IntPtr get_atom_name(IntPtr display, IntPtr atom) ;
			public static Guid GetAtom(this IntPtr display, IntPtr atom)
			{
			IntPtr data = get_atom_name(display,atom) ;
			Guid guid = new Guid( Marshal.PtrToStringAuto(data) ) ;
			free(data) ;
			return guid ;
			}

		//[DllImport("libX11", EntryPoint = "XGetAtomName")]
			//extern static IntPtr get_atom_name(IntPtr display, IntPtr atom) ;
			public static string GetDefaultAtom(this IntPtr display, IntPtr atom)
			{
			IntPtr data = get_atom_name(display,atom) ;
			string s = Marshal.PtrToStringAuto(data) ;
			free(data) ;
			return s ;
			}

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
			
		[DllImport("libX11", EntryPoint = "XSetStandardProperties")]
			extern static void set_standard_properties(System.IntPtr display, IntPtr window, string window_name, string icon_name, IntPtr pixmap, string [] argv, int argc, IntPtr hints)  ;
			public static void SetStandardProperties(this IntPtr display, IntPtr window, string window_name, string icon_name, IntPtr pixmap, string [] argv, int argc, IntPtr hints)
			{
			set_standard_properties(display,window,window_name,icon_name,pixmap,argv,argc,hints) ;
			}
			
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
			return gc_create(display,pixmap,value_mask,ref values) ;
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

		public static IntPtr Start(this Nullable<IntPtr> a)
			{
			return a.Value ;
			}
		}
	}
