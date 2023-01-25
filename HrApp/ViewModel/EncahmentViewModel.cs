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
    public class EncahmentViewModel : NotificationViewModel
    {

        string _Name;
        private bool _approveprop =true;

        public bool approveprop
        {
            get { return _approveprop ; }
            set { _approveprop  = value; RaisePropertyChanged(); }
        }

        public string Name { get { return _Name; } set { _Name = value; RaisePropertyChanged(); } }
        DateTime _Date = DateTime.Now;
        public DateTime Date { get { return _Date; } set { _Date = value; RaisePropertyChanged(); } }

        string _ApprovedComments;
        public string ApprovedComments { get { return _ApprovedComments; } set { _ApprovedComments = value; RaisePropertyChanged(); } }


        string _REMARKS;
        public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; RaisePropertyChanged(); } }

        int _Days;
        public int Days { get { return _Days; } set { _Days = value; RaisePropertyChanged(); } }

        int _ApprovedDays;
        public int ApprovedDays { get { return _ApprovedDays; } set { _ApprovedDays = value; RaisePropertyChanged(); } }


        string _DepitizedName;
        public string DepitizedName { get { return _DepitizedName; } set { _DepitizedName = value; RaisePropertyChanged(); } }

        int _DepitizedCode = 0;
        public int DepitizedCode { get { return _DepitizedCode; } set { _DepitizedCode = value; RaisePropertyChanged(); } }

        ObservableCollection<HrOfficersModel> empLst = new ObservableCollection<HrOfficersModel>();
        public ObservableCollection<HrOfficersModel> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

       

        public DelegateCommand SendApproveCommand { get; set; }
        public DelegateCommand SendRejectionCommand { get; set; }

        private readonly INotificationServices notificationServices;
        IUserServices _userServices;

        ILeaveServices _leaveService;

        ObservableCollection<LeavesModel> leaves = new ObservableCollection<LeavesModel>();
        public ObservableCollection<LeavesModel> Leaves { get { return leaves; } set { leaves = value; RaisePropertyChanged(); } }

        LeavesModel leave;
        public LeavesModel Leave { get { return leave; } set { leave = value; RaisePropertyChanged(); } }

   
        bool isShowLeave;
        public bool IsShowLeave { get { return isShowLeave; } set { isShowLeave = value; RaisePropertyChanged(); } }
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
                var resp = await _leaveService.EncashmentDelete(id);
                if (resp.IsSuccessStatusCode)
                {

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
                    EncashmentLeaves detailObjec = new EncashmentLeaves();
                    if (parameters["details"] != null)
                    {
                        IsShowLeave = true;
                        detailObjec = parameters["details"] as EncashmentLeaves;
                        REMARKS = detailObjec.notes;
                        Ballance = detailObjec.balance;
                        department = detailObjec.department;
                        ApprovedComments = detailObjec.APPROVED_Comments;
                        // RESUMPTION_TYPE = (float)detailObjec.resumptioN_TYPE;
                        reqDate = detailObjec.date;
                        Days = detailObjec.encashment_Days;
                        deleteallow = detailObjec.isEditDeleteAllowed;
                        StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                        RefNO = detailObjec.refNO;
                        ApprovedDays = detailObjec.APPROVED_Encashment_Days;
                        Name = detailObjec.name;
                        id = detailObjec.id;
                    }
                    else
                    {

                        IsLoading = true;
                        string ID = parameters["NotifiRequstID"] as string;
                        if (!string.IsNullOrEmpty(ID))
                        {
                            var result = await _leaveService.GetEncashmentByID(ID);
                            if (result.Item2 && result.Item1.Count > 0)
                            {
                                IsShowLeave = true;
                                detailObjec = result.Item1[0] as EncashmentLeaves;
                                REMARKS = detailObjec.notes;
                                Ballance = detailObjec.balance;
                                department = detailObjec.department;
                                ApprovedComments = detailObjec.APPROVED_Comments;

                                // RESUMPTION_TYPE = (float)detailObjec.resumptioN_TYPE;
                                reqDate = detailObjec.date;
                                Days = detailObjec.encashment_Days;
                                deleteallow = detailObjec.isEditDeleteAllowed;
                                StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                                RefNO = detailObjec.refNO;
                                ApprovedDays = detailObjec.APPROVED_Encashment_Days;
                                Name = detailObjec.name;
                                id = detailObjec.id;

                            }
                        }

                    }
                    if (parameters["IsFromManager"] != null)
                    {
                        DaysIenbled = false;
                        var isFromManger = parameters["IsFromManager"].ToString();

                        var role = Preferences.Get("role", 0);
                        if ((isFromManger == "1" && detailObjec.hR_APPROVE == 0 && role == 3) || (isFromManger == "1" && detailObjec.hR_DONE == 0 && role == 4 && detailObjec.hR_APPROVE == 1))
                        {
                            IsActionsVisible = true; 
                            if (detailObjec.department == App.HRDEBNAME && role == 3)
                            {
                                IsHideRject = true;

                            }

                        }
                        if ((isFromManger == "1" && detailObjec.hR_APPROVE == 0 && role == 3))
                        {
                            IsPendingOnHrManager = true;
                            ApprovedDays = detailObjec.encashment_Days;


                            GetHrOfficers();
                        }
                        if (isFromManger == "1" && detailObjec.hR_APPROVE == 0 && role == 3)
                        {
                            IsHideRject = true;
                          

                        }
                        if (role == 3&& detailObjec.hR_APPROVE==0) {
                            DaysIenbled = true; 
                        }
                        if (detailObjec.hR_REJECT == 1 )
                        {
                            IsActionsVisible = false;
                        }
                        if (isFromManger == "0")
                        { 
                            IsEmployee = false;
                            DaysIenbled = false;
                        }
                        


                    }
                else
                {
                        

                    }

                base.OnNavigatedTo(parameters);
            }
                else
                {
                    approveprop = false;
                     IsEmployee = true;
                    var role = Preferences.Get("role", 0);
                    if (role == 3)
                    {
                        DaysIenbled = true;
                    }
                }
            }
                    catch
                    { }
                    finally
                    { IsLoading = false; } }
    bool _IsActionsVisible;
        public bool IsActionsVisible { get { return _IsActionsVisible; } set { _IsActionsVisible = value; RaisePropertyChanged(); } }

        bool _IsPendingOnHrManager;
        public bool IsPendingOnHrManager { get { return _IsPendingOnHrManager; } set { _IsPendingOnHrManager = value; RaisePropertyChanged(); } }

        bool _IsHideRject;
        public bool IsHideRject { get { return _IsHideRject; } set { _IsHideRject = value; RaisePropertyChanged(); } }

        public EncahmentViewModel(INotificationServices notificationServices,IUserServices userServices, ILeaveServices leaveService, INavigationService navigationService, IPageDialogService pageDialogService) : base(notificationServices, navigationService, pageDialogService)
        {
            SendRejectionCommand = new DelegateCommand(async () => { await SendRejection(); });
            SendApproveCommand = new DelegateCommand(async () => { await SendApprove(); });
            _leaveService = leaveService;
            this.notificationServices = notificationServices;
            _userServices = userServices;

        }
        public async override void Initialize(INavigationParameters parameters)
        {
            var user = await _userServices.Getuserinfo();
            if (user != null && user.Item2)
            {
                Ballance = user.Item1.leavE_BALANCE;
                Preferences.Set("Ballance", Ballance);

            }
            base.Initialize(parameters);    

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
                        IsShowLeave = true;
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
                    empLst = resp.Item1;
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
                if (ApprovedDays > 0 && ApprovedDays <= Days)
                {
                    var res = await DialogService.DisplayAlertAsync("", "Are You sure you want to approve this request", "Yes", "No");
                    if (res)
                    {
                        if (DepitizedCode == 0 && IsPendingOnHrManager)
                        {
                            IsLoading = false;
                            await DialogService.DisplayAlertAsync("", "Please Select HR Officer", "Ok");
                        }
                        else
                        {//, ApprovedDays, ApprovedComments
                            var resp = await _leaveService.LeaveApprove(id, DepitizedCode, "LeaveEncashmentOperations/EncashmentApprove", ApprovedDays, ApprovedComments);
                            if (resp.IsSuccessStatusCode)
                            {
                                var result = await resp.Content.ReadAsStringAsync();
                                await DialogService.DisplayAlertAsync("",stringrequstapproved, "Ok");
                                await GetNotificationList(this.notificationServices);
                                await NavigationService.GoBackAsync();
                            }
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
        async Task SendRejection()
        {
            try
            {
                IsLoading = true;
                var res = await DialogService.DisplayAlertAsync("", "Are You sure you want to Reject this request", "Yes", "No");
                if (res)
                {
                    var resp = await _leaveService.LeaveReject(id,"LeaveEncashmentOperations/EncashmentReject");
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

        public DelegateCommand SendLeaveRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendLeaveRequest();
                });

            }
        }
        public int LeaveCode { get; set; }
        public DelegateCommand SelectLeaveCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var rs = await DialogService.DisplayActionSheetAsync("Select Leave", "Cancel", "", Leaves.Select(c => c.refNO).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                       // LEAVE_SERIAL = rs;
                        var SelectedLeave = Leaves.Where(c => c.refNO == rs).First();
                        LeaveCode = SelectedLeave.id;
                        Leave = SelectedLeave;

                    }
                });
            }
        }

        async Task GetLeavesLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _leaveService.GetLeaveRequestsByEmp();
                if (resp.Item2)
                {
                    Leaves = resp.Item1;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }


        async Task SendLeaveRequest()
        {
            try
            {
                /* if (Ballance < Days)
                 {
                     await DialogService.DisplayAlertAsync("Alert", "The No of Days should not exceed your Leave Balance.", "Cancle");


                 }
                 else
                 {*/
                if (Days > 0)
                {
                    if (Days > Ballance)
                    {
                        await DialogService.DisplayAlertAsync("Alert", "The number of days should not exceed  Balance", "Cancel");

                    }
                    else
                    {
                        IsLoading = true;

                        var model = new EncashmentLeaveModel()
                        {
                            Department = Preferences.Get("Department", ""),
                            StuffId = Preferences.Get("userId", 0),
                            Notes = REMARKS,
                            Date = Date,

                            Encashment_Days = Days,
                            LeaveBalance = Ballance,
                            Name = Name

                        };
                        var resp = await _leaveService.NewEncashmentLeave(model);
                        if (resp.IsSuccessStatusCode)
                        {
                            var result = await resp.Content.ReadAsStringAsync();
                            await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                            await NavigationService.GoBackAsync();
                        }
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
        }

    
}
