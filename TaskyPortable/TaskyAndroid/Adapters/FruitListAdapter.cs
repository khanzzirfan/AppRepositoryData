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
using TaskyPortableLibrary;

namespace TaskyAndroid.Adapters
{
	public class FruitListAdapter : BaseAdapter<Fruits>
	{
		protected Activity context = null;
		protected IList<Fruits> Fruits = new List<Fruits>();

		public FruitListAdapter(Activity context, IList<Fruits> menus)
			: base()
		{
			this.context = context;
			this.Fruits = menus;
		}

		public override Fruits this[int position]
		{
			get { return Fruits[position]; }
		}

		public override int Count
		{
			get { return Fruits.Count; }
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			// Get our object for position
			var item = Fruits[position];

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