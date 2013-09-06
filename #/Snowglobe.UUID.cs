/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/


using System ;

namespace Snowglobe
	{
	public class UUID : Icesphere.Universal.UID
		{
		static new public UUID Zero = new UUID( Icesphere.Universal.UID.Zero ) ;

		public new static UUID Unique
			{
			get { return new UUID( Icesphere.Universal.UID.Unique ) ; }
			}

		public static UUID operator ^( UUID a, UUID b )
			{
			byte[] x = a.id.ToByteArray() ;
			byte[] y = b.id.ToByteArray() ;
			const int byteArrayLength = 16 ;
			for( int i = 0 ; i < byteArrayLength ; i++ )
				x[i] ^= y[i] ;
			return new UUID( new Icesphere.Universal.UID( new Guid( x ) ) ) ;
			}

		public UUID( Icesphere.Universal.UID u )
			: base( u ) {}

//		public UUID( Snowglobe.UUID u )
//			: base( (System.Guid) u ) {}
		}
	}
