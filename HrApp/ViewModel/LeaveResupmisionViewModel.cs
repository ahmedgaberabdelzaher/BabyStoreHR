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
    public class LeaveResupmisionViewModel:NotificationViewModel
    {

        private DateTime _MiniReDate = DateTime.Now.AddDays(-30);

        public DateTime MiniReDate
        {
            get { return _MiniReDate; }
            set { _MiniReDate = value; RaisePropertyChanged(); }
        }
        string _LEAVE_SERIAL;


        public string LEAVE_SERIAL { get { return _LEAVE_SERIAL; } set { _LEAVE_SERIAL = value; RaisePropertyChanged(); } }
        DateTime _RESUMPTION_DATE = DateTime.Now;
        public DateTime RESUMPTION_DATE { get { return _RESUMPTION_DATE; } set { _RESUMPTION_DATE = value; RaisePropertyChanged(); } }
        int _RESUMPTION_TYPE;
        public int RESUMPTION_TYPE { get { return _RESUMPTION_TYPE; } set { _RESUMPTION_TYPE = value; RaisePropertyChanged(); } }

        string _ResumtionTypeName;
        public string ResumtionTypeName { get { return _ResumtionTypeName; } set { _ResumtionTypeName = value; RaisePropertyChanged(); } }

        string _REMARKS;
        public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; RaisePropertyChanged(); } }


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

        ObservableCollection<ResumptionTypeModel> _ResumptionTypes = new ObservableCollection<ResumptionTypeModel>();
        public ObservableCollection<ResumptionTypeModel> ResumptionTypes { get { return _ResumptionTypes; } set { _ResumptionTypes = value; RaisePropertyChanged(); } }


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
                var resp = await _leaveService.ResumptionDelete(id);
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
                LeaveResumtionsModel detailObjec=new LeaveResumtionsModel();
                if (parameters["details"]!=null)
                {
                    IsShowLeave = true;
                    detailObjec = parameters["details"] as LeaveResumtionsModel;
                    REMARKS = detailObjec.remarks;
                    RESUMPTION_TYPE =detailObjec.resumptioN_TYPE;
                    RefNO = detailObjec.refNO;
                    RESUMPTION_DATE = detailObjec.resumptioN_DATE;
                        StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                        department = detailObjec.department;
                        deleteallow = detailObjec.isEditDeleteAllowed;
                        ResumtionTypeName = detailObjec.resumptionTypeName;
                    if (detailObjec.leaveObject!=null)
                    {
                    LEAVE_SERIAL = detailObjec.leaveObject.refNO;
                    Leave = detailObjec.leaveObject;
                    }
                    
                    id = detailObjec.id;
                }
                else
                {
                   
                        IsLoading = true;
                        string ID = parameters["NotifiRequstID"] as string;
                        if (!string.IsNullOrEmpty(ID))
                        {
                            var result = await _leaveService.GetResumptionsByID(ID);
                          if (result.Item2&&result.Item1.Count>0)
                            {
                                IsShowLeave = true;
                                detailObjec = result.Item1[0] as LeaveResumtionsModel;
                                REMARKS = detailObjec.remarks;
                                RefNO = detailObjec.refNO;
                                StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                                department = detailObjec.department;
                                deleteallow = detailObjec.isEditDeleteAllowed;
                                RESUMPTION_TYPE = detailObjec.resumptioN_TYPE;
                                RESUMPTION_DATE = detailObjec.resumptioN_DATE;
                                ResumtionTypeName = detailObjec.resumptionTypeName;
                                if (detailObjec.leaveObject != null)
                                {
                                    LEAVE_SERIAL = detailObjec.leaveObject.refNO;
                                    Leave = detailObjec.leaveObject;
                                }

                                id = detailObjec.id;

                            }
                        }

                    }
                   
                if (parameters["IsFromManager"]!=null)
                {
                    var isFromManger = parameters["IsFromManager"].ToString();

                    var role = Preferences.Get("role", 0);
                    if ((isFromManger == "1" && detailObjec.hR_APPROVE == 0 && role == 3) || (isFromManger == "1" && detailObjec.hR_DONE == 0 && role == 4 ))
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

                        GetHrOfficers();
                    }
                    if (isFromManger == "1" && detailObjec.hR_APPROVE == 0&& role == 3)
                    {
                        IsHideRject = true;
                    }
                        if (detailObjec.hR_REJECT == 1 )
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
                 GetResumptionTypes();
            }
            await GetLeavesLst();
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

        public LeaveResupmisionViewModel(INotificationServices notificationServices, IUserServices userServices,ILeaveServices leaveService  ,INavigationService navigationService,IPageDialogService pageDialogService):base(notificationServices,navigationService, pageDialogService)
        {
            SendRejectionCommand = new DelegateCommand(async () => { await SendRejection(); });
            SendApproveCommand = new DelegateCommand(async () => { await SendApprove(); });
            _leaveService = leaveService;
            this.notificationServices = notificationServices;
            _userServices = userServices;
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
                        var resp = await _leaveService.LeaveApprove(id, "LeaveResumptionOperations/ResumptionsApprove");
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
        async Task SendRejection()//LeaveResumptionOperations/ResumptionsApprove
        {
            try
            {
                IsLoading = true;
                var res = await DialogService.DisplayAlertAsync("", "Are You sure you want to Reject this request", "Yes", "No");
                if (res)
                {
                    var resp = await _leaveService.LeaveReject(id, "LeaveResumptionOperations/ResumptionsReject");
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
                        LEAVE_SERIAL = rs;
                        var SelectedLeave = Leaves.Where(c => c.refNO == rs).First();
                        LeaveCode = SelectedLeave.id;
                        Leave = SelectedLeave;
                        IsShowLeave  = true;
                    }
                });
            }
        }

        public DelegateCommand SelectResumptionTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var rs = await DialogService.DisplayActionSheetAsync("Select Type", "Cancel", "", ResumptionTypes.Select(c => c.nameEn).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        ResumtionTypeName = rs;
                        var SelectedType = ResumptionTypes.Where(c => c.nameEn == rs).First();
                        RESUMPTION_TYPE = SelectedType.id;
                      
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
                    IsShowLeave = true;
                    Leaves = resp.Item1;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }

         void GetResumptionTypes()
        {
            try
            {
                IsLoading = true;
                ResumptionTypes = new ObservableCollection<ResumptionTypeModel>
                    { new ResumptionTypeModel{id=1,nameEn="Early" },
                     new ResumptionTypeModel{id=2,nameEn="On time" },
                      new ResumptionTypeModel{id=3,nameEn="Late" },
                       new ResumptionTypeModel{id=4,nameEn="Cancel" },
                    };
                
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
                IsLoading = true;

                var model = new LeaveResumptionRequestModel()
                {
                    Department = Preferences.Get("Department", ""),
                     ENTERED_DATE=DateTime.Now,
                      LEAVE_SERIAL=LeaveCode,
                    StaffId = Preferences.Get("userId", 0),
                    REMARKS =REMARKS, RESUMPTION_DATE=RESUMPTION_DATE,RESUMPTION_TYPE=RESUMPTION_TYPE
                    
                };
                var resp = await _leaveService.NewResupmisionLeave(model);
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
