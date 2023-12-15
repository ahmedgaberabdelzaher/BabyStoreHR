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
    public class PermissionRequestsViewModel : DetailsandActionsViewModel<PermissionsRequests>
    {

        ObservableCollection<PermissionsRequests> requests = new ObservableCollection<PermissionsRequests>();
        public ObservableCollection<PermissionsRequests> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


        string requestType = "";
        public string RequestType { get { return requestType; } set { requestType = value; RaisePropertyChanged(); } }
        string requestValue;
        TimeSpan _TotalHours;
        public TimeSpan TotalHours { get { return _TotalHours; } set { _TotalHours = value; RaisePropertyChanged(); } }


        TimeSpan _Timein;
        public TimeSpan Timein
        {
            get { return _Timein; }
            set
            {
                _Timein = value;
                TotalHours = Timeout.Subtract(Timein);
                if (TotalHours < new TimeSpan(0, 0, 0))
                {
                    TotalHours = new TimeSpan(0, 0, 0);
                }




                RaisePropertyChanged();
            }
        }


        public DelegateCommand<PermissionsRequests> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<PermissionsRequests>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.permission.request"
                            };
                            await Cancelrequest(body);
                            await GetPermissionsRequestLst();
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


        TimeSpan _Timeout;
        public TimeSpan Timeout
        {
            get { return _Timeout; }
            set
            {
                _Timeout = value;

                TotalHours = Timeout.Subtract(Timein);
                if (TotalHours < new TimeSpan(0, 0, 0))
                {
                    // TotalHours = Timeout.Add(new TimeSpan(24, 0, 0)).Subtract(Timein);
                    TotalHours = new TimeSpan(0, 0, 0);
                }

                RaisePropertyChanged();
            }
        }

        string business_name_en = "";
        public string Business_name_EN { get { return business_name_en; } set { business_name_en = value; RaisePropertyChanged(); } }

        string business_job_ar = "";
        public string Business_job_ar { get { return business_job_ar; } set { business_job_ar = value; RaisePropertyChanged(); } }

        string business_job_en = "";
        public string Business_job_EN { get { return business_job_en; } set { business_job_en = value; RaisePropertyChanged(); } }


        string business_work_mobile = "";
        public string Business_work_mobile { get { return business_work_mobile; } set { business_work_mobile = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }


        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public PermissionRequestsViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetPermissionsRequestLst();

        }



        public DelegateCommand SelectPermissionTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    //private_leave & leave_work
                    var rs = await DialogService.DisplayActionSheetAsync("Select Permission Type", "Cancel", "", "Leave Work", "Private Leave");
                    if (rs != null && rs != "Cancel")
                    {
                        RequestType = rs;
                        requestValue = RequestType == "Leave Work" ? "leave_work" : "private_leave";
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
            RequestType=requestValue = "";
            
        }

        public DelegateCommand SendRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendPermissionsRequest();
                });
            }
        }


        async Task SendPermissionsRequest()
        {
            try
            {
                IsLoading = true;
               
                    if(TotalHours.TotalMinutes>0&&!string.IsNullOrWhiteSpace(requestValue))
                        {
                            var model = new PermissionsRequestBody()
                            {

                                employee_id = Preferences.Get("userId", 0),
                                 type= requestValue,
                                  date_from=(DateTime.Now.Date +Timein).ToString("yyyy-MM-dd HH:m:ss"),
                                   date_to = (DateTime.Now.Date + Timeout).ToString("yyyy-MM-dd HH:m:ss"),

                            };
                            var body = new BaseOdoModel<PermissionsRequestBody>()
                            {
                                @params = model
                            };
                            var resp = await _onlineServices.SendPermissionRequest(body);
                            var result = await resp.Content.ReadAsStringAsync();
                            if (resp.IsSuccessStatusCode)
                            {
                                CleareNewRequestData();
                                // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await GetPermissionsRequestLst();

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

        async Task GetPermissionsRequestLst()
        {
            try
            {
                // Requests = new ObservableCollection<AccessCardRequests>();
                IsLoading = true;
                var resp = await _onlineServices.PermissionsRequestsLst(new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {
                        employee_id = Preferences.Get("userId", 0)
                    }
                });

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
        public void SetDetailsData(PermissionsRequests data)
        {
            EmployeeName = data.employee_id[1].ToString();
            RequestType = data.type;
            Timein = DateTimeHelper.ConvertStringTodate(data.date_from).TimeOfDay;
             Timeout = DateTimeHelper.ConvertStringTodate(data.date_to).TimeOfDay;

        }



    }

}

