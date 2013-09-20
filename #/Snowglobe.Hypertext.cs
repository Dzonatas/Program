/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Diagnostics ;
using System.Collections ;
using System.Threading ;
using System ;

using System.Net ;
using System.IO ;
using System.Net.Sockets ;
using System.Text ;

namespace Snowglobe
	{
	[Status.Startup]
	public sealed class Hypertext
		{
		static Uri                baseURI ;
		static Semaphore          throttle = new Semaphore( 2, 2 ) ;
		static CookieContainer    cookies  = new CookieContainer() ;
		MemoryStream              memory   = new MemoryStream() ;
		ManualResetEvent          done ;
		Uri                       uri ;
		Stream                    stream ;
		byte[]                    buffer ;
		byte[]                    transfer ;
		HttpStatusCode            status   = HttpStatusCode.NotImplemented ;
		bool                      success  = false ;
		
		public CookieContainer Cookies
			{
			get { return cookies ; }
			}
			
		public HttpStatusCode Status
			{
			get { return status ; }
			}

		public bool Success
			{
			get { return success ; }
			}

		public void Read()
			{
			stream.BeginRead( buffer, 0, buffer.Length, new AsyncCallback( ReadCallBack ), stream ) ;
			}

		void ReadCallBack( IAsyncResult ar )
			{
			int  n = stream.EndRead( ar ) ;
			if( n == 0 )
				{
				done.Set() ;
				return ;
				}
			memory.Write( buffer, 0, n ) ;
			Read() ;
			}

		HttpWebRequest processRequest( string method )
			{
			const int  second       = 1000 ;
			HttpWebRequest          request ;
			request                 = (HttpWebRequest) WebRequest.Create( uri ) ;
			request.Method          = method ;
			request.KeepAlive       = false ;
			request.Timeout         = 10 * second ;
			request.CookieContainer = cookies ;
			
			try
				{
				if( method == "POST" || method == "PUT" )
					{
					request.ContentType    = "application/llsd+xml" ;
					request.ContentLength  = transfer.Length ;
	
					Stream s = request.GetRequestStream() ;
					s.Write( transfer, 0, transfer.Length ) ;
					s.Close();
					}
				}
			catch( WebException e )
				{
				if( e.Status == WebExceptionStatus.Timeout )
					{
					status = HttpStatusCode.InternalServerError ;
					request.Abort() ;
					return null ;
					}
				if( e.Status == WebExceptionStatus.ConnectFailure )
					{
					status = HttpStatusCode.ServiceUnavailable ;
					request.Abort() ;
					return null ;
					}
				status = HttpStatusCode.NotImplemented ;
				Console.WriteLine( "HTTP Client Exception: {0} {1} {2} {3}", e.Status, request.Method, request.RequestUri, e ) ;
				request.Abort() ;
				return null ;
				}

			return request ;
			}

		void processResponse( HttpWebRequest request )
			{
			HttpWebResponse   response = null ;
			try
				{
				if( null == request )
					{
					return ;
					}
				response  = (HttpWebResponse) request.GetResponse() ;
				}
			catch( WebException e )
				{
				response = ( response != null ) ? response : ((HttpWebResponse)e.Response) ;
				if( response != null )
					{
					status = response.StatusCode ;
					response.Close() ;
					request.Abort() ;
					return ;
					}
				if( e.Status == WebExceptionStatus.Timeout )
					{
					status = HttpStatusCode.InternalServerError ;
					request.Abort() ;
					return ;
					}
				if( e.Status == WebExceptionStatus.ConnectFailure )
					{
					status = HttpStatusCode.ServiceUnavailable ;
					request.Abort() ;
					return ;
					}
				status = HttpStatusCode.NotImplemented ;
				//Debug.WriteLine( "HTTP Client Exception: {0} {1} {2} {3}", e.Status, request.Method, request.RequestUri, e ) ;
				request.Abort() ;
				return ;
				}
			catch( Exception e )
				{
				Console.WriteLine( "UNHANDLED EXCEPTION: HTTP: {0}", e ) ;
				request.Abort() ;
				if( response != null )
					response.Close() ;
				throw ;
				}
			stream    = response.GetResponseStream() ;
			Read() ;
			done.WaitOne() ;
			status    = response.StatusCode ;
			buffer    = null ;
			transfer  = null ;
			request.Abort() ;
			stream.Close() ;
			response.Close() ;
			success   = true ;
			}

		void processMethod( string method )
			{
			throttle.WaitOne() ;
			HttpWebRequest request = processRequest( method ) ;
			if( request != null )
				processResponse( request ) ;
			throttle.Release() ;
			}

		public MemoryStream Process( string method )
			{
			return Process( method, null ) ;
			}

		public MemoryStream Process( string method, MemoryStream data )
			{
			if( null != data )
				transfer = data.GetBuffer() ;
			processMethod( method ) ;
			memory.Position = 0 ;
			return memory ;
			}
		
		public string Get()
			{
			processMethod( "GET" ) ;
			if( success )
				return Encoding.UTF8.GetString( memory.GetBuffer() , 0, (int) memory.Length) ;
			else
				return null ;
			}

		public string Put( string data )
			{
			transfer = Encoding.UTF8.GetBytes( data ) ;
			processMethod( "PUT" ) ;
			if( success )
				return Encoding.UTF8.GetString( memory.GetBuffer() , 0, (int) memory.Length) ;
			else
				return null ;
			}
		
		public string Post( string data )
			{
			transfer = Encoding.UTF8.GetBytes( data ) ;
			processMethod( "POST" ) ;
			if( success )
				return Encoding.UTF8.GetString( memory.GetBuffer() , 0, (int) memory.Length) ;
			else
				return null ;
			}

		public string Delete( string data )
			{
			transfer = Encoding.UTF8.GetBytes( data ) ;
			processMethod( "DELETE" ) ;
			if( success )
				return Encoding.UTF8.GetString( memory.GetBuffer() , 0, (int) memory.Length) ;
			else
				return null ;
			}

		public Hypertext( string path )
			{
			this.uri  = new Uri( baseURI, path ) ;
			buffer    = new byte[8192] ;
			done      = new ManualResetEvent( false ) ;
			}

		public Hypertext( Uri uri )
			{
			this.uri  = uri ;
			buffer    = new byte[8192] ;
			done      = new ManualResetEvent( false ) ;
			}

		private Hypertext()
			{
			}
		
		static Hypertext()
			{
			Uri uri = new Uri( Icesphere.Parameter.Value( "uri" ) ) ;
			if( uri.Scheme != Uri.UriSchemeHttp )
				throw new Exception( "Parameter 'URI' is not a valid HTTP address. Format should be: http://host.tld:port" ) ;
			baseURI = uri ;
			}
		}
	}

	