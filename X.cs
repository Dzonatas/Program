using System.Xml ;
using System.IO ;
using System.Collections.Generic ;

public partial class A335
{

static XmlTextReader   xml ;
static string          xml_text ;
static bool            xml_loaded ;
static List<Number>    x_empty_ruleset = new List<Number>() ;
static Xo_t[]          xo_t   = new Xo_t[603] ;  //_overflow(>ASCII(7-bit))_FIX:_common_cause:_unicode_precedence,_entity_not_implemented
//static xml_s           _empty = new xml_s( "" ) ;

public class Xo
	{
	int      x, y ;
	xml_s    text ;
	bool     left ;
	object   o ;
	//Nullable<Symbol> sym ;
	internal Xo( int x, xml_s text ) 
		{
		this.x     = x ;
		this.y     = 0 ;
		this.text  = text ;
		this.o     = null ;
		this.left  = true ;
		}
	internal Xo( int x, int y, xml_s text ) 
		{
		this.x     = x ;
		this.y     = y ;
		this.text  = text ;
		this.o     = null ;
		this.left  = false ;
		}
	internal int X
		{
		get { return x ; }
		}
	internal int Y
		{
		get { return y ; }
		}
	public Rule Rule
		{
		get { return Rule.Set[x] ; }
		}
	internal bool Left
		{
		get { return left ; }
		}
	static public implicit operator int( Xo x )
		{
		if( x.o is xml_token ) return (int)(xml_token)x.o ;
		if( x.o is xml_symbol ) return (int)(xml_symbol)x.o ;
		throw new System.Exception( "<int>" ) ;
		}
	static public explicit operator char( Xo x )
		{
		if( x.o is xml_token ) return (char)(xml_token)x.o ;
		if( x.o is xml_symbol ) return (char)(xml_symbol)x.o ;
		throw new System.Exception( "<char>" ) ;
		}
	internal void set_if( xml_s name, object o )
		{
		if( name.s == text.s )
			{
			text = name ;
			this.o = o ;
			}
		}
	public string s
		{
		get { return text.s ; }
		}
	public override string ToString()
			{
			if( left ) 
				return string.Format("[Xo:{0}:{1}]",x, text.s);
			else
				return string.Format("[Xo:{0}.{1}: s={2} o={3}]",x,y, s, o);
			}
	}

class Xo_t
	{
	internal Xo     lhs ;
	internal Xo[]   rhs ;
	static public void Add( Rule r )
		{
		int x = r.number ;
		int y = r.rhs.Count ;
		xo_t[x]     = new Xo_t() ;
		xo_t[x].lhs = new Xo( x, r.lhs ) ;
		xo_t[x].rhs = new Xo[y] ;
		foreach( xml_s s in r.rhs )
			xo_t[x].rhs[--y] = new Xo(x, y, r.rhs[y] ) ;
		}
	static public implicit operator int( Xo_t x )
		{
		return x.lhs ;
		}
	static public implicit operator Xo( Xo_t x )
		{
		return x.lhs ;
		}
	public string ReductionMethod
		{
		get { return lhs.Rule.Mangle ; }
		}
	public int Length
		{
		get { return this.rhs.Length ; }
		}
	public Xo this[ int n ]
		{
		get {
			if( n == rhs.Length )
				return lhs ;
			return rhs[n] ;
			}
		set { rhs[n] = value ; }
		}
	public override string ToString()
			{
			return string.Format("[Xo_t:{0}[{1}]]", lhs, rhs.Length);
			}
	static string list( int i )
		{
		System.Text.StringBuilder sb = new System.Text.StringBuilder() ;
		sb.AppendLine( "  public const           char     C       = '"+ (char)xo_t[i] +"' ;" ) ;
		foreach( Itemset item in stateset[i].itemset )
			{
			//s.Write( item ) ;
			if( item.rule == i || item.rule == 0 )
				{
				continue ;
				}
			sb.Append(     "  public static readonly char     " ) ;
			string rule = item.rule == 0 ? "_accept" : xo_t[item.rule].lhs.s ;
			string point ;
			if( item.rule == 0 )
				{
				rule = "_accept" ;
				}
			else
				{
				rule = xo_t[item.rule].lhs.s ;
				}
			if( xo_t[item.rule].rhs.Length != item.point )
				{
				point = xo_t[item.rule][item.point].X.ToString() ;
				point += "_" ;
				point += xo_t[item.rule][item.point].Y.ToString() ;
				sb.Append( "" + rule +'_'+ point ) ;
				sb.Append( " = " ) ;
				sb.Append( "global::" + rule +"._"+ xo_t[item.rule][item.point].X.ToString() ) ;
				sb.AppendLine( ".iDNA.C ;" ) ;
				}
			else
				{
				point = xo_t[item.rule][item.point].X.ToString() ;
				sb.Append( "" + rule +'_'+ point ) ;
				sb.Append( " = " ) ;
				sb.Append( "global::" + rule +"._"+ point ) ;
				sb.AppendLine( ".iDNA.C ;" ) ;
				}
			}
		/*
		if( i == (xo_t.Length - 1) )
			sb.AppendLine( "  public override string ToString() { return \"\" + C ; }" ) ;
		else
			sb.AppendLine( "  public override string ToString() { return \"\" + C + global::" + xo_t[i+1].lhs.s + "._" + (i+1) + ".iDNA.ToString() ; }" ) ;
		*/
		if( stateset[i].lookaheadset.Count != 0 )
			{
			sb.Append(     "  public static readonly int[]    LookAhead  = { " ) ;
			foreach( var c in stateset[i].lookaheadset )
				sb.Append( c+", " ) ;
			sb.Remove( sb.Length-2, 2 ) ;
			sb.AppendLine( " } ;" ) ;
			}
		return sb.ToString() ;
		}
	static string _io( int i )
		{
		System.Text.StringBuilder sb = new System.Text.StringBuilder() ;
		int rule = -1 ;
		if( stateset[i].default_reduction.HasValue )
			{
			rule = stateset[i].reductionset[stateset[i].default_reduction.Value].rule ; // 9.9.Post([rule]) ; ...
			sb.AppendLine( "//" + xo_t[rule] ) ;
			}
		sb.AppendLine
			(
			 "  public static void Element( string l )\n"
			+"    {"
			) ;
		foreach( var t in stateset[i].shiftset )
			sb.AppendLine( "//" + stateset[i].transitionset[ t.Value ] ) ;
		foreach( Reduction r in stateset[i].reductionset )
			sb.AppendLine( "//" + r ) ;
		if( stateset[i].gotoset.Count != 0 )
		  sb.AppendLine
			(
			 "    //iDNA.EntityReference( l ) ;\n"
			+"    System.Console.WriteLine(l) ;\n"
//			+"    System.Console.WriteLine(C) ;\n"
			+"    }"
			) ;
		else
		  sb.AppendLine
			(
			 "    //#!\n"
			+"    }"
			) ;
		sb.AppendLine
			(
			 "  public static void EntityReference( string l )\n"
			+"    {"
			) ;
		foreach( var t in stateset[i].gotoset )
			sb.AppendLine( "//" + stateset[i].transitionset[ t.Value ] ) ;
		if( rule != -1 )
		  sb.AppendLine
			(
			 "    switch( l )\n"
			+"      {\n"
			+"      default : "
			        + ( rule == 0 ? "_accept" : xo_t[rule].lhs.s + "._" + xo_t[rule].lhs.X )
			        + ".iDNA.EntityReference(l) ; "
			        + "return ;\n"
			+"      }"
			) ;
		else
		  sb.AppendLine
			(
			 "    System.Console.Write( '.'+l ) ;"
			) ;
		sb.AppendLine
			(
			 "    }\n"
			+"  public static void Text( string l )\n"
			+"    {\n"
			+"    //System.Console.Write( l ) ;\n"
			+"    }"
			) ;
		return sb.ToString() ;
		}
	static readonly char[] entity_trim =  { ';' };
	static public void Build()
		{
		string[] compile = new string[xo_t.Length] ;
		var sw = Current.Path.CreateText( "x-y-text.tab.html" ) ;
		#if iDNA
		var s = Current.Path.CreateText( "auto.cs" ) ;
		compile[0] = "auto.cs" ;
		#endif
		var g = Current.Path.CreateText( "glossary.html" ) ;
		sw.Write( "<head></head><body><table style=\"font: monospace;\">" ) ;
		g.Write( "<head {0}></head><body style=\"color: red ; background: antiquewhite ;\"><table {1}>", "UUID", "ITEMSCOPE" ) ;
		Xo_t n = xo_t[0] ;
		Xo_t xo ;
		#if iDNA
		s.WriteLine( "namespace _accept" ) ;
		s.WriteLine( "{" ) ;
		s.WriteLine( "//await" ) ;
		s.WriteLine( "//awhile" ) ;
		s.WriteLine( "//aaccept" ) ;
		s.WriteLine( "//bookkeeping" ) ; //bookkeeppong
		s.WriteLine( "public partial class A335 {" ) ;
		s.WriteLine( "static A335() {}" ) ;
		s.WriteLine( "#if EMBED" ) ;
		//s.WriteLine( "public static void Main( string[] args ) { System.Console.WriteLine(iDNA.C) ; }" ) ;
		s.WriteLine( "public static void Main( string[] args )" ) ;
		s.WriteLine( "  {" ) ;
		s.WriteLine( "  X.Y.MapZ() ;" ) ;
		s.Write( _.xml_reader() ) ;
		s.WriteLine( "  Current.Interval.NOP() ;" ) ;
		s.WriteLine( "  }" ) ;
		s.WriteLine( "#endif" ) ;
		s.WriteLine( "}" ) ;
		s.WriteLine( "struct iDNA" ) ;
		s.WriteLine( "  {" ) ;
		s.Write( list( 0 ) ) ;
		s.Write( _io( 0 ) ) ;
		s.WriteLine( "  }" ) ;
		s.WriteLine( "public abstract class Auto" ) ;
		s.WriteLine( "{" ) ;
		s.WriteLine( "public abstract string LHS { get; }" ) ;
		s.WriteLine( "public abstract string[] RHS { get; }" ) ;
		s.WriteLine( "}" ) ;
		s.WriteLine( "public class _Auto : Auto" ) ;
		s.WriteLine( "{" ) ;
		s.WriteLine( "public override string LHS { get { return string.Empty ; } }" ) ;
		s.WriteLine( "public override string[] RHS { get { return null ; } }" ) ;
		s.WriteLine( "}" ) ;
		s.WriteLine( "public static class Codex" ) ;
		s.WriteLine( "{" ) ;
		s.WriteLine( "public static Auto Switch( int code )" ) ;
		s.WriteLine( "{" ) ;
		s.WriteLine( "switch( code ) {" ) ;
		for( int i = 1 ; i < xo_t.Length ; i++ )
			{
			xo = xo_t[i] ;
			string filename = xo.lhs.s +"._"+ xo.lhs.X +'.'+ xo.ReductionMethod ;
			compile[i] = filename ;
			s.WriteLine( "case "+i+" : return new {0}() ;", filename ) ;
			}
		s.WriteLine( "default: return new _Auto() ;" ) ;
		s.WriteLine( "}" ) ;
		s.WriteLine( "}" ) ;
		s.WriteLine( "}" ) ;
		s.WriteLine( "}" ) ;
		s.WriteLine( ) ;
		s.Close() ;
		#endif
		#if !XYP
		g.WriteLine( "<tr><th ITEMTYPE>Technique</th><th ITEMPROP>Profile</th><td>C</td><td>ENTITY</td><td>PROTOTYPE</td></tr>" ) ;
		#endif
		for( int i = 1 ; i < xo_t.Length ; i++ )
			{
			xo = xo_t[i] ;
			bool head = n.lhs.s != xo.lhs.s ;
			n = xo ;
			string filename = xo.lhs.s +"._"+ xo.lhs.X +'.'+ xo.ReductionMethod ;
			var f = Current.Path.CreateText( filename ) ;
			#if iDNA
			f.WriteLine( "namespace {0}._{1}", n.lhs.s, n.lhs.X ) ;
			f.WriteLine( "{" ) ;
			#endif
			#if XYP
			if( head )
				g.WriteLine( "<tr><td><h1>" + xo.lhs.X + "</h1></td><td><h1>" + xo.lhs.Y + "</h1></td><td><h1>" + xo.lhs.s + "</h1></td></tr>" ) ;
			else
				g.WriteLine( "<tr><td>" + xo.lhs.X + "</td><td>" + xo.lhs.Y + "</td><td>" + xo.lhs.s + "</td></tr>" ) ;
			#else
			string entity = "&0." + xo.lhs.X + ";" ;
			string prototype = xo.ReductionMethod.Substring( xo.lhs.s.Length ) ;
			if( head )
				{
				g.Write( "<tr><td><h1>" + xo.lhs.X + "." + xo.lhs.Y + "</h1></td><td><h1>" + xo.lhs.s + "</h1></td>" ) ;
				g.Write( "<td>" + (char)xo + "</td>" ) ;
				g.Write( "<td>" + entity + "</td>" ) ;
				g.Write( "<td>" + prototype + "</td>" ) ;
				g.WriteLine( "</tr>" ) ;
				}
			else
				{
				g.Write( "<tr>" ) ;
				g.Write( "<td>" + xo.lhs.X + "." + xo.lhs.Y + "</td>" ) ;
				g.Write( "<td>" + xo.lhs.s + "</td>" ) ;
				g.Write( "<td>" + (char)xo + "</td>" ) ;
				g.Write( "<td>" + entity + "</td>" ) ;
				g.Write( "<td>" + prototype + "</td>" ) ;
				g.Write( "</tr>" ) ;
				}
			#endif
			sw.WriteLine( "<tr><td>" + xo.lhs.X + "</td><td>" + xo.lhs.Y + "</td><td>" + xo.ReductionMethod + "</td></tr>" ) ;
			#if iDNA
			f.WriteLine( "public struct iDNA" ) ;
			f.WriteLine( "  {" ) ;
			//s.WriteLine( "  public const           char     C       = '"+ (char)xo +"' ;" ) ;
			f.Write(     "  public static readonly char[]   Entity  = { " ) ;
			foreach( char c in entity.TrimEnd( entity_trim ) )
				f.Write( "'"+c+"', " ) ;
			f.WriteLine( "'" + entity[entity.Length-1] + "' } ;" ) ;
			f.Write( list( i ) ) ;
			f.Write( _io( i ) ) ;
			f.WriteLine( "  }" ) ;
			f.WriteLine( "public partial class   " + xo.ReductionMethod ) ;
			f.WriteLine( "  : _accept.Auto " ) ;
			f.WriteLine( "  {" ) ;
			f.Write(     "  static readonly char[]   lhs = { " ) ;
			foreach( char c in Rule.Set[i].lhs.s )
				f.Write( "'"+c+"', " ) ;
			f.WriteLine( " } ;" ) ;
			f.WriteLine( "  public override string   LHS { get { return new string(lhs) ; } }" ) ;
			f.WriteLine( "  public override string[] RHS { get { return rhs ; } } ") ;
			f.Write(     "  static readonly string[] rhs = ") ;
			if( Rule.Set[i].rhs.Count > 0 )
				{
				var sb = new System.Text.StringBuilder() ;
				foreach( var rhs in Rule.Set[i].rhs )
					sb.Append("\"" + rhs.s.Replace("\"","\\\"") + "\", " ) ;
				sb.Remove( sb.Length-2, 2 ) ;
				f.Write( "{ " + sb.ToString() + " }" ) ;
				}
			else
				f.Write( "{}" ) ;
			f.WriteLine( " ;" ) ;
			f.WriteLine( "  }" ) ;
			f.WriteLine( "}" ) ;
			f.WriteLine( ) ;
			f.Close() ;
			#endif
			}
		sw.WriteLine( "</table></body>" ) ;
		g.WriteLine( "</table></body>" ) ;
		sw.Close() ;
		#if iDNA
		Cluster.Shell.Embed( compile ) ;
		#endif
		g.Close() ;
		#if POSTBACK
		//[((v8)|v16)[f32|.]v64]|v8sidv64
		var c = Current.Path.CreateText( "entset.csv" ) ;
		foreach( var i in xml_translate )
			{
			//string entity = "&0." + xo.lhs.X + ";" ;
			//string prototype = xo.ReductionMethod.Substring( xo.lhs.s.Length ) ;
			c.WriteLine( "\"&{0}.{1}\",", i.Value, (int)i.Key /* (char)xo, prototype*/ ) ;
			}
		c.Close() ;
		#endif
		}
		public static void OutputGraph()
			{
			//reserved
			///www.stenyak.com/archives/1208/trick-of-the-day-rendering-graphics-in-your-terminal/
			///usr/share/doc/plotutils/tek2plot/dmerc.tek.gz
			}
	}

//static Dictionary<string,Symbol> x_lhs_s = new Dictionary<string, Symbol>() ;
//static Dictionary<string,Symbol> x_rhs_s = new Dictionary<string, Symbol>() ;

static void xml_load_grammar()
	{
	if( xml_loaded )
		return ;
	Stream s = File.OpenRead( "../../~/understand/grammar.xml" ) ;
	xml = new XmlTextReader( new StreamReader( s ) ) ;
	while( xml.Read() )
		if( xml.NodeType == XmlNodeType.Element && xml.Name == "bison-xml-report" )
			break ;
	X x = new X() ;
	while( xml.Read() )
		{
		if( XmlNodeType.Element == xml.NodeType )
			{
			string name = xml.Name ;
			//if( name == "reduction" )
			//	x.reduction() ;
			//else
			if( xml.Name == "solved-conflicts" )
				name = "solved_conflicts" ;
			else
			typeof(X).InvokeMember( name, 
				System.Reflection.BindingFlags.InvokeMethod |
				System.Reflection.BindingFlags.NonPublic,
				null, x, null ) ;
			}
		else
		if( XmlNodeType.EndElement == xml.NodeType )
			{
			if( xml.Name == "state" )
				stateset[(int)x_state] = x_state ;
			if( xml.Name == "rule" )
				x_rule.post() ;
			if( xml.Name == "bison-xml-report" )
				goto xml_end ;
			}
		}
	xml_end:
	xml_loaded = true ;
	}

partial class X //_: YY
	{
	void filename()     {}
	void grammar()      {}
	void rules()        { rules_b = true ; }
	void rule()         { xml_get_rule() ; }
	void lhs()          { xml_get_lhs() ; }
	void rhs()          {}
	void symbol()       { xml_get_symbol(rules_b) ; }
	void empty()        { x_empty_ruleset.Add(x_rule.number) ; }
	void terminals()    { rules_b = false ; }
	void terminal()     { xml_get_terminal() ; }
	void nonterminals() {}
	void nonterminal()  { xml_get_nonterminal() ; }
	void automaton()    { _default = new xml_token( xml_symbolset["$accept"], new xml_s("$default") ) ; }
	void state()        { xml_get_state() ; }
	void itemset()      {}
	void item()         { xml_get_item() ; }
	void actions()      {}
	void transitions()  {}
	void transition()   { xml_get_transition() ; }
	void errors()       {}
	void reductions()   {}
	void reduction()    { xml_get_reduction() ; }
	void lookaheads()   {}
	void solved_conflicts() {}
	bool rules_b = false ;
	}


public struct xml_s
	{
	public string s ;
	public xml_s( string s )
		{
		this.s = s ;
		}
	}

public class xml_t
	{
	public Number  symbol ;
	public char    token ;
	public xml_s   name ;
	public xml_s   usefulness ;
	internal xml_t()
		{
		xml.MoveToFirstAttribute() ;
		symbol = Number.Parse( xml.Value ) ;
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
		symbol = Number.Parse( xml.Value ) ;
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
	public Number       number ;
	public xml_s        lhs ;
	public List<xml_s>  rhs ;
	public xml_s        usefulness ;
	internal void post()
		{
		Rule r = new Rule() ;
		r.lhs = lhs ;
		r.number = number ;
		r.rhs = rhs ;
		r.useful = usefulness.s == "useful" ;
		Xo_t.Add( r ) ;
		Rule.Set[number] = r ;
		//if( ! x_lhs.ContainsKey( lhs.s ) )
		//	x_lhs.Add( lhs.s, null ) ;
		//foreach( xml_s s in rhs ) 
		//	if( ! x_rhs.ContainsKey( s.s ) )
		//		x_rhs.Add( s.s, null ) ;
		}
	public xml_rule()
		{
		xml.MoveToFirstAttribute() ;
		number = Number.Parse( xml.Value ) ;
		rhs = new List<xml_s>() ;
		}
	}

static void xml_get_symbol( bool _rule )
	{
	xml.Read() ;
	if( _rule )
		x_rule.rhs.Add( new xml_s( xml.Value ) ) ;
	else
		{
		x_state.lookaheadset.Add ( (int)xml_tokenset[xml.Value] ) ;
		}
	xml.Read() ;
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
	
static Dictionary<char,int> xml_translate          = new Dictionary<char,int>() ;
static Dictionary<string,xml_token>  xml_tokenset  = new Dictionary<string, xml_token>() ;
static Dictionary<string,xml_symbol> xml_symbolset = new Dictionary<string, xml_symbol>() ;

static xml_token _default ;
static void xml_get_terminal()
	{
	xml_t t = new xml_t() ;
	//Symbol s = new Symbol(t.symbol,t) ;
	//symbol_from_token.Add(t.token, s) ;
	object o = new xml_token( t.token, t.symbol, t.name ) ;
	for( int x = 0 ; x < 603 ; x ++ )
		for( int y = 0 ; y < xo_t[x].rhs.Length ; y++ )
			xo_t[x][y].set_if( t.name, o ) ;
	}
	
static void xml_get_nonterminal()
	{
	xml_nt nt = new xml_nt() ;
	//Symbol s = new Symbol(nt.symbol,nt) ;
	object o = new xml_symbol( nt.symbol, nt.name ) ;
	for( int x = 0 ; x < 603 ; x ++ )
		{
		xo_t[x].lhs.set_if( nt.name, o ) ;
		for( int y = 0 ; y < xo_t[x].rhs.Length ; y++ )
			xo_t[x][y].set_if( nt.name, o ) ;
		}
	}

static State x_state ;
static void xml_get_state()
	{
	xml.MoveToFirstAttribute() ;
	x_state.debit = Number.Parse( xml.Value ) ;
	x_state.transitionset = new Transition[0] ;
	x_state.shiftset = new Dictionary<int,int>() ;
	x_state.gotoset = new Dictionary<int,int>() ;
	x_state.itemset = new Itemset[0] ;
	x_state.reductionset = new Reduction[0] ;
	x_state.lookaheadset = new List<int>() ;
	x_state.default_item = null ;
	x_state.default_reduction = null ;
	}

static void xml_get_item()
	{
	Itemset i = new Itemset() ;
	xml.MoveToFirstAttribute() ;
	i.rule = Number.Parse( xml.Value ) ;
	xml.MoveToNextAttribute() ;
	i.point = Number.Parse( xml.Value ) ;
	System.Array.Resize(ref x_state.itemset, x_state.itemset.Length + 1 ) ;
	x_state.itemset[ x_state.itemset.Length - 1 ] = i ;
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
	xml.MoveToNextAttribute() ;
	t.state = Number.Parse( xml.Value );
	foreach( Itemset i in x_state.itemset )
		if( t.symbol == (int)i )
			{
			t.item = i ;
			break ;
			}
	System.Array.Resize(ref x_state.transitionset,  x_state.transitionset.Length + 1 ) ;
	x_state.transitionset[  x_state.transitionset.Length - 1 ] = t ;
	if( t.type == "shift" )
		{
		x_state.shiftset.Add( t.symbol, x_state.transitionset.Length - 1 ) ;
		}
	else
		{
		x_state.gotoset.Add( t.symbol, x_state.transitionset.Length - 1 ) ;
		}
	}

static void xml_get_reduction()
	{
	Reduction r = new Reduction() ;
	xml.MoveToFirstAttribute() ;
	r.symbol = xml_tokenset[ xml.Value ] ;
	xml.MoveToNextAttribute() ;
	if( xml.Value != "accept" )
		r.rule = Number.Parse( xml.Value ) ;
	xml.MoveToNextAttribute() ;
	r.enabled = bool.Parse( xml.Value ) ;
	foreach( Itemset i in x_state.itemset )
		if( r.symbol == (int)i )
			{
			r.item = i ;
			break ;
			}
	if( r.symbol == _default )
		{
		x_state.default_reduction = x_state.reductionset.Length ;
		for( int x = 0 ; x < x_state.itemset.Length ; x++ )
			if( (Xo)x_state.itemset[x] == (Xo)r )
				{
				r.item = x_state.itemset[x] ;
				x_state.default_item = x ;
				break ;
				}
		}
	System.Array.Resize(ref  x_state.reductionset,  x_state.reductionset.Length + 1 ) ;
	x_state.reductionset[  x_state.reductionset.Length - 1 ] = r ;
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


static bool xml_get_()
	{
	if( xml.Read() && xml.NodeType == XmlNodeType.Element )
		{
		//status = true ;
		//state++ ;
		if( xml.Name[0] == '_' ) 
			{
			string [] s = xml.Name.Split("_-".ToCharArray()) ;
			yytoken = symbol_from_token[ int.Parse( s[1] ) ];
			yystate = stateset[ int.Parse( s[2] ) ] ;
			xml.Read() ;
			xml_text = xml.Value ;
			//yyrule = resolve() ;
			//stack.Push( symbol_from_token[yytoken] ) ;
			//System.Console.WriteLine("<{0}/>{2}", yyrule,yytoken,xml_text) ;
			//Console.WriteLine("{0} {1} {2}", yytoken, text, yyrule.lhs) ;
			return true ;
			}
		}
	//if( ! xml.EOF )
	//	throw new Exception() ;
	//xml_element = null ;
	xml_text    = null ;
	//status  = false ;
	//state   = 0; //int.MaxValue ;s
	return false ;
	}
}
