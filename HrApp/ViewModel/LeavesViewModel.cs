using System;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace HrApp.ViewModel
{
    public class LeavesViewModel:ViewModelBase
    {
       
        public LeavesViewModel(INavigationService navigationServices, IUserServices userServices, IPageDialogService pageDialogService) : base(navigationServices, pageDialogService)
        {
            PageTitle = "Leaves";
            
        }
        public DelegateCommand<string> GoToLeavesPageCommand
        {
            get
            {
                return new DelegateCommand<string>(async (e) =>
                {
                    var navParameters = new NavigationParameters();
                    navParameters.Add("LeaveCode", int.Parse(e));
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "1");
                    navParameters.Add("LeaaveTypeName", "");
                    Preferences.Set("LeaveCode", int.Parse(e));
                    await NavigationService.NavigateAsync("LeavesList", navParameters);
                });

            }
        }
        public DelegateCommand<string> GoToResumptionLeavesPageCommand
        {
            get
            {
                return new DelegateCommand<string>(async (e) =>
                {
                    var navParameters = new NavigationParameters();
                    navParameters.Add("LeaveCode", int.Parse(e));
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "1");
                    navParameters.Add("LeaaveTypeName", "");
                    Preferences.Set("LeaveCode", int.Parse(e));
                    await NavigationService.NavigateAsync("ResupmisionsLst", navParameters);
                });

            }
        }

        public DelegateCommand GoToEncashmentPageCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var navParameters = new NavigationParameters();
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "1");
                    navParameters.Add("LeaaveTypeName", "");
                    await NavigationService.NavigateAsync("EncashmentLeaveLst",navParameters);
                });

            }
        }
    }
}
