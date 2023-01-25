using HrApp.Helpers;
using HrApp.Model.FAQModel;
using HrApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Services.Class
{
   public class FAQServices : IFAQServices
    {
        public async Task<Tuple<ObservableCollection<FAQModel>, bool, string>> GetFAQList()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<FAQModel>>(App.BaseUrl + $"api/CommonServices/GetAllFAQ");

            return response;
        }
    }
}
