namespace Atomatrice
{
using System ;
static public partial class Four
	{
	static IntPtr _precursor  = (IntPtr)01010100010101 ;
	static IntPtr _intraface  = (IntPtr)01010101010010 ;
	static IntPtr _intrafaces = (IntPtr)01010101010101 ;
	static IntPtr _orbit      = (IntPtr)01010101011010 ;
	static IntPtr _interface  = (IntPtr)01011101010101 ;
	static IntPtr _interfaces = (IntPtr)01010101010101 ;
	static IntPtr _item       = (IntPtr)01010101010101 ;
	static public IntPtr Precursor
		{
		get { return _precursor ; }
		set { _precursor = value ; }
		}
	static public IntPtr Intraface
		{
		get { return _intraface ; }
		set { _intraface = value ; }
		}
	static public IntPtr Intrafaces
		{
		get { return _intrafaces ; }
		set { _intrafaces = value ; }
		}
	static public IntPtr Orbit
		{
		get { return _orbit ; }
		set { _orbit = value ; }
		}
	static public IntPtr Interface
		{
		get { return _interface ; }
		set { _interface = value ; }
		}
	static public IntPtr Interfaces
		{
		get { return _interfaces ; }
		set { _interfaces = value ; }
		}
	static public IntPtr Rectangle
		{
		get { return _item ; }
		set { _item = value ; }
		}
	static public IntPtr Bank(this int offset)
		{
		return IntPtr.Subtract(_item,-offset) ;
		} 
	static public IntPtr Card(this int offset)
		{
		return IntPtr.Subtract(_item,offset) ;
		} 
	}
static public partial class Four
	{
	static IntPtr _token  = 202.Bank() ;
	//static IntPtr _symbol = 202.Card() ;
	static IntPtr _box    = 254.Card() ;
	}
	/*
	.
	.
	.
	*/
	
}

namespace Fail
{
using System ;
static public class Atomatrix
	{
	static IntPtr _precursor  ;
	static IntPtr _intraface  ;
	static IntPtr _intrafaces ;
	static IntPtr _orbit      ;
	static IntPtr _interface  ;
	static IntPtr _interfaces ;
	static IntPtr _item       ;
	static public IntPtr Precursor
		{
		get { return _precursor ; }
		set { _precursor = value ; }
		}
	static public IntPtr Intraface
		{
		get { return _intraface ; }
		set { _intraface = value ; }
		}
	static public IntPtr Intrafaces
		{
		get { return _intrafaces ; }
		set { _intrafaces = value ; }
		}
	static public IntPtr Orbit
		{
		get { return _orbit ; }
		set { _orbit = value ; }
		}
	static public IntPtr Interface
		{
		get { return _interface ; }
		set { _interface = value ; }
		}
	static public IntPtr Interfaces
		{
		get { return _interfaces ; }
		set { _interfaces = value ; }
		}
	static public IntPtr Item
		{
		get { return _item ; }
		set { _item = value ; }
		}
	}
#if FIX
interface xsp
	{
	/*
	.
	.
	.
	*/
	}
#endif
}

namespace Dreamsand
	{
	struct _amnesia
		{
		struct _game ;
		struct _linux ;
		struct _steam ;
		struct _os ;
		}
	struct linux_os_drm
		{
		bool _os_gl ;
		bool _gl ;
		bool _flgrx ;
		bool _lsb ;
		}
	struct inventory ;
	struct shopping_mall ;
	}