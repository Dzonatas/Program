partial class A335
{
public partial class Class : Automatrix
	{
	static string[] field = new string[0] ;
	static string[] type = new string[0] ;
	static string[] cctor = new string[0] ;
	static void field_add( string id )
		{
		System.Array.Resize( ref field, field.Length +1 ) ;
		field[field.Length - 1] = id ;
		return ;
		}
	static void type_add( string id )
		{
		System.Array.Resize( ref type, type.Length +1 ) ;
		type[type.Length - 1] = id ;
		return ;
		}
	static void cctor_add( string id )
		{
		System.Array.Resize( ref cctor, cctor.Length +1 ) ;
		cctor[cctor.Length - 1] = id ;
		return ;
		}
	static public string Symbol
		{
		get { return classHead.Symbol ;	}
		}
	static public C_Type Type
		{
		get { return classHead.Type ; }
		}
	static public string[] Types
		{
		get { return type ; }
		}
	static public string[] Cctors
		{
		get { return cctor ; }
		}
	static public void Declared()
		{
		type_add( Symbol ) ;
		var sw = Current.Path.CreateText( Symbol + ".h" ) ;
		foreach( string s in field )
			sw.WriteLine( s ) ;
		sw.Close() ;
		field = new string[0] ;
		}
	}
}