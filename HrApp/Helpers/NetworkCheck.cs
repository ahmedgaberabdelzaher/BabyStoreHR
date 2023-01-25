using Xamarin.Essentials;

namespace HrApp.Helpers
{
    public static class NetworkCheck
    {
        public static bool IsInternet()
        {
            if (Connectivity.NetworkAccess==NetworkAccess.Internet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}