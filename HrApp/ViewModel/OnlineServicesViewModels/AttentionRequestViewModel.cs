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
using System.Linq;
using Xamarin.Forms;

namespace HrApp.ViewModel.OnlineServicesViewModels
{

    public class AttentionRequestViewModel : DetailsandActionsViewModel<AttentionRequestModel>
    {
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<AttentionRequestModel> requests = new ObservableCollection<AttentionRequestModel>();
        public ObservableCollection<AttentionRequestModel> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }



        string increase_type;
        public string Increase_type { get { return increase_type; } set { increase_type = value; RaisePropertyChanged(); } }

        string msg = "";
        public string Message { get { return msg; } set { msg = value; RaisePropertyChanged(); } }



        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        double amount = 0.0;
        public double Amount { get { return amount; } set { amount = value; RaisePropertyChanged(); } }


        DateTime paymentDate = DateTime.Now;
        public DateTime PaymentDate { get { return paymentDate; } set { paymentDate = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public AttentionRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetAllRequests();

        }

        Dictionary<string, string> IncreaseTypeLst = new Dictionary<string, string>();
        public void SetTypes()
        {
            IncreaseTypeLst.Add("Percentage", "percentage");
            IncreaseTypeLst.Add("Amount", "amount");


        }

        public DelegateCommand<AttentionRequestModel> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<AttentionRequestModel>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.attention.request"
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
            EmployeeName = "";
            Message = "";
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

                if (!string.IsNullOrEmpty(Message)&&SelectedEmployee!=null)
                {
                    var model = new AttentionRequestBody()
                    {

                        employee_id = SelectedEmployee.id,
                        message=Message


                    };
                    var body = new BaseOdoModel<AttentionRequestBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendRequest<AttentionRequestBody>(body, "attention/create_request");
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
                var resp = await _onlineServices.GetRequests<AttentionRequestModel>(model, "attention");
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
        public void SetDetailsData(AttentionRequestModel data)
        {

            Message = data.message;
            EmployeeName = data.employee_id[1].ToString();

        }


    }

}

