using System;
using System.Collections.Generic;
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
        public class CertificateNewRequestViewModel : NotificationViewModel
        {

            string _CertTypeName;
            public string CertTypeName { get { return _CertTypeName; } set { _CertTypeName = value; RaisePropertyChanged(); } }

        int _CertTypeId;
        public int CertTypeId{ get { return _CertTypeId; } set { _CertTypeId = value; RaisePropertyChanged(); } }

        string _LangName;
        public string LangName { get { return _LangName; } set { _LangName = value; RaisePropertyChanged(); } }

        int _LangId;
        public int LangId { get { return _LangId; } set { _LangId = value; RaisePropertyChanged(); } }


        string _REMARKS;
            public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; RaisePropertyChanged(); } }

        bool _Sallary;
        public bool Sallary { get { return _Sallary; } set { _Sallary = value; RaisePropertyChanged(); } }

        bool _IncludeBank;
        public bool IncludeBank { get { return _IncludeBank; } set { _IncludeBank = value; RaisePropertyChanged(); } }
        bool _InCashment;
        public bool InCashment { get { return _InCashment; } set { _InCashment = value; RaisePropertyChanged(); } }
        bool _Bank;
        public bool Bank { get { return _Bank; } set { _Bank = value; RaisePropertyChanged(); } }

        string _BankName ;
        public string BankName { get { return _BankName; } set { _BankName = value; RaisePropertyChanged(); } }

  
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
                var resp = await _leaveService.CertificateDelete(id);
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
                    CertificateLstModel detailObjec = new CertificateLstModel();
                    if (parameters["details"] != null)
                    {
                        detailObjec = parameters["details"] as CertificateLstModel;
                        id = detailObjec.id;
                        REMARKS = detailObjec.remarks;
                        CertTypeName = detailObjec.cerT_TYPE_NAME;
                        StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;reqDate = detailObjec.requesT_DATE;
                        department = detailObjec.department;
                        IncludeBank= detailObjec.bank;
                        InCashment = detailObjec.salary;

                        deleteallow = detailObjec.isEditDeleteAllowed;
                        BankName = detailObjec.banK_Name;
                        RefNO = detailObjec.refNO;
                    Sallary = detailObjec.salary;
                    LangName = lang.Find(c=>c.id== detailObjec.lang).Name;

                        id = detailObjec.id;
                }
                else
                {
                   
                        IsLoading = true;
                        string ID = parameters["NotifiRequstID"] as string;
                        if (!string.IsNullOrEmpty(ID))
                        {
                            var result = await _breadFestService.GetCertificateByID(ID);
                            if (result.Item2 && result.Item1.Count > 0)
                            {
                                detailObjec = result.Item1[0] as CertificateLstModel;
                                REMARKS = detailObjec.remarks;
                                id = detailObjec.id;

                                CertTypeName = detailObjec.cerT_TYPE_NAME;
                                BankName = detailObjec.banK_Name;
                                StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;reqDate = detailObjec.requesT_DATE;
                                department = detailObjec.department;
                                deleteallow = detailObjec.isEditDeleteAllowed;
                                IncludeBank = detailObjec.bank;
                                InCashment = detailObjec.salary;
                                RefNO = detailObjec.refNO;
                                Sallary = detailObjec.salary;
                                LangName = lang.Find(c => c.id == detailObjec.lang).Name;

                                id = detailObjec.id;

                            }
                        }

                    }
                   
                if (parameters["IsFromManager"] != null)
                    {
                        var isFromManger = parameters["IsFromManager"].ToString();

                        var role = Preferences.Get("role", 0);
                        if ((isFromManger == "1" && detailObjec.hR_APPROVE == 0 && role == 3) || (isFromManger == "1" && detailObjec.hR_DONE == 0 && role == 4))
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
                        if (isFromManger == "1" && detailObjec.hR_APPROVE == 0 && role == 3)
                        {
                            IsHideRject = true;
                        }
                        if (detailObjec.hR_REJECT == 1 || detailObjec.manageR_PREVENT == 1)
                        {
                            IsActionsVisible = false;
                        }
                    }

                }
                else
                {
                    IsEmployee = true;
                    IsLoading = true;   
               await GetCertificateypes();
             await   GetBankypes();
                }

                base.OnNavigatedTo(parameters);
            }
            catch
            { }
            finally
            { IsLoading = false; }
        }
        ObservableCollection<ResumptionTypeModel> _CertificateTypes = new ObservableCollection<ResumptionTypeModel>();
        public ObservableCollection<ResumptionTypeModel> CertificateTypes { get { return _CertificateTypes; } set { _CertificateTypes = value; RaisePropertyChanged(); } }

        ResumptionTypeModel _CertificateType = new ResumptionTypeModel();
        public ResumptionTypeModel CertificateType { get { return _CertificateType; } set { _CertificateType = value; RaisePropertyChanged(); } }


        ObservableCollection<ResumptionTypeModel> _BankTypes = new ObservableCollection<ResumptionTypeModel>();
        public ObservableCollection<ResumptionTypeModel> BankTypes { get { return _BankTypes; } set { _BankTypes = value; RaisePropertyChanged(); } }

        ResumptionTypeModel _BankType = new ResumptionTypeModel();
        public ResumptionTypeModel BankType { get { return _BankType; } set { _BankType = value; RaisePropertyChanged(); } }


        public DelegateCommand SelectCertTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var rs = await DialogService.DisplayActionSheetAsync("Select Type", "Cancel", "", CertificateTypes.Select(c => c.nameEn).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        CertTypeName = rs;
                        var SelectedType = CertificateTypes.Where(c => c.nameEn == rs).First();
                        CertTypeId = SelectedType.id;
                    }
                });
            }
        }

        public DelegateCommand SelectBankCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var rs = await DialogService.DisplayActionSheetAsync("Select Bank", "Cancel", "", BankTypes.Select(c => c.nameEn).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                       BankName  = rs;
                        var SelectedType = BankTypes.Where(c => c.nameEn == rs).First();
                       // Bank = SelectedType.id;
                    }
                });
            }
        }
        List<Langauges> lang = new List<Langauges>()
                    {
                        new Langauges()
                        {
                             id=1,Name="Arabic"
                        },
                         new Langauges()
                        {
                             id=2,Name="English"
                        },
                    };
        public DelegateCommand SelectCertLangCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                   
                    var rs = await DialogService.DisplayActionSheetAsync("Select Langauge", "Cancel", "", lang.Select(c => c.Name).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        LangName = rs;
                        var SelectedType = lang.Where(c => c.Name == rs).First();
                        LangId = SelectedType.id;
                    }
                });
            }
        }


        async Task GetCertificateypes()
        {
            try
            {
                IsLoading = true;
                var resp = await _breadFestService.GetCertificatTypes();
                if (resp.Item2)
                {

                    CertificateTypes = resp.Item1;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }

        async Task GetBankypes()
        {
            try
            {
                IsLoading = true;
                var resp = await _breadFestService.GetBankTypes();
                if (resp.Item2)
                {
                    BankTypes = resp.Item1;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
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
            public CertificateNewRequestViewModel(INotificationServices notificationServices, IUserServices userServices, ILeaveServices leaveService, IOnlineServices breadFestService, INavigationService navigationService, IPageDialogService pageDialogService) : base(notificationServices, navigationService, pageDialogService)
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
                            var resp = await _leaveService.LeaveApprove(id, DepitizedCode, "CertificatesOperations/CertApprove");
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
                        var resp = await _leaveService.LeaveReject(id, "CertificatesOperations/CertReject");
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
                        IsLoading = true;
                        await Task.Delay(1000);
                        await SendRequest();
                    });
                }
            }
        static bool isRequestSening = false;
            async Task SendRequest()
            {

                try
                {
                if (!isRequestSening)
                {
                    isRequestSening = true;

                    IsLoading = true;

                    var model = new CertificateRequestModel()
                    {
                        SALARY = InCashment ? 1 : 0,
                        BANK = IncludeBank ? 1 : 0,
                        CERT_TYPE = CertTypeId,
                        ENTERED_BY = Preferences.Get("userId", 0),
                        LANG = LangId,
                        REMARKS = REMARKS,
                        REQUEST_DATE = DateTime.Now,
                        STAFF_ID = Preferences.Get("userId", 0),
                        Department = Preferences.Get("Department", "")
                    };
                    var resp = await _breadFestService.NewCertificateRequest(model);
                    if (resp.IsSuccessStatusCode)
                    {
                        var result = await resp.Content.ReadAsStringAsync();
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await NavigationService.GoBackAsync();
                        isRequestSening = false;
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
               // isRequestSening= false;
                }

            }

        }
    public class Langauges
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
    }
