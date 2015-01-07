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
		System.Console.Write( point ) ;
		}
	static void log_end()
		{
		System.Console.WriteLine() ;
		}
	void unshift( System.Action _rule )
		{
		_rule() ;
		}
	void Goto( System.Action<Automaton> new_state )
		{
		new Automaton( new_state ) ;
		}
	static void shift( System.Action<Automaton> _set )
		{
		token = Tokenset.Input ;
		new Automaton( _set ) ;
		}
	}
