/*
commit 4b00444872ef9d4d1fcb396ae87a4f01b7dc4d81
Author: Dzonatas <dzonatas@gmail.com>
Date:   Sat Aug 24 10:41:21 2013 -0700

    _JHB
    Signed-off-by: Dzonatas <dzonatas@gmail.com>
*/
//using System;

public partial class _
{
}

#if SPIUGEBLHJEN_b
static internal Dictionary<string,b_set>   b_list = new Dictionary<string,b_set>() ;
static internal List<b_set>                b_list_of_pointers = new List<b_set>() ;
static internal List<b_set>                b_list_of_endpoints = new List<b_set>() ;
static internal bool                       b_subnets ;
static internal string                     b_io_path_one ;
static internal string                     b_io_path_two ;
static internal string                     b_io_path_three ;
#endif

#if SJLKNSKJNEIN_d
#if SJNSJNS
		static internal      Item      token ;
		static internal      Item      future    = new Item() ;
		
		static Item peek()
			{
			return stack.Peek() ;
			}
		static void poke( State state )
			{
			Item i = respond() ;
			if( i.symbol.StringIsNull != null && ! i.existential )
				throw new NotImplementedException( "Restated." ) ;
			i   = state ;
			i.stacked = false ;
			i.existential  = false ;
			request( ref i ) ;
			print_stack() ;
			}
		static void poke( Symbol symbol )
			{
			Item i = respond() ;
			if( i.existential )
				throw new NotImplementedException( "Reloaded." ) ;
			i.existential  = true ;
			i.symbol  = symbol ;
			i.stacked = false ;
			request( ref i ) ;
			}
		static Symbol get_symbol()
			{
			if( yytoken.StringIsNull == null )
				xml_get_() ;
			return yytoken ;
			}
		static Symbol next_symbol()
			{
			xml_get_() ;
			return yytoken ;
			}
		static Transition get_symbolic_transition( Symbol symbol, State state )
			{
			foreach( Transition t in state.transitionset )
				if( t == symbol )
					{
					if( t.type == "shift" && (object)symbol is xml_t )
						return t ;
					else
					if( t.type == "goto" && (object)symbol is xml_nt )
						return t ;
					}
			throw new NotImplementedException( "There is no try, only do." ) ;
			}
		static void print_state_header( Item i, string s )
			{
			//poke( i.state ) ;
			Console.Write("--------------{0}   ", s ) ;
			Console.Write("# {0}  {1}  ", stateset[i], s ) ;
			Console.WriteLine("--------------- L={0} R={1} T={2}",
				stateset[i].lookaheadset.Count,
				stateset[i].reductionset.Length,
				stateset[i].transitionset.Length,
				i.stacked ? "1" : "0"
				) ;
			}
		static void start()
			{
			Console.SetCursorPosition(0,0) ;
			}
		static internal Quant q   = new Quant() ;
		static internal Quant bit = new Quant() ;
		static void leave()
			{
			Console.SetCursorPosition(0,20) ;
			Console.Write("system") ;
			for( Item i = new Item() ;; bit.One = true )
				{
				// bit.switch { one:{} two:{} three:{} default: } [...blitter_stream...] ;
				if( bit.One )
					if( i.guid != null )
						if( i.guid == peek().guid )
							throw new NotFiniteNumberException( "Excluded enumeration, new Exception()." ) ;
						else
							if( peek().guid == null )
								{
								i.guid = Guid.NewGuid() ;
								bit.Two = true ;
								}
							else
								throw new EntryPointNotFoundException() ;
				enter( peek(), ref i ) ;
				if( i.do_ == null )
					continue ;
				if( bit.One )
					continue ;
				if( i.do_ != null )
					{
					token = i ;
					i.do_() ;
					continue ;
					}
				if( bit.Two )
					return ;
				goto unreachable ;
				}
			unreachable: throw new ProtocolViolationException() ;
			///* sleep(0) ; // INST[ant]_FO[u]R BRTARGET BRTARGET BRTARGET NAPINT64 */////$ $//////
			}
		/*
		static int x ;
		static int y ;
		static int zz ;
		static int yy ;
		*/
		static Item _enter( int x, int y, int zz, int yy )
			{
			Reduction   _ = stateset[x].reductionset[y] ;
			Transition  t = stateset[zz].transitionset[yy] ;
			//Symbol symbol = ruleset[_.rule] ;
			State   state = stateset[t.state] ;
			return new Item( new Symbol(0,0), state ) ;
			}
		static void q_continue()
			{
			bit.One   = true ;
			}
		static void q_right()
			{
			q.One     = true ;
			bit.Three = true ;
			}
		static void q_()
			{
			q.Two     = true ;
			}
		static void q_return()
			{
			bit.Two   = true ;
			}
		static void q_left()
			{
			q.Three   = true ;
			bit.Three = true ;
			}
		static void step()
			{
			token = get_symbol() ;
			Console.SetCursorPosition(0,0) ;
			Console.Write( "{0}-> ", token ) ;
			Console.ReadKey() ;
			q_return() ;
			}

		static void enter( Item stack, ref Item i )
			{
			Console.SetCursorPosition(0,1) ;
			Console.SetCursorPosition(0,3) ;
			if( i.do_ != stack.do_ || stack.do_ == null )
				{
				i = stack ;
				i.do_ = traverse_itemset ;
				request( ref i ) ;
				return ;
				}
			Console.WriteLine();
			}
		/*
		static void enter_again( Item stack, ref Item i )
			{
			foreach( Itemset item in stateset[stack].itemset )
				{
				Rule r = ruleset[item.rule] ;
				//i.symbol = ruleset[item.rule].lhs ;
				//Console.Write( "{0} #{1} |", r.lhs, item.point ) ;
				if( item.point >= r.rhs.Count )
					i.symbol = get_symbol() ;
				else
					{
					Symbol s = symbol_from_name[r.rhs[item.point]] ;
					i.symbol = s.terminal ? get_symbol() : s ;
					}
				foreach( Transition t in stateset[stack].transitionset )
					{
					//Console.WriteLine( " {0} |", t.symbol ) ;
					if( i.symbol == t.symbol )
						{
						Console.Write( "{0} {1}-{2} ; ", t.type, t.symbol, t.state ) ;
						i = stateset[t.state] ;
						if( t.type == "goto" )
							goto reduce ;
						request( ref i ) ;
						enter( peek(), ref i ) ;
						Console.WriteLine( "SHIFT------------------------ i={0} t={0}", stateset[i].debit, t.state ) ;
						continue ;
						}
					}
				continue ;
				reduce:
				if( i.symbol.terminal )
					foreach( Reduction _ in stateset[i].reductionset )
						if( _.enabled )
							if( i.symbol == _.symbol  )
								{
								reduce_stack_by_rule( ruleset[_.rule], ref i ) ;
								return ;
								}
							else
							if( _.symbol == "$default" )
								{
								reduce_stack_by_rule( ruleset[_.rule], ref i ) ;
								return ;
								}
				request( ref i ) ;
				enter( peek(), ref i ) ;
				}
			}
		*/	
		static Decimal itemset_ ;
		static void traverse_itemset()
			{
			Item stack = peek() ;
			foreach( Itemset item in stateset[stack].itemset )
				{
				Rule r = ruleset[item.rule] ;
				Console.SetCursorPosition(0,5) ;
				Console.Write("{0}-{1}", r, stateset[stack].debit );
				q_() ;
				leave() ;
				}
			}

		static void reduce_stack_by_rule( Rule r, ref Item i )
			{
			Console.SetCursorPosition(0,10) ;
			Console.WriteLine( "REDUCTION {0} rhs={1} stack={2}" , r, r.rhs.Count, stack.Count ) ;
			print_rule( r ) ;
			for( int x = r.rhs.Count ; --x > 0 ; respond() ) ;
			i = respond() ;
			i.stacked = false ;
			i.symbol = symbol_from_name[ r.ToString() ] ;
			return ;
			}
			
		static Reduction get_default_reduction( State state )
			{
			foreach( Reduction r in state.reductionset )
				if( r.symbol == 0 )
					return r ;
			throw new NotImplementedException( "Determinate." ) ;
			}
		
		static SearchResult analyize( Item i )
			{
			SearchResult sr ;
			if( i.symbol.StringIsNull )
				{
				Console.WriteLine("YYTOKEN={0}", yytoken ) ;
				sr = search_itemset( yytoken, stateset[i] ) ;
				}
			else
				{
				Console.WriteLine("STACKED={0}", i.symbol ) ;
				sr = search_itemset( i.symbol, stateset[i] ) ;
				}
			Console.Write("POINTS = {0}   ", sr.pointset.Count ) ;
			Console.Write("SHOWS  = {0}   ", sr.showset.Count ) ;
			Console.WriteLine("AHEADS = {0}", sr.aheadset.Count ) ;
			return sr ;
			}
			
			/*
			{
			if( t.type != null )
				Console.WriteLine("T {0} -> {1}", t.type, t.state  ) ;
			foreach( Reduction R in state.reductionset )
				Console.WriteLine( "R {0} -> {1}", R.symbol, ruleset[R.rule].lhs ) ;
			if( state.lookaheadset.Contains( token.name ) )
				Console.WriteLine("LOOKAHEAD {0}", token.name ) ;
			if( z.symbol != null )
				Console.WriteLine("REDUCTION {0}", z.symbol ) ;
			}
			*/
			
		public struct SearchResult
			{
			public List<Itemset> showset ;
			public List<Itemset> pointset ;
			public List<Itemset> aheadset ;
			public List<string>  points ;
			public SearchResult( List<Itemset> showset, List<Itemset> pointset, List<Itemset> aheadset, List<string> points )
				{
				this.showset = showset ;
				this.pointset = pointset ;
				this.aheadset = aheadset ;
				this.points = points ;
				}
			}
		static SearchResult search_itemset( Symbol s, State state )
			{
			bool show = false ;
			int items = 0 ;
			List <Itemset>   showset  = new List<Itemset>();
			List <Itemset>   pointset = new List<Itemset>();
			List <Itemset>   aheadset = new List<Itemset>();
			List <string>    points   = new List<string>() ;
			foreach( Itemset i in state.itemset )
				{
				int y = 0 ;
				show = false ;
				foreach( xml_s rhs in ruleset[i.rule].rhs )
					{
					if( s == rhs.s  )
						{
						show = true ;
						showset.Add( i ) ;
						break ;
						}
					}
				if( i.point >= ruleset[i.rule].rhs.Count )
					{
					aheadset.Add( i ) ;
					items++ ;
					goto result ;
					}
				if( ! show )
					continue ;
				result:
				Console.Write( "I {0} {1} | ", i.point, ruleset[i.rule].ToString() ) ;
				foreach( xml_s rhs in ruleset[i.rule].rhs )
					{
					//if( show )
					//	Console.WriteLine( "? {0}", rhs ) ;
					if( i.point == y )
						Console.Write( "<< " ) ;
					Console.Write( rhs ) ;
					if( i.point == y && s == rhs.s )
						{
						items++ ;
						pointset.Add( i ) ;
						points.Add( rhs.s ) ;
						}
					if( i.point == y )
						Console.Write( " >>" ) ;
					Console.Write( " " ) ;
					y++ ;
					}
				Console.WriteLine( " ;" ) ;
				}
			return new SearchResult( showset, pointset, aheadset, points ) ;
			}
			
	
		static void print_stack()
			{
			Console.Write("Stack={0} is ", stack.Count );
			Item [] a = stack.ToArray() ;
			Array.Reverse( a ) ;
			foreach( Item i in a )
				{
				Console.Write( "{0}-{1}", i.symbol, stateset[i].debit ) ;
				Console.Write( " " ) ;
				}
			Console.WriteLine( "[ {0} ]", yytoken ) ;
			}
		static void print_rule( Rule r )
			{
			Console.Write( "RULE {0}({1}) | ", r.ToString(), r.number ) ;
			foreach( xml_s rhs in r.rhs )
				{
				Console.Write( rhs.s ) ;
				Console.Write( " " ) ;
				}
			Console.WriteLine( ";") ;
			}
	static Reduction get_symbolic_reduction( Symbol symbol, State state )
			{
			foreach( Reduction r in state.reductionset )
				if( symbol == r.symbol )
					return r ;
			return new Reduction() ;
			}
