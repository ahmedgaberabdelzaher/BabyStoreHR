using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HrApp.Controls
{	
	public partial class EntryWithLabel : ContentView
	{	
		public EntryWithLabel ()
		{
			InitializeComponent ();
            EntryValueTxt.SetBinding(Entry.TextProperty, new Binding(nameof(ValueTxt), source: this));

        }

        public static readonly BindableProperty TitleTxtProperty = BindableProperty.Create(
                                                      propertyName: "TitleTxt",
                                                      returnType: typeof(string),
                                                      declaringType: typeof(EntryWithLabel),
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
                var control = (EntryWithLabel)bindable;
                control.TitleLabelTxt.Text = newValue.ToString();
            }

        }


        public static readonly BindableProperty ValueTxtProperty = BindableProperty.Create(
                                              propertyName: "ValueTxt",
                                              returnType: typeof(string),
                                              declaringType: typeof(EntryWithLabel),
                                              defaultValue: "",
                                              defaultBindingMode: BindingMode.TwoWay,
                                              propertyChanged: ValueTxtPropertyChanged);

        public string ValueTxt

        {
            get { return base.GetValue(ValueTxtProperty).ToString(); }
            set { base.SetValue(ValueTxtProperty, value); OnPropertyChanged("ValueTxt"); }
        }

        private static void ValueTxtPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var control = (EntryWithLabel)bindable;
                control.EntryValueTxt.Text = newValue.ToString();
            }

        }



        public string EntryPlaceHolderTxt
        {
            get => EntryValueTxt.Placeholder;
            set => EntryValueTxt.Placeholder = value;
        }

        public Keyboard EntryTxtKeybOardType
        {
            get => EntryValueTxt.Keyboard;
            set => EntryValueTxt.Keyboard = value;
        }


    }
}

