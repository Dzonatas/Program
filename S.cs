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
	static global::Item[] stack = new global::Item[0] ;
	public class Item : global::Item
		{
		public Rule Rule ;
		public Item()
			{
			this.Rule = this_rule ;
			}
		public class Token : Item
			{
			public planet  State ;
			public Tokenset.Token _Token ;
			public Token( planet _0, Tokenset.Token _1 ) : base()
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
	static void writeline()
		{
		if( args.Length == 0 )
			return ;
		switch( X.Auto["A"] )
			{
			#if DEBUG
			case "{.assembly":
				b_list += C699.C.Array.assembly.argv(args).asm + "; \n" ;
				break ;
			#endif
			default:
				X.Auto["argv"] = ", "+string.Join(", ", args)+", 0 }" ;
				b_list += Xo_t.put("fasm_c" ) ;
				break ;
			}
		args = new string[0] ;
		}
	static void write( string s )
		{
		Array.Resize( ref args, args.Length+1 ) ;
		args[args.Length-1] = '"'+s+'"' ;
		}
	static void write_( string s )
		{
		if( args.Length == 0 )
			return ;
		Array.Resize( ref args, args.Length+1 ) ;
		args[args.Length-1] = s ;
		}
	static string[] args = new string[0] ;
	static public void dump( Automatrix a )
		{
		if( args.Length == 0 )
			X.Auto["A"] = "{"+a.Arg0.Token ;
		for( int i = 1 ; i < a.Argv.Length ; i++ )
			{
			if( a.Argv[i] is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token)a.Argv[i] ;
				if( t[0] == '.' && t != ".ctor" && t != ".cctor" )
					{
					writeline() ;
					if( args.Length == 0 )
						X.Auto["A"] = "{"+a.Arg0.Token ;
					}
				write( t ) ;
				if( t[0] == '{' )
					writeline() ;
				}
			else
			if( a.Argv[i] is Automatrix )
				dump( a.Argv[i] as Automatrix ) ;
			else
			if( a.Argv[i] is Stack.Item.Empty )
				write_( "/*empty*/0" ) ;
			else
			if( a.Argv[i] == null )
				write_( "/*null*/0" ) ;
			else
				System.Console.Write( "["+a.Argv[i].GetType()+"]" ) ;
			}
		}
	static public void Dump()
		{
		X.Auto["A"] = "" ;
		foreach( global::Item o in stack )
			{
			if( o is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token)o ;
				if( t == "$end" )
					continue ;
				System.Console.WriteLine( "[stack.t] "+ t ) ;
				}
			else
			if( o is Automatrix )
				dump( o as Automatrix ) ;
			else
				System.Console.WriteLine( "[stack] "+o.ToString() ) ;
			}
		writeline() ;
		}
	static public void Push( Item o )
		{
		Array.Resize( ref stack, stack.Length+1 ) ;
		stack[stack.Length-1] = o ;
		}
	static public void Push( object[] o )
		{
		Array.Resize( ref stack, stack.Length+1 ) ;
		stack[stack.Length-1] = (Object) o[0] ;
		}
	static private object stack_pop()
		{
		object o = stack[stack.Length-1] ;
		Array.Resize( ref stack, stack.Length-1 ) ;
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
		get { return stack.Length > 0 ? stack[stack.Length-1] : null ; }
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
				string rhs = this_rule.rhs[i-1].s ;
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
				string lhs = ((Rule)(p.Rule)).lhs.s ;
				string rhs = this_rule.rhs[i-1].s ;
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
				string lhs = ((Rule)(p[0])).lhs.s ;
				string rhs = this_rule.rhs[i-1].s ;
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
	public System.Decimal     Number
		{
		get { return number ; }
		set {
			number            = value ;
			transitionset     = new Transition[0] ;
			shiftset          = new int[0,0] ;
			gotoset           = new int[0,0] ;
			itemset           = new Itemset[0] ;
			reductionset      = new Reduction[0] ;
			lookaheadset      = new int[0] ;
			from_states       = new int[0] ;
			default_item      = null ;
			default_reduction = null ;
			}
		}
	public Itemset []           Itemset               { get { return itemset ; } }
	public Transition []        Transitionset         { get { return transitionset ; } }
	public int [,]              Shiftset              { get { return shiftset ; } }
	public int [,]              Gotoset               { get { return gotoset ; } }
	public int []               Lookaheadset          { get { return lookaheadset ; } }
	public Reduction []         Reductionset          { get { return reductionset ; } }
	public Nullable<int>        Default_item          { get { return default_item ; } set { default_item = value ; } }
	public Nullable<int>        Default_reduction     { get { return default_reduction ; } set { default_reduction = value ; } }
	public int[]                FromStates            { get { return from_states ; } }
	System.Decimal       number ;
	Itemset []           itemset ;
	Transition []        transitionset ;
	int [,]              shiftset ;
	int [,]              gotoset ;
	int []               lookaheadset ;
	Reduction []         reductionset ;
	Nullable<int>        default_item ;
	Nullable<int>        default_reduction ;
	int []               from_states ;

	public void Append( int i )
		{
		System.Array.Resize(ref from_states, from_states.Length + 1 ) ;
		from_states[ from_states.Length - 1 ] = i ;
		}

	public void Append( Itemset i )
		{
		System.Array.Resize(ref itemset, itemset.Length + 1 ) ;
		itemset[ itemset.Length - 1 ] = i ;
		}

	public void Append( Transition t )
		{
		System.Array.Resize(ref transitionset,  transitionset.Length + 1 ) ;
		transitionset[  transitionset.Length - 1 ] = t ;
		}

	public void Append( Reduction r )
		{
		System.Array.Resize(ref  reductionset,  reductionset.Length + 1 ) ;
		reductionset[  reductionset.Length - 1 ] = r ;
		}

	public void Shiftset_Add( int _0, int _1  )
		{
		int[,] a = new int[shiftset.GetLength(0)+1,2] ;
		for( int i = 0 ; i < shiftset.GetLength(0) ; i++ )
			{
			a[i,0] = shiftset[i,0] ;
			a[i,1] = shiftset[i,1] ;
			}
		a[a.GetLength(0)-1,0] = _0 ;
		a[a.GetLength(0)-1,1] = _1 ;
		shiftset = a ;
		}

	public void Gotoset_Add( int _0, int _1  )
		{
		int[,] a = new int[gotoset.GetLength(0)+1,2] ;
		for( int i = 0 ; i < gotoset.GetLength(0) ; i++ )
			{
			a[i,0] = gotoset[i,0] ;
			a[i,1] = gotoset[i,1] ;
			}
		a[a.GetLength(0)-1,0] = _0 ;
		a[a.GetLength(0)-1,1] = _1 ;
		gotoset = a ;
		}

	public void Lookaheadset_Add( int lookahead )
		{
		System.Array.Resize( ref lookaheadset, lookaheadset.Length+1 ) ;
		lookaheadset[lookaheadset.Length-1] = lookahead ;
		}

	public void Set()
		{
		stateset[(int)number] = x_state ;
		}

	static public implicit operator Decimal( State s )
		{
		return s.number ;
		}
	static public explicit operator int( State s )
		{
		return (int)s.number ;
		}
	public override string ToString()
		{
		return number.ToString() ;
		}
	}

