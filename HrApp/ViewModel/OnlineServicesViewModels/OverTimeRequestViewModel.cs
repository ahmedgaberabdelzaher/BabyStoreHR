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
using HrApp.Model.OverTimeModels;
using System.Net.Http;
using System.Globalization;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
    public class OverTimeRequestViewModel : DetailsandActionsViewModel<OverTimeRequest>
    {
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<OverTimeRequest> requests = new ObservableCollection<OverTimeRequest>();
        public ObservableCollection<OverTimeRequest> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }

        CustodyProperityLst selectedReason;
        CustodyProperityLst SelectedReason { get { return selectedReason; } set { selectedReason = value; RaisePropertyChanged(); } }

        ObservableCollection<CustodyProperityLst> reasons = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> Reasons { get { return reasons; } set { reasons = value; RaisePropertyChanged(); } }


        OverTimeRequest selctedeRequest;
        public OverTimeRequest SelctedeRequest { get { return selctedeRequest; } set { selctedeRequest = value; RaisePropertyChanged(); } }


        string increase_type;
        public string Increase_type { get { return increase_type; } set { increase_type = value; RaisePropertyChanged(); } }

      

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }

      

        double amount = 0.0;
        public double Amount { get { return amount; } set { amount = value; RaisePropertyChanged(); } }


        DateTime overTimeDate = DateTime.Now;
        public DateTime OverTimeDate { get { return overTimeDate; } set { overTimeDate = value; RaisePropertyChanged(); } }

        TimeSpan _TotalHours;
        public TimeSpan TotalHours { get { return _TotalHours; } set { _TotalHours = value; RaisePropertyChanged(); } }


        TimeSpan _Timefrom;
        public TimeSpan TimeFrom
        {
            get { return _Timefrom; }
            set
            {
                _Timefrom = value;
                TotalHours = TimeTo.Subtract(_Timefrom);
                if (TotalHours < new TimeSpan(0, 0, 0))
                {
                    TotalHours = new TimeSpan(0, 0, 0);
                }




                RaisePropertyChanged();
            }
        }


        public DelegateCommand<OverTimeRequest> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<OverTimeRequest>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.overtime.request"
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


        TimeSpan _TimeTo;
        public TimeSpan TimeTo
        {
            get { return _TimeTo; }
            set
            {
                _TimeTo = value;

                TotalHours = TimeTo.Subtract(TimeFrom);
                if (TotalHours < new TimeSpan(0, 0, 0))
                {
                    // TotalHours = Timeout.Add(new TimeSpan(24, 0, 0)).Subtract(Timein);
                    TotalHours = new TimeSpan(0, 0, 0);
                }

                RaisePropertyChanged();
            }
        }

        Services.Interface.IOnlineServices _onlineServices;
        public OverTimeRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetAllRequests();
            SetTypes();

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                if (parameters != null && parameters.Count > 0)
                {

                    res_model = parameters["res_model"].ToString();
                    res_id = int.Parse(parameters["res_id"].ToString());
                  var data=  await GetRequestDetails();
                    SetDetailsData(data);
                }

            }
            catch (Exception ex)
            {

            }
        }
        public void SetDetailsData(OverTimeRequest data)
        {

            EmployeeName = data.employee_id[1].ToString();
            TotalHours = TimeSpan.FromHours(data.hours);
            TimeFrom = DateTime.ParseExact(data.date_from,"yyyy-MM-dd HH:m:ss", CultureInfo.InvariantCulture).TimeOfDay;
            TimeTo = DateTime.ParseExact(data.date_to, "yyyy-MM-dd HH:m:ss", CultureInfo.InvariantCulture).TimeOfDay;
            OverTimeDate = DateTime.ParseExact(data.date_from, "yyyy-MM-dd HH:m:ss", CultureInfo.InvariantCulture).Date;

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

                if (!string.IsNullOrEmpty(EmployeeName))
                {
                    var model = new OverTimeRequestModel()
                    {

                       employee_id  = SelectedEmployee.id,
                         date_from = (OverTimeDate + TimeFrom).ToString("yyyy-MM-dd HH:mm:ss"),
                        date_to = (OverTimeDate + TimeTo).ToString("yyyy-MM-dd HH:mm:ss"),


                    };
                    var body = new BaseOdoModel<OverTimeRequestModel>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendRequest<OverTimeRequestModel>(body, "overtime/create_request");
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
        async Task<ObservableCollection<CustodyProperityLst>> GetDepartments()
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
                var resp = await _onlineServices.GetRequests<CustodyProperityLst>(model, "hr_department");
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
                var resp = await _onlineServices.GetRequests<OverTimeRequest>(model, "overtime");
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


    }

}

