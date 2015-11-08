partial class A335
{
public partial class Method
	{
	public partial class Decl : Automatrix
		{
		Head _head ;
		Decls node ;
		public Decls Node
			{
			set { node = value ; }
			}
		protected int     MaxStack
			{
			set { head.MaxStack = value ; C.MaxStack = value ; }
			}
		protected SigArgs0     Locals
			{
			set { head.Locals = new Method.Locals( value ) ; }
			}
		protected int Args
			{
			get { return ( head.SigArgs0 == null ? 0 : head.SigArgs0.Count() ) + ( head.CallConvInstance ? 1 : 0 ) ; }
			}
		public C_Label Label
			{
			get {
				if( this is methodDecl_id____ )
					return (this as methodDecl_id____).Label ;
				else
					return C_Label.Empty ;
				}
			}
		static public C_Label Find( C_Symbol id )
			{
			foreach( Decl i in Decls.Thread )
				if( i.Label != null && id == i.Label )
					return i.Label ;
			return null ;
			}
		protected Decl    EntryPoint
			{
			set {
				_EntryPoint = value ;
				_head = head ;
				if( System.String.IsNullOrEmpty(Class.Symbol) )
					throw new System.NotImplementedException( "entrypoint outside class" ) ;
				}
			get {
				return _EntryPoint ;
				}
			}
		protected Program.C_Oprand NewOprand( string instr )
			{
			return head.NewOprand( instr ) ;
			}
		public Head Head
			{
			get { return _head ; }
			}
		}
	}

public partial class   methodDecl___entrypoint_
	: Method.Decl   {
	protected override void main()
		{
		EntryPoint = this ;
		}
	}

public partial class   methodDecl___maxstack__int32
	: Method.Decl   {
	protected override void main()
		{
		MaxStack = int.Parse( Arg2.Token ) ;
		}
	}

public partial class   methodDecl_localsHead__init______sigArgs0____
	: Method.Decl   {
	protected override void main()
		{
		Locals = Arg4 ;
		}
	protected new Argument Locals
		{
		set {
			base.Locals = (SigArgs0) (Automatrix) value ;
			}
		}
	}

public partial class   methodDecl_id____
	: Method.Decl   {
	C_Label label ;
	protected override void main()
		{
		label = C_Label.Acquire( Arg1.Token ) ;
		}
	public new C_Label Label
		{
		get { return label ; }
		}
	}

public partial class   methodDecl_instr
	: Method.Decl	{
	protected override void main()
		{
		var i = Argv[1] as A335.Instr ;
		i.Decl = this ;
		i.C_OprandHasArgs = ( 0 < Args ) ;
		i.Defined() ;
		//Debug.WriteLine( "[methodDecl_instr] stack={0}", C.StackOffset ) ;
		}
	static public implicit operator C699.c(methodDecl_instr mdi)
		{
		return mdi.Argv[1] as Instr ;
		}
	}
}
