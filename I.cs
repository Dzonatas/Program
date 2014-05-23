using System.Text.RegularExpressions ;

public partial class A335
{
static string iconic_Earth ; //[static:Earth:"EARTH"]
static string icon_dae_s ; //_X-CONSOLE:_requires:pointed:'Atomatrix'b
static string icon_dae_q ; //_X-CONSOLE:_requires:pointed:'Atomatrix'b:[Q,r]
static string icon_dae_r ; //_X-CONSOLE:_requires:pointed:'Atomatrix'b:[q,R]
//const   int icon_dae_v ; //_X-CONSOLE:_requires:pointed:'Atomatrix'b:[var:...]
#if OAUTH
[OAuth] Token infrastructure_i ;
#endif
const  System.Decimal    icon_voxel  = 0.0000m ;//_unordered_content[_token]
const  char []    i_undefined = null ; //{0xCA,0xFF} ;
//{"icon:voxel:",<title/>}//
//string input = "<?xml version=\"1.0\" ?>\n<xml><a f=\"1\">b</a><c>d</c></xml>" ;
//string input = "<?xml version=\"1.0\" ?>\n<xml reflection><a f=\"1\">b</a><c>d</c></xml>" ;
//string input = "<?xml version=\"1.1\" ?>\n<xml reflection-scope-i><a f=\"1\">b</a><c>d</c></xml>" ;
//string input = "<?xml version=\"1.1\" ?>\n<xml reflection-type-i><a f=\"1\">b</a><c>d</c></xml>" ;
//string input = "<?xml version=\"1.1\" ?>\n<xml reflection-prop-i><a f=\"1\">b</a><c>d</c></xml>" ;
//string input = "<?xml version=\"1.0\" ?>\n<xml reflection-i><a f=\"1\">b</a><c>d</c></xml>" ;
//string input = "<?xml version=\"0.1\" ?>\n<xml reflection--i><a f=\"1\">b</a><c>d</c></xml>" ;
//string input = "<?xml version=\"0.0\" ?>\n<xml reflection--i><a f=1>b</a><c>d</c></xml>" ;
//string input = "N0P<?xml version=(0.0) ?>\n<xml reflection-ice-i><a f=1>b</a><c>d</c></xml>" ;
//string input = "<xml reflection-ice-i><a f=1>b</a><c>d</c></xml>"'//y' ;
//string input = "<xml -i><a f=1>b</a><c>d</c></xml>"'//y' ;
//string input = "<a f=1>b</a><c>d</c>" ; //[radical_(i|-i)]
//string input = "<a1>b</><c>d</>" ;      //alpha[,<_->...][,_octal]
//string input = "b</><c>d</>" ;          //beta[,_octal]
//string input = "<c>d</>" ;              //[_cgroup]
//string input = "d</>" ;                 //[_data(_hexbytes)]
//string input = ""'//y' ;                //...gamma[[,_avoid_[hd]_syncs(_burner[_m[s]|_s])]|[,_dump_gamma]]
//[_od]

public struct Itemset
	{
	public int   rule ;
	public int   point ;
	static public explicit operator int( Itemset i )
		{
		return (int)xo_t[i.rule][i.point] ;
		}
	static public implicit operator Xo( Itemset i )
		{
		return xo_t[i.rule][i.point] ;
		}
	public override string ToString()
		{
		if( xo_t[rule].rhs.Length == point )
			return xo_t[rule].ToString() +'.'+ point.ToString() ;
		return xo_t[rule][point].ToString() ;
		}
	/*
	public static implicit operator Xo( Itemset i )
		{
		if( i.point < xo_t[i.rule].Length )
			return xo_t[i.rule][i.point] ;
		return new Xo( i.rule, i.point, _empty ) ;
		}
	*/
	}

static _.Token input( ref System.Collections.Generic.List<_.Token> b_line )
	{
	#if DEBUG_INPUT
	int y = 0 ;
	foreach( _.Token t in b_line )
		{
		string text = "<"+t._+">" ;
		y += text.Length ;
		}
	while( y < System.Console.WindowWidth )
		{
		_.Token t = _.input() ;
		b_line.Add( t ) ;
		string text = "<"+t._+">" ;
		y += text.Length ;
		}
	y = 0 ;
	foreach( _.Token t in b_line )
		{
		int z = y ;
		string text = "<"+t._+">" ;
		y += text.Length ;
		if( y >= System.Console.WindowWidth )
			break ;
		System.Console.SetCursorPosition( z, 20 ) ;
		System.Console.Write( text ) ;
		}
	_.Token token = b_line[0] ;
	if( debug ) 
		_.prompt(token) ;
	b_line.RemoveAt(0) ;
	return token ;
	#else
	return _.input() ;
	#endif
	}

