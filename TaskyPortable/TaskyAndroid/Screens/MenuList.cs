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
using Tasky.BL;
using Tasky.DAL;
using Menu = TaskyPortableLibrary.Menu;

namespace TaskyAndroid.Screens
{
	[Activity(Label = "MenuList")]
	public class MenuList : Activity
	{
		protected Adapters.MenuListAdapter taskList;
		protected IList<Menu> menus;
		protected Button addMenuButton = null;
		protected ListView menuListView = null;
		
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// set our layout to be the home screen
			SetContentView(Resource.Layout.Menu);

			//Find our controls
			menuListView = FindViewById<ListView>(Resource.Id.lstMenu);
			addMenuButton = FindViewById<Button>(Resource.Id.btnAddMenu);

			// wire up add task button handler
			if (addMenuButton != null)
			{
				addMenuButton.Click += (sender, e) =>
				{
					StartActivity(typeof(MenuDetailScreen));
				};
			}

			// wire up task click handler
			if (menuListView != null)
			{
				menuListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
				{
					var taskDetails = new Intent(this, typeof(MenuDetailScreen));
					taskDetails.PutExtra("MenuID", menus[e.Position].ID);
					StartActivity(taskDetails);
				};
			}
		
		}

		protected override void OnResume()
		{
			base.OnResume();
			menus = TaskyApp.Current.MenuRepository.GetAll();
			// create our adapter
			taskList = new Adapters.MenuListAdapter(this, menus);
			//Hook up our adapter to our ListView
			menuListView.Adapter = taskList;
		}

	}
}