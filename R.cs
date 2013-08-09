using System;
using System.IO ;
using System.Xml ;
using System.Diagnostics ;
using System.Collections.Generic ;

public partial class A335
{

static Rule [] ruleset = new Rule[606] ;

public struct Rule
	{
	public Number        number ;
	public xml_s         lhs ;
	public List<xml_s>   rhs ;
	public bool          useful ;
	public Rule( Rule r )
		{
		this = r ;
		}
	public static implicit operator int( Rule r )
		{
		return xo_t[r.number] ; // symbol_from_name[ r.lhs.s ];
		}
	public override string ToString()
		{
		if( useful )
			return +'('+lhs.s+')'
				+ number 
				+'['+ rhs.Count.ToString() +']' ;
			
		return string.Format("({0}{1},{2})", lhs, number, rhs.Count );
		//return string.Format("({0}{1},{2})", lhs, number, rhs.Count );
		}
	}

public struct Reduction
	{
	public int     symbol  ;
	public int     rule    ;
	public bool    enabled ;
	public Itemset item    ;
	public bool   Default( int rule )
		{
		if( symbol == _default && rule == this.rule )
			return true ;
		return false ;
		}
	static public implicit operator Xo( Reduction r )
		{
		return (Xo)xo_t[r.rule] ;
		}
	public override string ToString()
		{
		if( enabled )
			return symbol.ToString() +"->"+ xo_t[rule] ;
		return string.Format("[Reduction]({0},{1})", symbol, rule );
		}
	static public implicit operator int( Reduction r )
		{
		return r.symbol ;
		}
	}

static string r_number( int n )
	{
	switch( n )
		{
		case 0 : return "0" ;    //_FIX: 0.ToString() ;
		case 1 : return "One" ;
		case 2 : return "Two" ;
		case 3 : return "Three" ;
		case 4 : return "Four" ;
		case 5 : return "Five" ;
		case 6 : return "Six" ;
		case 7 : return "Seven" ;
		case 8 : return "Eight" ;
		case 9 : return "Nine" ;
		default: return n.ToString() ;
		}
	}

static bool requested_system ;

static void request( ref Item i )
	{
	if( i.stacked )
		throw new NotImplementedException( "Did, done." ) ;

	if( system.Equals(i) && ! requested_system )
		{
		requested_system = true ;
		_.assimulation() ;
		}
						
	i.stacked = true ;
	i.bit.One = false ;
	stack.Push( i ) ;
	if( object.ReferenceEquals(i.symbol,yytoken) )
		yytoken = new Symbol() ;
	Console.WriteLine( "$$ <- {0}   ", i ) ;
	//print_stack() ;
	}

static Item respond()
	{
	Item i = new Item() ;
	i = stack.Pop() ;
	if( i.symbol.StringIsNull && yytoken.StringIsNull )
		xml_get_() ;
	Console.WriteLine( "$$ -> {0}   ", i ) ;
	//print_stack() ;
	i.bit.One = false ;
	return i ;
	}

static void request( ref State s )
	{
	DateTime z = DateTime.Now ;
	if( this_state.debit != null && this_state.debit != s.debit )
		{
		stateset[this_state.debit].zlog.Add( z ) ;
		stateset[this_state.debit].zlog.Add( s ) ;
		stateset[         s.debit].zlog.Add( this_state ) ;
		stateset[         s.debit].zlog.Add( z ) ;
		}
	this_state = s ;
	}

	
public class ReducedAcception : Exception
	{
	public int     rule ;
	public int     backup ;
	public ReducedAcception( int rule )
		{
		this_state.zlog.Add( this ) ;
		this.rule = rule  ;
		this.backup = xo_t[rule].rhs.Length ;
		}
	public override string ToString()
			{
			return string.Format("[ReducedAcception={0}]{1}",backup,xo_t[rule]);
			}
	}

static bool reduction( int c, out Reduction rr )
	{
	foreach( Reduction r in this_state.reductionset )
		if( r == c )
			{
			rr = r ;
			return true ;
			}
	rr = new Reduction() ;
	return false ;
	}
	


}
