partial class A335
{
public partial class Object : Stack.Item
	{
	protected object[] o ;
	public Object( object[] _ ) : base()
		{
		#if DEBUG_TOKEN
		System.Diagnostics.Debug.WriteLine( "<A Object " + GetType().Name + " />"  ) ;
		#endif
		o = _ ;
		}
	public Object( int n ) : base()
		{
		#if DEBUG_TOKEN
		System.Diagnostics.Debug.WriteLine( "<A Object " + GetType().Name + ">"  ) ;
		#endif
		o = new object[n+1] ;
		Stack.Pop( ref o ) ;
		o[0] = this ;
		#if DEBUG_TOKEN
		System.Diagnostics.Debug.WriteLine( "</A>"  ) ;
		#endif
		}
	public Stack.Item this[int n]
		{
		get { return (Stack.Item) o[n] ; }
		set { o[n] = value ; }
		}
	}
}
