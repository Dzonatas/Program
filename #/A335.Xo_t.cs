partial class A335
{
public static void Main( string[] args )
	{
	xml_load_grammar() ;
	//Current.Working.Directory() ;
	Cluster.Cli.Start( "git branch", Branch_i ) ;
	Cluster.Program.Parse( args ) ;
	Current.Estate.Current__System_File.Path = Cluster.Parameter.Value("PANZOR") ;
	Xo_t.Compile() ;
	#if !UNICODED_SVG
	Xo_t.OutputGraph() ;
	#endif
	//Xo_t.Build() ;
	if( log_output != null )
		{
		log_output.Close() ;
		#if !DEBUG
		throw new System.NotImplementedException( "[/tmp/output.c] Logged" ) ;
		#endif
		}
	}

class Xo_t
	{
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
		backup = Rule.Set[r].RHS.Length ;
		yy = Rule.Set[r].Symbol ;
		string list = "" ;
		if( r > 0 ) //Target0: xyzzyy tail or mantissa.
			list += "auto = new " + Rule.Signal( Rule.Set[r] ) + "() ;" + tab ;
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
			int rule = (int)stateset[i].Reductionset[stateset[i].Default_reduction.Value].rule ;
			list += __point( _a, '-'+rule.ToString() ) ;
			list += gotoset_s( i, Rule.Set[rule].Symbol, _a ) ;
			}
		else
			{
			int rule = (int)stateset[i].Reductionset[stateset[i].Default_reduction.Value].rule ;
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
			int rule = (int)stateset[i].Reductionset[z].rule ;
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
		var xml = new System.Xml.XmlTextReader( new System.IO.StringReader( sxml ) ) ;
		read( xml ) ;
		return X.Auto["text"] ;
		}
	static readonly char[] trimchar = { '\n','\r'} ;
	static bool resolve = false ;
	static void read( System.IO.StreamReader sr )
		{
		resolve = false ;
		read( new System.Xml.XmlTextReader( sr ) ) ;
		}
	static void read( System.Xml.XmlReader xml )
		{
		bool content = false ;
		string text  = "" ;
		while( xml.Read() )
			{
			if( System.Xml.XmlNodeType.Element == xml.NodeType )
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
			if( content && System.Xml.XmlNodeType.EntityReference == xml.NodeType )
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
			if( content && System.Xml.XmlNodeType.EndElement == xml.NodeType )
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
		System.Collections.Generic.Dictionary<string,System.Type> automatrix =
			new System.Collections.Generic.Dictionary<string,System.Type>() ;
		if( Cluster.Parameter.Value("build") == "false" )
			return ;
		foreach( System.Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()  )
			{
			System.Attribute[] attributes = System.Attribute.GetCustomAttributes( t ) ;
			foreach( System.Attribute a in attributes )
				if( a is AutomatonAttribute )
					{
					if( string.IsNullOrEmpty( ((AutomatonAttribute)a).Signal ) )
						automatrix.Add( t.Name , t ) ;
					else
						automatrix.Add( ((AutomatonAttribute)a).Signal , t ) ;
					}
			}
		read( new System.IO.StreamReader( "../../#/Auto.xml" ) ) ;
		Cluster.Cli.NoOperation() ;
		X.Auto["branch"] = branch ;
		var f = Current.Path.CreateText( compile[0] ) ;
		f.Write( put("A335-Xo_t-Build-0") ) ;
		f.WriteLine( ) ;
		X.Auto["rule"] = ((int)_default).ToString() ;
		X.Auto["argc"] = Rule.Set[0].RHS.Length.ToString() ;
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
			if( previous_interface != Rule.Set[i].LHS )
				{
				previous_interface = Rule.Set[i].LHS ;
				X.Auto["interface"] = Rule.Set[i].LHS ;
				X.Auto["I"] = "" ;
				}
			X.Auto["rule"] = i.ToString() ;
			X.Auto["lhs_X"] = "Automaton." + Rule.EnumSymbol( Rule.Set[i] ) ;
			X.Auto["point"] = Rule.Set[i].Useful ? "true" : "false" ;
			X.Auto["interface"] = "global::Item" ;
			X.Auto["namespace"] = Rule.Set[i].LHS + "._" + i ;
			X.Auto["signal"] = Rule.Signal( Rule.Set[i] ) ;
			X.Auto["lhs"] = "{ " ;
			foreach( char c in Rule.Set[i].LHS )
				X.Auto["lhs"] += "'"+c+"', " ;
			X.Auto["lhs"] += " }" ;
			string name = string.Empty ;
			if( automatrix.ContainsKey( Rule.AlphaSignal( Rule.Set[i] ) ) )
				name = automatrix[ Rule.AlphaSignal( Rule.Set[i] ) ].FullName.Replace( '+', '.' ) ;
			else
			if( automatrix.ContainsKey( Rule.Signal( Rule.Set[i] ) ) )
				name = automatrix[ Rule.Signal( Rule.Set[i] ) ].FullName.Replace( '+', '.' ) ;
			if( name == string.Empty )
				X.Auto["synopsis"] = string.Empty ;
			else
				X.Auto["synopsis"] =
					"\n\t#if !EMBED"
					+ "\n\tprotected override global::A335.Automatrix splice_f() { return new global::"+name+"() ; }"
					+ "\n\t#endif" ;
			if( Rule.Set[i].RHS.Length > 0 )
				{
				var sb = new System.Text.StringBuilder() ;
				foreach( var rhs in Rule.Set[i].RHS )
					sb.Append("\"" + rhs.Replace("\"","\\\"") + "\", " ) ;
				sb.Remove( sb.Length-2, 2 ) ;
				X.Auto["rhs"] = "{ " + sb.ToString() + " }" ;
				}
			else
				X.Auto["rhs"] = "{}" ;
			X.Auto["argc"] = Rule.Set[i].RHS.Length.ToString() ;
			f.Write( put("A335-Xo_t-Build-iDNA-5") ) ;
			f.WriteLine( ) ;
			}
		f.WriteLine( "partial class A335 {" ) ;
		f.WriteLine( "public static readonly"
			+ " System.Collections.Generic.Dictionary<char,int> xml_translate"
			+ " = new System.Collections.Generic.Dictionary<char,int>() {"
			) ;
		foreach( System.Collections.Generic.KeyValuePair<char,int> kv in xml_translate )
			{
			f.WriteLine( "\t{{ '\\u{0:X4}', {1} }},",
				System.Convert.ToInt16(kv.Key),
				kv.Value
				) ;
			}
		f.WriteLine( "\t} ;" ) ;
		f.WriteLine( "}" ) ;
		f.Close() ;
		}
	static public void Build()
		{
		string infrastruct = Embed( compile ) ;
		string linkset = "" ;
		for( int i = 1 ; i < Rule.Set.Length ; i++ )
			{
			if( Rule.Set[i].RHS.Length == 0 )
				continue ;
			if( Rule.Set[i].RHS[0][0] != '"' || Rule.Set[i].RHS[0][1] != '.' || Rule.Set[i].RHS[0][2] == '.' )
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
}
