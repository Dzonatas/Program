using System.Text.RegularExpressions ;

public interface Item {}

public partial class A335
{
public class I : global::Item {}
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

static _.Token input( ref _.Token[] b_line )
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
	#if DEBUG
	return Tokenset.Input ;
	#else
	return _.input() ;
	#endif
	#endif
	}

class Instr : Automatrix
	{
	Instr next ;
	string code ;
	static Instr list ;
	static Instr previous ;
	static Instr current ;
	static public Instr List
		{
		get { Instr l = list ; list = previous = current = null ; return l ; }
		}
	public Instr Next
		{
		get { return next ; }
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
			c_oprand = A335.Method.Head.Current.NewOprand( op ) ;
			op = c_oprand.Instruction ;
			log( "[Instr.Oprand] "+ op ) ;
			current = this ;
			_instr = instr ;
			}
		static public void Declared()
			{
			current = null ;
			}
		}
	static string op ;
	protected string Op
		{
		set {
			current = this ;
			if( previous != null ) previous.next = current ;
			if( list == null ) list = this ;
			op = value ;
			op = (oprand = new Oprand(this)).C.Instruction ;
			code = op ;
			}
		get { return op ; }
		}
	protected Oprand oprand ;
	public Program.C_Oprand _C_Oprand
		{
		get { return oprand.C ; }
		}
	public bool C_OprandHasArgs
		{
		set { oprand.C.HasArgs = value ; }
		}
	public void Defined()
		{
		Oprand.Declared() ;
		previous = current ;
		}
	public class Method : Instr
		{
		protected C_Type _Type ;
		protected C_Type _TypeSpec ;
		protected C_Symbol _Call ;
		protected SigArgs0 _SigArgs0 ;
		protected bool     CallConvInstance ;
		protected override void main()
			{
			Op            = Arg1.Token ;
			CallConv      = Arg2 ;
			Type          = Arg3 ;
			TypeSpec      = Arg4 ;
			// '::'
			//MethodName    = Arg6 ;
			// '('
			SigArgs0      = Arg8 ;
			// ')'
			MethodName    = Arg6 ;
			METHOD() ;
			}
		protected virtual void METHOD() {}
		protected Argument SigArgs0
			{
			set { if ( value is Argument )
					{
					var a = (Automatrix) value ;
					if( a is Automatrix )
						{
						_SigArgs0 = a as SigArgs0 ;
						}
					}
				}
			}
		protected Argument CallConv
			{
			set { CallConvList = (((Automatrix) value) as CallConv).List ; }
			}
		protected Argument MethodName
			{
			set { _Call = C_Symbol.Acquire( _TypeSpec + methodname( value ) + ( _SigArgs0 == null ? "" : _SigArgs0.Types() ) ) ; }
			}
		string methodname( Argument arg )
			{
			return        (Automatrix) arg is methodName___ctor_
				? _ctor
				: Nameset[2] + arg.Token
				;
			}
		protected int Args
			{
			get { return ( _SigArgs0 == null ? 0 : _SigArgs0.Count() ) + ( CallConvInstance ? 1 : 0 ) ; }
			}
		protected C_Symbol _ctor
			{
			get { return C_Type.Acquire( Nameset[0] ) ; }
			}
		protected A335.Argument   Type
			{
			set { _Type = C_Type.Acquire( value.ResolveType() ) ; }
			}
		protected A335.Argument   TypeSpec
			{
			set { _TypeSpec = C_Type.Acquire( value.ResolveTypeSpec() ) ; }
			}
		public CallConv CallConvList
			{
			set { CallConvInstance = value is CallConv ? value.Instance : false ; }
			}
		}
	public class BrTarget : Instr
		{
		protected C_Label Id ;
		protected override void main()
			{
			Op = Arg1.Token ;
			oprand.BrTarget = true ;
			Id = C_Label.Require( Arg2.Token ) ;
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
		}
	public class Field : Instr
		{
		}
	public class Switch : Instr
		{
		}
	public class None : Instr
		{
		protected override void main()
			{
			Op = Arg1.Token ;
			NONE() ;
			}
		protected virtual void NONE() {}
		}
	public class String : Instr
		{
		protected override void main()
			{
			Op = Arg1.Token ;
			STRING( Arg2 ) ;
			}
		protected virtual void STRING( Argument compQstring ) {}
		}
	public override string ToString()
			{
			return "[Instr] " + code ;
			}
	static public void WriteList( string symbol, Instr instr )
		{
		var sw = System.IO.File.CreateText( directory.FullName + "/" + symbol + ".hpp" ) ;
		for( Instr i = instr ; i is Instr ; i = i.Next )
			i._C_Oprand.WriteTo( sw ) ;
		sw.Close() ;
		}
	}
}
