public interface IRule
	{
	System.Decimal   RuleNumber  { get; }
	string           LHS         { get; }
	string[]         RHS         { get; }
	int              Symbol      { get; }
	bool             Useful      { get; }
	}

