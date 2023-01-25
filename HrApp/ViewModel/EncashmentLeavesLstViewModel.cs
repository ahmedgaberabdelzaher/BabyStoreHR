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
    public class EncashmentLeavesLstViewModel : ViewModelBase
    {
        ObservableCollection<EncashmentLeaves> encahmmentLeaveLst = new ObservableCollection<EncashmentLeaves>();
        public ObservableCollection<EncashmentLeaves> EncahmmentLeaveLst { get { return encahmmentLeaveLst; } set { encahmmentLeaveLst = value; RaisePropertyChanged(); } }

        EncashmentLeaves selectedLeave = null;
        public EncashmentLeaves SelectedLeave { get { return selectedLeave; } set { selectedLeave = value; RaisePropertyChanged(); } }


        ILeaveServices _leaveService;

        string isManager = "0";
        bool _IsShowNewRequest;
        public bool IsShowNewRequest { get { return _IsShowNewRequest; } set { _IsShowNewRequest = value; RaisePropertyChanged(); } }


        public EncashmentLeavesLstViewModel(ILeaveServices leaveService, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _leaveService = leaveService;

        }
        public DelegateCommand GoToDetailsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (SelectedLeave != null)
                    {
                        var parameters = new NavigationParameters();
                        parameters.Add("IsFromManager", isManager);
                        parameters.Add("details", SelectedLeave);

                        await NavigationService.NavigateAsync("EncashmentLeave", parameters);
                        SelectedLeave = null;
                    }

                });

            }
        }

        public DelegateCommand GoToEncashmentLeavePageCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                   /* var parameters = new NavigationParameters();
                    parameters.Add("IsFromManager", isManager);*/
                  
                    await NavigationService.NavigateAsync("EncashmentLeave");
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
            if (!IsShowNewRequest && Preferences.Get("role", 0) == 3)
            {

                string endPoint = $"GetHRManagerPendingData/";
                await GetEncashmentLeaveLst(endPoint);
            }
             else if (!IsShowNewRequest && Preferences.Get("role", 0) == 4)
            {
                string endPoint = $"GetHROfficerPendingData/{Preferences.Get("userId", 0)}";
                await GetEncashmentLeaveLst(endPoint);
            }
            else
            {
                if (IsShowNewRequest)
                {
                    string endpoint = $"GetEncashmentByStuffId/{Preferences.Get("userId", 0)}";
                    await GetEncashmentLeaveLst(endpoint);
                }

            }
            base.OnNavigatedTo(parameters);
        }
        async Task GetEncashmentLeaveLst(string endpoint)
        {
            try
            {
                IsLoading = true;
                var resp = await _leaveService.GetEncashmentLeaveRequests(endpoint);
                if (resp.Item2)
                {
                    EncahmmentLeaveLst = resp.Item1;
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
