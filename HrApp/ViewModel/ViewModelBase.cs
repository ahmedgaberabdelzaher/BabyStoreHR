using HrApp.Model;
using HrApp.Resources;
using HrApp.Services.Interface;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Plugin.Multilingual;
using Plugin.XamarinFormsSaveOpenPDFPackage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HrApp.ViewModel
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        public static HubConnection connection;
        public string stringrequstapproved = "Request Approved";
        public string stringrequstrejected = "Request Rejected";

        private string _newmessage = "livechaticon.png";

        public string newmessage
        {
            get { return _newmessage; }
            set { _newmessage = value; RaisePropertyChanged(); }
        }
        private string _department;

        public string department
        {
            get { return _department; }
            set { _department = value; RaisePropertyChanged(); }
        }
        static double _DeviceWidth;

        public double DeviceWidth
        {
            get { _DeviceWidth = DeviceDisplay.MainDisplayInfo.Width; return _DeviceWidth; }
            set { _DeviceWidth = value; RaisePropertyChanged(); }
        }
        static double _DeviceHeight;

        public double DeviceHeight
        {
            get { _DeviceHeight = DeviceDisplay.MainDisplayInfo.Height; return _DeviceHeight; }
            set { _DeviceHeight = value; RaisePropertyChanged(); }
        }

        private int _deleteallow = 0;

        public int deleteallow
        {
            get { return _deleteallow; }
            set { _deleteallow = value; RaisePropertyChanged(); }
        }
        private DateTime _DateTimeToday = DateTime.Now;

        public DateTime DateTimeToday
        {
            get { return _DateTimeToday; }
            set { _DateTimeToday = value; }
        }

        static string _UserImage = "";

        public string UserImage
        {
            get { return _UserImage; }
            set { _UserImage = value; RaisePropertyChanged(); }
        }
        public string ServiceRequestNote { get; set; } = "You will be notified for your request approval";
        public string SendRequestText { get; set; } = "Submit Request";
        static int _NotificationCount = 0;

        bool _DaysIenbled = false;
        public bool DaysIenbled { get { return _DaysIenbled; } set { _DaysIenbled = value; RaisePropertyChanged(); } }

        static StuffRecord _user;

        public StuffRecord User { get { return _user; } set { _user = value; RaisePropertyChanged(); } }
        bool isEmployee;
        public bool IsEmployee { get { return isEmployee; } set { isEmployee = value; Isreadeonly = !value; DaysIenbled = value; RaisePropertyChanged(); } }
        private bool _Isreadeonly = true;

        public bool Isreadeonly
        {
            get { return _Isreadeonly; }
            set { _Isreadeonly = value; RaisePropertyChanged(); }
        }
        private DateTime _reqDate;

        public DateTime reqDate
        {
            get { return _reqDate; }
            set { _reqDate = value; RaisePropertyChanged(); }
        }
        private string _StuffFirstNameLastName;

        public string StuffFirstNameLastName
        {
            get { return _StuffFirstNameLastName; }
            set { _StuffFirstNameLastName = value; RaisePropertyChanged(); }
        }

        private object _RefNO;

        public object RefNO
        {
            get { return _RefNO; }
            set { _RefNO = value; RaisePropertyChanged(); }
        }


        private DateTime _DateNow = DateTime.Now.AddDays(-30);

        public DateTime MiniDateNow
        {
            get { return _DateNow; }
            set { _DateNow = value; RaisePropertyChanged(); }
        }

        private bool _Isnotification;

        public bool Isnotification
        {
            get { return _Isnotification; }
            set { _Isnotification = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<NotificationModel> _NotificationList = new ObservableCollection<NotificationModel>();



        public ObservableCollection<NotificationModel> NotificationList
        {
            get { return _NotificationList; }
            set { _NotificationList = value; RaisePropertyChanged(); }
        }
        public async Task GetNotificationList(INotificationServices _NotServices)
        {
            IsLoading = true;
            try
            {
                var resp = await _NotServices.GetNotificationList();
                if (resp.Item2)
                {
                    NotificationCount = resp.Item1.Count;
                    if (NotificationCount > 0)
                    { Isnotification = true; }
                    else
                    {
                        Isnotification = false;
                    }

                    NotificationList = resp.Item1;
                }
            }
            catch { }
            finally
            {
                IsLoading = false;
            }
        }
        public int NotificationCount { get { return _NotificationCount; } set { _NotificationCount = value; RaisePropertyChanged(); } }
        ObservableCollection<HrOfficersModel> empLst = new ObservableCollection<HrOfficersModel>();
        public ObservableCollection<HrOfficersModel> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        public DelegateCommand MyProfileCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    await NavigationService.NavigateAsync("Profile");
                });

            }
        }

        public DelegateCommand<string> GoNewPageCommand
        {
            get
            {
                return new DelegateCommand<string>(async (e) =>
                {
                    await NavigationService.NavigateAsync(e);
                });

            }
        }

        protected DelegateCommand NavigateToDetails(int taskid, int id, object SelectedItem)
        {
            return new DelegateCommand(async () =>
            {
                if (SelectedItem != null)
                {
                    Preferences.Set("TaskId", taskid);
                    Preferences.Set("CorrespondenceId", id);

                    await NavigationService.NavigateAsync("Details");
                    SelectedItem = null;
                }

            });
        }
        string userName;
        string pageTitle;
        public string UserName { get { return Preferences.Get("UserName", "Me"); } set { userName = value; RaisePropertyChanged(); } }
        public string PageTitle { get { return pageTitle; } set { pageTitle = value; RaisePropertyChanged(); } }


        string pageDesc;
        public string PageDesc { get { return pageDesc; } set { pageDesc = value; RaisePropertyChanged(); } }


        public DelegateCommand GoToNotificationCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await NavigationService.NavigateAsync("Notifications");
                });
            }
        }

        private int _Ballance;

        public int Ballance
        {
            get { return _Ballance; }
            set { _Ballance = value; RaisePropertyChanged(); }
        }

        //  public int Ballance { get { return Preferences.Get("Ballance", 0); } }

        FlowDirection _FlowDirection;
        public FlowDirection FlowDirection { get { return _FlowDirection; } set { _FlowDirection = value; RaisePropertyChanged(); } }
        string _LanguageId;

        public string LanguageId
        {
            get { return _LanguageId; }
            set
            {
                SetProperty(ref _LanguageId, value);
                RaisePropertyChanged();
            }
        }

        public async Task openpdfAsync(string url)
        {
            isLoading = true;

            try
            {
                var filename = url.Split('/')[url.Split('/').Length - 1].Replace(".html", "");

                var parameters = new NavigationParameters();
                parameters.Add("URL", url);
                parameters.Add("PDFNAME", filename);
                await NavigationService.NavigateAsync("PdfViwerControler", parameters);

                /*    var httpClient = new HttpClient();

                    var stream = await httpClient.GetStreamAsync(url);

                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        var filename = url.Split('/')[url.Split('/').Length - 1];
                        await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView(filename, "application/pdf", memoryStream, PDFOpenContext.InApp);
                    }*/
            }
            catch (Exception ex)
            {
                await DialogService.DisplayAlertAsync("Error", ex.Message, "Cancel");
            }
            finally
            {
                isLoading = false;
            }
        }
        public DelegateCommand GoBackCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await NavigationService.GoBackAsync();
                });
            }
        }
        public DelegateCommand GoHome
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await NavigationService.NavigateAsync("/Home");
                });
            }
        }



        public DelegateCommand ShowSearchCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsSearchVisible = true;
                });
            }
        }

        public DelegateCommand HideSearchCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsSearchVisible = false;
                });
            }
        }

        bool isLoading = false;

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                SetProperty(ref isLoading, value);
            }
        }

        bool noData = false;

        public bool NoData
        {
            get { return noData; }
            set
            {
                SetProperty(ref noData, value);
            }
        }



        bool iSearchVisible = false;

        public bool IsSearchVisible
        {
            get { return iSearchVisible; }
            set
            {
                SetProperty(ref iSearchVisible, value);
            }
        }
        public DelegateCommand SignOutCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    //await _microsoftAuthService.OnSignOutAsync();
                    string token = Preferences.Get("FCMToken", "");
                    bool deviceType = Preferences.Get("HCM", true);
                    Preferences.Clear();
                    SecureStorage.Remove("user");
                    SecureStorage.Remove("User");
                    User = new StuffRecord { };
                    Preferences.Set("FCMToken",token);
                    Preferences.Set("HCM", deviceType);
                    SecureStorage.Remove("passwerd");
                    await NavigationService.NavigateAsync("HrApp:///NavigationPage/LogIn");
                    // await NavigationService.NavigateAsync("../IntroPAge");
                });


                //  return NavigateToDetails(SelectedItem==null?0: SelectedItem.taskId, SelectedItem==null?0: SelectedItem.id, SelectedItem);



            }
        }



        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService DialogService { get; private set; }
        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand NavigateToHomeCommand { get; set; }
        public DelegateCommand NavigateToInboxCommand { get; set; }
        public DelegateCommand NavigateToOutboxCommand { get; set; }
        public DelegateCommand NavigateToCalenderCommand { get; set; }

        public DelegateCommand<string> SerachCommand { get; set; }


        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public CultureInfo Culture { get; set; }

        public ViewModelBase(INavigationService navigationService, IPageDialogService dialogService)
        {
            Intilize(navigationService, dialogService);

            Console.WriteLine("ViewModel......................................" + this.GetType().Name);
        }

         public void ShowMessage(int newMessage)
        {
          //  if (newMessage == 1)
           // {
                newmessage = "homelivechatnewmsgicon.png";
          //  }
        }
        private void Intilize(INavigationService navigationService, IPageDialogService dialogService)
        {
            newmessage = "livechaticon.png";

            Culture = new CultureInfo(Preferences.Get("LanguageId", "en"));
            if (Culture.Name.Contains("ar"))
            {
                LanguageId = "2";
            }
            else
            {
                LanguageId = "1";

            }
            LangaugeResource.Culture = Culture;
            CrossMultilingual.Current.CurrentCultureInfo = Culture;

            FlowDirection = CrossMultilingual.Current.CurrentCultureInfo.TextInfo.IsRightToLeft ?
             FlowDirection.RightToLeft :
             FlowDirection.LeftToRight;
            DialogService = dialogService;
            NavigationService = navigationService;
            NavigateToHomeCommand = new DelegateCommand(async () => { await NavigateToHome(); });
            NavigateToInboxCommand = new DelegateCommand(async () => { await NavigateToInbox(); });
            NavigateToOutboxCommand = new DelegateCommand(async () => { await NavigateToOutbox(); });
            NavigateToCalenderCommand = new DelegateCommand(async () => { await NavigateToCalender(); });

            User = JsonConvert.DeserializeObject<StuffRecord>(Preferences.Get("User", ""));
            Ballance = Preferences.Get("Ballance", 0);

            if (User != null && !String.IsNullOrEmpty(User.photograph))
            {
                UserImage = User.photograph;
            }

        }

        private async Task NavigateToHome()
        {
            await NavigationService.NavigateAsync("../DashBoard");
        }

        private async Task NavigateToInbox()
        {
            await NavigationService.NavigateAsync("../Inbox");
        }
        private async Task NavigateToOutbox()
        {
            await NavigationService.NavigateAsync("../OutBox");
        }
        private async Task NavigateToCalender()
        {
            await NavigationService.NavigateAsync("../CalenderPage");
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
           // newmessage= "livechaticon.png";
        }

        public virtual void Destroy()
        {

        }
    }
}
