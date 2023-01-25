using HrApp.Model;
using HrApp.Services.Interface;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HrApp.ViewModel
{

    public class LiveChatVM : ViewModelBase
    {

       
        public string SickFileName { get; set; }
        public string SickFileExtension { get; set; }

        bool _FristLoad = true;

        public bool FristLoad
        {
            get { return _FristLoad; }
            set { _FristLoad = value; RaisePropertyChanged(); }
        }
        int pagingsize =10;
        int pagenum = 0;
       public bool canLoadmore = false;
         bool _ScrollDown = false;

        public bool ScrollDown
        {
            get { return _ScrollDown; }
            set { _ScrollDown = value; RaisePropertyChanged(); }
        }
         bool _Scrollpaging = false;

        public bool Scrollpaging
        {
            get { return _Scrollpaging; }
            set { _Scrollpaging = value; RaisePropertyChanged(); }
        }
        static bool _AutoScrollDown = false;

        public bool AutoScrollDown
        {
            get { return _AutoScrollDown; }
            set { _AutoScrollDown = value; RaisePropertyChanged(); }
        }

        public byte[] File { get; set; }


        int chatid = 0;
        IChatService _chatService;
        public LiveChatVM(IChatService chatService,INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            _chatService = chatService;
        
            SendMsgCommand = new DelegateCommand(SendMsg);

           
        }
       

        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }


        private List<ConversationReplyModel> messageList;
        public List<ConversationReplyModel> MessagesList
        {
            get => messageList;
            set => SetProperty(ref messageList, value);
        }
        public ICommand SendMsgCommand { get; private set; }

        public DelegateCommand UploadAttatchementCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var opt = new PickOptions()
                    {
                        PickerTitle = "Select Image",
                        // FileTypes = new FilePickerFileType()
                    };
                    var res = await PickFile(opt);
                    if (res != null)
                    {
                        File = ConvertToBase64(res);

                    }
                });
            }
        }
        public byte[] ConvertToBase64(Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);

            return bytes;
            //return new MemoryStream(Encoding.UTF8.GetBytes(base64));
        }
        async Task<Stream> PickFile(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    SickFileName = result.FileName;

                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase) )
                    {
                        var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                        if (result.FileName.EndsWith("pdf"))
                        {
                            SickFileExtension = "pdf";
                        }
                        else
                        {
                            SickFileExtension = "png";
                        }

                        return stream;
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "Only Images  supported", "Ok");
                        return null;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
              
                base.OnNavigatedTo(parameters);
            }
            catch(Exception ex)
            { 
            
            }
        }
        public bool isOfficer = false;
        public override async void Initialize(INavigationParameters parameters)
        {

            //  UserName = parameters.GetValue<string>("UserNameId");
            MessagesList = new List<ConversationReplyModel>();
            try
            {
                if (parameters != null && parameters.Count > 0)
                {
                    if (parameters["ChatID"] != null)
                    {
                        chatid = (int) parameters["ChatID"];
                    }
                    if (parameters["IsOfficer"] != null)
                    {
                        isOfficer = (bool)parameters["IsOfficer"];
                    }

                }
                newmessage = "livechaticon.png";
                IsLoading = true;
                //  _chatService.ReceiveMessage(GetMessage);
              await  con();
               await GetPagingreplysAsync();

                //   await chatService.Connect(UserName);
            }
            catch (System.Exception exp)
            {
                throw;
            }
            finally
            { IsLoading = false; }

        }
        public async Task con()
        {
            ViewModelBase.connection.On<string, string, int, byte[], string, string>("ReceiveMessage2", (user, message, conversationId, FileContent, FileName, SenderDisplayName) => GetMessage(user, message, conversationId, FileContent, FileName, SenderDisplayName));
            ViewModelBase.connection.On<int>("ShowNewMessage", (NewMessage) => ShowMessage(NewMessage));

            await _chatService.Connect(chatid.ToString());
        }
        private async void SendMsg()
        {
            
           
            if (!string.IsNullOrEmpty(Message))
            { IsLoading = true;
                try
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (ViewModelBase.connection.State == HubConnectionState.Connected)
                        {
                            await _chatService.SendMessage(chatid.ToString(), Message, File, SickFileName,isOfficer);
                            GetMessage("local0", Message, 0, File, SickFileName, $"{Preferences.Get("userId", 0).ToString()}-{User.name} {DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")}");

                            Message = string.Empty;
                            File = null;
                            SickFileName = string.Empty;
                            break;
                        }
                        else
                        {
                            await con();
                          await  Task.Delay(1000);
                        }
                    }
                }
                catch (Exception ex)

                { await DialogService.DisplayAlertAsync("Error", ex.Message, "Cancel"); }
                finally
                { IsLoading = false; }

            }
        }

        public  void GetMessage(string userName, string message,int conid, byte[] FileContent, string FileName, string SenderDisplayName)
        {
           

            bool mine = false;
            if (Preferences.Get("userId", 0).ToString() == userName)
            {
                return;
            }if (userName == "local0")
            {
                mine = true;


            }

            AddrealTimeMessage(userName, message, mine,  FileContent,  FileName,SenderDisplayName);
            _chatService.Chatreadet(chatid.ToString());
            if (Preferences.Get("userId", 0).ToString() == userName)
            {
                AutoScrollDown = true;
            }
            else
            { 
             ScrollDown = true;
            }

        }

        /* public void Getreplys(string user,List<ConversationReplyModel> ConversationReplies)
         {
              ConversationReplies.ForEach(i => AddMessage(i.SenderUserId.ToString(), i.Content, Preferences.Get("userId", 0)==i.SenderUserId));
             // AddMessage(userName, message, false);
         }*/
        public async Task GetPagingreplysAsync()
        {
            try
            {
                IsLoading = true;
                PagingParameterModel model;
               HttpResponseMessage response;
                // PagingParameterModel model = new PagingParameterModel { staffId = Preferences.Get("userId", 0), conversationId = int.Parse(chatid.ToString()),pageNumber=++pagenum,pageSize=pagingsize };
                if (isOfficer)
                {
                 model = new PagingParameterModel { staffId =chatid, conversationId = 0, pageNumber = ++pagenum, pageSize = pagingsize };

                }
                else
                 model = new PagingParameterModel { staffId = Preferences.Get("userId", 0), conversationId = int.Parse(chatid.ToString()),pageNumber=++pagenum,pageSize=pagingsize };

                if (model.conversationId != null && model.conversationId != 0)
                {  response = await _chatService.GetConversationRepliesById(model); }
                else {  response = await _chatService.GetConversationRepliesByStaffId(model); }
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();
                        var JsonObject = JsonConvert.DeserializeObject<List<ConversationReplyModel>>(responseJson);
                        //  Tuple.Create(JsonObject, true, "");
                        if (JsonObject != null)
                        {
                            JsonObject.ForEach(i => AddMessage(i.SenderUserId.ToString(), i.Content, Preferences.Get("userId", 0) == i.SenderUserId,i.FileContent,i.FileName,i.SenderDisplayName));
                            if (JsonObject.Count < pagingsize)
                            {
                                canLoadmore = false;
                            }
                            else
                            {
                                canLoadmore=true;
                            }
                           
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
           // ConversationReplies.ForEach(i => AddMessage(i.SenderUserId.ToString(), i.Content, Preferences.Get("userId", 0) == i.SenderUserId));
            // AddMessage(userName, message, false);
        }

        private void AddMessage(string userName, string message, bool isOwner,byte [] FileContent , string FileName, string senderDisplayName)
        {
            var tempList = MessagesList.ToList();
            tempList.Add(new ConversationReplyModel { IsOwnerMessage = isOwner,  Content = message, FileContent = File, FileName = FileName,SenderDisplayName=senderDisplayName });
            MessagesList = new List<ConversationReplyModel>(tempList);
            Message = string.Empty;

        }
        private void AddrealTimeMessage(string userName, string message, bool isOwner, byte[] FileContent, string FileName ,string senderDisplayName)
        {
            var tempList = MessagesList.ToList();

            tempList.Insert(0,new ConversationReplyModel { IsOwnerMessage = isOwner, Content = message,FileContent=FileContent,FileName=FileName, SenderDisplayName = senderDisplayName });
            MessagesList = new List<ConversationReplyModel>(tempList);
            Message = string.Empty;

        }

    }



}
