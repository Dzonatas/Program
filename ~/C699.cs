//namespace C {
public partial class C699 {
public  const  string                               LIBC_so = "libc.so.6" ;

	[System.Runtime.InteropServices.DllImport( LIBC_so )]
public extern  static void                          free( System.IntPtr memory ) ;

}//}