class SigArgs0 : Automatrix
	{
	SigArg list ;
	[Automaton] public class   sigArgs0_sigArgs1
		: SigArgs0
		{
		protected override void main()
			{
			list = SigArg.List ;
			}
		}
	public int Count()
		{
		int i = 0 ;
		for( SigArg s = list ; s is SigArg ; s = s.Next )
			i++ ;
		return i ;
		}
	public string Types()
		{
		string i = null ;
		for( SigArg s = list ; s is SigArg ; s = s.Next )
			{
			i += "$" + s._Type ;
			}
		return i ;
		}
	public void ForEach( Action<SigArg> action )
		{
		for( SigArg s = list ; s is SigArg ; s = s.Next )
			action( s ) ;
		}
	}

class SigArg : Automatrix
	{
	static SigArg current = null ;
	SigArg previous ;
	SigArg next ;
	internal protected C_Type _Type ;
	internal protected string _ID ;
	protected Argument Type
		{
		set { _Type = C_Type.Acquire( value.ResolveType() ) ; }
		}
	protected Argument ID
		{
		set { _ID = value.Token ; }
		}
	protected void Enlist()
		{
		previous = current ;
		current = this ;
		}
	static public SigArg List
		{
		get {
			SigArg i ;
			for( i = current ; i is SigArg ; i = i.previous )
				{
				if( i.previous == null )
					{
					current = null ;
					return i ;
					}
				else
					i.previous.next = i ;
				}
			return i ;
			}
		}
	public SigArg Next
		{
		get { return next ; }
		}
	public SigArg Previous
		{
		get { return previous ; }
		}
	[Automaton] public class   sigArg_paramAttr_type
		: SigArg	{
		protected override void main()
			{
			Type = Arg2 ;
			Enlist() ;
			}
		}
	[Automaton] public class   sigArg_paramAttr_type_id
		: SigArg {
		protected override void main()
			{
			Type = Arg2 ;
			ID   = Arg3 ;
			Enlist() ;
			}
		}
	[Automaton] public class   sigArgs1_sigArgs1_____sigArg
		: Automatrix	{}
	[Automaton] public class   sigArgs1_sigArg
		: Automatrix	{}
	}
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

namespace Spherical.Mesh //:(∅°<<π²)  //∅°:~="tilde zero"  //(πr²)!=(a²|[x,y,z](u,v))
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
		static Tokenset.Token artifact
			{
			get { return new Tokenset.Token( 'ʄ' , cartesian ) ; }
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
