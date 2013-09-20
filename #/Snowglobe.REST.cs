/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Collections ;
using System.Reflection ;
using System.Threading ;
using System.Timers ;
using System.Linq ;
using System ;

using System.Net ;
using System.Xml ;
using System.IO ;
using System.Net.Sockets ;
using System.Text ;

namespace Snowglobe
	{
	[Status.Startup]
	public sealed class REST
		{
		delegate void                                      TaskDelegate( Task t ) ;
		static Thread                                      serverThread = new Thread( new ThreadStart( serverProcess ) ) ;
		static Thread                                      clientThread = new Thread( new ThreadStart( clientProcess ) ) ;
		static EventWaitHandle                             activity     = new EventWaitHandle( false, EventResetMode.AutoReset ) ;
		static Queue<Task>                                 tasks        = new Queue<Task>() ;
		static List<Task>                                  delayed      = new List<Task>() ;
		static bool                                        serverOnline = false ;

		static public bool ServerOnline
			{
			get { return serverOnline ; }
			}

		public class Task
			{
			int                    processed ;
			System.Timers.Timer    timer ;
			
			public int Processed
				{
				get { return processed ; }
				}
				
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
				REST.Queue( this ) ;
				lock( delayed )
					if( delayed.Contains( this ) )
						delayed.Remove( this ) ;
				}
				
			virtual protected void Process() { throw new NotImplementedException() ; }
			
			static internal void Process( Task t )
				{
				if( t.Delayed )
					{
					//Debug.WriteLine( "REST Client Delayed: {0}: {1}", t.processed, t ) ;
					lock( delayed )
						if( ! delayed.Contains( t ) )
							delayed.Add( t ) ;
					return ;
					}
				//Debug.WriteLine( "REST Client: {0}: {1}", t.processed, t ) ;
				t.Process() ;
				t.processed++ ;
				}
				
			override public string ToString()
				{
				return GetType().ToString() ;
				}
				
			virtual protected Task Combine( Task b )
				{
				return null ;
				}
				
			static internal Task Combine( Task a, Task b )
				{
				return a.Combine( b ) ;
				}
			}

		public abstract class Query : Task
			{
			abstract protected string        Resource   { get; }
			abstract protected MemoryStream  Request    { get; }
			abstract protected string        Method     { get; }

			abstract protected void Process( MemoryStream ms ) ;
			
			virtual protected void StatusNotFound()
				{
				if( Processed > 4 )
					throw new StatusException( this.ToString() ) ;
				REST.QueueDelayed( this ) ;
				}

			virtual protected void StatusMethodNotAllowed()
				{
				throw new StatusException( this.ToString() ) ;
				}

			virtual protected void StatusAccepted()
				{
				if( Processed > 100 )
					throw new StatusException( this.ToString() ) ;
				REST.QueueDelayed( this ) ;
				}

			virtual protected void StatusServiceUnavailable()
				{
				throw new StatusException( this.ToString() ) ;
				}
				
			virtual protected bool ProcessStatus( HttpStatusCode status )
				{
				if( status == HttpStatusCode.OK )
					return true ;
				if( status == HttpStatusCode.NotFound )
					StatusNotFound() ;
				else
				if( status == HttpStatusCode.MethodNotAllowed )
					StatusMethodNotAllowed() ;
				else
				if( status == HttpStatusCode.Accepted )
					StatusAccepted() ;
				else
				if( status == HttpStatusCode.ServiceUnavailable )
					StatusServiceUnavailable() ;
				else
					Console.WriteLine( "REST Client: {0} {1} -- Unhandled Http Status Code: {2}", Method, Resource, status.ToString() ) ;
				return false ;
				}

			override protected void Process()
				{
				Hypertext ht = new Hypertext( Resource ) ;
				MemoryStream ms = ht.Process( Method, Request ) ;
				if( ! ProcessStatus( ht.Status ) )
					return ;
				ms.Position = 0 ;
				Process( ms ) ;
				} 
			override public string ToString()
				{
				return GetType().ToString() + ": " + Method + " " + Resource ;
				}
			}
		
		sealed class PostGetsByUUID :  Query
			{
			override protected string        Resource   { get { return resource + "/s" ; } }
			override protected string        Method     { get { return "POST" ; } }

			Dictionary<UUID,GetByUUID>       gets       = new Dictionary<UUID,GetByUUID>() ;
			string                           resource ;
			Type                             type ;

			override protected MemoryStream  Request
				{
				get
					{
					Scalar.Array a = new Scalar.Array() ;
					foreach( UUID id in gets.Keys )
						a.Append( id ) ;
					MemoryStream ms = new MemoryStream() ;
					(new Scalar( a )).WriteTo( ms ) ; // TODO: DZ temporary conversion
					ms.Position = 0 ;
					return ms ;
					}
				}

			override protected void Process( MemoryStream ms )
				{
				foreach( Scalar sd in new Scalar( ms ) )
					{
					UUID id = (UUID) sd["ID"] ;
					GetByUUID a = gets[id] ;
					a.Response = sd ;
					gets.Remove( id ) ;
					REST.Queue( a ) ;
					}
				if( gets.Count != 0 )
					REST.QueueDelayed( this ) ;
				}

			override protected REST.Task Combine( REST.Task _b )
				{
				GetByUUID b = _b as GetByUUID ;
				if( type == _b.GetType() && resource == b.resource() && null == b.Response )
					{
					gets[b.ID] = b ;
					return this ;
					}
				return null ;
				}

			override public string ToString()
				{
				return GetType().ToString() + ": POST " + Resource ;
				}

			public PostGetsByUUID( string resource, GetByUUID a, GetByUUID b )
				{
				this.resource = resource ;
				type = a.GetType() ;
				gets[a.ID] = a ;
				gets[b.ID] = b ;
				}
			}

		public abstract class GetByUUID : Query
			{
			Scalar                           response ;
			abstract protected Scalar        SD         { set; }
			override protected MemoryStream  Request    { get { return null ; } }
			override protected string        Method     { get { return "GET" ; } }
			abstract public UUID             ID         { get; }
			public Scalar                    Response   { set { response = value ; } get { return response ; } }
			
			internal string                  resource() { return Resource ; }
			
			override protected void Process( MemoryStream ms ) {}

			override protected void Process()
				{
				Scalar response = this.response ;
				this.response = null ;
				if( null == response )
					{
					Hypertext ht = new Hypertext( Resource + "/" + ID.ToString() ) ;
					MemoryStream ms = ht.Process( Method, Request ) ;
					if( ! ProcessStatus( ht.Status ) )
						return ;
					ms.Position = 0 ;
					response = new Scalar( ms ) ;
					}
				else
					{
					if( response.ContainsKey( "Status" ) )
						if( ! ProcessStatus( (HttpStatusCode) (int) response["Status"] ) )
							return ;
					}
				SD = response ;
				}

			override public string ToString()
				{
				return GetType().ToString() + ": GET " + Resource + "/" + ID.ToString() ;
				}

			override protected REST.Task Combine( REST.Task _b )
				{
				GetByUUID b = _b as GetByUUID ;
				if( GetType() == _b.GetType() && Resource == b.Resource && response == null && b.response == null )
					return new PostGetsByUUID( Resource, this, b ) ;
				return null ;
				}
			}
		
		public abstract class Get : Query
			{
			abstract protected string        XML        { set; }
			override protected MemoryStream  Request    { get { return null ; } }
			override protected string        Method     { get { return "GET" ; } }
			
			override protected void Process( MemoryStream memory )
				{
				string xml = null ;
				try
					{
					xml = Encoding.UTF8.GetString( memory.GetBuffer() , 0, (int) memory.Length) ;
					XML = xml ;
					}
				catch( XmlException e )
					{
					//Debug.WriteLine("REST Exception: Resource: {0}", Resource ) ;
					//Debug.WriteLine("XML: {0}", xml ) ;
					throw e ;
					}
				} 
			}


		public abstract class Post : Query
			{
			abstract protected string        XML        { get; set; }
			override protected string        Method     { get { return "POST" ; } }

			override protected MemoryStream  Request
				{
				get
					{
					MemoryStream ms = new MemoryStream() ;
					(new MemoryStream( Encoding.UTF8.GetBytes( XML ) )).WriteTo( ms ) ; // TODO: DZ temporary conversion
					ms.Position = 0 ;
					return ms ;
					}
				}

			override protected void Process( MemoryStream memory )
				{
				string xml = null ;
				try
					{
					xml = Encoding.UTF8.GetString( memory.GetBuffer() , 0, (int) memory.Length) ;
					XML = xml ;
					}
				catch( XmlException e )
					{
					//Debug.WriteLine("REST Exception: Resource: {0}", Resource ) ;
					//Debug.WriteLine("XML: {0}", xml ) ;
					throw e ;
					}
				} 
			}

		public abstract class Delete : Task
			{
			abstract protected string        Resource   { get; }
			abstract protected string        XML        { get; set; }

			override protected void Process()
				{
				string xml = null ;
				try
					{
					Hypertext ht     = new Hypertext( Resource ) ;
					xml              = ht.Delete( XML ) ;
					XML              = xml ;
					}
				catch( XmlException e )
					{
					//Debug.WriteLine("REST Exception: Resource: {0}", Resource ) ;
					//Debug.WriteLine("XML: {0}", xml ) ;
					throw e ;
					}
				} 
			public override string ToString()
				{
				return GetType().ToString() + ": DELETE " + Resource ;
				}
			}

		
		static public void Queue( Task t )
			{
			lock( tasks )
				tasks.Enqueue( t ) ;
			activity.Set() ;
			}

		static public void QueueDelayed( Task t )
			{
			t.Delay( 10 ) ;
			Queue( t ) ;
			}

		static void clientProcess()
			{
			int n ;
			#if !DEBUG
			try
				{
			#endif
				while( true )
					{
					Task t = null ;
					Task p = null ;
					try
						{
						do
							{
							lock( tasks )
								{
								Icesphere.Application.Statistics.RestQueued = tasks.Count ;
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
						Icesphere.Application.Statistics.RestQueued = tasks.Count ;
						activity.WaitOne() ;
						}
					catch( StatusException e )
						{
						Console.WriteLine( "STATUS: REST thread: {0}", e ) ;
						}
					}
			#if !DEBUG
				}
			catch( System.Exception )
				{
				// TODO: ...
				throw ;
				}
			#endif
			}

		static void serverProcess()
			{
			string prefix = "http://" + Interface.Host + ":" + Interface.Port.ToString() + "/" ;
			Icesphere.Application.Statistics.RestPrefix = prefix ;
			//Debug.WriteLine("REST Prefix: {0}", prefix ) ;
			HttpListener listener = new HttpListener();
			listener.Prefixes.Add( prefix ) ;
			try
				{
				listener.Start();
				serverOnline = true ;
				Icesphere.Application.Statistics.RestServer = "Online" ;
				}
			catch( Exception )
				{
				//Debug.WriteLine( "STATUS: REST Listener: {0}", e.Message ) ;
				Icesphere.Application.Statistics.RestServer = "Offline" ;
				}
			while( serverOnline )
				{
				Resource.Context context = new Resource.Context( listener.GetContext() ) ;
				context.Process() ;
				}
			}

		public class Resource
			{
			static Dictionary< string, Resource >              resources    = new Dictionary< string, Resource >() ;
			public class Context
				{
				Resource                  resource ;
				HttpListenerRequest       request ;
				HttpListenerResponse      response ;
				public HttpStatusCode     Status
					{
					get { return (HttpStatusCode) response.StatusCode ; }
					set { response.StatusCode = (int) value ; }
					}
				public Scalar             XML
					{
					get { return new Scalar( request.InputStream ) ; }
					set { value.WriteTo( response.OutputStream ) ; }
					}
				public void Process()
					{
					foreach( string r in resources.Keys )
						if( r == request.Url.AbsolutePath )
							{
							resource = resources[ r ] ;
							break ;
							}
					//Debug.WriteLine( "REST/HTTP Server: Resource {0} {1} {2}", request.HttpMethod, request.Url.AbsolutePath, resource == null ? "-not found-" : "" ) ;
					if( resource == null )
						return ;
					if( request.HttpMethod == "GET" )
						resource.Get( this ) ;
					else
					if( request.HttpMethod == "POST" )
						resource.Post( this ) ;
					else
					if( request.HttpMethod == "PUT" )
						resource.Put( this ) ;
					else
					if( request.HttpMethod == "DELETE" )
						resource.Delete( this ) ;
					response.OutputStream.Close() ;
					}
				public Context( HttpListenerContext context )
					{
					request  = context.Request ;
					response = context.Response ;
					}
				}
			public virtual void Get( Context context )    { context.Status = HttpStatusCode.MethodNotAllowed ; }
			public virtual void Post( Context context )   { context.Status = HttpStatusCode.MethodNotAllowed ; }
			public virtual void Put( Context context )    { context.Status = HttpStatusCode.MethodNotAllowed ; }
			public virtual void Delete( Context context ) { context.Status = HttpStatusCode.MethodNotAllowed ; }
			protected Resource( string path )
				{
				resources[ path ] = this ;
				}
			}
			
		public class StatusException : System.Exception
			{
			public StatusException( string text ) : base( text ) {}
			}

		private REST()
			{
			}
		
		static REST()
			{
			clientThread.Start() ;
			serverThread.Start() ;
			}
		}
	}
	
