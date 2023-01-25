using System;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using HrApp.Model;
using Xamarin.Essentials;
using System.Linq;
using System.Threading.Tasks;
using Prism.Services;

namespace HrApp.ViewModel
{
      public class PermisionToLeaveNewRequestViewModel : NotificationViewModel
    {

     

        string _Reason;
        public string Reason { get { return _Reason; } set { _Reason = value; RaisePropertyChanged(); } }

        string _TotalPermision;
        public string TotalPermision { get { return _TotalPermision; } set { _TotalPermision = value; RaisePropertyChanged(); } }

        TimeSpan _TotalHours;
        public TimeSpan TotalHours { get { return _TotalHours; } set { _TotalHours = value; RaisePropertyChanged(); } }


        TimeSpan _Timein ;
        public TimeSpan Timein
        {
            get { return _Timein; }
            set
            {
                _Timein = value;
                TotalHours = Timeout.Subtract(Timein);
                if (TotalHours< new TimeSpan(0, 0, 0))
                {
                    // TotalHours = Timeout.Add(new TimeSpan(24, 0, 0)).Subtract(Timein);
                    TotalHours = new TimeSpan(0, 0, 0);
                }
              



                RaisePropertyChanged();
            }
        }




        TimeSpan _Timeout ;
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



        /*  TimeSpan _fromtime ;
          public TimeSpan FroTime
          {
              get { return _fromtime; }
              set
              {
                  if (value <= ToTime)
                  {
                      TotalHours = ToTime-value;
                      _fromtime = value;
                  }
                  RaisePropertyChanged();
              }
          }
  */
        /*  TimeSpan _toTime ; 
          public TimeSpan ToTime
          {
              get { return _toTime; }
              set
              {
                  if (value>=FroTime)
                  {

                      TotalHours = value - FroTime;
                      _toTime = value;
                  }

                  RaisePropertyChanged();
              }
          }*/

        string _REMARKS;
        public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; RaisePropertyChanged(); } }


        string _DepitizedName;
        public string DepitizedName { get { return _DepitizedName; } set { _DepitizedName = value; RaisePropertyChanged(); } }

        int _DepitizedCode = 0;
        public int DepitizedCode { get { return _DepitizedCode; } set { _DepitizedCode = value; RaisePropertyChanged(); } }

        private DateTime _perdate =DateTime.Now;

        public DateTime Perdate
        {
            get { return _perdate; }
            set { _perdate = value; RaisePropertyChanged(); }
        }

        private DateTime _mindate=DateTime.Now.AddDays(-30);

        public DateTime mindate
        {
            get { return _mindate; }
            set { _mindate = value; RaisePropertyChanged(); }
        }


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
                var resp = await _OnlineServices.PermissionToLeaveDelete(id);
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
                PermissionsToLeaveLst detailObjec = new PermissionsToLeaveLst();
                if (parameters["details"] != null)
                {
                    detailObjec = parameters["details"] as PermissionsToLeaveLst;
                    Reason = detailObjec.REASON;
                    TotalPermision = detailObjec.TOTAL_PERM;
                    Timeout =detailObjec.TIME_IN;
                    Timein =detailObjec.TIME_OUT;
                        StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                        department = detailObjec.department;
                        RefNO = detailObjec.RefNO;
                        deleteallow = detailObjec.isEditDeleteAllowed;
                        reqDate = detailObjec.REQUEST_DATE;
                        Perdate = detailObjec.LeavePermissionDate;

                        id = detailObjec.Id;
                }
                else
                {
                   
                        IsLoading = true;
                        string ID = parameters["NotifiRequstID"] as string;
                        if (!string.IsNullOrEmpty(ID))
                        {
                            var result = await _OnlineServices.GetPermitionsToLeaveByID(ID);
                            if (result.Item2 && result.Item1.Count > 0)
                            {
                                detailObjec = result.Item1[0] as PermissionsToLeaveLst;
                                Reason = detailObjec.REASON;
                                TotalPermision = detailObjec.TOTAL_PERM;
                                Timeout = detailObjec.TIME_IN;
                                Timein = detailObjec.TIME_OUT;
                                reqDate = detailObjec.REQUEST_DATE;
                                deleteallow = detailObjec.isEditDeleteAllowed;
                                StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                                department = detailObjec.department;
                                RefNO = detailObjec.RefNO;
                                id = detailObjec.Id;
                                Perdate = detailObjec.LeavePermissionDate;

                            }
                        }

                    }
                



                if (parameters["IsFromManager"] != null)
                {
                    var isFromManger = parameters["IsFromManager"].ToString();

                    var role = Preferences.Get("role", 0);
                    if ((isFromManger == "1" && detailObjec.MNG_APPROVE == 0 && role == 2) || (isFromManger == "1" && detailObjec.HR_APPROVE == 0 && role == 3 ) || (isFromManger == "1" && detailObjec.HR_DONE == 0 && role == 4 && detailObjec.MNG_APPROVE == 1))
                    {
                        IsActionsVisible = true;
                            if (detailObjec.department == App.HRDEBNAME && role == 3)
                            {
                                IsHideRject = true;

                            }
                        }
                    if ((isFromManger == "1" && detailObjec.HR_APPROVE == 0 && role == 3))
                    {
                        IsPendingOnHrManager = true;

                        GetHrOfficers();
                    }
                        if (detailObjec.MANAGER_PREVENT == 1)
                        {
                            IsActionsVisible = false;
                        }
                        if (isFromManger == "1" && detailObjec.MNG_APPROVE == 0 && role == 2)
                    {
                        IsHideRject = true;
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
        IOnlineServices _OnlineServices;
        public PermisionToLeaveNewRequestViewModel(INotificationServices notificationServices,IUserServices userServices, ILeaveServices leaveService, IOnlineServices OnlineServices, INavigationService navigationService, IPageDialogService pageDialogService) : base(notificationServices, navigationService, pageDialogService)
        {
            SendRejectionCommand = new DelegateCommand(async () => { await SendRejection(); });
            SendApproveCommand = new DelegateCommand(async () => { await SendApprove(); });
            _leaveService = leaveService;
            this.notificationServices = notificationServices;
            _userServices = userServices;
            _OnlineServices = OnlineServices;
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
                        var resp = await _leaveService.LeaveApprove(id, DepitizedCode, "PermissionToLeaveOperations/PermissionToLeaveApprove");
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
                    var resp = await _leaveService.LeaveReject(id, "PermissionToLeaveOperations/PermissionToLeaveReject");
                    if (resp.IsSuccessStatusCode)
                    {
                        var result = await resp.Content.ReadAsStringAsync();
                        await DialogService.DisplayAlertAsync("",stringrequstrejected, "Ok");
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
        async Task SendRequest()
        {
            try
            {
                IsLoading = true;
                if (TotalHours.TotalHours > 0)
                {
                    if (TotalHours.TotalHours > 8)
                    {
                        await DialogService.DisplayAlertAsync("Alert", "Maximum total hours for Prmission to Leave should be 8 hours", "Ok");

                    }

                    else
                    {


                        var model = new PermissionToLeaveRequestModel()
                        {
                            Department = Preferences.Get("Department", ""),
                            TIME_IN = Timeout,
                            TIME_OUT = Timein,
                            STAFF_ID = Preferences.Get("userId", 0),
                            REASON = Reason,

                            TOTAL_PERM = TotalPermision,
                            ENTERED_BY = Preferences.Get("userId", 0),
                            REQUEST_DATE = DateTime.Now,
                            LeavePermissionDate = Perdate



                        };
                        var resp = await _OnlineServices.NewPermissionToLeave(model);
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
