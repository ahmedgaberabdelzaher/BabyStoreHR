
using HrApp.Model;
using HrApp.Model.NewsModel;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace HrApp.ViewModel
{
   public class NotificationViewModel :ViewModelBase
    {

        List<KeyValuePair<string, int>> PagesKey;

      

        public async Task GetNotificationList(INotificationServices _NotServices)
        {
            NotificationCount = 0;
            NotificationList.Clear();
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

        public Command<NotificationModel> NotifiTabbed { get; set; }

        private int _NotificationCount = 0;

        private bool _NotiISopend = false;

        public bool NotiISopend
        {
            get { return _NotiISopend; }
            set
            {
                _NotiISopend = value; RaisePropertyChanged();
            }
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
        public ICommand NotifiCationCommand => new Command(async (o) => {
            if (o!=null)
            {

         
            PancakeView pancake = (PancakeView)o;
            if (NotiISopend)
            {

                await pancake.TranslateTo(0, 800, 400);
                NotiISopend = !NotiISopend;

            }
            else
            {
                NotiISopend = !NotiISopend;
                await Task.Delay(100);

                await pancake.TranslateTo(0, 0, 400);

            }
            }

        });



        INotificationServices _NotServices;
        public NotificationViewModel(INotificationServices NotServices , INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _NotServices = NotServices;
            NotifiTabbed = new Command<NotificationModel>(NavigateTarget);
           
            PagesKey =   new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("LeaveRequestDetails", 1),
                new KeyValuePair<string, int>("ResumtionLeaveRequest", 2),
                new KeyValuePair<string, int>("EncashmentLeave", 3),
                new KeyValuePair<string, int>("BreastfeedingNewRequest", 4),
                new KeyValuePair<string, int>("CertificateRequest", 5),
                new KeyValuePair<string, int>("OverTimeDetails", 6),
                new KeyValuePair<string, int>("PermisionToLeaveNewRequest", 7),
                new KeyValuePair<string, int>("StcSubscription", 8),
                new KeyValuePair<string, int>("NursesOvertime", 9),



            };


        }


        private async void NavigateTarget(NotificationModel obj)
        {
            try
            {

                var page = PagesKey.Where(x => x.Value == obj.requestTypes).ToList();
                if (obj.notificationType == 0)
                {
                    var navParameters = new NavigationParameters();
                    navParameters.Add("List", 1);
                    navParameters.Add("NotifiRequstID", obj.requestId.ToString());
                    navParameters.Add("IsFromManager", "1");
                    await NavigationService.NavigateAsync(page[0].Key, navParameters);

                }
                else
                {
                 
                    var navParameters = new NavigationParameters();
                    navParameters.Add("NotifiRequstID", obj.requestId.ToString());                  
                    await NavigationService.NavigateAsync(page[0].Key, navParameters);
                    var resp = _NotServices.HideNotification(obj.id);
                }
                // await NavigationService.NavigateAsync(page[0].Key, Parameters, useModalNavigation: true, true);
            }
            catch
            (Exception ex)
            { 
            
            }

        }

        public async override  void Initialize(INavigationParameters parameters)
        {
            await GetNotificationList(_NotServices);
            base.Initialize(parameters);    
        }
        public async override void OnNavigatedFrom(INavigationParameters parameters)
        {
          // await  GetNotificationList(_NotServices);

       //     NotiISopend = false;
          //  base.OnNavigatedFrom(parameters);
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {

            base.OnNavigatedTo(parameters);
            try
            {
               // string date = "14/03/44 07:05:45";
                var ex = await SecureStorage.GetAsync("AccessTokenexpires");
                if (DateTime.Parse(ex) < DateTime.Now.AddMinutes(-1))
                {
                    await NavigationService.NavigateAsync("HrApp:///NavigationPage/LogIn");

                }
            }
            catch(Exception e)
            {
               // await NavigationService.NavigateAsync("HrApp:///NavigationPage/LogIn");

            }
            await GetNotificationList(_NotServices);

         //   NotiISopend = false;
        }


    }
}
