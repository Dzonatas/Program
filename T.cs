public partial class A335
{
static System.Nullable<_.Token>  /*t_##*/token ; ///lowercased.Any(_atomatrix:IP)
static State              this_state ;
static Xo_t               this_xo_t ;
static string             this_method_name ;
static string             this_sigArg_types ;
static string             this_class_id ;
static string             this_start_class ;
static string             this_instr ;
static string             this_instr_list ;
static string             this_program ;
static string             this_methodName ;
static string             this_string ;
static int                this_stack_offset ;
static int                this_sigArgs ;
static string             this_method_type ;
static string             this_instr_type ;
static int                this_method_sigArgs ;
static string             this_method_sigArg_types ;
static int                this_instr_sigArgs ;
static string             this_instr_sigArg_types ;
static bool               this_method_static ;
static bool               this_callConv_instance ;
static int                this_maxstack ;
static bool               this_instr_callConv_instance ;
static bool               this_method_callConv_instance ;
static string             this_instr_symbol ;
static string             this_instr_class_symbol ;
static string             this_class_symbol ;

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
