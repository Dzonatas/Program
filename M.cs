//#define START Blogic#

using System;
using System.Xml ;
using System.IO ;


public partial class A335
{

public static void Main( string[] args )
	{
	//request( ref system ) ;
	Blogic() ;
#if RELEASE
	try {
		leave() ;
		}
	catch
		{
		throw new _.exception() ;
		}
#endif
	}

}

