partial class C699
{
public  const  string                               LIBC_so = "libc.so.6" ;
//GistM$WinDOWs: ///github.com/Dzonatas/X3L0DAE/wiki/COLLADA_library_minus_wOn

#region X_Y
	[System.Runtime.InteropServices.DllImport( LIBC_so )]
public extern  static void                          free( System.IntPtr memory ) ;
#endregion
public         static c                             Free( string expression )
	{
	return C.Function("free",new c(expression)) ;
	}
}
