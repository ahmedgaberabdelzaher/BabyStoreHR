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

namespace HrApp.ViewModel
{
    public class LeaveRequestViewModel : ViewModelBase
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
              //  value = DateTime.Parse(value.ToString("dd MM yyyy"));

                _fromDate = value;
                /*     if (!todatereadeonly)
                     {

                         TomDate = value.AddDays(70);
                     }
                     else
                     { 
                      if (value > TomDate)
                     {
                         TomDate = value;


                     }
                     else
                    {
                         var days = TomDate-value;
                         Days = days.Days + 1;
                     }
                     }*/
                if (LeaaveTypeCode == 4)
                {
                    if (value.Date == DateTime.Now.Date)
                    {
                        TomDate = value.AddDays(70);
                    }
                    else
                    {
                        TomDate = value.AddDays(69);

                    }
                }
                else if (LeaaveTypeCode == 6)
                {

                    TomDate = value.AddDays(2);

                }
                else
                {
                    TomDate = DateTime.Now;
                }
                IsLoading = true;

                GetDays();
                RaisePropertyChanged();
            }
        }

        public async  Task  GetDays()
        {
            try {
                isokdays = new DaysModel();
                var model = new DaysModel {dateFrom= FromDate,dateTo= TomDate, leaveType=LeaaveTypeCode  , stuffId=User.stafF_ID};
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

        ObservableCollection<HREmpModel> empLst = new ObservableCollection<HREmpModel>();
        public ObservableCollection<HREmpModel> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        public byte[] File { get; set; }

        public DelegateCommand SendLeaveRequestCommand { get; set; }
        IUserServices _userServices;
        public LeaveRequestViewModel(IUserServices userServices, INavigationService navigationServices, IPageDialogService pageDialogService) : base(navigationServices, pageDialogService)
        {
            _userServices = userServices;
            SendLeaveRequestCommand = new DelegateCommand(async () => { await SendLeaveRequest(); });
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
                        DepitizedCode = EmpLst.Where(c => c.name == rs).First().stafF_ID;
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
                    var rs = await DialogService.DisplayActionSheetAsync("Select Leave Type", "Cancel", "", App.LeaveTypes.Select(c => c.Name).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        LeaaveTypeName = rs;
                        LeaaveTypeCode = App.LeaveTypes.Where(c => c.Name == rs).First().Id;
                    }
                });
            }
        }
        async Task GetDeptEmployee()
        {
            try
            {
                IsLoading = false;
                var resp = await _userServices.GetDepartmentStuff();
                if (resp.Item2)
                {
                    empLst = resp.Item1;
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
        public static bool isRequestSending = false;
        async Task SendLeaveRequest()
        {
            try
            {
                /* if (Days == 0)
                 {
                     await DialogService.DisplayAlertAsync("Alert", "The No of Days should not equal 0 day", "Cancle");
                     return;
                 }
                 if (LeaaveTypeCode == 0)
                 {
                     if (Days > 14)
                     {
                         await DialogService.DisplayAlertAsync("Alert", "The No of Days should not exceed your Hajj Leave Days.", "Cancle");
                         return;
                     }


                 } else if (LeaaveTypeCode == 6)
                 {
                     if (Days > 3)
                     {
                         await DialogService.DisplayAlertAsync("Alert", "The No of Days should not exceed 3 Days.", "Cancle");
                         return;
                     }
                 }
                 if (FromDate > TomDate)
                 {
                     await DialogService.DisplayAlertAsync("Alert", "Date to must be More than date in", "Cancle");


                 } else if (Ballance< Days)
                 { 
                     await DialogService.DisplayAlertAsync("Alert", "The No of Days should not exceed your Leave Balance.", "Cancle");


                 }
                 else
                 {*/
                IsLoading = true;
                if (!isRequestSending)
                {
                    isRequestSending = true;
                    if (Days > 0)
                    {
                        if (isokdays.status == 1)
                        {
                            await DialogService.DisplayAlertAsync("", isokdays.message, "Ok");
                            isRequestSending = false;
                        }
                        else
                        {
                          


                            var model = new LeaveRequestBody()
                            {
                                ADDRESS = Address,
                                NO_DAYS = Days,
                                TEL_NO = PhoneNo,
                                ADVANCED_SALARY = AdvancedSallary,
                                INCASHMENT = InCashment,
                                DATE_FROM = FromDate,
                                DATE_TO = TomDate,
                                LEAVE_CODE = LeaaveTypeCode,
                                REMARKS = Note,
                                REQ_DATE = DateTime.Now,
                                ENTERED_BY = Preferences.Get("userId", 0),
                                STAFF_ID = Preferences.Get("userId", 0),
                                Department = Preferences.Get("Department", ""),
                                DEPUTIZED = DepitizedCode,
                                SickFileName = SickFileName,
                                SickFileExtension = SickFileExtension,
                                SickFile = File
                            };
                            var resp = await _userServices.LeaveRequest(model);
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
            if (parameters != null && parameters.Count > 0)
            {
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
                LeaaveTypeCode = int.Parse(parameters["LeaveCode"].ToString());
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
            base.Initialize(parameters);
        }
    }
}
