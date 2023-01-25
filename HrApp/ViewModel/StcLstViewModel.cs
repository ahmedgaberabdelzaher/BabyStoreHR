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
    public class StcLstViewModel :ViewModelBase
    {
        ObservableCollection<StcSubscriptionLStModel> stcSubscriptionLst = new ObservableCollection<StcSubscriptionLStModel>();
    public ObservableCollection<StcSubscriptionLStModel> StcSubscriptionLst { get { return stcSubscriptionLst; } set { stcSubscriptionLst = value; RaisePropertyChanged(); } }

        StcSubscriptionLStModel selectedItem = null;
    public StcSubscriptionLStModel SelectedItem { get { return selectedItem; } set { selectedItem = value; RaisePropertyChanged(); } }


    ILeaveServices _leaveService;

    string isManager = "0";
    bool _IsShowNewRequest;
    public bool IsShowNewRequest { get { return _IsShowNewRequest; } set { _IsShowNewRequest = value; RaisePropertyChanged(); } }


    public StcLstViewModel(ILeaveServices leaveService, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
    {
        _leaveService = leaveService;

    }
    public DelegateCommand GoToDetailsCommand
    {
        get
        {
            return new DelegateCommand(async () =>
            {
                if (SelectedItem != null)
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("IsFromManager", isManager);
                    parameters.Add("details", SelectedItem);

                    await NavigationService.NavigateAsync("StcSubscription", parameters);
                    SelectedItem = null;
                }

            });

        }
    }

    public DelegateCommand GoToENewPageCommand
    {
        get
        {
            return new DelegateCommand(async () =>
            {
                await NavigationService.NavigateAsync("StcSubscription");
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
    
        if (!IsShowNewRequest && Preferences.Get("role", 0) == 4)
        {
            string endPoint = $"GetHROfficerPendingData/{Preferences.Get("userId", 0)}";
            await GetEncashmentLeaveLst(endPoint);
        }
        else
        {
            if (IsShowNewRequest)
            {
                string endpoint = $"GetSubscriptionByStuffId/{Preferences.Get("userId", 0)}";
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
            var resp = await _leaveService.GetStcRequests(endpoint);
            if (resp.Item2)
            {
                StcSubscriptionLst = resp.Item1;
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
