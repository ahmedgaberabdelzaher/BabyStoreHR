using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.AppCompat.App;
using ImageCircle.Forms.Plugin.Droid;
using Android.Content;
using Plugin.FirebasePushNotification;
using Android.Support.V4.App;
using Huawei.Agconnect.Config;
using Android.Util;
using Huawei.Hms.Aaid;
using Xamarin.Essentials;
using Android.Widget;
using Android.Nfc;
using Android.Text;
using SVG.Forms.Plugin.Droid;

namespace HrApp.Droid
{
    [Activity(Label = "HrApp",Exported =true, Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SvgImageRenderer.Init();
            AiForms.Effects.Droid.Effects.Init();
            ImageCircleRenderer.Init();

            XamForms.Controls.Droid.Calendar.Init();
            SvgImageRenderer.Init();
            LoadApplication(new App());
            FirebasePushNotificationManager.ProcessIntent(this, Intent);

            CreateNotificationChannel();

            CrossFirebasePushNotification.Current.OnNotificationReceived += async (s, p) =>
            {
                try
                {
                    var builder = new NotificationCompat.Builder(this, "");

                    var newIntent = new Intent(this, typeof(MainActivity));
                    newIntent.AddFlags(ActivityFlags.ClearTop);
                    newIntent.AddFlags(ActivityFlags.SingleTop);
                    var body = p?.Data["title"]?.ToString();
                    var title = p?.Data["body"]?.ToString();
                    var pendingIntent = PendingIntent.GetActivity(this, 0, newIntent, PendingIntentFlags.Mutable);
                    var notification = builder.SetContentIntent(pendingIntent)
                        .SetSmallIcon(Resource.Drawable.HomeIcon)
                        .SetAutoCancel(false)
                        .SetTicker("")
                        .SetChannelId("DefaultChannel")
                        .SetContentTitle(p?.Data["title"]?.ToString())
                        .SetContentText(p?.Data["body"]?.ToString())
                        .SetNumber(10)
                        .Build();
                    var notId = new Random().Next();
                    var notificationManager = NotificationManagerCompat.From(this);
                    notificationManager.Notify(notId, builder.Build());
                }
                catch (Exception ex)
                {

                }

            };
            var manufacturer = Xamarin.Essentials.DeviceInfo.Manufacturer;
            if (manufacturer == "HUAWEI")
            {
           GetToken();
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification 
                // channel on older versions of Android.
                return;
            }

            var name = "DefaultChannel";
            var description = "DefaultChannel";
            var channel = new NotificationChannel("DefaultChannel", name, NotificationImportance.Default)
            {
                Description = description
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
        protected override void AttachBaseContext(Context context)
        {
            base.AttachBaseContext(context);
            AGConnectServicesConfig config = AGConnectServicesConfig.FromContext(context);
            config.OverlayWith(new HmsLazyInputStream(context));
        }

       
        private void GetToken()
        {
            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                try
                {

                    string appid = AGConnectServicesConfig.FromContext(this).GetString("client/app_id");
                    var client = HmsInstanceId.GetInstance(this);
                    string token = HmsInstanceId.GetInstance(this).GetToken(appid, "HCM");
                    if (!string.IsNullOrWhiteSpace(token))
                    {

                    Preferences.Set("FCMToken", token);
                        Preferences.Set("HCM", true);
                    }
                }
                catch (Exception e)
                {
                    Preferences.Set("HCM", false);
                    // Log.Info("token", e.ToString());
                    // throw (e);
                }
            }
                );
            thread.Start();
        }
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            FirebasePushNotificationManager.ProcessIntent(this, intent);
        }
    }
}
