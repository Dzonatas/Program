using System ;

//http://icyspherical.blogspot.com/2012/05/gtkstatusicon-what-every-app-needs.html

namespace Application
	{
	[Program.Singleton]
	sealed class StatusIcon : Gtk.StatusIcon
		{
		Menu         menu      = new Menu() ;
		
		static StatusIcon()
			{
			Gtk.Application.Init() ;
			}

		private StatusIcon()
			{
			Program.Initialize   += initialize ;
			Program.Run          += run ;
			}
		
		~StatusIcon()
			{
			Program.Initialize   -= initialize ;
			Program.Run          -= run ;
			}
			
		void initialize() 
			{
			Tooltip       = "Application" ;
			Stock         = Gtk.Stock.DialogQuestion ;
			Visible       = true ;
			Activate     += (o,e) => popup() ;
			PopupMenu    += (o,e) => popup() ;
			}
		
		void run()
			{
			Gtk.Application.Run() ;
			}

		void popup()
			{
			PresentMenu( menu, 0, Gtk.Global.CurrentEventTime ) ;
			}

		class Menu : Gtk.Menu
			{
			public Menu()
				{
				Gtk.MenuItem mi ;
				Append( mi = new Gtk.MenuItem( "Option _1" ) ) ;
				Append( mi = new Gtk.MenuItem( "Option _2" ) ) ;
				Append( mi = new Gtk.MenuItem( "Quit" ) ) ;
				mi.Activated += (o,e) => Gtk.Application.Quit() ;
				ShowAll() ;
				}
			}
		}
	}