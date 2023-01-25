using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Huawei.Hms.Aaid;
using Huawei.Hms.Aaid.Entity;
using Huawei.Hms.Push;

namespace HrApp.Droid
{
    public class HMSInstanceId : IHMSInstanceId
    {
        internal static HMSInstanceId Instance { get; private set; }

        private HmsInstanceId Client { get; set; }

        public event OnNewTokenHandler OnNewToken;

        public event OnTokenErrorHandler OnTokenError;

        public void Initialize()
        {
            Instance = this;
            Client = HmsInstanceId.GetInstance(Application.Context);
        }

        public void GetToken()
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    string token = Client.GetToken("<YourAppId>", HmsMessaging.DefaultTokenScope);
                    OnNewToken?.Invoke(token);
                }
                catch (Exception e)
                {
                    OnTokenError?.Invoke(e);
                }
            });
            thread.Start();
        }

        public async Task<string> GetAAIDAsync()
        {
            AAIDResult Result = await Client.GetAAIDAsync();
            return Result.Id;
        }

        public void DeleteAAID()
        {
            Thread thread = new Thread(() =>
            {
                Client.DeleteAAID();
            });
            thread.Start();
        }

        public void DeleteToken()
        {
            Thread thread = new Thread(() =>
            {
                Client.DeleteToken("<YourAppId>", HmsMessaging.DefaultTokenScope);
            });
            thread.Start();
        }

        public void HMSOnNewToken(string token)
        {
            OnNewToken?.Invoke(token);
        }
        public void HMSOnTokenError(string errorMessage)
        {
            OnTokenError?.Invoke(new Exception(errorMessage));
        }
    }
}
