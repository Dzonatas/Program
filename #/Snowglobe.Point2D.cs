/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

namespace Snowglobe
	{
	public struct Point2D<T>
		{
		public T X ;
		public T Y ;

		static public Point2D<T> Zero = new Point2D<T>() ;

		public Point2D( T x, T y )
			{
			X = x ;
			Y = y ;
			}

		public Point2D<T> Vector( System.Func<T,T> expression )
			{
			return new Point2D<T>
				(
				expression( X ),
				expression( Y )
				);
			}

		public Point2D<T> Vector( Point2D<T> operand, System.Func<T,T,T> expression )
			{
			return new Point2D<T>
				(
				expression( X, operand.X ),
				expression( Y, operand.Y )
				);
			}
			
		public T Scalar( System.Func<T,T,T> expression )
			{
			return expression( X, Y ) ;
			}

		public override bool Equals( object o )
			{
			if( o == null )
				return false ;
			Point2D<T> a = (Point2D<T>) o ;
			return X.Equals( a.X ) && Y.Equals( a.Y ) ;
			}

		public static bool operator ==( Point2D<T> a, Point2D<T> b )
			{
			return a.X.Equals( b.X ) && a.Y.Equals( b.Y )  ;
			}

		public static bool operator !=( Point2D<T> a, Point2D<T> b )
			{
			return ! a.Equals( b ) ;
			}

		public override int GetHashCode()
			{
			return X.GetHashCode() ^ Y.GetHashCode() ;
			}

		public override string ToString()
			{
			return System.String.Format("Point2D<T>[ {0}, {1} ]", X, Y) ;
			}

		}
	}
