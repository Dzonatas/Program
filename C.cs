partial class A335
{
public class Channel   // : X-Window
	{
	//VisualType:StaticGray|StaticColor|GrayScale
	//WINGRAVITY:Static
	//BITGRAVITY:Static
	//Depth:Array
	//oprands:
	System.IntPtr  display ;
	System.IntPtr  screen  ;
	System.IntPtr  sid     ;
	System.IntPtr  line    ;
	#if CAIRO
	System.IntPtr  flush   ;
	#endif
	//rez:
	object []      items   ;
	}

#region macro
/*
<COMPQSTRING> | <compQstring item-scope item-i/>
*/
#endregion macro
}

namespace System.Extensions
	{
	public static class C_Type_
		{
		}
	}
