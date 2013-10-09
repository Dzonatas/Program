using System ;
/*
namespace Application
	{
	[Program.Singleton]
	class Example
		{
		private Example()
			{
			Program.Parse       += (args) => Console.WriteLine( "Parse({0})", args.ToString() ) ;
			Program.Initialize  += ()     => Console.WriteLine( "Initialize()" ) ;
			Program.Run         += ()     => Console.WriteLine( "Run()" ) ;
			}
		}
	}

*/


namespace Application
	{
	using Application.Orbs ;
	using Application.Atomatrice ;
		
	public class OrbMemoryStream : Orb
		{
		public OrbMemoryStream()
			{
			}
		}

	public class OrbString : Orb
		{
		public OrbString()
			{
			}
		}

	public class OrbInteger : Orb
		{
		public OrbInteger()
			{
			}
		}
		
	[Program.Singleton]
	public class Space : Orb
		{
		private Space()
			{
			new OrbMemoryStream() ;
			new Atom<OrbMemoryStream>() ;
			new Atom<OrbInteger>() ;
			new Atom<OrbInteger>() ;
			}
		}
	/*
	public class Georbit
		{
		Space spherical ;
		Orb sphere ;
		}
	*/
	}
	

namespace Application
	{
	public abstract class OutputText : Task
		{
		abstract protected string	Text { get ; }
		override protected void Process()
			{
			Console.WriteLine( "Text= {0}", Text ) ;
			}
		}
	public class OutputText1 : OutputText
		{
		override protected string Text { get { return "One" ; } }
		}
	public class OutputText2 : OutputText
		{
		override protected string Text { get { return "Two" ; } }
		}
	[Program.Singleton]
	class TestTasks
		{
		private TestTasks()
			{
			Program.Run += () =>
				{
				Task.Queue( new OutputText1() ) ;
				Task.Queue( new OutputText2() ) ;
				} ;
			}
		}
	}
			

