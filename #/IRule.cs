public interface IRule
	{
	int              RuleNumber  { get; }
	string           LHS         { get; }
	string[]         RHS         { get; }
	int              Symbol      { get; }
	bool             Useful      { get; }
	}

