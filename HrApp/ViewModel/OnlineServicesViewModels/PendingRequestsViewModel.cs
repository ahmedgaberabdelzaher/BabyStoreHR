using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using HrApp.View.Requests.DetailsView;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class PendingRequestsViewModel : ViewModelBase
    {

        PendingRequests selectedRequest;
        public PendingRequests SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<PendingRequests> requests = new ObservableCollection<PendingRequests>();
        public ObservableCollection<PendingRequests> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }

       

        Services.Interface.IOnlineServices _onlineServices;
        public PendingRequestsViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetAllRequests();

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            GetAllRequests();

            base.OnNavigatedTo(parameters);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        async Task GetAllRequests()
        {
            try
            {
                IsLoading = true;
                var model = new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {
                        employee_id = Preferences.Get("userId", 0)
                    }
                };
                var resp = await _onlineServices.GetRequests<PendingRequests>(model, "pending_request");
                if (resp.Item2)
                {
                      Requests = resp.Item1.result.data;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }


        public DelegateCommand GoToDetailsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (SelectedRequest!=null)
                    {
  var navParameters = new NavigationParameters();
                    navParameters.Add("res_id", SelectedRequest.res_id);
                    navParameters.Add("res_model", SelectedRequest.res_model);
                    await Navigate(SelectedRequest.res_model, navParameters);
                    SelectedRequest = null;
                    }
                  
                });

            }
        }

        public async Task Navigate(string resModel, NavigationParameters navpar)
        {
            switch (resModel)
            {
                case "ess.overtime.request": //tesing done
                    await NavigationService.NavigateAsync("OverTimeRequestDetails", navpar);
                    break;
                case "ess.business.travel.request"://testing done
                    await NavigationService.NavigateAsync("BuisnessTravelRequestDetails", navpar);
                      break;
                case "ess.leave.request": //testing done
                    await NavigationService.NavigateAsync("LeaveRequest", navpar);
                    break;
                case "ess.medical.insurance.request"://testing done
                    await NavigationService.NavigateAsync("MedicalInsuranceDetail", navpar);
                      break;
                case "ess.access.card.request":// testing done
                    await NavigationService.NavigateAsync("AccessCardRequestDetails", navpar);
                    break;
                case "ess.custody.request":  //testing done
                    await NavigationService.NavigateAsync("CustodyRequestDetail", navpar);
                    break;
                case "ess.email.request":
                    await NavigationService.NavigateAsync("EmailRequestDetail", navpar);
                   
                    break;
                case "ess.termination.request"://Done
                    await NavigationService.NavigateAsync("TerminationRequestDetail", navpar);
                   break;
                case "ess.loan.request"://Done
                    await NavigationService.NavigateAsync("LoanRequestDetail", navpar); 
                    
                    break;
                case "ess.attention.request": 
                    await NavigationService.NavigateAsync("AttentionRequestDetail", navpar);
                    break;
                case "ess.salary.advance.request"://Done
                    await NavigationService.NavigateAsync("SallaryAdvanceRequestDetail", navpar);
                    break;
                case "ess.salary.transfer.request"://Done
                    await NavigationService.NavigateAsync("SalleryTransferRequestDetail", navpar);
                    break;
                case "ess.letter.request": //Done
                    await NavigationService.NavigateAsync("LetterRequestDetail", navpar);
                    break;
                case "ess.resignation.request"://done
                    await NavigationService.NavigateAsync("ResignationRequestDetail", navpar);
                    break;
                case "ess.business.card.request": // Done
                    await NavigationService.NavigateAsync("BuissnessCardRequestDetail", navpar);
                    break;
                case "ess.ticket.request": //Done
                    await NavigationService.NavigateAsync("TicketCashRequestDetail", navpar);
                    break;
                case "ess.permission.request"://Done
                    await NavigationService.NavigateAsync("PermissionRequestDetail", navpar);
                    break;
                case "ess.back.from.vacation.request"://Done
                    await NavigationService.NavigateAsync("BackFromVacationDetails", navpar);
                    break;
                case "ess.transfer.sponsorship.request"://Done
                    await NavigationService.NavigateAsync("TransferSponserShipDetail", navpar);
                    break;
                case "ess.legal.advice.request"://Done
                    await NavigationService.NavigateAsync("LegalAdviceRequestDetail", navpar);
                    break;
                case "ess.financial.request"://Done
                    await NavigationService.NavigateAsync("FinancialrequestDetail", navpar);
                    break;
                case "ess.leave.return.request"://Done
                    await NavigationService.NavigateAsync("ExitReentryVisaDetail", navpar);
                    break;
                case "ess.salary.increase.request"://Done
                    await NavigationService.NavigateAsync("SalleryIncreaseRequestDetails", navpar);
                    break;
                case "ess.employee.transfer.request"://Done
                    await NavigationService.NavigateAsync("EmployeeTransferRequestDetail", navpar);
                    break;
                case "ess.renewal.passport.request":
                    await NavigationService.NavigateAsync("RenewalPassportRequestDetail", navpar);
                    break;
                 case "ess.renewal.residence.request":
                    await NavigationService.NavigateAsync("RenewalResidentDetail", navpar);
                    break; 

                default:
                    break;
            }
        }

    }

}

