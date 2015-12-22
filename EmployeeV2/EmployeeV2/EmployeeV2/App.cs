using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeV2.View;
using EmployeeV2.ViewModel;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace EmployeeV2
{
    public class App : Application
    {
        public App()
        {
            RegisterViews();
            MainPage = new NavigationPage((Page)ViewFactory.CreatePage<MainViewModel, MainView>());
        }

        private void RegisterViews()
        {
            ViewFactory.Register<MainView, MainViewModel>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
