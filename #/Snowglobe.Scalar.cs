/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Collections ;
using System.Text ;
using System.Xml ;
using System.Net ;
using System.IO ;
using System ;

namespace Snowglobe
	{
	public class Scalar : IEnumerable<object>
		{
		object o ;

		public Type Type
			{
			get { return ( o == null ) ? null : o.GetType() ; }
			}

		public string XML
			{
			get { return toXML() ; }
			set { fromXML( new StringReader( value ) ) ; }
			}
			
		public class Binary
			{
			public const int      BYTES   = 8 ;
			public const int      BASE    = 64 ;
			byte[]                binary ;
			public static string ToBase64String( ulong l )
				{
				Binary b = (Binary) l ;
				return Convert.ToBase64String( b.binary ) ;
				}
			public static implicit operator Binary( ulong l )
				{
				return new Binary( BitConverter.GetBytes( IPAddress.HostToNetworkOrder( (long) l ) ) ) ;
				}
			public static implicit operator Binary( uint l )
				{
				return new Binary( BitConverter.GetBytes( IPAddress.HostToNetworkOrder( (int) l ) ) ) ;
				}
			public static implicit operator ulong( Binary b )
				{
				return (ulong) IPAddress.NetworkToHostOrder( BitConverter.ToInt64( b.binary, 0 ) ) ;
				}
			public static implicit operator uint( Binary b )
				{
				return (uint) IPAddress.NetworkToHostOrder( BitConverter.ToInt32( b.binary, 0 ) ) ;
				}
			public override string ToString()
				{
				return Convert.ToBase64String( binary ) ;
				}
			public Binary( byte[] binary )
				{
				this.binary = binary ;
				System.Array.Resize( ref this.binary, BYTES ) ;
				}
			public Binary( string binary )
				{
				this.binary = Convert.FromBase64String( binary ) ;
				System.Array.Resize( ref this.binary, BYTES ) ;
				}
			public Binary()
				{
				binary = new byte[8] ;
				}
			}

		public class Map : Dictionary< string, Scalar >
			{
			public void Dump()
				{
				Console.WriteLine( "MAP:+++" ) ;
				foreach( KeyValuePair<string,Scalar> kv in this )
					{
					Console.WriteLine( "KEY: {0}", kv.Key ) ;
					kv.Value.Dump() ;
					}
				Console.WriteLine( "MAP:---" ) ;
				}
			public Map()
				{
				}
			}
		
		public class Array : IEnumerable<object>
			{
			object[] array ;

			public void Dump()
				{
				Console.WriteLine( "ARRAY:+++" ) ;
				foreach( Scalar s in array )
					s.Dump() ;
				Console.WriteLine( "ARRAY:---" ) ;
				}
			
			public class Enumerator : IEnumerator<object>
				{
				object[] array ;
				int      index = -1;
				public object Current
					{
					get { return array[index] ; }
					}
				public bool MoveNext()
					{
					return ++index < array.Length ;
					}
				public void Reset()
					{
					index = -1 ;
					}
				void IDisposable.Dispose()
					{
					}
				public Enumerator( object[] a )
					{
					array = a ;
					}
				}
			public IEnumerator<object> GetEnumerator()
				{
				return new Enumerator( array ) ;
				}
			IEnumerator IEnumerable.GetEnumerator()
				{
				return new Enumerator( array ) ;
				}
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
				{
				return new Enumerator( array ) ;
				}
			void dim( int i )
				{
				if( array.Length < i )
					System.Array.Resize( ref array, i ) ;
				}
			public void Append( object o )
				{
				this[ array.Length ] = o ;
				}
			public object this[ int i ]
				{
				get { return array[i] ; }
				set	{ dim(i+1) ; array[i] = value ; }
				}
			public Array()
				{
				array = new object[0] ;
				}
			}

		class Exception : System.Exception
			{
			public Exception( string m )
				: base( m ) {}
			}

		string toXML()
			{
			XmlWriterSettings      s    = new XmlWriterSettings() ;
			s.OmitXmlDeclaration        = true ;
			StringBuilder          text = new StringBuilder() ;
			XmlWriter              w    = XmlWriter.Create( text, s ) ;
			WriteElementContentAsLLSD( w, o ) ;
			w.Flush() ;
			return text.ToString() ;
			}

		public string IndentedXML()
			{
			XmlWriterSettings     s   = new XmlWriterSettings() ;
			s.OmitXmlDeclaration      = true ;
			s.Indent                  = true ;
			StringBuilder        text = new StringBuilder() ;
			XmlWriter            w    = XmlWriter.Create( text, s ) ;
			WriteElementContentAsLLSD( w, o ) ;
			w.Flush() ;
			return text.ToString() ;
			}
			
		public void WriteTo( Stream ms )
			{
			XmlWriterSettings s = new XmlWriterSettings() ;
			s.Encoding = Encoding.UTF8 ;
			s.OmitXmlDeclaration = true ;
			XmlWriter w = XmlWriter.Create( ms, s ) ; //, Encoding.UTF8 ) ;
			WriteElementContentAsLLSD( w, o ) ;
			w.Flush() ;
			}

		void WriteElementContentAsLLSD( XmlWriter xml, object o )
			{
			xml.WriteStartElement("llsd");
			WriteElementContentAsValue( xml, o ) ;
			xml.WriteEndElement() ;
			}

		void WriteElementContentAsValue( XmlWriter xml, object o )
			{
			if( o == null )
				xml.WriteElementString( "undef", "", "" ) ;
			else
			if( o is Scalar )
				WriteElementContentAsValue( xml, (o as Scalar).o ) ;
			else
			if( o is Map )
				WriteElementContentAsMap( xml, (o as Map) ) ;
			else
			if( o is Array )
				WriteElementContentAsArray( xml, (o as Array) ) ;
			else
			if( o is Binary )
				WriteElementContentAsBinary( xml, o as Binary ) ;
			else
			if( o is ulong )
				WriteElementContentAsBinary( xml, o as Binary ) ;
			else
			if( o is string )
				WriteElementContentAsString( xml, (string) o ) ;
			else
			if( o is int )
				WriteElementContentAsInteger( xml, (int) o ) ;
			else
			if( o is double )
				WriteElementContentAsReal( xml, (double) o ) ;
			else
			if( o is bool )
				WriteElementContentAsBoolean( xml, (bool) o ) ;
			else
			if( o is UUID )
				WriteElementContentAsUUID( xml, o as UUID ) ;
			else
				throw new Exception( "Unhandled: " + o.GetType().ToString() ) ;
			}

		void WriteElementContentAsMap( XmlWriter xml, Map o )
			{
			xml.WriteStartElement("map") ;
			foreach( KeyValuePair<string,Scalar> kv in o )
				{
				xml.WriteElementString( "key", kv.Key ) ;
				WriteElementContentAsValue( xml, kv.Value ) ;
				}
			xml.WriteEndElement() ;
			}

		void WriteElementContentAsArray( XmlWriter xml, Array o )
			{
			xml.WriteStartElement("array") ;
			foreach( object v in o )
				WriteElementContentAsValue( xml, v ) ;
			xml.WriteEndElement() ;
			}

		void WriteElementContentAsBinary( XmlWriter xml, Binary o )
			{
			xml.WriteElementString( "binary", o.ToString() ) ;
			} 

		void WriteElementContentAsString( XmlWriter xml, string o )
			{
			xml.WriteElementString( "string", o ) ;
			} 

		void WriteElementContentAsInteger( XmlWriter xml, int o )
			{
			xml.WriteElementString( "integer", o.ToString() ) ;
			} 

		void WriteElementContentAsReal( XmlWriter xml, double o )
			{
			xml.WriteElementString( "real", o.ToString() ) ;
			} 

		void WriteElementContentAsBoolean( XmlWriter xml, bool o )
			{
			xml.WriteElementString( "boolean", ( o ? "1" : "0" ) ) ;
			} 

		void WriteElementContentAsUUID( XmlWriter xml, UUID o )
			{
			if( o == UUID.Zero )
				xml.WriteElementString( "uuid", "" ) ;
			else
				xml.WriteElementString( "uuid", o.ToString() ) ;
			} 

		void fromXML( TextReader s )
			{
			try
				{
				ReadElementContentAsLLSD( new XmlTextReader( s ) ) ;
				}
			catch( XmlException e )
				{
				//Debug.WriteLine( "LLSD+XML: Exception: {0}", s ) ;
				//Debug.WriteLine( "LLSD+XML: Exception: {0}", xml.Name, xml.NodeType, e.Message ) ;
				throw e ;
				}
			}
			
		void ReadElementContentAsLLSD( XmlReader xml )
			{
			xml.MoveToContent() ;
			xml.ReadStartElement( "llsd" ) ;
			o = ReadElementContentAsValue( xml ) ;
			xml.ReadEndElement() ;
			}

		KeyValuePair<string, Scalar> ReadElementContentAsMapKeyValuePair( XmlReader xml )
			{
			return new KeyValuePair<string, Scalar>(
				ReadElementContentAsMapKey( xml ),
				ReadElementContentAsMapValue( xml )
				);
			}

		string ReadElementContentAsMapKey( XmlReader xml )
			{
			string s = xml.ReadElementString( "key" ) ;
			if( s == "" )
				throw new XmlException( "Element <key> cannot be an empty string." ) ;
			return s ;
			}

		Scalar ReadElementContentAsMapValue( XmlReader xml )
			{
			return new Scalar( ReadElementContentAsValue( xml ) ) ;
			}

		Map ReadElementContentAsMap( XmlReader xml )
			{
			Map map = new Map() ;
			if( ! xml.IsStartElement( "map" ) )
				throw new XmlException( "Not positioned on 'map' element" ) ;
			if( xml.IsEmptyElement )
				{
				xml.Skip() ;
				return map ;
				}
			xml.ReadStartElement( "map" ) ;
			while( xml.NodeType == XmlNodeType.Element && xml.Name == "key" )
				{
				KeyValuePair<string, Scalar> kv = ReadElementContentAsMapKeyValuePair( xml ) ;
				map[kv.Key] = kv.Value ;
				}
			xml.ReadEndElement() ;
			return map ;
			}		

		Scalar ReadElementContentAsArrayValue( XmlReader xml )
			{
			return new Scalar( ReadElementContentAsValue( xml ) ) ;
			}

		Array ReadElementContentAsArray( XmlReader xml )
			{
			int index = -1 ;
			Array array = new Array() ;
			if( ! xml.IsStartElement( "array" ) )
				throw new XmlException( "Not positioned on 'array' element" ) ;
			if( xml.IsEmptyElement )
				{
				xml.Skip() ;
				return array ;
				}
			xml.ReadStartElement( "array" ) ;
			while( xml.NodeType == XmlNodeType.Element )
				{
				array[++index] = ReadElementContentAsArrayValue( xml ) ;
				}
			xml.ReadEndElement() ;
			return array ;
			}		

		object ReadElementContentAsUndefined( XmlReader xml )
			{
			xml.Skip() ;
			return null ; 
			}

		Binary ReadElementContentAsBinary( XmlReader xml )
			{
			return new Binary( xml.ReadElementContentAsString() ) ;
			}

		UUID ReadElementContentAsUUID( XmlReader xml )
			{
			string s = xml.ReadElementContentAsString() ;
			if( s == "" )
				return UUID.Zero ;
			return new UUID( s ) ;
			}

		object ReadElementContentAsValue( XmlReader xml )
			{
			xml.MoveToContent() ;
			if( xml.NodeType != XmlNodeType.Element )
				throw new XmlException( "Expected Element node type." ) ;
			if( xml.Name == "map" )
				return ReadElementContentAsMap( xml ) ;
			else
			if( xml.Name == "array" ) 
				return ReadElementContentAsArray( xml ) ;
			else
			if( xml.Name == "undef" )
				return ReadElementContentAsUndefined( xml ) ;
			else
			if( xml.Name == "uuid" )
				return ReadElementContentAsUUID( xml ) ;
			else
			if( xml.Name == "binary" )
				return ReadElementContentAsBinary( xml ) ;
			else
			if( xml.Name == "string" )
				return xml.ReadElementContentAsString() ;
			else
			if( xml.Name == "boolean" )
				return xml.ReadElementContentAsBoolean() ;
			else
			if( xml.Name == "integer" )
				return xml.ReadElementContentAsInt() ;
			else
			if( xml.Name == "real" )
				return xml.ReadElementContentAsDouble() ;
			throw new XmlException( "Unhandled element: '" + xml.Name + "'" ) ;
			}

		public Scalar this[ string name ]
			{
			get
				{
				try {
					return ((Map) o)[name] ;
					}
				catch( System.Exception )
					{
					//Debug.WriteLine( "SCALAR EXCEPTION: key=" + name ) ;
					throw ;
					}
				}
			set { ((Map) o)[name] = value ; }
			}

		public Scalar this[ int i ]
			{
			get { return (Scalar)( ((Array) o)[i] ); }
			set { ((Array) o)[i] = value ; }
			}

		IEnumerator IEnumerable.GetEnumerator()
			{
			if( o is Array )
				return (o as Array).GetEnumerator() ;
			throw new Exception( "Scalar value not enumerable: " + o.GetType() ) ;
			}

		IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
			if( o is Array )
				return (o as Array).GetEnumerator()  ;
			throw new Exception( "Scalar value not enumerable: " + o.GetType() ) ;
			}

		public static implicit operator Scalar( UUID id )
			{
			return new Scalar( id ) ;
			}
		public static implicit operator UUID( Scalar s )
			{
			return (UUID) s.o ;
			}

		public static implicit operator Scalar( bool m )
			{
			return new Scalar( m ) ;
			}
		public static implicit operator bool( Scalar s )
			{
			return (bool) s.o ;
			}

		public static implicit operator Scalar( string m )
			{
			return new Scalar( m ) ;
			}
		public static implicit operator string( Scalar s )
			{
			return (string) s.o ;
			}

		public static implicit operator Scalar( int i )
			{
			return new Scalar( i ) ;
			}
		public static implicit operator int( Scalar s )
			{
			return (int) s.o ;
			}

		public static implicit operator Scalar( ulong l )
			{
			return new Scalar( (Binary) l ) ;
			}
		public static implicit operator ulong( Scalar s )
			{
			return (ulong) (Binary) s.o ;
			}

		public static implicit operator Scalar( uint l )
			{
			return new Scalar( (Binary) l ) ;
			}
		public static implicit operator uint( Scalar s )
			{
			return (uint) (Binary) s.o ;
			}

		public static implicit operator Scalar( double d )
			{
			return new Scalar( d ) ;
			}
		public static implicit operator double( Scalar s )
			{
			return (double) s.o ;
			}

		public static implicit operator Scalar( float d )
			{
			return new Scalar( (double) d ) ;
			}
		public static implicit operator float( Scalar s )
			{
			return (float) (double) s.o ;
			}

		public static implicit operator Scalar( Map m )
			{
			return new Scalar( m ) ;
			}
		public static implicit operator Map( Scalar s )
			{
			return (Map) s.o ;
			}

		public static implicit operator Scalar( Array a )
			{
			return new Scalar( a ) ;
			}
		public static implicit operator Array( Scalar s )
			{
			return (Array) s.o ;
			}

		public static implicit operator Scalar( Snowglobe.Color4 cRGBA )
			{
			Array a = new Array() ;
			a[0]    = cRGBA.Red ;
			a[1]    = cRGBA.Green ;
			a[2]    = cRGBA.Blue ;
			a[3]    = cRGBA.Alpha ;
			return new Scalar( a ) ;
			}
		public static implicit operator Snowglobe.Color4( Scalar s )
			{
			Snowglobe.Color4 cRGBA ;
			cRGBA.Red    = s[0] ;
			cRGBA.Green  = s[1] ;
			cRGBA.Blue   = s[2] ;
			cRGBA.Alpha  = s[3] ;
			return cRGBA ;
			}
			
		public void Dump()
			{
			if( o is Map )
				(o as Map).Dump() ;
			else
			if( o is Array )
				(o as Array).Dump() ;
			else
				Console.WriteLine( "DUMP: {0}: {1}", o.GetType(), o.ToString() ) ;
			}
		
		public bool ContainsKey( string key )
			{
			return ( o is Map ) && (o as Map).ContainsKey( key ) ; 
			}
		
		internal Scalar( object o )
			{
			this.o = o ;
			}

		public Scalar( Stream ms )
			{
			fromXML( new StreamReader( ms ) ) ;
			}

		public Scalar( MemoryStream ms )
			{
			ms.Position = 0 ;
			fromXML( new StreamReader( ms ) ) ;
			}

		public Scalar()
			{
			}
		}
	}