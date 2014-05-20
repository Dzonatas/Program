using System.Collections.Generic ;
using System.Net ;
using System ;

public partial class A335
{
static object sphere_nt_ ;
//[static] sphere_t ; //_FIXT:_nt[(|^)_t] (-> reverse(d).errOR) (<system/d=...>_err[]</d>) /*err:#((auto-)contract(<NOUN>,'-ion') ""*/

static object s_cl__t ; //__FIXT:(E1..:)abend:(__)swp,"...": "(swp) -> ./#/.urn" ;

class _START : Automatrix {}

struct StringTheory
	{
	int     integer  ;
	string  string_  ;
	uint    capacity ;
	//bool  null_terminated ;
	//bool  terminal ;
	} //_reserved_;

#if SYSTEM_GUID
static        /* used */  Item    system = new Item() ; // auto-registry, File system_file_x...
#endif
static internal      IPAddress system_ip = IPAddress.Any ;
static State []                 stateset = new State[1125] ;

class Stack
	{
	static System.Collections.Generic.Stack<Item> stack = new System.Collections.Generic.Stack<Item>() ;
	public class Item
		{
		public Xo_t Rule ;
		public Item()
			{
			Rule = this_xo_t ;
			}
		public class Token : Item
			{
			public planet  State ;
			public _.Token _Token ;
			public Token( planet _0, _.Token _1 ) : base()
				{
				State = _0 ;
				_Token = _1 ;
				}
			static public explicit operator string( Token t )
				{
				return t._Token._ ;
				}
			public override string ToString()
				{
				return _Token.ToString() ;
				}
			}
		public class Empty : Item
			{
			public string Assertive ;
			public Empty( string assertive ) : base()
				{
				Assertive = assertive ;
				}
			public override string ToString()
				{
				return "[Empty] " + Assertive ;
				}
			}
		}
	static public void Dump()
		{
		while( stack.Count > 0 )
			{
			object o = stack.Pop() ;
			if( o is object[] )
				foreach( object i in (object[])o )
					log( "[stack.o#] "+ ( i == null ? "null" : i).ToString() ) ;
			else
				log( "[stack] "+o.ToString() ) ;
			}
		}
	static public void Push( Item o )
		{
		stack.Push( o ) ;
		}
	static public void Push( object[] o )
		{
		stack.Push( (Object) o[0] ) ;
		}
	static private object stack_pop()
		{
		object o = stack.Pop() ;
		string s ;
		if( o is object[] )
			{
			s = "{ " ;
			foreach( object i in (object[])o )
				s += ( i == null ? "null" : i ).ToString() + " , ";
			}
		else
			s = o.ToString() ;
		log( "[pop] " + s ) ;
		return o ;
		}
	static private object peak
		{
		get { return stack.Count > 0 ? stack.Peek() : null ; }
		}
	static private bool peakIsNull
		{
		get { return peak == null ; }
		}
	static private bool peakIsItemToken
		{
		get { return peak is Item.Token ; }
		}
	static private bool peakIsObject
		{
		get { return peak is Object ; }
		}
	static private bool peakIsArray
		{
		get { return peak is object[] ; }
		}
	static public object[] Pop()
		{
		throw new System.NotImplementedException() ;
		}
	static public void Pop( ref object[] o )
		{
		for( int i = o.Length - 1 ; i > 0 ; i-- )
			{
			if( peakIsNull )
				o[i] = null ;
			else
			if( peakIsItemToken )
				{
				Item.Token t = peak as Item.Token ;
				string rhs = this_xo_t.rhs[i-1].s ;
				if( rhs[0] == '\'' )
					{
					if(	rhs[1] == t._Token._[0] )
						o[i] = stack_pop() as Stack.Item.Token ;
					else
						o[i] = new Item.Empty( "rhs==" + rhs + "  stack==" + t._Token._ ) ;
					}
				else
				if( rhs[0] == '"' )
					{
					if( rhs == '"'+t._Token._+'"' )
						o[i] = stack_pop() as Stack.Item.Token ;
					else
						o[i] = new Item.Empty( "rhs==" + rhs + "  stack==" + t._Token._ ) ;
					}
				else
				if( rhs[0] == '$' )
					{
					if( rhs == t._Token._ )
						o[i] = stack_pop() as Stack.Item.Token ;
					else
						o[i] = new Item.Empty( "rhs==" + rhs + "  stack==" + t._Token._ ) ;
					}
				else
					{
					if( rhs == rhs.ToUpper() )
						o[i] = stack_pop() as Stack.Item.Token ;
					else
						o[i] = new Item.Empty( "rhs==" + rhs + "  stack==" + t._Token._ + " (not UPPER)" ) ;
					}
				}
			else
			if( peakIsObject )
				{
				Object p = peak as Object ;
				string lhs = ((Xo_t)(p.Rule)).lhs.s ;
				string rhs = this_xo_t.rhs[i-1].s ;
				if( lhs == rhs )
					o[i] = stack_pop() as Object ;
				else
					{
					log( "[Stack.Pop] lhs="+lhs+"   rhs="+rhs ) ;
					o[i] = new Item.Empty( "lhs="+lhs+"   rhs="+rhs ) ;
					}
				}
			else
			if( peakIsArray )
				{
				object[] p = peak as object[] ;
				string lhs = ((Xo_t)(p[0])).lhs.s ;
				string rhs = this_xo_t.rhs[i-1].s ;
				if( lhs == rhs )
					o[i] = new Object( stack_pop() as object[] ) ;
				else
					{
					log( "[Stack.Pop] lhs="+lhs+"   rhs="+rhs ) ;
					o[i] = new Item.Empty( "lhs="+lhs+"   rhs="+rhs ) ;
					}
				}
			else
				throw new System.NotImplementedException( "Unknown type on stack." ) ;
			}
		}
	}

public struct State                //_FIX:$State,_State,_State:=$State,$State!=_State
	{
	public Number               debit ;
	public Itemset []           itemset ;
	public Transition []        transitionset ;
	public Dictionary<int,int>  shiftset ;
	public Dictionary<int,int>  gotoset ;
	public List<int>            lookaheadset ;
	public Reduction []         reductionset ;
	public Nullable<int>        default_item ;
	public Nullable<int>        default_reduction ;
	public List<string>         zla
		{
		get { return list() ; }
		}
	
