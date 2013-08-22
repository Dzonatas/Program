using System.Collections.Generic ;
using System.Xml ;
using System.IO ;
using System ;
//using System.Runtime ;

partial class A335
{

static internal Dictionary<string,b_set>   b_list = new Dictionary<string,b_set>() ;
static internal List<b_set>                b_list_of_pointers = new List<b_set>() ;
static internal List<b_set>                b_list_of_endpoints = new List<b_set>() ;
static internal bool                       b_subnets ;
static internal string                     b_io_path_one ;
static internal string                     b_io_path_two ;
static internal string                     b_io_path_three ;

static void Blogic()
	{
	_.assimulation() ;
	//Console.WriteLine( "symbolset={0} tokenset={1}", xml_symbolset.Count, xml_tokenset.Count ) ;
	/*
	foreach( State s in stateset )
		{
		if( s.itemset.Length == 0 )
			throw new NotImplementedException() ;
		if( s.itemset.Length == 1 )
			y++ ;
		if( s.itemset.Length == 1 && s.reductionset.Length == 0 )
			zz++ ;
		if( s.itemset.Length == 1 && s.transitionset.Length == 0 )
			yy++ ;
		if( s.transitionset.Length == 0 && s.reductionset.Length == 0 )
			throw new NotImplementedException() ;
		if( s.reductionset.Length == 1 && s.reductionset[0] != _default )
			throw new NotImplementedException() ;
		if( s.reductionset.Length >  1 && s.reductionset[0] == _default )
			throw new NotImplementedException() ;
		if( s.transitionset.Length == 1 && s.reductionset.Length == 1 && s.transitionset[0] == s.reductionset[0] )
			throw new NotImplementedException() ;
		if( s.itemset.Length < s.transitionset.Length )
			throw new NotImplementedException() ;
		if( s.itemset.Length > 1 && s.itemset.Length == s.transitionset.Length && s.reductionset.Length != 0 )
			throw new NotImplementedException() ;
		if( s.itemset.Length == s.transitionset.Length && s.reductionset.Length != 0 )
			throw new NotImplementedException() ;
		if( s.itemset.Length + s.reductionset.Length < s.transitionset.Length )
			throw new NotImplementedException() ;
		if( s.transitionset.Length == 0 && s.itemset.Length <= s.reductionset.Length && s.reductionset[s.reductionset.Length-1] != _default )
			throw new NotImplementedException() ;
		if( s.transitionset.Length == 0 && s.reductionset[s.reductionset.Length-1] != _default )
			throw new NotImplementedException() ;
		x++ ;
		}
	if( y != (zz + yy) )
		throw new NotImplementedException() ;
	Console.WriteLine("x={0} y={1} z={2} yy={3}",x,y,zz,yy ) ;
	*/
	xyzzyy b = new xyzzyy(0,0,0,_default) ;
	jump_( ref b ) ;
	//b.Goto( 0, 0, 0, _default ) ;
	//goto_(  ) ;
	_.prompt(_.string_t) ;
	}
static List<_.Token> b_line = new List<_.Token>() ;

static string b_xhtml_css ; /*$...trigraphs...$*/    //_FIX:tainted,_second
static string [,] b_xhtml ; /*$...digraphs....$*/    //_FIX:tainted,_css[,_streaming{},_lock_matrix[_SSE4]]

//_FIX:can't_type_it(_here),<s>_breaks_kernel</s>,_FIXT:down_on_obvious_[...]_scanner,_said$dart[,_dirty_async_begin]
//_FIXT:BSD,_or_SELINIX_WITH_GAC[,_plan9...][,_[ref:ms]_linq][,Intel_b[l]_][,ARM]
//_FIXT:coLinux,_spliced_MICROSOFT_and_LINUX[_static][,_skew][,_hardened][[_ribbon]]

//_.

//_.console.yield(<t`_x.y>) ;
//_.elevation.up(dome)

//_.mono.down
//_.character.mode.ascii.up ;;
//_.character.mode.unicode.up(__) ;
//_.c.down

/*

jo <restricted,dome>{
	Decimal   center ;
	reserved  word ;     //_FIXT:$default,_researched,_said,_etc[,_used] [...remote...]
	//object    remote ;_USED,_null_or_array_splice|split,[_unknown::]
}

jo remote_lock : System.Attribute  //_rep()_is_not_DO_replication,_[quantum]_mechanics
	{
	// nop ;_ms
	}	


jo remote_lock <restricted,domain>{
	//_C,_trivial_unmarshal[,_fastcall[2]]
	}
	
jo var{
	//_do_nothing,_variously_;_unbeeps;_noise_as_signal_as_gc
}

[.class] jo b_atomatrix ;_tut[][]->[,]

jo dunce{//$default
	$end.assert(center==$[,elevation.down==true]) ;_symbol_s[,_said]
	}//=>$account[,$[<-]idol][$->idle](javascript:overflows->space_(t|nt),_no_style,_[xhtml|*]wrap[,_dae])

jo synopsis{} ;[_delegate_rt_[default_|_|*]]
	jo`{server:default:dome} ;
*///	jo`{urn:number:atomatrice:atomatrix:_}  //_$D#$

//delegate b_schema [=...] ;

//_.c.library.remote.down
//_.c.up
/*//_.apu.gpu.override.up   //_replicates_i,_google_play,_!bad[,__.social]
//_.arm.gpu.override.up
//_.console.bypass.         /*$singularity$useless[::]*/

//_.academic.grade.down
//_.academic.security.bypass.  /*$standard$disabled[::]*/
//_.academic.security.static.single.file.up  /*$standard$disabled[::]*/
//_.academic.grade.gpa.up
//_.academic.grade.down
//_.

//_FIX:idles,<s>leases</s>,_request(ref_)[respond,]
//_.X[3,11].up(__)
//_.NET.up(__)
	
#if SJKSNS
		
