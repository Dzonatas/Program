using System.Collections.Generic ;
using System ;

namespace Cluster
	{
	public partial class Task
		{
		static List<Task>                                  delayed      = new List<Task>() ;
		const  int                                         delay        = 10 ;
		System.Timers.Timer                                timer ;
			
		public bool Delayed
			{
			get { lock( this ) return null != timer && timer.Enabled ; }
			}
			
		public void Delay( uint seconds )
			{
			lock( this )
				{
				if( null == timer )
					{
					timer = new System.Timers.Timer() ;
					timer.Stop() ;
					timer.AutoReset = false ;
					timer.Elapsed += (o,e) => elapsed() ;
					}
				timer.Interval =  seconds * 1000 ;
				timer.Start() ;
				}
			}
			
		void elapsed()
			{
			Queue( this ) ;
			lock( delayed )
				if( delayed.Contains( this ) )
					delayed.Remove( this ) ;
			}
			
		virtual protected void Process() { throw new NotImplementedException() ; }
		
		static internal void Process( Task t )
			{
			if( t.Delayed )
				{
				lock( delayed )
					if( ! delayed.Contains( t ) )
						delayed.Add( t ) ;
				return ;
				}
			t.Process() ;
			}
			
		override public string ToString()
			{
			return GetType().ToString() ;
			}
		}
	}