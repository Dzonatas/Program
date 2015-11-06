using System.Collections.Generic ;
using System.Diagnostics ;
using System ;

namespace Cluster
	{
	public partial class Task
		{
		static Queue<Task>                                 tasks        = new Queue<Task>() ;

		[Program.Singleton]
		public sealed class Iterator
			{
			static void process()
				{
				int n ;
				Task t = null ;
				Task p = null ;
				do
					{
					lock( tasks )
						{
						if( tasks.Count > 0 )
							t = tasks.Dequeue() ;
						while( tasks.Count > 0 && null != ( p = Task.Combine( t, tasks.Peek() ) ) )
							{
							t = p ;
							tasks.Dequeue() ;
							}
						}
					n = tasks.Count ;
					if( t != null )
						Task.Process( t ) ;
					} while( n > 0 ) ;
				}
			
			private Iterator()
				{
				Processor.Loop = true ;
				Processor.Process += process ;
				}
			
			~Iterator()
				{
				Processor.Loop = false ;
				Processor.Process -= process ;
				}
			}
			
		virtual protected Task Combine( Task b )
			{
			return null ;
			}
			
		static internal Task Combine( Task a, Task b )
			{
			return a.Combine( b ) ;
			}
			
		static public void Queue( Task t )
			{
			lock( tasks )
				tasks.Enqueue( t ) ;
			Processor.Loop = true ;
			}

		static public void QueueDelayed( Task t )
			{
			t.Delay( delay ) ;
			Queue( t ) ;
			}
		}
	}