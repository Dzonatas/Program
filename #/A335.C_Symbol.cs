partial class A335
{
public class C_Symbol
	{
	string symbol ;
	public static string ToStemString(string d)
		{
		string a = d ;
		a = System.Text.RegularExpressions.Regex.Replace( a, "[^A-Za-z_0-9]", "_") ;
		a = a.ToUpper() ;
		return "_" + a ;
		}
	public string By_p()
		{
		string pid = ToStemString( A335.Guid.NewGuid().ToString() ) ;
		if( this.symbol[0] == '_' )  //Logical+ID,^'_'[<IDc>]+,(P==NP)=>>(P!=NP)
			return pid + this.symbol + "_p" ;
		string symbol ;
		symbol = "_" + ToStemString( this.symbol ) ;
		return pid + symbol + "_p" ;
		}
	internal C_Symbol( string symbol )
		{
		this.symbol = symbol ;
		}
	public C_Symbol()
		{
		symbol = "_" + A335.Guid.NewGuid().ToID() ;
		}
	static public C_Symbol Acquire( string symbol )
		{
		return Program.C_Symbol_Acquire( symbol ) ;
		}
	static public implicit operator string( C_Symbol c )
		{
		return c.symbol ;
		}
	}

public class C_Undefined : C_Symbol
	{
	public C_Undefined() : base
			(
			System.Text.RegularExpressions.Regex
				.Replace( A335.Guid.NewGuid().ToString(), "[^A-Za-z_0-9]", "_").ToUpper()
			)
		{}
	}
}