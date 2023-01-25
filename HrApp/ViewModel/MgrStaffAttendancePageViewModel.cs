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
    public class MgrStaffAttendancePageViewModel : ViewModelBase
    {

        private readonly IStaffService staffService;
        private readonly IUserServices userServices;


        public MgrStaffAttendancePageViewModel(INavigationService navigationService,
            IStaffService staffService, IUserServices userServices,
            IPageDialogService dialogService) : base(navigationService, dialogService)
        {

            this.staffService = staffService;
            this.userServices = userServices;

            Events = new ObservableCollection<EventModel>();
            Staff = new ObservableCollection<HREmpModel>();

            dateFrom = DateTime.Now;
            dateTo = DateTime.Now;

        }

        #region Methods

       

        private async Task GetEvents()
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

                Tuple<List<EventModel>, bool, string> request = await staffService.GetEmployeeAttendance(id, DateFrom, DateTo);

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
                var request = await userServices.GetEmployeesByDepartment(Preferences.Get("Department", ""));

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

        bool isLoadingStaff;

        public bool IsLoadingStaff
        {
            get { return isLoadingStaff; }
            set
            {
                SetProperty(ref isLoadingStaff, value);
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
                GetEvents();
            }
        }


        DateTime dateFrom;

        public DateTime DateFrom
        {
            get { return dateFrom; }
            set
            {
                SetProperty(ref dateFrom, value);
                GetEvents();
            }
        }

        DateTime dateTo;

        public DateTime DateTo
        {
            get { return dateTo; }
            set
            {
                SetProperty(ref dateTo, value);
                GetEvents();
            }
        }

        #endregion
    }
}
