using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using HrApp.Controls;
using HrApp.Model;
using HrApp.Resources;
using HrApp.Services.Class;
using HrApp.Services.Interface;
using HrApp.View;
using HrApp.View.FAQ;
using HrApp.View.NewsViews;
using HrApp.View.NotificationViews;
using HrApp.View.OverTimeViews;
using HrApp.View.Requests;
using HrApp.View.SecondSplach;
using HrApp.ViewModel;
using HrApp.ViewModel.OnlineServicesViewModels;
using Plugin.FirebasePushNotification;
using Plugin.Multilingual;
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
        
        public static string BaseAuth = "https://supportatit-babystory-addons-stg-8198551.dev.odoo.com/";

         public static string BaseUrl = "https://supportatit-babystory-addons-stg-8198551.dev.odoo.com/";
        public static string OdoDBName = "supportatit-babystory-addons-stg-8198551";
        public static string HRDEBNAME = "Human Resources & Administration";
        public static string OdoDUserame = "admin";
        public static string OdoPasssword = "Baby$tory2";

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
            CrossMultilingual.Current.CurrentCultureInfo = culturee;
            // LangaugeResource.Culture = culturee;
            // CrossMultilingual.Current.CurrentCultureInfo = culturee;
            var isLoged = Preferences.Get("IsLogedIn", false);
            // var user = await SecureStorage.GetAsync("user");
            // var _password = await SecureStorage.GetAsync("passwerd");
            //if (user!=null&&_password!=null)
            if (isLoged)
            {

               await NavigationService.NavigateAsync("/NavigationPage/Home");
               //  await NavigationService.NavigateAsync("/NavigationPage/PendingRequestsView");
                
            }
            else
            {

                await NavigationService.NavigateAsync("NavigationPage/LogIn");
            }
          //  await NavigationService.NavigateAsync("/NavigationPage/Profile");

            //  await NavigationService.NavigateAsync("NavigationPage/SecondSplach");
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTc5NTg3QDMxMzkyZTM0MmUzMEM3ekZjMG5LcllibHFQd2krTjU0K2FBTXd1bVp4ZEdQOXZkRjhwbTgzTVE9");
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
                Id=1,Name="Annual",
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

        public static ObservableCollection<LookUpModel> EmployeeRequests { get; set; } = new ObservableCollection<LookUpModel>()
        {
            new LookUpModel()
            {
                Id=1,Name=LangaugeResource.LeaveRequests,icon="HrApp.Images.Leave.svg",PageName="LeavesList"
            }/*,
             new LookUpModel()
            {
                Id=2,Name="Modify Leave Requests",icon="Modify-Leaves.svg",
            }*/,
              new LookUpModel()
            {
                Id=3,Name=LangaugeResource.SalaryTransferRequest,icon="HrApp.Images.Salary-Transfer.svg",PageName="SalleryTransferRequest"
            },
             new LookUpModel()
            {
                Id=4,Name=LangaugeResource.Letter_Requests,icon="HrApp.Images.Papers.svg",PageName="LetterRequests"
            },
                new LookUpModel()
            {
                Id=5,Name=LangaugeResource.Access_Card_Request,icon="HrApp.Images.Access-Card.svg",PageName="AccessCardRequestLstView"
            },
             new LookUpModel()
            {
                Id=6,Name=LangaugeResource.ResignationRequest,icon="HrApp.Images.Resignation.svg",PageName="ResignationRequests"
            },
              new LookUpModel()
            {
                Id=7,Name=LangaugeResource.BusinessCardRequest,icon="HrApp.Images.Business-Card.svg",PageName="BusinessCardRequest"
            },
             new LookUpModel()
            {
                Id=8,Name=LangaugeResource.CustodyRequest,icon="HrApp.Images.Custody.svg",PageName="CustodyRequests"
            },
              new LookUpModel()
            {
                Id=9,Name=LangaugeResource.EmailRequest,icon="HrApp.Images.Email.svg",PageName="EmailRequests"
            },
              new LookUpModel()
            {
                Id=10,Name=LangaugeResource.TicketCashRequest,icon="HrApp.Images.Ticket.svg",PageName="TicketCashRequestView"
            }
              ,
              new LookUpModel()
            {
                Id=11,Name=LangaugeResource.MedicalInsuranceRequest,icon="HrApp.Images.Medical-Insurance.svg"
            }
               /*,
              new LookUpModel()
            {
                Id=12,Name="Relative Request",icon="HrApp.Images.Employee-Relative.svg"
            }*/
               ,
              new LookUpModel()
            {
                Id=13,Name=LangaugeResource.Permission_Request,icon="HrApp.Images.Permission.svg",PageName="PermissionRequest"
            }
              ,
              new LookUpModel()
            {
                Id=14,Name=LangaugeResource.BusinessTravelRequest,icon="HrApp.Images.Business-Travel.svg",PageName="BusinessTravelRequestView"
            }
              ,
              new LookUpModel()
            {
                Id=15,Name=LangaugeResource.BackFromVacationRequest,icon="HrApp.Images.Back-From-Vacation.svg",PageName="BAckFromVacationRequest"
            },
              new LookUpModel()
            {
                Id=16,Name=LangaugeResource.LegalAdviceRequest,icon="HrApp.Images.Legal-Advice.svg",PageName="LegalAdviceRequesView"
            }
              ,
              new LookUpModel()
            {
                Id=17,Name=LangaugeResource.FinancialRequest,icon="HrApp.Images.Financial.svg",PageName="FinancialRequestView"
            }
              ,
              new LookUpModel()
            {
                Id=18,Name=LangaugeResource.ExitRe_EntryVISARequest,icon="HrApp.Images.Exit-Re-Entry-VISA.svg",PageName="ExitReEntryVISARequest"
            }
               ,
              new LookUpModel()
            {
                Id=19,Name=LangaugeResource.RenewalPassportRequest,icon="HrApp.Images.Renewal-Passport.svg",PageName="RenewalPassportRequestView"
            }
                ,
              new LookUpModel()
            {
                Id=20,Name=LangaugeResource.RenewalResidenceRequestt,icon="HrApp.Images.Renewal-Residence.svg",PageName="RenewalResidenceRequestView"
            }
        };

        public static ObservableCollection<LookUpModel> DirectManagerRequests { get; set; } = new ObservableCollection<LookUpModel>()
        {
            new LookUpModel()
            {
                Id=21,Name=LangaugeResource.LoanRequest,icon="Loan.svg",PageName="LoanRequestsView"
            },
             new LookUpModel()
            {
                Id=22,Name=LangaugeResource.AttentionRequest,icon="Attention.svg",PageName="AttentionRequestView"
            },
              new LookUpModel()
            {
                Id=23,Name=LangaugeResource.SalaryIncreaseRequest,icon="Salary-Increase.svg",PageName="SalaryIncreaserRequestView"
            },
             new LookUpModel()
            {
                Id=24,Name=LangaugeResource.OverTimeRequest,icon="Over-Time.svg",PageName="OverTimeRequest"
            },
                new LookUpModel()
            {
                Id=25,Name=LangaugeResource.SalaryAdvance,icon="Salary-Advance.svg",PageName="SalaryAdvanceRequestView"
            },
             new LookUpModel()
            {
                Id=26,Name=LangaugeResource.TerminationRequest,icon="Termination.svg",PageName="TerminationRequestView"
            },
              new LookUpModel()
            {
                Id=27,Name=LangaugeResource.EmployeeTransferRequest,icon="EmployeeTransfer.svg",PageName="EmployeeRequests"
            },
             new LookUpModel()
            {
                Id=28,Name=LangaugeResource.TransferSponsorshipRequest,icon="Transfer-Sponsorship.svg",PageName="TransferSponsorShipRequestView"
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
            containerRegistry.RegisterForNavigation<CustodyRequests, CustodyRequestsViewModel>();
            containerRegistry.RegisterForNavigation<ResignationRequests, ResignationRequestViewModel>();
            containerRegistry.RegisterForNavigation<SalleryTransferRequest, SalleryTransferRequestVIewModel>();
            containerRegistry.RegisterForNavigation<LetterRequests, LettersViewModel>();
            containerRegistry.RegisterForNavigation<BusinessCardRequest, BuissnessCardRequestViewModel>();
            containerRegistry.RegisterForNavigation<EmailRequests, EmailRequestsViewModel>();
            containerRegistry.RegisterForNavigation<TicketCashRequestView, TicketCashRequestViewModel>();
            containerRegistry.RegisterForNavigation<PermissionRequest, PermissionRequestsViewModel>();
            containerRegistry.RegisterForNavigation<BusinessTravelRequestView, BusinessTravelRequestViewModel>();
            containerRegistry.RegisterForNavigation<BAckFromVacationRequest, BAckFromVacationRequestViewModel>();
            containerRegistry.RegisterForNavigation<LegalAdviceRequesView, LegalAdviceRequesViewModel>();
            containerRegistry.RegisterForNavigation<FinancialRequestView, FinancialRequestViewModel>();
            containerRegistry.RegisterForNavigation<ExitReEntryVISARequest, ExitReEntryVISARequestViewModel>();
            containerRegistry.RegisterForNavigation<RenewalPassportRequestView, RenewalPassportRequestViewModel>();
            containerRegistry.RegisterForNavigation<SalaryIncreaserRequestView, SalaryIncreaserRequestViewModel>();
            containerRegistry.RegisterForNavigation<SalaryAdvanceRequestView, SalaryAdvanceRequestViewModel>();
            containerRegistry.RegisterForNavigation<LoanRequestsView, LoanRequestsViewModel>();
            containerRegistry.RegisterForNavigation<TerminationRequestView, TerminationRequestViewModel>();
            containerRegistry.RegisterForNavigation<EmployeeTransferRequestView, EmployeeTransferrequestViewModel>();
            containerRegistry.RegisterForNavigation<AttentionRequestView, AttentionRequestViewModel>();
            containerRegistry.RegisterForNavigation<RenewalResidenceRequestView, RenewalResidenceRequestViewModel>();
            containerRegistry.RegisterForNavigation<OverTimeRequestView, OverTimeRequestViewModel>();
            containerRegistry.RegisterForNavigation<PendingRequestsView, PendingRequestsViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.OverTimeRequestDetails, OverTimeRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.BuisnessTravelRequestDetails, BusinessTravelRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.AccessCardRequestDetails, AccessCardRequestLstViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.CustodyRequestDetail, CustodyRequestsViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.MedicalInsuranceDetail, MedicalInsuranceViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.BackFromVacationDetails, BAckFromVacationRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.BuissnessCardRequestDetail,BuissnessCardRequestViewModel >();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.EmployeeTransferRequestDetail, EmployeeTransferrequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.ExitReentryVisaDetail, ExitReEntryVISARequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.FinancialrequestDetail,FinancialRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.LegalAdviceRequestDetail, LegalAdviceRequesViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.LetterRequestDetail, LettersViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.LoanRequestDetail, LoanRequestsViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.PermissionRequestDetail, PermissionRequestsViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.RenewalPassportRequestDetail, RenewalPassportRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.RenewalResidentDetail, RenewalResidenceRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.ResignationRequestDetail, ResignationRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.SallaryAdvanceRequestDetail, SalaryAdvanceRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.SalleryIncreaseRequestDetails, SalaryIncreaserRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.SalleryTransferRequestDetail, SalleryTransferRequestVIewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.TerminationRequestDetail, TerminationRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.TicketCashRequestDetail, TicketCashRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.TransferSponserShipDetail, TransferSponsorShipRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.AttentionRequestDetail, AttentionRequestViewModel>();
            containerRegistry.RegisterForNavigation<HrApp.View.Requests.DetailsView.EmailRequestDetail, EmailRequestsViewModel>();

            containerRegistry.RegisterForNavigation<TransferSponsorShipRequestView, TransferSponsorShipRequestViewModel>();

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
            containerRegistry.RegisterForNavigation<OnlineServicesView, OnlineServicesMenuViewModel>();
            containerRegistry.RegisterForNavigation<AccessCardRequestLstView, AccessCardRequestLstViewModel>();
            containerRegistry.RegisterForNavigation<MedicalInsuranceView, MedicalInsuranceViewModel>();

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
