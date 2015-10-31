public partial class A335
{
public partial class Method
	{
	static Head head ;
	static Head begin ;
	public class Locals
		{
		public struct Local
			{
			public C_Symbol Symbol ;
			public C_Type   Type ;
			public string   ID ;
			}
		SigArgs0 args ;
		Local[] local ;
		public Locals( SigArgs0 args )
			{
			this.args = args ;
			local = new Local[args.Count()] ;
			int i = 0 ;
			this.args.ForEach( (a) =>
					{
					local[i] = new Local() ;
					local[i].Symbol = C_Symbol.Acquire( "_local"+i ) ;
					local[i].Type   = a.Type ;
					local[i].ID     = a._ID ;
					i++ ;
					}
				);
			}
		public Local this[ int index ]
			{
			get { return local[index] ; }
			}
		public Local this[ string name ]
			{
			get {
				for( int i = 0 ; i < local.Length ; i++ )
					{
					if( local[i].ID == name )
						return local[i] ;
					}
				throw new System.ArgumentException() ;
				}
			}
		public void WriteTo( Program.C_Function f )
			{
			foreach( Local l in local )
				{
				C699.c c = new C699.c() ;
				C699.c type ;
				switch( (C_Symbol) l.Type )
					{
					case "int32": c = c.Local( type = C699.C.Int, l.Symbol ) ;
						break ;
					case "struct _string ":
						c = c.Struct( type = C699.String, l.Symbol ) ;
						break ;
					default:
						throw new System.NotImplementedException() ;
					}
				//d.Statement( c.Equate( C699.Stack.Deref(C.StackOffset,type) ) ) ;
				f.Statement( c ) ;
				}
			}
		}
	static public void WriteIncludesTo( System.IO.StreamWriter sw )
		{
		for( Head i = Head.Begin ; i is Head ; i = i.Next )
			i.WriteInclude( sw ) ;
		}
	static public void Write()
		{
		for( Head i = Head.Begin ; i is Head ; i = i.Next )
			i.Write() ;
		}
	static Decl _EntryPoint ;
	static public Decl EntryPoint
		{
		get { return _EntryPoint ; }
		}
	static public void Start()
		{
		#if SYSTEM_GUID
		if( system.guid == null )
			{
			xml_load_grammar() ;
			byte []    b = system_ip.GetAddressBytes() ;
			Array.Reverse( b ) ;
			/*
			system       = b_enter( b[3], b[2], b[1], b[0] ) ;
			system.guid  = Guid.Empty ;
			*/
			}
		#else
		//xml_load_grammar() ;
		#endif
		}
	static public void WriteList( Program.C_Function function, Decl declList )
		{
		for( A335.Method.Decl d = declList ; d is A335.Method.Decl ; d = d.Next )
			{
			if( d.Label != null && d.Label.Required )
				function.Label( d.Label ) ;
			else
			if( d.Instr != null )
				function.Statement( d.Instr ) ;
			}
		}
	}
}
