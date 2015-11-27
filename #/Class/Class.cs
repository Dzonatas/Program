partial class A335
{
public partial class Class : Automatrix
	{
	static public string Symbol
		{
		get { return classHead.Symbol ;	}
		}
	static public C_Type Type
		{
		get { return classHead.Type ; }
		}
	static public void Declared( Head h, Decls d )
		{
		d.Head  = h ;
		h.Decls = d ;
		var sw = Current.Path.CreateText( Symbol + ".h" ) ;
		if( h.ValueType )
			{
			sw.WriteLine( "struct "+h.Symbol+" {" ) ;
			foreach( Decl decl in d )
				if( decl is classDecl_fieldDecl )
					sw.WriteLine( (decl as classDecl_fieldDecl).ToStructField() ) ;
			sw.WriteLine( "} ;" ) ;
			}
		else
			foreach( Decl decl in d )
				if( decl is classDecl_fieldDecl )
					sw.WriteLine( decl as classDecl_fieldDecl ) ;
		sw.Close() ;
		classHead = h.Outer ;
		}
	}
}