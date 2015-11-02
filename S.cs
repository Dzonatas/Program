partial class A335
{
static object sphere_nt_ ;
//[static] sphere_t ; //_FIXT:_nt[(|^)_t] (-> reverse(d).errOR) (<system/d=...>_err[]</d>) /*err:#((auto-)contract(<NOUN>,'-ion') ""*/

static object s_cl__t ; //__FIXT:(E1..:)abend:(__)swp,"...": "(swp) -> ./#/.urn" ;

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
static internal      System.Net.IPAddress system_ip = System.Net.IPAddress.Any ;
}

	
namespace Spatial.Mesh
	{
	public class atomics
		{
		public atomics()
			{
			throw new System.NotSupportedException("Try arithmetic types with icons as nodes.") ;
			}
		}
	}

namespace Spherical.Mesh //:(∅°<<π²)  //∅°:~="tilde zero"  //(πr²)!=(a²|[x,y,z](u,v))
	{
	static class generator
		{
		static readonly System.Decimal []      N = new System.Decimal[64] ;
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
			static public readonly System.Decimal  X, Y, Z, U, V ;
			static public readonly System.DateTime dated ;
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
			internal System.Decimal color ;
			internal object  item  ;
			}
		static node    [] colors = new node[0] ;
		static System.Decimal [] color  = new decimal[0] ;
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
		System.Int16       i13_3 ;    //_integral_fixed
		static bool busy ;
		public bool ing
			{
			get { return busy ; }   //_readonly_maybe_fixt
			}
		public System.Decimal Integer
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
			get { System.Int32 i = i13_3 ; i <<= 3 ; return (System.Decimal)(i)*.001m ; }  //_GNUs,implicit_(new)_content_unless_CPP'd
			#endif
			}
		}
	}
