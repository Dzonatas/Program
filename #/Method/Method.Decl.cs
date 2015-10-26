partial class A335
{
public partial class Method
	{
	public partial class Decl : Automatrix
		{
		static Decl current = null ;
		Head _head ;
		Decl previous ;
		Decl next ;
		C_Label   label ;
		Instr     _Instr ;
		public Decl Next
			{
			get { return next ; }
			}
		public Instr     Instr
			{
			set { _Instr = value ; }
			get { return _Instr ; }
			}
		static public Decl List
			{
			get {
				Decl i ;
				for( i = current ; i is Decl ; i = i.previous )
					{
					if( i.previous == null )
						{
						current = null ;
						return i ;
						}
					else
						i.previous.next = i ;
					}
				return i ;
				}
			}
		protected void Enlist()
			{
			previous = current ;
			current = this ;
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
			set { label = value ; }
			get { return label != null ? label : C_Label.Empty ; }
			}
		static public C_Label Find( C_Symbol id )
			{
			for( Decl i = current ; i is Decl ; i = i.next )
				if( i.label != null && id == i.label )
					return i.label ;
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
	protected override void main()
		{
		Enlist() ;
		Label = C_Label.Acquire( Arg1.Token ) ;
		}
	}

public partial class   methodDecl_instr
	: Method.Decl	{
	protected override void main()
		{
		Enlist() ;
		Instr = Argv[1] as Instr ;
		Instr.C_OprandHasArgs = ( 0 < Args ) ;
		Instr.Defined() ;
		//Debug.WriteLine( "[methodDecl_instr] stack={0}", C.StackOffset ) ;
		}
	}
}
