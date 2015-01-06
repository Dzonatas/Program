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
	public Automaton( System.Action _set )
		{
		_set() ;
		}
	}
