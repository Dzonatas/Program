using System.Extensions ;
using System ;
using X.Predefined ;

public partial class A335
{

partial class X
	{
	static System.IntPtr ʄ ;
	static string x_server_vendor ;
	static public XEvent _event ;
	public static class Simple
		{
		static public IntPtr drawable ;
		static public IntPtr gc ;
		static public Values values ;
		static public long   mask = GCValue.Function | GCValue.Background | GCValue.Foreground ;
		static Simple()
			{
			":0".OpenDisplay( out ʄ ) ;
			ʄ.CreateSimpleWindow( out drawable ) ;
			x_server_vendor = ʄ.ServerVendor() ;
			#if DEBUG
			System.Console.WriteLine( "X-ServerVendor: {0}", x_server_vendor ) ;
			#endif
			ʄ.GCValues( ʄ.DefaultGC(), mask, out values ) ;
			values.Function  = GX.Set ;
			ʄ.CreateGC( drawable, mask, ref values, out gc ) ;
			ʄ.SelectInput( drawable, 0xFFFFFF ) ;
			}
		static public void Map()
			{
			ʄ.MapWindow( drawable ) ;
			}
		static public void Redraw()
			{
			Random y = new Random() ;
			for( int x = 0 ; x < 300 ; x++ )
				ʄ.DrawPoint( drawable, gc, x, y.Next( 300 ) ) ;
			}
		}
	static XAnyEvent zone ;
	static public void Window()
		{
		zone = XStart.ip ;
		loop:
		ʄ.NextEvent( out _event ) ;
		switch( _event.Type )
			{
			case 4:
				if( zone.Type != _event.Type )
					{
					XStart.ip = zone ;
					return ;
					}
				break ;
			case 5:
				if( zone.Type != _event.Type )
					{
					XStop.time = zone ;
					return ;
					}
				break ;
			default:
				zone = _event.XAny ;
				Simple.Redraw() ;
				goto loop ;
			}
		System.Console.WriteLine( "zone: {0} {1}", _event.Type, _event.XAny.Serial ) ;
		for(;;) goto loop ;
		}
	class XStart : Zone.Start
		{
		public static XAnyEvent ip = new XAnyEvent() ;
		}
	class XStop  : Zone.Stop
		{
		public static XAnyEvent time = new XAnyEvent() ;
		}
	}
}