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

class Instr
	{
	public class Method : Automatrix
		{
		static public C_Type   Type ;
		static public int      SigArgs ;
		static public string   SigArgTypes ;
		static public C_Type   Class ;
		static public C_Symbol Symbol ;
		static public bool CallConvInstance ;
		public CallConv CallConvList
			{
			set { CallConvInstance = value is CallConv ? value.Instance : false ; }
			}
		}
	public class BrTarget : Automatrix
		{
		static public string ID ;
		}
	}

[Automaton] class   instr_INSTR_BRTARGET_id
	: Instr.BrTarget {
	protected override void main()
		{
		ID = Arg2.Token ;
		}
	}

[Automaton] class   instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____
	: Instr.Method	{
	protected override void main()
		{
		string methodName = System.String.Empty ;
		if( Argv[6] is methodName___ctor_ )
			methodName = "_ctor" ;
		else
			methodName = "$" + Arg6.Token ;
		Type          = C_Type.Acquire( Arg3.ResolveType() ) ;
		Class         = C_Type.Acquire( Arg4.ResolveTypeSpec() ) ;
		Symbol        = C_Symbol.Acquire( Class + methodName + SigArg.Types() ) ;
		SigArgs       = SigArg.Count() ;
		SigArgTypes   = SigArg.Types() ;
		CallConvList  = A335.CallConv.List ;
		SigArg.Clear() ;
		}
	}
}
