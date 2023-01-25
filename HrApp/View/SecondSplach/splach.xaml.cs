using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HrApp.View.SecondSplach
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class splach : ContentView
    {
        public splach()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}