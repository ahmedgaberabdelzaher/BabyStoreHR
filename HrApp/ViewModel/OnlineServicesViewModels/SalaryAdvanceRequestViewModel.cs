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
using Xamarin.Forms;
using System.Linq;
using HrApp.Helpers;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class SalaryAdvanceRequestViewModel : DetailsandActionsViewModel<SalaryAdvanceRequest>
    {
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<SalaryAdvanceRequest> requests = new ObservableCollection<SalaryAdvanceRequest>();
        public ObservableCollection<SalaryAdvanceRequest> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }



        string increase_type;
        public string Increase_type { get { return increase_type; } set { increase_type = value; RaisePropertyChanged(); } }

  string reason="";
        public string Reason { get { return reason; } set { reason = value; RaisePropertyChanged(); } }



        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        double amount = 0.0;
        public double Amount { get { return amount; } set { amount = value; RaisePropertyChanged(); } }


        DateTime paymentDate = DateTime.Now;
        public DateTime PaymentDate { get { return paymentDate; } set { paymentDate = value; RaisePropertyChanged(); } }
        

        Services.Interface.IOnlineServices _onlineServices;
        public SalaryAdvanceRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetAllRequests();
            SetTypes();

        }

        Dictionary<string, string> IncreaseTypeLst = new Dictionary<string, string>();
        public void SetTypes()
        {
            IncreaseTypeLst.Add("Percentage", "percentage");
            IncreaseTypeLst.Add("Amount", "amount");


        }
        public DelegateCommand SelecIncreaseTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {


                    var rs = await DialogService.DisplayActionSheetAsync("Select Increase Type", "Cancel", "", IncreaseTypeLst.Keys.ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        Increase_type = rs;
                        
                    }


                    IsLoading = false;


                });
            }
        }


        public DelegateCommand<CustodyLst> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<CustodyLst>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.salary.advance.request"
                            };
                            await Cancelrequest(body);
                            await GetAllRequests();
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
            Increase_type = "";
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

                if (Amount > 0.0 && !string.IsNullOrEmpty(Reason))
                {
                    var model = new SalaryAdvanceRequestBody()
                    {

                        employee_id = SelectedEmployee.id,
                        amount = Amount,
                         reason= Reason,
                         date=PaymentDate.ToString("yyyy-MM-dd")


                    };
                    var body = new BaseOdoModel<SalaryAdvanceRequestBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendRequest<SalaryAdvanceRequestBody>(body, "salary_advance/create_request");
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetAllRequests();

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
                var resp = await _onlineServices.GetRequests<SalaryAdvanceRequest>(model, "salary_advance");
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
        public void SetDetailsData(SalaryAdvanceRequest data)
        {
            EmployeeName = data.employee_id[1].ToString();
            Amount = data.amount;
            Reason = data.reason;
            PaymentDate= DateTimeHelper.ConvertStringTodateonly(data.date);

        }



    }

}

