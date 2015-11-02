partial class A335
{
string rune__ ; /*C`_ -rc:"BRANCH" +volume:0.00*/
static int root_n ; //<KNOWN> | root: <NOUN default="FILE:" refinery-technique-profile=""/>//
string rune___; /*C`__ -volume:0.00 (+"rc:") */
//const int __swp_regex_d ; /* lexical-skew: 'vim was always in re-lexicate screen-mode, vi was not.' */



#if OLD_ITEM
static void request( ref Item i )
	{
	if( i.stacked )
		throw new System.NotImplementedException( "Did, done." ) ;

	if( system.Equals(i) && ! requested_system )
		{
		requested_system = true ;
		_.assimulation() ;
		}
						
	i.stacked = true ;
	i.bit.One = false ;
	stack.Push( i ) ;
	//if( object.ReferenceEquals(i.symbol,yytoken) )
	//	yytoken = new Symbol() ;
	//System.Console.WriteLine( "$$ <- {0}   ", i ) ;
	//print_stack() ;
	}

static Item respond()
	{
	Item i = (Item)stack.Pop() ;
	//if( i.symbol.StringIsNull && yytoken.StringIsNull )
	//	xml_get_() ;
	//System.Console.WriteLine( "$$ -> {0}   ", i ) ;
	//print_stack() ;
	i.bit.One = false ;
	return i ;
	}
#endif

#if BEGINNING
public class ReducedAcception : System.Exception
	{
	public int     rule ;
	public int     backup ;
	public ReducedAcception( int rule )
		{
		this.rule = rule  ;
		this.backup = Rule.Set[rule].RHS.Length ;
		}
	public override string ToString()
			{
			return string.Format("[ReducedAcception={0}]{1}",backup,xo_t[rule]);
			}
	}
#endif

/*
static bool reduction( int c, out Reduction rr )
	{
	foreach( Reduction r in this_state.Reductionset )
		if( r == c )
			{
			rr = r ;
			return true ;
			}
	rr = new Reduction() ;
	return false ;
	}
*/	

/*
#region micro
<URN.URL> | 'remote' 'var'
#endregion micro
*/
}
