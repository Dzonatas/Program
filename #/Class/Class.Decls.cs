partial class A335
{
public partial class Class : Automatrix
	{
	public partial class Decls : Class, System.Collections.Generic.IEnumerable<Decl>
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
		public Decls First()
			{
			Decls current = this ;
			while( current.previous != null ) current = current.previous ;
			return current ;
			}
		public new Head Head
			{
			set	{
				foreach( Decl d in this )
					d.Node.head = value ;
				}
			get { return head ; }
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
		public void WriteIncludesTo( System.IO.StreamWriter sw )
			{
			foreach( Decl d in this )
				{
				if( d is classDecl_methodHead_methodDecls____ )
					(d as classDecl_methodHead_methodDecls____).WriteIncludesTo( sw ) ;
				else
				if( d is classDecl_classHead_____classDecls____)
					(d as classDecl_classHead_____classDecls____).WriteIncludesTo( sw ) ;
				}
			}
		}
	}

public partial class   classDecls_classDecls_classDecl
	: Class.Decls	{
	protected override void main()
		{
		previous = Argv[1] as Class.Decls ;
		decl     = Argv[2] as Class.Decl ;
		if( previous != null )
			(previous as classDecls_classDecls_classDecl).next = this ;
		else
			thread = this ;
		decl.Node = this ;
		}
	}
}
