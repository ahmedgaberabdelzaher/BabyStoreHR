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
{//Commitment
    public class StcSubscriptionViewModel:NotificationViewModel
    {
        ObservableCollection<StcTyps> _StcTypes = new ObservableCollection<StcTyps>();
        public ObservableCollection<StcTyps> StcTypes { get { return _StcTypes; } set { _StcTypes = value; RaisePropertyChanged(); } }
        int _stc_TYPE;
        public int stc_TYPE { get { return _stc_TYPE; } set { _stc_TYPE = value; RaisePropertyChanged(); } }

        string _stcTypeName;
        public string stcTypeName { get { return _stcTypeName; } set { _stcTypeName = value; RaisePropertyChanged(); } }
        string _Name;
        public string Name { get { return _Name; } set { _Name = value; RaisePropertyChanged(); } }

        bool _Commitment=false;
        public bool Commitment { get { return _Commitment; } set { _Commitment = value; RaisePropertyChanged(); } }

        DateTime _Date = DateTime.Now;
        public DateTime Date { get { return _Date; } set { _Date = value; RaisePropertyChanged(); } }

      
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
                var resp = await _leaveService.StcSubscriptionDelete(id);
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
                StcSubscriptionLStModel detailObjec = new StcSubscriptionLStModel();
                if (parameters["details"] != null)
                {
                    IsShowLeave = true;
                    detailObjec = parameters["details"] as StcSubscriptionLStModel;
                    REMARKS = detailObjec.Notes;
                    // RESUMPTION_TYPE = (float)detailObjec.resumptioN_TYPE;
                    Date = detailObjec.JoiningDate;
                    Commitment = Boolean.Parse(detailObjec.Commitment);
                        RefNO = detailObjec.RefNO;
                        stcTypeName = detailObjec.ServiceTypeName;

                        reqDate = detailObjec.JoiningDate;
                        deleteallow = detailObjec.isEditDeleteAllowed;
                        Name = detailObjec.Name;
                    StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                        department = detailObjec.department;
                        id = detailObjec.Id;
                }
                else
                {
                  
                        IsLoading = true;
                        string ID = parameters["NotifiRequstID"] as string;
                        if (!string.IsNullOrEmpty(ID))
                        {
                            var result = await _leaveService.GetStcByID(ID);
                            if (result.Item2 && result.Item1.Count > 0)
                            {
                                detailObjec = result.Item1[0] as StcSubscriptionLStModel;
                                REMARKS = detailObjec.Notes;
                                deleteallow = detailObjec.isEditDeleteAllowed;
                                StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;
                                department = detailObjec.department;
                                RefNO = detailObjec.RefNO;
                                deleteallow = detailObjec.isEditDeleteAllowed;
                                reqDate = detailObjec.JoiningDate;
                                // RESUMPTION_TYPE = (float)detailObjec.resumptioN_TYPE;
                                Date = detailObjec.JoiningDate;
                                Commitment = Boolean.Parse(detailObjec.Commitment);
                                Name = detailObjec.Name;
                                stcTypeName = detailObjec.ServiceTypeName;
                                id = detailObjec.Id;

                            }
                        }

                    }
                  
                if (parameters["IsFromManager"] != null)
                {
                    var isFromManger = parameters["IsFromManager"].ToString();

                    var role = Preferences.Get("role", 0);
                    if ((isFromManger == "1" && detailObjec.HR_DONE == 0 && role == 4))
                    {
                        IsActionsVisible = true;
                            if (detailObjec.department == App.HRDEBNAME && role == 3)
                            {
                                IsHideRject = true;

                            }
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
                    var response = await _leaveService.GetTypesOfServices();

                    if (response.Item2)
                    {
                        StcTypes = response.Item1;


                    }
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

        public StcSubscriptionViewModel(INotificationServices notificationServices, IUserServices userServices, ILeaveServices leaveService, INavigationService navigationService, IPageDialogService pageDialogService) : base(notificationServices, navigationService, pageDialogService)
        {
            SendRejectionCommand = new DelegateCommand(async () => { await SendRejection(); });
            SendApproveCommand = new DelegateCommand(async () => { await SendApprove(); });
            _leaveService = leaveService;
            this.notificationServices = notificationServices;
            _userServices = userServices;
          
        }

        int id;
        public DelegateCommand SelectSTCTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var rs = await DialogService.DisplayActionSheetAsync("Select Type", "Cancel", "", StcTypes.Select(c => c.nameEn).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        stcTypeName = rs;
                        var SelectedType = StcTypes.Where(c => c.nameEn == rs).First();
                        stc_TYPE = SelectedType.id;

                    }
                });
            }
        }
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
                        await DialogService.DisplayAlertAsync("", "Please Select Hr Officer", "Ok");
                    }
                    else
                    {
                        var resp = await _leaveService.ApproveStc(id, "StcSubscriptionOperations/SubscriptionApprove");
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
                    var resp = await _leaveService.LeaveReject(id, "LeaveEncashmentOperations/EncashmentReject");
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
                    await SendLeaveRequest();
                });

            }
        }

        async Task SendLeaveRequest()
        {
            try
            {
                IsLoading = true;

                var model = new NewStcSubscriptionModel()
                {
                    Department = Preferences.Get("Department", ""),
                    StuffId = Preferences.Get("userId", 0),
                    Notes = REMARKS,
                    JoiningDate = Date,
                   ServiceType= stc_TYPE,
                    Commitment = Commitment.ToString(),
                    Name = Name

                };
                var resp = await _leaveService.NewStcSubscriptionRequest(model);
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
