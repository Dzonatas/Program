namespace System.Extensions {
using System.Text.RegularExpressions ;
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
		return 0 ;
		}
	public static int Tool(this double _)
		{
		bubbles++ ;
		//GrabScreenSaver
		//sensors->:9
		return 0 ;
		}
	}
}