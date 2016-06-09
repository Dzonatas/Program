using System.Collections.Generic ;
using System.Extensions ;

partial class A335
{
partial class Program : C699
	{
	public class C_Oprand : Program
		{
		C_Function function ;
		public string Instruction ;
		public bool HasArgs ;
		public bool BrTarget ;
		public List<C699.c> GCBefore  = new List<C699.c>() ;
		List<C699.c> list             = new List<C699.c>() ;
		public List<C699.c> GCAfter   = new List<C699.c>() ;
		public C_Method Method
			{
			get { return function.Method ; }
			}
		public C_Oprand( C_Function function, string instr )
			{
			this.function = function ;
			Instruction = System.Text.RegularExpressions.Regex.Replace( instr, "[^A-Za-z_0-9]", "_").ToUpper() ;
			}
		public C_Oprand GotoStatement( string label )
			{
			if( ! BrTarget )
				throw new System.NotImplementedException() ;
			list.Add( C.Goto( label ) ) ;
			return this ;
			}
		public C_Oprand Statement( C699.c c )
			{
			list.Add( c ) ;
			return this ;
			}
		public void Push( C699.c value, C_Type type )
			{
			Statement( Stack.Assign( value, type.Spec ) ) ;
			Push( type ) ;
			}
		public void PushRef( C_ValueType vt )
			{
			for( int i = 0 ; i < freeset.Length ; i++ )
				if( freeset[i].Symbol == vt.Symbol )
					freeset[i].Offset++ ;
			vt.Type = vt.Type.Ref ;
			Statement( Stack.Assign( new c("&"+vt.Symbol), vt.Type.Spec ) ) ;
			stack[stack_offset] = vt ;
			stack_offset++ ;
			}
		public C_ValueType Allocate(C_Type type)
			{
			var vt = new C_ValueType()
				{
				Symbol = new C_Symbol() ,
				Offset = stack_offset ,
				Type   = C_Type.Static( type.Deref.Spec )
				} ;
			var mp = new C_ValueType()
				{
				Symbol = vt.Symbol ,
				Offset = stack_offset ,
				Type   = C_Type.Static( type.Spec )
				} ;
			System.Array.Resize( ref function.ManagedPointers, function.ManagedPointers.Length+1 ) ;
			function.ManagedPointers[function.ManagedPointers.Length-1] = mp ;
			C_TypeDef typedef = typedefset["string"] ;
			string _string = typedef.Struct[1] ;
			GCAfter.Add( C699.C.Struct( new c("_mp") )
				.Equate( mp.Symbol+"_mp", "1,(void*) ("+mp.StackDeref+")->"+_string ) );
			Statement( C699.C.Struct(vt.Type.TypeSpec, vt.Symbol) ) ;
			System.Array.Resize( ref freeset, freeset.Length+1 ) ;
			freeset[freeset.Length-1] = vt ;
			return vt ;
			}
		public C_ValueType AllocateArray(C_Type type)
			{
			var vt = new C_ValueType()
				{
				Symbol = new C_Symbol() ,
				Offset = stack_offset ,
				Type   = C_Type.Static( type.Deref.Spec )
				} ;
			/*
			var mp = new C_ValueType()
				{
				Symbol = vt.Symbol ,
				Offset = stack_offset ,
				Type   = C_Type.Static( type.Spec )
				} ;
			System.Array.Resize( ref function.ManagedPointers, function.ManagedPointers.Length+1 ) ;
			function.ManagedPointers[function.ManagedPointers.Length-1] = mp ;
			C_TypeDef typedef = typedefset["string"] ;
			string _string = typedef.Struct[1] ;
			GCAfter.Add( C699.C.Struct( new c("_mp") )
				.Equate( mp.Symbol+"_mp", "1,(void*) ("+mp.StackDeref+")."+_string ) );
			*/
			Statement( C699.C.Struct(vt.Type.TypeSpec, vt.Symbol) ) ;
			/*
			System.Array.Resize( ref freeset, freeset.Length+1 ) ;
			freeset[freeset.Length-1] = vt ;
			*/
			return vt ;
			}
		public C_ValueType Allocate(C699.c type, string args)
			{
			return Allocate(C_Type.ConstStatic(type), args) ;
			}
		public C_ValueType Allocate(C_Type type, string args)
			{
			var vt = new C_ValueType()
				{
				Symbol = new C_Symbol() ,
				Offset = stack_offset ,
				Type   = C_Type.ConstStatic( type.Deref.Spec )
				} ;
			var mp = new C_ValueType()
				{
				Symbol = vt.Symbol ,
				Offset = stack_offset ,
				Type   = C_Type.ConstStatic( type.Spec )
				} ;
			System.Array.Resize( ref function.ManagedPointers, function.ManagedPointers.Length+1 ) ;
			function.ManagedPointers[function.ManagedPointers.Length-1] = mp ;
			C_TypeDef typedef = typedefset["string"] ;
			string _string = typedef.Struct[1] ;
			GCAfter.Add( C699.C.Struct( new c("_mp") )
				.Equate( mp.Symbol+"_mp", "0,(void*) ("+mp.StackDeref+")->"+_string ) );
			Statement( vt.Type.TypeSpec.Equate(vt.Symbol,args) ) ;
			System.Array.Resize( ref freeset, freeset.Length+1 ) ;
			freeset[freeset.Length-1] = vt ;
			return vt ;
			}
		public void WriteTo( System.IO.TextWriter tw )
			{
			tw.WriteLine( "{// "+Instruction ) ;
			foreach( C699.c s in list )
				tw.WriteLine( "\t\t"+s+" ;" ) ;
			tw.Write( "\t}" ) ;
			}
		}
	}
}