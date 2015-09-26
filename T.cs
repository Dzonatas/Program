public partial class A335
{
static System.Nullable<Tokenset.Token>  /*t_##*/token ; ///lowercased.Any(_atomatrix:IP)
static State              this_state ;
public static IRule       this_rule ;
static string             this_string ;

public struct Transition
	{
	public string  type   ;
	public int     symbol ;
	public int     state  ;
	public Itemset item   ;
	static public implicit operator System.Decimal( Transition t )
		{
		return stateset[t.state] ;
		}
	static public implicit operator int( Transition t )
		{
		return t.symbol ;
		}
	static public implicit operator ulong( Transition t )
		{
		return ((ulong)t.item.rule << 32)
			| ((ulong)t.item.point << 16)
			| (ulong)t.state ;
		}
	static public explicit operator string( Transition t )
		{
		string s1 = "_"+
			( ( t.item.rule < 10 ) ? "___"
			: ( t.item.rule < 100 ) ? "__"
			: "_"
			) ;
		string s2 = "_"+
			( ( t.item.point < 10 ) ? "_" : "" ) ;
		string s3 = "_"+
			( ( t.state < 10 ) ? "___"
			: ( t.state < 100 ) ? "__"
			: ( t.state < 1000 ) ? "_"
			: ""
			) ;
		return s1+t.item.rule+s2+t.item.point+s3+t.state ;
		}
	public override string ToString()
		{
		return string.Format( "({0},{1},{2},{3})", type, symbol, state,item ) ;
		}
	}
	
static bool transition( int i, out Transition tr )
	{
	foreach( Transition t in this_state.Transitionset )
		if( t == i )
			{
			tr = t ;
			return true ;
			}
	tr = new Transition() ;
	return false ;
	}


/*
#region micro
<throw.flag></> | //(<s>.</t=(key)>)
<TRANSIENT></t> | ____`-ary
&&Earth;.byte;  | URN:"TERABYTE"
&&Earth;.byte;  | URN:"TRILLONTH-BYTE"
#region micro
*/
}