	public List<string> list()
		{
		List<string> l = new List<string>() ;
		foreach( int i in lookaheadset )
			{
			foreach( KeyValuePair<string,xml_token> kv in xml_tokenset )
				{
				if( i == (int)(xml_token)kv.Value )
					{
					l.Add( kv.Value.ToString() ) ;
					break ;
					}
				}
			}
		return l ;
		}
	
	static public implicit operator Decimal( State s )
		{
		return s.debit ;
		}
	static public explicit operator int( State s )
		{
		return (int)s.debit ;
		}
	public override string ToString()
		{
		return debit.ToString() ;
		}
	}

class SigArg
	{
	static SigArg instance = new SigArg() ;
	List<string> type = new List<string>() ;
	List<string> name = new List<string>() ;
	public SigArg() {}
	static public List<string> Typeset
		{
		get { return instance.type ; }
		}
	static public List<string> Nameset
		{
		get { return instance.type ; }
		}
	static void add( string type, string name )
		{
		instance.type.Add( type ) ;
		instance.name.Add( name ) ;
		}
	static public void Clear()
		{
		instance.type.Clear() ;
		instance.name.Clear() ;
		}
	static public int Count()
		{
		return instance.type.Count ;
		}
	static public string Types()
		{
		string i = null ;
		foreach( string s in instance.type )
			i += "$" + s ;
		return i ;
		}
	[Automaton] class   sigArg_paramAttr_type
		: Automatrix	{
		protected override void main()
			{
			add( Arg2.ResolveType(), null ) ;
			}
		}
	[Automaton] class   sigArg_paramAttr_type_id
		: Automatrix {
		protected override void main()
			{
			add( Arg2.ResolveType(), Arg3.Token ) ;
			}
		}
	[Automaton] class   sigArgs1_sigArgs1_____sigArg
		: Automatrix	{}
	[Automaton] class   sigArgs1_sigArg
		: Automatrix	{}
	[Automaton] class   sigArgs0_sigArgs1
		: Automatrix {}
	}

partial class Program
	{
	static List<Microdata> stack = new List<Microdata>() ;
	static int stack_offset ;
	static int stack_down ;
	//static uint effective_symbolic_objective_credit ;
	public int StackOffset
		{
		get { return stack_offset - stack_down ; }
		}
	public void Push( Microdata stack_item_data )
		{
		stack[stack_offset] = stack_item_data ;
		stack_offset++ ;
		}
	public void Push1( C_Type string_line_x )
		{
		Push( new Microdata( 1, String.Empty, string_line_x ) ) ;
		}
	public void Push( C_Type string_line )
		{
		Push( new Microdata( 0, null, string_line ) ) ;
		}
	public void Push( string type )
		{
		Push( C_Type.Acquire( type ) ) ;
		}
	public object Pop()
		{
		stack_offset-- ;
		return stack[stack_offset+1] ;
		}
	public void Hangup( int iargs )
		{
		stack_offset -= iargs ;
		}
	public void Hangdown()
		{
		stack_down = stack_offset ;
		}
	public int MaxStack
		{
		set {
			if( stack_offset + value > stack.Count )
				{
				stack.Capacity += value ;
				for( int i = 0 ; i < value ; i++ )
					stack.Add( null ) ;
				}
			}
		}
	}

public struct Symbol                //_FIX:$Symbol,_Symbol,.ibid
	{
	public Number  credit ;
	object         oo ;

