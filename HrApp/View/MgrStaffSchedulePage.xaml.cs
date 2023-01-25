using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HrApp.View
{
    public partial class MgrStaffSchedulePage : ContentPage
    {
        public MgrStaffSchedulePage()
        {
            InitializeComponent();
            SetMonthAndYear();
        }

        void UPTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            MyCalendar.PreviousMonth();
            SetMonthAndYear();
        }

        void DownTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            MyCalendar.NextMonth();
            SetMonthAndYear();
        }

        private async void SetMonthAndYear()
        {

            await System.Threading.Tasks.Task.Delay(500);

            YearMonthLab.Text = MyCalendar.TitleLabelText;
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            fromPicker.Focus();
        }
    }
}
