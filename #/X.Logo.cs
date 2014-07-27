using System.Extensions ;
using System ;
using X.Predefined ;
using X.String ;

using Fixture = System.IntPtr ;

public partial class A335
{


partial class XLogo
	{
	#if O1AUTHUNK
	static public IntPtr _ ;
	static public IntPtr Rubis ;
	static public IntPtr Q ;
	static public IntPtr Bit ;
	#endif
	static System.IntPtr ʄ ;
	static Fixture x_server_vendor ;
	static public XEvent _event ;
	int  CSS = A335.b_muon_css ;
	char MAP = A335.b_custom_map ;
	static int max_x ;
	static int max_y ;
	#if INTERACTIVE
	//XEvent[] instructions ;
	#else
	Simple simple ;
	#endif
	public XLogo()
		{
		XIPv6.alpha.beta.Display = ʄ = X.Display ;
		#if O1AUTHUNK
		switch( ʄ )
			{
			case _
			case Rubis
			case Q
			case Bit
			}
		#endif
		XIPv6.alpha.Switch(
			() => { return 1 ; },
			() => { (simple = new Simple()).Map() ; return 2 ; },
			() => { return 3 ; },
			ref _event.XAny
			);
		}
	public class Simple
		{
		static Random bit = new Random() ;
		static public IntPtr drawable ;
		static public IntPtr gc ;
		static public IntPtr gc_erase ;
		static public Values values ;
		static public long   mask = GCValue.Function | GCValue.PlaneMask | GCValue.Background | GCValue.Foreground ;
		const  ulong  pmask  = ulong.MaxValue ;
		public Simple()
			{
			//":0".OpenDisplay( out ʄ ) ;
			IntPtr d = ʄ ;
			ʄ.CreateSimpleWindow( out drawable ) ;
			x_server_vendor = ʄ.ServerVendor() ;
			System.Console.WriteLine( "X-ServerVendor: {0}", x_server_vendor ) ;
			values.Function  = GX.Clear ;
			ʄ.CreateGC( drawable, GCValue.Function, ref values, out gc_erase ) ;
			ʄ.GCValues( ʄ.DefaultGC(), mask, out values ) ;
			values.Function  = GX.Set ;
			//values.PlaneMask = 0x77777777 ;
			ʄ.CreateGC( drawable, mask, ref values, out gc ) ;
			ʄ.SelectInput( drawable, 0xFFFFFF ) ;
			}
		public void Map()
			{
			ʄ.MapWindow( drawable ) ;
			}
		static int degree = 45 ;
		static public void plot( int x, int y, int size )
			{
			var border = 300 ;
			Decimal i = 300 ; //(Decimal)border - border ;
			var rad_i  = Math.PI/180 ;
			var arc_i  = degree*rad_i ;

			//var radius = (Decimal)border / 2 ;
			var cosine = (Decimal)Math.Cos(arc_i) ;
			var sine   = (Decimal)Math.Sin(arc_i) ;

			#if !BITR
			//Z
			Decimal dx = (Decimal)x + y * cosine ;
			Decimal dy = (Decimal)y + x * sine ;

			x = (int)dx ;
			y = (int)dy ;
			#else
			//icyspherical.blogspot.com/2010/07/optimizing-simulations-with-basic.html
			//YX
			Decimal dx = (Decimal)x * cosine - y * sine ;
			Decimal dy = (Decimal)x * sine + y * cosine ;

			x = (int)dx + border /2;
			y = (int)dy + border /5;
			#endif

			IntPtr _gc ;
			if( bit.Next(2) == 0 ? false : true )
				_gc = gc ;
			else
				_gc = gc_erase ;
			for( int x_i = 0 ; x_i < size ; x_i++ )
				for( int y_i = 0 ; y_i < size ; y_i++ )
					{
					if( x+x_i > max_x ) max_x = x+x_i ;
					if( y+y_i > max_y ) max_y = y+y_i ;
					if( x+x_i < 300 && y+y_i < 300 )
						ʄ.DrawPoint( drawable, _gc, x+x_i, y+y_i ) ;
					}
			}
			static ulong serial ;
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
			ulong w = (ulong)((long)e.Serial - (long)serial + (long)3) ;
			serial = e.Serial ;
			switch( w )
				{
				case 0 : return global::X.Predefined.Color.Butter ;
				case 1 : return global::X.Predefined.Color.Orange ;
				case 2 : return global::X.Predefined.Color.Chocolate ;
				case 3 : return global::X.Predefined.Color.Chameleon ;
				case 4 : return global::X.Predefined.Color.SkyBlue ;
				case 5 : return global::X.Predefined.Color.Plum ;
				case 6 : return global::X.Predefined.Color.ScarletRed ;
				default: return ( e.SendEvent ? ulong.MinValue : 0xFFFFFF ) ;
				}
			}
		static public void QuickResponseEncodedSplash( XAnyEvent e )
			{
			#if !BITR
			const int l = 300 ;
			#else
			const int l = 128 ;
			#endif
			values.PlaneMask = response( e ) ;
			degree = 45 ;
			ʄ.ChangeGC( gc, GCValue.PlaneMask, ref values) ;
			for( int i = bit.Next(4) ; i > 0 ; i-- )
				for( int x = 0 ; x < l ; x+= i+1 )
					for( int y = 0 ; y < l ; y+= i+1 )
						plot( x, y, i+1 ) ;
			Random yy = new Random() ;
			for( int x = 0 ; x < l ; x++ )
					plot( x,  yy.Next(l), 1 ) ;
			}
		}
	static XAnyEvent zone ;
	public void Window()
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
					System.Console.WriteLine("{0} {1}", max_x, max_y) ;
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

namespace X.String
{
class StandardStringInput  : StandardStringError {}
class StandardStringOutput : StandardStringError {}
class StandardStringError  {}
class TZN : TZ {}
class TZS : TZ {}
class TZ : StandardZone {}
class StandardZone : BuildString /*: A335.Zone*/ {}
class BuildString {}
}
