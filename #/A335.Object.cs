partial class A335
{
public partial class Object : Stack.Item
	{
	protected object[] o ;
	public Object( object[] _ ) : base()
		{
		System.Diagnostics.Debug.WriteLine( "<A Object " + GetType().Name + " />"  ) ;
		o = _ ;
		}
	public Object( int n ) : base()
		{
		System.Diagnostics.Debug.WriteLine( "<A Object " + GetType().Name + ">"  ) ;
		o = new object[n+1] ;
		Stack.Pop( ref o ) ;
		o[0] = this ;
		System.Diagnostics.Debug.WriteLine( "</A>"  ) ;
		}
	public Stack.Item this[int n]
		{
		get { return (Stack.Item) o[n] ; }
		set { o[n] = value ; }
		}
	}
}
