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
    public class StaffAttendancePageViewModel : ViewModelBase
    {

        private readonly IStaffService staffService;


        public StaffAttendancePageViewModel(INavigationService navigationService,
            IStaffService staffService,
            IPageDialogService dialogService) : base(navigationService, dialogService)
        {

            this.staffService = staffService;

            Events = new ObservableCollection<EventModel>();

            dateFrom = DateTime.Now;
            dateTo = DateTime.Now;

        }

        #region Methods

      

        private async Task GetEvents()
        {
            IsLoading = true;
            try
            {
                int id = Preferences.Get("userId", 0);

                Tuple<List<EventModel>, bool, string> request  = await staffService.GetEmployeeAttendance(id, DateFrom, DateTo);


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

        //public async override void OnNavigatedTo(INavigationParameters parameters)
        //{
        //    base.OnNavigatedTo(parameters);

        //    await GetEvents();
        //}

        #endregion

        #region props

        //public DelegateCommand SelectDateCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(async () =>
        //        {
        //            SetCurrentDateText();

        //            bool multi = SelectedDates.Count > 1;

        //            await GetEvents(multi);
        //        });

        //    }
        //}

        
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

        #endregion
    }

}
