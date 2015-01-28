public partial class A335
{
static System.Nullable<Tokenset.Token>  /*t_##*/token ; ///lowercased.Any(_atomatrix:IP)
static State              this_state ;
static Xo_t               this_xo_t ;
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
		ulong v1 = (ulong)t.item.rule ;
		ulong v2 = (ulong)t.item.point ;
		int   vs = t.state ;
		ulong v3 = (v1 << 32) | (v2 << 16) | (ulong)vs ;
		return v3 ;
		}
	static public explicit operator string( Transition t )
		{
		return string.Format( "{0}, {1}, {2}", t.item.rule, t.item.point, t.state ) ;
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
