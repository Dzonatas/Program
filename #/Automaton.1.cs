#if EMBED
using Debug = System.Console ;
#else
using Debug = System.Diagnostics.Debug ;
#endif
partial class Automaton
	{
	System.Func<int,int> gotoset_s ;
	Tokenset.Token                _token ;
	static Tokenset.Token         token ;
	static bool  token_HasValue   = false ;
	static int   backup ;
	static global::Item auto ;
	static int yy ;
	Automaton()
		{
		if( ! token_HasValue )
			{
			token = Tokenset.Input ;
			token_HasValue = true ;
			#if !EMBED
			#if DEBUG_TOKEN
			Debug.WriteLine( "[Token] " + token ) ;
			#endif
			token.point = global::A335.xml_translate[token.c] ;
			#endif
			}
		}
	static void log( string point )
		{
		#if EMBED
		System.Console.Write( point ) ;
		#endif
		}
	static void log_end()
		{
		#if EMBED
		System.Console.WriteLine() ;
		#endif
		}
	class SyntaxException : System.NotImplementedException
		{
		public SyntaxException() : base() {}
		public SyntaxException(string message) : base(message) {}
		}
	}
