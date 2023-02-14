using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using HrApp.Helpers;
using HrApp.Model;
using HrApp.Model.OnlineServicesModels;
using HrApp.Services.Interface;
using Xamarin.Essentials;

namespace HrApp.Services.Class
{
    public class OnlineServices : IOnlineServices
    {
        public async Task<HttpResponseMessage> NewBreatFestRequest(BreastFeedingRequestModel model)
        {
            //api/LeaveResumptionOperations/GetResumptionsByStuffId/111111
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/BreastfeedingRequestOperations/AddNewBreast", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<ObservableCollection<BreastFeedingListModel>, bool, string>> GetBreatFestRequest(string endPoint)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<BreastFeedingListModel>>(App.BaseUrl + $"api/BreastfeedingRequestOperations/{endPoint}").ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> NewPermissionToLeave(PermissionToLeaveRequestModel model)
        {
            //api/LeaveResumptionOperations/GetResumptionsByStuffId/111111
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/PermissionToLeaveOperations/AddNewPermission", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<ObservableCollection<PermissionsToLeaveLst>, bool, string>> GetPermitionsToLeaveRequests(string endPoint)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<PermissionsToLeaveLst>>(App.BaseUrl + $"api/PermissionToLeaveOperations/{endPoint}").ConfigureAwait(false);

            return response;
        }    
            public async Task<HttpResponseMessage> NewCertificateRequest(CertificateRequestModel model)
        {
            //api/LeaveResumptionOperations/GetResumptionsByStuffId/111111
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/CertificatesOperations/AddNewCertificate", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<ObservableCollection<CertificateLstModel>, bool, string>> GetCertificateRequests(string endPoint)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<CertificateLstModel>>(App.BaseUrl + $"api/CertificatesOperations/{endPoint}").ConfigureAwait(false);

            return response;
        }
        public async Task<Tuple<ObservableCollection<ResumptionTypeModel>, bool, string>> GetCertificatTypes()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<ResumptionTypeModel>>(App.BaseUrl + $"api/CertificatesOperations/GetCertificatesTypes").ConfigureAwait(false);

            return response;
        }
        public async Task<Tuple<ObservableCollection<ResumptionTypeModel>, bool, string>> GetBankTypes()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<ResumptionTypeModel>>(App.BaseUrl + $"api/CertificatesOperations/GetBankTypes").ConfigureAwait(false);

            return response;
        }
      //  CertificatesOperations/GetCertificatesById/{ID}
      //  PermissionToLeaveOperations/GetPermissionById/{ID}
     //   StcSubscriptionOperations/GetBreastById/{ID}
        public async Task<Tuple<ObservableCollection<BreastFeedingListModel>, bool, string>> GetBreatFestByID(string ID)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<BreastFeedingListModel>>(App.BaseUrl + $"api/BreastfeedingRequestOperations/GetBreastById/{ID}").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<PermissionsToLeaveLst>, bool, string>> GetPermitionsToLeaveByID(string ID)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<PermissionsToLeaveLst>>(App.BaseUrl + $"api/PermissionToLeaveOperations/GetPermissionById/{ID}").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<CertificateLstModel>, bool, string>> GetCertificateByID(string ID)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<CertificateLstModel>>(App.BaseUrl + $"api/CertificatesOperations/GetCertificatesById/{ID}").ConfigureAwait(false);

            return response;
        }

   

        public async Task<HttpResponseMessage> PermissionToLeaveDelete(int LeaveId)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/PermissionToLeaveOperations/RemovePermission/{LeaveId}", new { }).ConfigureAwait(false);
            return response;
        }

      
         public async Task<Tuple<OnlineServiceMenuModel, bool, string>> GetOnlineServicesLst()
        {
            var response = await HttpManager.GetAsyncWithBody<OnlineServiceMenuModel>(App.BaseUrl + $"get_menu",).ConfigureAwait(false);
            return response;
        }
     

      
    }
}
