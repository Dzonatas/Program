//using System.C.IDE.MonoDevelop;//C.I.S.("ecma.cproj")

partial class A335
{
#if COPY
#endif

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