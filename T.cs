public partial class A335
{
static System.Nullable<_.Token>  /*t_##*/token ; ///lowercased.Any(_atomatrix:IP)
static State              this_state ;
static Xo_t               this_xo_t ;
static string             this_method_name ;
static string             this_method_type ;
static string             this_class_id ;
static string             this_start_class ;
static string             this_instr ;
static string             this_instr_list ;
static string             this_program ;
static string             this_methodName ;
static string             this_className ;

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
	public override string ToString()
			{
			return string.Format( "({0},{1},{2},{3})", type, symbol, state,item ) ;
			}
	}
	
static bool transition( int i, out Transition tr )
	{
	foreach( Transition t in this_state.transitionset )
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
