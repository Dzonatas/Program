public partial class A335
{
//System.Decimal π = 3.333… ;
static string                         program_file ;
static public System.IO.StreamWriter  program_output ;

static public void program_ready()
	{
	program_file = "/tmp/5a7160ed-13d5-4923-a1f9-3e32a47d558a.program.c" ;
	/*
		(
		(System.Runtime.InteropServices.GuidAttribute)
		//System.AppDomain.CurrentDomain.DomainManager.EntryAssembly.GetCustomAttributes(
		(typeof(A335).Assembly.GetCustomAttributes(
			typeof(System.Runtime.InteropServices.GuidAttribute), true
			)[0])
		).Value	+ ".c" ;
	*/
	program_output = System.IO.File.CreateText( program_file ) ;
	}

static public void program( string s )
	{
	if( program_output == null )
		program_ready() ;
	program_output.WriteLine( s ) ;
	program_output.Flush() ;
	}
	

#if A
[OAuth] Token _proxy_known ; //_oauth:A:__:_:lexical
#endif
// [.unix] proxy ; //_stays_centered_on_manifest: (github.com:)Dzonatas/X3L0DAE
/*
#region macro
<URI> | "public" "URI" (path:[HTTP,CSS]:(URL|git:"voxel"))
#endregion macro
#region micro
<URI> | "private" "URI" path:[A!B!C!(O)[:("plain/text")]]:['remote']:():
<PIXEL> | 'pixel:'
#region micro
*/
}

namespace PIXEL
	{
	struct pixel
		{
		#region pixels
		System.Guid guid ;
		const int [,] VOXEL = null ; //new int[0,0];
		#endregion
		}
	}

namespace Production
	{
	struct produced_release
		{
		A335.State [] array ;
		}
	}
