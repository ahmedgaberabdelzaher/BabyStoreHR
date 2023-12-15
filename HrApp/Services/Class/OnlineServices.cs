using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using HrApp.Helpers;
using HrApp.Model;
using HrApp.Model.OdooModels;
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

      
         public async Task<Tuple<OnlineServiceMenuModel, bool, string>> GetOnlineServicesLst(OnlineServiceMenuModel model)
        {
            var response = await HttpManager.GetAsyncWithBody<OnlineServiceMenuModel>(App.BaseUrl + $"get_menu",model).ConfigureAwait(false);
            return response;
        }
        
        public async Task<HttpResponseMessage> SendAccessCardRequest(BaseOdoModel<AccessCardRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"access_card/create_request", model).ConfigureAwait(false);
            return response;
        }
      
        public async Task<Tuple<OdooResponse<ObservableCollection<AccessCardRequests>>, bool, string>> AccessCardRequestLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<AccessCardRequests>>>(App.BaseUrl + "access_card", body).ConfigureAwait(false);

            return response;
        }
        public async Task<HttpResponseMessage> SendCustodyRequest(BaseOdoModel<GetLeavesBody>  model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"custody/create_request", model).ConfigureAwait(false);
            return response;
        }

        public async Task<Tuple<OdooResponse<ObservableCollection<CustodyLst>>, bool, string>> CustodyRequestLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<CustodyLst>>>(App.BaseUrl + "custody", body).ConfigureAwait(false);

            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> CustodyProberitytLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<CustodyProperityLst>>>(App.BaseUrl + "custody_property", body).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> SendResignationRequest(BaseOdoModel<ResignationReasonBody>  model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"resignation/create_request", model).ConfigureAwait(false);
            return response;
        }
   public async Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> ResignationReasonstLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<CustodyProperityLst>>>(App.BaseUrl + "resignation_reason", body).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<CustodyLst>>, bool, string>> GetResignationstLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<CustodyLst>>>(App.BaseUrl + "resignation", body).ConfigureAwait(false);
            return response;
        }


        public async Task<HttpResponseMessage> SendSalleytransferRequest(BaseOdoModel<SallertTransferBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"salary_transfer/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<SlleryTransferLst>>, bool, string>> SalleytransferRequestLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<SlleryTransferLst>>>(App.BaseUrl + "salary_transfer", body).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetBankLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<CustodyProperityLst>>>(App.BaseUrl + "employee_bank", body).ConfigureAwait(false);
            return response;
        }


        public async Task<HttpResponseMessage> SendLetterRequest(BaseOdoModel<LetterRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"letter/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<LetterRequests>>, bool, string>> LetterRequestLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<LetterRequests>>>(App.BaseUrl + "letters", body).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetLetterTypes(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<CustodyProperityLst>>>(App.BaseUrl + "letter_type", body).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetLetterCompany(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<CustodyProperityLst>>>(App.BaseUrl + "letter_company", body).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetLetterDetails(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<CustodyProperityLst>>>(App.BaseUrl + "letter_details", body).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> SendBuisnessCardRequest(BaseOdoModel<BuissnessCardRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"business_card/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<BuissnessCardRequestLst>>, bool, string>> BuissnessCrdRequestsLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<BuissnessCardRequestLst>>>(App.BaseUrl + "business_card", body).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> SendEmailRequest(BaseOdoModel<GetLeavesBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"email/create_request", model).ConfigureAwait(false);
            return response;
        }

        public async Task<Tuple<OdooResponse<ObservableCollection<AccessCardRequests>>, bool, string>> EmailRequestLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<AccessCardRequests>>>(App.BaseUrl + "emails", body).ConfigureAwait(false);

            return response;
        }


        public async Task<HttpResponseMessage> SendTicketCashRequest(BaseOdoModel<TicketCashRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"ticket/create_request", model).ConfigureAwait(false);
            return response;
        }

        public async Task<Tuple<OdooResponse<ObservableCollection<TicketCashRequestsLst>>, bool, string>> TicketCashRequestLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<TicketCashRequestsLst>>>(App.BaseUrl + "tickets", body).ConfigureAwait(false);

            return response;
        }



        public async Task<HttpResponseMessage> SendPermissionRequest(BaseOdoModel<PermissionsRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"permission/create_request", model).ConfigureAwait(false);
            return response;
        }

        public async Task<Tuple<OdooResponse<ObservableCollection<PermissionsRequests>>, bool, string>> PermissionsRequestsLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<PermissionsRequests>>>(App.BaseUrl + "permission", body).ConfigureAwait(false);

            return response;
        }


        public async Task<HttpResponseMessage> SendBusinessTravelRequest(BaseOdoModel<BuisnessTravelRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"business_travel/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<BusinessTravelRequestsLst>>, bool, string>> BusinessTravelRequeststLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<BusinessTravelRequestsLst>>>(App.BaseUrl + "business_travel", body).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetTravelCovers(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<CustodyProperityLst>>>(App.BaseUrl + "travel_cover", body).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> SendBackFromVacationRequest(BaseOdoModel<BackFromVacationRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"back_vacation/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<BackFromVacationRequest>>, bool, string>> BackFromVacationRequestLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<BackFromVacationRequest>>>(App.BaseUrl + "back_vacation", body).ConfigureAwait(false);
            return response;
        }


        public async Task<HttpResponseMessage> SendLegalAdviceRequest(BaseOdoModel<LegalAdviceRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"legal_advice/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<LegalAdviceRequest>>, bool, string>> LegalAdviceRequestLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<LegalAdviceRequest>>>(App.BaseUrl + "legal_advice", body).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> SendFinancialRequest(BaseOdoModel<FinancialRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"financial/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<FinancialRequest>>, bool, string>> FinancialRequesttLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<FinancialRequest>>>(App.BaseUrl + "financial", body).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> SendExitReEntryRequest(BaseOdoModel<ExitReEntryRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"exit_reentry_visa/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<ExitReEntryRequest>>, bool, string>> ExitReEntryRequestLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<ExitReEntryRequest>>>(App.BaseUrl + "exit_reentry_visa", body).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> SendRenewPassportRequest(BaseOdoModel<RenewalPassportRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"renewal_passport/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<RenewalPassportRequest>>, bool, string>> enewalPassportRequesLst(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<RenewalPassportRequest>>>(App.BaseUrl + "renewal_passport", body).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> SendLoanRequest(BaseOdoModel<LoanModelBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"loan/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<LoadRequestModel>>, bool, string>> LoanRequests(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<LoadRequestModel>>>(App.BaseUrl + "loan", body).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> SendSalaryIncreaserRequest(BaseOdoModel<SalaryIncreaserRequestBody> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"salary_increase/create_request", model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<SalaryIncreaserRequestModel>>, bool, string>> SalaryIncreaserRequests(BaseOdoModel<GetLeavesBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<SalaryIncreaserRequestModel>>>(App.BaseUrl + "salary_increase", body).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> SendRequest<T>(BaseOdoModel<T> model,string endPoint)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + endPoint, model).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<T>>, bool, string>> GetRequests<T>(BaseOdoModel<GetLeavesBody> body,string endPoint)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<T>>>(App.BaseUrl + endPoint, body).ConfigureAwait(false);
            return response;
        }
        public async Task<Tuple<OdooResponse<ObservableCollection<T>>, bool, string>> GetRequestDeatils<T>(BaseOdoModel<GetRequestDetailsBody> body)
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<T>>>(App.BaseUrl+ "get_request", body).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> ApproveRequest<T>(BaseOdoModel<ApproveeRejectModel> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + "request/approve", model).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> RejectRequest<T>(BaseOdoModel<ApproveeRejectModel> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + "request/reject", model).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> CancelRequest(BaseOdoModel<GetRequestDetailsBody> body)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + "cancel_request", body).ConfigureAwait(false);
            return response;
        }

        /*
                 Task<HttpResponseMessage> SendFinancialRequest(BaseOdoModel<FinancialRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<FinancialRequest>>, bool, string>> FinancialRequesttLst(BaseOdoModel<GetLeavesBody> body);
         */
    }
}
