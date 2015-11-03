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
static public c C
	{
	get { return new c() ; }
	}
public enum Bit
	{
	If     = 0x01 ,
	Goto   = 0x02 ,
	Else   = 0x04 ,
	Object = 0x08 ,
	}
public struct c
	{
	string s ;
	public Bit Bits ;
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
		get { s += KeyedWord.Long + ' '  ; return this ; }
		//get { s += KeyedWord.Int + ' '  ; return this ; }
		}
	public c Static(C699.c c, C699.c symbol)
		{
		s += KeyedWord.Static+' '+c.s+' '+symbol.s + ' ' ; return this ;
		}
	public c Static(C699.c c)
		{
		s += KeyedWord.Static+' '+c.s + ' '  ; return this ;
		}
	public c Const
		{
		get { s += KeyedWord.Const + ' '  ; return this ; }
		}
	public c Return(string symbol)
		{
		s += KeyedWord.Return+' '+symbol + ' '  ; return this ;
		}
	public c If( string expression )
		{
		s += KeyedWord.If+'('+expression+')' + ' '  ; Bits |= Bit.If ; return this ;
		}
	public c If( string expression, c then )
		{
		s += KeyedWord.If+'('+expression+')'+' '+then + ' '  ; Bits |= Bit.If | then.Bits ; return this ;
		}
	public c If( c expr1, string op, c expr2, c then )
		{
		s += KeyedWord.If+'('+expr1+' '+op+' '+expr2+')'+' '+then + ' '  ; Bits |= Bit.If | then.Bits ;
		return this ;
		}
	public c Else
		{
		get { s += KeyedWord.Else + ' '  ; Bits |= Bit.Else ; return this ; }
		}
	public c Goto( string label )
		{
		s += KeyedWord.Goto + ' ' + label  ; Bits |= Bit.Goto ; return this ;
		}
	public c Inline
		{
		get { s += KeyedWord.Inline + ' '  ; return this ; }
		}
	public c Struct(C699.c c)
		{
		s += KeyedWord.Struct+' '+c.s + ' '  ; return this ;
		}
	public c Struct(C699.c c,string symbol)
		{
		s += c.s+' '+symbol + ' '  ; return this ;
		}
	public c Local(C699.c c,string symbol)
		{
		s += c.s+' '+symbol + ' '  ; return this ;
		}
	public c Global(C699.c c,string symbol)
		{
		s += c.s+' '+symbol + ' '  ; return this ;
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
	public c Function( string classtype, string fn, string args )
		{
		s += classtype + '$' + fn +'('+args+')'+' ' ; return this ;
		}
	public c Function( string fn )
		{
		s += fn +'('+')'+' ' ; return this ;
		}
	public c Function( string fn, C699.c arg0 )
		{
		s += fn +'('+arg0+')'+' ' ; return this ;
		}
	public c EqualTo
		{
		get { s += "== " ; return this ; }
		}
	public c Zero
		{
		get { s += "0 " ; return this ; }
		}
	public c One
		{
		get { s += "1 " ; return this ; }
		}
	public c Two
		{
		get { s += "2 " ; return this ; }
		}
	public c Three
		{
		get { s += "3 " ; return this ; }
		}
	public c Equate(string text)
		{
		return new c( s+'='+text+' ' ) ;
		}
	public c Equate(string symbol, string embracement)
		{
		s += symbol+'='+'{'+embracement+'}' ; return this ;
		}
	public c p
		{
		get { s += '*' ; return this ; }
		}
	public static implicit operator string( c c )
		{
		return c.s ;
		}
	public c/**/ Restricted( string expression ) //($(X)RSH)|$futex_unknown
		{
		#if DEBUG_RESTRICTED
		System.Console.WriteLine(expression) ;
		#endif
		return (new c(expression+' ')) ;
		}
	public c/**/ Literal( string value )
		{
		return (new c(value+' ')) ;
		}
	public c Static(C699.c c,string symbol)
		{
		return (new c()).Static(c,new c(symbol)) ;
		}
	public c( string text )
		{
		s = text ;
		Bits = 0 ;
		}
	}
public struct cso
	{
	c _c ;
	string s ;
	public cso(c cc)
		{
		_c = cc ;
		s = "" ;
		}
	#if DEBUG
	public cso assembly
		{
		get { s += "\""+System.Extensions.var_.GUID(0.1)+"/.assembly.exe\"" ; return this ; }
		}
	public cso argv(string[] args)
		{
		s += ", "+string.Join(", ", args)+", 0 " ;
		return this ;
		}
	public c asm
		{
		get { return _c.Function( "fasm", C.Restricted( "(char*[]) {"+s+"}" ) ) ; }
		}
	#endif
	}
public struct cil
	{
	//https://github.com/CosmosOS/Cosmos/tree/c591a7ff1b7d8e37871b3cc75999df4fa6817e9f/source/Cosmos.IL2CPU
	}
}//}
