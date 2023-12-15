using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Linq;
using HrApp.Helpers;

namespace HrApp.ViewModel.OnlineServicesViewModels
{

    public class BusinessTravelRequestViewModel : DetailsandActionsViewModel<BusinessTravelRequestsLst>
    {
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<BusinessTravelRequestsLst> requests = new ObservableCollection<BusinessTravelRequestsLst>();
        public ObservableCollection<BusinessTravelRequestsLst> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


        ObservableCollection<CustodyProperityLst> travelCovers = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> TravelCovers { get { return travelCovers; } set { travelCovers = value; RaisePropertyChanged(); } }

        ObservableCollection<CustodyProperityLst> selectedTravelCovers = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> SelectedTravelCovers { get { return selectedTravelCovers; } set { selectedTravelCovers = value; RaisePropertyChanged(); } }


        string employeeName;
        public string EmployeeName { get { return employeeName; } set { employeeName = value; RaisePropertyChanged(); } }

        public int employee_id { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string travel_type { get; set; }
        public string way_to_travel { get; set; }
        public string ticket_type { get; set; }
        public List<int> travel_cover_ids { get; set; }

        string requestType;
        public string RequestType { get { return requestType; } set { requestType = value; RaisePropertyChanged(); } }

        string description = "";
        public string Description { get { return description; } set { description = value; RaisePropertyChanged(); } }

        string wayToTravele="";
        public string WayToTravele { get { return wayToTravele; } set { wayToTravele = value; RaisePropertyChanged(); } }

        string WayToTravelevalue;

        string travelType = "";
        public string TravelType { get { return travelType; } set { travelType = value; RaisePropertyChanged(); } }

       string ticketType = "";
        public string TicketType { get { return ticketType; } set { ticketType = value; RaisePropertyChanged(); } }

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


        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        userData selectedEmployee;
        public userData SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; RaisePropertyChanged(); } }

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        double ticketAmount = 0.0;
        public double TicketAmount { get { return ticketAmount; } set { ticketAmount = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public BusinessTravelRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetBusisnessTravelRequestsLst();

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

        public DelegateCommand<BusinessTravelRequestsLst> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<BusinessTravelRequestsLst>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.business.travel.request"
                            };
                            await Cancelrequest(body);
                            await GetBusisnessTravelRequestsLst();
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


        private void SetDetailsData(BusinessTravelRequestsLst data)
        {
            EmployeeName = data.employee_id[1].ToString();
            Description = data.description;
            Eligible_for_ticket = data.eligible_for_ticket;
            TicketType = data.ticket_type;
            WayToTravele = data.way_to_travel;
            TravelType = data.travel_type;
            TomDate = DateTimeHelper.ConvertStringTodateonly(data.date_to);
            FromDate = DateTimeHelper.ConvertStringTodateonly(data.date_from);
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


        public DelegateCommand SelectTravelTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    var rs = await DialogService.DisplayActionSheetAsync("Select Travel Type", "Cancel", "", "Internal", "External");
                    if (rs != null && rs != "Cancel")
                    {
                        TravelType = rs;
                    }
                });
            }
        }

        public DelegateCommand SelectWayToTravelCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    
                    var rs = await DialogService.DisplayActionSheetAsync("Select Way To Travel", "Cancel", "", "Airline", "Car");
                    if (rs != null && rs != "Cancel")
                    {
                        WayToTravele = rs;
                    }
                });
            }
        }

        public DelegateCommand SelectTicketTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    //first/business/economy
                    var rs = await DialogService.DisplayActionSheetAsync("Select Ticket Type", "Cancel", "", "First", "Business", "Economy");
                    if (rs != null && rs != "Cancel")
                    {
                        TicketType = rs;
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
            Description = "";
            Eligible_for_ticket = false;
            TicketType = "";
            WayToTravele = "";
            TravelType = "";
 TomDate = DateTime.Now;
            FromDate = DateTime.Now;
            SelectedTravelCovers = new ObservableCollection<CustodyProperityLst>();
        }

        public DelegateCommand<CustodyProperityLst> UnselectTravelCoverCommand
        {
            get
            {
                return new DelegateCommand<CustodyProperityLst>(async (e) =>
                {
                    if (e!=null&&SelectedTravelCovers!=null&&SelectedTravelCovers.Count>0)
                    {
                        SelectedTravelCovers.Remove(e);
                    }
                });
            }
        }

        public DelegateCommand SendRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendBusisnessTravelRequest();
                });
            }
        }

        public DelegateCommand SelectTravelCoverCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var Data = await GetTravekCovers();
                    if (Data != null)
                    {
                        var rs = await DialogService.DisplayActionSheetAsync("Select Travel Cover", "Cancel", "", Data.Select(c => c.name).ToArray());
                        if (rs != null && rs != "Cancel")
                        {
                            var selectedCover = Data.First(c => c.name == rs);
                            if (!SelectedTravelCovers.Contains(selectedCover))
                            {
                                SelectedTravelCovers.Add(selectedCover);
                            }
                           
                        }
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "No Data Found", "Ok");
                        IsLoading = false;
                    }
                    IsLoading = false;


                });
            }
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

        async Task SendBusisnessTravelRequest()
        {
            try
            {
                IsLoading = true;

                if (!string.IsNullOrWhiteSpace(Description)&& !string.IsNullOrWhiteSpace(TravelType)&& !string.IsNullOrWhiteSpace(WayToTravele))
                {
                    var model = new BuisnessTravelRequestBody()
                    {

                        employee_id = Preferences.Get("userId", 0),
                        description = Description,
                        eligible_for_ticket = Eligible_for_ticket,
                        ticket_type = TicketType.ToLower(),
                        way_to_travel = WayToTravele.ToLower(),
                        travel_type = TravelType.ToLower(),
                        date_to = TomDate.Date.ToString("yyyy-MM-dd"),
                        date_from = FromDate.Date.ToString("yyyy-MM-dd"),
                        travel_cover_ids = SelectedTravelCovers.Select(c => c.id).ToList()
                      
                    };
                    var body = new BaseOdoModel<BuisnessTravelRequestBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendBusinessTravelRequest(body);
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetBusisnessTravelRequestsLst();

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

        async Task GetBusisnessTravelRequestsLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.BusinessTravelRequeststLst(new BaseOdoModel<GetLeavesBody>()
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


    }

}

