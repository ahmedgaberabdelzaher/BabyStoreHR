﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HrApp.View
{
    public partial class StaffSchedulePage : ContentPage
    {
        public StaffSchedulePage()
        {
            InitializeComponent();
            SetMonthAndYear();
            YearMonthLab.Text = DateTime.UtcNow.ToString("MMM yyyy");
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

        private async  void SetMonthAndYear()
        {

            await System.Threading.Tasks.Task.Delay(200);
            
            YearMonthLab.Text = MyCalendar.TitleLabelText;
        }
    }
}
