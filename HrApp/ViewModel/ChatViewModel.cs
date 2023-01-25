using HrApp.Model;
using HrApp.Model.ChatModels;
using HrApp.Services.Class;
using HrApp.Services.Interface;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HrApp.ViewModel
{
    public class ChatViewModel:ViewModelBase
    {
        // SelectedChat
        int staffId;
        public int  StaffId { get { return staffId; } set { staffId = value; RaisePropertyChanged(); } }
        int pagingsize = 7;
        int pagenum = 1;
      public  bool canLoadmore = false;

        public DelegateCommand<ListView> ListChat
        {
            get
            {
                return new DelegateCommand<ListView>( (url) =>
                {
                    try
                    {

                    
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                });

            }
        }

        public DelegateCommand StartChatWithStaffCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {

                       await GetUserById();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                });

            }
        }

        public DelegateCommand<GetChatUsers> SelectedChat
        {
            get
            {
                return new DelegateCommand<GetChatUsers>(async (url) =>
                {
                    try
                    {
                      
                        var parameters = new NavigationParameters();
                        parameters.Add("PageTitle", "LiveChat");
                        parameters.Add("ChatID", url.userOneID);
                       // parameters.Add("ChatID", user.Item1.stafF_ID);
                        parameters.Add("IsOfficer", true);
                        await NavigationService.NavigateAsync("LiveChat", parameters);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                });

            }
        }
        ObservableCollection<GetChatUsers> _UsersLst = new ObservableCollection<GetChatUsers>();
        public ObservableCollection<GetChatUsers> UsersLst { get { return _UsersLst; } set { _UsersLst = value; RaisePropertyChanged(); } }

        IChatService _chatService;
        IUserServices _userServices;
        public ChatViewModel(IChatService chatService, INavigationService navigationService, IPageDialogService dialogService,IUserServices userServices) : base(navigationService, dialogService)
        {
            _userServices = userServices;
            _chatService = chatService;
          //  _chatService.Connect("0");
            //    SendMsgCommand = new DelegateCommand(SendMsg);
        }
        public async override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
          // await LoadMoreAsync();


        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            await LoadMoreAsync();

            base.OnNavigatedTo(parameters);
        }
        public async Task LoadMoreAsync()
        {
            try
            {
                IsLoading = true;
                PagingParameterModel model = new PagingParameterModel { staffId = Preferences.Get("userId", 0), pageNumber = pagenum++, pageSize = pagingsize };
                var response = await _chatService.GetAllConversations(model);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();
                        var JsonObject = JsonConvert.DeserializeObject<ObservableCollection<GetChatUsers>>(responseJson);
                        //  Tuple.Create(JsonObject, true, "");
                        if (JsonObject != null)
                        {
                            if (UsersLst.Count > 0)
                            {
                                JsonObject.ToList().ForEach(i=> UsersLst.Add(i)) ;
                            } else
                            { UsersLst = JsonObject; }
                          
                            if (JsonObject.Count < pagingsize)
                            { canLoadmore = false; }
                            else { canLoadmore = true; }

                        }
                    }
                    catch (Exception ex)
                    { throw ex; }




                }
                else
                {
                    await DialogService.DisplayAlertAsync("Error", response.ReasonPhrase, "Cancel");
                }

                /*  if (resp.Item2)
                  {
                      UsersLst = resp.Item1;
                  }*/
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }
        public async Task GetUserById()
        {
            try
            {
                IsLoading = true;
                if (StaffId>0)
                {
            var user = await _userServices.Getuserinfo(StaffId);
            if (user != null && user.Item2&&user.Item1.stafF_ID!=0)
            {
                    var parameters = new NavigationParameters();
                    parameters.Add("PageTitle", "LiveChat");
                   // parameters.Add("ChatID", user.Item1.stafF_ID);
                        parameters.Add("ChatID", user.Item1.stafF_ID);
                        parameters.Add("IsOfficer", true);

                        await NavigationService.NavigateAsync("LiveChat", parameters);
                        pagenum = 1;
                        UsersLst = new ObservableCollection<GetChatUsers>();
                }
            }
            }
            catch (Exception ex)
            {
                IsLoading = false;
            }
            finally { IsLoading = false; }
            
        }
    }
}