#endif
#endif

#if SYBGWIPUEHOIJK_b
		
#if djdjnd

static void print_grammar()
	{
	for( int x = 0 ; x < 603 ; x++ )
		{
		Console.Write( xo_t[x] ) ;
		Console.Write( " " ) ;
		for( int y = 0 ; y < xo_t[x].rhs.Length ; y++ )
			{
			Console.Write( xo_t[x][y].s ) ;
			Console.Write( " " ) ;
			}
		Console.WriteLine("") ;
		}
			_.prompt(_.string_t) ;
	}


static void b_1()
	{
	Item i = new Item( new Symbol(), stateset[0] ) ;
	object o = b_list ;			//_FIX:_object_keyword_is_like_the_keyword_"reuse",_intentionally,_"partial"_box/unbox
		{
		b_list.Clear() ;
		build_list_of_points( i ) ;
		foreach( b_set b in b_list.Values )
			b_list_of_pointers.Add( b ) ;
		}
		{
		b_list.Clear() ;
		build_list_of_endpoints( i ) ;
		foreach( b_set b in b_list.Values )
			b_list_of_endpoints.Add( b ) ;
		}
	b_list = (Dictionary<string,b_set>)o ; //_FIX:_it's_"internal",_so_make_so_FIX: b_list = o ;

	build_paths() ;

		{
		B b = new B() ;
		}
	
	end() ;
	}
