using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HrApp.Model;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace HrApp.ViewModel
{
    public class CertificatesViewModel:ViewModelBase
    {

        ObservableCollection<CertificateLstModel> _CertificateLst = new ObservableCollection<CertificateLstModel>();
        public ObservableCollection<CertificateLstModel> CertificateLst { get { return _CertificateLst; } set { _CertificateLst = value; RaisePropertyChanged(); } }

        CertificateLstModel selectedLValue = null;
        public CertificateLstModel SelectedValue { get { return selectedLValue; } set { selectedLValue = value; RaisePropertyChanged(); } }


        IOnlineServices _breadfestService;

        string isManager = "0";
        bool _IsShowNewRequest;
        public bool IsShowNewRequest { get { return _IsShowNewRequest; } set { _IsShowNewRequest = value; RaisePropertyChanged(); } }


        public CertificatesViewModel(IOnlineServices breadfestService, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _breadfestService = breadfestService;

        }
        public DelegateCommand GoToDetailsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (SelectedValue != null)
                    {
                        var parameters = new NavigationParameters();
                        parameters.Add("IsFromManager", isManager);
                        parameters.Add("details", SelectedValue);

                        await NavigationService.NavigateAsync("CertificateRequest", parameters);
                        SelectedValue = null;
                    }

                });

            }
        }



        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters["IsFromManager"] != null)
            {
                isManager = parameters["IsFromManager"].ToString();

            }
            IsShowNewRequest = isManager == "0" ? true : false;
            if (!IsShowNewRequest && Preferences.Get("role", 0) == 2)
            {

                string endPoint = $"GetManagerPendingData/{Preferences.Get("Department", "")}";
                await GetCertificatetLst(endPoint);
            }
            if (!IsShowNewRequest && Preferences.Get("role", 0) == 3)
            {

                string endPoint = $"GetHRManagerPendingData";
                await GetCertificatetLst(endPoint);
            }
            else if (!IsShowNewRequest && Preferences.Get("role", 0) == 4)
            {
                string endPoint = $"GetHROfficerPendingData/{Preferences.Get("userId", 0)}";
                await GetCertificatetLst(endPoint);
            }
            else
            {
                if (IsShowNewRequest)
                {
                    string endpoint = $"GetCertificateByStuffId/{Preferences.Get("userId", 0)}";
                    await GetCertificatetLst(endpoint);
                }

            }
            base.OnNavigatedTo(parameters);
        }
        async Task GetCertificatetLst(string endpoint)
        {
            try
            {
                IsLoading = true;
                var resp = await _breadfestService.GetCertificateRequests(endpoint);
                if (resp.Item2)
                {
                    CertificateLst = resp.Item1;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }

    }
}
