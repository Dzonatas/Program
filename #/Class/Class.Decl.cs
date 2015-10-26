public partial class A335
{
public partial class Class
	{
	public partial class Decl : Automatrix
		{
		static public string Field
			{
			set { field_add( value ) ;  }
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
		Field = (Argv[1] as FieldDecl).Field ;
		}
	}

}



