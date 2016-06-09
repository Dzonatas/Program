partial class A335
{
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
			MethodName    = Argv[6] as A335.Method.Name ;
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
		protected A335.Method.Name MethodName
			{
			set { _Call = C_Symbol.Acquire( (C_Type)typeSpec + methodname( value ) + ( _SigArgs0 == null ? "" : _SigArgs0.Types() ) ) ; }
			}
		string methodname( A335.Method.Name value )
			{
			return (string) (C_Symbol) value ;
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
							bool jiffy = false ;
							var sig = ( (string)(C_Type)((A335.Type)a) ).Trim() ;
							var vt  = ( (string)(data[i].Type.Spec) ).Trim() ;
							string v = vt.Replace("struct","").Replace("*","").Trim() ;
							if( sig == "struct object" && v != "string" && ! Class.Head.Find(v).ValueType )
								jiffy = false ;
							else
							if( sig != vt )
								jiffy = true ;
							if( jiffy )
								{
								var symbol = new C_Symbol() ;
								C.jiffy( "string* object::"+symbol+"()" )
									.Instantiated()
									.Statement( "return (struct string *)((struct object *)argv[0])->data" ) ;
								Program.C_Function.Require( "System$Object$"+symbol ) ;
								string o = "obj"+i ;
								d.Statement( new C699.c("static struct object "+o+" = { 0 }")) ;
								d.Statement( new C699.c(""+o+".$ToString = System$Object$"+symbol) ) ;
								d.Statement( new C699.c(""+o+".data = (void*)"+data[i].StackElement) ) ;
								d.Statement( new C699.c(""+data[i].StackElement.Equate( "&"+o )) ) ;
								}
							i++ ;
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
				Program.C_Function.Require( _Call ) ;
				if( type is type__string_ )
					{
					var vt = d.Allocate(type) ;
					C699.c s = new C699.c( vt.Symbol ) ;
					if( iargs == 0 )
						d.Statement( s.Equate(C699.C.Function(_Call)) ) ;
					else
						d.Statement( s.Equate(C699.C.Function(_Call,C699.Stack.Pointer)) ) ;
					d.PushRef( vt ) ;
					}
				else
				if( type is type__int32_ )
					{
					d.Push( C699.C.Three, C_I4_3 ) ; //bogus
					oprand.C.Statement(new C699.c("/*new implementation*/")) ;
					}
				else
				if( type is type__bool_ )
					{
					d.Push( C699.C.Three, C_I4_3 ) ; //bogus
					oprand.C.Statement(new C699.c("/*new implementation*/")) ;
					}
				else
				if( type is type__int16_ )
					{
					d.Push( C699.C.Three, C_I4_3 ) ; //bogus
					oprand.C.Statement(new C699.c("/*new implementation*/")) ;
					}
				else
				if( type is type__void_ )
					{
					var t = new C699.c(type) ;
					var args = (iargs == 0) ? C699.C.Void : C699.C.Const.Voidpp ;
					d.Statement( C699.C.Extern.Type(t).Function(_Call,args) ) ;
					if( iargs == 0 )
						d.Statement( C699.C.Function(_Call) ) ;
					else
						d.Statement( C699.C.Function(_Call,C699.Stack.Pointer) ) ;
					}
				else
					{
					var vt = d.Allocate(type) ;
					d.PushRef( vt ) ;
					oprand.C.Statement(new C699.c("/*new implementation*/")) ;
					}
				break ;
				}
			case "CALLVIRT" :
				{
				int iargs = Args ;
				C.Hangup( iargs - 1 ) ;
				var v = C.Pop() ;
				var typeSpec = Argv[4] as A335.Type.Spec ;
				var t = type ;
				if( t is type_____int32 )
					t = typeSpec.GenericArgument( int.Parse(type.Arg2.Token) ) ;
				if( t is type__string_ )
					{
					var vt = d.Allocate(t) ;
					var call = "*("+v.StackCast+")->"+(Argv[6] as A335.Method.Name) ;//C_Symbol.Acquire( (C_Type)typeSpec + methodname( value ) + ( _SigArgs0 == null ? "" : _SigArgs0.Types() ) ) ;
					C699.c s = new C699.c( vt.Symbol ) ;
					if( iargs == 0 )
						d.Statement( s.Equate(C699.C.Function(call)) ) ;
					else
						d.Statement( s.Equate(C699.C.Function(call,C699.Stack.Pointer)) ) ;
					d.PushRef( vt ) ;
					}
				else
				if( t is type_type_square_brackets )
					{
					//var vt = d.AllocateArray(t) ;
					var call = "("+v.StackCast+")->"+(Argv[6] as A335.Method.Name) ;
					var sp = C699.Stack.Pointer ;
					if( iargs == 0 )
						d.Push( C699.C.Function(call), t ) ;
					else
						d.Push( C699.C.Function(call,sp), t ) ;
					}
				else
				if( t is type__int32_ )
					d.Push( new C699.c(Arg1.Token), C_Type.Acquire(C699.C.Int) ) ;
				else
				if( t is type__void_ )
					{
					if( iargs == 0 )
						d.Statement( C699.C.Function(_Call) ) ;
					else
						d.Statement( C699.C.Function(_Call,C699.Stack.Pointer) ) ;
					}
				else
					throw new System.NotImplementedException() ;
				}
				break ;
			case "NEWOBJ":
				{
				C699.c ts = typeSpec ;
				if( ((string)ts).Contains("genArgs") )
					{
					var symbol = new C_Symbol() ;
					if( Args == 3 )
						{
						var ftn = C.Pop() ;
						var obj = C.Pop() ;
						//d.Statement( C699.C.Extern.Void.Function(_Call,C699.C.Const.Voidpp) ) ;
						d.Statement( C699.C.Static(C699.C.Struct(typeSpec),symbol) ) ;
						d.Statement( new C699.c(symbol+".this").Equate(obj.StackCast) ) ;
						d.Statement( new C699.c(symbol+".$Invoke").Equate(ftn.StackCast) ) ;
						}
					else
					if( Args == 1 )
						{
						d.Statement( C699.C.Static(C699.C.Struct(typeSpec),symbol) ) ;
						}
					else
						throw new System.NotImplementedException() ;
					var sp = C699.Stack.Pointer ;
					d.Push( new C699.c("&"+symbol), C_Type.Acquire(C699.C.Struct(typeSpec).p) ) ;
					//d.Statement( C699.C.Function(_Call,sp) ) ;
					break ;
					}
				else
				if( (string) ts == "System$Exception" )
					{
					var t = C_Type.Static(C699.Object(ts)) ;
					var symbol = new C_Symbol() ;
					int iargs  = Args ;
					C.Hangup( iargs - 1 ) ;
					d.Statement( C699.C.Struct(t.TypeSpec,symbol) ) ;
					d.Push( new C699.c("&"+symbol), t.Ref ) ;
					break ;
					}
				else
					{
					var head = Class.Head.Find(typeSpec) ;
					var t = C_Type.Static(C699.Object(ts)) ;
					var symbol = new C_Symbol() ;
					//C_Type _class = typeSpec ;
					int iargs  = Args ;
					C.Hangup( iargs - 1 ) ;
					d.Statement( C699.C.Extern.Void.Function(_Call,C699.C.Const.Voidpp) ) ;
					d.Statement( C699.C.Struct(t.TypeSpec,symbol) ) ;
					if( head.ExtendedSystemObject )
						{
						d.Statement( C699.C.Extern.Type(C699.String.p).Function(ts+"$ToString",C699.C.Const.Voidpp) ) ;
						d.Statement( C699.C.Literal(symbol+".base.$ToString").Equate(ts+"$ToString") ) ;
						}
					head.ForEachVirtualMethod( (mh) =>
						{
						d.Statement( mh.ToStructMemberAssign(symbol,head) ) ;
						} ) ;
					var sp = C699.Stack.Pointer ;
					d.Push( new C699.c("&"+symbol), t.Ref ) ;
					if( iargs == 0 )
						d.Statement( C699.C.Function(_Call) ) ;
					else
						d.Statement( C699.C.Function(_Call,sp) ) ;
					/*
					var t = C_Type.ConstStatic(C699.Object) ;
					var symbol = new C_Symbol() ;
					C_Type _class = typeSpec ;
					int iargs  = Args ;
					C.Hangup( iargs - 1 ) ;
					d.Statement( C699.C.Extern.Void.Function(_Call,C699.C.Const.Voidpp) ) ;
					d.Statement( C699.C.Extern.Struct(C699.Object,_class) ) ;
					d.Statement( t.TypeSpec.Equate(symbol,"&"+_class) ) ;
					var sp = C699.Stack.Pointer ;
					d.Push( new C699.c("&"+symbol), t ) ;
					if( iargs == 0 )
						d.Statement( C699.C.Function(_Call) ) ;
					else
						d.Statement( C699.C.Function(_Call,sp) ) ;
					*/
					}
				break ;
				}
			case "LDFTN" :
				{
				if( type is type__string_ )
					{
					d.Statement( C699.C.Extern.Type(type).Function(_Call) ) ;
					d.Push( new C699.c(_Call), C_Type.Acquire( C699.C.Void.p ) ) ;
					}
				else
				if( type is type__int32_ )
					{
					d.Statement( C699.C.Extern.Type(type).Function(_Call) ) ;
					d.Push( new C699.c(_Call), C_Type.Acquire( C699.C.Void.p ) ) ;
					}
				else
					throw new System.NotImplementedException() ;
				}
				break ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	}
}
