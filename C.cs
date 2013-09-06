partial class A335
{
#if COPY
#endif
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
		string node_asset_contribtor =
		@"<embed id              = 'xs:String'>
			 Author          = '<THIS/>'
			 Authoring_Tool  = '<THIS/>'
			 Comments        = '<THIS/>'
			 Copyright       = '<THIS/>'
			 Source_Data     = '<URL/>'
		         </embed>";
		}
	}

namespace Contributor.Asset  //DOTTEDNAME-space
	{
	struct contribution
		{
		string uri = "xs:URL:SQSTRING,SQSTRING,SQSTRING,SQSTRING" ; //_literalized_xs
		}
	}
