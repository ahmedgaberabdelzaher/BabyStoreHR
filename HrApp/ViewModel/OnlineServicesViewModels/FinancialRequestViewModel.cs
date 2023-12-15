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

    public class FinancialRequestViewModel : DetailsandActionsViewModel<FinancialRequest>
    {
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<FinancialRequest> requests = new ObservableCollection<FinancialRequest>();
        public ObservableCollection<FinancialRequest> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


        string employeeName;
        public string EmployeeName { get { return employeeName; } set { employeeName = value; RaisePropertyChanged(); } }

        string address="";
        public string Address { get { return address; } set { address = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        userData selectedEmployee;
        public userData SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; RaisePropertyChanged(); } }

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        double financialAmount = 0.0;
        public double FinancialAmount { get { return financialAmount; } set { financialAmount = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public FinancialRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetFinancialRequesttLst();

        }

        public DelegateCommand<FinancialRequest> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<FinancialRequest>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.financial.request"
                            };
                            await Cancelrequest(body);
                            await GetFinancialRequesttLst();
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
            FinancialAmount = 0.0;
        }

        public DelegateCommand SendRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendFinancialRequest();
                });
            }
        }


        async Task SendFinancialRequest()
        {
            try
            {
                IsLoading = true;

                if (financialAmount > 0.0)
                {
                    var model = new FinancialRequestBody()
                    {

                        employee_id = Preferences.Get("userId", 0),
                        financial_amount = FinancialAmount,
                         financial_address=Address
                    };
                    var body = new BaseOdoModel<FinancialRequestBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendFinancialRequest(body);
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetFinancialRequesttLst();

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

        async Task GetFinancialRequesttLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.FinancialRequesttLst(new BaseOdoModel<GetLeavesBody>()
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
        public void SetDetailsData(FinancialRequest data)
        {

            FinancialAmount = data.financial_amount;
            Address = data.financial_address;
            EmployeeName = data.employee_id[1].ToString();

        }


    }

}

