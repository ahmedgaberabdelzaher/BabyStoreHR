using HrApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Services.Interface
{
   public interface INotificationServices
    {
        Task<Tuple<ObservableCollection<NotificationModel>, bool, string>> GetNotificationList();
       Task<HttpResponseMessage> HideNotification(int id);


    }
}
