using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using HrApp.Model;
using HrApp.Model.OnlineServicesModels;

namespace HrApp.Services.Interface
{
    public interface IOnlineServices
    {
        Task<HttpResponseMessage> NewBreatFestRequest(BreastFeedingRequestModel model);
        Task<Tuple<ObservableCollection<BreastFeedingListModel>, bool, string>> GetBreatFestRequest(string endPoint);
        Task<Tuple<ObservableCollection<BreastFeedingListModel>, bool, string>> GetBreatFestByID(string endPoint);
       
      
        Task<HttpResponseMessage> PermissionToLeaveDelete(int LeaveId);


        Task<HttpResponseMessage> NewPermissionToLeave(PermissionToLeaveRequestModel model);
        Task<Tuple<ObservableCollection<PermissionsToLeaveLst>, bool, string>> GetPermitionsToLeaveRequests(string endPoint);
        Task<Tuple<ObservableCollection<PermissionsToLeaveLst>, bool, string>> GetPermitionsToLeaveByID(string ID);

        // https://tmsapp.westeurope.cloudapp.azure.com:
        // /HR/api/CertificatesOperations/GetCertificatesById/{ID}
        // https://tmsapp.westeurope.cloudapp.azure.com:4434/HR/api/PermissionToLeaveOperations/GetPermissionById/{ID}
       //  https://tmsapp.westeurope.cloudapp.azure.com:4434/HR/api/StcSubscriptionOperations/GetBreastById/{ID}

        Task<HttpResponseMessage> NewCertificateRequest(CertificateRequestModel model);
        Task<Tuple<ObservableCollection<CertificateLstModel>, bool, string>> GetCertificateRequests(string endPoint);
        Task<Tuple<ObservableCollection<CertificateLstModel>, bool, string>> GetCertificateByID(string ID);

        Task<Tuple<ObservableCollection<ResumptionTypeModel>, bool, string>> GetCertificatTypes();
        Task<Tuple<ObservableCollection<ResumptionTypeModel>, bool, string>> GetBankTypes();
        Task<Tuple<OnlineServiceMenuModel, bool, string>> GetOnlineServicesLst(OnlineServiceMenuModel model);
    }
}
