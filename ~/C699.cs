//namespace C {
public partial class C699 {
public static class KeyedWord
	{
	public const string For    = "for"    ;
	public const string If     = "if"     ;
	public const string Else   = "else"   ;
	public const string Goto   = "goto"   ;
	public const string Do     = "do"     ;
	public const string While  = "while"  ;
	public const string Return = "return" ;
	public const string Void   = "void"   ;
	public const string Char   = "char"   ;
	public const string Long   = "long"   ;
	public const string Short  = "short"  ;
	public const string Int    = "int"    ;
	public const string Struct = "struct" ;
	public const string Extern = "extern" ;
	public const string Main   = "main"   ;
	}
public struct C
	{
	static public c Charpp
		{
		get { return (new c()).Charpp ; }
		}
	static public c Extern
		{
		get { return (new c()).Extern ; }
		}
	static public c Int
		{
		get { return (new c()).Int ; }
		}
	static public c Cctor( string classtype )
		{
		return (new c(classtype)).Cctor() ;
		}
	static public c Function( string classtype, string fn )
		{
		return (new c()).Function(classtype, fn) ;
		}
	}
public struct c
	{
	string s ;
	public c Charpp
		{
		get { s += KeyedWord.Char+'*'+'*' + ' '  ; return this ; }
		}
	public c Extern
		{
		get { s += KeyedWord.Extern + ' '  ; return this ; }
		}
	public c Void
		{
		get { s += KeyedWord.Void + ' '  ; return this ; }
		}
	public c Int
		{
		get { s += KeyedWord.Int + ' '  ; return this ; }
		}
	public c ArgC
		{
		get { s += "argc" + ' '  ; return this ; }
		}
	public c ArgV
		{
		get { s += "args" + ' '  ; return this ; }
		}
	public c Env
		{
		get { s += "env" + ' '  ; return this ; }
		}
	public c Cctor( string classtype )
		{
		s += classtype + "_cctor()" + ' ' ; return this ;
		}
	public c Cctor()
		{
		s += "_cctor()" + ' ' ; return this ;
		}
	public c Function( string classtype, string fn )
		{
		s += classtype + '$' + fn +'('+')'+' ' ; return this ;
		}
	public static implicit operator string( c c )
		{
		return c.s ;
		}
	public c( string text )
		{
		s = text ;
		}
	}
}//}
