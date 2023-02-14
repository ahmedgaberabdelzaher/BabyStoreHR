using System;
using System.Threading.Tasks;
using HrApp.Model;
using HrApp.Services.Interface;
using HrApp.View.NewsViews;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HrApp.ViewModel
{
    public class HomeViewModel: NotificationViewModel
    {
        
        bool isOnlineServices ;

        public bool IsOnlineServices
        {
            get { return isOnlineServices; }
            set
            {
                SetProperty(ref isOnlineServices, value);
            }
        }
      

        bool isManager;

        public bool IsManager
        {
            get { return isManager; }
            set
            {
                SetProperty(ref isManager, value);
            }
        }

      

        bool isHome;

        public bool IsHome
        {
            get { return isHome; }
            set
            {
                SetProperty(ref isHome, value);
            }
        }

        bool isEmployeeCenter;

        public bool IsEmployeeCenter
        {
            get { return isEmployeeCenter; }
            set
            {
                SetProperty(ref isEmployeeCenter, value);
            }
        }

        bool isManagereCenter;

        public bool IsManagereCenter
        {
            get { return isManagereCenter; }
            set
            {
                SetProperty(ref isManagereCenter, value);
            }
        }
        
        public DelegateCommand OverTimeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Over Time");
                    await NavigationService.NavigateAsync("OverTimeList", parameters);
                });

            }
        }

        public DelegateCommand StaffShacheduleCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Staff Shachedule");
                    await NavigationService.NavigateAsync(ViewsRoutes.StaffSchedule, parameters);
                });

            }
        }

        public DelegateCommand AttendenceCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Staff Attendance");
                    await NavigationService.NavigateAsync(ViewsRoutes.StaffAttendance, parameters);
                });

            }
        }


        public DelegateCommand EmployeeCenterCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Employee Center");
                    parameters.Add("PageDesc", "Manage online requests and access your records easily");

                    await NavigationService.NavigateAsync("EmployeeCenter", parameters);
                });

            }
        }

        public DelegateCommand DepartmentScheduleCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "EDepartment Schedule");
                    await NavigationService.NavigateAsync(ViewsRoutes.MgrStaffSchedule, parameters);
                });

            }
        }

        public DelegateCommand EmployeeAttendanceCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "EDepartment Schedule");
                    await NavigationService.NavigateAsync(ViewsRoutes.MgrStaffAttendancePage, parameters);
                });

            }
        }

        public DelegateCommand QuickLinksCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Quick Links");
                    await NavigationService.NavigateAsync(ViewsRoutes.QuickLinksPage, parameters);
                });

            }
        }

        public DelegateCommand EmployeeDirectoryCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Employee Directory");

                    await NavigationService.NavigateAsync(ViewsRoutes.EmployeeDirectoryPage, parameters);
                });

            }
        }


        public DelegateCommand ManagerCenterCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Manager Center");
                    parameters.Add("PageDesc", "Access department employees information, requests, duty schedule, and attendance.");

                    await NavigationService.NavigateAsync("ManagerCenter", parameters);
                });

            }
        }
        public DelegateCommand OfficerCenterCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "HR Officer Center");
                    parameters.Add("PageDesc", "Access department employees information, requests, duty schedule, and attendance.");

                    await NavigationService.NavigateAsync("ManagerOnlineRequests", parameters);
                });

            }
        }
        
        public DelegateCommand ShowFaqCommand
        {
            get
            {
                return new DelegateCommand(async () => { await NavigationService.NavigateAsync("FAQ"); });
            }
        }

        public DelegateCommand ShowHomeCommand
        {
            get
            {
                return new DelegateCommand(async () => { await NavigationService.NavigateAsync("Home"); });

            }
        }

      
             
        public DelegateCommand LifeChatCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var result = await chatService.GetAgentState();
                 /*   if (result.Item2 == "1"|| Preferences.Get("IsAgent", 0).ToString() == "1")
                    {*/
                        var parameters = new NavigationParameters();

                        if (Preferences.Get("IsAgent", 0).ToString() == "1" )
                        {
                            parameters.Add("PageTitle", "Chat List");
                            await NavigationService.NavigateAsync("LiveChatList", parameters);
                        }
                        else
                        {
                            parameters.Add("PageTitle", "Live Chat");
                            await NavigationService.NavigateAsync("LiveChat", parameters);
                        }
                 //   }
                 /*   else
                    {
                      await  DialogService.DisplayAlertAsync("Alert", "The agent is not connected", "cancel");
                    }*/
                 
                });

            }
        }


        public DelegateCommand StcCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    
                    await NavigationService.NavigateAsync("StcSubscriptionLst");
                });

            }
        }

        public DelegateCommand PermisionToLeaveCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                  
                    await NavigationService.NavigateAsync("PermissionToLeaveLst");
                });

            }
        }

        public DelegateCommand BreatFeastCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    await NavigationService.NavigateAsync("BreastfeedingLst");
                });

            }
        }

        public DelegateCommand DigitalValetCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    await NavigationService.NavigateAsync(ViewsRoutes.DigitalValetPage);
                });

            }
        }

        public DelegateCommand CertificatesCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    await NavigationService.NavigateAsync("CertificateLst");
                });

            }
        }

        public DelegateCommand OnlineRequestsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Online Services");
                    parameters.Add("PageDesc", "Click on the desired service, fill the form, and submit ​");

                    await NavigationService.NavigateAsync("OnlineServices", parameters);
                });

            }
        }

        public DelegateCommand ManagerOnlineRequestsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Online Services");
                    parameters.Add("PageDesc", "Review and process submitted online requests.");

                    await NavigationService.NavigateAsync("ManagerOnlineRequests", parameters);
                });

            }
        }

        public DelegateCommand LeavesCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "Leaves");
                    parameters.Add("PageDesc", "Leaves Page");

                    await NavigationService.NavigateAsync("Leaves", parameters);
                });

            }
        }
        public DelegateCommand GetStartedCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                 
                    await NavigationService.NavigateAsync("/Home");
                });

            }
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
                    navParameters.Add("IsFromManager", "0");
                    navParameters.Add("LeaaveTypeName", "");
                    Preferences.Set("LeaveCode", int.Parse(e));
                   await NavigationService.NavigateAsync("LeavesList",navParameters);
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
                    navParameters.Add("IsFromManager", "0");
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
                   // navParameters.Add("LeaveCode", int.Parse(e));
                    navParameters.Add("List", 1);
                    navParameters.Add("IsFromManager", "0");
                    navParameters.Add("LeaaveTypeName", "");
                  //  Preferences.Set("LeaveCode", int.Parse(e));
                    await NavigationService.NavigateAsync("EncashmentLeaveLst");
                });

            }
        }
        /*  public DelegateCommand NewsBoardCommand
          {
              get
              {
                  return new DelegateCommand(async () =>
                  {
                      var parameters = new NavigationParameters();
                      parameters.Add("PageTitle", "News Board");
                      await NavigationService.NavigateAsync("NewsBoard", parameters);
                  });

              }
          }*/

     //   public Command NavToNewsPage { get; set; }
        public DelegateCommand NewsCommand
        {
             get
             {
                 return new DelegateCommand(async () =>
                 {
                     var parameters = new NavigationParameters();
                     parameters.Add("PageTitle", "News Events");
                     await NavigationService.NavigateAsync("NewsList", parameters);
                 });

             }
         }

        public DelegateCommand FAQCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "News Events");
                    await NavigationService.NavigateAsync("FAQ", parameters);
                });

            }
        }

        public IUserServices _userServices { get; }

        private readonly IChatService chatService;
        INotificationServices _Notification;
        public HomeViewModel(IChatService chatService,INotificationServices notification, IUserServices userServices ,INavigationService navigationServices, IPageDialogService pageDialogService) : base(notification, navigationServices, pageDialogService)
        {
            this.chatService = chatService;
            _Notification = notification;
            _userServices =userServices;
           
            if (Preferences.Get("role",0)==1)
            {
                IsEmployee = true;
            }
            else
            {
                IsManager = true;
            }
            IsHome = true;

            ViewModelBase.connection.On<int>("ShowNewMessage", (NewMessage) => ShowMessage(NewMessage));
             chatService.Connect("0");




        }

       

        public override async void OnNavigatedFrom(INavigationParameters parameters)
        {
          
            base.OnNavigatedFrom(parameters);
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            newmessage = "livechaticon.png";
            base.OnNavigatedTo(parameters);
           ViewModelBase.connection.On<int>("ShowNewMessage", (NewMessage) => ShowMessage(NewMessage));
           await chatService.Connect("0");
          

        }

        public DelegateCommand GoToOnlineServicesMenuCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    await NavigationService.NavigateAsync(ViewsRoutes.OnlineServicesView) ;
                });

            }
        }
        public async override void Initialize(INavigationParameters parameters)
        {
            if (parameters!=null&&parameters.Count>0)
            {
                PageTitle = parameters["PageTitle"].ToString();
                PageDesc= parameters["PageDesc"].ToString();
            }
            else
            {
                PageTitle = "HR\nAl Seef";
                PageDesc = "Connecting with HR is much easier and faster now";
            }
       //     await CheckLoginAsync();
     //     await  GetNotificationList(_Notification);
            base.Initialize(parameters);
        }
    }
}