	public override string ToString()
		{
		return "$"+credit.ToString()+oo.ToString()+"$" ;
		}
	static public implicit operator char( Symbol s )
		{
		return (char)s.oo ;
		}
	static public implicit operator Symbol( string s )
		{
		return symbol_from_name[s] ;
		}
	static public bool operator !=( Symbol s, string ss )
		{
		return true ;
		}
	static public bool operator ==( Symbol s, string ss )
		{
		if( s.oo is string ) return s.oo.Equals(ss) ;
		if( s.oo is object [] )
			{
			object [] ooa = (object [])s.oo ;
			if( ooa[1] is string ) return ooa[1].Equals(ss) ;
			}
		return s.Equals( (object)ss ) ;
		}
	public string Name
		{
		get {
			if( oo == null ) return null ;
			if( oo is xml_t ) return ((xml_t)oo).name.s ;
			if( oo is xml_nt ) return ((xml_nt)oo).name.s ;
			//if( oo is object [] ) return (string)((object[])oo)[1] == null ;
			throw new NotImplementedException( "Obvious." ) ;
			}
		}
	public bool StringIsNull
		{
		get {
			if( oo == null ) return true ;
			if( oo is xml_t ) return ((xml_t)oo).name.s == null ;
			if( oo is xml_nt ) return ((xml_nt)oo).name.s == null ;
			//if( oo is object [] ) return (string)((object[])oo)[1] == null ;
			if( oo is int )
				return false ;
			throw new NotImplementedException( "Obvious." ) ;
			}
		}
	private Symbol( Number credit, object o )
		{
		this.credit   = credit ;
		this.oo       = o ;
		//symbol_from_number.Add( credit , this ) ;
		}
		/*
	public Symbol( Number credit, Number token, string name, bool terminal )
		: this( credit, new object [] {token, name}, terminal )
		{
		symbol_from_number.Add( credit , this ) ;
		symbol_from_name.Add( name , this ) ;
		symbol_from_token.Add( token , this ) ;
		}*/
	}

//static Dictionary<Number,Symbol>    symbol_from_number = new Dictionary<Number, Symbol>() ;
static Dictionary<Number,Symbol>    symbol_from_token = new Dictionary<Number, Symbol>() ;
//static Dictionary<Number,Symbol>    symbol_from_null_token = new Dictionary<Number, Symbol>() ;
static Dictionary<string,Symbol>    symbol_from_name = new Dictionary<string, Symbol>() ;

}

	
namespace Spatial.Mesh
	{
	public class atomics
		{
		public atomics()
			{
			throw new NotSupportedException("Try arithmetic types with icons as nodes.") ;
			}
		}
	}

