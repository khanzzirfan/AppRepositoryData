using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamApp2.View;
using XamApp2.ViewModel;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace XamApp2
{
    public class App : Application
    {
        public App()
        {
            RegisterViews();
            
            //MainPage = new NavigationPage((Page)ViewFactory.CreatePage<MainViewModel, MainView>());

            MainPage = new NavigationPage((Page)ViewFactory.CreatePage<HomeViewModel, Home>());

            //var homePage = new NavigationPage(new Home())
            //{
            //    BarTextColor = Color.White,
            //};

            //var page = ViewFactory.CreatePage<HomeViewModel, Home>((vm, v) => vm.InitializeModel(homePage)) as Page;
            //MainPage = new NavigationPage(page);
            
        }
        
        private void RegisterViews()
        {
            ViewFactory.Register<MainView, MainViewModel>();
            ViewFactory.Register<Home, HomeViewModel>();
        }

    }
}
