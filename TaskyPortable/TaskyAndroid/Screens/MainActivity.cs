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

namespace TaskyAndroid.Screens
{
	[Activity(Label = "MainActivity", MainLauncher = true, Icon = "@drawable/ic_launcher", Theme = "@style/AppTheme")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.MainActivity);
			var btnTask = FindViewById<Button>(Resource.Id.btnOpenTask);
			var btnMenu = FindViewById<Button>(Resource.Id.btnOpenMenu);
			var btnFruit = FindViewById<Button>(Resource.Id.btnOpenFruits);

			if (btnTask != null)
			{
				btnTask.Click += (sender, e) =>
				{
					StartActivity(typeof(HomeScreen));
				};
			}

			btnMenu.Click+=(sender, e) =>
			{
				StartActivity(typeof(MenuList));
			};

			btnFruit.Click += (sender, e) =>
			{
				StartActivity(typeof(FruitList	));
			};

		}
	}
}