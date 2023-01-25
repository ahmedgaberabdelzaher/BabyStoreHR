using System;

using Xamarin.Forms;

namespace HrApp.ViewModel
{
    public class EncashmentLst : ContentPage
    {
        public EncashmentLst()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

