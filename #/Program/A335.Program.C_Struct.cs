using System.Collections.Generic ;

partial class A335
{
partial class Program : C699
	{
	public class C_Struct
		{
		public C699.c Type ;
		public C_TypeDef TypeDef ;
		List<string> list = new List<string>() ;
		List<C_Type> parameterset = new List<C_Type>() ;
		public C_Struct( string type )
			{
			TypeDef = C_TypeDef.Acquire( type ) ;
			if( TypeDef.Struct == null )
				TypeDef.Struct = this ;
			switch( type )
				{
				case "string": Type = C699.String ; return ;
				case "object": Type = C699.Object("object") ; return ;
				case "mp":     Type = C699.Object(type) ; return ;
				default      : Type = C.Restricted("struct " + type) ; return ;
				}
			}
		public C_Struct()
			{
			Type = C699.Object("object") ;
			}
		public void Add( string text )
			{
			list.Add( text ) ;
			}
		public C_Struct Parameter( C_Type symbol )
			{
			list.Add( symbol.Type + " " + symbol ) ;
			parameterset.Add( symbol ) ;
			return this ;
			}
		public C_Struct Parameter( C699.c symbol, string text )
			{
			list.Add( symbol + " " + text ) ;
			return this ;
			}
		public C_Type this[int n]
			{
			get{ return parameterset[n] ; }
			}
		public void WriteTo( System.IO.StreamWriter sw )
			{
			sw.WriteLine( Type ) ;
			sw.WriteLine( "\t{" ) ;
			foreach( string s in list )
				sw.WriteLine( "\t" + s + " ;" ) ;
			sw.WriteLine( "\t} ;" ) ;
			sw.WriteLine() ;
			}
		}
	}
}