	if( this_state.lookaheadset.Count > 0 )
		Console.SetCursorPosition(1,1) ;
		
		
		
	
	
	
	if( b.y < xo_t[b.x].rhs.Length )
	         xo_ = xo_t[b.x][b.y] ;
	else
	         xo_ = xo_t[b.x] ;
	if( this_state.transitionset.Length > 0 && this_state.transitionset[0].type == "goto" && b.c == 0 )
		{
		if( ! transition( xo_, out t ) )
			throw new NotImplementedException() ;
		b.Goto( b.x, b.y, t.state, 0 ) ;
		goto setstate ;
		}
	else
	if( this_state.transitionset.Length > 0 && this_state.transitionset[0].type == "shift" && b.c == 0 )
		{
		if( ! token.HasValue )
			token = input() ;
		b.c = xml_translate[token.Value.c] ;
		token = null ;
		if( reduction( b.c, out r ) )
			{
			item( xo_t[r.rule], out i ) ;
			b.x = i.rule ;
			b.y = i.point ;
			b.z = r.rule ;
			b.c = 0 ;
			//throw new ReductionAcception() ;
			throw new NotImplementedException() ;
			}
		i = this_state.itemset[this_state.default_item.Value] ;
		}
	else
	if( this_state.transitionset.Length == 0 )
		{
		i = this_state.itemset[this_state.default_item.Value] ;
		b.x = i.rule ;
		b.y = i.point ;
		b.z = i.rule ;
		throw new ReductionAcception( b.y-1 ) ;
		}
	/*
	else
		{
		throw new NotImplementedException() ;
		}
	*/
	    {
		if( ! item( xo_t[b.x], out i ) )
			throw new NotImplementedException() ;
		}
	if( i.point < xo_t[i.rule].rhs.Length )
	         _xo = xo_t[i.rule][i.point] ;
	else
	         _xo = xo_t[i.rule] ;
	if( ! transition( b.c, out t ) )
		{
		if( ! reduction( _default, out r ) )
			return ;
		item( xo_t[r.rule], out i ) ;
		b.x = i.rule ;
		b.y = i.point ;
		b.z = r.rule ;
		throw new ReductionAcception( b.y ) ;
		}
	//if( ! item( t.symbol, out i ) )
	//		throw new NotImplementedException() ;
	foreach( Itemset item in this_state.itemset )
		{
		if( item.point < xo_t[item.rule].rhs.Length )
			xo_ = xo_t[item.rule][item.point] ;
		else
			xo_ = xo_t[item.rule] ;
		if( t.symbol == (int)xo_ )
			{
			if( t.type == "shift" )
				{
				b.Goto( item.rule, item.point, t.state, b.c ) ;
				token = null ;
				}
			else
				{
				b.x = item.rule ;
				b.y = item.point ;
				b.z = t.state ;
				}
			goto setstate ;
			}
		}
	throw new NotImplementedException() ;
	}
