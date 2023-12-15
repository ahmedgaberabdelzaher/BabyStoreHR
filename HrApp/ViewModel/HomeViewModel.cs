using System;
using System.Globalization;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using FirebaseNet.Messaging;
using HrApp.Helpers;
using HrApp.Model;
using HrApp.Model.OdooModels;
using HrApp.Resources;
using HrApp.Services.Interface;
using HrApp.View.NewsViews;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Plugin.Multilingual;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HrApp.ViewModel
{
    public class HomeViewModel: ViewModelBase
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

        string checkInTime="--/--";

        public string CheckInTime
        {
            get { return checkInTime; }
            set
            {
                SetProperty(ref checkInTime, value);
            }
        }

        string checkInOuttxt;

        public string CheckInOuttxt
        {
            get { return checkInOuttxt; }
            set
            {
                SetProperty(ref checkInOuttxt, value);
            }
        }

        string checkOuTime = "--/--";

        public string CheckOuTime
        {
            get { return checkOuTime; }
            set
            {
                SetProperty(ref checkOuTime, value);
            }
        }


        string name;

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        string role;

        public string Role
        {
            get { return role; }
            set
            {
                SetProperty(ref role, value);
            }
        }


        bool isCkeckInOrOutVisible;

        public bool IsCkeckInOrOutVisible
        {
            get { return isCkeckInOrOutVisible; }
            set
            {
                SetProperty(ref isCkeckInOrOutVisible, value);
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
  public DelegateCommand ChangeLangaugeCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    IsLoading = true;
                    var currenLang= Preferences.Get("LanguageId", App.defaultLang);
                    if (Culture.Name.Contains("ar"))
                    {
                        Preferences.Set("LanguageId", "en");
                    }
                    else
                    {
                        Preferences.Set("LanguageId", "ar-EG");
                    }
                    Culture = new CultureInfo(Preferences.Get("LanguageId", App.defaultLang));
                    LangaugeResource.Culture = Culture;
                    CrossMultilingual.Current.CurrentCultureInfo = Culture;

                    FlowDirection = CrossMultilingual.Current.CurrentCultureInfo.TextInfo.IsRightToLeft ?
                     FlowDirection.RightToLeft :
                     FlowDirection.LeftToRight;
                    await NavigationService.NavigateAsync("../Home");
                    IsLoading = false;
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


        public DelegateCommand CheckInOutCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SetAttendance();
                });

            }
        }

        private async Task SetAttendance()
        {
            IsLoading = true;
            if (Preferences.Get("IsTodayCheckedIn", false))
            {
               await SenAttendanceData();
                 var CheckInModel = await GetCurrentLocation();
                var checkInTime = Preferences.Get("TodayCheckedInTime", DateTime.Now);
                CheckInTime = checkInTime.ToLongTimeString(); ;
            }
            else
            {
                await SenAttendanceData();
                Preferences.Set("IsTodayCheckedIn", true);
                CheckInOuttxt = LangaugeResource.CheckOut;
                var checkInTime = Preferences.Get("TodayCheckedInTime", DateTime.Now);
                CheckInTime = checkInTime.ToLongTimeString();
                return;
            }
            if (Preferences.Get("IsTodayCheckedOut", false))
            {
               await SenAttendanceData();
                var checkOuTime = Preferences.Get("TodayCheckedOutTime", DateTime.Now);
                CheckOuTime = checkOuTime.ToLongTimeString();
                IsCkeckInOrOutVisible = false; ;
                return;
            }
            else
            {
                Preferences.Set("IsTodayCheckedOut", true);
                var checkOuTime = Preferences.Get("TodayCheckedOutTime", DateTime.Now);
                CheckOuTime = checkOuTime.ToLongTimeString();
                IsCkeckInOrOutVisible = false; ;
                return;
            }
            IsCkeckInOrOutVisible = true;
        }

        public void checkInOutStatus() {
            if (Preferences.Get("IsTodayCheckedIn", false))
            {
               /*System.Globalization.DateTimeFormatInfo DTFormat;
                DTFormat = new System.Globalization.CultureInfo("en-US", false).DateTimeFormat;
                DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                var ex = DateTime.Now.AddSeconds(JsonObject.expires_in).ToString(DTFormat);*/
                if (Preferences.Get("TodayCheckedInTime", DateTimeHelper.DateTimeFormater(DateTime.Now).AddDays(-1)) < DateTimeHelper.DateTimeFormater(DateTime.Now).Date)
                {
                    Preferences.Set("IsTodayCheckedIn", false);
                    Preferences.Set("IsTodayCheckedOut", false);
                    Preferences.Remove("TodayCheckedInTime");
                    Preferences.Remove("TodayCheckedOutTime");
                    CheckInTime = "-- / --";
                    checkOuTime = "-- / --";
                    IsCkeckInOrOutVisible = true;
                    CheckInOuttxt = LangaugeResource.CheckIn;
                }
                else
                {
                    var checkInTime = Preferences.Get("TodayCheckedInTime", DateTimeHelper.DateTimeFormater(DateTime.Now));
                    //CheckInTime = checkInTime.Hour + " / " + checkInTime.Minute;
                    CheckInTime = checkInTime.ToLongTimeString();

                    if (Preferences.Get("IsTodayCheckedOut", false))
                    {
                        var checkOuTime = Preferences.Get("TodayCheckedOutTime", DateTimeHelper.DateTimeFormater(DateTime.Now));
                        // CheckOuTime = checkOuTime.Hour + " / " + checkOuTime.Minute;
                        CheckOuTime = checkOuTime.ToLongTimeString();
                        IsCkeckInOrOutVisible =false;
                    }
                    else
                    {
                        IsCkeckInOrOutVisible = true;
                        CheckInOuttxt = LangaugeResource.CheckOut;
                       
                    }
                }
            }
            else
            {
                IsCkeckInOrOutVisible = true;
                CheckInOuttxt = LangaugeResource.CheckIn;
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
        public HomeViewModel(IChatService chatService,INotificationServices notification, IUserServices userServices ,INavigationService navigationServices, IPageDialogService pageDialogService) : base(navigationServices, pageDialogService)
        {
           // this.chatService = chatService;
            //_Notification = notification;
            _userServices =userServices;
          checkInOutStatus();
            Name=Preferences.Get("UserName", "");
            Role = Preferences.Get("role", "employee");
            if (Preferences.Get("role", "employee") == "employee")
            {
                IsEmployee = true;
            }
            else
            {
                IsManager = true;
            }
            IsHome = true;

            /*ViewModelBase.connection.On<int>("ShowNewMessage", (NewMessage) => ShowMessage(NewMessage));
             chatService.Connect("0");*/




        }

       

        public override async void OnNavigatedFrom(INavigationParameters parameters)
        {
          
            base.OnNavigatedFrom(parameters);
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            newmessage = "livechaticon.png";
            base.OnNavigatedTo(parameters);
          // ViewModelBase.connection.On<int>("ShowNewMessage", (NewMessage) => ShowMessage(NewMessage));
          // await chatService.Connect("0");
          

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
        public DelegateCommand GoToPendingRequestsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    await NavigationService.NavigateAsync(ViewsRoutes.PendingRequestsView);
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

        async Task SenAttendanceData()
        {
            try
            {
                IsLoading = true;
           var attandenceModel=   await  GetCurrentLocation();
                //    var model = new NewUserModel() { Username =this.EmployeeId, Password = this.Password,ConfirmPassword=this.ConfirmPassword, Reset=int.Parse(isreset), PhoneNumber=this.MobileNo};
                var model = new BaseOdoModel<CheckInOutModel>() { jsonrpc = "2.0", @params = attandenceModel };


                var resp = await _userServices.CheckinCheckOut(model);
                if (resp.IsSuccessStatusCode)
                {
                  
                    var content = await resp.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject< OdooResponse<AttendanceData>>(content);
                    var attendence = result.result.data.attendance;
                    if (attendence!=null)
                    {
                        if (attendence.check_in!="false"&& attendence.check_in!=null)
                        {
                            var checkinDate = DateTimeHelper.ConvertStringTodate(attendence.check_in);
                            if (checkinDate.Date == DateTime.Now.Date)
                            {
                                Preferences.Set("TodayCheckedInTime", checkinDate);
                            }
                        }
                        if (attendence.check_out != "false"&& attendence.check_out!=null)
                        {
                            var checkOutDate = DateTimeHelper.ConvertStringTodate(attendence.check_out);
                            if (checkOutDate.Date==DateTime.Now.Date)
                            {
                            Preferences.Set("TodayCheckedOutTime", DateTime.Now);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await SecureStorage.SetAsync("user", ex.Message);
                IsLoading = false;
            }
            finally
            {
                IsLoading = false;
            }

        }



        CancellationTokenSource cts;
        async Task<CheckInOutModel> GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    var checkInOutModel = new CheckInOutModel() { employee_id=Preferences.Get("userId", 0), latitude=location.Latitude,longtitue=location.Longitude };
                    return checkInOutModel;
                }
                return new CheckInOutModel() { employee_id = Preferences.Get("userId", 0) };

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                return new CheckInOutModel() { employee_id = Preferences.Get("userId", 0)};
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DialogService.DisplayAlertAsync("", "Please open GPS", "Ok");
                return new CheckInOutModel() { employee_id = Preferences.Get("userId", 0) };
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                await DialogService.DisplayAlertAsync("", "Please give GPS permission", "Ok");
                return new CheckInOutModel() { employee_id = Preferences.Get("userId", 0) };
                // Handle permission exception
            }
            catch (Exception ex)
            {
                return new CheckInOutModel() { employee_id = Preferences.Get("userId", 0) };
                // Unable to get location
            }
        }

    }
}