	static protected C_Type type ;
	static protected C_Type typespec ;
class Instr : Automatrix
	{
	const string start_s = "start" ;
	static Oprand _start ;
	static Instr()
		{
		_start = new Oprand( start_s ) ;
		}
	public class Oprand
		{
		Instr _instr ;
		Program.C_Oprand c_oprand ;
		static Oprand current ;
		static public A335.Program.C_Oprand Current
			{
			get { return current.c_oprand ; }
			}
		public A335.Program.C_Oprand C
			{
			get { return c_oprand ; }
			}
		public bool BrTarget
			{
			set { c_oprand.BrTarget = value ; }
			}
		public Oprand( Instr instr )
			{
			c_oprand = A335.method.NewOprand( op ) ;
			op = c_oprand.Instruction ;
			log( "[Instr.Oprand] "+ op ) ;
			current = this ;
			_instr = instr ;
			}
		public Oprand( string instr )
			{
			c_oprand = A335.method.NewOprand( instr ) ;
			op = c_oprand.Instruction ;
			log( "[Instr.Oprand] "+ op ) ;
			current = this ;
			_instr = null ;
			}
		static public void Declared()
			{
			current = null ;
			}
		}
	static string op ;
	protected string Op
		{
		set { op = value ; op = (oprand = new Oprand(this)).C.Instruction ; }
		get { return op ; }
		}
	protected Oprand oprand ;
	static public void Declared()
		{
		Oprand.Declared() ;
		Method.SigArgTypes = null ;
		Method.SigArgs = 0 ;
		Method.CallConvInstance = false ;
		}
	public class Method : Instr
		{
		protected override void main()
			{
			Op            = Arg1.Token ;
			CallConvList  = A335.CallConv.List ;
			Type          = Arg3 ;
			TypeSpec      = Arg4 ;
			// '::'
			Symbol        = _arg6_methodname() ;
			// '('
			SigArgs       = SigArg.Count() ;
			SigArgTypes   = SigArg.Types() ;
			SigArg.Clear() ;
			// ')'
			METHOD() ;
			}
		protected virtual void METHOD() {}
		C_Symbol _arg6_methodname()
			{
			string symbol = A335.typespec + arg6_methodname() + SigArg.Types() ;
			return C_Symbol.Acquire( symbol ) ;
			}
		string arg6_methodname()
			{
			return        Argv[6] is methodName___ctor_
				? _ctor
				: Nameset[2] + Arg6.Token
				;
			}
		protected int Args
			{
			get { return SigArgs + ( CallConvInstance ? 1 : 0 ) ; }
			}
		protected C_Symbol _ctor
			{
			get { return C_Type.Acquire( Nameset[0] ) ; }
			}
		protected A335.Argument   Type
			{
			set { A335.type = C_Type.Acquire( value.ResolveType() ) ; }
			}
		static public int      SigArgs ;
		static public string   SigArgTypes ;
		protected A335.Argument   TypeSpec
			{
			set { typespec = C_Type.Acquire( value.ResolveTypeSpec() ) ; }
			}
		static public C_Symbol Symbol ;
		static public bool CallConvInstance ;
		public CallConv CallConvList
			{
			set { CallConvInstance = value is CallConv ? value.Instance : false ; }
			}
		}
	public class BrTarget : Instr
		{
		protected string Id ;
		protected override void main()
			{
			Op = Arg1.Token ;
			oprand.BrTarget = true ;
			Id = Arg2.Token ;
			BRTARGET() ;
			}
		protected virtual void BRTARGET() {}
		}
	public class Type : Instr
		{
		protected override void main()
			{
			Op = Arg1.Token ;
			TYPE( Arg2 ) ;
			}
		protected virtual void TYPE( Argument typeSpec ) {}
		protected Program.C_Oprand Declare( string op )
			{
			oprand = new Oprand( op ) ;
			return oprand.C ;
			}
		}
	public class Field : Instr
		{
		protected Program.C_Oprand Declare( string op )
			{
			oprand = new Oprand( op ) ;
			return oprand.C ;
			}
		}
	public class Switch : Instr
		{
		protected Program.C_Oprand Declare( string op )
			{
			oprand = new Oprand( op ) ;
			return oprand.C ;
			}
		}
	public class None : Instr
		{
		protected Program.C_Oprand Declare( string op )
			{
			oprand = new Oprand( op ) ;
			return oprand.C ;
			}
		}
	public class String : Instr
		{
		protected Program.C_Oprand Declare( string op )
			{
			oprand = new Oprand( op ) ;
			return oprand.C ;
			}
		}
	}
}
