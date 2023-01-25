using System;
using Android.App;
using Android.OS;
using Huawei.Hms.Push;
using Xamarin.Essentials;

namespace HrApp.Droid
{
    [Service]
    [IntentFilter(new[] { "com.huawei.push.action.MESSAGING_EVENT" })]
    public class HMSPushMessageService : HmsMessageService
    {
        public override void OnNewToken(string token, Bundle bundle)
        {
            // HMSInstanceId.Instance.HMSOnNewToken(token);
            if (!string.IsNullOrWhiteSpace(token))
            {

                Preferences.Set("FCMToken", token);
                Preferences.Set("HCM", true);
            }
        

        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            HMSPushEvent.Instance.HMSOnMessageReceived(message.Data);
        }
    }
}

