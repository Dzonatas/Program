/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Collections ;
using System ;

namespace Snowglobe
	{
	public class QueryAction<T> where T : class
		{
		bool                 queryable ;
		bool                 inqueried ;
		bool                 done ;
		T                    instance ;
		Action               actionQuery ;
		Action<Scalar>       actionQueried ;
		Queue< Action<T> >   actions ;
		
		protected virtual void query()
			{
			if( actionQuery != null )
				actionQuery() ;
			}

		protected virtual void queried( Scalar s )
			{
			if( actionQueried != null )
				actionQueried( s ) ;
			}
		
		public bool Queryable
			{
			set
				{
				lock( instance )
					{
					queryable = value ;
					inquire() ;
					}
				} 
			}
			
		void inquire()
			{
			if( queryable && actions != null && actions.Count > 0 && ! inqueried )
				{
				inqueried = true ;
				query() ;
				}
			}
			
		public void Requery( Action<T> action )
			{
			lock( instance )
				{
				done       = false ;
				inqueried  = false ;
				Query( action ) ;
				}
			}

		public void Query( Action<T> action )
			{
			lock( instance )
				{
				if( done )
					{
					if( action != null )
						action( instance ) ;
					}
				else
					{
					if( actions == null )
						actions = new Queue< Action<T> >() ;
					actions.Enqueue( action ) ;
					inquire() ;
					}
				}
			}
		
		public void Queried( Scalar info )
			{
			lock( instance )
				{
				queried( info ) ;
				done = true ;
				if( actions != null )
					{
					while( actions.Count > 0 )
						{
						Action<T> action = actions.Dequeue() ;
						action( instance ) ;
						}
					actions = null ;
					}
				}
			}
			
		public QueryAction( T instance )
			{
			queryable       = false ;
			done            = false ;
			inqueried       = false ;
			this.instance   = instance ;
			}

		public QueryAction( T instance, Action query, Action<Scalar> queried )
			{
			queryable             = false ;
			done                  = false ;
			inqueried             = false ;
			this.instance         = instance ;
			this.actionQuery      = query ;
			this.actionQueried    = queried ;
			}
		}
	}