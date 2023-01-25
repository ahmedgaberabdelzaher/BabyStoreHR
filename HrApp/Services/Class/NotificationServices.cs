using HrApp.Helpers;
using HrApp.Model;
using HrApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HrApp.Services.Class
{
    public class NotificationServices : INotificationServices
    {
        public async Task<Tuple<ObservableCollection<NotificationModel>, bool, string>> GetNotificationList()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<NotificationModel>>(App.BaseUrl + $"api/CommonServices/GetEmployeePendingNotifications/{Preferences.Get("userId", 0)}");
            return response;
        }

        public async  Task<HttpResponseMessage> HideNotification(int id)
        {
              var response = await HttpManager.PostAsync(App.BaseUrl + $"api/CommonServices/UpdateEmployeeNotificationStatus/{id}",new{ });

            return response;

        }
    }
}
