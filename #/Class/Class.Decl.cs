public partial class A335
{
public partial class Class
	{
	public partial class Decl : Automatrix
		{
		static protected Field.Decl Field
			{
			set { field_add( value ) ;  }
			}
		static protected bool Cctor
			{
			set { cctor_add( Class.Symbol ) ; }
			}
		public void Declared()
			{
			System.Array.Resize( ref idset, idset.Length -1 ) ;
			}
		}
	}

public partial class   classDecl_methodHead_methodDecls____
	: Class.Decl	{
	protected override void main()
		{
		var methodHead = (Argv[1] as Method.Head) ;
		methodHead.DeclList = Method.Decl.List ;
		if( methodHead.Cctor )
			Cctor = true ;
		#if HPP
		string symbol = Class.Type + methodHead.Name ;
		Instr.WriteList( symbol, Instr.List ) ;
		#else
		Instr hpp = Instr.List ;
		#endif
		C.Hangdown() ;
		}
	}

public partial class   classDecl_classHead_____classDecls____
	: Class.Decl	{
	protected override void main()
		{
		Declared() ;
		}
	}

public partial class   classDecl_fieldDecl
	: Class.Decl	{
	protected override void main()
		{
		Field = Argv[1] as Field.Decl ;
		}
	}

public partial class   classDecls_classDecls_classDecl
	: Automatrix	{}
}



