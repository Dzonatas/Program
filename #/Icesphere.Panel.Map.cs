/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Collections ;
using System.IO ;
//using System.Drawing.Imaging ;
//using System.Drawing ;
using System ;
using Gtk ;
using Glade ;
using Snowglobe ;
using Pango ;

namespace Icesphere.Panel
	{
	public class Map : UI.View
		{
		#pragma warning disable 649
		[Glade.Widget] internal Gtk.Button         ButtonWorldMapShowLocation ;
		[Glade.Widget] internal Gtk.ComboBoxEntry  ComboWorldMapSearch ;
		[Glade.Widget] internal Gtk.Alignment      AlignmentWorldMapObjects ;
		[Glade.Widget] internal Gtk.SpinButton     SpinButtonWorldMapX ;
		[Glade.Widget] internal Gtk.SpinButton     SpinButtonWorldMapY ;
		[Glade.Widget] internal Gtk.SpinButton     SpinButtonWorldMapZ ;
		#pragma warning restore 649

		Gtk.DrawingArea      area     = new Gtk.DrawingArea() ;
		Gtk.Image            image    = new Gtk.Image() ;
		Point2D<double>      center   = new Point2D<double>( Double.NaN, Double.NaN ) ;
		Point2D<double>      invalid  = new Point2D<double>( Double.NaN, Double.NaN ) ;
		
		Pango.Layout  layout ;
		
		const int       MAP_LEVELS          = 8 ;
		const int       MAP_TILE_SIZE       = 256 ;
		const double    REGION_WIDTH_METERS = 256 ;
		
		internal static Action<ImageMipMap> UpdatedMipMap ;
		
		static Dictionary<string, ImageMipMap>   tiles = new Dictionary<string, ImageMipMap>() ;
		//List<ImageMipMap>                 active = new List<ImageMipMap>() ;

		internal static Func<int,int>           subdivisions  = (level)     => 1 << ( level-1 ) ;
		internal static Func<int,int>           tilesInPixels = (pixels)    => (MAP_TILE_SIZE + pixels - 1) / MAP_TILE_SIZE ;
		internal static Func<double,int,int>    mapToMip      = (map,level) => { int x = (int) Math.Truncate( map / REGION_WIDTH_METERS ) ; return x - x % subdivisions( level ) ; } ;
		
		internal struct PointMipMap
			{
			public int X ;
			public int Y ;
			public int Level ;

			public override bool Equals( object o )
				{
				if( o == null )
					return false ;
				PointMipMap pmm = (PointMipMap) o ;
				return ( X == pmm.X ) && ( Y == pmm.Y ) && ( Level == pmm.Level ) ;
				}

			public override int GetHashCode()
				{
				return X.GetHashCode() ^ Y.GetHashCode() ^ Level.GetHashCode() ;
				}
			}

		internal class ImageMipMap
			{
			PointMipMap  pmm ;
			Gdk.Pixbuf   pb = null ;
			
			public Gdk.Pixbuf Pixbuf
				{
				get { lock( this ) return pb ; }
				}

			public PointMipMap Point
				{
				get { lock( this ) return pmm ; }
				}
			
			class QueryMipMap : REST.Task
				{
				ImageMipMap   imm ;
				Uri           uri ;
				MemoryStream  memory ;
				override protected void Process()
					{
					Hypertext  ht  = new Hypertext( uri ) ;
					memory         = ht.Process( "GET" ) ;
					if( ! ht.Success )
						{
						//Debug.WriteLine("Image missing: X={0} Y={1} Level={2}", imm.Point.X, imm.Point.Y, imm.Point.Level ) ;
						// TODO:DZ missing image
						return ;
						}
					Gdk.Pixbuf pb ;
					try
						{
						pb = new Gdk.Pixbuf( memory ) ;
						}
					catch( Exception )
						{
						return ;
						}
					imm.updateImage( pb ) ;
					}
				internal QueryMipMap( ImageMipMap imm, PointMipMap pmm )
					{
					this.imm = imm ;
					uri = new Uri( "http://map.secondlife.com.s3.amazonaws.com/map-" + pmm.Level.ToString() + "-" + pmm.X.ToString() + "-" + pmm.Y.ToString() + "-objects.jpg" ) ;
					//Debug.WriteLine( uri ) ;
					}
				}
				
			void updateImage( Gdk.Pixbuf pb )
				{
				lock( this )
					this.pb = pb ;
				UpdatedMipMap( this ) ;
				}
				
			internal ImageMipMap( PointMipMap pmm )
				{
				this.pmm = pmm ;
				REST.Queue( new QueryMipMap( this, pmm ) ) ;
				}
			}
		
		void updatedMipMap( ImageMipMap imm )
			{
			mipmap.Update( imm ) ;
			//image.Pixbuf = imm.Pixbuf ;
			/*
			Point2D<int> p = new Point2D<int>() ;
			Gdk.Pixbuf pb ;
			mipmap.Update( imm ) ;
			lock( lobj )
				{
				pb  = pixbuf ;
				p.X = imm.Point.X - pmmNE.X ;
				p.Y = imm.Point.Y - pmmNE.Y ;
				p.X *= MAP_TILE_SIZE ;
				p.Y *= -MAP_TILE_SIZE ;
				Debug.WriteLine( "image updated {0} {1}", p.X, p.Y  ) ;
				// TODO:DZ check bounds
				}
			imm.Pixbuf.CopyArea ( 0, 0,  MAP_TILE_SIZE, MAP_TILE_SIZE,  pb, p.X, p.Y) ;
			*/
			Gtk.Application.Invoke( (o,e) => area.QueueDraw() ) ;
			}
			
		static ImageMipMap mapTile( PointMipMap pmm )
			{
			string serial = pmm.Level.ToString() + "-" + pmm.X.ToString() + "-" + pmm.Y.ToString() ;
			if( tiles.ContainsKey( serial ) )
				{
				//Debug.WriteLine( "cached {0} {1} {2} {3}", pmm.X, pmm.Y, pmm.Level, serial ) ;
				return tiles[ serial ] ;
				}
			//Debug.WriteLine( "retrieve {0} {1} {2} {3}", pmm.X, pmm.Y, pmm.Level, serial ) ;
			return tiles[ serial ] = new ImageMipMap( pmm ) ;
			}
		
		object lobj = new object() ;

		class MipMap
			{
			List<ImageMipMap>         tiles = new List<ImageMipMap>() ;
			Rectangle2D<int>          mip ;
			Rectangle2D<double>       map ;
			int                       level ;
			Gdk.Pixbuf                pixbuf ;

			public Point2D<double>    MapSE       { get { return map.Origin ; } }
			public Point2D<double>    MapNW       { get { return new Point2D<double>( map.Size.Width + map.Origin.X, map.Size.Height + map.Origin.Y ) ; } }
			public Point2D<double>    MapNE       { get { return new Point2D<double>( map.Origin.X, map.Size.Height + map.Origin.Y ) ; } }
			public Point2D<double>    MapSW       { get { return new Point2D<double>( map.Size.Width + map.Origin.X, map.Origin.Y ) ; } }

			public Point2D<int>       MipSE       { get { return mip.Origin ; } }
			public Point2D<int>       MipNW       { get { return new Point2D<int>( mip.Size.Width + mip.Origin.X, mip.Size.Height + mip.Origin.Y ) ; } }
			public Point2D<int>       MipNE       { get { return new Point2D<int>( mip.Origin.X, mip.Size.Height + mip.Origin.Y ) ; } }
			public Point2D<int>       MipSW       { get { return new Point2D<int>( mip.Size.Width + mip.Origin.X, mip.Origin.Y ) ; } }

			public Gdk.Pixbuf         Pixbuf      { get { return pixbuf ; } }
			
			void update()
				{
				Point2D<int>   nw   = MipNW ;
				Point2D<int>   se   = MipSE ;
				PointMipMap    p    = new PointMipMap() ;
				p.Level             = 1 ;
				tiles.Clear() ;
				for( p.X = se.X ; p.X < nw.X ; ++p.X )
					{
					for( p.Y = se.Y ; p.Y < nw.Y ; ++p.Y )
						{
						tiles.Add( mapTile( p ) ) ;
						}
					}
				}
			
			public void Update()
				{
				//Debug.WriteLine("MipMap.Update") ;
				lock( this )
					update() ;
				}

			public void Update( ImageMipMap imm )
				{
				Point2D<int> p = new Point2D<int>() ;
				p.X = imm.Point.X - MipNE.X ;
				p.Y = imm.Point.Y - MipNE.Y ;
				p.X *= MAP_TILE_SIZE ;
				p.Y *= -MAP_TILE_SIZE ;
				p.Y -= MAP_TILE_SIZE ;
					//Debug.WriteLine( "image updated {0} {1}", p.X, p.Y  ) ;
					// TODO:DZ check bounds
				imm.Pixbuf.CopyArea ( 0, 0,  MAP_TILE_SIZE, MAP_TILE_SIZE,  pixbuf, p.X, p.Y) ;
				}
				
			public Point2D<double> Origin
				{
				set
					{
					map.Origin      = value.Vector( (v) => Math.Truncate( v / 256 ) ) ;
					mip.Origin      = new Point2D<int>(  (int) map.X, (int) map.Y  ) ;
					mip.Origin      = mip.Origin.Vector(  (v) => v - v % subdivisions( level ) ) ;
					map.X           = mip.X * 256 ;
					map.Y           = mip.Y * 256 ;
					}
				}
			
			public Size2D<int> Size
				{
				get
					{
					return mip.Size ;
					}
				}

			public MipMap( Point2D<double> se, Size2D<int> size_tiles, int level )
				{
				this.level      = level ;
				Origin          = se ;
				mip.Size        = size_tiles ;
				map.Width       = mip.Width  * 256 ;
				map.Height      = mip.Height * 256 ;
				pixbuf     = new Gdk.Pixbuf( Gdk.Colorspace.Rgb, false, 8, mip.Size.Width * MAP_TILE_SIZE, mip.Size.Height * MAP_TILE_SIZE ) ;
				//update() ;
				}
			}
			
		MipMap mipmap ;
		
/*		void mapArray()
			{
			PointMipMap pmm = PointMipMap.FromGlobalPosition( center, level ) ;
			lock( lobj )
				{
				//active.Clear() ;
				pmm.X -= (int) sizeTiles.Width  / 2 ;
				pmm.Y += (int) sizeTiles.Height / 2 ;
				pmmNE  = pmm ;
				cornerNE.X = ( Math.Truncate( center.X / REGION_WIDTH_METERS ) - (double)(sizeTiles.Width / 2) ) * REGION_WIDTH_METERS ;
				cornerNE.Y = ( Math.Truncate( center.Y / REGION_WIDTH_METERS ) + (double)(sizeTiles.Height / 2) ) * REGION_WIDTH_METERS + REGION_WIDTH_METERS ;
				for( int x = 0 ; x < sizeTiles.Width ; ++x )
					{
					PointMipMap xpmm = pmm ;
					xpmm.X += x ;
					for( int y = 0; y < sizeTiles.Height ; ++y )
						{
						PointMipMap xypmm = xpmm ;
						xypmm.Y -= y ;
						//Debug.WriteLine( "MA {0}, {1} :: {2}, {3}", x, y, xypmm.X, xypmm.Y ) ;
						//array[ (x * sizeTiles.Width) + y ] = mapTile( xypmm ) ;
						active.Add( mapTile( xypmm ) ) ;
						}
					}
				}
			}
*/			
		void allocated( object o, SizeAllocatedArgs a )
			{
			updateMap() ;

			//mipmap = new MipMap( origin, size, 1 ) ;    
			/*
			Point2D<double> cornerNE ;
			Size2D<int> sizePixbuf ;
			Size2D<int> sizeTiles ;
			Size2D<int> sizePixels ;
			Gdk.Pixbuf pixbuf ;

				Size2D<int> st         = sizePixbuf ;
				sizePixels.Height  = a.Allocation.Height ;
				sizePixels.Width   = a.Allocation.Width ;
				sizeTiles.Width    = tilesInPixels( sizePixels.Width ) ;
				sizeTiles.Height   = tilesInPixels( sizePixels.Height ) ;
				sizePixbuf.Width   = sizeTiles.Width  * MAP_TILE_SIZE ;
				sizePixbuf.Height  = sizeTiles.Height * MAP_TILE_SIZE ;
				Point2D<double> se         = new Point2D<double>() ;
				se.X               = 
				mipmap = new MipMap( center, sizetiles, 1 ) ;
				}
			*/
			// mapArray() ;
			}

		void realized( object o, EventArgs e )
			{
			layout = new Pango.Layout (area.PangoContext);
			layout.Wrap = Pango.WrapMode.Word;
			layout.FontDescription = FontDescription.FromString ("Tahoma 16");
			layout.SetMarkup ("testing text hello Pango.Layout");
  
			//Snowglobe.Toolbar.OnClickedMap() ;
			//showLocation( null, null ) ;
			}

		void activatedSearchEntry()
			{
			//Snowglobe.WorldMap wm = new Snowglobe.WorldMap() ;
			//wm.TrackURL( ComboWorldMapSearch.Entry.Text, 100, 100 ,100 ) ;
			}
			
		void updateMap()
			{
			//Debug.WriteLine( "!!!========= center {0}", center ) ;
			if( center == invalid )
				return ;
			Size2D<int>     pixels  = new Size2D<int>( area.Allocation.Width, area.Allocation.Height ) ;
			Size2D<int>     size    = pixels.Vector( (v) => tilesInPixels( v ) ) ;
			Point2D<double> middle  = new Point2D<double>( pixels.Width / 2, pixels.Height / 2 ) ;
			Point2D<double> origin  = center.Vector( middle, (c,m) => c - m ) ;
			//Debug.WriteLine( "P={0} || S={1} || M={2} || O={3}", pixels, size, middle, origin ) ;

			if( mipmap == null || mipmap.Size != size )
				mipmap = new MipMap( origin, size, 1 ) ;
			else
				mipmap.Origin = origin ;
				
			mipmap.Update() ;
			//Debug.WriteLine( "========= center {0}", center ) ;
			//if( mipmap != null )
			//mipmap.Update() ;
			//mapArray() ;
			}

		void showLocation()
			{
			Snowglobe.REST.Queue( new Snowglobe.Agent.QueryPosition() ) ;
			Point3D<double> p = new Point3D<double>() ;
			p.X = SpinButtonWorldMapX.Value ;
			p.Y = SpinButtonWorldMapY.Value ;
			p.Z = SpinButtonWorldMapZ.Value ;
			// center = p TODO: convert to global
			updateMap() ;
			}
			
		void updatePosition()
			{
			Point3D<double> p  = Agent.Position ;
			SpinButtonWorldMapX.Value = p.X ;
			SpinButtonWorldMapY.Value = p.Y ;
			SpinButtonWorldMapZ.Value = p.Z ;
			}
			
		void agentPositionUpdated()
			{
			Point3D<double> p = Agent.GlobalPosition ;
			//Debug.WriteLine( "========= GB {0}", p ) ;
			center = new Point2D<double>( p.X, p.Y ) ;
			//Debug.WriteLine( "========= center {0}", center ) ;
			updatePosition() ;
			updateMap() ;
			}
			
		void exposed( object o, ExposeEventArgs args )
			{
			//Gdk.EventExpose expose    = args.Event ;
			//Gdk.Rectangle sizeExposed = expose.Area ;
			Gdk.GC gc                 = area.Style.BaseGC(StateType.Normal) ;
			//Debug.WriteLine( "exposed" ) ;
			
			if( mipmap == null )
				return ;			
			//area.GdkWindow.DrawLayout (area.Style.TextGC (StateType.Normal), 100, 150, layout);	

			Point2D<int> p ;
			p.X  = (int)( area.Allocation.Width  / 2 ) ;
			p.Y  = (int)( area.Allocation.Height / 2 ) ;
			
			MipMap mm = mipmap ;
			p.X += (int)( mm.MapNE.X - center.X ) ;
			p.Y -= (int)( mm.MapNE.Y - center.Y ) ;
			area.GdkWindow.DrawPixbuf (gc, mm.Pixbuf,  0, 0,  p.X, p.Y,  -1, -1,  Gdk.RgbDither.None, 0, 0 ) ;
			}


			/*
			for( int x = 0 ; x < st.Width ; ++x )
				{
				Point2D<int> xp = p ;
				xp.X += x * MAP_TILE_SIZE ;
				for( int y = 0; y < st.Height ; ++y )
					{
					Point2D<int> xyp = xp ;
					xyp.Y += y * MAP_TILE_SIZE ;
					ImageMipMap imm = map[ (x * st.Width) + y ] ;
					if( imm == null || imm.Pixbuf == null )
						continue ;
					//area.GdkWindow.DrawPixbuf (gc, imm.Pixbuf,  0, 0,  xyp.X, xyp.Y,  MAP_TILE_SIZE, MAP_TILE_SIZE,  Gdk.RgbDither.Normal, 0, 0 ) ;
					//public void Composite (Pixbuf dest, int dest_x, int dest_y, int dest_width, int dest_height, double offset_x, double offset_y, double scale_x, double scale_y, InterpType interp_type, int overall_alpha)
					
					//imm.Pixbuf.Composite( pb,
					//	xyp.X, xyp.Y,                    // dest x y
					//	MAP_TILE_SIZE, MAP_TILE_SIZE,    // dest w h
					//	0, 0,                            // offset x y
					//	1, 1,                            // scale x y
					//	Gdk.InterpType.Nearest,          // Nearest, Tiles, Bilinear, Hyper: (fastest/low to slowest/high) quality
					//	255) ;
						
					//imm.Pixbuf.CopyArea (int src_x, int src_y, int width, int height, Pixbuf dest_pixbuf, int dest_x, int dest_y)
					//imm.Pixbuf.CopyArea ( 0, 0,  MAP_TILE_SIZE, MAP_TILE_SIZE,  pb, xyp.X, xyp.Y) ;
					}
				}
			*/
			
			//Debug.WriteLine( "DP {0} {1} ", (int)(cornerNE.X - center.X) , (int)(cornerNE.Y - center.Y) ) ;
			
			//Debug.WriteLine( "EX {0} {1} {2} {3}", rect.X, rect.Y, rect.Width, rect.Height ) ;
			//area.GdkWindow.DrawPixbuf (gc, pb,  0, 0,  0, 0,  sizePixbuf.Width, sizePixbuf.Height,  Gdk.RgbDither.None, 0, 0 ) ;

			
		override protected void Shown()
			{
			Snowglobe.REST.Queue( new Snowglobe.Agent.QueryPosition() ) ;
			Point3D<double> p = Agent.GlobalPosition ;
			//Debug.WriteLine( "===" ) ;
			center = new Point2D<double>( p.X, p.Y ) ;
			Agent.PositionChanged += agentPositionUpdated ;
			agentPositionUpdated() ;
			updatePosition() ;
			updateMap() ;
			}

		override protected void Hidden()
			{
			Agent.PositionChanged -= agentPositionUpdated ;
			tiles.Clear() ; 
			}

		public Map() : base( "map" )
			{
			area.SetSizeRequest( 600, 600 ) ;
			area.ModifyBg( Gtk.StateType.Normal, UI.Color.Black ) ;
			area.Realized              += realized ;
			area.ExposeEvent           += exposed ;
			area.Show() ;
			
			UpdatedMipMap += updatedMipMap ;
			AlignmentWorldMapObjects.Add( area ) ;
			AlignmentWorldMapObjects.SizeAllocated  += allocated ;
			ButtonWorldMapShowLocation.Clicked      += (o,e) => showLocation() ;
			ComboWorldMapSearch.Entry.Activated     += (o,e) => activatedSearchEntry() ;
			}
		}
	}