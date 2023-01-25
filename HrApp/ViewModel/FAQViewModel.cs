using HrApp.Model.FAQModel;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HrApp.ViewModel
{
    public class FAQViewModel : ViewModelBase
    {
        private IFAQServices _faqservices;


        ObservableCollection<FAQModel> _faqlist = new ObservableCollection<FAQModel>();
        public ObservableCollection<FAQModel> FAQlist { get { return _faqlist; } set { _faqlist = value; RaisePropertyChanged(); } }

        public FAQViewModel(IFAQServices fAQServices, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _faqservices= fAQServices;
        }

        public override void Initialize(INavigationParameters parameters)
        {

            base.Initialize(parameters);
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                IsLoading=true;
                var Result = await _faqservices.GetFAQList();
                if (Result.Item2)
                    FAQlist=Result.Item1;
                base.OnNavigatedTo(parameters);
            }
            catch
            {
            }
            finally
            {
                IsLoading=false;
            }
        }
    }
}