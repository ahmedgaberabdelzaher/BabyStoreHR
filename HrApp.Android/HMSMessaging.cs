using System;
using System.Threading.Tasks;
using Android.App;
using Huawei.Hms.Push;
[assembly: Xamarin.Forms.Dependency(typeof(HrApp.Droid.HMSMessaging))]
namespace HrApp.Droid
{
    public class HMSMessaging : IHMSMessaging
    {
        public bool AutoInitEnabled
        {
            get => HmsMessaging.GetInstance(Application.Context).AutoInitEnabled;
            set => HmsMessaging.GetInstance(Application.Context).AutoInitEnabled = value;
        }

        public Task SubscribeAsync(string topic)
        {
            return HmsMessaging.GetInstance(Application.Context).SubscribeAsync(topic);
        }

        public Task TurnOffPushAsync()
        {
            return HmsMessaging.GetInstance(Application.Context).TurnOffPushAsync();
        }

        public Task TurnOnPushAsync()
        {
            return HmsMessaging.GetInstance(Application.Context).TurnOnPushAsync();
        }

        public Task UnsubscribeAsync(string topic)
        {
            return HmsMessaging.GetInstance(Application.Context).UnsubscribeAsync(topic);
        }

    }
}

