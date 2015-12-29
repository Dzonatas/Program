partial class A335
{
partial class Program : C699
	{
	public _TypeDef TypeDef
		{
		get { return new _TypeDef() ; }
		}
	public class _TypeDef
		{
		public C_Struct String
			{
			get { return new C_Struct("string") ; }
			}
		public C_Struct Object
			{
			get { return new C_Struct("object") ; }
			}
		public C_Struct Type( string type )
			{
			return new C_Struct(type) ;
			}
		}
	public class C_TypeDef
		{
		C_Symbol symbol ;
		C_Type   alias ;
		public C_Struct Struct ;
		C_TypeDef( string symbol, C_Type alias )
			{
			//ID = Guid.NewGuid() ;
			this.symbol = C_Symbol.Acquire( symbol ) ;
			this.alias  = alias ;
			}
		static public C_TypeDef Acquire( string symbol )
			{
			C_TypeDef c;
			if( typedefset.ContainsKey( symbol ) )
				c = typedefset[symbol] ;
			else
				typedefset.Add( symbol, c = new C_TypeDef( symbol, C_Type.Acquire( string.Empty ) ) ) ;
			return c ;
			}
		static public bool Declared( string S )
			{
			return typedefset.ContainsKey( S ) ;
			}
		}
	}
}
