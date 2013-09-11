/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Collections ;
using System ;

namespace Snowglobe
	{
	public sealed partial class Inventory
		{
		static RootUUID                        rootUUID = new RootUUID() ;
		
		//public class ItemDictionary : Dictionary< UUID, Item >
		//	{
		//	}
		
		
		static public void QueryRoot( Action<Category> a )
			{
			rootUUID.Query(  (id) => a( Category.Find( id ) )  )  ;
			}

		class RootUUID
			{
			QueryAction<RootUUID> qa ;
			UUID      id ;
			
			class QueryInventoryRoot : REST.Get
				{
				Action<Scalar> result ;
				override protected string  Resource           { get { return "Inventory/Root" ; } }
				override protected string  XML
					{
					set
						{
						Scalar s  = new Scalar() ;
						s.XML = value ;
						result( s ) ;
						}
					}
				public QueryInventoryRoot( Action<Scalar> result )
					{
					this.result  = result ;
					}
				}

			public void Query( Action<UUID> a )
				{
				qa.Query( (_) => a( id ) ) ;
				}
			
			internal RootUUID()
				{
				qa = new QueryAction<RootUUID>( this,
								() => REST.Queue( new QueryInventoryRoot( (s) => qa.Queried( s ) ) ),
								(s) => id = (UUID) s["ID"] ) ;
				Interface.LoginComplete  += () => qa.Queryable = true ;
				}
			}


		[Status.Startup]
		public class ResourceInventoryChanged : REST.Resource
			{
			private ResourceInventoryChanged() : base( "/Inventory/Changed" ) {}
			public override void Post( REST.Resource.Context context )
				{
				Scalar m = context.XML ;
				foreach( Scalar sd in m )
					{
					UUID id         = sd["ID"] ;
					//bool sdComplete = sd["Complete"] ;
					string sdAssetType = sd.ContainsKey("AssetType") ? (string) sd["AssetType"] : "unknown" ;
					//Debug.WriteLine("INVENTORY: {0} {1}", id, sdAssetType ) ;
					if( sdAssetType == "category" )
						{
						Category c = Category.Exists( id ) ;
						if( null != c )
							c.Requery() ;
						}
					else
						{
						Item i = Item.Exists( id ) ;
						if( null != i )
							i.Requery() ;
						}
					}
				Scalar s = new Scalar.Map() ;
				s["status"] = "ok" ;
				context.XML = s ;
				}
			}
		}
	}
