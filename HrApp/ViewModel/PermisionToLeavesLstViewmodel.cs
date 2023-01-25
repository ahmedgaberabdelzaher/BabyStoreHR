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
    public class PermisionToLeavesLstViewmodel:ViewModelBase
    {
        ObservableCollection<PermissionsToLeaveLst> permissionsToLeaveLstLst = new ObservableCollection<PermissionsToLeaveLst>();
        public ObservableCollection<PermissionsToLeaveLst> PermissionsToLeaveLstLst { get { return permissionsToLeaveLstLst; } set { permissionsToLeaveLstLst = value; RaisePropertyChanged(); } }

        PermissionsToLeaveLst selectedLValue = null;
        public PermissionsToLeaveLst SelectedValue { get { return selectedLValue; } set { selectedLValue = value; RaisePropertyChanged(); } }


        IOnlineServices _onlineServices;

        string isManager = "0";
        bool _IsShowNewRequest;
        public bool IsShowNewRequest { get { return _IsShowNewRequest; } set { _IsShowNewRequest = value; RaisePropertyChanged(); } }


        public PermisionToLeavesLstViewmodel(IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _onlineServices = onlineServices;

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

                        await NavigationService.NavigateAsync("PermisionToLeaveNewRequest", parameters);
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
                await GetPermisionstLst(endPoint);
            }
            if (!IsShowNewRequest && Preferences.Get("role", 0) == 3)
            {

                string endPoint = $"GetHRManagerPendingData";
                await GetPermisionstLst(endPoint);
            }
            else if (!IsShowNewRequest && Preferences.Get("role", 0) == 4)
            {
                string endPoint = $"GetHROfficerPendingData/{Preferences.Get("userId", 0)}";
                await GetPermisionstLst(endPoint);
            }
            else
            {
                if (IsShowNewRequest)
                {
                    string endpoint = $"GetPermissionByStuffId/{Preferences.Get("userId", 0)}";
                    await GetPermisionstLst(endpoint);
                }

            }
            base.OnNavigatedTo(parameters);
        }
        async Task GetPermisionstLst(string endpoint)
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.GetPermitionsToLeaveRequests(endpoint);
                if (resp.Item2)
                {
                    PermissionsToLeaveLstLst = resp.Item1;
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
