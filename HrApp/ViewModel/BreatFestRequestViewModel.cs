using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using HrApp.Model;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace HrApp.ViewModel
{
    public class BreatFestRequestViewModel:NotificationViewModel
    {

      string _Name;
        public string Name { get { return _Name; } set { _Name = value; RaisePropertyChanged(); } }

        DateTime _fromDate = DateTime.Now;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                TomDate = value.AddMonths(3);
                RaisePropertyChanged();
            }
        }

        DateTime _tromDate = DateTime.Now;
        public DateTime TomDate
        {
            get { return FromDate.AddMonths(3); }
            set
            {
                _tromDate = value;
                RaisePropertyChanged();
            }
        }

        string _REMARKS;
        public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; RaisePropertyChanged(); } }


        string _DepitizedName;
        public string DepitizedName { get { return _DepitizedName; } set { _DepitizedName = value; RaisePropertyChanged(); } }

        int _DepitizedCode = 0;
        public int DepitizedCode { get { return _DepitizedCode; } set { _DepitizedCode = value; RaisePropertyChanged(); } }

       

        public DelegateCommand SendApproveCommand { get; set; }
        public DelegateCommand SendRejectionCommand { get; set; }

        private readonly INotificationServices notificationServices;
        IUserServices _userServices;

        ILeaveServices _leaveService;
        public DelegateCommand DeleteItem
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await DeleteAsync();
                });
            }
        }

        private async Task DeleteAsync()
        {
            IsLoading = true;
            try
            {
                var resp = await _leaveService.BreastDelete(id);
                if (resp.IsSuccessStatusCode)
                {

                    await DialogService.DisplayAlertAsync("", "Deleted successfully", "Ok");
                    await NavigationService.GoBackAsync();
                }
                else
                {
                    await DialogService.DisplayAlertAsync("", resp.Content.ToString(), "cancel");

                }
            }
            catch (Exception ex)
            {
                await DialogService.DisplayAlertAsync("", ex.Message, "cancel");

            }
            finally { IsLoading = false; }
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                if (parameters != null && parameters.Count > 0)
                {
                    BreastFeedingListModel detailObjec = new BreastFeedingListModel();
                    if (parameters["details"] != null)
                    {
                        detailObjec = parameters["details"] as BreastFeedingListModel;
                        REMARKS = detailObjec.Notes;
                        Name = detailObjec.Name;
                        FromDate = detailObjec.StartDate;
                        RefNO = detailObjec.RefNO;
                        reqDate= detailObjec.StartDate;
                        TomDate = detailObjec.EndDate;
                        StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                        department = detailObjec.department;
                        deleteallow = detailObjec.isEditDeleteAllowed;

                        id = detailObjec.Id;
                    }
                    else
                    {

                        IsLoading = true;
                        string ID = parameters["NotifiRequstID"] as string;
                        if (!string.IsNullOrEmpty(ID))
                        {
                            var result = await _breadFestService.GetBreatFestByID(ID);
                            if (result.Item2 && result.Item1.Count > 0)
                            {
                                detailObjec = result.Item1[0] as BreastFeedingListModel;
                                REMARKS = detailObjec.Notes;
                                Name = detailObjec.Name;
                                StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                                department = detailObjec.department;
                                deleteallow = detailObjec.isEditDeleteAllowed;
                                reqDate = detailObjec.StartDate;
                                RefNO =  detailObjec.RefNO;
                                FromDate = detailObjec.StartDate;
                                TomDate = detailObjec.EndDate;
                                
                                id = detailObjec.Id;

                            }
                        }

                    }


                    if (parameters["IsFromManager"] != null)
                    {
                        var isFromManger = parameters["IsFromManager"].ToString();

                        var role = Preferences.Get("role", 0);
                        if ((isFromManger == "1" && detailObjec.mnG_APPROVE == 0 && role == 2) || (isFromManger == "1" && detailObjec.hR_APPROVE == 0 && role == 3 ) || (isFromManger == "1" && detailObjec.hR_DONE == 0 && role == 4 && detailObjec.mnG_APPROVE == 1))
                        {
                            IsActionsVisible = true;
                            if (detailObjec.department == App.HRDEBNAME && role == 3)
                            {
                                IsHideRject = true;

                            }
                        }
                        if ((isFromManger == "1" && detailObjec.hR_APPROVE == 0 && role == 3 ))
                        {
                            IsPendingOnHrManager = true;

                            GetHrOfficers();
                        }
                        if (isFromManger == "1" && detailObjec.mnG_APPROVE == 0 && role == 2)
                        {
                            IsHideRject = true;
                        }
                        if ( detailObjec.manageR_PREVENT == 1)
                        {
                            IsActionsVisible = false;
                        }
                        if (isFromManger == "0")
                        {
                            IsEmployee = false;
                        }
                    }

                }
                else
                {
                    IsEmployee = true;

                }

                base.OnNavigatedTo(parameters);
            }
            catch
            { }
            finally
            { IsLoading = false; }
        }
    bool _IsActionsVisible;
        public bool IsActionsVisible { get { return _IsActionsVisible; } set { _IsActionsVisible = value; RaisePropertyChanged(); } }

        bool _IsPendingOnHrManager;
        public bool IsPendingOnHrManager { get { return _IsPendingOnHrManager; } set { _IsPendingOnHrManager = value; RaisePropertyChanged(); } }

        bool _IsHideRject;
        public bool IsHideRject { get { return _IsHideRject; } set { _IsHideRject = value; RaisePropertyChanged(); } }

        bool _IsshowLeave;
        public bool IsshowLeave { get { return _IsshowLeave; } set { _IsshowLeave = value; RaisePropertyChanged(); } }
        IOnlineServices _breadFestService;
        public BreatFestRequestViewModel(INotificationServices notificationServices, IUserServices userServices, ILeaveServices leaveService,IOnlineServices breadFestService, INavigationService navigationService, IPageDialogService pageDialogService) : base( notificationServices,navigationService, pageDialogService)
        {
            SendRejectionCommand = new DelegateCommand(async () => { await SendRejection(); });
            SendApproveCommand = new DelegateCommand(async () => { await SendApprove(); });
            _leaveService = leaveService;
            this.notificationServices = notificationServices;
            _userServices = userServices;
             _breadFestService = breadFestService;
        }

        public DelegateCommand SelectDeoitizerCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var rs = await DialogService.DisplayActionSheetAsync("Select Name", "Cancel", "", EmpLst.Select(c => c.name).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        DepitizedName = rs;
                        DepitizedCode = EmpLst.Where(c => c.name == rs).First().staff_id;
                    }
                });
            }
        }

        async Task GetHrOfficers()
        {
            try
            {
                IsLoading = true;

                var resp = await _userServices.GetHrOfficers();
                if (resp.Item2)
                {
                    EmpLst = resp.Item1;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsLoading = false;
            }
        }
        int id;
        async Task SendApprove()
        {
            try
            {
                IsLoading = true;

                var res = await DialogService.DisplayAlertAsync("", "Are You sure you want to approve this request", "Yes", "No");
                if (res)
                {
                    if (DepitizedCode == 0 && IsPendingOnHrManager)
                    {
                        IsLoading = false;
                        await DialogService.DisplayAlertAsync("", "Please Select HR Officer", "Ok");
                    }
                    else
                    {
                        var resp = await _leaveService.LeaveApprove(id, DepitizedCode, "BreastfeedingRequestOperations/BreastApprove");
                        if (resp.IsSuccessStatusCode)
                        {
                            await GetNotificationList(this.notificationServices);
                            var result = await resp.Content.ReadAsStringAsync();
                            await DialogService.DisplayAlertAsync("", stringrequstapproved, "Ok");
                            await GetNotificationList(this.notificationServices);
                            await NavigationService.GoBackAsync();
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsLoading = false;
            }

        }
        async Task SendRejection()//LeaveResumptionOperations/ResumptionsApprove
        {
            try
            {
                IsLoading = true;
                var res = await DialogService.DisplayAlertAsync("", "Are You sure you want to Reject this request", "Yes", "No");
                if (res)
                {
                    var resp = await _leaveService.LeaveReject(id, "BreastfeedingRequestOperations/BreastReject");
                    if (resp.IsSuccessStatusCode)
                    {
                        var result = await resp.Content.ReadAsStringAsync();
                        await DialogService.DisplayAlertAsync("", stringrequstrejected, "Ok");
                        await NavigationService.GoBackAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
            finally
            {
                IsLoading = false;

            }

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

                var model = new BreastFeedingRequestModel()
                {
                    Department = Preferences.Get("Department", ""),
                    EndDate = TomDate,
                    StartDate = FromDate,
                    StuffId = Preferences.Get("userId", 0),
                    Notes = REMARKS, Name=Name
                            };
                var resp = await _breadFestService.NewBreatFestRequest(model);
                if (resp.IsSuccessStatusCode)
                {
                    var result = await resp.Content.ReadAsStringAsync();
                    await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                    await NavigationService.GoBackAsync();
                }
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
            finally
            {
                IsLoading = false;
            }

        }

    }
}