#endif

#if SJNSJ
class B
	{
	List<b_set>                a_list_of_pointers = new List<b_set>() ;
	List<b_set>                a_list_of_endpoints = new List<b_set>() ;
	Item 	                   i ;

	b_set b ;
	public B()
		{
		i = new Item( new Symbol(), stateset[2] ) ;
			{
			b = b_list_of_endpoints[0] ;
			print( ref i ) ;
			Console.SetCursorPosition(0,0) ;
			Console.Write( b ) ;
			_.prompt(_.string_t) ;
			}
		System.Console.Clear() ;
		object o = b_list ;			//_FIX:_object_keyword_is_like_the_keyword_"reuse",_intentionally,_"partial"_box/unbox
			{
			b_list.Clear() ;
			build_list_of_points( i ) ;
			foreach( b_set a in b_list.Values )
				a_list_of_pointers.Add( a ) ;
			}
			{
			b_list.Clear() ;
			build_list_of_endpoints( i ) ;
			foreach( b_set a in b_list.Values )
				a_list_of_endpoints.Add( a ) ;
			}
		b_list = (Dictionary<string,b_set>)o ; //_FIX:_it's_"internal",_so_make_so_FIX: b_list = o ;
		}
	}

static void B_end()
	{
	string path = System.Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) ;
	if( path != "" )
		throw new NotImplementedException( "Transient negotiations, phroke." ) ;
	if( b_list_of_pointers.Count != 2 )
		throw new NotImplementedException() ;
	if( b_list_of_endpoints.Count != 1 )
		throw new NotImplementedException() ;
	b_subnets = false ;                           //_FIX:_P=NP:=_FIXT: obvious b_subnets ;
	}
#endif

public struct b_set
	{
	public int x ;
	public int y ;
	public Decimal zz ;
	public Decimal yy ;
	public override string ToString()
			{
			return x.ToString() + "." + y.ToString() + "." + zz.ToString() + "." + yy.ToString() ;
			}
	public b_set( int x, int y, int zz, int yy )
		{
		this.x = x ;
		this.y = y ;
		this.zz = zz ;
		this.yy = yy ;
		}
	}
#if JSNJSN

