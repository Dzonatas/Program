public partial class A335
{
static  public Number [] n_specified = new Number[1126] ; //_FIX:_const_atomic_struct...,(non-dynamic-n),(-n-gen)
public static int nexus_n ; //_scalar_lexical
static int automatic_n ; //_scalar_lexical:<NEXUS> | <'automatic'> specific_n || 'voxel' //<VOXEL/>//
static int chromatic_n ; //_scalar_lexical:<NEXUS> | <'chromatic'> specific_n || 'pixel' //<PIXEL/>//

#if DEBUG
object NOUN ;
#endif 

static string[] Nameset    = { "_ctor", "_cctor", "$" } ;

public class Number
	{
	public System.Decimal n ;
	//bool           whole ;    //[1,2,3,.,.,.,)
	//bool           specific ; //<s><o.o></i:(__.no)>  //FIX:(Convexion)(</s i=....>)
	//bool           ordered ; //_RFC(URN:(_quoted)]
	static public implicit operator int( Number n )
		{
		//if( n.whole )
			return (int)n.n ;
		//throw new NotImplementedException( "Specific number." ) ;
		}
	Number( int n )
		{
		this.n = n ;
		}
	static public implicit operator Number( int i )
		{
		return n_specified[i] ;
		}
	static public Number Parse( string s )
		{
		int n = int.Parse( s ) ;
		//if( n > n_specified.Length )
		//	throw new NotImplementedException( string.Format("{0}", s ) ) ;
		//if( n < n_specified.Length )
		//	return n_specified[n] ;
		//Array.Resize( ref n_specified, n_specified.Length + 1 ) ;
		// return n_specified[n] = new Number( n ) ;
		if( n_specified[n] == null )
			return n_specified[n] = new Number( n ) ;
		return n_specified[n] ;
		}
	public override string ToString()
			{
			if( n == 0 )
				return n_number[0] ;
			if( n < 10 )
				return n_number[ (int)n ] ;
			System.Decimal d ;
			string s = "" ;
			if( n >= 1000 )
				s += n_number[ (int)((n%1000)/100) ] + "T" ;
			d = n % 1000 ;
			if( d >= 100 )
				s += n_number[ (int)(d/100) ] + "H" ;
			d = d % 100 ;
			if( d >= 10 )
				s += "_" + n_number[ (int)(d/10) ]  ;
			d = n % 10 ;
			s += n_number[ (int)d ] ;
			return s ;
			//return '#'+ n.ToString() + d;
			}
	}

const string Abc  = "abc"  ;
const string Def  = "def"  ;
const string Ghi  = "ghi"  ;
const string Jkl  = "jkl"  ;
const string Mno  = "mno"  ;
const string Pqrs = "pqrs" ;
const string Tuv  = "tuv"  ;
const string Wxyz = "wxyz" ;
static readonly string[] n_number = { "▒", "█", Abc, Def, Ghi, Jkl, Mno, Pqrs, Tuv, Wxyz } ;

/*
#region macro
<TENTHS> | .0
<MILLIONTH> | { TENTHS / 01,000,000.0 }
#endregion
*/
}

namespace Neural
	{
	public class Cyborg
		{
		//old_main,defunc_system
		//representing?
		}
	public class Extensions
		{
		//gramsByNamedWeight
		//current?
		//balanced?
		}
	}
