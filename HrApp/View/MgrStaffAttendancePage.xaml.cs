using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HrApp.View
{
    public partial class MgrStaffAttendancePage : ContentPage
    {
        public MgrStaffAttendancePage()
        {
            InitializeComponent();
        }
        void TapGestureRecognizer_FromTapped(System.Object sender, System.EventArgs e)
        {
            fromPicker.Focus();
        }
        void TapGestureRecognizer_ToTapped(System.Object sender, System.EventArgs e)
        {
            toPicker.Focus();
        }
        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            staffPicker.Focus();
        }
    }
}
