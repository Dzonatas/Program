using System;
using System.Xml ;
using System.Text ;
using System.IO ;
using System.Collections.Generic ;
using System.Net ;

public partial class A335
{
static object sphere_nt_ ;
//[static] sphere_t ; //_FIXT:_nt[(|^)_t] (-> reverse(d).errOR) (<system/d=...>_err[]</d>) /*err:#((auto-)contract(<NOUN>,'-ion') ""*/

static object s_cl__t ; //__FIXT:(E1..:)abend:(__)swp,"...": "(swp) -> ./#/.urn" ;

static public void START()
	{
	if( system.guid == null )
		{
		xml_load_grammar() ;
		byte []    b = system_ip.GetAddressBytes() ;
		Array.Reverse( b ) ;
		/*
		system       = b_enter( b[3], b[2], b[1], b[0] ) ;
		system.guid  = Guid.Empty ;
		*/
		}
	}
	
static public /* used */  Item    system = new Item() ; // auto-registry, File system_file_x...
static internal      IPAddress system_ip = IPAddress.Any ;
static Stack<Item>                 stack = new Stack<Item>() ;
static State []                 stateset = new State[1125] ;

public struct State                //_FIX:$State,_State,_State:=$State,$State!=_State
	{
	public Number        debit ;
	public Itemset []    itemset ;
	public Transition [] transitionset ;
	public List<int>     lookaheadset ;
	public Reduction []  reductionset ;
	public Nullable<int> default_item ;
	public Nullable<int> default_reduction ;
	public List<object>  zlog ;
	public List<string> zla
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

static Symbol sym_token ;
static State  sym_state ;
static string sym_text ;
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
	public class generator
		{
		public string cartesian
			{
			get { return "a² = x² + y² + z²" ; } //a=r
			}
		public string parameters
			{
			get { return "[x,y,z](u,v) = [ cos(u)sin(v)a , sin(u)sin(v)a , cos(v)a ]" ; }
			//tessellation:{ u=2πn/N ; v=πm/M ; m=[1±polarity,M±polarity) ; n=[1,N) }
			}
		public _.Token artifact
			{
			get { return new _.Token( 'ʄ' , cartesian ) ; }
			}
		}
	}
	