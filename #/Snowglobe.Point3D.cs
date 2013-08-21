/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections;
using System;

namespace Snowglobe
	{
	public struct Point3D<T>
		{
		public T X ;
		public T Y ;
		public T Z ;

		static public Point3D<T> Zero = new Point3D<T>() ;

		public Point3D( T x, T y, T z )
			{
			X = x ;
			Y = y ;
			Z = z ;
			}
			
		public Point3D<T> Vector( System.Func<T,T> expression )
			{
			return new Point3D<T>
				(
				expression( X ),
				expression( Y ),
				expression( Z )
				);
			}

		public Point3D<T> Vector( Point3D<T> operand, System.Func<T,T,T> expression )
			{
			return new Point3D<T>
				(
				expression( X, operand.X ),
				expression( Y, operand.Y ),
				expression( Z, operand.Z )
				);
			}

		public T Scalar( System.Func<T,T,T,T> expression )
			{
			return expression( X, Y, Z ) ;
			}

		public override bool Equals( object o )
			{
			if( o == null )
				return false ;
			Point3D<T> a = (Point3D<T>) o ;
			return X.Equals( a.X ) && Y.Equals( a.Y ) && Z.Equals( a.Z ) ;
			}

		public static bool operator ==( Point3D<T> a, Point3D<T> b )
			{
			return a.X.Equals( b.X ) && a.Y.Equals( b.Y ) && a.Z.Equals( b.Z ) ;
			}

		public static bool operator !=( Point3D<T> a, Point3D<T> b )
			{
			return ! a.Equals( b ) ;
			}

		public override int GetHashCode()
			{
			return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ;
			}

		public override string ToString()
			{
			return String.Format("Point3D<T>[ {0}, {1}, {2} ]", X, Y, Z ) ;
			}
		}
	}