static void build_list_of_points( Item i )
	{
	b_set b = new b_set();
	b.zz = i ;
	if( b_list.ContainsKey( b.ToString() ) )
		return ;
	if( stateset[i].reductionset.Length > 0 )
		{
		b.x = - 1 ;
		foreach( Reduction r in stateset[i].reductionset )
			{
			b.x++ ;
			Console.WriteLine( "{0} {1}", b, i ) ;
			b_list[b.ToString()] = b ;
			}
		}
	foreach( Itemset item in stateset[i].itemset )
		{
		Console.Write( "{0} , ", item ) ;
		if( item.point == ruleset[item.rule].rhs.Count )
			continue ;
		if( stateset[i].transitionset.Length > 0 )
			{
			b.y = -1 ;
			foreach( Transition t in stateset[i].transitionset )
				{
				Console.Write( "/{0}/ , ", t.symbol ) ;
				
//				while( ruleset[item.rule].rhs[item.point].s != t.symbol )
				while( t == xo_t[item.rule][item.point]  )
					{
					b.y++ ;
					break ;
					}
				}
			if( b.y != -1 )
				{
				Transition t_ = stateset[i].transitionset[b.y] ; //_FIX: t` = stateset[i.state].transitionset[b.y] ;
				build_list_of_points( b_enter( b.x, b.y, ref stateset[i], ref stateset[t_.state] ) ) ;
				}
			}
		}
	}

static void build_list_of_endpoints( Item i )
	{
	b_set b = new b_set();
	b.zz = stateset[i] ;
	if( b_list.ContainsKey( b.ToString() ) )
		return ;
	if( stateset[i].reductionset.Length > 0 )
		{
		b.x = - 1 ;
		foreach( Reduction r in stateset[i].reductionset )
			b.x++ ;
		}
	foreach( Itemset item in stateset[i].itemset )
		{
		Console.Write( "{0} , ", item ) ;
		if( item.point < ruleset[item.rule].rhs.Count )
			continue ;
		if( stateset[i].transitionset.Length > 0 )
			{
			if( ruleset[item.rule].rhs.Count > 0 )
				{
				b.y = -1 ;
				foreach( Transition t in stateset[i].transitionset )
					{
				Console.Write( "/{0}/ , ", t.symbol ) ;
					while( t != xo_t[item.rule].rhs[item.point] )
						{
						b.y++ ;
						break ;
						}
					}
				}
			b.zz = stateset[i] ;
			b.yy = stateset[i].transitionset[b.y] ;
			Console.WriteLine( "{0} {1}", b, item ) ;
			b_list[b.ToString()] = b ;
			}
		}
	}
	
static void build_paths()
	{
	string path = "/tmp" ;
	List<string> s = new List<string>() ;
	foreach( b_set b in b_list_of_pointers )
		s.Add( b.ToString() ) ;
	b_io_path_one   = path + "/" + system.guid + "." + s[0] ;
	b_io_path_two   = path + "/" + system.guid + "." + s[1] ;
	s.Clear() ;
	foreach( b_set b in b_list_of_endpoints )
		s.Add( b.ToString() ) ;
	b_io_path_three = path + "/" + system.guid + "." + s[0] ;
	}
		
static void b_end()
	{
	foreach( string b in b_list.Keys )
		Console.WriteLine( b ) ;
	}

static Item b_enter( b_set b )	
	{
	return b_enter( b.x , b.y , ref stateset[(int)b.zz] , ref stateset[(int)b.yy] ) ;
	}
static Item b_enter( int R , int T , ref State site_s , ref State site_ss )  //_HACK:_obvious,_FIX:.micro.r,.macro.t,_("ref"':')="using"
	{
	Reduction   r = site_s.reductionset[R] ;  //_precedence_FIX:try_[][]_,catch_()[]
	Transition  t = site_ss.transitionset[T] ; //_FIX:_internal:"buss",_external:"transient"
	//Symbol symbol = ruleset[r.rule] ;
	State   state = stateset[t.state] ;
	return Item
	//return new Item( new Symbol(0,0), state ) ;
	}
static Item b_enter( int enum_r, int site_t, Decimal site0_s, Decimal site1_s )
	{
	return b_enter( enum_r , site_t , site0_s , site1_s ) ;
	}
	
static void print( ref Item i )
	{
	int x = 0, y = 0, l = x ; // zz = 0, yy = 0;
	Console.Clear() ;

	x = ++l ;
	Console.SetCursorPosition(y,x) ;
	Console.Write( (Decimal)i ) ;	

	x = ++l ;
	foreach( Itemset item in stateset[i].itemset )
		{
		Console.SetCursorPosition(y,x) ;
		Console.Write( xo_t[item.rule].lhs + "." ) ;
		Console.Write( item.point ) ;
		Console.Write( "[" ) ;
		Console.Write( ruleset[item.rule].rhs.Count ) ;
		Console.Write( "]" ) ;
		//if( item.point == ruleset[item.rule].rhs.Count )
	//		Console.Write( '#' ) ;
		if( ++x > 10 ) { break ; /*x = l ; y += 15 ;*/ }
		}
		
	x = (l += 11 ) ;
	Console.SetCursorPosition(y=0,x=12) ;
	/*
	Console.Write( ruleset[0] + " | " ) ;

	foreach( xml_s rhs in ruleset[0].rhs )
		{
		Console.Write( rhs.s + " " ) ;
		//Console.SetCursorPosition(y,x) ;
		}
	*/

	x = (l += 1 ) ;
	Console.SetCursorPosition(y=0,x) ;
	
	foreach( Transition t in stateset[i].transitionset )
		{
		if( y > 80 ) break ;
		Console.SetCursorPosition(y,x) ;
		Console.Write( t.symbol  ) ;
		if( ++x > 20 ) { x = l ; y += 15 ; }
		}
		
	x = (l += 3 ) ;
	Console.SetCursorPosition(y=0,x) ;
	
	foreach( Reduction r in stateset[i].reductionset )
			Console.Write( "{0}<{1}> ", r.symbol, xo_t[r.rule].lhs ) ;
	
	}
