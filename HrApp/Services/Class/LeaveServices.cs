using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using HrApp.Helpers;
using HrApp.Model;
using HrApp.Model.OdooModels;
using HrApp.Services.Interface;
using Xamarin.Essentials;

namespace HrApp.Services.Class
{
    public class LeaveServices: ILeaveServices
    {
        public async Task<HttpResponseMessage> BreastDelete(int LeaveId)
        {

            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/BreastfeedingRequestOperations/RemoveBreast/{LeaveId}",new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> CertificateDelete(int LeaveId)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/CertificatesOperations/RemoveCertificate/{LeaveId}", new { }).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> StcSubscriptionDelete(int LeaveId)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/StcSubscriptionOperations/RemoveSubscription/{LeaveId}", new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> EncashmentDelete(int LeaveId)
        {

            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/LeaveEncashmentOperations/RemoveEncashment/{LeaveId}", new { }).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> LeaveApprove(int LeaveId,int ASSIGN_TO)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/EmpLeavesOperations/LeaveApprove/{LeaveId}/{ASSIGN_TO}/{Preferences.Get("userId",0)}", new { }).ConfigureAwait(false);
            return response;
        }
       
        public async Task<HttpResponseMessage> LeaveReject(int LeaveId)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/EmpLeavesOperations/LeaveReject/{LeaveId}", new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeaveRequests(string endPoint)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<LeavesModel>>(App.BaseUrl + $"api/EmpLeavesOperations/{endPoint}").ConfigureAwait(false);

            return response;
        }
       /* public async Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeaveRequests(int LeaveCode, string endPoint)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<LeavesModel>>(App.BaseUrl + $"api/EmpLeavesOperations/{endPoint}/{LeaveCode}").ConfigureAwait(false);

            return response;
        }*/
        public async Task<Tuple<ObservableCollection<StcTyps>, bool, string>> GetTypesOfServices()

        {
            var response = await HttpManager.GetAsync<ObservableCollection<StcTyps>>(App.BaseUrl + $"api/CommonServices/GetTypesOfServices").ConfigureAwait(false);

            return response;
        }
        public async Task<HttpResponseMessage> NewResupmisionLeave(LeaveResumptionRequestModel model)
        {
            //api/LeaveResumptionOperations/GetResumptionsByStuffId/111111
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/LeaveResumptionOperations/AddNewResumptions", model).ConfigureAwait(false);
            return response;
        }
        //ToDo EncashmentApprove edit
        public async Task<HttpResponseMessage> EncashmentApprove(int LeaveId, int ASSIGN_TO,int Days)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/EmpLeavesOperations/LeaveApprove/{LeaveId}/{ASSIGN_TO}/{Preferences.Get("userId", 0)}/{Days}", new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> NewEncashmentLeave(EncashmentLeaveModel model)
        {
            //api/LeaveResumptionOperations/GetResumptionsByStuffId/111111
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/LeaveEncashmentOperations/AddNewEncashment", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<ObservableCollection<EncashmentLeaves>, bool, string>> GetEncashmentLeaveRequests(string endPoint)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<EncashmentLeaves>>(App.BaseUrl + $"api/LeaveEncashmentOperations/{endPoint}").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<LeaveResumtionsModel>, bool, string>> GetResumptionsLeaveRequests(string endPoint)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<LeaveResumtionsModel>>(App.BaseUrl + $"api/LeaveResumptionOperations/{endPoint}").ConfigureAwait(false);

            return response;
        }
        public async Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeaveRequestsByEmp()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<LeavesModel>>(App.BaseUrl + $"api/LeaveResumptionOperations/GetActiveLeaves/{Preferences.Get("userId",0)}").ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> LeaveApprove(int LeaveId, int ASSIGN_TO,string endpoint,int Days)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/{endpoint}/{LeaveId}/{ASSIGN_TO}/{Preferences.Get("userId", 0)}/{Days}", new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> LeaveApprove(int LeaveId, int ASSIGN_TO, string endpoint)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/{endpoint}/{LeaveId}/{ASSIGN_TO}/{Preferences.Get("userId", 0)}/", new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> LeaveApprove(int LeaveId, string endpoint)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/{endpoint}/{LeaveId}/{Preferences.Get("userId", 0)}/", new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> LeaveApprove(int LeaveId, int ASSIGN_TO, string endpoint, int Days, string approvedcomm)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/{endpoint}/{LeaveId}/{ASSIGN_TO}/{Preferences.Get("userId", 0)}/{Days}/{approvedcomm}", new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> ApproveStc(int LeaveId,string endpoint)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/{endpoint}/{LeaveId}/{Preferences.Get("userId", 0)}", new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> LeaveReject(int LeaveId, string endpoint)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/{endpoint}/{LeaveId}", new { }).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> NewStcSubscriptionRequest(NewStcSubscriptionModel model)
        {
            //api/LeaveResumptionOperations/GetResumptionsByStuffId/111111
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/StcSubscriptionOperations/AddNewSubscription", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<ObservableCollection<StcSubscriptionLStModel>, bool, string>> GetStcRequests(string endPoint)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<StcSubscriptionLStModel>>(App.BaseUrl + $"api/StcSubscriptionOperations/{endPoint}").ConfigureAwait(false);

            return response;
        }
         public async Task<Tuple<ObservableCollection<ResumptionTypeModel>, bool, string>> GetResumptionTypes()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<ResumptionTypeModel>>(App.BaseUrl + $"api/LeaveResumptionOperations/GetResumptionTypes").ConfigureAwait(false);

            return response;
        }
        
       
        
        public async Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeaveByID(string ID)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<LeavesModel>>(App.BaseUrl + $"api/EmpLeavesOperations/GetEmpLeavesById/{ID}").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<LeaveResumtionsModel>, bool, string>> GetResumptionsByID(string ID)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<LeaveResumtionsModel>>(App.BaseUrl + $"api/LeaveResumptionOperations/GetResumptionsById/{ID}").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<EncashmentLeaves>, bool, string>> GetEncashmentByID(string ID)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<EncashmentLeaves>>(App.BaseUrl + $"api/LeaveEncashmentOperations/GetEncashmentById/{ID}").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<StcSubscriptionLStModel>, bool, string>> GetStcByID(string ID)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<StcSubscriptionLStModel>>(App.BaseUrl + $"api/StcSubscriptionOperations/GetSubscriptionById/{ID}").ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> ResumptionDelete(int LeaveId)
        {

            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/LeaveResumptionOperations/RemoveResumptions/{LeaveId}", new { }).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> LeaveDelete(int LeaveId)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/EmpLeavesOperations/RemoveEmpLeaves/{LeaveId}",new { }).ConfigureAwait(false);
            return response;
        }

        public async Task<Tuple<OdooResponse<ObservableCollection<LeaveTypesModel>>, bool, string>> GetLeaveTypes()
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<LeaveTypesModel>>>(App.BaseUrl + $"leave_type", new BaseOdoModel<LookUpModel>() { @params=new LookUpModel() { Id = 1, Name = "ESS" } }).ConfigureAwait(false);

            return response;
        }

  public async Task<HttpResponseMessage> SubmitLeaveRequest(BaseOdoModel<LeaveRequestModel> leaveRequestModel)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"leave/create_request",leaveRequestModel).ConfigureAwait(false);
            return response;
        }

        public async Task<Tuple<OdooResponse<ObservableCollection<LeaveRequestsModel>>, bool, string>> GeEmptLeaveRequests(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<LeaveRequestsModel>>>(App.BaseUrl + "leaves", body).ConfigureAwait(false);

            return response;
        }

    }
}
