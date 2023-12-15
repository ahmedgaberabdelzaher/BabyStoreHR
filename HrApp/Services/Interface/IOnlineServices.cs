using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using HrApp.Helpers;
using HrApp.Model;
using HrApp.Model.OdooModels;
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
        Task<HttpResponseMessage> SendAccessCardRequest(BaseOdoModel<AccessCardRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<AccessCardRequests>>, bool, string>> AccessCardRequestLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendCustodyRequest(BaseOdoModel<GetLeavesBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<CustodyLst>>, bool, string>> CustodyRequestLst(BaseOdoModel<GetLeavesBody> body);
        Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> CustodyProberitytLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendResignationRequest(BaseOdoModel<ResignationReasonBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> ResignationReasonstLst(BaseOdoModel<GetLeavesBody> body);
        Task<Tuple<OdooResponse<ObservableCollection<CustodyLst>>, bool, string>> GetResignationstLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendSalleytransferRequest(BaseOdoModel<SallertTransferBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<SlleryTransferLst>>, bool, string>> SalleytransferRequestLst(BaseOdoModel<GetLeavesBody> body);
        Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetBankLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendLetterRequest(BaseOdoModel<LetterRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<LetterRequests>>, bool, string>> LetterRequestLst(BaseOdoModel<GetLeavesBody> body);
        Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetLetterTypes(BaseOdoModel<GetLeavesBody> body);
        Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetLetterCompany(BaseOdoModel<GetLeavesBody> body);
        Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetLetterDetails(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendBuisnessCardRequest(BaseOdoModel<BuissnessCardRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<BuissnessCardRequestLst>>, bool, string>> BuissnessCrdRequestsLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendEmailRequest(BaseOdoModel<GetLeavesBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<AccessCardRequests>>, bool, string>> EmailRequestLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendTicketCashRequest(BaseOdoModel<TicketCashRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<TicketCashRequestsLst>>, bool, string>> TicketCashRequestLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendPermissionRequest(BaseOdoModel<PermissionsRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<PermissionsRequests>>, bool, string>> PermissionsRequestsLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendBusinessTravelRequest(BaseOdoModel<BuisnessTravelRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<BusinessTravelRequestsLst>>, bool, string>> BusinessTravelRequeststLst(BaseOdoModel<GetLeavesBody> body);
        Task<Tuple<OdooResponse<ObservableCollection<CustodyProperityLst>>, bool, string>> GetTravelCovers(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendBackFromVacationRequest(BaseOdoModel<BackFromVacationRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<BackFromVacationRequest>>, bool, string>> BackFromVacationRequestLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendLegalAdviceRequest(BaseOdoModel<LegalAdviceRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<LegalAdviceRequest>>, bool, string>> LegalAdviceRequestLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendFinancialRequest(BaseOdoModel<FinancialRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<FinancialRequest>>, bool, string>> FinancialRequesttLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendExitReEntryRequest(BaseOdoModel<ExitReEntryRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<ExitReEntryRequest>>, bool, string>> ExitReEntryRequestLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendRenewPassportRequest(BaseOdoModel<RenewalPassportRequestBody> model);
        Task<Tuple<OdooResponse<ObservableCollection<RenewalPassportRequest>>, bool, string>> enewalPassportRequesLst(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendLoanRequest(BaseOdoModel<LoanModelBody> model);

        Task<Tuple<OdooResponse<ObservableCollection<LoadRequestModel>>, bool, string>> LoanRequests(BaseOdoModel<GetLeavesBody> body);

        Task<HttpResponseMessage> SendSalaryIncreaserRequest(BaseOdoModel<SalaryIncreaserRequestBody> model);

        Task<Tuple<OdooResponse<ObservableCollection<SalaryIncreaserRequestModel>>, bool, string>> SalaryIncreaserRequests(BaseOdoModel<GetLeavesBody> body);
        Task<HttpResponseMessage> SendRequest<T>(BaseOdoModel<T> model, string endPoint);

        Task<Tuple<OdooResponse<ObservableCollection<T>>, bool, string>> GetRequests<T>(BaseOdoModel<GetLeavesBody> body, string endPoint);
        Task<Tuple<OdooResponse<ObservableCollection<T>>, bool, string>> GetRequestDeatils<T>(BaseOdoModel<GetRequestDetailsBody> body);
        Task<HttpResponseMessage> ApproveRequest<T>(BaseOdoModel<ApproveeRejectModel> model);
        Task<HttpResponseMessage> RejectRequest<T>(BaseOdoModel<ApproveeRejectModel> model);
        Task<HttpResponseMessage> CancelRequest(BaseOdoModel<GetRequestDetailsBody> body);
    }
}