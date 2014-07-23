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
		static public long   mask = GCValue.Function | GCValue.PlaneMask | GCValue.Background | GCValue.Foreground ;
		const  ulong  pmask  = ulong.MaxValue ;
		static Simple()
			{
			":0".OpenDisplay( out ʄ ) ;
			ʄ.CreateSimpleWindow( out drawable ) ;
			x_server_vendor = ʄ.ServerVendor() ;
			#if DEBUG
			System.Console.WriteLine( "X-ServerVendor: {0}", x_server_vendor ) ;
			#endif
			values.Function  = GX.Clear ;
			ʄ.CreateGC( drawable, GCValue.Function, ref values, out gc_erase ) ;
			ʄ.GCValues( ʄ.DefaultGC(), mask, out values ) ;
			values.Function  = GX.Set ;
			//values.PlaneMask = 0x77777777 ;
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
		static ulong response( XAnyEvent e )
			{
			switch( e.Type )
				{
				case 0 : return global::X.Predefined.Color.AluminiumExtraLight ;
				case 1 : return global::X.Predefined.Color.AluminiumLight ;
				case 2 : return global::X.Predefined.Color.AluminiumMediumLight ;
				case 3 : return global::X.Predefined.Color.AluminiumMediumDark ;
				case 4 : return global::X.Predefined.Color.AluminiumDark ;
				case 5 : return global::X.Predefined.Color.AluminiumExtraDark ;
				}
			switch( e.Serial % 10 )
				{
				case 0 : return global::X.Predefined.Color.Butter ;
				case 1 : return global::X.Predefined.Color.Orange ;
				case 2 : return global::X.Predefined.Color.Chocolate ;
				case 3 : return global::X.Predefined.Color.Chameleon ;
				case 4 : return global::X.Predefined.Color.SkyBlue ;
				case 5 : return global::X.Predefined.Color.Plum ;
				case 6 : return global::X.Predefined.Color.ScarletRed ;
				default: return ulong.MaxValue ;
				}
			}
		static public void QuickResponseEncodedSplash( XAnyEvent e )
			{
			values.PlaneMask = response( e ) ;
			ʄ.ChangeGC( gc, GCValue.PlaneMask, ref values) ;
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
				Simple.QuickResponseEncodedSplash( _event.XAny ) ;
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