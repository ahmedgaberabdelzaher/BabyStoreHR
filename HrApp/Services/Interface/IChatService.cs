using HrApp.Model;
using HrApp.Model.ChatModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Services.Interface
{
    public interface IChatService
    {
     
        Task<bool> Connect(string ConID);
        Task Disconnect(string userEmail);
        Task SendMessage(string ConID, string message, byte[] FileContent, string FileName, bool isOfficer = false);
        Task Chatreadet(string ConID);

        void ReceiveMessage(Action<string, string> GetMessageAndUser );
        //void GetConversationRepliesByStaffId(Action<List<ConversationReplyModel>> ConversationReplies);
        Task<HttpResponseMessage> GetConversationRepliesByStaffId(PagingParameterModel Model);
        Task<HttpResponseMessage> GetConversationRepliesById(PagingParameterModel Model);
        Task<HttpResponseMessage> GetAllConversations(PagingParameterModel Model);

        void GetReplyes(Action<List<ConversationReplyModel>>ConversationReplies);

        Task<Tuple<ObservableCollection<GetChatUsers>, bool, string>> GetChatUsresList();

        Task<Tuple<bool, string>> GetAgentState();


    }
}
