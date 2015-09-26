public partial class A335
{
string rune__ ; /*C`_ -rc:"BRANCH" +volume:0.00*/
static int root_n ; //<KNOWN> | root: <NOUN default="FILE:" refinery-technique-profile=""/>//
string rune___; /*C`__ -volume:0.00 (+"rc:") */
//const int __swp_regex_d ; /* lexical-skew: 'vim was always in re-lexicate screen-mode, vi was not.' */

public struct Rule : IRule
	{
	public System.Decimal   RuleNumber  { get { return number ; } }
	public string           LHS         { get { return lhs ; } }
	public string[]         RHS         { get { return rhs ; } }
	public int              Symbol      { get { return symbol ; } }
	public bool             Useful      { get { return useful ; } }
	public static Rule [] Set = new Rule[0] ;
	System.Decimal number ;
	string         lhs ;
	string[]       rhs ;
	bool           useful ;
	int            symbol ;
	public Rule( System.Decimal _number, xml_s _lhs, xml_s[] _rhs, bool _useful )
		{
		number  = _number ;
		lhs     = _lhs.s ;
		rhs     = new string[_rhs.Length] ;
		for( int i = 0 ; i < _rhs.Length ; i ++ )
			rhs[i] = _rhs[i].s ;
		useful  = _useful ;
		symbol  = -1 ;
		if( number+1 > Set.Length )
			System.Array.Resize( ref Set, (int)number+1 ) ;
		Set[(int)number] = this ;
		}
	public static void SetSymbol( string name, int _symbol )
		{
		for( int i = 0 ; i < Set.Length ; i++ )
			if( Set[i].lhs == name )
				Set[i].symbol = _symbol ;
		}
	public static implicit operator int( Rule r )
		{
		return Rule.Set[r].Symbol ;
		}
	public static implicit operator System.Decimal( Rule r )
		{
		return r.number ;
		}
	static string _s( string s )
		{
		string i = "_" ;
		foreach( char c in s )
			if( char.IsLetter(c) )
				i += c ;
			else
				i += string.Format( "{0:X2}", (int)c ) ;
		return i ;
		}
	public static string EnumSymbol( IRule r )
		{
		return _s( r.LHS ) ;
		}
	public static string Signal( IRule r )
		{
		string i = r.LHS ;
		for( int x = 0 ; x < r.RHS.Length ; x++ )
				i += _s( r.RHS[x] ) ;
		return i ;
		}
	public static string AlphaSignal( IRule r )
		{
		string i = r.LHS ;
		for( int x = 0 ; x < r.RHS.Length ; x++ )
			i += "_" + r.RHS[x] ;
		return System.Text.RegularExpressions.Regex.Replace( i, "[^A-Za-z_0-9]", "_" ) ;
		}
	public override string ToString()
		{
		if( useful )
			return +'('+lhs+')'
				+ number 
				+'['+ rhs.Length.ToString() +']' ;
			
		return string.Format("({0} #{1},{2})", lhs, number, rhs.Length );
		//return string.Format("({0}{1},{2})", lhs, number, rhs.Count );
		}
	}

public struct Reduction
	{
	public int            symbol  ;
	public System.Decimal rule    ;
	public bool           enabled ;
	public Itemset        item    ;
	public bool   Default( int rule )
		{
		if( symbol == _default && rule == this.rule )
			return true ;
		return false ;
		}
	public override string ToString()
		{
		if( enabled )
			return symbol.ToString() +"->"+ xo_t[(int)rule] ;
		return string.Format("[Reduction]({0},{1})", symbol, rule );
		}
	static public implicit operator int( Reduction r )
		{
		return r.symbol ;
		}
	}

#if OLD_ITEM
static void request( ref Item i )
	{
	if( i.stacked )
		throw new System.NotImplementedException( "Did, done." ) ;

	if( system.Equals(i) && ! requested_system )
		{
		requested_system = true ;
		_.assimulation() ;
		}
						
	i.stacked = true ;
	i.bit.One = false ;
	stack.Push( i ) ;
	//if( object.ReferenceEquals(i.symbol,yytoken) )
	//	yytoken = new Symbol() ;
	//System.Console.WriteLine( "$$ <- {0}   ", i ) ;
	//print_stack() ;
	}

static Item respond()
	{
	Item i = (Item)stack.Pop() ;
	//if( i.symbol.StringIsNull && yytoken.StringIsNull )
	//	xml_get_() ;
	//System.Console.WriteLine( "$$ -> {0}   ", i ) ;
	//print_stack() ;
	i.bit.One = false ;
	return i ;
	}
#endif


public class ReducedAcception : System.Exception
	{
	public int     rule ;
	public int     backup ;
	public ReducedAcception( int rule )
		{
		this.rule = rule  ;
		this.backup = Rule.Set[rule].RHS.Length ;
		}
	public override string ToString()
			{
			return string.Format("[ReducedAcception={0}]{1}",backup,xo_t[rule]);
			}
	}

static bool reduction( int c, out Reduction rr )
	{
	foreach( Reduction r in this_state.Reductionset )
		if( r == c )
			{
			rr = r ;
			return true ;
			}
	rr = new Reduction() ;
	return false ;
	}
	

/*
#region micro
<URN.URL> | 'remote' 'var'
#endregion micro
*/
}
