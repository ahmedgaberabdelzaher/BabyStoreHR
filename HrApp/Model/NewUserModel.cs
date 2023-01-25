using System;
using Xamarin.Essentials;

namespace HrApp.Model
{
    public class NewUserModel
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int? Reset { get; set; }
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
        public string FirebaseDeviceToken { get; set; }
        public string DeviceType { get; set; }
        public int  AppVersion { get; set; }
    }
}
