partial class A335
{
public partial class Method
	{
	static Decl entryPoint ;
	public struct Local
		{
		public C_Symbol Symbol ;
		public string   ID ;
		public Type     Type ;
		}
	public class Locals
		{
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
					local[i].Type   = a ;
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
				f.Statement( C699.C.Local( l.Type, l.Symbol ) ) ;
				var ct1 = ((string)C699.String.p).Trim() ;
				var ct2 = ((string)((C_Type)l.Type).Spec).Trim() ;
				if( ct1 == ct2 )
					f.Statement( f.Allocate( l ) ) ;
				}
			}
		}
	static public Decl EntryPoint
		{
		get { return entryPoint ; }
		set { entryPoint = value ; }
		}
	static public Head Declared( Head h, Decls d )
		{
		d.Head  = h ;
		h.Decls = d ;
		return h ;
		}
	}
}
