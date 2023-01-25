using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using HrApp.Model;

namespace HrApp.Services.Interface
{
    public interface ILeaveServices
    {

        Task<HttpResponseMessage> BreastDelete(int LeaveId);
        Task<HttpResponseMessage> StcSubscriptionDelete(int LeaveId);
        Task<HttpResponseMessage> CertificateDelete(int LeaveId);
        Task<HttpResponseMessage> EncashmentDelete(int LeaveId);
        Task<HttpResponseMessage> ResumptionDelete(int LeaveId);
        Task<HttpResponseMessage> LeaveApprove(int LeaveId, int ASSIGN_TO);
        Task<HttpResponseMessage> LeaveReject(int LeaveId);
        Task<Tuple<ObservableCollection<StcTyps>, bool, string>> GetTypesOfServices();
        Task<HttpResponseMessage> LeaveDelete(int LeaveId);
    //    Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeaveRequests(int LeaveCode, string endPoint);
        Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeaveRequests( string endPoint);

        Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeaveByID(string ID);
        Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeaveRequestsByEmp();

        Task<HttpResponseMessage> NewResupmisionLeave(LeaveResumptionRequestModel model);
        Task<Tuple<ObservableCollection<LeaveResumtionsModel>, bool, string>> GetResumptionsLeaveRequests(string endPoint);
        Task<Tuple<ObservableCollection<LeaveResumtionsModel>, bool, string>> GetResumptionsByID(string ID);
        Task<HttpResponseMessage> LeaveApprove(int LeaveId, int ASSIGN_TO, string endpoint, int Days, string approvedcomm);

        Task<HttpResponseMessage> LeaveApprove(int LeaveId, int ASSIGN_TO, string endpoint, int Days);
        Task<HttpResponseMessage> LeaveApprove(int LeaveId, int ASSIGN_TO, string endpoint);
        Task<HttpResponseMessage> LeaveApprove(int LeaveId,string endpoint);

        Task<HttpResponseMessage> LeaveReject(int LeaveId, string endpoint);
        // https://tmsapp.westeurope.cloudapp.azure.com:4434/HR/api/LeaveEncashmentOperations/GetEncashmentById/{ID}
        // https://tmsapp.westeurope.cloudapp.azure.com:4434/HR/api/EmpLeavesOperations/GetEmpLeavesById/{ID}
        // https://tmsapp.westeurope.cloudapp.azure.com:4434/HR/api/LeaveResumptionOperations/GetResumptionsById/{ID}

        Task<HttpResponseMessage> NewEncashmentLeave(EncashmentLeaveModel model);
        Task<Tuple<ObservableCollection<EncashmentLeaves>, bool, string>> GetEncashmentLeaveRequests(string endPoint);
        Task<Tuple<ObservableCollection<EncashmentLeaves>, bool, string>> GetEncashmentByID(string ID);

        Task<HttpResponseMessage> NewStcSubscriptionRequest(NewStcSubscriptionModel model);
        Task<Tuple<ObservableCollection<StcSubscriptionLStModel>, bool, string>> GetStcRequests(string endPoint);
        Task<Tuple<ObservableCollection<StcSubscriptionLStModel>, bool, string>> GetStcByID(string ID);

        Task<HttpResponseMessage> ApproveStc(int LeaveId, string endpoint);
        Task<Tuple<ObservableCollection<ResumptionTypeModel>, bool, string>> GetResumptionTypes();

    }

}
