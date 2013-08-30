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

static string read()
	{
	System.Text.StringBuilder sb = new System.Text.StringBuilder() ;
	System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo( "/bin/sh","/home/dzonatas/ecma335/compile.sh" ) ;
	psi.UseShellExecute = false ;
	//psi.StandardOutputEncoding = System.Text.Encoding.ASCII ;
	psi.RedirectStandardOutput = true ;
	
	System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi) ;
	while(true)
		{
		string x = p.StandardOutput.ReadLine() ;
		if( x == null )
			break ;
		sb.Append( x ) ;
		sb.Append( '\n' ) ;
		}
	p.WaitForExit() ;
	System.Console.WriteLine(p.ExitCode) ;
	return sb.ToString() ;
	}

/*
public struct (O(QR))(^)__
	{
	Token Association ;
	Token Contribution ;
	}
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
		return new Token( (char)int.Parse( s[1] ), text ) ; //_point3D:___(s[2,text])
		}
	Token t = new Token( '$', "$end" ) ;
	if( !ended ) prompt( t ) ;
	ended = true ;
	System.Console.SetCursorPosition(y,x) ;
	return t ;
	}
/*
#region micro
<bisect> | bisect: PLINE
<o/o>    | O.no.#(One^H)
#endregion micro
//completion:(loop)(((_second))-('Sound'))
#region macro_d
<o/o specific_n=n>    | [(->)(./#/O.cs)((_)s)](<(o)/(o)>)_FIX:("requires"_)lexical.up(Decimal "grammar"(0.0))
#endregion macro_d
*/
}
