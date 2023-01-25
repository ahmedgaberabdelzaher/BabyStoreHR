using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using HrApp.Controls;
using HrApp.Model;
using HrApp.Services.Class;
using HrApp.Services.Interface;
using HrApp.View;
using HrApp.View.FAQ;
using HrApp.View.NewsViews;
using HrApp.View.NotificationViews;
using HrApp.View.OverTimeViews;
using HrApp.View.SecondSplach;
using HrApp.ViewModel;
using Plugin.FirebasePushNotification;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OnlineServices = HrApp.View.OnlineServices;

namespace HrApp
{
    


    public partial class App : PrismApplication
    {
        public App() : this(null) { }
        #region Dev Url
       /*
       public static string BaseAuth = "https://tmsapp.westeurope.cloudapp.azure.com:4434/HRAuth/";
       public static string BaseUrl = "https://tmsapp.westeurope.cloudapp.azure.com:4434/HR/";
         */
        #endregion
        
        public static string BaseAuth = "https://myalseef.alseef-hospital.com/";

         public static string BaseUrl = "https://myalseef.alseef-hospital.com/HR/";
       
        public static string HRDEBNAME = "Human Resources & Administration";

        
        public static string defaultLang = "en";
        public App(IPlatformInitializer initializer) : base(initializer) {

        }
        
        protected override async void OnInitialized()
        {
            InitializeComponent();
            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                Preferences.Set("FCMToken", p.Token);

            };
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {


            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {


            };

            var languageId = Preferences.Get("LanguageId", defaultLang);
            var culturee = new CultureInfo(languageId);
            // LangaugeResource.Culture = culturee;
            // CrossMultilingual.Current.CurrentCultureInfo = culturee;
            var isLoged = Preferences.Get("IsLogedIn", false);
            // var user = await SecureStorage.GetAsync("user");
            // var _password = await SecureStorage.GetAsync("passwerd");
            //if (user!=null&&_password!=null)
            /* if (isLoged)
             {

                 await NavigationService.NavigateAsync("/NavigationPage/Home");

             }
             else
             {
            */
          //  await NavigationService.NavigateAsync("NavigationPage/LogIn");

            //   await NavigationService.NavigateAsync("/NavigationPage/Home");
             await NavigationService.NavigateAsync("NavigationPage/SecondSplach");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTc5NTg3QDMxMzkyZTM0MmUzMEM3ekZjMG5LcllibHFQd2krTjU0K2FBTXd1bVp4ZEdQOXZkRjhwbTgzTVE9");
            /* if (isLoged)
             {
               

             }
             else
             {
             //    await NavigationService.NavigateAsync("/NavigationPage/LogIn");


             }*/
            //  }
            // await NavigationService.NavigateAsync(ViewsRoutes.EmployeeDirectoryPage);
        }

        public static ObservableCollection<LookUpModel> LeaveTypes { get; set; } = new ObservableCollection<LookUpModel>()
        {
            new LookUpModel()
            {
                Id=1,Name="Annual"
            },
             new LookUpModel()
            {
                Id=2,Name="Unpaid"
            },
              new LookUpModel()
            {
                Id=3,Name="Hajj"
            },
             new LookUpModel()
            {
                Id=15,Name="Time Back"
            },
                new LookUpModel()
            {
                Id=17,Name="Sick"
            },
             new LookUpModel()
            {
                Id=14,Name="Conference"
            },
              new LookUpModel()
            {
                Id=6,Name="Compassionate"
            },
             new LookUpModel()
            {
                Id=16,Name="Buisness Trip"
            },
              new LookUpModel()
            {
                Id=7,Name="Study"
            },
              new LookUpModel()
            {
                Id=4,Name="Maternity"
            }

        };
    

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<ResumtionLeaveRequest,LeaveResupmisionViewModel>();
            containerRegistry.RegisterForNavigation<ResupmisionsLst, ResumptionsLstViewModel>();
            containerRegistry.RegisterForNavigation<EncashmentLeave, EncahmentViewModel>();
            containerRegistry.RegisterForNavigation<EncashmentLeaveLst, EncashmentLeavesLstViewModel>();

            containerRegistry.RegisterForNavigation<StcSubscriptionLst, StcLstViewModel>();
            containerRegistry.RegisterForNavigation<StcSubscription, StcSubscriptionViewModel>();
            containerRegistry.RegisterForNavigation<LiveChat, LiveChatVM>();



            containerRegistry.RegisterForNavigation<Profile,ProfileViewModel>();

            containerRegistry.RegisterForNavigation<WelcomePage,HomeViewModel>();
            containerRegistry.RegisterForNavigation<LeavesList, LeavesListViewModel>();
            containerRegistry.RegisterForNavigation<PdfViwerControler, PdfVM>();

