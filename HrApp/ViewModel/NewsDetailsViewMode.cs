using HrApp.Model.NewsModel;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.ViewModel
{
  public  class NewsDetailsViewMode :ViewModelBase
    {
        NewsModel _SelectedNews;
        public NewsModel SelectedNews { get { return _SelectedNews; } set { _SelectedNews = value; RaisePropertyChanged(); } }
        string _title = "";
        public string Title { get { return _title; } set { _title = value; RaisePropertyChanged(); } }

        string _Content = "";
        public string Content { get { return _Content; } set { _Content = value; RaisePropertyChanged(); } }

        DateTime _pageDate ;
        public DateTime pageDate { get { return _pageDate; } set { _pageDate = value; RaisePropertyChanged(); } }
        public NewsDetailsViewMode(INavigationService navigationServices, IPageDialogService pageDialogService) : base(navigationServices, pageDialogService)
        {

        }
        public override void Initialize(INavigationParameters parameters)
        {
            if (parameters!=null&&parameters.Count>0)
            {


                SelectedNews = parameters["details"] as NewsModel;

         Content =SelectedNews.contentArabic;
             pageDate = SelectedNews.pageDate;
                Title= SelectedNews.titleArabic;


            }
            base.Initialize(parameters);    
        }
      


    }
}
