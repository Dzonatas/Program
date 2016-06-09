partial class A335
{
public partial class Method
	{
	public partial class Head : Automatrix
		{
		Class.Decl                  classDecl ;
		Decls                       decls     ;
		int                         maxstack  ;
		Locals                      locals    ;
		protected Attr              attr      ;
		protected CallConv          callConv  ;
		protected Name              name      ;
		protected SigArgs0          sigArgs0  ;
		protected Program.C_Method  c_method  ;
		virtual protected void _prerender() {}
		public partial class Part1 : Automatrix {}
		public bool Cctor
			{
			get { return name is methodName___cctor_ ; }
			}
		protected override void prerender()
			{
			c_method = new Program.C_Method( classDecl.Node.Head.Type ) ;
			_prerender() ;
			CreateFunction() ;
			}
		public Decls   Decls
			{
			set { decls = value.First() ; }
			get { return decls ; }
			}
		public Class.Decl ClassDecl
			{
			get { return classDecl ; }
			set { classDecl = value ; }
			}
		public C_Type  ClassType
			{
			get { return classDecl.Node.Head.Type ; }
			}
		public Name  Name
			{
			get { return name ; }
			}
		public SigArgs0 SigArgs0
			{
			get { return sigArgs0 ; }
			}
		public Locals Locals
			{
			set { locals = value ; }
			get { return locals ; }
			}
		protected void    CreateFunction()
			{
			string symbol = ClassType + name ;
			if( sigArgs0 != null )
				{
				sigArgs0.ForEach( (a) => c_method.Args.Add( (Type)a ) ) ;
				symbol += sigArgs0.Types() ;
				}
			c_method.Function = Program.C_Function.FromSymbol( symbol ) ;
			c_method.Function.Method = c_method ;
			c_method.Function.Type   = c_method.Type.Spec ;
			}
		public int MaxStack
			{
			set { maxstack = value ; }
			get { return maxstack ; }
			}
		public bool Static
			{
			get { return attr == null ? false : attr.Static ; }
			}
		public bool CallConvInstance
			{
			get { return callConv is CallConv ? callConv.Instance : false ; }
			}
		public bool    Virtual
			{
			get { return attr == null ? false : attr.Virtual ; }
			}
		public void WriteIncludeTo( System.IO.StreamWriter sw )
			{
			string _name ;
			if( sigArgs0 == null )
				_name = ClassType + name ;
			else
				_name = ClassType + name + sigArgs0.Types() ;
			_name = _name
				.Replace('/','.') //.Replace('$','.')
				.Replace('[','_').Replace(']','_') ;
			sw.WriteLine( "#include \"" + _name + ".c\"" ) ;
			}
		protected void _render()
			{
			var c = c_method.Function ;
			int args = ( sigArgs0 == null ? 0 : sigArgs0.Count() ) + ( CallConvInstance ? 1 : 0 ) ;
			if( args == 0 )
				c.Args = "()" ;
			else
				c.Args = '('+C699.C.Const.Void.p.p.ArgV+')' ;
			c.Statement( C699.C.Const.Void.p.p.Equate("stack",C699.Alloca(maxstack + " * sizeof(void*)") ) ) ;
			if( locals != null )
				locals.WriteTo( c ) ;
			}
		public void WriteMethod()
			{
			var c = c_method.Function ;
			var name = c.Symbol
				.Replace('/','.') //.Replace('$','.')
				.Replace('[','_').Replace(']','_') ;
			var sw = global::Current.Path.CreateText( name + ".c" ) ;
			c.WriteTo( sw ) ;
			sw.Close() ;
			}
		public Program.C_Oprand NewOprand( string instr )
			{
			return new Program.C_Oprand( c_method.Function, instr ) ;
			}
		public Program.C_Function Function
			{
			get { return c_method.Function ; }
			}
		public virtual string ToStructMember( Class.Head h )
			{
			throw new System.NotImplementedException() ;
			}
		public C699.c ToStructMemberAssign(string symbol, Class.Head h )
			{
			return new C699.c(symbol+"."+name+"="+h.Symbol+name+" ") ;
			}
		}
	}

public partial class   methodHeadPart1___method_
	: Method.Head.Part1   {}

public partial class   methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____
	: Method.Head   {
	protected override void main()
		{
		attr              = Argv[2] as Method.Attr ;
		name              = Argv[6] as Method.Name ;
		name.MethodHead   = this ;
		sigArgs0          = Argv[8] as SigArgs0 ;
		callConv          = Argv[3] as CallConv ;
		}
	protected override void _prerender()
		{
		c_method.Type     = Argv[5] as Type ;
		c_method.Name     = name ;
		}
	protected override void render()
		{
		_render() ;
		Function.GarbageCollect() ;
		}
	public override string ToStructMember( Class.Head h )
		{
		return ""+c_method.Type+" (*"+name+")("+C699.C.Const.Void.p.p+") ;" ;
		}
	}
}
