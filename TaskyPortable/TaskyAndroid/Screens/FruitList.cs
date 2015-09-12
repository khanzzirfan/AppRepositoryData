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

namespace TaskyAndroid.Screens
{
	[Activity(Label = "FruitList")]
	public class FruitList : Activity
	{
		protected Adapters.FruitListAdapter taskList;
		protected IList<Fruits> fruits;
		protected Button addfruitButton = null;
		protected ListView fruitListView = null;
		

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// set our layout to be the home screen
			SetContentView(Resource.Layout.Menu);

			//Find our controls
			fruitListView = FindViewById<ListView>(Resource.Id.lstMenu);
			addfruitButton = FindViewById<Button>(Resource.Id.btnAddMenu);

			// wire up add task button handler
			if (addfruitButton != null)
			{
				addfruitButton.Click += (sender, e) =>
				{
					StartActivity(typeof(FruitDetailScreen));
				};
			}

			// wire up task click handler
			if (fruitListView != null)
			{
				fruitListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
				{
					var taskDetails = new Intent(this, typeof(FruitDetailScreen));
					taskDetails.PutExtra("FruitID", fruits[e.Position].ID);
					StartActivity(taskDetails);
				};
			}
		}

		protected override void OnResume()
		{
			base.OnResume();
			fruits = TaskyApp.Current.FruitRepository.GetAll();
			// create our adapter
			taskList = new Adapters.FruitListAdapter(this, fruits);
			//Hook up our adapter to our ListView
			fruitListView.Adapter = taskList;
		}
	
	}
}