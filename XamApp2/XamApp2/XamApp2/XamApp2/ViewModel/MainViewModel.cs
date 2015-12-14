﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamApp2.ViewModel
{
    public class MainViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private string _message;

        public MainViewModel()
        {
            Message = "Hello Xamarin Forms Labs MVVM Basics!!";
        }

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

    }
}
