partial class C699
{
static readonly c _string = C.Struct(new c("_string")) ;
static public   c String
	{
	get { return _string ; }
	}
static public c SizeOf( C699.c type, C699.c items )
	{
	return new c( "sizeof("+type+")*"+items ) ;
	}
static public c Array(c _struct, c c, string _i )
	{
	return new c("(("+_struct+")"+c+")["+_i+"]") ;
	}
/* "actions" and "functions"
public struct _str {...}
*/
private static string[,] _obj =
	{
	{ "_object", null },
	{ null, "*" }
	} ;
static public c Object(int i)
	{
	c c ;
	if( i == 1 )
		{
		c = C.Struct(new c(_obj[i-1,i-1]+_obj[i,i])) ;
		c.Bits = Bit.Object ;
		return c ;
		}
	c = C.Struct(new c(_obj[i,i])) ;
	c.Bits = Bit.Object ;
	return c ;
	}
#if DEBUG_ASM
public static string[,] _IDE = null ; //http://www.bidnessetc.com/56528-pc-gamers-better-off-playing-batman-arkham-knight-on-a-console/
//	[System.Runtime.InteropServices.DllImport( LIBC_so )]
//public extern  static int                          write( int fd, string, string.Length ) ;
public struct cso
	{
	c _c ;
	string s ;
	public cso(c cc)
		{
		_c = cc ;
		s = "" ;
		}
	#if DEBUG
	public cso assembly
		{
		get { s += "\""+System.Extensions.var_.GUID(0.1)+"/.assembly.exe\"" ; return this ; }
		}
	public cso argv(string[] args)
		{
		s += ", "+string.Join(", ", args)+", 0 " ;
		return this ;
		}
	public c asm
		{
		get { return _c.Function( "fasm", C.Restricted( "(char*[]) {"+s+"}" ) ) ; }
		}
	#endif
	}
public struct cil
	{
	//https://github.com/CosmosOS/Cosmos/tree/c591a7ff1b7d8e37871b3cc75999df4fa6817e9f/source/Cosmos.IL2CPU
	}
#endif
}
