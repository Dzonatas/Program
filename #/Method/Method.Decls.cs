partial class A335
{
public partial class Method
	{
	public partial class Decls : Automatrix, System.Collections.Generic.IEnumerable<Decl>
		{
		static protected Decls thread ;
		protected Head  head ;
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
		public Head Head
			{
			set	{
				foreach( Decl d in this )
					d.Node.head = value ;
				}
			get { return head ; }
			}
		public Decls First()
			{
			Decls current = this ;
			while( current.previous != null ) current = current.previous ;
			return current ;
			}
		public new System.Collections.Generic.IEnumerator<Decl> GetEnumerator()
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
	}

public partial class   methodDecls_methodDecls_methodDecl
	: Method.Decls	{
	protected override void main()
		{
		previous = Argv[1] as Method.Decls ;
		decl     = Argv[2] as Method.Decl ;
		if( previous != null )
			(previous as methodDecls_methodDecls_methodDecl).next = this ;
		else
			thread = this ;
		decl.Node = this ;
		}
	protected override void render()
		{
		//head.Function.GarbageCollect() ;
		}
	}
}
