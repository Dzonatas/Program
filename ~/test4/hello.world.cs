struct HelloWorld
	{
	public string hello ;
	public string space ;
	public string world ;
	}
namespace Fourth
{
public class Test4
	{
	static HelloWorld hw = new HelloWorld()
		{
		hello = "Hello",
		space = " ",
		world = "World"
		} ;
	static void Main( string[] args )
		{
		System.Console.Write( hw.hello ) ;
		System.Console.Write( hw.space ) ;
		System.Console.WriteLine( hw.world ) ;
		}
	}
}
