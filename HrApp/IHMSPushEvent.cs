using System;
namespace HrApp
{
    public interface IHMSPushEvent
    {

        event OnMessageReceivedHandler OnMessageReceived;
        void Initialize();
    }
    public delegate void OnMessageReceivedHandler(string data);
}

