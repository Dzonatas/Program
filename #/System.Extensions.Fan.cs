namespace System.Extensions {
using System.Runtime.InteropServices ;
using System.Drawing ;
using X.Predefined ;
using Drawable  = System.IntPtr ;         //_window,_pixmap
using Rectangle = System.IntPtr ;         //X-defined-default:[x,y]:=upper-left
public static class Solution
	{
	static int bubbles ;
	public static int Fan(this double _)
		{
		//'Post /etc/wall/fire.d nice/0.0'
		return 0 ;
		}
	public static int FAN(this double _)
		{
		//'Post /etc/heading.d nice/0.0'
		return 0.0.Tool() ;
		}
	public static int Tool(this double _)
		{
		#if GLSL
		///www.shadertoy.com/view/XsjGRd
		screensaver_reset( var_.display ) ;
		#elif iDNA && VIN
		Cluster.Shell.XOverlay() ;
		#else
		bubbles++ ;
		screensaver_activate( var_.display ) ;
		#endif
		//GrabScreenSaver
		//sensors->:9
		return 0 ;
		}
	[DllImport("libX11", EntryPoint = "XActivateScreenSaver")] extern static void screensaver_activate(System.IntPtr display) ;
	[DllImport("libX11", EntryPoint = "XResetScreenSaver")] extern static void screensaver_reset(System.IntPtr display) ;
	}
}