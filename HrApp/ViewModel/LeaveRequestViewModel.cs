using HrApp.Model;
using HrApp.Services.Interface;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using HrApp.Model.OdooModels;
using HrApp.ViewModel.OnlineServicesViewModels;
using HrApp.Helpers;
using FirebaseNet.Messaging;
using HrApp.Resources;

namespace HrApp.ViewModel
{
    public class LeaveRequestViewModel:DetailsandActionsViewModel<LeaveRequestsModel>
    {

        public string SickFileName { get; set; }
        public string SickFileExtension { get; set; }
        string _LeaaveTypeName;

        private bool _todatereadeonly=true;
        DaysModel isokdays;
        public bool todatereadeonly
        {
            get { return _todatereadeonly; }
            set { _todatereadeonly = value; RaisePropertyChanged(); }
        }

        private bool exit_re_entry_visa;
        public bool Exit_re_entry_visa
        {
            get { return exit_re_entry_visa; }
            set { exit_re_entry_visa = value; RaisePropertyChanged(); }
        }

        public string LeaaveTypeName { get { return _LeaaveTypeName; } set { _LeaaveTypeName = value; RaisePropertyChanged(); } }

        string _FileName;

        public string FileName { get { return _FileName; } set { _FileName = value; RaisePropertyChanged(); } }

        int adddays = 0;
        int _LeaaveTypeCode;
        public int LeaaveTypeCode { get { return _LeaaveTypeCode; } set { _LeaaveTypeCode = value; RaisePropertyChanged(); } }

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

        DateTime _ExpectedReturnDate = DateTime.Now; /*DateTime.Parse( DateTime.Now.ToString("dd MM yyyy"));*/
        public DateTime ExpectedReturnDate
        {
            get { return _ExpectedReturnDate; }
            set
            {

                _ExpectedReturnDate = value;
                RaisePropertyChanged();
            }
        }

        public async  Task  GetDays()
        {
            try {
                isokdays = new DaysModel();
                var model = new DaysModel {dateFrom= FromDate,dateTo= TomDate, leaveType=LeaaveTypeCode  , stuffId=User.id};
                var days = await _userServices.GetDays(model);
                if (days.IsSuccessStatusCode)
                {
                    var responseJson = await days.Content.ReadAsStringAsync();
                    var JsonObject = JsonConvert.DeserializeObject<DaysModel>(responseJson);
                    Days = (int)JsonObject.total_Dayes;
                    isokdays = JsonObject;
                    if (isokdays.status == 1)
                    {
                        await DialogService.DisplayAlertAsync("", JsonObject.message, "Ok");
                      
                    }
                }
                    }
            catch { }
            finally{ IsLoading = false; }

        }
       

        DateTime _tromDate = DateTime.Now;
        public DateTime TomDate
        {
            get
            {
                
                return _tromDate; }
            set
            {
                // value = DateTime.Parse(value.ToString("dd MM yyyy"));
                /* if (value >= FromDate)
                 {
                     _tromDate = value;
                     var days = value.Date - FromDate.Date;
                     Days = days.Days + 1;
                 }*/
                _tromDate = value;

                IsLoading = true;
                GetDays();
                RaisePropertyChanged();
            }
        }

        int _Dayse=0;
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


        string _DepitizedName;
        public string DepitizedName { get { return _DepitizedName; } set { _DepitizedName = value; RaisePropertyChanged(); } }

        int _DepitizedCode = 0;
        public int DepitizedCode { get { return _DepitizedCode; } set { _DepitizedCode = value; RaisePropertyChanged(); } }

        bool isReadOnly = false;
        public bool IsReadOnly { get { return isReadOnly; } set { isReadOnly = value; RaisePropertyChanged(); } }

        bool isAddNew = true;
        public bool IsAddNew { get { return isAddNew; } set { isAddNew = value; RaisePropertyChanged(); } }


        userData selectedReplacementEmp ;
        public userData SelectedReplacementEmp { get { return selectedReplacementEmp; } set { selectedReplacementEmp = value; RaisePropertyChanged(); } }


        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }




