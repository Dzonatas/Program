using System.Threading ;
using System.Diagnostics ;
using System ;

namespace Application
	{
	[Program.Singleton]
	public sealed class Processor
		{
		static public Action                               Process      = () => {} ;
		static Thread                                      thread       = new Thread( new ThreadStart( process ) ) ;
		static bool                                        loop         = true ;
		static EventWaitHandle                             activity     = new EventWaitHandle( false, EventResetMode.AutoReset ) ;
		
		static public bool Loop
			{
			get { return loop ; }
			set { loop = value ; activity.Set() ; Console.WriteLine("Loop={0}", loop ) ; }
			}
		
		static void process()
			{
			Debug.WriteLine( "Processor started." ) ;
			while( loop )
				{
				activity.WaitOne() ;
				Process() ;
				}
			Debug.WriteLine( "Processor ended." ) ;
			}

		void run()
			{
			thread.Start() ;
			}

		private Processor()
			{
			Program.Run += run ;
			}
		
		[System.Diagnostics.Conditional("DEBUG")]
		static void debug()
			{
			thread.Join() ;
			}
			
		~Processor()
			{
			Program.Run -= run ;
			Loop = false ;
			debug() ;
			}
		}
	}