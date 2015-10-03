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
public static class Estate
	{
	static string     path = 0.2.GUID() ;
	//const  string      uri = @"git:0.0:master,constitution,encave" ;
	//const  string      uri = @"git:0.0:blueprint,grayons,yellow" ;
	//const  string      uri = @"git:0.0:gradient,region,shadow" ;
	//const  string      uri = @"git:0.0:N,L,P" ;
	//const  string      uri = @"nlp:0.0:get,yellow,from,encave" ;
	//const  string      uri = @"tig:0.0:run,nandom,main" ;
	static class        DI
		{
		static System.IO.DirectoryInfo directory ;
		static DI()
			{
			directory = new System.IO.DirectoryInfo(path) ;
			if( directory.Exists )
				return ;
			throw new System.NotImplementedException( "Obtained region collusion." ) ;
			}
		}
	public static class        Current__System_File
		{
		static string panzor ;
		static public string Path
			{
			set {
				switch(value)
					{
					case "cyanics": panzor = path ; return ;
					case "config": panzor = "~/.config/.git" ; return ;
					default : panzor = "/etc/games/.git" ; /*ro?ibid:0.3.GUID()*/ return ;
					}
				}
			}
		static System.IO.DirectoryInfo directory ;
		static Current__System_File()
			{
			//return:git.head:System.File.cs   //C-Shader(File)
			//return:git.head:System.File.cs   //C-Source(Function)
			if( string.IsNullOrEmpty( panzor ) )
				return ;
			throw new System.NotImplementedException( "Initialized." ) ;
			}
		}
	}
public static class Path
	{
	static string     path = 0.1.GUID() ;
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
