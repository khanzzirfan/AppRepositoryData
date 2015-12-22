﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using EmployeeV2.ViewModel;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace EmployeeV2.Droid
{
    [Activity(Label = "EmployeeV2", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //LoadApplication(new App());

            if (!Resolver.IsSet) SetIoc();

            LoadApplication(new App());
        }

        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            resolverContainer.Register<IDevice>(r => AndroidDevice.CurrentDevice);
            resolverContainer.Register<MainViewModel>(r => new MainViewModel(r.Resolve<IDevice>()));
            
            Resolver.SetResolver(resolverContainer.GetResolver());
        }

    }
}