        public static ObservableCollection<LeaveTypesModel> LeaveTypes;
        
        public byte[] File { get; set; }

        public DelegateCommand SendLeaveRequestCommand { get; set; }
        IUserServices _userServices;
        ILeaveServices _leaveServices;

        public LeaveRequestViewModel(IUserServices userServices,IOnlineServices onlineServices, INavigationService navigationServices, IPageDialogService pageDialogService, ILeaveServices leaveServices) : base(onlineServices,navigationServices, pageDialogService,userServices)
        {
            _userServices = userServices;
            _leaveServices = leaveServices;
            SendLeaveRequestCommand = new DelegateCommand(async () => { await SendLeaveRequest(); });
        }
        public DelegateCommand SelectDeoitizerCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var rs = await DialogService.DisplayActionSheetAsync("Select Name", "Cancel", "", EmpLst.Select(c => c.name_en).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        DepitizedName = rs;
                        DepitizedCode = EmpLst.Where(c => c.name_en == rs).First().id;
                    }
                });
            }
        }


        public DelegateCommand UploadAttatchementCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var opt = new MediaPickerOptions()
                    {
                        Title = "Select Attatchement",
                        // FileTypes = new FilePickerFileType()
                    };
                    var res = await PickFile(opt);
                    if (res != null)
                    {
                        File = ConvertToBase64(res);

                    }
                });
            }
        }
        public byte[] ConvertToBase64(Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);

            return bytes;
            //return new MemoryStream(Encoding.UTF8.GetBytes(base64));
        }
        async Task<Stream> PickFile(MediaPickerOptions options)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(options);
                if (result != null)
                {
                    SickFileName = result.FileName;

                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase) || result.FileName.EndsWith("pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                        if (result.FileName.EndsWith("pdf"))
                        {
                            SickFileExtension = "pdf";
                        }
                        else
                        {
                            SickFileExtension = "png";
                        }

                        return stream;
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "Only Images and PDF file supported", "Ok");
                        return null;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DelegateCommand SelectLeaveTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (LeaveTypes==null||LeaveTypes.Count<=0)
                    {
                        LeaveTypes =await GetLeaveTypes();
                    }
                   
                    var rs = await DialogService.DisplayActionSheetAsync("Select Leave Type", "Cancel", "", LeaveTypes.Select(c => c.name).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        LeaaveTypeName = rs;
                        LeaaveTypeCode = LeaveTypes.Where(c => c.name == rs).First().id;
                    }
                });
            }
        }

        public new DelegateCommand  SelectEmployeeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (EmpLst == null || EmpLst.Count <= 0)
                    {
                      await  GetDeptEmployee();
                    }

                    var rs = await DialogService.DisplayActionSheetAsync("Select Replacement Employee", LangaugeResource.Cancel, "", EmpLst.Select(c => c.name_en).ToArray());
                    if (rs != null && rs != LangaugeResource.Cancel)
                    {
                        DepitizedName = rs;
                        SelectedReplacementEmp = EmpLst.First(c => c.name_en == rs);
                        
                    }
                });
            }
        }

        async Task GetDeptEmployee()
        {
            try
            {
                IsLoading = false;
                var resp = await _userServices.GetAllEmployees();
                if (resp.Item2)
                {
                    var data = resp.Item1.result.data;
                    var emp = data.Where(c => c.department == User.department);
                    empLst = new ObservableCollection<userData>(emp);
                    
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

        async Task<ObservableCollection<LeaveTypesModel>> GetLeaveTypes()
        {
            try
            {
                IsLoading = false;
                var resp = await _leaveServices.GetLeaveTypes();
                if (resp.Item2)
                {

                    var leaveTypes = resp.Item1.result.data;
                    return leaveTypes;
                }

                return new ObservableCollection<LeaveTypesModel>();
            }
            catch (Exception ex)
            {
                IsLoading = false;
                return new ObservableCollection<LeaveTypesModel>();

            }
            finally
            {
                IsLoading = false;
            }
        }

        public static bool isRequestSending = false;
        async Task SendLeaveRequest()
        {
            try
            {
                IsLoading = true;
                if (!isRequestSending)
                {
                    isRequestSending = true;
                    {
                        {
                                                      var model = new LeaveRequestModel()
                            {

                                employee_id = Preferences.Get("userId", 0),
                                end_date = TomDate.Date.ToString("yyyy-MM-dd"),
                                 start_date=FromDate.Date.ToString("yyyy-MM-dd"),
                                expected_return_date= ExpectedReturnDate.Date.ToString("yyyy-MM-dd"),
                                 leave_type_id=LeaaveTypeCode,
                                  replacement_mobile=PhoneNo,
                                  exit_re_entry_visa=Exit_re_entry_visa,
                                   replacement_employee_id=SelectedReplacementEmp.id
                            };
                            var leavModel = new BaseOdoModel<LeaveRequestModel>()
                            {
                                @params = model
                            };
                            var resp = await _leaveServices.SubmitLeaveRequest(leavModel);
                            var result = await resp.Content.ReadAsStringAsync();
                            if (resp.IsSuccessStatusCode)
                            {
                               
                                // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");

                                await NavigationService.GoBackAsync();
                                isRequestSending = false;
                            }
                            else
                            {
                                await DialogService.DisplayAlertAsync("", "Erro Occured", "Cancel");
                                isRequestSending = false;

                            }

                        }
                    }

                }
            }

            //   }
            catch (Exception ex)
            {
                IsLoading = false;
                isRequestSending = false;

            }
            finally
            {
                IsLoading = false;
            }

        }
        public override async void Initialize(INavigationParameters parameters)
        {
            try
            {

       if (parameters != null && parameters.Count > 0)
            {
                    if (parameters.ContainsKey("res_id"))
                    {
                        IsReadOnly = true;
                        IsAddNew = false;
                        res_model = parameters["res_model"].ToString();
                        res_id = int.Parse(parameters["res_id"].ToString());
                        var data = await GetRequestDetails();
                        SetDetailsData(data);
                        return;
                    }
                isRequestSending = false;
                adddays = 0;
           var user =   await   _userServices.Getuserinfo();
                if (user != null&&user.Item2)
                {
                    Ballance = user.Item1.leavE_BALANCE;
                    Preferences.Set("Ballance", Ballance);

                }
                todatereadeonly = true;
                LeaaveTypeName = parameters["LeaaveTypeName"].ToString();
                LeaaveTypeCode = int.Parse(parameters["RequesttypeId"].ToString());
                if (LeaaveTypeCode == 4)
                { todatereadeonly = false; TomDate = DateTime.Now.AddDays(69); }
                else if (LeaaveTypeCode == 6)
                {
                    TomDate = TomDate = DateTime.Now.AddDays(2);
                    todatereadeonly = false;
                }
                else {
                    TomDate = DateTime.Now;
                }
                GetDays();

                //parameters.Add("LeaveCode", Preferences.Get("LeaveCode", 0));
            }
            GetDeptEmployee();
            }
            catch (Exception ex)
            {
                IsLoading = false;
            }
     
            base.Initialize(parameters);
        }

        public void SetDetailsData(LeaveRequestsModel data)
        {
            EmployeeName = data.employee_name;
            TomDate = DateTimeHelper.ConvertStringTodateonly(data.end_date);
              FromDate = DateTimeHelper.ConvertStringTodateonly(data.start_date);
             ExpectedReturnDate = DateTimeHelper.ConvertStringTodateonly(data.expected_return_date);
            LeaaveTypeName = data.leave_type_name;
              PhoneNo = data.replacement_mobile;
            SelectedReplacementEmp = new userData()
            {
                name_ar = data.replacement_employee_id[1].ToString(),
                name_en = data.replacement_employee_id[1].ToString()
            };
            DepitizedName = data.replacement_employee_id[1].ToString();

            exit_re_entry_visa = data.leave_or_return;
             

        }


    }
}
