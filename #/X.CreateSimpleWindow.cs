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
		static Random bit = new Random() ;
		static public IntPtr drawable ;
		static public IntPtr gc ;
		static public IntPtr gc_erase ;
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
			values.Function  = GX.Clear ;
			ʄ.CreateGC( drawable, mask, ref values, out gc_erase ) ;
			ʄ.GCValues( ʄ.DefaultGC(), mask, out values ) ;
			values.Function  = GX.Set ;
			ʄ.CreateGC( drawable, mask, ref values, out gc ) ;
			ʄ.SelectInput( drawable, 0xFFFFFF ) ;
			}
		static public void Map()
			{
			ʄ.MapWindow( drawable ) ;
			}
		static public void plot( int x, int y, int size )
			{
			IntPtr _gc ;
			if( bit.Next(2) == 0 ? false : true )
				_gc = gc ;
			else
				_gc = gc_erase ;
			for( int x_i = 0 ; x_i < size ; x_i++ )
				for( int y_i = 0 ; y_i < size ; y_i++ )
					if( x+x_i < 300 && y+y_i < 300 )
						ʄ.DrawPoint( drawable, _gc, x+x_i, y+y_i ) ;
			}
		static public void QuickResponseEncodedSplash()
			{
			ʄ.DrawPoint( drawable, gc, 0, 0 ) ;
			ʄ.DrawPoint( drawable, gc_erase, 0, 0 ) ;
			for( int i = bit.Next(4) ; i > 0 ; i-- )
				for( int x = 0 ; x < 300 ; x+= i+1 )
					for( int y = 0 ; y < 300 ; y+= i+1 )
						plot( x, y, i+1 ) ;
			Random yy = new Random() ;
			for( int x = 0 ; x < 300 ; x++ )
					plot( x,  yy.Next(300), 1 ) ;
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
				Simple.QuickResponseEncodedSplash() ;
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