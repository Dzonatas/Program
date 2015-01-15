using System.Xml ;
using System.IO ;
using System.Extensions ;

public partial class A335
{

static XmlTextReader   xml ;
static string          xml_text ;
static bool            xml_loaded ;
static Number[]        x_empty_ruleset = new Number[0] ;
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
		int y = r.rhs.Length ;
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
	static public implicit operator Number( Xo_t x )
		{
		return x.lhs.Rule ;
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
		X.Auto["glyph"] = string.Format( "\\u{0:X4}", System.Convert.ToInt16( (char)xo_t[i] ) ) ;
		sb.Append( put("A335-Xo_t-list-top") ) ;
		foreach( Itemset item in stateset[i].Itemset )
			{
			if( item.rule == i || item.rule == 0 )
				continue ;
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
				X.Auto["global"] = "global::" + rule +"._"
					+ xo_t[item.rule][item.point].X.ToString()
					+ ".iDNA.C" ;
				}
			else
				{
				point = xo_t[item.rule][item.point].X.ToString() ;
				X.Auto["global"] = "global::"+rule+"._"+point+".iDNA.C" ;
				}
			X.Auto["rule"] = rule ;
			X.Auto["point"] = point ;
			sb.Append( put("A335-Xo_t-list") ) ;
			}
		return sb.ToString() ;
		}
	static string _io( int i )
		{
		string rule = "(-__default)" ;
		bool lookahead_volatile = stateset[i].Lookaheadset.Length == 0 ;
		bool shiftset_volatile  = stateset[i].Shiftset.GetLength(0) == 0 ;
		bool volatile_b         = lookahead_volatile && shiftset_volatile ;
		bool reduction_volatile = stateset[i].Reductionset.GetLength(0) == 0 ;
		bool gotoset_volatile   = stateset[i].Gotoset.GetLength(0) == 0 ;
		bool transit_volatile   = stateset[i].Transitionset.Length == 0 ;
		X.Auto["typeset"]   = "" ;
		X.Auto["symbolset"] = "" ;
		X.Auto["stateset"]  = "" ;
		X.Auto["ruleset"]   = "" ;
		X.Auto["pointset"]  = "" ;
		X.Auto["lookaheadset"]  = "" ;
		if( stateset[i].Default_reduction.HasValue )
			rule = stateset[i].Reductionset[stateset[i].Default_reduction.Value].rule.ToString() ;
		foreach( Transition t in stateset[i].Transitionset )
			{
			X.Auto["typeset"]   += '"'+t.type+'"'+", " ;
			X.Auto["symbolset"] += t.symbol+", " ;
			X.Auto["stateset"]  += t.state+", " ;
			X.Auto["ruleset"]   += t.item.rule+", " ;
			X.Auto["pointset"]  += t.item.point+", " ;
			}
		foreach( int z in stateset[i].Lookaheadset )
			X.Auto["lookaheadset"]  += z+", " ;
		X.Auto["typeset"]   = (X.Auto["typeset"]  =="") ? "new string[0]" : "new string[] { "+X.Auto["typeset"]+" }" ;
		X.Auto["symbolset"] = (X.Auto["symbolset"]=="") ? "new int[0]" : "new int[] { "+X.Auto["symbolset"]+" }" ;
		X.Auto["stateset"]  = (X.Auto["stateset"] =="") ? "new int[0]" : "new int[] { "+X.Auto["stateset"]+" }" ;
		X.Auto["ruleset"]   = (X.Auto["ruleset"]  =="") ? "new int[0]" : "new int[] { "+X.Auto["ruleset"]+" }" ;
		X.Auto["pointset"]  = (X.Auto["pointset"] =="") ? "new int[0]" : "new int[] { "+X.Auto["pointset"]+" }" ;
		string[] ss = new string[stateset[i].Reductionset.Length] ;
		int zz = 0 ;
		string tab = "\t\t\t" ;
		foreach( Reduction r in stateset[i].Reductionset )
			ss[zz++] = "{ "+r.symbol+", "+r.rule+", "+(r.enabled?'1':'0')+", "+r.item.rule+", "+r.item.point+" }" ;
		if( zz == 0 )
			X.Auto["reductionset"] = "new int[0,0]" ;
		else
		if( zz < 2 )
			X.Auto["reductionset"] = "new int[,] { "+string.Concat(ss)+" }" ;
		else
			X.Auto["reductionset"] = "new int[,]\n"+tab+"{\n"+tab+string.Join(",\n"+tab,ss)+"\n"+tab+"}" ;
		string list = "" ;
		if( stateset[i].Lookaheadset.Length == 1 )
			list += "if( token.point == "+stateset[i].Lookaheadset[0]+" ) return true ;\n\t\t" ;
		else
		if( stateset[i].Lookaheadset.Length > 0 )
			{
			list += "if( " ;
			int z ;
			for( z = 0 ; z < stateset[i].Lookaheadset.Length-1 ; z++ )
				list += "token.point == "+stateset[i].Lookaheadset[z]+" || " ;
			list += "token.point == "+stateset[i].Lookaheadset[z]+" ) return true ;\n\t\t" ;
			}
		string list_v = "" ;
		string lookahead = "" ;
		if( list.Length != 0 )
			{
			X.Auto["list"] = list + "return false ;" ;
			lookahead = put("A335-Xo_t-_io-1-lookaheadset") ;
			list_v += "a.lookahead_b = lookahead_"+i+"() ;\n\t" ;
			}
		list = "" ;
		for( int z = 0 ; z < stateset[i].Shiftset.GetLength(0) ; z++ )
			{
			int x = stateset[i].Shiftset[z,0] ;
			int y = stateset[i].Shiftset[z,1] ;
			list += "if( token.point == "+x+" ) return "+z+" ;\n\t\t" ;
			if( z < (stateset[i].Shiftset.GetLength(0)-1) )
				list += "else\n\t\t" ;
			}
		string shiftset = "" ;
		if( list.Length == 0 )
			list_v += "a.shiftset_i = 0 ;\n\t" ;
		else
			{
			list_v += "a.shiftset_i = shiftset_"+i+"() ;\n\t" ;
			X.Auto["list"] = list + "return "+stateset[i].Shiftset.GetLength(0)+" ;" ;
			shiftset = put("A335-Xo_t-_io-1-shiftset") ;
			}
		list = "" ;
		string reductionset = "" ;
		if( ! reduction_volatile )
			{
			for( int z = 0 ; z < stateset[i].Reductionset.Length ; z++ )
				{
				Reduction r = stateset[i].Reductionset[z] ;
				if( ! r.enabled )
					continue ;
				if( r.symbol == _default )
					continue ;
				list += "if( yy == "+r.symbol+" ) return "+stateset[i].Reductionset[z].rule+" ;\n\t\t" ;
				}
			if( list.Length != 0 )
				{
				X.Auto["list"] = list + "return "+rule+" ;" ;
				reductionset = put("A335-Xo_t-_io-1-reductionset") ;
				}
			}
		list = "" ;
		string gotoset = "" ;
		for( int z = 0 ; z < stateset[i].Gotoset.GetLength(0) ; z++ )
			list += "if( yy == "+stateset[i].Gotoset[z,0]+" ) return "+stateset[i].Gotoset[z,1]+" ;\n\t\t" ;
		if( list.Length != 0 )
			{
			X.Auto["list"] = list + "return __default ;" ;
			gotoset = put("A335-Xo_t-_io-1-gotoset") ;
			}
		list = "" ;
		if( ! transit_volatile )
			{
			list += "a.stateset      = "+X.Auto["stateset"]+" ;\n\t" ;
			list += "a.ruleset       = "+X.Auto["ruleset"]+" ;\n\t" ;
			list += "a.pointset      = "+X.Auto["pointset"]+" ;\n\t" ;
			}
		if( volatile_b )
			list += "a.volatile_b = true ;\n\t" ;
		else
			list += list_v ;
		if( reduction_volatile )
			{
			list += "a.reduction_v    = true ;\n\t" ;
			list += "a.rule           = "+rule+" ;\n\t" ;
			}
		else
			{
			list += "a.rule            = "+rule+" ;\n\t" ;
			if( reductionset.Length == 0 )
				list += "a.reduction_v     = true ;\n\t" ;
			else
				list += "a.reductionset_s  = reductionset_"+i+" ;\n\t" ;
			}
		if( gotoset_volatile )
			list += "a.goto_v = true ;\n\t" ;
		else
			{
			list += "a.gotoset_s     = gotoset_"+i+" ;\n\t" ;
			}
		list += "return ;" ;
		X.Auto["list"] = list ;
		string sets = lookahead + shiftset + reductionset + gotoset ;
		if( i == 0 || i >= xo_t.Length )
			return put("A335-Xo_t-_io-1")+sets ;
		X.Auto["namespace"] = xo_t[i].lhs.s + "._" + xo_t[i].lhs.X ;
		X.Auto["signal"]    = X.Auto[ "_"+xo_t[i].lhs.X ] ;
		return put("A335-Xo_t-_io-_1")+put("A335-Xo_t-_io-1")+sets ;
		}
	public static string put( string s )
		{
		var sxml = "<text>"+X.Auto[s]+"</text>" ;
		var xml = new XmlTextReader( new StringReader( sxml ) ) ;
		read( xml ) ;
		return X.Auto["text"] ;
		}
	static readonly char[] trimchar = { '\n','\r'} ;
	static bool resolve = false ;
	static void read( StreamReader sr )
		{
		resolve = false ;
		read( new XmlTextReader( sr ) ) ;
		}
	static void read( XmlReader xml )
		{
		bool content = false ;
		string text  = "" ;
		while( xml.Read() )
			{
			if( XmlNodeType.Element == xml.NodeType )
				{
				if( xml.Name == "auto" )
					continue ;
				content = true ;
				if( ! resolve )
					{
					text = xml.Name ;
					xml.MoveToContent() ;
					X.Auto[text] = xml.ReadInnerXml().TrimStart(trimchar) ;
					}
				}
			else
			if( content && XmlNodeType.EntityReference == xml.NodeType )
				{
				bool nul = false ;
				try { nul = X.Auto[xml.Name] == null ; }
				catch( System.Collections.Generic.KeyNotFoundException eh )
					{
					if( Cluster.Parameter.Value( xml.Name ) == "false" )
						System.Console.WriteLine( "Program: eh( &"+xml.Name+"; )" ) ;
					else
						X.Auto[xml.Name] = Cluster.Parameter.Value( xml.Name ) ;
					}
				if( nul )
					text += '&'+xml.Name+';' ;
				else
					text += X.Auto[xml.Name] ;
				}
			else
			if( content && XmlNodeType.EndElement == xml.NodeType )
				{
				if( xml.Name == "text" )
					X.Auto[xml.Name] = text ;
				else
				if( xml.Name != "auto" )
					X.Auto.Add(xml.Name, text ) ;
				content = false ;
				text = "" ;
				}
			else
			if( content )
				{
				text += xml.Value ;
				}
			}
		resolve = true ;
		}
	static readonly char[] entity_trim =  { ';' };
	static string[] compile = new string[xo_t.Length] ;
	static public void Compile()
		{
		if( Cluster.Parameter.Value("build") == "false" )
			return ;
		compile[0] = "auto.cs" ;
		Xo_t xo ;
		read( new StreamReader( "../../#/Auto.xml" ) ) ;
		read( new StreamReader( "../../#/Addendum.xml" ) ) ;
		Cluster.Cli.NoOperation() ;
		var st = Current.Path.CreateText( "Automaton.2.cs" ) ;
		st.Write("partial class Automaton {\nstatic int[] xo_t =\n\t{\n\t") ;
		for( int z = 0 ; z < xo_t.Length ; z++ )
			{
			st.Write( "{0}\t, ", (int)xo_t[z] ) ;
			if( z%10 == 9 )
				st.Write( "\n\t" ) ;
			}
		st.WriteLine( "} ;" ) ;
		st.WriteLine( "}" ) ;
		st.Close() ;
		var sl = Current.Path.CreateText( "Automaton.3.cs" ) ;
		sl.Write("partial class Automaton {\nstatic int[] xo_l =\n\t{\n\t") ;
		for( int z = 0 ; z < xo_t.Length ; z++ )
			{
			sl.Write( "{0}\t, ", xo_t[z].rhs.Length ) ;
			if( z%10 == 9 )
				sl.Write( "\n\t" ) ;
			}
		sl.WriteLine( "} ;" ) ;
		sl.WriteLine( "}" ) ;
		sl.Close() ;
		X.Auto["branch"] = branch ;
		var ss = Current.Path.CreateText( "Automaton.4.cs" ) ;
		ss.Write("partial class Automaton {\nstatic System.Action<Automaton>[] xo_a =\n\t{\n\t") ;
		for( int z = 0 ; z < stateset.Length ; z++ )
			{
			ss.Write( "_{0}\t, ", z ) ;
			if( z%10 == 9 )
				ss.Write( "\n\t" ) ;
			}
		ss.WriteLine( "} ;" ) ;
		ss.WriteLine( "}" ) ;
		ss.Close() ;
		X.Auto["list"] = list( 0 ) ;
		var f = Current.Path.CreateText( compile[0] ) ;
		string filename = "" ;
		f.Write( put("A335-Xo_t-Build-0") ) ;
		for( int i = 1 ; i < xo_t.Length ; i++ )
			{
			xo = xo_t[i] ;
			X.Auto["_"+xo.lhs.X] = X.Auto["_"+xo.lhs.X].TrimEnd() ;
			compile[i] = xo.lhs.s +".cs" ;
			}
		f.WriteLine( ) ;
		X.Auto["rule"] = ((int)_default).ToString() ;
		f.Write( put("A335-Xo_t-_io-0") ) ;
		for( int i = 0 ; i < stateset.Length ; i++ )
			{
			X.Auto["point"] = "_"+i.ToString() ;
			f.Write( _io( i ) ) ;
			}
		f.Write( put("A335-Xo_t-_io-2") ) ;
		for( int i = 1 ; i < xo_t.Length ; i++ )
			{
			xo = xo_t[i] ;
			if( compile[i-1] != compile[i] )
				{
				f.Close() ;
				f = Current.Path.CreateText( compile[i] ) ;
				X.Auto["interface"] = xo.lhs.s ;
				X.Auto["i"] = "" ;
				f.Write( put("A335-Xo_t-Build-iDNA-5i") ) ;
				}
			X.Auto["interface"] = "global::Item, basic."+xo.lhs.s ;
			string reduction = put("_"+xo.lhs.X ) ;
			string entity = "&0." + xo.lhs.X + ";" ;
			string prototype = reduction.Substring( xo.lhs.s.Length ) ;
			X.Auto["namespace"] = xo.lhs.s + "._" + xo.lhs.X ;
			X.Auto["Entity"] = "{ " ;
			foreach( char c in entity.TrimEnd( entity_trim ) )
				X.Auto["Entity"] += "'"+c+"', " ;
			X.Auto["Entity"] += "'" + entity[entity.Length-1] + "' }" ;
			X.Auto["list"] = list( i ) ;
			X.Auto["signal"] = reduction ;
			X.Auto["lhs"] = "{ " ;
			foreach( char c in Rule.Set[i].lhs.s )
				X.Auto["lhs"] += "'"+c+"', " ;
			X.Auto["lhs"] += " }" ;
			X.Auto["synopsis"] = "; }" ;
			if( Rule.Set[i].rhs.Length > 0 )
				{
				var sb = new System.Text.StringBuilder() ;
				foreach( var rhs in Rule.Set[i].rhs )
					sb.Append("\"" + rhs.s.Replace("\"","\\\"") + "\", " ) ;
				sb.Remove( sb.Length-2, 2 ) ;
				X.Auto["rhs"] = "{ " + sb.ToString() + " }" ;
				}
			else
				X.Auto["rhs"] = "{}" ;
			f.Write( put("A335-Xo_t-Build-iDNA-5") ) ;
			f.WriteLine( ) ;
			}
		f.Close() ;
		}
	static public void Build()
		{
		string infrastruct = Cluster.Shell.Embed( compile ) ;
		string linkset = "" ;
		for( int i = 1 ; i < xo_t.Length ; i++ )
			{
			if( xo_t[i].rhs.Length == 0 )
				continue ;
			if( xo_t[i].rhs[0].s[0] != '"' || xo_t[i].rhs[0].s[1] != '.' || xo_t[i].rhs[0].s[2] == '.' )
				continue ;
			linkset += Current.Path.Entry( "." + i + ".exe" ) + " " ;
			}
		Cluster.Cli.Relink( infrastruct, linkset ) ;
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
	xml = new XmlTextReader( new StreamReader( "../../~/understand/grammar.xml" ) ) ;
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
	}

