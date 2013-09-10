public partial class _
{
#if BISECT
public static void Main( string[] args )
	{
	new A335.Clogic() ;
#if RELEASE
	try {
		new A335.L() ;
		}
	catch
		{
		throw new exception() ;
		}
#endif
	}

#endif
static public Token string_t     = new Token( '$' , "string" ) ;
static public Token underline_t  = new Token( '_' , "underline" ) ;
static public Token accent_t     = new Token( '`' , "accent" ) ;
static public Token entity_t     = new Token( '&' , "entity" ) ;  //_amper`sand,_resource
//<s>public Token string_t     = new Token( '$' , "string" ) ;</t=noise.switch>//_FIXT:_string_precedes,_or_char_precedes
//<s>public Token string_t     = new Token( '$' , "string" ) ;</t=formed.key>//_FIXT:(numbers_or_unicoded_char)->(#)
//<s>public Token string_t     = new Token( '$' , "string" ) ;</t=repo.rep..>//_FIXT:<s>self</>

public struct Token
	{
	public char    c ;
	public string  _ ;
	internal Token( char _char, string _string )
		{
		c = _char ;
		_ = _string ;
		}
	public override string ToString()
			{
			return string.Format( "({0},{1})", c, _ );
			}
	}
#region macro
#if RELEASE
<KNOWN> | "manifest"
#endif
//<NOUN>  | known(_//y)
//<EMBED> | known [<BLITTER (stream=i-id)>]
#endregion macro
//'URN'':'"math":((F#).dae.xml)
#region micro
#if RELEASE
//<(MathML.EMBED)> | known [()).xml
//<(EMBED.MathML)> | known (()].xml
#endif
#endregion
}
