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
		public class Item
			{
			UUID    id ;
			UUID    queried_asset = UUID.Zero ;
			Scalar  sd ;
			QueryAction<Item> qa ;
			
			public event Action Changed = () => {} ;

			static Dictionary<UUID,Item> cache = new Dictionary<UUID,Item>() ;

			public UUID ID
				{
				get { return id ; }
				}

			public string Name
				{
				get
					{
					lock( this )
						if( sd.ContainsKey("name") )
							return sd["name"] ;
					return null ;
					}
				}
				
			public UUID AssetID
				{
				get
					{
					lock( this )
						{
						if( sd.ContainsKey("asset_id") )
							return (UUID) sd["asset_id"] ;
						if( sd.ContainsKey("shadow_id") )
							return ( (UUID) sd["shadow_id"] ) ^ new UUID( "3c115e51-04f4-523c-9fa6-98aff1034730" ) ; // MAGIC_ID
						}
					return null ;
					}
				}

			public string Type
				{
				get
					{
					lock( this )
						if( sd.ContainsKey("inv_type") )
							return sd["inv_type"] ;
					return null ;
					}
				}
				
			public bool Active
				{
				get
					{
					lock( this )
						if( sd.ContainsKey("Active") )
							return sd["Active"] ;
					return false ;
					}
				}
				
			System.Type assetType()
				{
				string type ;
				try
					{ type = Type ; }
				catch( Exception )
					{ return null ; }
				return Asset.ConvertType( type ) ;
				}
			
			public uint Flags
				{
				get
					{
					lock( this )
						if( sd.ContainsKey("flags") )
							return (uint) sd["flags"] ;
					return 0 ;
					}
				}
				
			public string Description
				{
				get
					{
					lock( this )
						if( sd.ContainsKey("desc") )
							return sd["desc"] ;
					return null ;
					}
				}

			static public Item Find( UUID id )
				{
				lock( cache )
					{
					if( cache.ContainsKey( id ) )
						return cache[ id ] ;
					return cache[ id ] = new Item( id ) ;
					}
				}

			static public Item Exists( UUID id )
				{
				lock( cache )
					{
					if( cache.ContainsKey( id ) )
						return cache[ id ] ;
					return null ;
					}
				}
				
			class QueryItem : REST.GetByUUID
				{
				Item  item ;
				//override protected void    StatusNotFound() { item.Queried( null ) ; }
				override protected string  Resource   { get { return "Inventory/Item"; } }
				override protected Scalar  SD         { set { item.Queried( value ) ;  } }
				internal Item              Item       { get { return item ; } }
				override public UUID       ID         { get { return item.ID ; } } 
				public QueryItem( Item item )         {	this.item = item ; }
				}

			
			public class QueryAsset : REST.GetByUUID
				{
				Inventory.Item item ;
				override protected string  Resource   { get { return "Inventory/Asset" ; } }
				override protected Scalar  SD         { set { /*item.Queried( value ) ;*/ } }
				internal Inventory.Item    Item       { get { return item ; } }
				override public UUID       ID         { get { return item.ID ; } }
				public QueryAsset( Inventory.Item item, Action<QueryAsset> a )
					{
					//Debug.WriteLine("Inventory Asset Item={0} Asset={1}", item.ID, item.AssetID ) ;
					this.item    = item ;
					//inventory.Add( this ) ;
					Asset asset = Asset.Find( item.AssetID, Asset.ConvertType( item.Type ) ) ;
					asset.Query( (_asset) => a( this ) ) ; 
					}
				}

			public void Requery()
				{
				qa.Requery( (c) => Changed() ) ;  
				}

			internal void Queried( Scalar s )
				{
				qa.Queried( s ) ;
				}
				
			internal void Query( Action<Item> a )
				{
				qa.Query( a ) ;
				}
				
			void loaded( Action<Item,Asset> a )
				{
				Asset asset = Asset.Find( AssetID, assetType() ) ;
				asset.Query( (_asset) => a( this, _asset ) )  ;
				}
				
			public void Query( Action<Item,Asset> a )
				{
				lock( this )
					{
					if( queried_asset == UUID.Zero || queried_asset != AssetID )
						{
						qa.Query( (item) =>
							{
							REST.Queue(   new QueryAsset(  item, (q) => loaded( a )  )   ) ;
							queried_asset = AssetID ;
							} ) ;
						}
					else
						qa.Query( (item) => loaded( a ) ) ;
					}
				}
			
			private Item( UUID id )
				{
				this.id      = id ;
				qa           = new QueryAction<Item>(  this,
				                 ()  => REST.Queue( new QueryItem( this ) ),
				                 (s) => { lock( this ) sd = s ; }
				                 ) ;
				qa.Queryable = true ;
				}
			}
		}
	}
