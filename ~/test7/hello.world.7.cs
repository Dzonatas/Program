namespace Seventh
{
public class Test7
	{
	protected string[]  argv = new string[3] ;
	protected int       arg_i = 3 ;
	public    string    Argv { set { argv[--arg_i] = value ; } }
	public void Write()
		{
		foreach( string s in argv )
			System.Console.Write( s ) ;
		System.Console.WriteLine("") ;
		}
	public override string ToString()
		{
		return "" ;
		}
	}
}
public class Test
	{
	static void Main( string[] args )
		{
		var t = new Seventh.Test7() ;
		t.Argv = "World" ;
		t.Argv = " " ;
		t.Argv = "Hello" ;
		t.Write() ;
		}
	}
