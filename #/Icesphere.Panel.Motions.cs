/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Timers ;
using Snowglobe ;
using System ;
using Gtk ;
using Glade ;

namespace Icesphere.Panel
	{
	public class Motions : UI.View
		{
		#pragma warning disable 649
		[Glade.Widget] internal Gtk.Frame      FrameMotionsWalk ;
		[Glade.Widget] internal Gtk.Frame      FrameMotionsRun ;
		[Glade.Widget] internal Gtk.Frame      FrameMotionsFly ;
		[Glade.Widget] internal Gtk.Frame      FrameMotionsSit ;
		[Glade.Widget] internal Gtk.Frame      FrameMotionsSitGround ;
		[Glade.Widget] internal Gtk.Frame      FrameMotionsStand ;
		[Glade.Widget] internal Gtk.Frame      FrameMotionsStand1 ;
		[Glade.Widget] internal Gtk.Frame      FrameMotionsStand2 ;
		[Glade.Widget] internal Gtk.Frame      FrameMotionsStand3 ;
		[Glade.Widget] internal Gtk.Frame      FrameMotionsStand4 ;
		#pragma warning restore 649
			
		static Dictionary<UUID,UUID>               replace        = new Dictionary<UUID,UUID>() ;

		class Override
			{
			Gtk.Frame                  frame ; 
			Gtk.Label                  label ;
			Gtk.EventBox               box   ;
			UUID                       original ;
			Snowglobe.Inventory.Item   item ;

			void loaded( Snowglobe.Inventory.Item item )
				{
				if( item.Type != "animation" )
					return ;
				label.Text         = item.Name ;
				replace[original]  = item.AssetID ;
				}

			void dropped( object o, Gtk.DragDataReceivedArgs args )
				{
				if( args.SelectionData.Length == -1 )
					return ;
				switch( args.SelectionData.Target.Name )
					{
					case "InventoryItem":
						string text = System.Text.Encoding.UTF8.GetString( args.SelectionData.Data ) ;
						item = Snowglobe.Inventory.Item.Find( new UUID( text ) ) ;
						replace.Remove( original ) ;
						label.Text = "" ;
						item.Query( loaded ) ;
						break ;
					}
				}

			public Override( Gtk.Frame frame, UUID original )
				{
				this.frame            = frame ;
				this.original         = original ;
				label                 = new Gtk.Label( "" ) ;
				box                   = new Gtk.EventBox() ;
				box.DragDataReceived += dropped ;
				box.AboveChild        = true ;
				box.Add( label ) ;
				((Gtk.Alignment)frame.Child).Add( box ) ;
				frame.ShowAll() ;
				Gtk.TargetEntry[]   te = new Gtk.TargetEntry[]
					{
					new Gtk.TargetEntry( "InventoryItem", 0, 0 )
					} ;
				Gtk.Drag.DestSet( box, Gtk.DestDefaults.All, te, Gdk.DragAction.Copy ) ;
				Gtk.Drag.DestSetTargetList( box, new Gtk.TargetList( te ) ) ;
				}
			}

		Override[] overrides ;

		public void Update( Dictionary<UUID,bool> motions )
			{
			UUID[] ids = new UUID[motions.Count] ;
			motions.Keys.CopyTo( ids, 0 ) ;
			lock( this )
				{
				foreach( UUID id in ids )
					{
					//Debug.WriteLine("--: {0} {1}", motions[id], Agent.Animation.Lookup( id )  ) ;
					if( replace.ContainsKey( id ) )
						{
						motions[replace[id]] = motions[id] ;
						motions[id] = false ;
						//Debug.WriteLine( "replaced" ) ;
						}
					}
				}
			//s = list ;
			}

		public Motions() : base( "motions" )
			{
			Snowglobe.Agent.ResourceAnimationRequest.Update += Update ;

			overrides = new Override[]
				{
				new Override( FrameMotionsWalk,        Agent.Animation.Walk ) ,
				new Override( FrameMotionsRun,         Agent.Animation.Run ) ,
				new Override( FrameMotionsFly,         Agent.Animation.Fly ) ,
				new Override( FrameMotionsSit,         Agent.Animation.Sit ) ,
				new Override( FrameMotionsSitGround,   Agent.Animation.SitGround ) ,
				new Override( FrameMotionsStand,       Agent.Animation.Stand ) ,
				new Override( FrameMotionsStand1,      Agent.Animation.Stand1 ) ,
				new Override( FrameMotionsStand2,      Agent.Animation.Stand2 ) ,
				new Override( FrameMotionsStand3,      Agent.Animation.Stand3 ) ,
				new Override( FrameMotionsStand4,      Agent.Animation.Stand4 ) ,
				} ;

			//Show();
			}
		}
	}