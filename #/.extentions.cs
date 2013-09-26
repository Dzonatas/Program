namespace System.Extensions
	{
	using System.Runtime.InteropServices ;
	using System.Drawing ;
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
			public static void Free(this IntPtr display, IntPtr data)
			{
			free(data) ;
			}

		[DllImport("libX11", EntryPoint = "XInternAtom")]
			extern static IntPtr intern_atom(IntPtr display, string name, bool only_if_exists) ;
			public static IntPtr InternAtom(this IntPtr display, string name, bool only_if_exists)
			{
			return intern_atom(display,name,only_if_exists) ;
			}

		[DllImport("libX11", EntryPoint = "XGetAtomName")]
			extern static string get_atom_name(IntPtr display, IntPtr atom) ;
			public static string GetAtomName(this IntPtr display, IntPtr atom)
			{
			return get_atom_name(display,atom) ;
			}

		[DllImport("libX11", EntryPoint = "XRootWindow")]
			extern static IntPtr root_window(IntPtr display) ;
			public static IntPtr RootWindow(this IntPtr display)
			{
			return root_window(display) ;
			}

		[DllImport("libX11", EntryPoint = "XDefaultRootWindow")]
			extern static IntPtr default_root_window(IntPtr display) ;
			public static IntPtr DefaultRootWindow(this IntPtr display)
			{
			return default_root_window(display) ;
			}

		[DllImport("libX11", EntryPoint = "XQueryTree")]
			extern static void query_tree(System.IntPtr display, IntPtr window, out IntPtr root, out IntPtr sid, out IntPtr items, out int nitems) ;
			public static void QueryTree(this IntPtr display, IntPtr window, out IntPtr root, out IntPtr sid, out IntPtr items, out int nitems )
			{
			query_tree(display,window,out root,out sid,out items,out nitems) ;
			}
		}

	namespace X11
		{
		public static class test
			{
			public static void atomics()
				{
				}
			}
		}
	}
