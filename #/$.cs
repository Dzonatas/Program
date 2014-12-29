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
static public Tokenset.Token string_t     = new Tokenset.Token( '$' , "string" ) ;
static public Tokenset.Token underline_t  = new Tokenset.Token( '_' , "underline" ) ;
static public Tokenset.Token accent_t     = new Tokenset.Token( '`' , "accent" ) ;
static public Tokenset.Token entity_t     = new Tokenset.Token( '&' , "entity" ) ;  //_amper`sand,_resource
//<s>public Token string_t     = new Token( '$' , "string" ) ;</t=noise.switch>//_FIXT:_string_precedes,_or_char_precedes
//<s>public Token string_t     = new Token( '$' , "string" ) ;</t=formed.key>//_FIXT:(numbers_or_unicoded_char)->(#)
//<s>public Token string_t     = new Token( '$' , "string" ) ;</t=repo.rep..>//_FIXT:<s[0]/t=[.post|.get]>
//<s>public Token string_t     = new Token( '$' , "0x0C" ) ;</t=repo.rep..>//_FIXT:.custom
//<s>public Token string_t     = new Token( '$' , "0xCA" ) ;</t=repo.rep..>//_FIXT:.custom ATTRIBUTE
//<s>public Token string_t     = new Token( '$' , "0XFF" ) ;</t=repo.rep..>//_FIXT:(ref:opcode.def)
//<s>public Token string_t     = new Token( '<' , "shift-in" ) ;  //_FIXT:.custom '<':.ctor = ( SI )
//<s>public Token string_t     = new Token( '>' , "shift-out" ) ; //_FIXT:.custom '>':.ctor = ( SO )
//@Expect: Assembler ASCII encoded ECMA335 with '.custom' modules

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
