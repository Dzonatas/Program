using System.Extensions ;
using System ;
using X.Predefined ;

public partial class A335
{

partial class X
	{
	static System.IntPtr ʄ ;
	static string x_server_vendor ;
	public static class Simple
		{
		static public IntPtr drawable ;
		static public IntPtr gc ;
		static public XAnyEvent _event ;
		static public IntPtr colormap ;
		static public Values values ;
		static public long   mask =
			GCValue.Background | GCValue.Foreground
			| GCValue.LineWidth | GCValue.Function
			| GCValue.LineStyle | GCValue.CapStyle
			| GCValue.JoinStyle | GCValue.GraphicsExposures ;
		static Simple()
			{
			":2".OpenDisplay( out ʄ ) ;
			ʄ.CreateSimpleWindow( out drawable ) ;
			ʄ.GCValues( ʄ.DefaultGC(), mask, out values ) ;
			values.Function  = GX.Set ;
			values.LineWidth = 1 ;
			values.GraphicsExposures = true ;
			ʄ.CreateGC( drawable, mask, ref values, out gc ) ;
			colormap = ʄ.CreateColormap( drawable, ʄ.DefaultVisual( ʄ.DefaultScreen() ), 0 ) ;
			XColor softcolor ;
			XColor hardcolor ;
			ʄ.LookupColor( colormap, "red", out softcolor, out hardcolor ) ;
			ʄ.AllocColor( colormap, ref softcolor ) ;
			values.Foreground = softcolor.Pixel ;
			ʄ.ChangeGC( gc, mask, ref values ) ;
			//ʄ.SetForeground( gc, softcolor.Pixel ) ;
			x_server_vendor = ʄ.ServerVendor() ;
			#if DEBUG
			System.Console.WriteLine( "X-ServerVendor: {0}", x_server_vendor ) ;
			#endif
			ʄ.SelectInput( drawable, 0xF ) ;
			}
		static public void Map()
			{
			ʄ.MapWindow( drawable ) ;
			loop:
			ʄ.NextEvent( out _event ) ;
			System.Console.WriteLine( "Event type: {0}", _event.Type ) ;
			for( int x = 0 ; x < 100 ; x ++ )
				ʄ.DrawPoint( drawable, gc, x, x ) ;
			goto loop ;
			}
		}
	}
}