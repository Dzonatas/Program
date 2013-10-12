using System;

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
const  Decimal    icon_voxel  = 0.0000m ;//_unordered_content[_token]
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

public struct Item
	{
	public Symbol  symbol ;
	public Decimal account ;
	public bool    imaginary ;
	public bool    stacked ;
	public bool    existential ;
	public Quant   q ;
	public Quant   bit ;
	public Action  do_ ;
	public Nullable<Guid> guid ;
	public static implicit operator Item( State state )
		{
		throw new NotImplementedException( "Stackless." ) ;
		}
	public static implicit operator Item( Symbol symbol )
		{
		throw new NotImplementedException( "Stateless." ) ;
		}
	public static implicit operator Item( bool parity )
		{
		throw new NotImplementedException( "Finite truths, linearly." ) ;
		}
	public static implicit operator bool( Item i )
		{
		return i.existential ;
		}
	public static implicit operator Symbol( Item i )
		{
		return i.symbol ;
		}
	public static implicit operator int( Item i )
		{
		return (int)i.account ;
		}
	public static implicit operator Decimal( Item i )
		{
		return i.account ;
		}
	public static implicit operator State( Item i )
		{
		return stateset[i] ;
		}
	public override string ToString()
		{
		return ( symbol.StringIsNull ? "" : symbol.ToString() ) +'-'+ account.ToString() ;
		}
	public Item( Symbol symbol, State state )
		{
		this.symbol      = symbol ;
		this.account     = state ;
		this.stacked     = false ;
		this.existential = false ;
		this.imaginary   = true ;
		this.q           = new Quant() ;
		this.bit         = new Quant() ;
		this.do_         = null ;
		// {0:0:0} ;
		}
	}

static _.Token input( ref System.Collections.Generic.List<_.Token> b_line )
	{
	int y = 0 ;
	foreach( _.Token t in b_line )
		{
		string text = "<"+t._+">" ;
		y += text.Length ;
		}
	while( y < 80 )
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
		if( y >= 80 )
			break ;
		Console.SetCursorPosition( z, 20 ) ;
		Console.Write( text ) ;
		}
	_.Token token = b_line[0] ;
	if( debug ) 
		_.prompt(token) ;
	b_line.RemoveAt(0) ;
	return token ;
	}
	

}
