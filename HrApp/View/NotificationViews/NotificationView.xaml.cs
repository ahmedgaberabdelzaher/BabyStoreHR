﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HrApp.View.NotificationViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationView : ContentView
    {
        public NotificationView()
        {
            InitializeComponent();
        }
    }
}