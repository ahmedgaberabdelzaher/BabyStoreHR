using HrApp.Model.NewsModel;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HrApp.ViewModel
{
   public class NewsViewModel :ViewModelBase
    {
        INewsServices _newsServices;

        ObservableCollection<NewsModel> News = new ObservableCollection<NewsModel>();
        public ObservableCollection<NewsModel> NewsList { get { return News; } set { News = value; RaisePropertyChanged(); } }
      //  NewsModel _SelectedNews;
       // public NewsModel SelectedNews { get { return _SelectedNews; } set { _SelectedNews = value; RaisePropertyChanged(); } }

        public Command<NewsModel> ArticleTabbed { get; set; }
       
       
        public NewsViewModel(INewsServices newsServices, INavigationService navigationServices, IPageDialogService pageDialogService) : base(navigationServices, pageDialogService)
        {
            _newsServices=newsServices;
            ArticleTabbed=new Command<NewsModel>(Tapped);
        }

        private async void Tapped(NewsModel obj)
        {
            var parameters = new NavigationParameters();

            parameters.Add("details", obj);
            if (obj.Type == 2)
            {
                if (!string.IsNullOrEmpty(obj.CircularFileURL))
                { await openpdfAsync(obj.CircularFileURL); }
            }
            else if (obj.Type == 1)

            {
                await NavigationService.NavigateAsync("NewsDetails", parameters, useModalNavigation: true, true);
            }
         //   SelectedNews = null;
        }

        public override void Initialize(INavigationParameters parameters)
        {

            base.Initialize(parameters);    
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetNews();           

            base.OnNavigatedTo(parameters);
        }

        private async Task GetNews()
        {
            try {
                IsLoading = true;
                var resp = await _newsServices.GetNewsList();
                if (resp.Item2)
                {
                    NewsList = resp.Item1;
                }
            }
            catch { 

            } finally {
                IsLoading = false;

            }
        }

        


    }
}