namespace Spherical.Mesh
	{
	static class generator
		{
		static readonly Decimal []      N = new Decimal[64] ;
		static readonly object          shaped ;
		static System.IO.MemoryStream   mesh ;
		static string cartesian
			{
			get { return "a² = x² + y² + z²" ; } //a=r
			}
		static string parameters
			{
			get { return "[x,y,z](u,v) = [ cos(u)sin(v)a , sin(u)sin(v)a , cos(v)a ]" ; }
			//tessellation:{ u=2πn/N ; v=πm/M ; m=[1±polarity,M±polarity) ; n=[1,N) }
			}
		static _.Token artifact
			{
			get { return new _.Token( 'ʄ' , cartesian ) ; }
			set { artifact = value ; }
			}
		static generator()
			{
			mesh = new System.IO.MemoryStream() ;
			for( int i = 0 ; i < N.Length ; i++ )
				N[i] = i ;
			//{array:[Guid,4k]}>{node:#,#,#,...}//RFC:(well-known):X509(:plain-text:datestamped-by-entity)
			//foreach(Decimal...n}
			//foreach(face...array)
			//if(faces.are.square)
				shaped = '∛' ;
			//if(faces.are.polygonal)
				shaped = '⏚' ;
			System.GC.KeepAlive( environment.dated ) ;
			}
		public static class environment
			{
			static public readonly bool     spin ;
			static public readonly Decimal  X, Y, Z, U, V ;
			static public readonly DateTime dated ;
			static environment()
				{
				spin = false ;
				X = Y = Z = U = V = 0.0m ;
				#if X509 || !BSD
				dated = System.DateTime.Now ;
				System.GC.KeepAlive( shaped.GetHashCode() ) ;
				//mesh.Write( ʄ.rez(), 0,  ʄ.axyz() ) ;
				#else
				#if REST
				StreamWriter sw = new StreamWriter(mesh) ;
				foreach( Decimal n in N )
					foreach( Decimal m in N )
						A335.Main(new string[] { @"ʄnode-mn="+m.ToString()+","+n.ToString() } ) ;
				sw.Write( 0 ) ; //result:O(1)
				sw.Write( dated = System.DateTime.Now ) ;
				#else
				StreamWriter sw = new StreamWriter(mesh) ;
				foreach( Decimal n in N )
					foreach( Decimal m in N )
						sw.Write( 0 ) ; //result:O(N(N)) //ʄ(m,n) //Noted: github.com/Dzonatas/solution re:post,get,ReST
				sw.Write( dated = System.DateTime.Now ) ;
				#endif
				#endif
				}
			}
		}
	}

namespace Scuplted.Object
	{
	static public class Space
		{
		internal struct node
			{
			internal Decimal color ;
			internal object  item  ;
			}
		static node    [] colors = new node[0] ;
		static Decimal [] color  = new decimal[0] ;
		static object  [] items ;  //idols,reflections,wait-states-on-RT,ray-casted(concaves)
		}
	static class Objects
		{
		static object [] XYZ = {} ;    //_discrete_wavelets
		#if ARM
		static object [] XYZZYY = {} ; //_shaped_constraints,_aparatus("future items",traits,PCI-BUSS)
		#endif
		#if VFS
		static object [] dBus = {} ;   //_D-Bus,_kerning,_raw(_aligned)
		#endif
		}
	//[Suffix("-ing")]
	public class Build
		{
		//materials
		Int16       i13_3 ;    //_integral_fixed
		static bool busy ;
		public bool ing
			{
			get { return busy ; }   //_readonly_maybe_fixt
			}
		public Decimal Integer
			{
			#if PI_IS_IRRATIONAL
			#if ATM || EightyTwentyRule
			get {
				busy = true ;
				Int32 i = i13_3 ; i <<= 3 ;
				string yytoken = (Decimal)(i) ;
				try {
					yytoken = yytoken.Split(".")[1] ; //0.377|(mask|octals)
					busy = false ;
					return yytoken ;
					}
				catch
					{
					throw ;
					}
				}  //_spelled,_!GNUs
			#else
			get { Int32 i = i13_3 ; i <<= 3 ; return (Decimal)(i) >> 3m ; }  //_GNUs,implicit_(new)_content_unless_CPP'd
			#endif
			#else
			get { Int32 i = i13_3 ; i <<= 3 ; return (Decimal)(i)*.001m ; }  //_GNUs,implicit_(new)_content_unless_CPP'd
			#endif
			}
		}
	}
