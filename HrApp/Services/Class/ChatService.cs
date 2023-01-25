using HrApp.Model;
using HrApp.Services.Interface;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using HrApp.ViewModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using HrApp.Model.ChatModels;
using HrApp.Helpers;
using System.Net.Http;

namespace HrApp.Services.Class
{
    public class ChatService : IChatService
    {

      
        public ChatService()
        {
            var url = $"{App.BaseUrl}chathub";
               ViewModelBase.connection = new HubConnectionBuilder()
                       .WithUrl(url)
                       .WithAutomaticReconnect()
                       .Build();
            
        }
        public async Task<bool> Connect(string ConID)
        {
          
            try
            {
               /* ViewModelBase.connection.On<string, string, int>("ReceiveMessage", (user, message, conversationId) => OnReceiveMessage(user, message, conversationId));
                ViewModelBase.connection.On<string, List<ConversationReplyModel>>("ConnectionUpdated", (user, conversationReplies) => OnCraeteOrUpdateConnection(user, conversationReplies));
*/
                // receive a message from the hub

                var T = ViewModelBase.connection.StartAsync();
                for (int i = 0; i < 25; i++)
                {
                 await Task.Delay(1000);
                    if (T.IsCompleted)
                    { break; }
                }


                if (T.IsCompleted)
                {
                    await ViewModelBase.connection.InvokeAsync("CraeteOrUpdateConnection", Preferences.Get("userId", 0).ToString(), Convert.ToInt32(ConID));
                }
                return T.IsCompleted;
            }
            catch (Exception ex)
            {
                
             return false;
            }
           
        }
       

        public async Task SendMessage(string ConID, string message,byte [] FileContent ,string FileName,bool isOfficer=false)
        {
            try
            {
                //   await connection.InvokeAsync("SendMessage", "12036", "message from " + "12036", Convert.ToInt32(3));
                if (isOfficer)
                {
                    await ViewModelBase.connection.InvokeAsync("SendMessage", Preferences.Get("userId", 0).ToString(),ConID, message, 0, FileContent, FileName);
                }
                else
                await ViewModelBase.connection.InvokeAsync("SendMessage", Preferences.Get("userId", 0).ToString(),"", message, Convert.ToInt32(ConID), FileContent, FileName);



            }
            catch (Exception ex)
            { 
            
            }
        }


        public async Task Chatreadet(string ConID)
        {
            try
            {
            var userid =    Preferences.Get("userId", 0).ToString();
                await ViewModelBase.connection.InvokeAsync("UpdateStatus", userid, Convert.ToInt32(ConID));
            }
            catch (Exception ex)
            {

            }
        }
        public ConversationModel OnReceiveMessage(string user, string message, int conversationId)
        {

          //  Console.WriteLine($"{user}: conversationId: {conversationId} and {message}");
            var Model= new ConversationModel { user=user,message=message,conversationId=conversationId};
            return Model;
        }

        public  List<ConversationReplyModel>OnCraeteOrUpdateConnection(string user, List<ConversationReplyModel> conversationReplies)
        {
            //Console.WriteLine($"Conncted user: {user}: conversationId: {conversationId} and {message}");
            Console.WriteLine($"Conncted user: {user}");
            if (conversationReplies != null)
            {

                return conversationReplies;

                /*  foreach (ConversationReplyModel conversationReplie in conversationReplies)
                  {
                      Console.WriteLine($"From: {conversationReplie.SenderUserId.ToString()}, Message: {conversationReplie.Content}, DateTime: {conversationReplie.CreationDate.ToString("dd/MM/yyyy hh:mm tt")}");
                  }*/

            }
            else
            {
                return null;
            }
        }
        public Task Disconnect(string userEmail)
        {
            throw new NotImplementedException();
        }
        public void GetReplyes( Action<List<ConversationReplyModel>> conversationReplies)
        {
            ViewModelBase.connection.On("ConnectionUpdated",conversationReplies);

        //    connection.("ConnectionUpdated", (user, conversationReplies) => OnCraeteOrUpdateConnection(user, conversationReplies));

        }
        public void ReceiveMessage(Action<string, string> GetMessageAndUser )
        {
            //  connection.On<string, string, int>("ReceiveMessage", (user, message, conversationId) => OnReceiveMessage(user, message, conversationId));
            ViewModelBase.connection.On("ReceiveMessage", GetMessageAndUser);
          

        }

        public async Task<Tuple<ObservableCollection<GetChatUsers>, bool, string>> GetChatUsresList()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<GetChatUsers>>(App.BaseUrl + $"api/ConversationAPI/GetAllConversations").ConfigureAwait(false);

            return response;
        }
        public async Task<Tuple<bool, string>> GetAgentState()
        {
            var response = await HttpManager.GetAsyncString(App.BaseUrl + $"api/ConversationAPI/isAgentConnected").ConfigureAwait(false);

            return response;
        }
        /*
      /api/ConversationAPI/GetAllConversations/PagingParameterModel
/api/ConversationAPI/GetConversationRepliesByStaffId/PagingParameterModel
/api/ConversationAPI/GetConversationRepliesById/PagingParameterModel
      */
        public async Task<HttpResponseMessage>GetConversationRepliesByStaffId(PagingParameterModel Model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/ConversationAPI/GetConversationRepliesByStaffIdPaging", Model).ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> GetConversationRepliesById(PagingParameterModel Model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/ConversationAPI/GetConversationRepliesByIdPaging", Model).ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> GetAllConversations(PagingParameterModel Model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/ConversationAPI/GetAllConversationsPaging",Model).ConfigureAwait(false);

            return response;
        }

      
    }
}