#endif
#endif

#if SJNSJNS
				static void xml_i()
					{
					xml.MoveToFirstAttribute() ;
					

					xml.MoveToNextAttribute() ;
					//token = Convert.ToInt32( xml.Value ) ;
					xml.MoveToNextAttribute() ;
					//string 	cn = xml.Value ;
					xml.MoveToNextAttribute() ;
					string 	sn = xml.Value ;
					xml.MoveToNextAttribute() ;
					//string 	sb1 = xml.Value ;
					xml.MoveToNextAttribute() ;
					//string 	sb2 = xml.Value ;
					xml.MoveToNextAttribute() ;
					string 	op = xml.Value ;
					xml.MoveToNextAttribute() ;
					//string 	ok = xml.Value ;
					xml.MoveToNextAttribute() ;
					//string 	h = xml.Value ;
					xml.MoveToNextAttribute() ;
					//string 	bb = xml.Value ;
					xml.MoveToNextAttribute() ;
					//string 	b = xml.Value ;
					xml.MoveToNextAttribute() ;
					//string 	cf = xml.Value ;
					Console.WriteLine( sn ) ;
					switch( op )
						{
						case "InlineNone":
							get() ;
							break ;
						case "InlineMethod":
							get() ;
							callConv() ;
							type() ;
							int s = state ;
							typeSpec() ;
							if( s != state )
								{
								assert( "_", "::" ) ;
								get() ;
								}
							methodName() ;
							sigArgs0_p() ;
							get() ;
							break ;
						case "InlineString":
							get() ;
							compQstring() ; // or bytes
							break ;
						default:
							Console.WriteLine("{0} {1} {2}?", xml_element, 0, op) ;
							break ;
						}
					}
				static void xml_assembly()
					{
					bool _extern = false ;
					get() ;
					if( text_( "extern" ) )
						{
						_extern = true ;
						get() ;
						}
					string s = id() ;
					Console.WriteLine(".assembly {0} {1} {{", _extern ? "extern" : "", s ) ;
					get( start_curly_bracket ) ;
					while( get() && ! end_curly_bracket() )
						xml_() ;
					}
				static void xml_ver()
					{
					get( "int64" ) ;
					get( "p", ":" ) ;
					get( "int64" ) ;
					get( "p", ":" ) ;
					get( "int64" ) ;
					get( "p", ":" ) ;
					get( "int64" ) ;
					}
				static void xml_hash()
					{
					//bool _algorithm = false ;
					get() ;
					switch( xml_element )
						{
						case "_":
							//_algorithm = text == "algorithm" ;
							get( "int64" ) ;
							break ;
						default:
							throw new Exception() ;
						}
					}
				static void xml_class()
					{
					get() ;
					classAttr() ;
					id() ;
					get() ;
					if( text_( "extends" ) )
						className() ;
					if( text_( "implements" ) )
						do className() ;
						while( comma() ) ;
					assert( start_curly_bracket ) ;
					while( get() && ! end_curly_bracket() )
						xml_() ;
					}
				static void xml_method()
					{
					get() ;
					methAttr() ;
					callConv() ;
					paramAttr() ;
					type() ;
					if( text_( "marshal" ) )
						{
						get( start_parenthesis ) ;
						get() ; nativeType() ;
						assert( end_parenthesis ) ;
						get() ;
						}
					methodName() ;
					sigArgs0_p() ;
					get() ;	implAttr() ;
					assert( start_curly_bracket ) ;
					int s = state ;
					get() ;
					while( ! end_curly_bracket() )
						{
						if( s == state )
							throw new Exception() ;
						s = state ;
						if( xml_element_id() )
							{
							id() ;
							get( "p", ":" ) ;
							get() ;
							}
						xml_() ;
						}
					}
				static void xml_maxstack()
					{
					get( "int64" ) ;
					get() ;
					}
				static void xml_entrypoint()
					{
					get() ;
					}






				static Item leave_alone( Item stack )
					{
					for( Item i = new Item() ;; stack = peek(), bit.One = true )
						{
						if( bit.One )
							return i ;
						foreach( Itemset item in stack.state.itemset )
							{
							Rule r = ruleset[item.rule] ;
							Console.Write( "$" ) ;
							switch( r.lhs )
								{
								case "$accept" :
									Console.Write( "{0} |", r.lhs ) ;
									if( r.rhs.Count <= item.point )
										continue ;
									i.symbol = symbol_from_name[ r.rhs[item.point] ] ;
									Console.Write( "| {0} ", i.symbol ) ;
									if( i.symbol.name == "$end" )
										{
										Reduction rr = stateset[0].reductionset[0] ;
										i.symbol = symbol_from_name[ ruleset[rr.rule].lhs ] ;
										Transition t = stateset[0].transitionset[1] ;
										i.state  = stateset[t.state] ; 
										push( i ) ;
										//leave( peek() ) ;
										return i ;
										}
									if( stack.state.transitionset.Length != 0 )
										{
										i.state  = stateset[stack.state.transitionset[0].state] ;
										goto accept ;
										}
									if( stack.state.reductionset[0].rule == int.MaxValue )
										{
										i.state = stateset[0] ;
										push( i ) ;
										return i ;
										}
									goto default ;
								default:
									throw new Exception() ;
								}
							}
						accept:
						push( i ) ;
						//leave( peek() ) ;
						}
					}

			static void save()
					{
					newstate:
					Item i = new Item() ;
					switch( i.state.number )
						{
						default:
							{
							i.q.One   = false ;
							i.bit.One = false ;
							if( i.state.reductionset[0].enabled )
								i.q.One = true ;
							if( i.state.transitionset.Length == 0 )
								i.bit.One = true ;

							iq:
							Console.WriteLine("QBIT = {0}-0-{1}", i.q, i.bit ) ;
							
							
							if( i.q.One && ! i.bit.One && ! i.stacked )
								{
								//Rule   r = ruleset[ i.state.reductionset[0].rule ] ;
								Symbol s = get_symbol() ;
								Transition t = get_symbolic_transition( s, i ) ;
								push( i = new Item( s, stateset[t.state] ) ) ;
								goto newstate ;
								}
								
							if( i.q.One == false && ! i.stacked && i.state.lookaheadset.Count == 0 )
								{
								Symbol s = i.stacked ? i.symbol : get_symbol() ;
								Transition t = get_symbolic_transition( s, i ) ;
								push( i = new Item( s, stateset[t.state] ) ) ;
								goto newstate ;
								}
								
							if( i.q.One == false && i.stacked && i.state.lookaheadset.Count == 0 )
								{
								Symbol s = i.symbol ;
								Transition t = get_symbolic_transition( s, i ) ;
								poke( s ) ;
								poke( i.state = stateset[t.state] ) ;
								goto newstate ;
								}

							if( i.q.One && i.bit.One )
								{
								Rule r = ruleset[ i.state.reductionset[0].rule ] ;
								reduce_stack_by_rule( r ) ;
								Item reduced = pop() ;
								i = peek() ;
								reduced.stacked = false ;
								push( reduced ) ;
								i.symbol = reduced.symbol ;
								goto newstate ;
								}
								
							if( i.q.One && ! i.bit.One && i.stacked && i.state.lookaheadset.Count != 0 )
								{ // 204 twice
								//Symbol s = get_symbol() ;
								//bool b = i.state.lookaheadset.Contains( s ) ;
								
								Rule r = ruleset[ i.state.reductionset[0].rule ] ;
								reduce_stack_by_rule( r ) ;
								Item reduced = pop() ;
								i = peek() ;
								reduced.stacked = false ;
								push( reduced ) ;
								i.symbol = reduced.symbol ;
								goto newstate ;
								}

// -----------------------
#if sjjnjns
							if( i.bit.Two && String.IsNullOrEmpty( i.symbol.name ) ) 
								{								
								Symbol s = get_symbol() ;
								transition = get_symbolic_transition( s, i ) ;
								poke( s ) ;
								push( i = new Item( yytoken = new Symbol(), stateset[transition.state] ) ) ;
								goto newstate ;
								}

							if( i.bit.Two && ! String.IsNullOrEmpty( i.symbol.name ) ) 
								{								
								transition = get_symbolic_transition( i, i ) ;
								push( i = new Item( new Symbol(), stateset[transition.state] ) ) ;
								goto newstate ;
								}
								
							if( i.bit.Three )
								{
								}
								
							if( i.state.transitionset.Length == 1
								&& i.state.transitionset[0].symbol == i.symbol.name )
								{
								i.bit.Two = true ;
								goto iq ;
								}
							
							
							analyize() ;
							
							//Item top = pop() ;
							if( i.state.reductionset.Length == 1 
								&& i.state.reductionset[0].symbol != "$default" )
								{
								reduction = i.state.reductionset[0] ;
								reduce_stack_by_rule( ruleset[reduction.rule] ) ;
								i = peek() ;
								i.q.One = false ;
								goto newstate ;
								}

							if( i.q.One )
								{
								i.bit.Two = true ;
								goto iq ;
								}
																
							if( i.state.transitionset.Length > 1 )
								{
								i.bit.Two = true ;
								goto iq ;
								}
							
							if( i.state.reductionset.Length == 1 )
								{
								if( i.state.reductionset[0].symbol == i.symbol.name )
									reduction = i.state.reductionset[0] ;
								else
								if( i.state.reductionset[0].symbol == "$default" )
									reduction = i.state.reductionset[0] ;
								else
									break ;
								reduce_stack_by_rule( ruleset[reduction.rule] ) ;
								i = peek() ;
								i.q.One = false ;
								goto newstate ;
								}

							if( i.q.One )
								{
								i.bit.Two = true ;
								goto iq ;
								}

							if( i.q.Three )
								{
								break ;
								}
#endif
							break ;
							}
						}
					throw new NotImplementedException( "Quantum strangeness." ) ;
					}



