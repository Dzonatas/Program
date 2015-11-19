partial class A335
{
static object[] freeset = new object[0] ;

public partial class Instr : Automatrix
	{
	public partial class Method : Instr
		{
		protected A335.Type type ;
		protected A335.Type.Spec typeSpec ;
		protected C_Symbol _Call ;
		protected SigArgs0 _SigArgs0 ;
		protected bool     CallConvInstance ;
		protected override void main()
			{
			CallConv      = Arg2 ;
			type          = Argv[3] as A335.Type ;
			typeSpec      = Argv[4] as A335.Type.Spec ;
			// '::'
			//MethodName    = Arg6 ;
			// '('
			SigArgs0      = Arg8 ;
			// ')'
			MethodName    = Arg6 ;
			}
		protected Argument SigArgs0
			{
			set { if ( value is Argument )
					{
					var a = (Automatrix) value ;
					if( a is Automatrix )
						{
						_SigArgs0 = a as SigArgs0 ;
						}
					}
				}
			}
		protected Argument CallConv
			{
			set { CallConvList = ((Automatrix) value) as CallConv ; }
			}
		protected Argument MethodName
			{
			set { _Call = C_Symbol.Acquire( (C_Type)typeSpec + methodname( value ) + ( _SigArgs0 == null ? "" : _SigArgs0.Types() ) ) ; }
			}
		string methodname( Argument arg )
			{
			return ((Automatrix)arg) as A335.Method.Name ;
			}
		protected int Args
			{
			get { return ( _SigArgs0 == null ? 0 : _SigArgs0.Count() ) + ( CallConvInstance ? 1 : 0 ) ; }
			}
		public CallConv CallConvList
			{
			set { CallConvInstance = value is CallConv ? value.Instance : false ; }
			}
		}
	}

public partial class   instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____
	: Instr.Method	{
	protected override void render()
		{
		var d = oprand.C ;
		d.HasArgs = ( 0 < Args ) ;
		switch( Op )
			{
			case "CALL":
				{
				int iargs = Args ;
				var data = C.Hangup( iargs ) ;
				if( _SigArgs0 != null )
					{
					try {
						int i = CallConvInstance ? 1 : 0 ;
						_SigArgs0.ForEach( (a) =>
							{
							if( a != data[i].Type )
								{
								//type=pet( "nexus:CTS:get0,sphere,cube,square,point", a, data );
								}
							} ) ;
						}
					catch( C_Type.UndefinedTypeException )
						{
						/*
								this_program += "static struct _object obj = { 0 } ;" ;
								this_program += "obj.this = (void*) stack["+offset+"] ;" ;
								this_program += "stack[" + offset + "] =  &obj;" ;
						*/
						}
					}
				C_Symbol symbol = null ;
				Program.C_Function.Require( _Call ) ;
				if( type is type__string_ )
					{
					symbol = new C_Symbol() ;
					d.Statement( C699.C.Static(C699.String,symbol) ) ;
					System.Array.Resize( ref freeset, freeset.Length+1 ) ;
					freeset[freeset.Length-1] = C699.Stack.Offset ;
					C699.c s = new C699.c( symbol ) ;
					if( iargs == 0 )
						d.Statement( s.Equate(C699.C.Function(_Call)) ) ;
					else
						d.Statement( s.Equate(C699.C.Function(_Call,C699.Stack.Pointer)) ) ;
					d.Push( new C699.c("&"+symbol), type ) ;
					}
				else
				if( type is type__void_ )
					{
					if( iargs == 0 )
						d.Statement( C699.C.Function(_Call) ) ;
					else
						d.Statement( C699.C.Function(_Call,C699.Stack.Pointer) ) ;
					}
				else
						throw new System.NotImplementedException() ;
				break ;
				}
			case "NEWOBJ":
				{
				var symbol = new C_Symbol() ;
				C_Type _class = typeSpec ;
				int iargs  = Args ;
				C.Hangup( iargs - 1 ) ;
				d.Statement( C699.C.Extern.Void.Function(_Call,C699.C.Const.Voidpp) ) ;
				d.Statement( C699.C.Extern.Struct(C699.Object(0),_class) ) ;
				d.Statement( C699.C.Const.Static(C699.Object(0)).Equate(symbol,"&"+_class) ) ;
				d.Push( new C699.c("&"+symbol), "object" ) ;
				if( iargs == 0 )
					d.Statement( C699.C.Function(_Call) ) ;
				else
					d.Statement( C699.C.Function(_Call,C699.Stack.Pointer) ) ;
				break ;
				}
			default :
				log( "[INSTR_METHOD] Defaulted on " + Op ) ;
				return ;
			}
		}
	}
}
