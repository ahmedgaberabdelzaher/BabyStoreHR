using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using HrApp.Model;
using HrApp.Resources;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
    public class FCMBody

    {

        public string[] registration_ids { get; set; }

        public FCMNotification notification { get; set; }

        public FCMData data { get; set; }

    }

    public class FCMNotification

    {

        public string body { get; set; }

        public string title { get; set; }

    }

    public class FCMData

    {

        public string key1 { get; set; }

        public string key2 { get; set; }

        public string key3 { get; set; }

        public string key4 { get; set; }

    }
    public class OnlineServicesMenuViewModel:ViewModelBase
	{

        public  ObservableCollection<LookUpModel> EmployeeRequests { get; set; } = new ObservableCollection<LookUpModel>()
        {
            new LookUpModel()
            {
                Id=1,Name=LangaugeResource.LeaveRequests,icon="HrApp.Images.Leave.svg",PageName="LeavesList"
            }/*,
             new LookUpModel()
            {
                Id=2,Name="Modify Leave Requests",icon="Modify-Leaves.svg",
            }*/,
              new LookUpModel()
            {
                Id=3,Name=LangaugeResource.SalaryTransferRequest,icon="HrApp.Images.Salary-Transfer.svg",PageName="SalleryTransferRequest"
            },
             new LookUpModel()
            {
                Id=4,Name=LangaugeResource.Letter_Requests,icon="HrApp.Images.Papers.svg",PageName="LetterRequests"
            },
                new LookUpModel()
            {
                Id=5,Name=LangaugeResource.Access_Card_Request,icon="HrApp.Images.Access-Card.svg",PageName="AccessCardRequestLstView"
            },
             new LookUpModel()
            {
                Id=6,Name=LangaugeResource.ResignationRequest,icon="HrApp.Images.Resignation.svg",PageName="ResignationRequests"
            },
              new LookUpModel()
            {
                Id=7,Name=LangaugeResource.BusinessCardRequest,icon="HrApp.Images.Business-Card.svg",PageName="BusinessCardRequest"
            },
             new LookUpModel()
            {
                Id=8,Name=LangaugeResource.CustodyRequest,icon="HrApp.Images.Custody.svg",PageName="CustodyRequests"
            },
              new LookUpModel()
            {
                Id=9,Name=LangaugeResource.EmailRequest,icon="HrApp.Images.Email.svg",PageName="EmailRequests"
            },
              new LookUpModel()
            {
                Id=10,Name=LangaugeResource.TicketCashRequest,icon="HrApp.Images.Ticket.svg",PageName="TicketCashRequestView"
            }
              ,
              new LookUpModel()
            {
                Id=11,Name=LangaugeResource.MedicalInsuranceRequest,icon="HrApp.Images.Medical-Insurance.svg",PageName="MedicalInsuranceView"
            }
               /*,
              new LookUpModel()
            {
                Id=12,Name="Relative Request",icon="HrApp.Images.Employee-Relative.svg"
            }*/
               ,
              new LookUpModel()
            {
                Id=13,Name=LangaugeResource.Permission_Request,icon="HrApp.Images.Permission.svg",PageName="PermissionRequest"
            }
              ,
              new LookUpModel()
            {
                Id=14,Name=LangaugeResource.BusinessTravelRequest,icon="HrApp.Images.Business-Travel.svg",PageName="BusinessTravelRequestView"
            }
              ,
              new LookUpModel()
            {
                Id=15,Name=LangaugeResource.BackFromVacationRequest,icon="HrApp.Images.Back-From-Vacation.svg",PageName="BAckFromVacationRequest"
            },
              new LookUpModel()
            {
                Id=16,Name=LangaugeResource.LegalAdviceRequest,icon="HrApp.Images.Legal-Advice.svg",PageName="LegalAdviceRequesView"
            }
              ,
              new LookUpModel()
            {
                Id=17,Name=LangaugeResource.FinancialRequest,icon="HrApp.Images.Financial.svg",PageName="FinancialRequestView"
            }
              ,
              new LookUpModel()
            {
                Id=18,Name=LangaugeResource.ExitRe_EntryVISARequest,icon="HrApp.Images.Exit-Re-Entry-VISA.svg",PageName="ExitReEntryVISARequest"
            }
               ,
              new LookUpModel()
            {
                Id=19,Name=LangaugeResource.RenewalPassportRequest,icon="HrApp.Images.Renewal-Passport.svg",PageName="RenewalPassportRequestView"
            }
                ,
              new LookUpModel()
            {
                Id=20,Name=LangaugeResource.RenewalResidenceRequestt,icon="HrApp.Images.Renewal-Residence.svg",PageName="RenewalResidenceRequestView"
            }
        };

        public  ObservableCollection<LookUpModel> DirectManagerRequests { get; set; } = new ObservableCollection<LookUpModel>()
        {
            new LookUpModel()
            {
                Id=21,Name=LangaugeResource.LoanRequest,icon="Loan.svg",PageName="LoanRequestsView"
            },
             new LookUpModel()
            {
                Id=22,Name=LangaugeResource.AttentionRequest,icon="Attention.svg",PageName="AttentionRequestView"
            },
              new LookUpModel()
            {
                Id=23,Name=LangaugeResource.SalaryIncreaseRequest,icon="Salary-Increase.svg",PageName="SalaryIncreaserRequestView"
            },
             new LookUpModel()
            {
                Id=24,Name=LangaugeResource.OverTimeRequest,icon="Over-Time.svg",PageName="OverTimeRequestView"
            },
                new LookUpModel()
            {
                Id=25,Name=LangaugeResource.SalaryAdvance,icon="Salary-Advance.svg",PageName="SalaryAdvanceRequestView"
            },
             new LookUpModel()
            {
                Id=26,Name=LangaugeResource.TerminationRequest,icon="Termination.svg",PageName="TerminationRequestView"
            },
              new LookUpModel()
            {
                Id=27,Name=LangaugeResource.EmployeeTransferRequest,icon="EmployeeTransfer.svg",PageName="EmployeeTransferRequestView"
            },
             new LookUpModel()
            {
                Id=28,Name=LangaugeResource.TransferSponsorshipRequest,icon="Transfer-Sponsorship.svg",PageName="TransferSponsorShipRequestView"
            }
        };


        ObservableCollection<Model.LookUpModel> onlineServicesMenuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> OnlineServicesMenuItems { get { return onlineServicesMenuItems; } set { onlineServicesMenuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequestType;
        public Model.LookUpModel SelectedRequestType { get { return selectedRequestType; } set { selectedRequestType = value;RaisePropertyChanged(); } }

        Services.Interface.IOnlineServices _onlineServices;

        public OnlineServicesMenuViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _onlineServices = onlineServices;
            /*  OnlineServicesMenuItems = new ObservableCollection<Model.LookUpModel>()
              {
                   new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},
                   new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},
                   new Model.LookUpModel(){  icon="leaverequest",Id=1,Name="Leave Request"},
                   new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},
                   new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},
                   new Model.LookUpModel(){  icon="leaverequest.svg",Id=1,Name="Leave Request"},             new Model.LookUpModel(){  icon="leaverequest",Id=1,Name="Leave Request"},
                   new Model.LookUpModel(){  icon="leaverequest",Id=1,Name="Leave Request"}
              };*/
           var Role = Preferences.Get("role", "employee");
            if (Role=="manager"||Role=="hr")
            {
                var services = EmployeeRequests.ToList();
                services.AddRange(DirectManagerRequests);
                OnlineServicesMenuItems = new ObservableCollection<Model.LookUpModel>(services);
            }
            else
            OnlineServicesMenuItems = EmployeeRequests;
        }

        public DelegateCommand GoToDetailsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                  

                });

            }
        }

      public DelegateCommand SelectedRequestTypeChangedCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    if (SelectedRequestType!=null)
                    {
                        var navParameters = new NavigationParameters();
                        navParameters.Add("RequesttypeId", SelectedRequestType.Id);
                          navParameters.Add("List", 1);
                          navParameters.Add("IsFromManager", "1");
                          navParameters.Add("RequesttypeName", SelectedRequestType.Name);
                        navParameters.Add("PageTitle", "Leaves");

                        await NavigationService.NavigateAsync(SelectedRequestType.PageName, navParameters);
                        SelectedRequestType = null;


                    }
                });

            }
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetOnlineServices();
            base.OnNavigatedTo(parameters);
        }
        async Task GetOnlineServices()
        {
            try
            {
                IsLoading = true;
                
                var resp = await _onlineServices.GetOnlineServicesLst(new Model.OnlineServicesModels.OnlineServiceMenuModel());
                if (resp.Item2)
                {
                    var menu = resp.Item1;
                    if (menu.result!=null)
                    {
                        var data = menu.result.data;
                        foreach (var item in data)
                        {
                            OnlineServicesMenuItems.Add(new Model.LookUpModel()
                            {
                                Id = int.Parse(item.Key),
                                Name = item.Value
                            });
                        }
                    }
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }


    }
}