#endif


#if ASJNJNS
				static string id()
					{
					assert( () => { return xml_element_id() || xml_element_sqstring() ; } ) ;
					return text ;
					}
				static void callConv()
					{
					if( yyrule.rhs.Count != 0 )
					Console.WriteLine("callConv() {0} {1} {2} {3}", text, yyrule.lhs, yyrule.number, yystate._default ) ;
					if( xml_element_() ) 
						switch( text )
							{
							case "instance": get(); callConv() ; break ;
							case "explicit": get(); callConv() ; break ;
							default: callKind() ; break ;
							}
					}
				static void callKind()
					{
					if( xml_element_() ) 
						switch( text )
							{
							case "default": get(); break ;
							case "vararg": get(); break ;
							case "unmanaged": get() ;
								switch( text )
									{
									case "cdecl": get() ; break ;
									case "stdcall": get() ; break ;
									case "thiscall": get() ; break ;
									case "fastcall": get() ; break ;
									}
								break ;
							}
					}
				static void classAttr()
					{
					Console.WriteLine( yyrule.lhs ) ;
					while( xml_element_() ) 
						switch( text )
							{
							case "public" :
							case "private" :
							case "value" :
							case "enum" :
							case "interface" :
							case "sealed" :
							case "abstract" :
							case "auto" :
							case "sequential" :
							case "explicit" :
							case "ansi" :
							case "unicode" :
							case "autochar" :
							case "import" :
							case "serializable" :
							case "specialname" :
							case "rtspecialname" :
							case "beforefieldinit" :
								get() ;
								break ;
							case "nested" :
								get() ;
								switch( text )
									{
									case "public" :
									case "private" :
									case "family" :
									case "assembly" :
									case "famandassem" :
									case "famorassem" :
										get() ;
										break ;
									//default
									}
								break ;
							default:
								return ;
							}
 					}
				static void methAttr()
					{
					while( xml_element_() )
						switch( text )
							{
							case "static" :
							case "public" :
							case "private" :
							case "family" :
							case "final" :
							case "specialname" :
							case "virtual" :
							case "abstract" :
							case "assembly" :
							case "famandassem" :
							case "famorassem" :
							case "privatescope" :
							case "hidebysig" :
							case "newslot" :
							case "rtspecialname" :
							case "unmanagedexp" :
							case "reqsecobj" :
								get() ;
								break ;
							case "pinvokeimpl":
								get( start_parenthesis ) ;
								get() ;
								if( xml_element_qstring() )
									compQstring() ;
								if( text_( "as" ) )
									{
									get() ;
									compQstring() ;
									}
								pinvAttr() ;
								assert( end_parenthesis ) ;
								get() ;
								break ;
							default:
								return ;
							}
					}
				static void pinvAttr()
					{
					while( xml_element_() )
						switch( text )
							{
							case  "nomangle" :
							case  "ansi" :
							case  "unicode" :
							case  "autochar" :
							case  "lasterr" :
							case  "winapi" :
							case  "cdecl" :
							case  "stdcall" :
							case  "thiscall" :
							case  "fastcall" :
								get() ;
								break ;
							default :
								return ;
							}
					}
				static void type()
					{
					if( xml_element_() )
						switch( text )
							{
							case "class" : className() ; break ;
							case "object" : get() ; break ;
							case "string" : get() ; break ;
							case "value" /*"class"*/ : get_( "class" ) ; className() ; break ;
							case "valuetype" : className() ; break ;
							case "typedref" : get() ; break ;
							case "char" : get() ; break ;
							case "void" : get() ; break ;
							case "bool" : get() ; break ;
							case "int8" : get() ; break ;
							case "int16" : get() ; break ;
							case "int32" : get() ; break ;
							case "int64" : get() ; break ;
							case "float32" : get() ; break ;
							case "float64" : get() ; break ;
							case "unsigned" : get() ;
								switch( text )
									{
									case "int8" : get() ; break ;
									case "int16" : get() ; break ;
									case "int32" : get() ; break ;
									case "int64" : get() ; break ;
									}
								break ;
							case "native" : get() ;
								switch( text )
									{
									case "int" :  get() ; break ;
									case "unsigned" /* "int" */: get_( "int" ) ; get() ; break ;
									case "float" : get() ; break ;
									}
								break ;
							case "method" : get() ;
								callConv() ;
								type() ;
								assert( asterisk ) ;
								get() ;
								sigArgs0_p() ;
								get() ;
								break ;
							}
					else
					if( exclamation_point() )
						{
						get() ; // int32
						get() ;
						}
					else
						return ;
					loop:
						if( xml_element == "p" )
							switch( text )
								{
								case "[" : get() ; bounds() ; assert( end_square_bracket ) ; get() ; break ;
								case "&" : get() ; break ;
								case "*" : get() ; break ;
								default :
									return ;
								}
						else
						if( xml_element_() )
							switch( text )
								{
								case "pinned" : get() ; break ;
								case "modreq" :
								case "modopt" :
									 get( start_parenthesis ) ;
									 className() ;
									 assert( end_parenthesis ) ;
									 get() ;
									 break ;
								default :
									return ;
								}
						else
							return ;
					goto loop ;
					}
				static void sigArgs0_p()
					{
					assert( start_parenthesis ) ;
					if( get() && ! end_parenthesis() )
						sigArgs1() ;
					assert( end_parenthesis ) ;
					}
				static void sigArgs1()
					{
					loop:
						sigArg() ;
						if( comma() )
							{
							get() ;
							goto loop ;
							}
					}
				static void sigArg()
					{
					if( text_( "..." ) )
						{
						get() ;
						return ;
						}
					paramAttr() ;
					type() ;
					if( text_( "marshal" ) )
						{
						get( start_parenthesis ) ;
						nativeType() ;
						assert( end_parenthesis ) ;
						get() ;
						}
					if( xml_element_sqstring() || xml_element_id() )
						{
						id() ;
						get() ;
						}
						
					}
				static void paramAttr()
					{
					loop:
						if( start_square_bracket() )
							{
							get() ; // "in", "out", "opt", int32
							get( end_square_bracket ) ;
							get() ;
							goto loop ;
							}
					}
				static void nativeType()
					{
					if( xml_element_() )
						switch( text )
							{
							case "currency" :
				 			case "syschar" :
				 			case "void" :
				 			case "bool" :
				 			case "int8" :
				 			case "int16" :
				 			case "int32" :
				 			case "int64" :
				 			case "float32" :
				 			case "float64" :
				 			case "error" :
				 			case "decimal" :
				 			case "date" :
							case "bstr" :
				 			case "lpstr" :
							case "lpwstr" :
							case "lptstr" :
							case "objectref" :
							case "iunknown" :
							case "idispatch" :
							case "struct" :
							case "interface" :
				 			case "tbstr" :
							case "int" :
							case "byvalstr" :
							case "lpstruct" :
							case "method" :
								get() ;
								break ; 
							case "unsigned" : get() ;
								switch( text )
									{
									case "int" : get() ; break ;
									case "int8" : get() ; break ;
									case "int16" : get() ; break ;
									case "int32" : get() ; break ;
									case "int64" : get() ; break ;
									}
								break ;
							case "safearray" : get() ;
								variantType() ;
								if( comma() )
									{
									get() ;
									compQstring() ;
									}
								break ;
							case "nested" : get_( "struct" ) ; get() ; break ;
							case "ansi" : get_( "bstr" ) ; get() ; break ;
							case "as" : get_( "any" ) ; get() ; break ;
							case "variant" : get() ;
								if( text_( "bool" ) )
									get() ;
								break ;
							case "custom" :
								get( start_parenthesis ) ;
								get() ; compQstring() ;
								assert( comma ) ;
								get() ; compQstring() ;
								if( comma() )
									{
									get() ; compQstring() ;
									assert( comma ) ;
									get() ; compQstring() ;
									}
								assert( end_parenthesis ) ;
								get() ;
								break ;
							case "fixed" :
								get() ; // "sysstring", "array"
								get( start_square_bracket ) ;
								get() ; // int32
								get( end_square_bracket ) ;
								get() ;
								break ;
							}
					else
						return ;
					loop:
						if( start_square_bracket() )
							{
							get() ;
							if( xml_element == "int64" )
								get() ;
							if( plus() )
								get() ;
							if( xml_element == "int64" )
								get() ;
							assert( end_square_bracket ) ;
							get() ;
							}
						else
						if( asterisk() )
							{
							get() ;
							}
						else
							return ;
					goto loop ;
					}
				static void compQstring()
					{
					do get() ;
					while( plus() && get() ) ;
					}
				static void variantType()
					{
					if( xml_element_() )
						switch( text )
							{
							case "null" :
							case "variant" :
							case "currency" :
							case "void" :
							case "bool" :
							case "int8" :
							case "int16" :
							case "int32" :
							case "int64" :
							case "float32" : 
							case "float64" :
							case "int" :
							case "decimal" :
							case "date" :
							case "bstr" :
							case "lpstr" :
							case "lpwstr" :
							case "iunknown" :
							case "idispatch" :
							case "safearray" :
							case "error" :
							case "hresult" :
							case "carray" :
							case "userdefined" :
							case "record" :
							case "filetime" :
							case "blob" :
							case "stream" :
							case "storage" :
							case "streamed_object" :
							case "stored_object" :
							case "blob_object" :
							case "cf" :
							case "clsid" :
								get() ;
								break ;
							case "unsigned" :
								get() ; // int8 || int16 || int32 || int64
								get() ; 
								break ;
							}
						else
						if( asterisk() )
							{
							get() ;
							}
						else
							return ;
						if( punctuation() )
							{
							switch( text )
								{
								case "[" : get( end_square_bracket ) ; break ;
								case "&" : get() ; break ;
								}
							}
						else
						if( text_( "vector" ) )
							{
							get() ;
							}
						}
				static void bounds()
					{
					do bound() ;
					while ( comma() && get() ) ;
					}
				static void bound()
					{
					if( text_( "..." ) )
						{
						get() ;
						}
					else
					if( xml_element == "int64" )
						{
						get_( "..." ) ;
						get( "int64" ) ;
						get() ;
						}
					}
				static string name()
					{
					if( xml_element == "dottedname" )
						{
						get() ;
						return "" ; // text
						}
					do
						{
						id() ;
						get() ;
						}
						while ( period() && get() ) ;
					return "" ;
					}
				static void methodName()
					{
					if( xml_element_ctor() || xml_element_cctor() )
						{
						get() ;
						return ;
						}
					name() ;
					}
				static void typeSpec()
					{
					int s = state ;
					type() ;
					if( s != state )
						return ;
					if( start_square_bracket() )
						{
						get() ;
						if( xml_element_module() )
							{
							//_module = true ;
							get() ;
							}
						name() ;
						assert( end_square_bracket ) ;
						get() ;
						}
					switch( xml_element )
						{
						case "dottedname" :
						case "id" :
						case "sqstring" :
							break ;
						default :
							return ;
						}
					name() ;
					while( slash() )
						{
						get() ;
						name() ;
						}
					}
					
				static void className()
					{
					//bool _module = false ;
					get() ;
					if( start_square_bracket() )
						{
						get() ;
						if( xml_element_module() )
							{
							//_module = true ;
							get() ;
							}
						name() ;
						assert( end_square_bracket ) ;
						get() ;
						}
					name() ;
					while( slash() )
						{
						get() ;
						name() ;
						}
					}
				static void implAttr()
					{
					while( xml_element_() )
						switch( text )
							{
							case  "native" :
							case  "cil" :
							case  "optil" :
							case  "managed" :
							case  "unmanaged" :
							case  "forwardref" :
							case  "preservesig" :
							case  "runtime" :
							case  "internalcall" :
							case  "synchronized" :
							case  "noinlining" :
								get() ;
								break ;
							default:
								return ;
							}
					}
#endif
