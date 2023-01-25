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
    public class LeaveRequestDetailsViewModel:NotificationViewModel
    {

        

        string _LeaaveTypeName;

        public string LeaaveTypeName { get { return _LeaaveTypeName; } set { _LeaaveTypeName = value; RaisePropertyChanged(); } }
        string _refNO;

        public string refNO { get { return _refNO; } set { _refNO = value; RaisePropertyChanged(); } }

        
        string _file="";

        public string file { get { return _file; } set { _file = value; RaisePropertyChanged(); } }

        int _LeaaveTypeCode;
        public int LeaaveTypeCode { get { return _LeaaveTypeCode; } set { _LeaaveTypeCode = value; RaisePropertyChanged(); } }

        DateTime _fromDate;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value; 
                RaisePropertyChanged();
            }
        }

        DateTime _tromDate;
        public DateTime TomDate
        {
            get { return _tromDate; }
            set
            {
                _tromDate = value;
                
                RaisePropertyChanged();
            }
        }

        int _Dayse;
        public int Days { get { return _Dayse; } set { _Dayse = value; RaisePropertyChanged(); } }

        string _PhoneNo;
        public string PhoneNo { get { return _PhoneNo; } set { _PhoneNo = value; RaisePropertyChanged(); } }

        string _Address;
        public string Address { get { return _Address; } set { _Address = value; RaisePropertyChanged(); } }

        string _Note;
        public string Note { get { return _Note; } set { _Note = value; RaisePropertyChanged(); } }

        bool _AdvancedSallary;
        public bool AdvancedSallary { get { return _AdvancedSallary; } set { _AdvancedSallary = value; RaisePropertyChanged(); } }

        bool _InCashment;
        public bool InCashment { get { return _InCashment; } set { _InCashment = value; RaisePropertyChanged(); } }

     bool _IsActionsVisible;
        public bool IsActionsVisible { get { return _IsActionsVisible; } set { _IsActionsVisible = value; RaisePropertyChanged(); } }

        bool _IsPendingOnHrManager;
        public bool IsPendingOnHrManager { get { return _IsPendingOnHrManager; } set { _IsPendingOnHrManager = value; RaisePropertyChanged(); } }

        bool _IsHideRject;
        public bool IsHideRject { get { return _IsHideRject; } set { _IsHideRject = value; RaisePropertyChanged(); } }


        string _DepitizedName;
        public string DepitizedName { get { return _DepitizedName; } set { _DepitizedName = value; RaisePropertyChanged(); } }

        int _DepitizedCode =0;
        public int DepitizedCode { get { return _DepitizedCode; } set { _DepitizedCode = value; RaisePropertyChanged(); } }

        ObservableCollection<HrOfficersModel> empLst = new ObservableCollection<HrOfficersModel>();
        public ObservableCollection<HrOfficersModel> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }


        public DelegateCommand SendApproveCommand { get; set; }
        public DelegateCommand SendRejectionCommand { get; set; }

        bool _IsSHowImage;
        public bool IsSHowImage { get { return _IsSHowImage; } set { _IsSHowImage = value; RaisePropertyChanged(); } }

        public DelegateCommand DeleteItem
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                  await  DeleteAsync();
                });
            }
        }

        private async Task DeleteAsync()
        {
            IsLoading = true;
            try
            {
                var resp = await _leaveServices.LeaveDelete(id);
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

        IUserServices _userServices;
        private readonly INotificationServices notificationServices;
        ILeaveServices _leaveServices;
        public LeaveRequestDetailsViewModel(INotificationServices notificationServices,ILeaveServices leaveServices, IUserServices userServices, INavigationService navigationServices, IPageDialogService pageDialogService) : base(notificationServices ,navigationServices, pageDialogService)
        {
            _userServices = userServices;
            this.notificationServices = notificationServices;
            _leaveServices = leaveServices;
            SendRejectionCommand = new DelegateCommand(async () => { await SendRejection(); });
            SendApproveCommand = new DelegateCommand(async () => { await SendApprove(); });
        }
        int id;
        public async override void Initialize(INavigationParameters parameters)
        {
            try
            {
                LeavesModel detailObjec = new LeavesModel();
                if (parameters != null && parameters.Count > 0)
                {


                    detailObjec = parameters["details"] as LeavesModel;
                    //    string ID = parameters["NotifiRequstID"] as string;
                    if (detailObjec != null)
                    {

                        LeaaveTypeCode = detailObjec.leavE_CODE;
                        LeaaveTypeName = detailObjec.leaveName;
                        FromDate = detailObjec.datE_FROM;
                        TomDate = detailObjec.datE_TO;
                        Days = detailObjec.nO_DAYS;
                        Address = detailObjec.address;
                        department = detailObjec.department;
                        RefNO = detailObjec.refNO;
                        Ballance = detailObjec.balance;
                        StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;reqDate = detailObjec.reQ_DATE;
                        department = detailObjec.department;
                        deleteallow = detailObjec.isEditDeleteAllowed;
                        Note = detailObjec.remarks;
                        PhoneNo = detailObjec.teL_NO;
                        InCashment = detailObjec.incashment;
                        AdvancedSallary = detailObjec.advanceD_SALARY;
                        id = detailObjec.id;
                        file = detailObjec.filecontentstring.Replace(@"C:\temp\HRMobileApp\wwwroot/",App.BaseUrl);
                    }
                    else
                    {

                        IsLoading = true;
                        string ID = parameters["NotifiRequstID"] as string;

                        if (!string.IsNullOrEmpty(ID))
                        {

                            var result = await _leaveServices.GetLeaveByID(ID);
                            if (result.Item2 && result.Item1.Count > 0)
                            {
                                detailObjec = result.Item1[0] as LeavesModel;
                                LeaaveTypeCode = detailObjec.leavE_CODE;
                                LeaaveTypeName = detailObjec.leaveName;
                                FromDate = detailObjec.datE_FROM;
                                TomDate = detailObjec.datE_TO;
                                department = detailObjec.department;
                                Ballance = detailObjec.balance;

                                Days = detailObjec.nO_DAYS;
                                Address = detailObjec.address;
                                StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;reqDate = detailObjec.reQ_DATE;reqDate = detailObjec.reQ_DATE;

                                deleteallow = detailObjec.isEditDeleteAllowed;
                                Note = detailObjec.remarks;
                                RefNO = detailObjec.refNO;
                                PhoneNo = detailObjec.teL_NO;
                                InCashment = detailObjec.incashment;
                                AdvancedSallary = detailObjec.advanceD_SALARY;
                                id = detailObjec.id;
                                file = detailObjec.filecontentstring;
                            }
                        }

                    }

                }
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



                base.Initialize(parameters);

            }
            catch
            { }
            finally
            { IsLoading = false; }
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
        public DelegateCommand SelectLeaveTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var rs = await DialogService.DisplayActionSheetAsync("Select Leave Type", "Cancel", "", App.LeaveTypes.Select(c => c.Name).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        LeaaveTypeName = rs;
                        LeaaveTypeCode = App.LeaveTypes.Where(c => c.Name == rs).First().Id;
                    }
                });
            }
        }



        public DelegateCommand OpenAttatchementCommandCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (file.EndsWith("pdf"))
                    {
                    await openpdfAsync(file);
                    }
                    else
                    {
                        IsSHowImage = true;  
                    }
                });
            }
        }

        public DelegateCommand CloseImageCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                  
                        IsSHowImage = false;
                    
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
       
        async Task SendApprove()
        {
            try
            {
                IsLoading = true;

                var res =await DialogService.DisplayAlertAsync("", "Are You sure you want to approve this request", "Yes", "No");
                if (res)
                {
                    if (DepitizedCode == 0 && IsPendingOnHrManager)
                    {
                        IsLoading = false;
                        await DialogService.DisplayAlertAsync("", "Please Select HR Officer", "Ok");
                    }
                    else
                    {
                        var resp = await _leaveServices.LeaveApprove(id, DepitizedCode);
                        if (resp.IsSuccessStatusCode)
                        {
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
        async Task SendRejection()
        {
            try
            {
                IsLoading = true;
                var res = await DialogService.DisplayAlertAsync("", "Are You sure you want to Reject this request", "Yes", "No");
                if (res)
                {
                    var resp = await _leaveServices.LeaveReject(id);
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
    }
}
