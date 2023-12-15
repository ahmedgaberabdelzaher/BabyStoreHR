using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HrApp.Controls
{	
	public partial class DDlControl : ContentView
	{	
		public DDlControl ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty TitleTxtProperty = BindableProperty.Create(
                                                      propertyName: "TitleTxt",
                                                      returnType: typeof(string),
                                                      declaringType: typeof(DDlControl),
                                                      defaultValue: "",
                                                      defaultBindingMode: BindingMode.TwoWay,
                                                      propertyChanged: TitleTextPropertyChanged);

        public string TitleTxtlTxt
        {
            get { return base.GetValue(TitleTxtProperty).ToString(); }
            set { base.SetValue(TitleTxtProperty, value); }
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var control = (DDlControl)bindable;
                control.TitleLabelTxt.Text = newValue.ToString();
            }

        }


        public static readonly BindableProperty SelectedValueTxtProperty = BindableProperty.Create(
                                              propertyName: "SelectedValueTxt",
                                              returnType: typeof(string),
                                              declaringType: typeof(DDlControl),
                                              defaultValue: "",
                                              defaultBindingMode: BindingMode.TwoWay,
                                              propertyChanged: VSelectedValueTxtChanged);

        public string SelectedValueTxt
        {
            get { return base.GetValue(SelectedValueTxtProperty).ToString(); }
            set { base.SetValue(TitleTxtProperty, value); }
        }

        private static void VSelectedValueTxtChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var control = (DDlControl)bindable;
                control.TextValue.Text = newValue.ToString();
            }

        }


    }
}

