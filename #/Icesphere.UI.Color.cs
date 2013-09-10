/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System ;
using Gtk ;

namespace Icesphere.UI
	{
	public class Color
		{
		// Primary Colors
		public static Color      Red     = new Space.RGB( 0.5, 0.0, 0.0 ) ;
		public static Color      Green   = new Space.RGB( 0.0, 0.5, 0.0 ) ;
		public static Color      Blue    = new Space.RGB( 0.0, 0.0, 0.5 ) ;

		// Secondary Colors
		public static Color      Magenta = new Space.RGB( 0.5, 0.0, 0.5 ) ;
		public static Color      Yellow  = new Space.RGB( 0.5, 0.5, 0.0 ) ;
		public static Color      Cyan    = new Space.RGB( 0.0, 0.5, 0.5 ) ;
		
		// Absolute Palette
		public static Color      White     = new Space.RGB( 0xFFFFFF ) ;
		public static Color      Black     = new Space.RGB( 0x000000 ) ;
		
		// Tango Palette
		public static Color      ButterLight          = new Space.RGB( 0xfce94f ) ;
		public static Color      Butter               = new Space.RGB( 0xEDD400 ) ;
		public static Color      ButterDark           = new Space.RGB( 0xc4a000 ) ;
		public static Color      OrangeLight          = new Space.RGB( 0xfcaf3e ) ;
		public static Color      Orange               = new Space.RGB( 0xF57900 ) ;
		public static Color      OrangeDark           = new Space.RGB( 0xce5c00 ) ;
		public static Color      ChocolateLight       = new Space.RGB( 0xe9b96e ) ;
		public static Color      Chocolate            = new Space.RGB( 0xC17D11 ) ;
		public static Color      ChocolateDark        = new Space.RGB( 0x8f5902 ) ;
		public static Color      ChameleonLight       = new Space.RGB( 0x8ae234 ) ;
		public static Color      Chameleon            = new Space.RGB( 0x73D216 ) ;
		public static Color      ChameleonDark        = new Space.RGB( 0x4e9a06 ) ;
		public static Color      SkyBlueLight         = new Space.RGB( 0x729fcf ) ;
		public static Color      SkyBlue              = new Space.RGB( 0x3465a4 ) ;
		public static Color      SkyBlueDark          = new Space.RGB( 0x204A87 ) ;
		public static Color      PlumLight            = new Space.RGB( 0xad7fa8 ) ;
		public static Color      Plum                 = new Space.RGB( 0x75507B ) ;
		public static Color      PlumDark             = new Space.RGB( 0x5c3566 ) ;
		public static Color      ScarletRedLight      = new Space.RGB( 0xef2929 ) ;
		public static Color      ScarletRed           = new Space.RGB( 0xCC0000 ) ;
		public static Color      ScarletRedDark       = new Space.RGB( 0xa40000 ) ;
		public static Color      AluminiumExtraLight  = new Space.RGB( 0xEEEEEC ) ;
		public static Color      AluminiumLight       = new Space.RGB( 0xD3D7CF ) ;
		public static Color      AluminiumMediumLight = new Space.RGB( 0xBABDB6 ) ;
		public static Color      AluminiumMediumDark  = new Space.RGB( 0x888A85 ) ;
		public static Color      AluminiumDark        = new Space.RGB( 0x555753 ) ;
		public static Color      AluminiumExtraDark   = new Space.RGB( 0x2e3426 ) ;
		

		internal Space           space ;
		public class Space
			{
			public class RGBA : Space
				{
				public float Red ;
				public float Blue ;
				public float Green ;
				public float Alpha ;
				public RGBA( float red, float green, float blue, float alpha )
					{
					Red    = red ;
					Green  = green ;
					Blue   = blue ;
					Alpha  = alpha ;
					}
				public RGBA( double red, double green, double blue, double alpha )
					{
					Red    = (float) red ;
					Green  = (float) green ;
					Blue   = (float) blue ;
					Alpha  = (float) alpha ;
					}
				public static implicit operator Color( RGBA rgba )
					{
					return new Color( rgba ) ;
					}
				public override string ToString()
					{
					return String.Format( "UI.Color.Space.RGBA[ {0}. {1}, {2}, {3} ]", Red, Green, Blue, Alpha ) ;
					}
				}
			public class RGB : RGBA
				{
				public RGB( float red, float green, float blue )
					: base( red, green, blue, 1.0f ) {}
				public RGB( double red, double green, double blue )
					: base( red, green, blue, 1.0 ) {}
				public RGB( uint hex )
					: base(  ( (hex >> 16) & 0xFF ) / 256.0,  ( (hex >> 8) & 0xFF ) / 256.0,  (hex & 0xFF) / 256.0, 1.0  ) {}
				public RGB Dim()
					{
					return new RGB(
						Math.Max( 0.0, Red   - 0.2 ),
						Math.Max( 0.0, Green - 0.2 ),
						Math.Max( 0.0, Blue  - 0.2 )
						);
					}
				public static implicit operator Color( RGB rgb )
					{
					return new Color( rgb ) ;
					}
				public override string ToString()
					{
					return String.Format( "UI.Color.Space.RGB[ {0}. {1}, {2} ]", Red, Green, Blue ) ;
					}
				}
			public class GDK : Space
				{
				static Gdk.Colormap                  map    = Gdk.Colormap.System ;
				static Dictionary<UInt64,Gdk.Color>  allocated = new Dictionary<UInt64,Gdk.Color>() ;
				public new class RGB : GDK
					{
					Gdk.Color color ;
					private void allocate()
						{
						UInt64 hash = (UInt64) color.Red | (UInt64) color.Green << 16 | (UInt64) color.Blue << 32 ;
						if( allocated.ContainsKey( hash ) )
							color = allocated[hash] ;
						else
							{
							map.AllocColor( ref color, false, false ) ;
							allocated.Add( hash, color ) ;
							}
						}
					public RGB( Space.RGB rgb )
						{
						unchecked
							{
							color.Red	= (ushort)( (float) ushort.MaxValue * rgb.Red   + 0.5 ) ;
							color.Green = (ushort)( (float) ushort.MaxValue * rgb.Green + 0.5 ) ;
							color.Blue	= (ushort)( (float) ushort.MaxValue * rgb.Blue  + 0.5 ) ;
							}
						allocate() ;
						}
					public static implicit operator Gdk.Color( RGB rgb )
						{
						return rgb.color ;
						}
					public override string ToString()
						{
						return String.Format( "UI.Color.Space.GDK.RGB[ {0}. {1}, {2}, Pixel={3} ]", color.Red, color.Green, color.Blue, color.Pixel ) ;
						}
					}
				public static Gdk.Colormap Map
					{
					get { return map ; }
					set	{ map = value ; }
					}
				}
			}
		public static implicit operator Gdk.Color( Color color )
			{
			if( color.space is Space.GDK.RGB )
				{
				Space.GDK.RGB r = (Space.GDK.RGB) color.space ;
				return r ;
				}
			if( color.space is Space.RGB )
				{
				Space.GDK.RGB r = new Space.GDK.RGB( (Space.RGB) color.space ) ;
				return r ;
				}
			throw new Exception("Unable to convert UI.Color to Gdk.Color") ;
			}
		public Color( Space space )
			{
			this.space = space ;
			}
		}
	}

