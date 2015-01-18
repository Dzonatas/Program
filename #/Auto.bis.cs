namespace bis
{
public abstract class Auto
	{
	static public Tokenset.Token Token ;
	public abstract string LHS { get; }
	public abstract string[] RHS { get; }
	protected static void log( string point )
		{
		System.Console.Write( point ) ;
		}
	}
}