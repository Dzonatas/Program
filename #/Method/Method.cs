partial class A335
{
public partial class Method
	{
	static Head head ;
	static Head begin ;
	static Decl entryPoint ;
	public class Locals
		{
		public struct Local
			{
			public C_Symbol Symbol ;
			public string   ID ;
			public Type     Type ;
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
					local[i].ID     = a ;
					local[i].Type  = a ;
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
				f.Statement( C699.C.Local( l.Type, l.Symbol ) ) ;
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
	static public Decl EntryPoint
		{
		get { return entryPoint ; }
		set { entryPoint = value ; }
		}
	#if BEGINNING
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
	#endif
	static public Head Declared( Head h, Decls d )
		{
		d.Head  = h ;
		h.Decls = d ;
		return h ;
		}
	}
}
