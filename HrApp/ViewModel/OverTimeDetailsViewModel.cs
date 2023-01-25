using HrApp.Model;
using HrApp.Model.OverTimeModels;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HrApp.ViewModel
{
   public class OverTimeDetailsViewModel : NotificationViewModel
    {
        ObservableCollection<OverTime> _Items = new ObservableCollection<OverTime>();
        public ObservableCollection<OverTime> ItemsList { get { return _Items; } set { _Items = value; RaisePropertyChanged(); } }
        ObservableCollection<HrOfficersModel> empLst = new ObservableCollection<HrOfficersModel>();
        public ObservableCollection<HrOfficersModel> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }
      

        string isManager = "0";
        bool _IsShowNewRequest;
        TimeSpan _Days;
        private string _selectedmonth;

        public string selectedmonth
        {
            get { return _selectedmonth; }
            set { _selectedmonth = value; }
        }
        private string _reQ_MONTH;
     
        public string reQ_MONTH { get { return _reQ_MONTH; } set { _reQ_MONTH = value; RaisePropertyChanged(); } }


        TimeSpan _Timein;
        public TimeSpan Timein
        {
            get { return _Timein; }
            set
            {
                _Timein = value;
                if (Timeout < Timein)
                {
                    Days = Timeout.Add(new TimeSpan(24, 0, 0)).Subtract(Timein);
                }
                else
                {
                    Days = Timeout.Subtract(Timein);
                }




                RaisePropertyChanged();
            }
        }


        TimeSpan _Timeout;
        public TimeSpan Timeout
        {
            get { return _Timeout; }
            set
            {
                _Timeout = value;

                if (Timeout < Timein)
                {
                    Days = Timeout.Add(new TimeSpan(24, 0, 0)).Subtract(Timein);
                }
                else
                {
                    Days = Timeout.Subtract(Timein);
                }

                RaisePropertyChanged();
            }
        }


        public string _refNO;
        public string refNO { get { return _refNO; } set { _refNO = value; RaisePropertyChanged(); } }

        public TimeSpan Days { get { return _Days; } set { _Days = value; RaisePropertyChanged(); } }

        string _Note = "";
        public string Note { get { return _Note; } set { _Note = value; RaisePropertyChanged(); } }
        DateTime _datetime = DateTime.Now;
        public DateTime Datetime
        {
            get { return _datetime; }
            set { _datetime = value; RaisePropertyChanged(); }
        }

        private string _reQ_YEAR;
        public string reQ_YEAR { get { return _reQ_YEAR; } set { _reQ_YEAR = value; RaisePropertyChanged(); } }
        bool _IsActionsVisible;
        public bool IsActionsVisible { get { return _IsActionsVisible; } set { _IsActionsVisible = value; RaisePropertyChanged(); } }

        bool _IsPendingOnHrManager;
        public bool IsPendingOnHrManager { get { return _IsPendingOnHrManager; } set { _IsPendingOnHrManager = value; RaisePropertyChanged(); } }

        bool _IsHideRject;
        public bool IsHideRject { get { return _IsHideRject; } set { _IsHideRject = value; RaisePropertyChanged(); } }

        public DelegateCommand SendApproveCommand { get; set; }
        public DelegateCommand SendRejectionCommand { get; set; }
        string _DepitizedName;
        public string DepitizedName { get { return _DepitizedName; } set { _DepitizedName = value; RaisePropertyChanged(); } }

        int _DepitizedCode = 0;
       
        public int DepitizedCode { get { return _DepitizedCode; } set { _DepitizedCode = value; RaisePropertyChanged(); } }

        IUserServices _userServices;
        IOverTimeServices _OverTimeServices;
        List<KeyValuePair<string, int>> MothKey;
        private INotificationServices notificationServices;
        public OverTimeDetailsViewModel(INotificationServices notificationServices,IOverTimeServices OverTimeServices, IUserServices userServices, INavigationService navigationServices, IPageDialogService pageDialogService) : base(notificationServices, navigationServices, pageDialogService)
        {
             this.notificationServices = notificationServices;
             _userServices =userServices;
            _OverTimeServices=OverTimeServices;
            SendRejectionCommand = new DelegateCommand(async () => { await SendRejection(); });
            SendApproveCommand = new DelegateCommand(async () => { await Approve(); });

            MothKey = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Jan", 1),
                new KeyValuePair<string, int>("Feb", 2),
                new KeyValuePair<string, int>("Mar", 3),
                new KeyValuePair<string, int>("Apr", 4),
                new KeyValuePair<string, int>("May", 5),
                new KeyValuePair<string, int>("Jun", 6),
                new KeyValuePair<string, int>("Jul", 7),
                new KeyValuePair<string, int>("Aug", 8),
                new KeyValuePair<string, int>("Sept",9),
                new KeyValuePair<string, int>("Oct", 10),
                new KeyValuePair<string, int>("Nov", 11),
                new KeyValuePair<string, int>("Dec", 12),




            };
        }
        int id;
      

        public async override void Initialize(INavigationParameters parameters)
        {
            try
            {
                if (parameters!=null&&parameters.Count>0)
            {


                var detailObjec = parameters["details"] as OverTimeModel;
                    if (detailObjec != null)
                    {
                        var month = MothKey.Where(x => x.Value == int.Parse(detailObjec.reQ_MONTH)).ToList();

                        RefNO = detailObjec.refNO;
                        Datetime = detailObjec.reQ_DATE;
                        reQ_YEAR = detailObjec.reQ_YEAR;
                        department = detailObjec.department;
                        StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;reqDate = detailObjec.reQ_DATE;
                      //  deleteallow =detailObjec.isEditDeleteAllowed;

                        deleteallow = detailObjec.isEditDeleteAllowed;

                        reQ_MONTH = month[0].Key;
                        id = detailObjec.id;
                        detailObjec.overtimeItems.OrderBy(i => i.Date).ToList().ForEach(i => ItemsList.Add(i));
                    }
                    else
                    {

                        IsLoading = true;
                        string ID = parameters["NotifiRequstID"] as string;
                        if (!string.IsNullOrEmpty(ID))
                        {
                            var result = await _OverTimeServices.GetOverTimeById(int.Parse(ID));
                            if (result.Item2 && result.Item1.Count > 0)
                            {
                                detailObjec = result.Item1[0] as OverTimeModel;

                                var month = MothKey.Where(x => x.Value == int.Parse(detailObjec.reQ_MONTH)).ToList();

                                RefNO = detailObjec.refNO;
                                reQ_YEAR = detailObjec.reQ_YEAR;
                                reQ_MONTH = month[0].Key;
                                department = detailObjec.department;
                                StuffFirstNameLastName = detailObjec.StuffFirstNameLastName;reqDate = detailObjec.reQ_DATE;
                                deleteallow =detailObjec.isEditDeleteAllowed;
                                Datetime = detailObjec.reQ_DATE;
                                id = detailObjec.id;
                                detailObjec.overtimeItems.OrderBy(i=>i.Date).ToList().ForEach(i => ItemsList.Add(i));
                               
                           

                            }
                        }

                    }
                var isFromManger = parameters["IsFromManager"].ToString();
                var role = Preferences.Get("role", 0);
                if ((isFromManger=="1"&&detailObjec.mnG_APPROVE==0&&role==2)|| (isFromManger == "1" && detailObjec.hR_APPROVE == 0&&role==3) || (isFromManger == "1" && detailObjec.hR_DONE == 0&&role==4&& detailObjec.mnG_APPROVE == 1))
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
                if (detailObjec.hR_REJECT == 1||detailObjec.manageR_PREVENT==1)
                    {
                        IsActionsVisible = false;
                    }
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
                var resp = await _OverTimeServices.OvertimeDelete(id);
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


        /*  public DelegateCommand SelectLeaveTypeCommand
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
          }*/
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

        async Task  Approve()
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
                        var resp = await _OverTimeServices.OverTimeApprove(id, DepitizedCode);
                        if (resp.IsSuccessStatusCode)
                        {
                            var result = await resp.Content.ReadAsStringAsync();
                            await DialogService.DisplayAlertAsync("", "Request Approved", "Ok");
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
                    var resp = await _OverTimeServices.OverTimeReject(id);
                    if (resp.IsSuccessStatusCode)
                    {
                        var result = await resp.Content.ReadAsStringAsync();
                        await DialogService.DisplayAlertAsync("", "Request Rejected", "Ok");
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
