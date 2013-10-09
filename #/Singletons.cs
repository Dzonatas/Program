using System ;

//http://icyspherical.blogspot.com/2012/05/programsingleton-revised-example.html

namespace Application
	{
/*
	[Program.Singleton]
	class Parameter
		{
		private Parameter()
			{
			Program.Parse       += (args) => Console.WriteLine( "Parse({0})", args.ToString() ) ;
			Console.WriteLine( "+A" ) ;
			}
		static Parameter()
			{
			Console.WriteLine( "A" ) ;
			}
		~Parameter()
			{
			Console.WriteLine( "A-" ) ;
			}
		}
*/
	[Program.Singleton]
	sealed class Initializer
		{
		private Initializer()
			{
			Program.Initialize  += ()     => Console.WriteLine( "Initialize()" ) ;
			}
		static Initializer()
			{
			Console.WriteLine( "B" ) ;
			}
		~Initializer()
			{
			Console.WriteLine( "B-" ) ;
			}
		}

/*
	[Program.Singleton]
	sealed class Iterator
		{
		private Iterator()
			{
			Program.Run         += ()     => Console.WriteLine( "Run()" ) ;
			}
		static Iterator()
			{
			Console.WriteLine( "C" ) ;
			}
		~Iterator()
			{
			Console.WriteLine( "C-" ) ;
			}
		}
*/
	}

