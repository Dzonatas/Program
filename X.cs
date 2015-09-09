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
	public Rule Rule
		{
		get { return Rule.Set[x] ; }
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
	static public implicit operator Xo( Xo_t x )
		{
		return x.lhs ;
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
	static int tabs_i ;
	static int tabs
		{
		get { return tabs_i ; }
		set { tabs_i = value ; tab = "\n" ; for( uint i = 0 ; i < tabs_i ; i++ ) tab += "\t" ; }
		}
	static string tab ;
	static string _io( int i )
		{
		string rule = "__default" ;
		bool lookahead_volatile = stateset[i].Lookaheadset.Length == 0 ;
		bool shiftset_volatile  = stateset[i].Shiftset.GetLength(0) == 0 ;
		bool volatile_b         = lookahead_volatile && shiftset_volatile ;
		bool reduction_volatile = stateset[i].Reductionset.GetLength(0) == 0 ;
		bool gotoset_volatile   = stateset[i].Gotoset.GetLength(0) == 0 ;
		bool transit_volatile   = stateset[i].Transitionset.Length == 0 ;
		bool default_volatile   = stateset[i].Default_reduction.HasValue == false
			|| stateset[i].Reductionset.GetLength(0) == 1 ;
		bool empty_token = volatile_b && default_volatile && gotoset_volatile ;
		bool io_volatile = stateset[i].FromStates.Length == 1 && empty_token ;
		//bool tab_b = tabs_i != 1 ;
		string _a = tabs_i == 1 ? "a" : "aa" ;
		string _rule = rule ;
		bool _rule_b = true ;
		if( stateset[i].Default_reduction.HasValue )
			{
			string r = stateset[i].Reductionset[stateset[i].Default_reduction.Value].rule.ToString() ;
			rule = '-'+r ;
			_rule = "__"+r+"()" ;
			_rule_b = false ;
			}
		bool _rule_bbb = false ;
		if( reduction_rule( i ) )
			{
			_rule   = "reductionset_"+i+"( token.point )" ;
			_rule_b = false ;
			_rule_bbb = true ;
			}
		string list = "" ;
		/*
		if( tab_b )
			{
			tabs++ ;
			list += "() =>"+tab ;
			list += "{"+tab ;
			}
		*/
		if( ! empty_token )
			list += "Automaton "+_a+" = new Automaton() ;" + tab ;
		if( ! gotoset_volatile )
			{
			tabs++ ;
			list += _a+".gotoset_s = (_yy) =>"+tab ;
			list += "{"+tab ;
			list += gotoset_list( i, _a )+tab ;
			tabs-- ;
			list += "} ;"+tab ;
			}
		if( lookahead_volatile == false || stateset[i].Shiftset.GetLength(0) > 2 )
			{
			tabs++ ;
			list += "switch( token.point )"+tab ;
			list += "{"+tab ;
			}
		if( ! lookahead_volatile )
			{
			list += lookahead_list( i ) + tab ;
			if( rule == "__default" )
				throw new System.NotImplementedException("Default condition on lookahead") ;
			else
				{
				if( ! io_volatile )
					{
					tabs++ ;
					list += "if( token_HasValue )"+tab ;
					tabs-- ;
					list += _a+"._token = Tokenset.Empty ;"+tab ;
					}
				}
			if( volatile_b == false || shiftset_volatile == false )
				{
				list += "goto _"+i+"_default ;" + tab ;
				}
			list += reductionset_case( i, _a ) ;
			}
		if( ! shiftset_volatile )
			list += shiftset_list( i, _a ) ;
		if( lookahead_volatile == false || stateset[i].Shiftset.GetLength(0) > 2 )
			{
			tabs-- ;
			list += "}"+tab ;
			}
		if( lookahead_volatile == false && ( volatile_b == false || shiftset_volatile == false ) )
			{
			list += "_"+i+"_default:" + tab ;
			}
		if( rule != "__default" && volatile_b )
			{
			if( ! empty_token )
				{
				tabs++ ;
				list += "if( token_HasValue )"+tab ;
				tabs-- ;
				list += _a+"._token = Tokenset.Empty ;"+tab ;
				}
			return_rule( i, rule, ref list, _a ) ;
			}
		else
		if( rule != "__default" )
			{
			return_rule( i, rule, ref list, _a ) ;
			}
		else
			{
			list += "throw new System.NotImplementedException() ;" ;
			}
		/*
		if( tab_b )
			{
			list += tab ;
			tabs-- ;
			list += "} ;" ;
			return list ;
			}
		*/
		return
			( "static int _" + i.ToString() + "()"+tab
			+ "{" + tab
			+ "log(\"_" + i.ToString() + "\") ;" + tab
			+ list + tab
			+ "}\n"
			) ;
		}
	static int backup ;
	static int yy ;
	static string __point( string _a, string rule )
		{
		if( rule == "__default" )
			throw new System.NotImplementedException("default rule index") ;
		int r = -int.Parse(rule) ;
		backup = Rule.Set[r].rhs.Length ;
		yy = Rule.Set[r].Symbol ;
		string list = "" ;
		if( r > 0 ) //Target0: xyzzyy tail or mantissa.
			list += "auto = new " + Rule.Set[r].Signal + "() ;" + tab ;
		if( backup > 0 )
			{
			list += "backup = " + backup + " ;" + tab ;
			list += "yy = " + yy + " ;" + tab ;
			}
		return list  ;
		}
	static bool reduction_rule( int i )
		{
		bool lookahead_volatile = stateset[i].Lookaheadset.Length == 0 ;
		bool shiftset_volatile  = stateset[i].Shiftset.GetLength(0) == 0 ;
		bool volatile_b         = lookahead_volatile && shiftset_volatile ;
		if( volatile_b )
			return false ;
		for( int z = 0 ; z < stateset[i].Reductionset.Length ; z++ )
			{
			Reduction r = stateset[i].Reductionset[z] ;
			if( ! r.enabled )
				continue ;
			if( r.symbol == _default )
				continue ;
			if( ! volatile_b )
				return true ;
			break ;
			}
		return false ;
		}
	static bool return_rule( int i, string rule, ref string list, string _a )
		{
		bool lookahead_volatile = stateset[i].Lookaheadset.Length == 0 ;
		bool shiftset_volatile  = stateset[i].Shiftset.GetLength(0) == 0 ;
		bool volatile_b         = lookahead_volatile && shiftset_volatile ;
		bool gotoset_volatile   = stateset[i].Gotoset.GetLength(0) == 0 ;
		int l = stateset[i].Gotoset.GetLength(0) ;
		int r = -int.Parse(rule) ;
		if( ( gotoset_volatile && stateset[i].Default_reduction.HasValue )
			|| reduction_rule( i ) )
			{
			list += reductionset_list(i,_a) ;
			return true ;
			}
		else
		if( l != 0 )
			{
			int x = Rule.Set[r].Symbol ;
			for( int z = 0 ; z < l ; z++ )
				{
				Transition t = stateset[i].Transitionset[ stateset[i].Gotoset[z,1] ] ;
				if( t.symbol == x )
					{
					if( gotoset_volatile )
						list += "return "+_a+".split( _"+t.state+"() ) ;" ;
					else
						list += "return "+_a+".deploy( _"+t.state+"() ) ;" ;
					return true ;
					}
				}
			}
		list += __point( _a, rule ) ;
		list += "return "+rule+" ;" ;
		return true ;
		}
	static string lookahead_list( int i )
		{
		string list = "" ;
		for( int z = 0 ; z < stateset[i].Lookaheadset.Length ; z++ )
			{
			bool reduction = false ;
			foreach( Reduction r in stateset[i].Reductionset )
				{
				//if( ! r.enabled )
				//	continue ;
				if( r.symbol != stateset[i].Lookaheadset[z] )
					continue ;
				reduction = true ;
				break ;
				}
			string t = ( ( z%8 == 7 && z != stateset[i].Lookaheadset.Length-1 ) ? tab : " " ) ;
			if( reduction )
				list += "/* case "+stateset[i].Lookaheadset[z]+": */" + t ;
			else
				list += "case "+stateset[i].Lookaheadset[z]+":" + t ;
			}
		return list ;
		}
	static string shiftset_list( int i, string _a )
		{
		bool lookahead_volatile = stateset[i].Lookaheadset.Length == 0 ;
		bool gotoset_volatile   = stateset[i].Gotoset.GetLength(0) == 0 ;
		bool switch_b = stateset[i].Shiftset.GetLength(0) > 2 || ! lookahead_volatile ;
		string list = "" ;
		for( int z = 0 ; z < stateset[i].Shiftset.GetLength(0) ; z++ )
			{
			Transition  t = stateset[i].Transitionset[ stateset[i].Shiftset[z,1] ] ;
			if( switch_b )
				list += "case "+(string)t.item+": " ;
			else
				list += "if( token.point == "+(string)t.item+" ) { " ;
			list += _a+".shift() ; " ;
			if( gotoset_volatile )
				list += "return "+_a+".split( _"+t.state+"() ) ;" ;
			else
				list += "return "+_a+".deploy( _"+t.state+"() ) ;" ;
			if( switch_b )
				list += tab ;
			else
			if( z < (stateset[i].Shiftset.GetLength(0)-1) )
				list += " }"+tab+"else"+tab ;
			else
				list += " }"+tab ;
			}
		return list ;
		}
	static string reductionset_list( int i, string _a )
		{
		string list = string.Empty ;
		if( stateset[i].Gotoset.GetLength(0) != 0 )
			{
			int rule = stateset[i].Reductionset[stateset[i].Default_reduction.Value].rule ;
			list += __point( _a, '-'+rule.ToString() ) ;
			list += gotoset_s( i, Rule.Set[rule].Symbol, _a ) ;
			}
		else
			{
			int rule = stateset[i].Reductionset[stateset[i].Default_reduction.Value].rule ;
			list += __point( _a, '-'+rule.ToString() ) ;
			list += "return -"+rule+" ;" ;
			}
		return list ;
		}
	static string reductionset_case( int i, string _a )
		{
		string list = "" ;
		for( int z = 0 ; z < stateset[i].Reductionset.Length ; z++ )
			{
			Reduction r = stateset[i].Reductionset[z] ;
			if( ! r.enabled )
				continue ;
			if( r.symbol == _default )
				continue ;
			tabs++ ;
			list += "case "+r.symbol+": "+tab ;
			int rule = stateset[i].Reductionset[z].rule ;
			if( stateset[i].Gotoset.GetLength(0) == 0 )
				{
				list += "{" + tab ;
				list += __point( _a, '-'+rule.ToString() ) ;
				list += "return -"+rule+" ;"+tab ;
				tabs-- ;
				list += "}" + tab ;
				}
			else
				{
				list += "{"+tab ;
				list += __point( _a, '-'+rule.ToString() ) ;
				list += gotoset_s( i, Rule.Set[rule].Symbol, _a )+tab ;
				tabs-- ;
				list += "}"+tab ;
				}
			}
		return list ;
		}
	struct transtruct
		{
		public Transition t ;
		public int        index ;
		public bool       valued ;
		public transtruct( Transition t, int index )
			{
			this.t = t ;
			this.index = index ;
			this.valued = true ;
			}
		}
	static string gotoset_list( int i, string _a )
		{
		string list = "" ;
		string gotoset = "" ;
		int size = stateset[i].Gotoset.GetLength(0) ;
		int min = int.MaxValue;
		int max = int.MinValue;
		for( int j = 0 ; j < size ; j++ )
			{
			Transition  t = stateset[i].Transitionset[ stateset[i].Gotoset[j,1] ] ;
			if( t.symbol > max ) max = t.symbol ;
			if( t.symbol < min ) min = t.symbol ;
			}
		int length = 1+max-min ;
		transtruct[] ary = new transtruct[1+max-min] ;
		for( int j = 0 ; j < size ; j++ )
			{
			Transition  t = stateset[i].Transitionset[ stateset[i].Gotoset[j,1] ] ;
			ary[t.symbol-min] = new transtruct( t, j ) ;
			}
		tabs++ ;
		list += "switch(_yy) // size="+size+" min="+min+" max="+max+" length="+(1+max-min).ToString()+tab ;
		list += "{"+tab ;
		for( int j = 0 ; j < ary.Length ; j++ )
			{
			if( ary[j].valued )
				{
				tabs++ ;
				list += "case "+(string)ary[j].t.item+" :" ;
				list += gotoset_list( i, ary[j].index, _a ) ;
				tabs-- ;
				list += tab ;
				}
			}
		list += "default: return __default ;"+tab ;
		tabs-- ;
		list += "}" ;
		return list ;
		}
	static string gotoset_list( int i, int zi, string _a )
		{
		string list = string.Empty ;
		Transition  t = stateset[i].Transitionset[ stateset[i].Gotoset[zi,1] ] ;
		list += " return _"+t.state+"() ;" ;
		return list ;
		}
	static string gotoset_s( int i, int symbol, string _a )
		{
		string list = string.Empty ;
		for( int zi = 0 ; zi < stateset[i].Gotoset.GetLength(0) ; zi++ )
			{
			Transition  t = stateset[i].Transitionset[ stateset[i].Gotoset[zi,1] ] ;
			if( t.symbol != symbol )
				continue ;
			list += "return "+_a+".deploy( _"+t.state+"() ) ;" ;
			return list ;
			}
		list += "return __default ; //oo" ;
		return list ;
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
	static string[] compile = new string[] { "auto.cs" } ;
	static public void Compile()
		{
		if( Cluster.Parameter.Value("build") == "false" )
			return ;
		read( new StreamReader( "../../#/Auto.xml" ) ) ;
		Cluster.Cli.NoOperation() ;
		X.Auto["branch"] = branch ;
		var f = Current.Path.CreateText( compile[0] ) ;
		f.Write( put("A335-Xo_t-Build-0") ) ;
		f.WriteLine( ) ;
		X.Auto["rule"] = ((int)_default).ToString() ;
		X.Auto["argc"] = xo_t[0].rhs.Length.ToString() ;
		X.Auto["i"]    = "0" ;
		X.Auto["I"]    = Rule.Set[0].Symbol.ToString() ;
		f.WriteLine( "partial class Automaton {" ) ;
		f.WriteLine( "\tconst int __default = " + ((int)_default).ToString() + " ;" ) ;
		f.WriteLine( "\t"+symbols_cs ) ;
		f.WriteLine( put("Automaton-deploy") ) ;
		for( int i = 0 ; i < stateset.Length ; i++ )
			{
			X.Auto["point"] = "_"+i.ToString() ;
			tabs = 1 ;
			f.Write( _io( i ) ) ;
			}
		f.WriteLine( "}" ) ;
		string previous_interface = string.Empty ;
		for( int i = 1 ; i < Rule.Set.Length ; i++ )
			{
			if( previous_interface != Rule.Set[i].lhs.s )
				{
				previous_interface = Rule.Set[i].lhs.s ;
				X.Auto["interface"] = Rule.Set[i].lhs.s ;
				X.Auto["i"] = "" ;
				X.Auto["I"] = "" ;
				}
			X.Auto["interface"] = "global::Item" ;
			X.Auto["namespace"] = Rule.Set[i].lhs.s + "._" + i ;
			X.Auto["signal"] = Rule.Set[i].Signal ;
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
			X.Auto["argc"] = Rule.Set[i].rhs.Length.ToString() ;
			f.Write( put("A335-Xo_t-Build-iDNA-5") ) ;
			f.WriteLine( ) ;
			}
		f.Close() ;
		}
	static public void Build()
		{
		string infrastruct = Embed( compile ) ;
		string linkset = "" ;
		for( int i = 1 ; i < xo_t.Length ; i++ )
			{
			if( xo_t[i].rhs.Length == 0 )
				continue ;
			if( xo_t[i].rhs[0].s[0] != '"' || xo_t[i].rhs[0].s[1] != '.' || xo_t[i].rhs[0].s[2] == '.' )
				continue ;
			linkset += Current.Path.Entry( "." + i + ".exe" ) + " " ;
			}
		//Cluster.Cli.Relink( infrastruct, linkset ) ;
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
	static readonly string[,] file =
		{
		{ "#/", "" },
		{ "~/", "X.Y.cs" },
		{ "#/", "X.Predefined.cs" },
		{ "#/", "Tokenset.cs" },
		{ "#/", "Automaton.1.cs" },
		{ "",   "Z.cs" },
		{ "~/", "C699.cs" },
		{ "~/", "C699.free.cs" }
		} ;
	static public string Embed( string[] compile )
		{
		string tab = "\n\t" ;
		string list = "\t" ;
		file[0,1] = "Auto."+A335.Branch+".cs" ;
		for( int i = 0 ; i < file.GetLength(0) ; i++ )
			{
			var f = "../../"+file[i,0]+file[i,1] ;
			list += "<Compile Include=\""+file[i,1]+"\" />"+tab ;
			Cluster.Cli.Copy( f, Current.Path.Entry( file[i,1] ) ) ;
			}
		foreach( string filename in compile )
			if( ! list.Contains( '"'+filename+'"' ) )
				list += "<Compile Include=\""+filename+"\" />"+tab ;
		list += "<Compile Include=\"tokenset.cs\" />"+tab ;
		var csproj = Current.Path.CreateText( "infrastructure.csproj" ) ;
		X.Auto["list"] = list ;
		csproj.WriteLine( put("ProjectFile") ) ;
		csproj.Close() ;
		Cluster.Cli.Build( "infrastructure.csproj" ) ;
		string infrastruct = Current.Path.Entry( "infrastructure.exe" ) ;
		Cluster.Cli.Copy( Current.Path.Entry("bin/Debug/infrastructure.exe"), infrastruct ) ;
		return infrastruct ;
		}
	}

static System.Text.StringBuilder symbols_cs = new System.Text.StringBuilder() ;
static string transitions = string.Empty ;

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
	foreach( State s in stateset )
		foreach( Transition t in s.Transitionset )
			stateset[t.state].Append( s.Number ) ;
	}

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
		Xo_t.Add( new Rule( number, lhs, rhs, usefulness.s == "useful" ) ) ;
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
	x_empty_ruleset[x_empty_ruleset.Length-1] = x_rule.number ;
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
	object o = new xml_token( t.token, t.symbol, t.name ) ;
	for( int x = 0 ; x < 603 ; x ++ )
		for( int y = 0 ; y < xo_t[x].rhs.Length ; y++ )
			xo_t[x][y].set_if( t.name, o ) ;
	symbols_cs.Append( string.Format("const int {0,30}\t= "+(int)t.symbol+" ;\n\t", t.name._s) ) ;
	}
	
static void xml_get_nonterminal()
	{
	xml_nt nt = new xml_nt() ;
	object o = new xml_symbol( nt.symbol, nt.name ) ;
	Rule.SetSymbol( nt.name.s, nt.symbol ) ;
	for( int x = 0 ; x < 603 ; x ++ )
		{
		xo_t[x].lhs.set_if( nt.name, o ) ;
		for( int y = 0 ; y < xo_t[x].rhs.Length ; y++ )
			xo_t[x][y].set_if( nt.name, o ) ;
		}
	symbols_cs.Append( string.Format( "const int {0,30}\t= "+(int)nt.symbol+" ;\n\t", nt.name._s ) ) ;
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
	foreach( Number n in x_empty_ruleset )
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
	t.state = Number.Parse( xml.Value );
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
	if( r.symbol != _default && -1 == System.Array.IndexOf( x_state.Lookaheadset, r.symbol ) )
		r.item = Itemset.Find( x_state.Itemset, xml.Value ) ;
	xml.MoveToNextAttribute() ;
	if( xml.Value != "accept" )
		r.rule = Number.Parse( xml.Value ) ;
	xml.MoveToNextAttribute() ;
	r.enabled = bool.Parse( xml.Value ) ;
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
