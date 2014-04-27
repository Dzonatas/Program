public class Test2
	{
	class Hello
		{
		public override string ToString()
			{
			return "Hello" ;
			}
		}
	class World
		{
		public override string ToString()
			{
			return "World" ;
			}
		}
	static void Main()
		{
		System.Console.WriteLine( new Hello() +" "+ new World() ) ;
		}
	}
