namespace master
{
public abstract class Auto
	{
	public abstract string LHS { get; }
	public abstract string[] RHS { get; }
	protected Tokenset.Token[] argv ;
	protected int arg_i ;
	public void Splice()
		{
		log( "["+LHS+" " ) ;
		for( int i = 0 ; i < argv.Length ; i++ )
			log( argv[i]._+"," ) ;
		log( "]" ) ;
		}
	public Tokenset.Token   Argv
		{
		set { argv[--arg_i] = value ; }
		}
	protected static void log( string point )
		{
		System.Console.Write( point ) ;
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
	#endif
	}
