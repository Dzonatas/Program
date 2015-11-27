partial class A335
{
public partial class Class : Automatrix
	{
	static public C_Type Type
		{
		get { return classHead.Type ; }
		}
	static public void Declared( Head h, Decls d )
		{
		d.Head  = h ;
		h.Decls = d ;
		var sw = Current.Path.CreateText( h.Symbol + ".h" ) ;
		if( h.ValueType )
			sw.WriteLine( "struct "+h.Symbol+" {" ) ;
		foreach( Decl decl in d )
			if( decl is classDecl_fieldDecl )
				sw.WriteLine( (decl as classDecl_fieldDecl).FieldDecl.ToStructField(h) ) ;
		if( h.ValueType )
			sw.WriteLine( "} ;" ) ;
		sw.Close() ;
		classHead = h.Outer ;
		}
	}
}