#endif
#if ddnjdn
static void goto_( ref b_state b )
	{
	request( ref stateset[b.z] ) ;
	Reduction r ;
	if( this_state.transitionset.Length == 0 )
		{
		if( this_state.reductionset.Length == 1 )
			{
			r = this_state.reductionset[0] ;
			if( this_state.itemset.Length == 1 )
				{
				Itemset item = this_state.itemset[0] ;
				Xo xo ;
				if( item.point < xo_t[item.rule].rhs.Length )
					xo = xo_t[item.rule][item.point] ;
				else
					xo = xo_t[item.rule] ;
				b.c = (char)xo ;
				return ;
				}
			else
				foreach( Itemset item in this_state.itemset )
					{
					if( ! r.Default( item.rule ) )
						continue ;
					Xo xo ;
					if( item.point < xo_t[item.rule].rhs.Length )
						xo = xo_t[item.rule][item.point] ;
					else
						xo = xo_t[item.rule] ;
					b.c = (char)xo ;
					return ;
					}
			throw new NotImplementedException() ;
			}
		else
			{
			r = this_state.reductionset[this_state.reductionset.Length-1] ;
			foreach( Itemset item in this_state.itemset )
				{
				if( ! r.Default( item.rule ) )
					continue ;
				Xo xo ;
				if( item.point < xo_t[item.rule].rhs.Length )
					xo = xo_t[item.rule][item.point] ;
				else
					xo = xo_t[item.rule] ;
				b.c = (char)xo ;
				return ;
				}
			throw new NotImplementedException() ;
			}
		}
	else
	if( this_state.transitionset.Length == 1 )
		{
		if( this_state.reductionset.Length == 0 )
			{
			Itemset item = this_state.itemset[0] ;
			Xo xo ;
			if( item.point < xo_t[item.rule].rhs.Length )
				xo = xo_t[item.rule][item.point] ;
			else
				xo = xo_t[item.rule] ;
			b.c = (char)xo ;
			return ;
			}
		else
			foreach( Itemset item in this_state.itemset )
				{
				Xo xo ;
				if( item.point < xo_t[item.rule].rhs.Length )
					xo = xo_t[item.rule][item.point] ;
				else
					xo = xo_t[item.rule] ;
				if( b.c != (int)xo )
					continue ;
				return ;
				}
		throw new NotImplementedException() ;
		}
	else
		{
		if( b.c == _default )
			b.c = input().c ;
		if( reduction( b.c, out r ) )
			foreach( Itemset item in this_state.itemset )
				{
				Xo xo ;
				Transition t ;
				if( item.point < xo_t[item.rule].rhs.Length )
					xo = xo_t[item.rule][item.point] ;
				else
					xo = xo_t[item.rule] ;
				if( transition( b.c, out t ) )
					{
					b.Goto( b.x, b.y, t.state, _default ) ;
					}
				else
					throw new NotImplementedException() ;
				return ;
				}
		else
			if( reduction( _default, out r ) )
				foreach( Itemset item in this_state.itemset )
					{
					Xo xo ;
					Transition t ;
					if( ! r.Default( item.rule ) )
						continue ;
					if( item.point < xo_t[item.rule].rhs.Length )
						xo = xo_t[item.rule][item.point] ;
					else
						xo = xo_t[item.rule] ;
					if( b.c == _default && r.Default( item.rule ) )
						{
						b.c = (char)xo ;
						if( transition( b.c, out t ) )
							{
							b.Goto( b.x, b.y, t.state, _default ) ;
							}
						else
							throw new NotImplementedException() ;
						return ;
						}
					else
						continue ;
					return ;
					}
		}
	throw new NotImplementedException() ;
	}
#endif

