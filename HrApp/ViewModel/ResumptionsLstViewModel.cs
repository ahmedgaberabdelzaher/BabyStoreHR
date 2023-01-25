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
    public class ResumptionsLstViewModel:ViewModelBase
    {
        ObservableCollection<LeaveResumtionsModel> resumpitionsLeaveLst = new ObservableCollection<LeaveResumtionsModel>();
        public ObservableCollection<LeaveResumtionsModel> ResumpitionsLeaveLst { get { return resumpitionsLeaveLst; } set { resumpitionsLeaveLst = value; RaisePropertyChanged(); } }

LeaveResumtionsModel selectedLeave =null;
        public LeaveResumtionsModel SelectedLeave { get { return selectedLeave; } set { selectedLeave = value; RaisePropertyChanged(); } }


        ILeaveServices _leaveService;

        string isManager = "0";
        bool _IsShowNewRequest;
        public bool IsShowNewRequest { get { return _IsShowNewRequest; } set { _IsShowNewRequest = value; RaisePropertyChanged(); } }


        public ResumptionsLstViewModel(ILeaveServices leaveService, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
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

                        await NavigationService.NavigateAsync("ResumtionLeaveRequest", parameters);
                        SelectedLeave = null;
                    }

                });

            }
        }

        public DelegateCommand GoToResumptionLeavesPageCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await NavigationService.NavigateAsync("ResumtionLeaveRequest");
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
            if (!IsShowNewRequest&&Preferences.Get("role",0)==3)
            {

                string endPoint = $"GetHRManagerPendingData";
                await GetResumptionLst(endPoint);
            }
            else if (!IsShowNewRequest && Preferences.Get("role", 0) == 4)
            {
                string endPoint = $"GetHROfficerPendingData/{Preferences.Get("userId", 0)}";
                await GetResumptionLst(endPoint);
            }
            else
            {
                if (IsShowNewRequest)
                {
                    string endpoint= $"GetResumptionsByStuffId/{Preferences.Get("userId",0)}";
             await GetResumptionLst(endpoint);
                }
              
            }
            base.OnNavigatedTo(parameters);
        }
        async Task GetResumptionLst(string endpoint)
        {
            try
            {
                IsLoading = true;
                var resp = await _leaveService.GetResumptionsLeaveRequests(endpoint);
                if (resp.Item2)
                {
                    ResumpitionsLeaveLst = resp.Item1;
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
