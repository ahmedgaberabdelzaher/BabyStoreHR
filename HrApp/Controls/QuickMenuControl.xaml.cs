using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace HrApp.Controls
{
    public partial class QuickMenuControl : ContentView
    {
        private bool _isOpend;
        readonly int x_dir;
        double _scale;
        uint _flyoutSpeed = 200;
        double _pagePositionX;
        double _flyoutTranslationX;

        public QuickMenuControl()
        {
            InitializeComponent();

            x_dir = 1;// ViewModel.Lang == (int)Common.Enums.Languages.Arabic ? -1 : 1;

            _isOpend = true;

            _flyoutTranslationX = 100;

            TapGestureRecognizer_Tapped(this, null);
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            _isOpend = !_isOpend;

            arrowImage.Source = _isOpend ? "hide_nav_icon.png" : "show_nav_icon.png";

            AnimateImage(_isOpend);
        }

        private void AnimateImage(bool openning)
        {
            if (openning)
            {
                homeImge.TranslateTo(_pagePositionX * x_dir, 0, _flyoutSpeed);
                FaqImage.TranslateTo(_pagePositionX * x_dir, 0, _flyoutSpeed);
            }
            else
            {
                var sumX = (homeImge.TranslationX + _flyoutTranslationX) * x_dir;
                var sumY = (homeImge.TranslationY + homeImge.Height);
                homeImge.TranslateTo(sumX, sumY, _flyoutSpeed);
                FaqImage.TranslateTo(sumX, 0, _flyoutSpeed);
            }
        }


        public static readonly BindableProperty FaqCommandProperty =
         BindableProperty.Create(nameof(FaqCommand), typeof(ICommand), typeof(QuickMenuControl), null);

        public ICommand FaqCommand
        {
            get { return (ICommand)GetValue(FaqCommandProperty); }
            set { SetValue(FaqCommandProperty, value); }
        }

        public Command ShowFaqCommand => new Command(() => Execute(FaqCommand));


        public static readonly BindableProperty HomeCommandProperty =
         BindableProperty.Create(nameof(HomeCommand), typeof(ICommand), typeof(QuickMenuControl), null);

        public ICommand HomeCommand
        {
            get { return (ICommand)GetValue(HomeCommandProperty); }
            set { SetValue(HomeCommandProperty, value); }
        }

        public Command ShowHomeCommand => new Command(() => Execute(HomeCommand));


        public static void Execute(ICommand command)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(null);
            }
        }

    }
}
