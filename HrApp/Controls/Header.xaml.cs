using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HrApp.Controls
{
    public partial class Header : ContentView
    {
        public Header()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TitelTxtProperty = BindableProperty.Create(
                                                      propertyName: "TitelTxt",
                                                      returnType: typeof(string),
                                                      declaringType: typeof(Header),
                                                      defaultValue: "",
                                                      defaultBindingMode: BindingMode.TwoWay,
                                                      propertyChanged: TitleTextPropertyChanged);

        public string TitelTxt
        {
            get { return base.GetValue(TitelTxtProperty).ToString(); }
            set { base.SetValue(TitelTxtProperty, value); }
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var control = (Header)bindable;
                control.TitleTxt.Text = newValue.ToString();
            }

        }
    }
}
