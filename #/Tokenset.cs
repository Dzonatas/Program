public static partial class Tokenset
	{
	static int index = 0 ;
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
	static System.Xml.XmlTextReader   xml ;
	public static void Assimulation( string input )
		{
		//In re: "assimilated" -> icyspherical.blogspot.com/2010/07/why-resthttp-based-client-side.html
		xml = new System.Xml.XmlTextReader( new System.IO.StringReader( input ) ) ;
		while( xml.Read() && ! ( xml.NodeType == System.Xml.XmlNodeType.Element && xml.Name == "xml" ) ) ;
		#if DEBUG
		Lift() ;
		#endif
		}
	public static Token input()
		{
		if( xml.Read() )
			{
			switch( xml.NodeType )
				{
				case System.Xml.XmlNodeType.Element:
					{
					string [] s = xml.Name.Split("_-".ToCharArray()) ;
					xml.Read() ;
					string text = xml.Value ;
					return new Token( (char)int.Parse( s[1] ), text, true, int.Parse( s[2] )) ; //_point3D:___(s[2,text]),_xor_URN:s[0]:_
					}
				case System.Xml.XmlNodeType.EntityReference:
					{
					string [] s = xml.Name.Split("_".ToCharArray()) ;
					xml.Read() ;
					string text = xml.Value ;
					return new Token( (char)int.Parse( s[2] ), text, false, int.Parse( s[1] ) ) ; //s[1]_estate
					}
				}
			}
		return new Token( '\0', "$end" ) ;
		}
	}
