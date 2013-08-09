using System ;
using System.Diagnostics ;
using System.Text ;
using System.Xml ;
using System.IO ;
using System.Collections.Generic ;
//using System.Collections ; | < # >
using System.Net ;

partial class A335
		{
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
}