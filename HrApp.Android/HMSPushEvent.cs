using System;

[assembly: Xamarin.Forms.Dependency(typeof(HrApp.Droid.HMSPushEvent))]
namespace HrApp.Droid
{
    public class HMSPushEvent : IHMSPushEvent
    {
        internal static HMSPushEvent Instance;

        public event OnMessageReceivedHandler OnMessageReceived;

        public void HMSOnMessageReceived(string data)
        {
            OnMessageReceived?.Invoke(data);
        }

        public void Initialize()
        {
            Instance = this;
        }
    }
}

