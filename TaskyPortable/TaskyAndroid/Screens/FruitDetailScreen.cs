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
using TaskyPortableLibrary;

namespace TaskyAndroid.Screens
{
	[Activity(Label = "FruitDetailScreen", Icon = "@drawable/ic_launcher", Theme = "@style/AppTheme")]
	public class FruitDetailScreen : Activity
	{
		//protected Task task = new Task();
		protected Fruits Fruits = new Fruits();
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

			int menuID = Intent.GetIntExtra("FruitID", 0);
			if (menuID > 0)
			{
				Fruits = TaskyApp.Current.FruitRepository.GetById(menuID);
			}

			nameTextEdit = FindViewById<EditText>(Resource.Id.txtName);
			notesTextEdit = FindViewById<EditText>(Resource.Id.txtNotes);
			saveButton = FindViewById<Button>(Resource.Id.btnSave);
			doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone);
			cancelDeleteButton = FindViewById<Button>(Resource.Id.btnCancelDelete);
			speakButton = FindViewById<Button>(Resource.Id.btnSpeak);

			// set the cancel delete based on whether or not it's an existing task
			cancelDeleteButton.Text = (Fruits.ID == 0 ? "Cancel" : "Delete");
			// name
			nameTextEdit.Text = Fruits.Name;
			// notes
			notesTextEdit.Text = Fruits.Country;
			// done
			doneCheckbox.Checked = Fruits.Active;
			// button clicks 
			cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
			saveButton.Click += (sender, e) => { Save(); };
			
		}
	
		protected void Save()
		{
			double priceValue = 0;
			Fruits.Name = nameTextEdit.Text;
			Fruits.Country = notesTextEdit.Text;
			Fruits.Active = doneCheckbox.Checked;
			TaskyApp.Current.FruitRepository.Insert(Fruits);
			Finish();
		}

		protected void CancelDelete()
		{
			if (Fruits.ID != 0)
			{
				TaskyApp.Current.FruitRepository.Delete(Fruits);
			}
			Finish();
		}

	}
}