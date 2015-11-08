partial class A335
{
public partial class Class : Automatrix
	{
	static string[] type = new string[0] ;
	static string[] cctor = new string[0] ;
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
	static public void Declared( Head h, Decls d )
		{
		d.Head  = h ;
		h.Decls = d ;
		type_add( Symbol ) ;
		var sw = Current.Path.CreateText( Symbol + ".h" ) ;
		foreach( Decl decl in d )
			if( decl is classDecl_fieldDecl )
				sw.WriteLine( decl as classDecl_fieldDecl ) ;
		sw.Close() ;
		classHead = h.Outer ;
		}
	}
}