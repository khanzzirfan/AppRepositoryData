using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Tasky.BL;
using Tasky.DAL;
using Menu = TaskyPortableLibrary.Menu;

namespace TaskyAndroid.Screens
{
	[Activity(Label = "Menu Details", Icon = "@drawable/ic_launcher", Theme = "@style/AppTheme")]			
	public class MenuDetailScreen: Activity 
	{
		//protected Task task = new Task();
		protected Menu menu = new Menu();
		protected Button cancelDeleteButton;
		protected EditText notesTextEdit;
		protected EditText nameTextEdit;
		protected Button saveButton;
		protected Button speakButton;
		CheckBox doneCheckbox;
		

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			View titleView = Window.FindViewById(Android.Resource.Id.Title);
			if (titleView != null)
			{
				IViewParent parent = titleView.Parent;
				if (parent != null && (parent is View))
				{
					View parentView = (View)parent;
					parentView.SetBackgroundColor(Color.Rgb(0x26, 0x75, 0xFF)); //38, 117 ,255
				}
			}

			SetContentView(Resource.Layout.MenuDetails);

			int menuID = Intent.GetIntExtra("MenuID", 0);
			if (menuID > 0)
			{
				menu = TaskyApp.Current.MenuRepository.GetById(menuID);
			}

			nameTextEdit = FindViewById<EditText>(Resource.Id.txtName);
			notesTextEdit = FindViewById<EditText>(Resource.Id.txtNotes);
			saveButton = FindViewById<Button>(Resource.Id.btnSave);
			doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone);
			cancelDeleteButton = FindViewById<Button>(Resource.Id.btnCancelDelete);
			speakButton = FindViewById<Button>(Resource.Id.btnSpeak);


			// set the cancel delete based on whether or not it's an existing task
			cancelDeleteButton.Text = (menu.ID == 0 ? "Cancel" : "Delete");
			// name
			nameTextEdit.Text = menu.Name;
			// notes
			notesTextEdit.Text = menu.Price.ToString();
			// done
			doneCheckbox.Checked = menu.Active;

			// button clicks 
			cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
			saveButton.Click += (sender, e) => { Save(); };
			
		}

		protected void Save()
		{
			double priceValue = 0;
			menu.Name = nameTextEdit.Text;
			if (Double.TryParse(notesTextEdit.Text, out priceValue))
			{
				menu.Price = priceValue;
			}
			else
			{
				menu.Price = priceValue;
			}

			menu.Active = doneCheckbox.Checked;
			menu.FruitID = 25;
			TaskyApp.Current.MenuRepository.Insert(menu);
			Finish();
		}
		
		protected void CancelDelete()
		{
			if(menu.ID != 0) {
				TaskyApp.Current.MenuRepository.Delete(menu);
			}
			Finish();
		}
	
	}
}