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
	static public c Extern
		{
		get { return (new c()).Extern ; }
		}
	}
public struct c
	{
	string s ;
	public c Extern
		{
		get { s += KeyedWord.Extern + ' '  ; return this ; }
		}
	public c Void
		{
		get { s += KeyedWord.Void + ' '  ; return this ; }
		}
	public static implicit operator string( c c )
		{
		return c.s ;
		}
	}
}//}
