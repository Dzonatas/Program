using System.Xml ;
using System.Extensions ;

partial class A335
{
static State x_state ;
static XmlTextReader   xml ;
static bool            xml_loaded ;
static int[]           x_empty_ruleset = new int[0] ;
static System.Text.StringBuilder symbols_cs = new System.Text.StringBuilder() ;

partial class X //_: YY
	{
	public static readonly System.Collections.Generic.Dictionary<string,string> Auto = new System.Collections.Generic.Dictionary<string,string>()
		{
		{ "branch",     null },
		{ "Entity",     null },
		{ "list",       null },
		{ "argv",       null },
		{ "argc",       null },
		{ "io",         null },
		{ "namespace",  null },
		{ "lhs",        null },
		{ "rhs",        null },
		{ "lhs_X",      null },
		{ "signal",     null },
		{ "glyph",      null },
		{ "lookahead",  null },
		{ "rule",       null },
		{ "point",      null },
		{ "i",          null },
		{ "I",          "" },
		{ "A",          "" },
		{ "synopsis",   null },
		{ "global",     null },
		{ "interface",  null },
		{ "guid",       0.0.GUID() },
		#if DEBUG
		{ "debug_nop", "Current.Interval.NOP() ;" }
		#else
		{ "debug_nop", string.Empty }
		#endif
		} ;
	public static readonly System.Collections.Generic.Dictionary<string,System.Action> Element = new System.Collections.Generic.Dictionary<string,System.Action>()
		{
		{ "filename",     () => {} },
		{ "grammar",      () => {} },
		{ "rules",        () => { rules_b = true ; } },
		{ "rule",         xml_get_rule },
		{ "lhs",          xml_get_lhs  },
		{ "rhs",          () => {} },
		{ "symbol",       () => { xml_get_symbol(rules_b) ; } },
		{ "empty",        xml_get_empty },
		{ "terminals",    () => { rules_b = false ; } },
		{ "terminal",     xml_get_terminal },
		{ "nonterminals", () => {} },
		{ "nonterminal",  xml_get_nonterminal },
		{ "automaton",    () => { _default = new xml_token( xml_symbolset["$accept"], new xml_s("$default") ) ; } },
		{ "state",        xml_get_state },
		{ "itemset",      () => {} },
		{ "item",         xml_get_item },
		{ "actions",      () => {} },
		{ "transitions",  () => {} },
		{ "transition",   xml_get_transition },
		{ "errors",       () => {} },
		{ "reductions",   () => {} },
		{ "reduction",    xml_get_reduction },
		{ "lookaheads",   () => {} },
		{ "solved-conflicts", () => {} }
		} ;
	static bool rules_b = false ;
	}

static void xml_load_grammar()
	{
	if( xml_loaded )
		return ;
	xml = new XmlTextReader( new System.IO.StreamReader( "../../~/ilxml/grammar.xml" ) ) ;
	while( xml.Read() )
		if( xml.NodeType == XmlNodeType.Element && xml.Name == "bison-xml-report" )
			break ;
	while( xml.Read() )
		{
		if( XmlNodeType.Element == xml.NodeType )
			X.Element[xml.Name]() ;
		else
		if( XmlNodeType.EndElement == xml.NodeType )
			{
			if( xml.Name == "state" )
				x_state.Set() ;
			if( xml.Name == "rule" )
				x_rule.post() ;
			if( xml.Name == "bison-xml-report" )
				goto xml_end ;
			}
		}
	xml_end:
	xml_loaded = true ;
	foreach( State s in stateset )
		foreach( Transition t in s.Transitionset )
			stateset[t.state].Append( (int)s.Number ) ;
	}

public struct xml_s
	{
	public string s ;
	public xml_s( string s )
		{
		this.s = s ;
		}
	public string _s
		{
		get
			{
			string i = "_" ;
			foreach( char c in s )
				if( char.IsLetter(c) )
					i += c ;
				else
					i += string.Format( "{0:X2}", (int)c ) ;
			return i ;
			}
		}
	public override string ToString()
		{
		return s;
		}
	}

public class xml_t
	{
	public int     symbol ;
	public char    token ;
	public xml_s   name ;
	public xml_s   usefulness ;
	internal xml_t()
		{
		xml.MoveToFirstAttribute() ;
		symbol = int.Parse( xml.Value ) ;
		xml.MoveToNextAttribute() ;
		token =  (char)int.Parse( xml.Value ) ;  //_FIX:_new_Symbol(d,i);_new_Token(i,d);
		xml.MoveToNextAttribute() ;
		name  =  new xml_s( xml.Value ) ;
		xml.MoveToNextAttribute() ;
		usefulness = new xml_s( xml.Value ) ;
		}
	}
	
public class xml_nt
	{
	public int     symbol ;
	public xml_s   name ;
	public xml_s   usefulness ;
	internal xml_nt()
		{
		xml.MoveToFirstAttribute() ;
		symbol = int.Parse( xml.Value ) ;
		xml.MoveToNextAttribute() ;
		name  =  new xml_s( xml.Value ) ;
		xml.MoveToNextAttribute() ;
		usefulness = new xml_s( xml.Value ) ;
		}
	public override string ToString()
			{
			return string.Format("({0},{1},{2})",symbol,name.s,usefulness.s);
			}
	}
	
public class xml_rule
	{
	public System.Decimal number ;
	public xml_s          lhs ;
	public xml_s[]        rhs ;
	public xml_s          usefulness ;
	internal void post()
		{
		new Rule( number, lhs, rhs, usefulness.s == "useful" ) ;
		}
	public xml_rule()
		{
		xml.MoveToFirstAttribute() ;
		number = int.Parse( xml.Value ) ;
		xml.MoveToNextAttribute() ;
		usefulness  =  new xml_s( xml.Value ) ;
		rhs = new xml_s[0] ;
		}
	}

static void xml_get_symbol( bool _rule )
	{
	xml.Read() ;
	if( _rule )
		{
		System.Array.Resize( ref x_rule.rhs, x_rule.rhs.Length+1 ) ;
		x_rule.rhs[x_rule.rhs.Length-1] = new xml_s( xml.Value ) ;
		string s1 = "_"+
			( ( (int)x_rule.number < 10 ) ? "__"
			: ( (int)x_rule.number < 100 ) ? "_"
			: ""
			) ;
		string s2 = "_"+
			( (x_rule.rhs.Length-1) < 10 ? "_" : "" ) ;
		X.Auto[s1+(int)x_rule.number+s2+(x_rule.rhs.Length-1)] = x_rule.rhs[x_rule.rhs.Length-1]._s ;
		}
	else
		{
		x_state.Lookaheadset_Add ( (int)xml_tokenset[xml.Value] ) ;
		}
	xml.Read() ;
	}

static void xml_get_empty()
	{
	System.Array.Resize( ref x_empty_ruleset, x_empty_ruleset.Length+1 ) ;
	x_empty_ruleset[x_empty_ruleset.Length-1] = (int)x_rule.number ;
	string s1 = "_"+
		( ( (int)x_rule.number < 10 ) ? "__"
		: ( (int)x_rule.number < 100 ) ? "_"
		: ""
		) ;
	string s2 = "___" ;
	X.Auto[s1+(int)x_rule.number+s2] = x_rule.lhs._s ;
	}

struct xml_token
	{
	char  c ;
	int   i ;
	xml_s s ;
	internal xml_token( char c, int i, xml_s s )
		{
		this.c = c ;
		this.i = i ;
		this.s = s ;
		xml_tokenset.Add( this.s.s, this ) ;
		xml_translate.Add( c, i ) ;
		}
	internal xml_token( xml_symbol x, xml_s s )
		{
		this.c = (char)x ;
		this.i = (int)x ;
		this.s = s ;
		xml_tokenset.Add( this.s.s, this ) ;
		xml_translate.Add( c, i ) ;
		}
	static public explicit operator char( xml_token t )
		{
		return t.c ;
		}
	static public implicit operator int( xml_token t )
		{
		return t.i ;
		}
	internal void accept()
		{
		xml_symbolset.Add( "$default", new xml_symbol( xml_symbolset["$end"], this.s ) ) ;
		}
	public override string ToString()
			{
			return string.Format("[{0},{1},{2}]",(int)c,i,s.s);
			}
	}
	
struct xml_symbol
	{
	int    i ;
	xml_s  s ;
	internal xml_symbol( int i, xml_s s )
		{
		this.i = i ;
		this.s = s ;
		xml_symbolset.Add( this.s.s, this ) ;
		}
	static public implicit operator int( xml_symbol s )
		{
		return s.i ;
		}
	public override string ToString()
			{
			return string.Format("[{0},{1}]",i,s.s);
			}
	//static public implicit operator char( xml_symbol s )
	//	{
	//	return '$' ;
	//	}
	}
	
public static System.Collections.Generic.Dictionary<char,int> xml_translate          = new System.Collections.Generic.Dictionary<char,int>() ;
static System.Collections.Generic.Dictionary<string,xml_token>  xml_tokenset  = new System.Collections.Generic.Dictionary<string, xml_token>() ;
static System.Collections.Generic.Dictionary<string,xml_symbol> xml_symbolset = new System.Collections.Generic.Dictionary<string, xml_symbol>() ;

static xml_token _default ;
static void xml_get_terminal()
	{
	xml_t t = new xml_t() ;
	new xml_token( t.token, t.symbol, t.name ) ;
	symbols_cs.Append( string.Format("internal const int {0,30}\t= "+(int)t.symbol+" ;\n\t", t.name._s) ) ;
	}
	
static void xml_get_nonterminal()
	{
	xml_nt nt = new xml_nt() ;
	object o = new xml_symbol( nt.symbol, nt.name ) ;
	Rule.SetSymbol( nt.name.s, nt.symbol ) ;
	symbols_cs.Append( string.Format( "internal const int {0,30}\t= "+(int)nt.symbol+" ;\n\t", nt.name._s ) ) ;
	}

static void xml_get_state()
	{
	xml.MoveToFirstAttribute() ;
	x_state.Number = System.Decimal.Parse( xml.Value ) ;
	}

static void xml_get_item()
	{
	Itemset i = new Itemset() ;
	xml.MoveToFirstAttribute() ;
	i.rule = System.Decimal.Parse( xml.Value ) ;
	xml.MoveToNextAttribute() ;
	i.point = int.Parse( xml.Value ) ;
	foreach( System.Decimal n in x_empty_ruleset )
		if( n == i.rule )
			i.empty = true ;
	x_state.Append( i ) ;
	}

static void xml_get_transition()
	{
	Transition t = new Transition() ;
	xml.MoveToFirstAttribute() ;
	t.type = xml.Value ;
	xml.MoveToNextAttribute() ;
	if( t.type == "goto" )
		t.symbol = xml_symbolset[xml.Value] ;
	else
		t.symbol = xml_tokenset[xml.Value] ;
	t.item = Itemset.Find( x_state.Itemset, xml.Value ) ;
	xml.MoveToNextAttribute() ;
	t.state = int.Parse( xml.Value );
	x_state.Append( t ) ;
	}

static void xml_get_reduction()
	{
	Reduction r = new Reduction() ;
	xml.MoveToFirstAttribute() ;
	r.symbol = xml_tokenset[ xml.Value ] ;
	if( r.symbol != _default && -1 == System.Array.IndexOf( x_state.Lookaheadset, r.symbol ) )
		r.item = Itemset.Find( x_state.Itemset, xml.Value ) ;
	xml.MoveToNextAttribute() ;
	if( xml.Value != "accept" )
		r.rule = System.Decimal.Parse( xml.Value ) ;
	xml.MoveToNextAttribute() ;
	r.enabled = bool.Parse( xml.Value ) ;
	if( r.symbol == _default )
		{
		x_state.Default_reduction = x_state.Reductionset.Length ;
		int i = Itemset.FindDefault( x_state.Itemset, r.rule ) ;
		r.item = x_state.Itemset[i] ;
		x_state.Default_item = i ;
		}
	x_state.Append( r ) ;
	}
	
static xml_rule x_rule ;
static void xml_get_rule()
	{
	x_rule = new xml_rule() ;
	}

static void xml_get_lhs()
	{
	xml.Read() ;
	x_rule.lhs = new xml_s( xml.Value ) ;
	xml.Read() ;
	}
}
