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
		public class Category
			{
			UUID                  id ;
			Scalar                sd ;
			QueryAction<Category> qa ;
			bool                  valid = true ;
			//Category              outer ;

			public event Action Changed = () => {} ;

			static Dictionary<UUID,Category> cache = new Dictionary<UUID,Category>() ;

			public UUID ID
				{
				get { return id ; }
				}
				
			public string Name
				{
				get
					{
					lock( this )
						if( sd.ContainsKey("Name") )
							return sd["Name"] ;
					return null ;
					}
				}
			
			public bool Valid
				{
				get { return valid ; }
				}
			
			public List<Category> Categories
				{
				get
					{
					List<Category> list = new List<Category>() ;
					lock( this )
						foreach( Scalar s in sd["Categories"] )
							list.Add( Category.Find( s ) ) ;
					return list ;
					}
				}
			
			public List<Item> Items
				{
				get
					{
					List<Item> list = new List<Item>() ;
					lock( this )
						foreach( Scalar s in sd["Items"] )
							list.Add( Item.Find( s ) ) ;
					return list ;
					}
				}
				
			static public Category Find( UUID id )
				{
				lock( cache )
					{
					if( cache.ContainsKey( id ) )
						return cache[ id ] ;
					return cache[ id ] = new Category( id ) ;
					}
				}

			static public Category Exists( UUID id )
				{
				lock( cache )
					{
					if( cache.ContainsKey( id ) )
						return cache[ id ] ;
					return null ;
					}
				}

			class QueryCategory : REST.GetByUUID
				{
				Category category ;
				override protected string  Resource         { get { return "Inventory/Category" ; } }
				override protected Scalar  SD               { set { category.Queried( value ) ;  } }
				internal Category          Category         { get { return category ; } }
				override public UUID       ID               { get { return category.ID ; } } 
				public QueryCategory( Category category )   { this.category = category ; }
				}

			[Status.Startup]
			public class ResourceDone : REST.Resource
				{
				private ResourceDone() : base( "/Inventory/Category" ) {}
				public override void Post( REST.Resource.Context context )
					{
					Scalar m = context.XML ;
					UUID id = (UUID) m["ID"] ;
					Category c = Category.Find( (UUID) m["ID"] ) ;
					c.Queried( m ) ;
					Scalar s = new Scalar.Map() ;
					s["status"] = "ok" ;
					context.XML = s ;
					}
				}
				
			public void Requery()
				{
				qa.Requery( (c) => Changed() ) ;  
				}

			public void Queried( Scalar s )
				{
				qa.Queried( s ) ;
				}
				
			public void Query( Action<Category> a )
				{
				qa.Query( a ) ;
				}
			
			private Category( UUID id )
				{
				this.id      = id ;
				qa           = new QueryAction<Category>( this,
				                 () => REST.Queue( new QueryCategory( this ) ),
				                 (s) => { lock( this ) sd = s ; }
				                 ) ;
				qa.Queryable = true ;
				}
			}
		}
	}
