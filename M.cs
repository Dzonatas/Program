//#define START Blogic#

using System;
using System.Xml ;
using System.IO ;


public partial class A335
{

public static void Main( string[] args )
	{
	//request( ref system ) ;  //_: request( ref system_m ) ; //_m!(_err[1...3]='boxed','unboxed','not boxed')
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

