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

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class ExitReEntryVISARequestViewModel : DetailsandActionsViewModel<ExitReEntryRequest>
    {

        ObservableCollection<ExitReEntryRequest> requests = new ObservableCollection<ExitReEntryRequest>();
        public ObservableCollection<ExitReEntryRequest> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


        string employeeName;
        public string EmployeeName { get { return employeeName; } set { employeeName = value; RaisePropertyChanged(); } }


        string requestType;
        public string RequestType { get { return requestType; } set { requestType = value; RaisePropertyChanged(); } }

        string durationType = "";
        public string DurationType { get { return durationType; } set { durationType = value; RaisePropertyChanged(); } }

        string wayToTravele = "";
        public string WayToTravele { get { return wayToTravele; } set { wayToTravele = value; RaisePropertyChanged(); } }

        string WayToTravelevalue;

        string travelType = "";
        public string TravelType { get { return travelType; } set { travelType = value; RaisePropertyChanged(); } }

        int duration = 0;
        public int Duration { get { return duration; } set { duration = value; RaisePropertyChanged(); } }

        bool eligible_for_ticket;
        public bool Eligible_for_ticket { get { return eligible_for_ticket; } set { eligible_for_ticket = value; RaisePropertyChanged(); } }

        DateTime _fromDate = DateTime.Now; /*DateTime.Parse( DateTime.Now.ToString("dd MM yyyy"));*/
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {

                _fromDate = value;
                RaisePropertyChanged();
            }
        }

        DateTime _tromDate = DateTime.Now;
        public DateTime TomDate
        {
            get
            {

                return _tromDate;
            }
            set
            {
                _tromDate = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand<ExitReEntryRequest> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<ExitReEntryRequest>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.leave.return.request"
                            };
                            await Cancelrequest(body);
                            await GetExitReEntryRequestLst();
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


        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        userData selectedEmployee;
        public userData SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; RaisePropertyChanged(); } }

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        double ticketAmount = 0.0;
        public double TicketAmount { get { return ticketAmount; } set { ticketAmount = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public ExitReEntryVISARequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetExitReEntryRequestLst();

        }






   
        public DelegateCommand SelectDurationTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    //first/business/economy
                    var rs = await DialogService.DisplayActionSheetAsync("Select Duration Type", "Cancel", "", "day", "month");
                    if (rs != null && rs != "Cancel")
                    {
                        DurationType = rs;
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





        async Task<ObservableCollection<CustodyProperityLst>> GetTravekCovers()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.GetTravelCovers(new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {

                    }
                });

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

        public DelegateCommand SendRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendExitReEntryRequest();
                });
            }
        }
        async Task SendExitReEntryRequest()
        {
            try
            {
                IsLoading = true;

                if (!string.IsNullOrWhiteSpace(DurationType) && Duration>0)
                {
                    var model = new ExitReEntryRequestBody()
                    {

                        employee_id = Preferences.Get("userId", 0),
                         duration=Duration,
                          duration_type=DurationType,
                           
                        leave_to = TomDate.Date.ToString("yyyy-MM-dd"),
                        leave_from = FromDate.Date.ToString("yyyy-MM-dd")

                    };
                    var body = new BaseOdoModel<ExitReEntryRequestBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendExitReEntryRequest(body);
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetExitReEntryRequestLst();

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

        async Task GetExitReEntryRequestLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.ExitReEntryRequestLst(new BaseOdoModel<GetLeavesBody>()
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
        public void SetDetailsData(ExitReEntryRequest data)
        {
            Duration = data.duration;
            DurationType = data.duration_type;
            TomDate= DateTime.Parse(data.leave_to);
            FromDate = DateTime.Parse(data.leave_from);
            EmployeeName = data.employee_id[1].ToString();

        }




    }

}

