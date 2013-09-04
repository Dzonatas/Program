/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Collections ;
using System.Reflection ;
using System.Text ;
using System ;

namespace Snowglobe
	{
	public abstract class Asset
		{
		UUID                     id ;
		Scalar                   info ;
		QueryAction<Asset>       qa ;
		static Cache                     cache      = new Cache() ;
		
		class InnerCache : Dictionary<UUID,Asset> {}
		
		class Cache : Dictionary<System.Type, InnerCache>
			{
			public Cache()
				{
				this[ typeof(Notecard) ] = new InnerCache() ;
				this[ typeof(Gesture) ]  = new InnerCache() ;
				}
			}

		public UUID ID
			{
			get { return id ; }
			}
			
		public class Notecard : Asset
			{
			class QueryAssetNotecard : REST.GetByUUID
				{
				Asset  asset ;
				override protected string  Resource              { get { return "Asset/Notecard" ; } }
				override protected Scalar  SD                    { set { asset.Queried( value ) ;  } }
				internal Asset             Asset                 { get { return asset ; } }
				override public UUID       ID                    { get { return asset.ID ; } }
				public QueryAssetNotecard( Asset asset )         { this.asset = asset ; }
				}
			override protected void query()
				{
				REST.Queue( new QueryAssetNotecard( this ) ) ;
				}
			internal Notecard( UUID id ) : base( id, typeof( Notecard ) )
				{
				//Debug.WriteLine("new notecard {0}", id ) ;
				}
			} 

		public class Script : Asset
			{
			override protected void query()
				{
				//Debug.WriteLine("Asset Query {0} {1}", id, GetType() ) ;
				}
			internal Script( UUID id ) : base( id, typeof( Script ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}

		public class Object : Asset
			{
			override protected void query()
				{
				//Debug.WriteLine("Asset Query {0} {1}", id, GetType() ) ;
				}
			internal Object( UUID id ) : base( id, typeof( Object ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}

		public class Texture : Asset
			{
			override protected void query()
				{
				//Debug.WriteLine("Asset Query {0} {1}", id, GetType() ) ;
				}
			internal Texture( UUID id ) : base( id, typeof( Texture ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}

		public class Animation : Asset
			{
			override protected void query()
				{
				//Debug.WriteLine("Asset Query {0} {1}", id, GetType() ) ;
				}
			internal Animation( UUID id ) : base( id, typeof( Animation ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}

		public class Landmark : Asset
			{
			override protected void query()
				{
				//Debug.WriteLine("Asset Query {0} {1}", id, GetType() ) ;
				}
			internal Landmark( UUID id ) : base( id, typeof( Landmark ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}

		public class Sound : Asset
			{
			override protected void query()
				{
				//Debug.WriteLine("Asset Query {0} {1}", id, GetType() ) ;
				}
			internal Sound( UUID id ) : base( id, typeof( Sound ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}

		public class Gesture : Asset
			{
			class QueryAssetGesture : REST.GetByUUID
				{
				Asset  asset ;
				override protected string  Resource              { get { return "Asset/Gesture" ; } }
				override protected Scalar  SD                    { set { asset.Queried( value ) ;  } }
				internal Asset             Asset                 { get { return asset ; } }
				override public UUID       ID                    { get { return asset.ID ; } }
				public QueryAssetGesture( Asset asset )          { this.asset = asset ; }
				}
			override protected void query()
				{
				REST.Queue( new QueryAssetGesture( this ) ) ;
				}
			internal Gesture( UUID id ) : base( id, typeof( Gesture ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}
			
		public class Callcard : Asset
			{
			override protected void query()
				{
				//Debug.WriteLine("Asset Query {0} {1}", id, GetType() ) ;
				}
			internal Callcard( UUID id ) : base( id, typeof( Callcard ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}
			
		public class Snapshot : Asset
			{
			override protected void query()
				{
				//Debug.WriteLine("Asset Query {0} {1}", id, GetType() ) ;
				}
			internal Snapshot( UUID id ) : base( id, typeof( Snapshot ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}
			
		public class Wearable : Asset
			{
			override protected void query()
				{
				//Debug.WriteLine("Asset Query {0} {1}", id, GetType() ) ;
				}
			internal Wearable( UUID id ) : base( id, typeof( Wearable ) )
				{
				//Debug.WriteLine("new {0} {1}", GetType(), id ) ;
				}
			}
				
		static public System.Type ConvertType( string type )
			{
			if( "notecard"  == type )  return typeof( Asset.Notecard  ) ;
			if( "script"    == type )  return typeof( Asset.Script    ) ;
			if( "object"    == type )  return typeof( Asset.Object    ) ;
			if( "texture"   == type )  return typeof( Asset.Texture   ) ;
			if( "animation" == type )  return typeof( Asset.Animation ) ;
			if( "landmark"  == type )  return typeof( Asset.Landmark  ) ;
			if( "attach"    == type )  return typeof( Asset.Object    ) ;
			if( "sound"     == type )  return typeof( Asset.Sound     ) ;
			if( "gesture"   == type )  return typeof( Asset.Gesture   ) ;
			if( "callcard"  == type )  return typeof( Asset.Callcard  ) ;
			if( "snapshot"  == type )  return typeof( Asset.Snapshot  ) ;
			if( "wearable"  == type )  return typeof( Asset.Wearable  ) ;
			return null ;
			}
			
		[Status.Startup]
		public class ResourceAssetLoaded : REST.Resource
			{
			private ResourceAssetLoaded() : base( "/Asset/Loaded" ) {}
			public override void Post( REST.Resource.Context context )
				{
				Scalar        m          = context.XML ;
				UUID          id         = (UUID)   m["ID"] ;
				System.Type   type       = Asset.ConvertType( (string) m["Type"] ) ;
				//Debug.WriteLine("Asset loaded id={0} {1}", id, type ) ;
				if( null != type )
					{
					Asset asset = Asset.Find( id, type ) ;
					asset.Queryable        = true ;
					}
				Scalar s = new Scalar.Map() ;
				s["status"] = "ok" ;
				context.XML = s ;
				}
			}
			
		internal bool Queryable
			{
			set { qa.Queryable = value ; }
			}

		public void Queried( Scalar s )
			{
			qa.Queried( s ) ;
			}
			
		public void Query( Action<Asset> a )
			{
			qa.Query( a ) ;
			}
		
		abstract protected void query() ;
		
		void queried( Scalar info )
			{
			if( info == null )
				{
				}
			else
				{
				this.info  = info ;
				}
			}

		public Scalar this[ string s ]
			{
			get { return info[s] ; }
			}

		static public Asset Find( UUID id, System.Type type )
			{
			InnerCache ic = cache[type] ;
			if( ic.ContainsKey( id ) )
				return ic[ id ] ;
			object o = type.InvokeMember(
							null, BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance ,
			        		null, null, new object[] { id } );
			return o as Asset ;
			}

		internal Asset( UUID id, System.Type type )
			{
			this.id             = id ;
			qa                  = new QueryAction<Asset>( this, query, queried ) ;
			qa.Queryable        = false ;
			cache[ type ][ id ] = this ;
			}

		static Asset()
			{
			}
		}
	}
