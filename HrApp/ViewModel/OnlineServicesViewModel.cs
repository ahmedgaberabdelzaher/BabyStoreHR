using System;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace HrApp.ViewModel
{
    public class OnlineServicesViewModel:NotificationViewModel
    {

        public OnlineServicesViewModel(INavigationService navigationServices, IUserServices userServices, IPageDialogService pageDialogService,INotificationServices notificationServices) : base(notificationServices,navigationServices, pageDialogService)
        {
            PageTitle = "Online Requests";
            PageDesc = "Review and process submitted online requests.";
        }

        public DelegateCommand LeavesCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var navParameters = new NavigationParameters();
                  /*  navParameters.Add("LeaveCode", 0);
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "1");
                    navParameters.Add("LeaaveTypeName", "");
                    Preferences.Set("LeaveCode", 0);*/
                    // await NavigationService.NavigateAsync("LeavesList", navParameters);
                    navParameters.Add("PageTitle", "Leaves");
                      await NavigationService.NavigateAsync("ManagerLeaves", navParameters);
                });

            }
        }


       //OverTimeCommand
        public DelegateCommand StcCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var navParameters = new NavigationParameters();
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "1");
                    await NavigationService.NavigateAsync("StcSubscriptionLst",navParameters);
                });

            }
        }

        public DelegateCommand PermisionToLeaveCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var navParameters = new NavigationParameters();
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "1");
                    await NavigationService.NavigateAsync("PermissionToLeaveLst", navParameters);
                });

            }
        }
        public DelegateCommand BreatFeastCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var navParameters = new NavigationParameters();
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "1");
                    await NavigationService.NavigateAsync("BreastfeedingLst", navParameters);
                });

            }
        }
        public DelegateCommand OverTimeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var navParameters = new NavigationParameters();
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "1");
                    await NavigationService.NavigateAsync("OverTimeList", navParameters);
                });

            }
        }


        public DelegateCommand CertificatesCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var navParameters = new NavigationParameters();
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "1");
                    await NavigationService.NavigateAsync("CertificateLst",navParameters);
                });

            }
        }

        public DelegateCommand ShowHomeCommand
        {
            get
            {
                return new DelegateCommand(async () => { await NavigationService.NavigateAsync("Home"); });

            }
        }

        public DelegateCommand ShowFaqCommand
        {
            get
            {
                return new DelegateCommand(async () => { await NavigationService.NavigateAsync(ViewsRoutes.DigitalValetPage); });
            }
        }
    }
}
