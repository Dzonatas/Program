partial class A335
{
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
}
