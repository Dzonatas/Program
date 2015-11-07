partial class A335
{
public partial class Decls : Automatrix, System.Collections.Generic.IEnumerable<Decl>
	{
	static protected Decls thread ;
	protected Decls previous ;
	protected Decls next ;
	protected Decl  decl ;
	static public implicit operator Decl( Decls d )
		{
		return d.decl ;
		}
	static public Decls Thread
		{
		get { return thread ; }
		}
	public Decls First()
		{
		Decls current = this ;
		while( current.previous != null ) current = current.previous ;
		return current ;
		}
	public System.Collections.Generic.IEnumerator<Decl> GetEnumerator()
		{
		Decls current = First() ;
		while( current != null )
			{
			yield return current.decl ;
			current = current.next ;
			}
		}
	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
		return GetEnumerator() ;
		}
	}

public partial class   decls
	: Decls	{}

public partial class   decls_decls_decl
	: Decls {
	protected override void main()
		{
		previous = Argv[1] as Decls ;
		decl     = Argv[2] as Decl ;
		if( previous != null )
			(previous as decls_decls_decl).next = this ;
		else
			thread = this ;
		decl.Node = this ;
		}
	}
}
