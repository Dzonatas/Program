public partial class A335
{
public struct Itemset
	{
	public System.Decimal   rule ;
	public int              point ;
	public bool             empty ;
	static public Itemset Find( Itemset [] items, string symbol )
		{
		foreach( Itemset i in items )
			{
			if( Rule.Set[(int)i.rule].RHS.Length == i.point )
				{
				if( Rule.Set[(int)i.rule].LHS == symbol )
					return i ;
				continue ;
				}
			if( Rule.Set[(int)i.rule].RHS[i.point] == symbol )
				return i ;
			}
		throw new System.IndexOutOfRangeException(symbol) ;
		}
	static public int FindDefault( Itemset [] items, System.Decimal rule )
		{
		for( int i = 0 ; i < items.Length ; i++ )
			{
			if( Rule.Set[(int)items[i].rule].RHS.Length == items[i].point )
				{
				if( items[i].rule == rule )
					return i ;
				continue ;
				}
			}
		throw new System.DataMisalignedException() ;
		}
	static public explicit operator string( Itemset i )
		{
		string s1 = "_"+
			( ( i.rule < 10 ) ? "__"
			: ( i.rule < 100 ) ? "_"
			: ""
			) ;
		if( ! i.empty )
			{
			string s2 = "_"+
				( i.point < 10 ? "_" : "" ) ;
			return X.Auto[s1+i.rule+s2+i.point] ;
			}
		return X.Auto[s1+i.rule+"___"] ;
		}
	public override string ToString()
		{
		if( Rule.Set[(int)rule].RHS.Length == point )
			return Rule.Set[(int)rule].ToString() +'.'+ point.ToString() ;
		return Rule.Set[(int)rule].RHS[point].ToString() ;
		}
	}
}
