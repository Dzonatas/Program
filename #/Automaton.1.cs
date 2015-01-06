partial class Automaton
	{
	int[,]       shiftset      ;
	int[,]       gotoset       ;
	string[]     typeset       ;
	int[]        symbolset     ;
	int[]        stateset      ;
	int[]        ruleset       ;
	int[]        pointset      ;
	int[,]       reductionset  ;
	int          _default      ;
	static       Tokenset.Token token ;
	public Automaton( System.Action<Automaton> _set )
		{
		_set( this ) ;
		}
	static void log( string point )
		{
		if( point == null )
			System.Console.WriteLine() ;
		else
			System.Console.Write( point ) ;
		}
	}
