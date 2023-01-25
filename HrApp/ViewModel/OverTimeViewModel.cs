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
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HrApp.ViewModel
{
    public class OverTimeViewModel : ViewModelBase
    {

        ObservableCollection<OverTimeModel> OverTime = new ObservableCollection<OverTimeModel>();
        public ObservableCollection<OverTimeModel> OverTimeList { get { return OverTime; } set { OverTime = value; RaisePropertyChanged(); } }

        MonthModel _selectedMoth = null;
        public MonthModel selectedMoth { get { return _selectedMoth; } set { _selectedMoth = value; MAxDays = value.Days; RaisePropertyChanged(); } }
        ObservableCollection<MonthModel> _MonthesModel = new ObservableCollection<MonthModel>();
        public ObservableCollection<MonthModel> MonthesModel { get { return _MonthesModel; } set { _MonthesModel = value; RaisePropertyChanged(); } }
        OverTimeModel _SelectedOverTime;
        public OverTimeModel SelectedOverTime { get { return _SelectedOverTime; } set { _SelectedOverTime = value; RaisePropertyChanged(); } }

        ObservableCollection<OverTime> _Items = new ObservableCollection<OverTime>();
        public ObservableCollection<OverTime> ItemsList { get { return _Items; } set { _Items = value; RaisePropertyChanged(); } }
        private string _reQ_YEAR =DateTime.Now.Year.ToString();
        public string reQ_YEAR { get { return _reQ_YEAR; } set { _reQ_YEAR = value; RaisePropertyChanged(); } }



        private bool _showSubmit = false;


        private bool _EnableSelector;

        public bool EnableSelector
        {
            get { return _EnableSelector; }
            set
            {
                _EnableSelector = value;

                RaisePropertyChanged();
            }
        }

        private int _DayofMonth=1;

        public int DayofMonth
        {
            get { return _DayofMonth; }
            set { 
                _DayofMonth = value; 
                
                RaisePropertyChanged(); }
        }



        public bool ShowSubmit
        {
            get { return _showSubmit; }
            set { _showSubmit = value; RaisePropertyChanged(); }
        }

        private int _MAxDays=29;

        public int MAxDays
        {
            get { return _MAxDays; }
            set { _MAxDays = value;   RaisePropertyChanged(); }
        }

        private bool _popisopend;

        public bool popisopend
        {
            get { return _popisopend; }
            set { _popisopend = value; RaisePropertyChanged(); }
        }

        public DelegateCommand PoPup
        {
            get
            {
                return new DelegateCommand( () =>
                {
                    
                    popopening();
                });

            }
        }

        public void popopening()
        {
            if (popisopend)
            {
                popisopend = false;
            }
            else
            {

                if (selectedMoth !=null&& !string.IsNullOrEmpty(selectedMoth.Month) && !string.IsNullOrEmpty(this.reQ_YEAR))
                {
                  
                    popisopend = true;
                   
                }
                else
                {
                    DialogService.DisplayAlertAsync("Alert", "Please fill year and month fields", "Cancel");
                }
            }
        }

        public async Task CheckClearItems()
        {


          
            if (ItemsList.Count > 0)
            { 
             var result = await DialogService.DisplayAlertAsync("Alert","If you changed month or year all overtime items will removed","Yes","Cancel");
                if (result)
                {
                    ItemsList.Clear();
                    Items.Clear();
                    EnableSelector = false;
                }

            }

        }

        public List<OverTime> Items;

        TimeSpan _Timein=TimeSpan.FromHours(9);
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




        TimeSpan _Timeout= TimeSpan.FromHours(10);
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


        string isManager = "0";
        bool _IsShowNewRequest;
        TimeSpan _Days;
        public TimeSpan Days { get { return _Days; } set { _Days = value; RaisePropertyChanged(); } }

        private int _DayLimit;

        public int DayLimit
        {
            get { return _DayLimit; }
            set { _DayLimit = value; }
        }


        string _Note = "";
        public string Note { get { return _Note; } set { _Note = value; RaisePropertyChanged(); } }
        DateTime _datetime = DateTime.Now;
        public DateTime Datetime
          
        {
            get { return _datetime; }
            set { _datetime = value; RaisePropertyChanged(); }
        }
        public bool IsShowNewRequest { get { return _IsShowNewRequest; } set { _IsShowNewRequest = value; RaisePropertyChanged(); } }

        public DelegateCommand SendOverTimeRequestCommand { get; set; }
        public DelegateCommand AddItem { get; set; }
        public DelegateCommand<OverTime> DeleteItem { get; set; }

        

        IOverTimeServices _OverTimeServices;
        public OverTimeViewModel(IOverTimeServices OverTimeServices, INavigationService navigationServices, IPageDialogService pageDialogService) : base(navigationServices, pageDialogService)
        {                
         MonthesModel = new ObservableCollection<MonthModel> {
        new MonthModel{Numeric=1 , Month="Jan", Days=31 },
        new MonthModel{Numeric=2 , Month="Feb", Days=28 },
        new MonthModel{Numeric=3 , Month="Mar", Days=31 },
        new MonthModel{Numeric=4 , Month="Apr", Days=30 },
        new MonthModel{Numeric=5 , Month="May", Days=31 },
        new MonthModel{Numeric=6 , Month="Jun", Days=30 },
        new MonthModel{Numeric=7, Month="Jul",  Days=31 },
        new MonthModel{Numeric=8 , Month="Aug", Days=31 },
        new MonthModel{Numeric=9 , Month="Sep", Days=30 },
        new MonthModel{Numeric=10 , Month="Oct",Days=31 },
        new MonthModel{Numeric=11 , Month="Nov",Days=30 },
        new MonthModel{Numeric=12 , Month="Dec",Days=31 },
        };
            Items = new List<OverTime>();

            AddItem = new DelegateCommand(additem);
            DeleteItem = new DelegateCommand<OverTime>(deleteitem);
            _OverTimeServices = OverTimeServices;
            SendOverTimeRequestCommand = new DelegateCommand(async () => { await SendOverRequest(); });
        }

       

        public DelegateCommand CheckAlert {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await CheckClearItems();
                });
            }
        }

        private void deleteitem(OverTime obj)
        {
            ItemsList.Remove(obj);
            Items.Remove(obj);
            if (Items.Count <= 0)
            {
               
                EnableSelector = false;
                ShowSubmit = false;
            }
        


        }

        public void additem()
        {
          
                EnableSelector = true;
          

            IsLoading = true;
           // DateTime Datetime = new DateTime(int.Parse(reQ_YEAR), selectedMoth.Numeric, DayofMonth);
          

            //  string Date = $"{selectedMoth.Numeric}/{DayofMonth}/{reQ_YEAR}";
            //    Datetime = Convert.ToDateTime(Date);

            var Item = new OverTime()
            {
               // Date = Datetime,
                TimeIn = this.Timein,
                TimeOut = this.Timeout,
                Day= DayofMonth,
                Notes = Note

            };
            ItemsList.Add(Item);
            Items.Add(Item);
            ShowSubmit = true;
           
            IsLoading = false;
            popopening();
        }

        private async Task SendOverRequest()
        {
            try
            {
               
                IsLoading = true;

                var model = new OverTimeModel()
                {
                    reQ_YEAR = reQ_YEAR,
                    reQ_MONTH = selectedMoth.Numeric.ToString(),
                    remarks = Note,
                    reQ_DATE = DateTime.Now,
                    days = 0,

                    entereD_BY = Preferences.Get("userId", 0),
                    stafF_ID = Preferences.Get("userId", 0),
                    department = Preferences.Get("Department", ""),
                    overtimeItems = Items
                };
                var resp = await _OverTimeServices.AddAppOvertimeRecord(model);
                if (resp.IsSuccessStatusCode)
                {
                    ItemsList = new ObservableCollection<OverTime>();
                    OverTime = new ObservableCollection<OverTimeModel>();
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

        public async override void Initialize(INavigationParameters parameters)
        {
            /*parameters.Add("LeaaveTypeName", "Annual");
            parameters.Add("LeaveCode", 1);*/
            // if (parameters!=null&&parameters.Count>0)

            base.Initialize(parameters);
        }
        public DelegateCommand GoToDetailsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (SelectedOverTime != null)
                    {
                        var parameters = new NavigationParameters();
                        parameters.Add("IsFromManager", isManager);
                        parameters.Add("details", SelectedOverTime);

                        await NavigationService.NavigateAsync("OverTimeDetails", parameters);
                        SelectedOverTime = null;
                    }

                });

            }
        }

        public DelegateCommand OverTimeRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();

                    await NavigationService.NavigateAsync("OverTimeRequest", parameters);
                });

            }
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {


            if (parameters["IsFromManager"] != null)
            {
                isManager = parameters["IsFromManager"].ToString();

            }
            IsShowNewRequest = isManager == "0" ? true : false;
            if (IsShowNewRequest)
            {
                await GetOverTime();

            }
            else
            {
                await GetOverTimeList();
            }


            base.OnNavigatedTo(parameters);
        }

        async Task GetOverTimeList()
        {
            try
            {
                IsLoading = true;
                OverTimeList.Clear();
                string endPoint = "";
                if (Preferences.Get("role", 0) == 2)
                {
                    endPoint = $"GetManagerPendingData/{Preferences.Get("Department", "")}";
                }
                else if (Preferences.Get("role", 0) == 3)
                {
                    endPoint = $"GetHRManagerPendingData";

                }
                else if (Preferences.Get("role", 0) == 4)
                {
                    endPoint = $"GetHROfficerPendingData/{Preferences.Get("userId", 0)}";
                }
                var resp = await _OverTimeServices.GetOverTimeRequests(endPoint);
                if (resp.Item2)
                {
                    var list = resp.Item1.OrderByDescending(i => i.reQ_DATE).ToList();
                    list.ForEach(i => OverTimeList.Add(i));
                   
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

        async Task GetOverTime()
        {
            try
            {
                OverTimeList.Clear();
                IsLoading = true;
                var resp = await _OverTimeServices.GetOverTimeRequestsByStuffId();
                if (resp.Item2)
                {
                    var list = resp.Item1.OrderByDescending(i => i.reQ_DATE).ToList();
                    list.ForEach(i => OverTimeList.Add(i));
                 
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }
    }
}
