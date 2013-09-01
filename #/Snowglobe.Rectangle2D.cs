/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

namespace Snowglobe
	{
	public struct Rectangle2D<T>
		{
		public T X ;
		public T Y ;
		public T Width ;
		public T Height ;
		
		public Point2D<T> Origin
			{
			get { return new Point2D<T>( X, Y ) ; }
			set { X = value.X ; Y = value.Y; }
			}

		public Size2D<T>  Size
			{
			get { return new Size2D<T>( Width, Height ) ; }
			set { Width = value.Width ; Height = value.Height; }
			}
			
		public Rectangle2D( T x, T y, T width, T height )
			{
			X       = x ;
			Y       = y ;
			Width   = width ;
			Height  = height ;
			}

		public Rectangle2D( Point2D<T> origin, Size2D<T> size )
            : this( origin.X, origin.Y, size.Width, size.Height ) {}
		}
	}
