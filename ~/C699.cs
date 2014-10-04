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
	public const string Const  = "const"  ;
	public const string Static = "static" ;
	public const string Inline = "inline" ;
	public const string Main   = "main"   ;
	//public const string U3n   = "u3n"   ;
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
	static public c Static(C699.c c)
		{
		return (new c()).Static(c) ;
		}
	static public c Struct(C699.c c)
		{
		return (new c()).Struct(c) ;
		}
	static public c Const
		{
		get { return (new c()).Const ; }
		}
	static public c Return
		{
		get { return (new c()).Return ; }
		}
	static public c If( string expression )
		{
		return (new c()).If(expression) ;
		}
	static public c Else
		{
		get { return (new c()).Else ; }
		}
	static public c Inline
		{
		get { return (new c()).Inline ; }
		}
	static public c Void
		{
		get { return (new c()).Void ; }
		}
	static public c Cctor( string classtype )
		{
		return (new c(classtype)).Cctor() ;
		}
	static public c Function( string classtype, string fn )
		{
		return (new c()).Function(classtype, fn) ;
		}
	static public c/**/ Restricted( string expression ) //($(X)RSH)|$futex_unknown
		{
		System.Console.WriteLine(expression) ;
		if( expression.StartsWith(C699.KeyedWord.Goto) )
			return (new c(expression)) ; //c.Goto(#|Label|IntPtr)
		return (new c(expression+' ')) ;
		}
	}
public struct c
	{
	string s ;
	#if !____biz
	public c Tut( c c )
		{
		s += '('+c+ ')'  ; return this ;
		}
	#endif
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
	public c Voidpp
		{
		get { s += KeyedWord.Void+'*'+'*' + ' '  ; return this ; }
		}
	public c Int
		{
		get { s += KeyedWord.Int + ' '  ; return this ; }
		}
	public c Static(C699.c c)
		{
		s += KeyedWord.Static+' '+c.s + ' '  ; return this ;
		}
	public c Struct(C699.c c)
		{
		s += KeyedWord.Struct+' '+c.s + ' '  ; return this ;
		}
	public c Const
		{
		get { s += KeyedWord.Const + ' '  ; return this ; }
		}
	public c Return
		{
		get { s += KeyedWord.Return + ' '  ; return this ; }
		}
	public c If( string expression )
		{
		s += KeyedWord.If+'('+expression+')' + ' '  ; return this ;
		}
	public c Else
		{
		get { s += KeyedWord.Else + ' '  ; return this ; }
		}
	public c Inline
		{
		get { s += KeyedWord.Inline + ' '  ; return this ; }
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
	public c Equate(string text)
		{
		s += '='+text+' ' ; return this ;
		}
	public c Equate(string symbol, string embracement)
		{
		s += symbol+'='+'{'+embracement+'}' ; return this ;
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
