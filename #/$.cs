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
//<s>public Token string_t     = new Token( '$' , "string" ) ;</t=noise.>

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
#region macro
}
