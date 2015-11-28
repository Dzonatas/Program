partial class A335
{
public partial class Method
	{
	public partial class Head : Automatrix
		{
		Class.Decl                  classDecl ;
		Decls                       decls     ;
		int                         maxstack  ;
		bool                        _static   ;
		bool                        _virtual  ;
		Locals                      locals    ;
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
		protected Attr    MethAttr
			{
			set {
				  Static  = value is Attr ? value.Static : false ;
				  Virtual = value is Attr ? value.Virtual : false ;
				}
			}
		C_Type  classType
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
			string symbol = classType + name ;
			if( sigArgs0 != null )
				{
				sigArgs0.ForEach( (a) => c_method.Args.Add( (Type)a ) ) ;
				symbol += sigArgs0.Types() ;
				}
			c_method.Function = Program.C_Function.FromSymbol( symbol ) ;
			c_method.Function.Method = c_method ;
			}
		public int MaxStack
			{
			set { maxstack = value ; }
			get { return maxstack ; }
			}
		public bool Static
			{
			set { _static = value ; }
			get { return _static ; }
			}
		public bool CallConvInstance
			{
			get { return callConv is CallConv ? callConv.Instance : false ; }
			}
		public bool    Virtual
			{
			set {
				if( ( _virtual = value ) )
					{
					var c = Program.C_Struct.FromSymbol( classType ) ;
					c.Assign( name + ( sigArgs0 != null ? sigArgs0.Types() : string.Empty ) ) ;
					}
				}
			get { return _virtual ; }
			}
		public void WriteInclude( System.IO.StreamWriter sw )
			{
			if( sigArgs0 == null )
				sw.WriteLine( "#include \"" + classType + name + ".c\"" ) ;
			else
				sw.WriteLine( "#include \"" + classType + name + sigArgs0.Types() + ".c\"" ) ;
			}
		protected void _render()
			{
			var c = c_method.Function ;
			int args = ( sigArgs0 == null ? 0 : sigArgs0.Count() ) + ( CallConvInstance ? 1 : 0 ) ;
			if( _virtual )
				c.Type = C699.String ;
			if( args == 0 )
				c.Args = "()" ;
			else
				c.Args = '('+C699.C.Const.Voidpp.ArgV+')' ;
			c.Statement( C699.C.Const.Voidpp.Equate("stack",C699.Alloca(maxstack + " * sizeof(void*)") ) ) ;
			if( locals != null )
				locals.WriteTo( c ) ;
			}
		public void WriteMethod()
			{
			var c = c_method.Function ;
			if( _virtual )
				c.Statement( C699.C.Return("*("+C699.String+" *) *stack") ) ;
			var sw = global::Current.Path.CreateText( c.Symbol + ".c" ) ;
			#if HPP
			sw.WriteLine( "#include \"" + c.Symbol + ".hpp\"\n" ) ;
			#endif
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
		}
	}

public partial class   methodHeadPart1___method_
	: Method.Head.Part1   {}

public partial class   methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____
	: Method.Head   {
	protected override void main()
		{
		name              = Argv[6] as Method.Name ;
		name.MethodHead   = this ;
		sigArgs0          = Argv[8] as SigArgs0 ;
		callConv          = Argv[3] as CallConv ;
		}
	protected override void _prerender()
		{
		c_method.Type     = Argv[5] as Type ;
		c_method.Name     = name ;
		MethAttr          = Argv[2] as Method.Attr ;
		}
	protected override void render()
		{
		_render() ;
		Function.GarbageCollect() ;
		}
	}
}
