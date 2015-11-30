public static partial class Tokenset
	{
	static int index = 0 ;
	public static readonly Token Empty = new Tokenset.Token( '\u0000', "", false, 0 ) ;
	public static Token Input
		{
		get {
			#if !EMBED
			//if( tokenset == null )
				return input() ;
			#else
			Token t = tokenset[index] ;
			if( t._ != "$end")
				index++ ;
			return t ;
			#endif
		    }
		}
	#if EMBED
	public static string[] Argv
		{
		get {
			string[] p = new string[tokenset.Length] ;
			for( int i = 0 ; i < tokenset.Length ; i++ )
				p[i] = tokenset[i]._ ;
			return p ;
		    }
		}
	public static string[] Points
		{
		get {
			string[] p = new string[tokenset.Length] ;
			for( int i = 0 ; i < tokenset.Length ; i++ )
				p[i] = tokenset[i].point.ToString() ;
			return p ;
		    }
		}
	#endif
	public struct Token
		{
		public char    c ;
		public string  _ ;
		public bool    terminal ;
		public int     point ;
		internal Token( char _char, string _string )
			{
			c = _char ;
			_ = _string ;
			terminal = true ;
			point = 0 ;
			}
		internal Token( char _char, string _string, bool _terminal, int _point )
			{
			c = _char ;
			_ = _string ;
			terminal = _terminal ;
			point = _point ;
			}
		#if !EMBED
		static public explicit operator string( Token t )
			{
			return string.Format
				(
				"( '\\u{0:X4}', \"{1}\", {2}, {3} )",
				System.Convert.ToInt16(t.c),
				t._,
				t.terminal.ToString().ToLower(),
				A335.xml_translate[t.c]
				) ;
			}
		#endif
		public override string ToString()
			{
			return string.Format
				(
				"( '\\u{0:X4}', \"{1}\", {2}, {3} )",
				System.Convert.ToInt16(c),
				_,
				terminal.ToString().ToLower(),
				point
				) ;
			}
		}
	#if !EMBED
	static System.Xml.XmlTextReader   xml ;
	public static void Assimulation( string input )
		{
		//In re: "assimilated" -> icyspherical.blogspot.com/2010/07/why-resthttp-based-client-side.html
		xml = new System.Xml.XmlTextReader( new System.IO.StringReader( input ) ) ;
		while( xml.Read() && ! ( xml.NodeType == System.Xml.XmlNodeType.Element && xml.Name == "xml" ) ) ;
		if( Cluster.Parameter.Value("build") == "infrastructure" )
			Lift() ;
		}
	static bool xml_read = false ;
	public static Token input()
		{
		if( xml_read || xml.Read() )
			{
			xml_read = false ;
			switch( xml.NodeType )
				{
				case System.Xml.XmlNodeType.Element:
					{
					string [] s = xml.Name.Split("_-".ToCharArray()) ;
					xml.Read() ;
					string text = xml.Value ;
					return new Token( (char)int.Parse( s[1] ), text, true, 0 /*int.Parse( s[2] )*/) ; //_point3D:___(s[2,text]),_xor_URN:s[0]:_
					}
				case System.Xml.XmlNodeType.EntityReference:
					{
					string [] s = xml.Name.Split("_".ToCharArray()) ;
					xml.Read() ;
					string text = string.Empty ;
					if( xml.NodeType == System.Xml.XmlNodeType.Text
					  || xml.NodeType == System.Xml.XmlNodeType.Whitespace )
						text = xml.Value ;
					else
						xml_read = true ;
					return new Token( (char)int.Parse( s[1] ), text, false, 0 /*int.Parse( s[^1] )*/ ) ; //s[^1]_estate
					}
				}
			}
		return new Token( '\0', "$end" ) ;
		}
	#endif
	}
