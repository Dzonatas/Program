using Tao.OpenGl ;
using Tao.FreeGlut ;

public partial class _
{
static System.Xml.XmlTextReader   xml ;

public class exception : System.Exception
	{
	public exception()
		{
		prompt( string_t ) ;
		}
	}
	
public static char prompt( Token t )
	{
	int x = System.Console.WindowHeight-1 ; //t.c == '$' ? System.Console.WindowHeight-1 : 0 ;
	System.Console.SetCursorPosition(0,x) ;
	System.Console.ForegroundColor = System.ConsoleColor.Cyan ;
	System.Console.BackgroundColor = System.ConsoleColor.Blue ;
	System.Console.Write( t + "_" ) ;
	System.Console.ResetColor() ;
	System.Console.Write( "> _" ) ;
	System.Console.SetCursorPosition(System.Console.CursorLeft-1,x) ;
	System.ConsoleKeyInfo cki = System.Console.ReadKey( x == 0 ? true : false ) ;
	System.Console.SetCursorPosition(0,x) ;
	System.Console.Write( "> {0}_{1}", t._, cki.KeyChar ) ;
	for( int y = System.Console.CursorLeft ; y < System.Console.WindowWidth ; y++ )
		System.Console.Write( ' ' ) ;
	System.Console.SetCursorPosition(0,23) ;
	return cki.KeyChar ;
	}

public static void assimulation()
	{
	string input = read() ;
	xml = new System.Xml.XmlTextReader( new System.IO.StringReader( input ) ) ;
	while( xml.Read() && ! ( xml.NodeType == System.Xml.XmlNodeType.Element && xml.Name == "xml" ) ) ;
	}
	
internal static class screen
	{
	internal static System.Diagnostics.ProcessStartInfo psi ;
	static System.Diagnostics.Process process ;
	static screen()
		{
		object[] o = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute),true) ;
		
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env","Xnest :2 -name '" + (o[0] as System.Reflection.AssemblyTitleAttribute).Title +"'" ) ;
		psi.UseShellExecute = false ;
		//psi.StandardOutputEncoding = System.Text.Encoding.ASCII ;
		//psi.RedirectStandardOutput = true ;
		//psi.CreateNoWindow = true ;
		}
	internal static void start()
		{
		process = System.Diagnostics.Process.Start(psi) ;
		}
	}

internal static class shell
	{
	internal static System.Diagnostics.ProcessStartInfo psi ;
	static shell()
		{
		screen.start() ;
		int argc = 1 ;
		System.Text.StringBuilder [] sb = new System.Text.StringBuilder[1] ;
		sb[0] = new System.Text.StringBuilder() ;
		sb[0].Append( "DISPLAY=:2" ) ;
		Glut.glutInit( ref argc, sb ) ;
		Glut.glutInitDisplayMode( Glut.GLUT_SINGLE | Glut.GLUT_RGB ) ; //GLUT_RGBA:CHROME
		psi = new System.Diagnostics.ProcessStartInfo( "/usr/bin/env","DISPLAY=:2 blizzard.exe --opengl" ) ;
		psi.UseShellExecute = false ;
		//psi.StandardOutputEncoding = System.Text.Encoding.ASCII ;
		//psi.RedirectStandardOutput = true ;
		//psi.CreateNoWindow = true ;
		}
	}

static string read()
	{
	System.Text.StringBuilder sb = new System.Text.StringBuilder() ;
	System.Diagnostics.Process p ;
	try {
		p= System.Diagnostics.Process.Start(shell.psi) ;
		while(true)
			{
			string x = p.StandardOutput.ReadLine() ;
			if( x == null )
				break ;
			sb.Append( x ) ;
			sb.Append( '\n' ) ;
			}
		goto done ;
		} catch {}
	done:
	p.WaitForExit() ;
	return sb.ToString() ;
	}

/*
public struct (O(QR))(^)__
	{
	Token Association ; //[array:]
	//x [IHAVE,sendme]
	//y [ihave,SENDME]
        (Token "0.00000xbf"("con"-"(vexed)")) ;: '//y' -> . //_disables_comments_... ...(WORD) :'weak'.lnk.
	//zz   [MATERIALS,pixels]
	//y(y) [materials,PIXELS]
	Token Contribution ; //[tab:]
	}(.vm_p)((OPRAND))__FIXT:(Earth:)[UNICODED].known(...ASL)((default:"second-hand"(I.O)))
*/
	
static bool ended ;
public static Token input()
	{
	int x = System.Console.CursorTop ;
	int y = System.Console.CursorLeft ;
	if( xml.Read() && xml.NodeType == System.Xml.XmlNodeType.Element )
		{
		string [] s = xml.Name.Split("_-".ToCharArray()) ;
		xml.Read() ;
		string text = xml.Value ;
		return new Token( (char)int.Parse( s[1] ), text ) ; //_point3D:___(s[2,text]),_xor_URN:s[0]:_
		}
	Token t = new Token( '$', "$end" ) ;
	if( !ended ) prompt( t ) ;
	ended = true ;
	System.Console.SetCursorPosition(y,x) ;
	return t ;
	}

#region micro
//<bisect> | bisect: PLINE
//<o/o>    | O.no.#(One^H)
#endregion micro
//completion:(loop)(((_second))-('Sound'))
#region macro_d
//<o/o specific_n=n>    | [(->)(./#/O.cs)((_)s)](<(o)/(o)>)_FIX:("requires"_)lexical.up(Decimal "grammar"(0.0))
#endregion macro_d
#region micro_d
#if USED_PATENTS
//<o/o specific_n=n.[1-9](+)>    //_patented
#if UUCP_GOV_QUADGRAPH
//<o/o specific_n=d.[123456789](+)>    //__Open.gov.mil
//<o/o specific_n=d.[123456789](+)>    //MAP.GOV.MIL.d.(\123456789).[+objects,-terrain]
#endif
#endif
#endregion micro_d

}
