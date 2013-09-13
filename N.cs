using System;

public partial class A335
{
static  public Number [] n_specified = new Number[1126] ; //_FIX:_const_atomic_struct...,(non-dynamic-n),(-n-gen)
public static int nexus_n ; //_scalar_lexical
static int automatic_n ; //_scalar_lexical:<NEXUS> | <'automatic'> specific_n || 'voxel' //<VOXEL/>//
static int chromatic_n ; //_scalar_lexical:<NEXUS> | <'chromatic'> specific_n || 'pixel' //<PIXEL/>//

#if DEBUG
object NOUN ;
#endif 
	
public class Number
	{
	public Decimal n ;
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
				return "$default" ;
			if( n < 10 )
				return r_number( (int)n ) ;
			Decimal d ;
			string s = "" ;
			if( n >= 1000 )
				s += n_number( (int)((n%1000)/100) ) + "T" ;
			d = n % 1000 ;
			if( d >= 100 )
				s += n_number( (int)(d/100) ) + "H" ;
			d = d % 100 ;
			if( d >= 10 )
				s += "_" + n_number( (int)(d/10) )  ;
			d = n % 10 ;
			s += n_number( (int)d ) ;
			return s ;
			//return '#'+ n.ToString() + d;
			}
	}

static string n_number( int n )
	{
	switch( n )
		{
		case 0 : return "_" ;
		case 1 : return "One" ;
		case 2 : return "Two" ;
		case 3 : return "Three" ;
		case 4 : return "Four" ;
		case 5 : return "Five" ;
		case 6 : return "Six" ;
		case 7 : return "Seven" ;
		case 8 : return "Eight" ;
		case 9 : return "Nine" ;
		default: throw new NotImplementedException() ;
		}
	}
	
/*
#region macro
<TENTHS> | .0
<MILLIONTH> | { TENTHS / 01,000,000.0 }
#endregion
*/
}
