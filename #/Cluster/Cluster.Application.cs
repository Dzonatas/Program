using System ;

//http://icyspherical.blogspot.com/2012/05/programsingleton-revised-example.html
#if CPP_SYNC
namespace Application
    {
    [Program.Singleton]
    class Parameter
        {
        private Parameter()
            {
            Program.Parse       += (args) => Console.WriteLine( "Parse({0})", args.ToString() ) ;
            }
        }

    [Program.Singleton]
    class Initializer
        {
        private Initializer()
            {
            Program.Initialize  += ()     => Console.WriteLine( "Initialize()" ) ;
            }
        }

    [Program.Singleton]
    class Iterator
        {
        private Iterator()
            {
            Program.Run         += ()     => Console.WriteLine( "Run()" ) ;
            }
        }
    }

#endif