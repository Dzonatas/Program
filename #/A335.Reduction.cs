partial class A335
{
public struct Reduction
	{
	public int            symbol  ;
	public System.Decimal rule    ;
	public bool           enabled ;
	public Itemset        item    ;
	public bool   Default( int rule )
		{
		if( symbol == _default && rule == this.rule )
			return true ;
		return false ;
		}
	public override string ToString()
		{
		if( enabled )
			return symbol.ToString() +"->"+ Rule.Set[(int)rule] ;
		return string.Format("[Reduction]({0},{1})", symbol, rule );
		}
	static public implicit operator int( Reduction r )
		{
		return r.symbol ;
		}
	}
}

