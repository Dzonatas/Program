//using System.C.IDE.MonoDevelop;//C.I.S.("ecma.cproj")
using System.Text.RegularExpressions ;
using System ;

partial class A335
{
#if COPY
#endif

partial class Program
	{
	static public C_Symbol C_Symbol_Aquire( string symbol )
		{
		C_Symbol c ;
		if( ! symbolset.ContainsKey( symbol ) )
			symbolset.Add( symbol, c = new C_Symbol( symbol ) ) ;
		else
			c = symbolset[symbol] ;
		return c ;
		}
	}

public class C_Symbol
	{
	Guid ID ;
	string symbol ;
	internal C_Symbol( string symbol )
		{
		this.symbol = symbol ;
		ID = Guid.NewGuid() ;
		}
	public C_Symbol()
		{
		ID = Guid.NewGuid() ;
		symbol = "_" + Regex.Replace( ID.ToString(), "[^A-Za-z_0-9]", "_").ToLower() ;
		}
	static public C_Symbol Acquire( string symbol )
		{
		return Program.C_Symbol_Aquire( symbol ) ;
		}
	static public implicit operator string( C_Symbol c )
		{
		return c.symbol ;
		}
	}


public class Channel   // : X-Window
	{
	//VisualType:StaticGray|StaticColor|GrayScale
	//WINGRAVITY:Static
	//BITGRAVITY:Static
	//Depth:Array
	//oprands:
	System.IntPtr  display ;
	System.IntPtr  screen  ;
	System.IntPtr  sid     ;
	System.IntPtr  line    ;
	#if CAIRO
	System.IntPtr  flush   ;
	#endif
	//rez:
	object []      items   ;
	}

#region macro
/*
<COMPQSTRING> | <compQstring item-scope item-i/>
*/
#endregion macro
}
