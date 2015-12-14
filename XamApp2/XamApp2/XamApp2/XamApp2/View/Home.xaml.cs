using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamApp2.ViewModel;
using Xamarin.Forms;

namespace XamApp2.View
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            //Xamarin.Insights.Track("Home");
            BindingContext = new HomeViewModel(this);

            ButtonFindStore.Clicked += async (sender, e) =>
            {
                //if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
                //  await Navigation.PushAsync(new StoresTabletPage());
                //else
               // await Navigation.PushAsync(new Search());
            };

            ButtonLeaveFeedback.Clicked += async (sender, e) =>
            {
               // await Navigation.PushAsync(new Search());
            };

        }
        public void HomePageLoad()
        {
            BindingContext = new HomeViewModel(this);
        }

        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var searchOption = args.Item as Home;
            if (searchOption == null)
                return;

          // Navigation.PushAsync(new Search());
            //// Reset the selected item
            //  list.SelectedItem = null;
        }


    }
}
