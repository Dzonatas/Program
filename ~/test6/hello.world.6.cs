public interface ITest 
	{
	string   LHS     { get; }
	string[] RHS     { get; }
	}
public abstract class ATest : ITest
	{
	public abstract string LHS    { get; }
	public abstract string[] RHS  { get; }
	}
public class Test6 : ATest
	{
	static readonly string    lhs = "Hello" ;
	static readonly string[]  rhs = { " ", "World" } ;
	public override string    LHS { get { return lhs ; } }
	public override string[]  RHS { get { return rhs ; } }
	static void Main( string[] args )
		{
		Test6 t = new Test6() ;
		System.Console.Write( t.LHS ) ;
		System.Console.WriteLine( t.RHS[0] + t.RHS[1] ) ;
		}
	}