            containerRegistry.RegisterForNavigation<LeaveRequest, LeaveRequestViewModel>();
            containerRegistry.RegisterForNavigation<ManagerLeaves, LeavesViewModel>();
            containerRegistry.RegisterForNavigation<ManagerOnlineRequests, OnlineServicesViewModel>();
            containerRegistry.RegisterForNavigation<LeaveRequestDetails, LeaveRequestDetailsViewModel>();
            containerRegistry.RegisterForNavigation<PermissionToLeaveLst, PermisionToLeavesLstViewmodel>();
            containerRegistry.RegisterForNavigation<PermisionToLeaveNewRequest, PermisionToLeaveNewRequestViewModel>();

            containerRegistry.RegisterForNavigation<BreastfeedingLst, BreatFestListViewModel>();
            containerRegistry.RegisterForNavigation<BreastfeedingNewRequest, BreatFestRequestViewModel>();


            containerRegistry.RegisterForNavigation<CertificateLst, CertificatesViewModel>();
            containerRegistry.RegisterForNavigation<CertificateRequest, CertificateNewRequestViewModel>();



            containerRegistry.RegisterForNavigation<Register,UserViewModel>();
            containerRegistry.RegisterForNavigation<ResetPassword, UserViewModel>();

            containerRegistry.RegisterForNavigation<LogIn, UserViewModel>();
            containerRegistry.RegisterForNavigation<Home, HomeViewModel>();
            containerRegistry.RegisterForNavigation<ManagerCenter, HomeViewModel>();
            containerRegistry.RegisterForNavigation<EmployeeCenter, HomeViewModel>();
            containerRegistry.RegisterForNavigation<Leaves, HomeViewModel>();
            containerRegistry.RegisterForNavigation<LiveChatList, ChatViewModel>();

           // containerRegistry.RegisterForNavigation<LiveChatList, ChatViewModel>();
           // containerRegistry.RegisterForNavigation<NewsBoard, HomeViewModel>();

            containerRegistry.RegisterForNavigation<OnlineServices, HomeViewModel>();
            containerRegistry.RegisterForNavigation<OverTimeList, OverTimeViewModel>();
            containerRegistry.RegisterForNavigation<OverTimeRequest, OverTimeViewModel>();

           
            containerRegistry.RegisterForNavigation<OnlineServices, HomeViewModel>();
            containerRegistry.RegisterForNavigation<StaffSchedulePage, StaffSchedulePageViewModel>(ViewsRoutes.StaffSchedule);
            containerRegistry.RegisterForNavigation<StaffAttendancePage, StaffAttendancePageViewModel>(ViewsRoutes.StaffAttendance);
            containerRegistry.RegisterForNavigation<MgrStaffSchedulePage, MgrStaffSchedulePageViewModel>(ViewsRoutes.MgrStaffSchedule);
            containerRegistry.RegisterForNavigation<MgrStaffAttendancePage, MgrStaffAttendancePageViewModel>(ViewsRoutes.MgrStaffAttendancePage);
            containerRegistry.RegisterForNavigation<QuickLinksPage, QuickLinksPageViewModel>(ViewsRoutes.QuickLinksPage);
            containerRegistry.RegisterForNavigation<DigitalValetPage, DigitalValetPageViewModel>(ViewsRoutes.DigitalValetPage);
            containerRegistry.RegisterForNavigation<NewsList, NewsViewModel>();
            containerRegistry.RegisterForNavigation<NewsDetails, NewsDetailsViewMode>();
            containerRegistry.RegisterForNavigation<OverTimeDetails, OverTimeDetailsViewModel>();
            containerRegistry.RegisterForNavigation<FAQ, FAQViewModel>();
            containerRegistry.Register<IChatService, ChatService>();

            containerRegistry.Register<IUserServices, UserServices>();
            containerRegistry.Register<ILeaveServices, LeaveServices>();
            containerRegistry.Register<IOverTimeServices, OverTimeServices>();
            containerRegistry.RegisterForNavigation<EmployeeDirectoryPage, EmployeeDirectoryPageViewModel>(ViewsRoutes.EmployeeDirectoryPage);

            containerRegistry.Register<IUserServices, UserServices>();
            containerRegistry.Register<ILeaveServices, LeaveServices>();
            containerRegistry.Register<IStaffService, StaffService>();
            containerRegistry.Register<IOnlineServices,Services.Class.OnlineServices>();
            containerRegistry.Register<INewsServices, NewsServices>();
            containerRegistry.Register<IFAQServices, FAQServices>();
            containerRegistry.Register<INotificationServices, NotificationServices>();



          //  containerRegistry.RegisterForNavigation<SecondSplach>();


            containerRegistry.RegisterForNavigation<SecondSplach, SecondSplachViewModel>();
            containerRegistry.RegisterForNavigation<NotificationList, NotificationViewModel>();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
