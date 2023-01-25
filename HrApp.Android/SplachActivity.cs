
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HrApp.Droid
{
    [Activity(NoHistory = true, Exported = true, Theme = "@style/SplashTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait,
    LaunchMode = LaunchMode.SingleTop)]

    public class SplashScreen : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            try
            {
                await Task.Delay(4000);
                if (Intent.Extras != null)
                {
                    var id = Intent.Extras.Get("Id");
                    if (id != null)
                    {
                        Intent i = new Intent(this, typeof(MainActivity));
                        i.PutExtra("ID", id.ToString());
                    
                        StartActivity(i);
                    }
                    else
                    {
                        InvokeMainActivity();
                      
                    }
             
                }
                else
                {
                    InvokeMainActivity();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

        
        }
        private void InvokeMainActivity()
        {
            var mainActivityIntent = new Intent(this, typeof(MainActivity));
            mainActivityIntent.AddFlags(ActivityFlags.NoAnimation); 
            StartActivity(mainActivityIntent);
        }
    }
}
