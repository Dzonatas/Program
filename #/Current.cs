namespace Current
{
using System.IO ;
using System.Extensions ;

public static class Working
	{
	static DirectoryInfo directory ;
	public static DirectoryInfo Directory
		{
		get { return directory ; }
		}
	static Working()
		{
		string path = 0.1.GUID() ;
		directory = new DirectoryInfo(path) ;
		if( directory.Exists )
			return ;
		directory = System.IO.Directory.CreateDirectory(path) ;
		if( directory.Exists )
			return ;
		throw new System.NotSupportedException( "Obtained path collusion." ) ;
		/*
			(
			(System.Runtime.InteropServices.GuidAttribute)
			//System.AppDomain.CurrentDomain.DomainManager.EntryAssembly.GetCustomAttributes(
			(typeof(A335).Assembly.GetCustomAttributes(
				typeof(System.Runtime.InteropServices.GuidAttribute), true
				)[0])
			).Value	+ ".c" ;
		*/
		}
	}
#if WORK
static class Work
	{
	static string     path = 1.1.GUID() ;
	static string  current = path ;
	static XEvent        _ ;
	static class        DI
		{
		static System.IO.DirectoryInfo directory ;
		static DI()
			{
			directory = new System.IO.DirectoryInfo(path) ;
			if( directory.Exists )
				return ;
			directory = System.IO.Directory.CreateDirectory(path) ;
			if( directory.Exists )
				return ;
			throw new System.NotSupportedException( "Obtained path collusion." ) ;
			}
		}
	}
#endif
public static class Path
	{
	static System.IO.DirectoryInfo directory ;
	static Path()
		{
		directory = Working.Directory ;
		}
	static public System.IO.StreamWriter CreateText( string name )
		{
		return System.IO.File.CreateText( Working.Directory.FullName + "/" + name ) ;
		}
	static public string Entry( string name )
		{
		return Working.Directory.FullName + "/" + name ;
		}
	static public bool Exists( string name )
		{
		return System.IO.File.Exists( Entry( name ) ) ;
		}
	static public bool Existed
		{
		get { return directory != null && directory.Exists ; }
		}
	}
}
