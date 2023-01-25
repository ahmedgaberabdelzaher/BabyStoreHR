using HrApp.Helpers;
using HrApp.Model.NewsModel;
using HrApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Services.Class
{
    public class NewsServices : INewsServices
    {
        public async Task<Tuple<ObservableCollection<NewsModel>, bool, string>> GetNewsById(int ID)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<NewsModel>>(App.BaseUrl + $"api/CommonServices/GetpageDetails/{ID}");

            return response;
        }

        public async Task<Tuple<ObservableCollection<NewsModel>, bool, string>> GetNewsList()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<NewsModel>>(App.BaseUrl + $"api/CommonServices/GetNewsList");

            return response;
        }
    }
}
