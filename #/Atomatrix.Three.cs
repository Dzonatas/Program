namespace Atomatrice
{
using System ;
static public class Three
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
	static public IntPtr YYToken
		{
		get { return _item ; }
		set { _item = value ; }
		}
	static public IntPtr INSTR_(this IntPtr a, int offset)
		{
		#if CONSISTENT
		return IntPtr.Subtract(_item,-offset) ;
		#else
		return a.Token(offset) ;
		#endif
		} 
	static public IntPtr Oprand(this IntPtr a, int offset)
		{
		#if CONSISTENT
		return IntPtr.Subtract(_item,offset) ;
		#else
		return a.Token(-offset) ;
		#endif
		} 
	}
	/*
	.
	.
	.
	*/
	
}

namespace Contributors
	{
	struct Contributor
		{
		object node_asset_contribtor ;
		Contributor( string url )
			{
			node_asset_contribtor =
			@"<embed id              = 'xs:String'>
					 Author          = '<THIS/>'
					 Authoring_Tool  = '<THIS/>'
					 Comments        = '<THIS/>'
					 Copyright       = '<THIS/>'
					 Source_Data     = '"+url+@"'
					 </embed>";
			}
		}
	}

namespace Contributor.Asset  //DOTTEDNAME-space
	{
	struct contribution
		{
		#region C_LITERAL
		System.Guid literalized ;
		string uri ; //= "xs:URL:SQSTRING,SQSTRING,SQSTRING,SQSTRING" ; //_literalized_xs
		#endregion
		contribution( string url, string sqstring_, string _0, string _1, string _2 )
			{
			this.uri = "xs:"+url+':'+sqstring_+','+_0+','+_1+','+_2 ;
			}
		void CLASS()
			{
			//UUID literal ; //_FIX:_not_dated(_likely_C_ticked)
			//literalized = new System.Guid(literal.ToString()); //_FIXT:_dated
			}
		}
	}

namespace con.sys
	{
	struct tint
		{
		//<Geospatial env="ENVIRONMENT:ALL.VAR:{(i.OS.syscall)}">
		PIXEL.pixel name ;
		//Mip id   ;
		//</Geospatial>
		}
	}

/*
#region C_PROFILE
<COLLADA><library_geometry><geometry><convex_mesh>
  <source id="">
  	.custom C_MAP = ( Scalar id = new Scalar( i_undefined, <xml:vwrap/> ) ; (id).ToHex() ; )
  	<accessor>::id/unreachable/code/<param sid/></accessor>
  	<accessor source="#id">::id/Material/<param ITEMSCOPE="®" ITEMTYPE="™"/></accessor>
	#if UUCP_GOV_QUADMAP
  	<accessor>::id/Material/<param name=".ace" type="file::"/></accessor>
  	#endif
  	<technique profile="debug,concaved,spatial"><script>{}</script></technique>
  </source>
</convex_mesh></geometry></library_geometry></COLLADA>
#endregion C_PROFILE
*/

namespace kern.el.o
	{
	struct __one
		{
		bool _one   ;
		bool _two ;
		bool three   ;
		}
	struct __two
		{
		bool _one   ;
		bool _two    ;
		bool three    ;
		bool _four   ;
		}
	struct _three
		{
		bool _one       ;
		bool _two     ;
		bool three       ;
		bool _four    ;
		}
	struct __four
		{
		bool _one     ;
		bool _two      ;
		bool _three     ;
		bool _four     ;
		bool _five    ;
		bool _six      ;
		bool _seven     ;
		bool _eight     ;
		bool _nine   ;
		bool _ten       ;
		bool _eleven    ;
		bool _twelve     ;
		bool _thirteen    ;
		bool _CBT       ;
		}
	struct __five
		{
		bool _one      ;
		bool _two    ;
		bool _three ;
		bool _four      ;
		bool _five      ;
		bool _six ;
		bool _seven     ;
		bool _eight     ;
		bool _nine  ;
		}
	struct _six
		{
		bool _one      ;
		bool _two    ;
		bool _three  ;
		}
	struct __seven
		{
		bool _one      ;
		bool _two      ;
		bool _three     ;
		bool four     ;
		bool _five    ;
		bool _six       ;
		bool _seven        ;
		bool _eight     ;
		}
	struct _eight
		{
		bool _one        ;
		bool _two      ;
		bool _three      ;
		bool _four      ;
		bool _five    ;
		}
	struct _nine
		{
		bool _one     ;
		bool _two ;
		bool _three    ;
		}
	struct _
		{
		bool __     ;
		bool ___      ;
		}
	}
