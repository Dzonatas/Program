namespace Driver
{
public abstract class Auto : global::IRule
	{
	public abstract System.Decimal   RuleNumber  { get; }
	public abstract string           LHS         { get; }
	public abstract string[]         RHS         { get; }
	public abstract int              Symbol      { get; }
	public abstract bool             Useful      { get; }
	#if !EMBED
	protected virtual global::A335.Automatrix splice_f() { throw new System.NotImplementedException( this.GetType().FullName ) ; }
	#endif
	protected Tokenset.Token[] argv ;
	protected int arg_i ;
	public void Splice()
		{
		#if EMBED
		log( "["+LHS+" " ) ;
		for( int i = 0 ; i < argv.Length ; i++ )
			log( argv[i]._+"," ) ;
		log( "]" ) ;
		#else
		global::A335.Stack.this_rule = this ;
		global::A335.Stack.Push( (global::A335.Automatrix) splice_f() ) ;
		#endif
		}
	public Tokenset.Token   Argv
		{
		set { argv[--arg_i] = value ; }
		}
	protected static void log( string point )
		{
		#if EMBED
		System.Console.Write( point ) ;
		#endif
		}
	public override string ToString()
		{
		string s = "<"+LHS+" argc="+argv.Length ;
		for( int i = 0 ; i < argv.Length ; i++ )
			s += " "+RHS[i]+"="+argv[i]._ ;
		s+=">" ;
		return s ;
		}
	}
}

partial class Automaton
	{
	#if EMBED
	public static void Main( string[] args )
		{
		_0() ;
		log_end() ;
		}
	#else
	public static void Begin()
		{
		_0() ;
		log_end() ;
		}
	#endif
	}
