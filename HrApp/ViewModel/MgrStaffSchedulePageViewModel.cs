using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

    public class MgrStaffSchedulePageViewModel : ViewModelBase
    {
        private readonly IStaffService staffService;
        private readonly IUserServices userServices;


        public MgrStaffSchedulePageViewModel(INavigationService navigationService,
            IStaffService staffService, IUserServices userServices,
            IPageDialogService dialogService) : base(navigationService, dialogService)
        {

            this.staffService = staffService;
            this.userServices = userServices;

            SelectedDate = DateTime.Now;

            Events = new ObservableCollection<EventModel>();
            Staff = new ObservableCollection<HREmpModel>();
            
            SelectedDates = new List<DateTime>();

            SetCurrentDateText();

        }

        #region Methods

        private void SetCurrentDateText()
        {
            SelectedDateText = SelectedDate.Value.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture);
        }

        private async Task GetEvents(bool muiltDates)
        {
            IsLoading = true;
            try
            {
                if (SelectedStaff == null)
                {
                    IsLoading = false;
                    return;
                }

                int id = SelectedStaff.stafF_ID;

                Tuple<List<EventModel>, bool, string> request = null;

                if (muiltDates)
                {
                    var from = selectedDates.Min();
                    var to = selectedDates.Max();

                    request = await staffService.GetEmployeeAttendance(id, from, to);
                }
                else
                {
                    request = await staffService.GetDepartmentScedule(id, selectedDate.Value);
                }


                if (request.Item2)
                {
                    List<EventModel> list = request.Item1;

                    Events = new ObservableCollection<EventModel>(list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IsLoading = false;
        }


        private async Task GetStaff()
        {
            IsLoadingStaff = true;
            try
            {
                var request =  await userServices.GetEmployeesByDepartment(Preferences.Get("Department", ""));

                if (request.Item2)
                {
                    Staff = new ObservableCollection<HREmpModel>(request.Item1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IsLoadingStaff = false;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await GetStaff();
           // await GetEvents(false);
        }

        #endregion

        #region props

        public DelegateCommand SelectDateCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    SetCurrentDateText();

                    bool multi = SelectedDates.Count > 1;

                    await GetEvents(multi);
                });

            }
        }

        string selectedDateText;

        public string SelectedDateText
        {
            get { return selectedDateText; }
            set
            {
                SetProperty(ref selectedDateText, value);
            }
        }

        bool isLoadingStaff;

        public bool IsLoadingStaff
        {
            get { return isLoadingStaff; }
            set
            {
                SetProperty(ref isLoadingStaff, value);
            }
        }

        private List<DateTime> selectedDates;

        public List<DateTime> SelectedDates
        {
            get
            {
                return selectedDates;
            }
            set
            {
                SetProperty(ref selectedDates, value);
            }
        }

        DateTime? selectedDate;

        public DateTime? SelectedDate
        {
            get { return selectedDate; }
            set
            {
                SetProperty(ref selectedDate, value);
            }
        }

        private ObservableCollection<EventModel> _events;

        public ObservableCollection<EventModel> Events
        {
            get
            {
                return _events;
            }
            set
            {
                SetProperty(ref _events, value);
            }
        }

        private ObservableCollection<HREmpModel> _staff;

        public ObservableCollection<HREmpModel> Staff
        {
            get
            {
                return _staff;
            }
            set
            {
                SetProperty(ref _staff, value);
            }
        }

        HREmpModel selectedStaff;

        public HREmpModel SelectedStaff
        {
            get { return selectedStaff; }
            set
            {
                SetProperty(ref selectedStaff, value);
                NoData = false;
                GetEvents(false);
            }
        }

        #endregion
    }
}
