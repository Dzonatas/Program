/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System ;

namespace Snowglobe
	{
	public struct Color4
		{

		public float Red ;
		public float Green ;
		public float Blue ;
		public float Alpha ;

		public static Snowglobe.Color4 Zero = new Snowglobe.Color4 () ;

		public static Color4 Gray = new Color4( 0.8f, 0.8f, 0.8f, 1.0f ) ;
		
		public Color4( float red, float green, float blue, float alpha )
			{
			Red   = red ;
			Green = green ;
			Blue  = blue ;
			Alpha = alpha ;
			}
		public Color4( Gdk.Color color )
			{
			Red	    = (float) ushort.MaxValue / color.Red   ;
			Green   = (float) ushort.MaxValue / color.Green ;
			Blue	= (float) ushort.MaxValue / color.Blue  ;
			Alpha   = 1.0f ;
			}
		public static implicit operator Gdk.Color( Color4 rgb )
			{
			Gdk.Color color = Gdk.Color.Zero ;
			unchecked
				{
				color.Red	= (ushort)( (float) ushort.MaxValue * rgb.Red   + 0.5 ) ;
				color.Green = (ushort)( (float) ushort.MaxValue * rgb.Green + 0.5 ) ;
				color.Blue	= (ushort)( (float) ushort.MaxValue * rgb.Blue  + 0.5 ) ;
				}
			return color ;
			}
		public override string ToString()
			{
			return String.Format("RGBA[ {0}, {1}, {2}, {3} ]", Red, Green, Blue, Alpha ) ;
			}
		}
	}