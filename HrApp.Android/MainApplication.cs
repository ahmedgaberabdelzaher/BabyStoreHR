using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.FirebasePushNotification;
using Xamarin.Essentials;

namespace HrApp.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                /*
                 * For a single Notification channel
                 */
                //Change for your default notification channel id here
                FirebasePushNotificationManager.DefaultNotificationChannelId = "DefaultChannel";

                //Change for your default notification channel name here
                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
                FirebasePushNotificationManager.DefaultNotificationChannelImportance = NotificationImportance.Max;
                /*
                 * Or to work with multiple notification channels
                 * e.g. to enable multiple importance level messages or different notification sounds...etc
                 * Note: Once NotificationChannels contains at least one element, DefaultNotificationChannelId, DefaultNotificationChannelName, 
                 * and DefaultNotificationChannelImportanceLevel are ignored.
                 */
                /*PushNotificationManager.NotificationChannels = new List<NotificationChannelProps>()
                {
                    new NotificationChannelProps("infoMessagesId", "Informations"),
                    new NotificationChannelProps("warningMessagesId", "Warnings", NotificationImportance.High),
                    new NotificationChannelProps("reminderMessagesId", "Reminders", NotificationImportance.Min)
                };*/

                CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
                {
                    Preferences.Set("FCMToken", p.Token);
                    System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
                };

            }


            //If debug you should reset the token each time.
#if DEBUG
            FirebasePushNotificationManager.Initialize(this,true);
#else
            FirebasePushNotificationManager.Initialize(this, false);
#endif

            //Handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {


            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
               

            };
        }
    }
}

