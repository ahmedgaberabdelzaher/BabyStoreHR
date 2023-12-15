using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using HrApp.Helpers;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class LoanRequestsViewModel : DetailsandActionsViewModel<LoadRequestModel>
    {
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<LoadRequestModel> requests = new ObservableCollection<LoadRequestModel>();
        public ObservableCollection<LoadRequestModel> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


       
        string requestType;
        public string RequestType { get { return requestType; } set { requestType = value; RaisePropertyChanged(); } }

       
      
        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        double amount = 0.0;
        public double Amount { get { return amount; } set { amount = value; RaisePropertyChanged(); } }

        int noOfInstallments = 0;
        public int NoOfInstallments { get { return noOfInstallments; } set { noOfInstallments = value; RaisePropertyChanged(); } }

        DateTime paymenDate =DateTime.Now;
        public DateTime PaymenDate { get { return paymenDate; } set { paymenDate = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public LoanRequestsViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetLoanRequests();

        }


        public DelegateCommand<LoadRequestModel> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<LoadRequestModel>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.loan.request"
                            };
                            await Cancelrequest(body);
                            await GetLoanRequests();
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
            Amount = 0.0;
        }

        public DelegateCommand SendRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendRequest();
                });
            }
        }


        async Task SendRequest()
        {
            try
            {
                IsLoading = true;

                if (Amount > 0.0&&SelectedEmployee!=null)
                {
                    var model = new LoanModelBody()
                    {

                        employee_id = SelectedEmployee.id,
                        amount = Amount,
                        installment= NoOfInstallments,
                        payment_date=PaymenDate.ToString("yyyy-MM-dd")
                        
                    };
                    var body = new BaseOdoModel<LoanModelBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendLoanRequest(body);
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetLoanRequests();

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

        async Task GetLoanRequests()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.LoanRequests(new BaseOdoModel<GetLeavesBody>()
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
        public void SetDetailsData(LoadRequestModel data)
        {

            Amount = data.amount;
            EmployeeName = data.employee_id[1].ToString();

            NoOfInstallments = data.installment;
            PaymenDate = DateTimeHelper.ConvertStringTodateonly(data.payment_date);

        }



    }

}

