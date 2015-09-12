using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Menu = TaskyPortableLibrary.Menu;

namespace TaskyAndroid.Adapters
{
	public class MenuListAdapter : BaseAdapter<Menu>
	{
		protected Activity context = null;
		protected IList<Menu> Menus = new List<Menu>();


		public MenuListAdapter(Activity context, IList<Menu> menus)
			: base()
		{
			this.context = context;
			this.Menus = menus;
		}

		public override Menu this[int position]
		{
			get { return Menus[position]; }
		}

		public override long GetItemId(int position)
		{
			return position;
		}


		public override int Count
		{
			get { return Menus.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			// Get our object for position
			var item = Menus[position];

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			// will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
			var view = (convertView ??
					context.LayoutInflater.Inflate(
					Android.Resource.Layout.SimpleListItemChecked,
					parent,
					false)) as CheckedTextView;

			view.SetText(item.Name == "" ? "<new task>" : item.Name, TextView.BufferType.Normal);
			view.Checked = item.Active;

			//Finally return the view
			return view;
		}
	}
}