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
using HrApp.Helpers;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class RenewalResidenceRequestViewModel : DetailsandActionsViewModel<RenewalResidanceRequestModel>
    {
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<RenewalResidanceRequestModel> requests = new ObservableCollection<RenewalResidanceRequestModel>();
        public ObservableCollection<RenewalResidanceRequestModel> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }

        CustodyProperityLst selectedReason;
        CustodyProperityLst SelectedReason { get { return selectedReason; } set { selectedReason = value; RaisePropertyChanged(); } }

        ObservableCollection<CustodyProperityLst> reasons = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> Reasons { get { return reasons; } set { reasons = value; RaisePropertyChanged(); } }


        string increase_type;
        public string Increase_type { get { return increase_type; } set { increase_type = value; RaisePropertyChanged(); } }

        string location = "";
        public string Location { get { return location; } set { location = value; RaisePropertyChanged(); } }



        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        int duration = 0;
        public int Duration { get { return duration; } set { duration = value; RaisePropertyChanged(); } }


        DateTime epirationDate = DateTime.Now;
        public DateTime ExpirationDate { get { return epirationDate; } set { epirationDate = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public RenewalResidenceRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
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


        public DelegateCommand<RenewalResidanceRequestModel> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<RenewalResidanceRequestModel>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.renewal.residence.request"
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
            Duration = 0;
            Location = "";
            ExpirationDate = DateTime.Now;
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

                if (!string.IsNullOrEmpty(Location)&&Duration>0)
                {
                    var model = new RenewalResidanceRequestBody()
                    {

                        employee_id = Preferences.Get("userId", 0),
                        location = Location,
                        expiration_date = ExpirationDate.ToString("yyyy-MM-dd"),
                         duration=Duration
                         


                    };
                    var body = new BaseOdoModel<RenewalResidanceRequestBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendRequest<RenewalResidanceRequestBody>(body, "renewal_residence/create_request");
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
        async Task<ObservableCollection<CustodyProperityLst>> GetReasons()
        {
            try
            {
                IsLoading = true;

                var model = new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {
                    }
                };
                var resp = await _onlineServices.GetRequests<CustodyProperityLst>(model, "termination_reason");
                if (resp.Item2)
                {

                    var data = resp.Item1.result.data;
                    return data;
                }
                IsLoading = false;

                return null;

            }
            catch (Exception ex)
            {
                IsLoading = false;

                return null;


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
                var resp = await _onlineServices.GetRequests<RenewalResidanceRequestModel>(model, "renewal_residence");
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
        public void SetDetailsData(RenewalResidanceRequestModel data)
        {
            EmployeeName = data.employee_id[1].ToString();
            Location = data.location;
            ExpirationDate = DateTimeHelper.ConvertStringTodateonly(data.expiration_date);
            Duration = data.duration;

        }



    }

}

