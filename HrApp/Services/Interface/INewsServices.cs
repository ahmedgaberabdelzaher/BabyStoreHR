using HrApp.Model.NewsModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Services.Interface
{
  public  interface INewsServices
    {
        Task<Tuple<ObservableCollection<NewsModel>, bool, string>> GetNewsList();

        Task<Tuple<ObservableCollection<NewsModel>, bool, string>> GetNewsById(int ID);
    }
}
