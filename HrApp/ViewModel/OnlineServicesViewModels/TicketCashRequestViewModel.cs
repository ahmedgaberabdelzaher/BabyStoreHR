using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;
using Xamarin.Forms;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class TicketCashRequestViewModel : DetailsandActionsViewModel<TicketCashRequestsLst>
    {
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<TicketCashRequestsLst> requests = new ObservableCollection<TicketCashRequestsLst>();
        public ObservableCollection<TicketCashRequestsLst> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


        string employeeName;
        public string EmployeeName { get { return employeeName; } set { employeeName = value; RaisePropertyChanged(); } }

        string requestType;
        public string RequestType { get { return requestType; } set { requestType = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        userData selectedEmployee;
        public userData SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; RaisePropertyChanged(); } }

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        double ticketAmount=0.0;
        public double TicketAmount { get { return ticketAmount; } set { ticketAmount = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public TicketCashRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetTicketCashRequestLst();
           
        }


        public DelegateCommand SelectEmployeeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    IsLoading = true;
                    if (EmpLst == null || EmpLst.Count <= 0)
                    {
                        EmpLst = await GetAllEmployee();
                    }

                    var rs = await DialogService.DisplayActionSheetAsync("Select Employee", "Cancel", "", EmpLst.Select(c => c.name_en).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        EmployeeName = rs;
                        SelectedEmployee = EmpLst.First(c => c.name_en == rs);

                    }
                    IsLoading = false;
                });
            }
        }


        public DelegateCommand<TicketCashRequestsLst> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<TicketCashRequestsLst>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.ticket.request"
                            };
                            await Cancelrequest(body);
                            await GetTicketCashRequestLst();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        IsLoading = false;
                    }


                });

            }
        }


        public DelegateCommand AddNewRequestCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsNewRequest = true;
                });
            }
        }

        public DelegateCommand CloseNewRequestCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CleareNewRequestData();
                });
            }
        }

        private void CleareNewRequestData()
        {
            IsNewRequest = false;
            SelectedEmployee = new userData();
            TicketAmount = 0.0;
        }

        public DelegateCommand SendRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await TicketCashRequest();
                });
            }
        }


        async Task TicketCashRequest()
        {
            try
            {
                IsLoading = true;
                
                    if(TicketAmount>0.0)
                        {
                            var model = new TicketCashRequestBody()
                            {

                                employee_id = Preferences.Get("userId", 0),
                                amount = TicketAmount
                            };
                            var body = new BaseOdoModel<TicketCashRequestBody>()
                            {
                                @params = model
                            };
                            var resp = await _onlineServices.SendTicketCashRequest(body);
                            var result = await resp.Content.ReadAsStringAsync();
                            if (resp.IsSuccessStatusCode)
                            {
                                CleareNewRequestData();
                                // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await GetTicketCashRequestLst();

                            }
                            else
                            {
                                await DialogService.DisplayAlertAsync("", "Erro Occured", "Cancel");

                            }

                        }
                    

                
            }

            //   }
            catch (Exception ex)
            {
                IsLoading = false;

            }
            finally
            {
                IsLoading = false;
            }

        }

        async Task GetTicketCashRequestLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.TicketCashRequestLst(new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {
                        employee_id = Preferences.Get("userId", 0)
                    }
                });

                if (resp.Item2)
                {

                    /*var list = resp.Item1.OrderByDescending(i => i.reQ_DATE).ToList();
                    list.ForEach(i => Leaves.Add(i)); */

                    Requests = resp.Item1.result.data;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                if (parameters != null && parameters.Count > 0)
                {

                    res_model = parameters["res_model"].ToString();
                    res_id = int.Parse(parameters["res_id"].ToString());
                    var data = await GetRequestDetails();
                    SetDetailsData(data);
                }

            }
            catch (Exception ex)
            {

            }
        }
        public void SetDetailsData(TicketCashRequestsLst data)
        {

            TicketAmount = data.amount;
 
            EmployeeName = data.employee_id[1].ToString();

        }



    }

}

