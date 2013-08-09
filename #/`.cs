using System;

public partial class _
{
}

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
