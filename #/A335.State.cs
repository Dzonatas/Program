partial class A335
{
static State []                 stateset = new State[1125] ;

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
	public System.Nullable<int> Default_item          { get { return default_item ; } set { default_item = value ; } }
	public System.Nullable<int> Default_reduction     { get { return default_reduction ; } set { default_reduction = value ; } }
	public int[]                FromStates            { get { return from_states ; } }
	System.Decimal       number ;
	Itemset []           itemset ;
	Transition []        transitionset ;
	int [,]              shiftset ;
	int [,]              gotoset ;
	int []               lookaheadset ;
	Reduction []         reductionset ;
	System.Nullable<int> default_item ;
	System.Nullable<int> default_reduction ;
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
		if( t.type == "shift" )
			addToShiftset( t.symbol, Transitionset.Length - 1 ) ;
		else
			addToGotoset( t.symbol, Transitionset.Length - 1 ) ;
		}

	public void Append( Reduction r )
		{
		System.Array.Resize(ref  reductionset,  reductionset.Length + 1 ) ;
		reductionset[  reductionset.Length - 1 ] = r ;
		}

	void addToShiftset( int _0, int _1  )
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

	void addToGotoset( int _0, int _1  )
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
		if( number >= stateset.Length )
			System.Array.Resize( ref stateset, (int)number+1 ) ;
		stateset[(int)number] = x_state ;
		}

	static public implicit operator System.Decimal( State s )
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
}
