/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Diagnostics ;
using System.Collections ;
using System.Security ;
using Snowglobe ;
using System ;


namespace Icesphere.Panel
	{
	public class Inventory : UI.View
		{
		#pragma warning disable 649
		[Glade.Widget] internal Gtk.ScrolledWindow  ScrolledWindowInventoryAllItems ;
		[Glade.Widget] internal Gtk.Entry           EntryInventorySearch ;
		#pragma warning restore 649
		
		/*
		class TreeView : Gtk.TreeView, Gtk.TreeDragSource
			{
			public bool DragDataGet( Gtk.TreePath tp, Gtk.SelectionData sd ) { return base.DragDataGet( tp, sd ) ;}
			public bool RowDraggable(Gtk.TreePath tp ) { return base.DragDraggable( tp ) ;}
			public bool DragDataDelete(Gtk.TreePath tp ) { return base.DragDragDelete( tp ) ; }
			public TreeView() {}
			}
		 */
		Gtk.TreeView  tv    = new Gtk.TreeView() ;
		Gtk.TreeStore store = new Gtk.TreeStore( typeof(object), typeof(bool) ) ;
	
		public class CellRenderer : Gtk.CellRenderer
		{
			const int    pad        = 2 ;
			Gdk.Pixbuf   pixbuf ;
			string       text ;
			
			public Gdk.Pixbuf Pixbuf
				{
				get { return pixbuf ; }
				set { pixbuf = value ; }
				}

			public string Text
				{
				get { return text ; }
				set { text = value ; }
				}
		
			public override void GetSize( Gtk.Widget widget, ref Gdk.Rectangle cell_area, out int x_offset, out int y_offset, out int width, out int height )
				{
				Pango.Layout layout = new Pango.Layout( widget.PangoContext ) ;
				layout.SetMarkup( text ) ;
				
				Pango.Rectangle ext, nil ;
				layout.GetPixelExtents( out nil, out ext ) ;
				
				int pw = ( null == pixbuf ) ?  0 : pixbuf.Width ;
				int ph = ( null == pixbuf ) ?  0 : pixbuf.Height ;
				int w  = Math.Max( pw, ph ) ;
		
				int calc_width  = (int) this.Xpad * 2 + w + ext.Width + pad ;
				int calc_height = (int) this.Ypad * 2 + w ;
		
				width  = calc_width ;
				height = calc_height ;
		
				x_offset = 0;
				y_offset = 0;
				if (!cell_area.Equals (Gdk.Rectangle.Zero))
					{
					x_offset = (int) (this.Xalign * (cell_area.Width - calc_width));
					x_offset = Math.Max (x_offset, 0);
					
					y_offset = (int) (this.Yalign * (cell_area.Height - calc_height));
					y_offset = Math.Max (y_offset, 0);
					}
				}
		
			protected override void Render (Gdk.Drawable window, Gtk.Widget widget, Gdk.Rectangle background_area, Gdk.Rectangle cell_area, Gdk.Rectangle expose_area, Gtk.CellRendererState flags)
				{
				int x    = (int) ( cell_area.X + this.Xpad ) ;
				int y    = (int) ( cell_area.Y + this.Ypad ) ;
				int pw   = ( null == pixbuf ) ?  0 : pixbuf.Width ;
				int ph   = ( null == pixbuf ) ?  0 : pixbuf.Height ;
				int w    = Math.Max( pw, ph ) ;
				int wpad = ( w - pw ) / 2 ;
				int hpad = ( w - ph ) / 2 ;
				if( null != pixbuf )
					window.DrawPixbuf( widget.Style.BackgroundGC(widget.State), pixbuf, 
						0, 0,    // source
						x+wpad, y+hpad,  // dest
						pixbuf.Width, pixbuf.Height, // w h
						Gdk.RgbDither.None, 0, 0 ) ;
		
				Pango.Layout layout = new Pango.Layout( widget.PangoContext ) ;
				layout.SetMarkup( text ) ;
				window.DrawLayout( widget.Style.TextGC( widget.State ), pad + w + x, y, layout ) ;
				}
			}


		void ProgressData( Gtk.TreeViewColumn tree_column, Gtk.CellRenderer cell, Gtk.TreeModel tree_model, Gtk.TreeIter iter )
			{
			object o = store.GetValue( iter, 0 ) ;
			bool   b = (bool) store.GetValue( iter, 1 ) ;
			
			if( o is Snowglobe.Inventory.Item )
				{
				Snowglobe.Inventory.Item item = o as Snowglobe.Inventory.Item ;
				if( ! b )
					{
					((CellRenderer)cell).Pixbuf  = Icon.Cube ;
					((CellRenderer)cell).Text    = "<span foreground="+'"'+"grey"+'"'+">(...)</span>" ;
					return ;
					}
				((CellRenderer)cell).Text    = SecurityElement.Escape( item.Name ) ;
				((CellRenderer)cell).Pixbuf  = Icon.FromItemType( item ) ;
				}
			else
			if( o is Snowglobe.Inventory.Category )
				{
				Snowglobe.Inventory.Category category = o as Snowglobe.Inventory.Category ;
				((CellRenderer)cell).Pixbuf  = Icon.Folder ;
				((CellRenderer)cell).Text    = b ? SecurityElement.Escape( category.Name ) : "<span foreground="+'"'+"grey"+'"'+">(...)</span>" ;
				return ;
				}
			}

		public void QueriedCategory( Gtk.TreeIter outer, Snowglobe.Inventory.Category category )
			{
			Gtk.Application.Invoke( delegate
				{
				lock( store )
					{
					store.SetValue( outer, 1, true ) ;
					foreach( Snowglobe.Inventory.Category c in category.Categories )
						store.AppendValues( outer, c, false ) ;
					foreach( Snowglobe.Inventory.Item i in category.Items )
						store.AppendValues( outer, i, false ) ;
					}
				});
			}

		public void QueriedItem( Gtk.TreeIter row, Snowglobe.Inventory.Item item )
			{
			Gtk.Application.Invoke( delegate
				{
				lock( store )
					store.SetValue( row, 1, true ) ;
				});
			}

		public void QueriedRoot( Snowglobe.Inventory.Category c )
			{
			Gtk.Application.Invoke( delegate
				{
				lock( store )
					{
					Gtk.TreeIter iter = store.AppendValues( c, false ) ;
					c.Query( (category) => QueriedCategory( iter, category ) ) ;
					}
				});
			}
			
		void queryRow( Gtk.TreeIter row )
			{
			lock( store )
				{
				object o = store.GetValue( row, 0 ) ;
				if( o is Snowglobe.Inventory.Item )
					{
					Snowglobe.Inventory.Item i = o as Snowglobe.Inventory.Item ;
					i.Query( (item) => QueriedItem( row, item ) ) ;
					}
				else
				if( o is Snowglobe.Inventory.Category )
					{
					Snowglobe.Inventory.Category c = o as Snowglobe.Inventory.Category ;
					c.Query( (category) => QueriedCategory( row, category ) ) ;
					}
				}
			}
			
		void expanded( object obj, Gtk.RowExpandedArgs args )
			{
			lock( store )
				{
				Gtk.TreeIter outer = args.Iter ;
				object o = store.GetValue( outer, 0 ) ;
				if( o is Snowglobe.Inventory.Item )
					{
					Snowglobe.Inventory.Item item = o as Snowglobe.Inventory.Item ;
					//Debug.WriteLine("Toggled Item {0} {1}", item.ID, item.Name ) ;
					}
				else
				if( o is Snowglobe.Inventory.Category )
					{
					Snowglobe.Inventory.Category category = o as Snowglobe.Inventory.Category ;
					//Debug.WriteLine("Toggled Category {0} {1}", category.ID, category.Name ) ;
					Gtk.TreeIter iter ;
					for( int i = 0 ; store.IterNthChild( out iter, outer, i ) ; ++i )
						queryRow( iter ) ;
					}
				}
			}
			
		void showPopup()
			{
			Gtk.TreePath[] path = tv.Selection.GetSelectedRows() ;
			Gtk.TreeIter  iter ;
			if( ! store.GetIter(out iter, path[0]) )
				return ;
			if( ! (bool) store.GetValue( iter, 1 ) )
				return ;
			object o = store.GetValue( iter, 0 ) ;
			if( o is Snowglobe.Inventory.Category )
				{
				//ExpandRow( path[0], false )
				return ;
				}
			if( ! ( o is Snowglobe.Inventory.Item ) )
				{
				//Debug.WriteLine("error" ) ;
				}
			Snowglobe.Inventory.Item item = o as Snowglobe.Inventory.Item ;
			Gtk.Menu menu = new Gtk.Menu() ;
			if( item.Type == "notecard" )
				{
				Gtk.MenuItem m = new Gtk.MenuItem("Open") ;
				m.Activated += (oo,e) => new Panel.EditorNotecard( item ) ;
				menu.Append( m ) ;
				}
			else
				{
				Gtk.MenuItem m = new Gtk.MenuItem( item.Type ) ;
				menu.Append( m ) ;
				}
			menu.Popup() ;
			menu.ShowAll() ;
			// new Panel.EditorNotecard( item )
			}
			
		void OnPopupMenu( object o, Gtk.PopupMenuArgs args )
			{
			showPopup() ;
			}
			
		void OnButtonReleased( object o, Gtk.ButtonReleaseEventArgs args )
			{
			if( args.Event.Button == 3 )
				showPopup() ;
			}

		void OnDragDataGet( object s, Gtk.DragDataGetArgs args )
			{
			Gtk.TreeModel m ;
			Gtk.TreeIter  iter ;
			tv.Selection.GetSelected( out m, out iter ) ;

			object  o     = store.GetValue( iter, 0 ) ;
			bool    b     = (bool) store.GetValue( iter, 1 ) ;
			string  text  = "sunsuns";
			UUID    id    = UUID.Zero ;

			switch( args.SelectionData.Target.Name )
				{
				case "STRING":
				case "text/plain":
					args.SelectionData.Set(args.SelectionData.Target, 8, System.Text.Encoding.UTF8.GetBytes(text)) ;
					break ;
				case "InventoryItem":
					if( o is Snowglobe.Inventory.Item )
						{
						Snowglobe.Inventory.Item item = o as Snowglobe.Inventory.Item ;
						text  = item.Name ;
						id    = item.ID ;
						args.SelectionData.Set( args.SelectionData.Target, 8, System.Text.Encoding.UTF8.GetBytes(id.ToString()) ) ;
						}
					break ;
				case "InventoryCategory":
					if( o is Snowglobe.Inventory.Category )
						{
						Snowglobe.Inventory.Category category = o as Snowglobe.Inventory.Category ;
						text  = category.Name ;
						id    = category.ID ;
						args.SelectionData.Set( args.SelectionData.Target, 8, System.Text.Encoding.UTF8.GetBytes(id.ToString()) ) ;
						}
					break ;
				}
			}
		
		public Inventory( ) : base( "inventory" )
			{
			tv.Model = store ;
			tv.AppendColumn( "", new CellRenderer(), new Gtk.TreeCellDataFunc( ProgressData ) ) ;
			tv.HeadersVisible       = false ;
			tv.RowExpanded         += expanded ;
			tv.PopupMenu           += OnPopupMenu ;
			tv.ButtonReleaseEvent  += OnButtonReleased ;
			tv.DragDataGet         += OnDragDataGet ;

			Gtk.TargetEntry[] te = new Gtk.TargetEntry[]
				{
				new Gtk.TargetEntry( "STRING", 0, 0 ) ,
				new Gtk.TargetEntry( "text/plain", 0, 1 ) ,
				new Gtk.TargetEntry( "InventoryItem", 0, 2 ) ,
				new Gtk.TargetEntry( "InventoryCategory", 0, 3 ) ,
				} ;
		
			tv.EnableModelDragSource (Gdk.ModifierType.Button1Mask, te, Gdk.DragAction.Copy) ;

			ScrolledWindowInventoryAllItems.Add( tv ) ;
			Snowglobe.Inventory.QueryRoot( QueriedRoot ) ;
			//Show() ;
			}
		}
	}