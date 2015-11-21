partial class A335
{
public partial class Method
	{
	public partial class Head : Automatrix
		{
		Class.Decl classDecl ;
		Head    previous ;
		Head    next ;
		Program.C_Method c_method ;
		C_Type  classType ;
		Name    name ;
		Decls   decls ;
		int     maxstack ;
		bool    _static ;
		bool    _CallConvInstance ;
		SigArgs0 _SigArgs0 ;
		bool    _Virtual ;
		Locals  locals ;
		public partial class Part1 : Automatrix
			{
			protected override void main()
				{
				}
			}
		public bool Cctor
			{
			get { return name is methodName___cctor_ ; }
			}
		protected override void main()
			{
			if( null != ( previous = head ) )
				previous.next = this ;
			else
				begin = this ;
			head = this ;
			c_method = new Program.C_Method( Class.Type ) ;
			classType = Class.Type ;
			methodHead() ;
			CreateFunction() ;
			}
		virtual protected void methodHead() {}
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
		protected CallConv CallConvList
			{
			set { _CallConvInstance = value is CallConv ? value.Instance : false ; }
			}
		protected Type  Type
			{
			set { c_method.Type = value ; }
			}
		public C_Type  ClassType
			{
			get { return classType ; }
			}
		public Name  Name
			{
			set { c_method.Name = C_Symbol.Acquire( name = value ) ; }
			get { return name ; }
			}
		public SigArgs0 SigArgs0
			{
			set { _SigArgs0 = value ; }
			get { return _SigArgs0 ; }
			}
		public Locals Locals
			{
			set { locals = value ; }
			get { return locals ; }
			}
		protected void    CreateFunction()
			{
			string symbol = classType + name ;
			if( _SigArgs0 != null )
				{
				_SigArgs0.ForEach( (a) => c_method.Args.Add( (Type)a ) ) ;
				symbol += _SigArgs0.Types() ;
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
			set { _CallConvInstance = value ; }
			get { return _CallConvInstance ; }
			}
		public bool    Virtual
			{
			set {
				if( ( _Virtual = value ) )
					{
					var c = Program.C_Struct.FromSymbol( classType ) ;
					c.Assign( name + ( _SigArgs0 != null ? _SigArgs0.Types() : string.Empty ) ) ;
					}
				}
			get { return _Virtual ; }
			}
		public void WriteInclude( System.IO.StreamWriter sw )
			{
			if( _SigArgs0 == null )
				sw.WriteLine( "#include \"" + classType + name + ".c\"" ) ;
			else
				sw.WriteLine( "#include \"" + classType + name + _SigArgs0.Types() + ".c\"" ) ;
			}
		static public Head Begin
			{
			get { return begin ; }
			}
		public Head Next
			{
			get { return next ; }
			}
		protected void _render()
			{
			var c = c_method.Function ;
			int args = ( _SigArgs0 == null ? 0 :_SigArgs0.Count() ) + ( _CallConvInstance ? 1 : 0 ) ;
			if( _Virtual )
				c.Type = C699.String ;
			if( args == 0 )
				c.Args = "()" ;
			else
				c.Args = '('+C699.C.Const.Voidpp.ArgV+')' ;
			c.Statement( C699.C.Const.Voidpp.Equate("stack",C699.Alloca(maxstack + " * sizeof(void*)") ) ) ;
			if( locals != null )
				locals.WriteTo( c ) ;
			//A335.Method.WriteList( c, decls ) ;
			}
		public void Write()
			{
			var c = c_method.Function ;
			if( _Virtual )
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
	protected override void methodHead()
		{
		Type              = Argv[5] as Type ;
		Name              = Argv[6] as Method.Name ;
		Name.MethodHead   = this ;
		SigArgs0          = Arg8 ;
		CallConv          = Arg3 ;
		MethAttr          = Argv[2] as Method.Attr ;
		}
	protected new Argument SigArgs0
		{
		set {
			if ( value is Argument )
				{
				var a = (Automatrix) value ;
				if( a is Automatrix )
					base.SigArgs0 = a as SigArgs0 ;
				}
			}
		}
	protected Argument CallConv
		{
		set { CallConvList = ((Automatrix) value) as CallConv ; }
		}
	protected override void render()
		{
		_render() ;
		}
	}
}