partial class X //_: YY
	{
	public static readonly System.Collections.Generic.Dictionary<string,string> Auto = new System.Collections.Generic.Dictionary<string,string>()
		{
		{ "branch",     null },
		{ "Entity",     null },
		{ "list",       null },
		{ "argv",       null },
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
		{ "stateset",   null },
		{ "symbolset",  null },
		{ "typeset",    null },
		{ "ruleset",    null },
		{ "pointset",   null },
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
		{ "empty",        () => { System.Array.Resize( ref x_empty_ruleset, x_empty_ruleset.Length+1 ) ; x_empty_ruleset[x_empty_ruleset.Length-1] = x_rule.number ; } },
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
	public xml_s[]      rhs ;
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
		}
	else
		{
		x_state.Lookaheadset_Add ( (int)xml_tokenset[xml.Value] ) ;
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
	
public static System.Collections.Generic.Dictionary<char,int> xml_translate          = new System.Collections.Generic.Dictionary<char,int>() ;
static System.Collections.Generic.Dictionary<string,xml_token>  xml_tokenset  = new System.Collections.Generic.Dictionary<string, xml_token>() ;
static System.Collections.Generic.Dictionary<string,xml_symbol> xml_symbolset = new System.Collections.Generic.Dictionary<string, xml_symbol>() ;

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
	x_state.Number = Number.Parse( xml.Value ) ;
	}

static void xml_get_item()
	{
	Itemset i = new Itemset() ;
	xml.MoveToFirstAttribute() ;
	i.rule = Number.Parse( xml.Value ) ;
	xml.MoveToNextAttribute() ;
	i.point = Number.Parse( xml.Value ) ;
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
	xml.MoveToNextAttribute() ;
	t.state = Number.Parse( xml.Value );
	foreach( Itemset i in x_state.Itemset )
		if( t.symbol == (int)i )
			{
			t.item = i ;
			break ;
			}
	x_state.Append( t ) ;
	if( t.type == "shift" )
		x_state.Shiftset_Add( t.symbol, x_state.Transitionset.Length - 1 ) ;
	else
		x_state.Gotoset_Add( t.symbol, x_state.Transitionset.Length - 1 ) ;
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
	foreach( Itemset i in x_state.Itemset )
		if( r.symbol == (int)i )
			{
			r.item = i ;
			break ;
			}
	if( r.symbol == _default )
		{
		x_state.Default_reduction = x_state.Reductionset.Length ;
		for( int x = 0 ; x < x_state.Itemset.Length ; x++ )
			if( (Xo)x_state.Itemset[x] == (Xo)r )
				{
				r.item = x_state.Itemset[x] ;
				x_state.Default_item = x ;
				break ;
				}
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
