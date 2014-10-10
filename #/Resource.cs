using System.Collections.Generic ;
using System.Collections ;
using System.Reflection ;
using System.Threading ;
using System.Timers ;
using System.Linq ;
using System ;

using System.Net ;
//using System.Xml ;
using System.IO ;
using System.Net.Sockets ;
using System.Text ;


//using System ;

namespace Cluster
	{
	[Program.Singleton]
	public class Resource
		{
		static string                                      prefix       = "http://127.0.0.1:80/" ;
		static HttpListener                                listener     = new HttpListener() ;
		static Thread                                      thread       = new Thread( new ThreadStart( process ) ) ;
		static Dictionary< string, Resource >              resources    = new Dictionary< string, Resource >() ;
		static bool                                        loop         = false ;
		static public Action<bool>                         Online       = (online) => loop = online ;

		private Resource()
			{
			Program.Initialize   += initialize ;
			Program.Run          += run ;
			}
		
		~Resource()
			{
			Online( false ) ;
			Program.Initialize   -= initialize ;
			Program.Run          -= run ;
			}

		void initialize() 
			{
			listener.Prefixes.Add( prefix ) ;
			}
		
		void run()
			{
			thread.Start() ;
			}
		
		static void process()
			{
			try
				{
				listener.Start();
				Online( true ) ;
				}
			catch( Exception )
				{
				//Debug.WriteLine( "STATUS: HTTP Listener: {0}", e.Message ) ;
				}
			while( loop )
				{
				Resource.Context context = new Resource.Context( listener.GetContext() ) ;
				context.Process() ;
				}
			}

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
			public Stream Input
				{
				get { return request.InputStream ; }
				}
			public Stream Output
				{
				get { return response.OutputStream ; }
				}
			public void Process()
				{
				if( ! resources.TryGetValue( request.Url.AbsolutePath, out resource ) )
					return ;
				switch( request.HttpMethod )
					{
					case "GET"    : resource.Get( this ) ;    break ;
					case "POST"   : resource.Post( this ) ;   break ;
					case "PUT"    : resource.Put( this ) ;    break ;
					case "DELETE" : resource.Delete( this ) ; break ;
					}
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
	}