#if SJNSJNS
static void goto_( ref b_state b ) //_FIX:x,c
	{
	request( ref stateset[b.z] ) ;
	Reduction r ;
	Transition t ;
	if( reduction( _default, out r ) )          //_accepted_real#_default,duality_type,(char_mouth_o,int_foot_lr)
		{
		if( b.c == _default )
			b.c = (char)xml_translate[input().c] ;
		Reduction rr ;
		if( reduction( b.c, out rr ) )
			throw new NotImplementedException( "reduce/reduced." ) ;
		
		foreach( Itemset item in this_state.itemset )
			{
			if( ! r.Default( item.rule ) )
				continue ;
			Xo xo = xo_t[item.rule] ;
			if( ! transition( (char)xo, out t ) )
				{
				if( b.c == xo )
					throw new NotImplementedException( "0 trans" ) ;
				break ;
				}
			if( this_state.lookaheadset.Count == 0 )
				{
				b.Goto( r, b.y, t.state, b.c ) ;
				request( ref stateset[b.z] ) ;
				//_return
				}
			break ;
			}
		//throw new NotImplementedException( "no items match" ) ;
		
		}
	if( ! transition( b.c, out t ) )
		{
		if( this_state.transitionset.Length == 0 )
				return ;
		if( this_state.transitionset[0].type == "shift" )
			{
			_.Token token = input() ;
			b.c = (char)xml_translate[token.c] ;
			//_...:_text
			if( ! transition( b.c, out t ) )
				throw new NotImplementedException( "no transitions match" ) ;
			foreach( Itemset item in this_state.itemset )
				{
				Xo xo ;
				if( item.point < xo_t[item.rule].rhs.Length )
					xo = xo_t[item.rule][item.point] ;
				else
					{
					xo = xo_t[item.rule] ;
					}
				if( t == xo ) // lookahead?
					{
					
					b.Goto( b.x, b.y, t.state, b.c ) ;
					return ;
					}
				}
			throw new NotImplementedException(" goto $end ; " ) ;
			}
		else
			throw new NotImplementedException( "no transitions matched" ) ;
		}

	Console.SetCursorPosition(0,2) ;
	Console.Write( this_state ) ;
	{}	//throw new NotImplementedException( "ok..." ) ;
	
	foreach( Itemset item in this_state.itemset )
		{
		Xo xo ;
		if( item.point < xo_t[item.rule].rhs.Length )
			xo = xo_t[item.rule][item.point] ;
		else
			{
			xo = xo_t[item.rule] ;
			}
		if( t == xo ) // lookahead?
			{
			
			b.Goto( b.x, b.y, t.state, _default ) ;
			return ;
			}
		}
	throw new NotImplementedException(" goto $end ; " ) ;
	}
#endif
	
#if SJNSJN
	Console.WriteLine( "{0}{1}",m , xo_t[rr] ) ;
	Transition t ;
	Console.WriteLine( b.c ) ;
	bool m = transition( (char)xo_t[0], out t ) ;
	Console.WriteLine( "{0}{1}",m , t ) ;
	if( m )
		{
		Console.WriteLine() ;
		}
	foreach( Itemset item in this_state.itemset )
		{
		if( item.point < xo_t[item.rule].rhs.Length )
			xo = xo_t[item.rule][item.point] ;
		else
			xo = xo_t[item.rule] ;
		/*
		foreach( Transition t in this_state.transitionset )
			{
			if( t == xo )
				{
				b_state c = b ;
				if( t.type == "shift" )
					{
					_.Token token = input() ;
					//_FIX:_xml_text_?
					c.c = token.c ;
					}
				c.z = t.state ;
				//c.y++;// = 0 ;
				//c.x++ ;
				goto_( c ) ;
				request( ref stateset[b.z] ) ;
				}
			}
		*/
		if( b.c == '$' )
			{
			//_.prompt(new _.Token(b.c,xo.ToString()) );
			}
		
		if( b.c == xo )
			goto reduce ;
		_.prompt(_.string_t) ;
		}
	return ;
	reduce:
	foreach( Reduction r in this_state.reductionset )
		{
		if( r.symbol == xo )
			{
			//Console.Write( "!" ) ;
			return ;
			}
		}
#endif
	

static void B_end()
	{
	}

		
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
_.soundex.up(__ipvsix)_idle[,]/\_.    //_FIXT:_=b_atomatrix(__),_no_loop(polygen.down...)
//_.elevation.down(dome)
#region macro
_.gc.down.on.NET   //_FIXT:cc
A
B
(_.internet.up)
#endregion macro
}
