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
{
    public class EmployeeDirectoryPageViewModel:ViewModelBase
    {
        string _departmentitem= Preferences.Get("Department", "");
        private bool _AppearDropList = false;

        public bool AppearDropList
        {
            get { return _AppearDropList; }
            set { _AppearDropList = value; RaisePropertyChanged(); }
        }

            
        public string departmentitem { get { return _departmentitem; } set { _departmentitem = value; RaisePropertyChanged(); } }

        private ObservableCollection<string> _departmentslist;

        public ObservableCollection<string> departmentslist
        {
            get
            {
                return _departmentslist;
            }
            set
            {
                SetProperty(ref _departmentslist, value);
            }
        }
        private readonly IUserServices userServices;

        public EmployeeDirectoryPageViewModel(INavigationService navigationService,
            IUserServices userServices,
            IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            this.userServices = userServices;
        }

        #region Props
        public DelegateCommand SelectDepartment
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var rs = await DialogService.DisplayActionSheetAsync("Select Department", "Cancel", "", departmentslist.ToList().Select(c => c).ToArray());
                    if (rs != null && rs != "Cancel")
                    {

                      await  GetEmployees(rs);
                    }
                });
            }
        }
        public DelegateCommand GoToDetailsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                   // await NavigationService.NavigateAsync();
                });

            }
        }

        private ObservableCollection<HREmpModel> employees;

        public ObservableCollection<HREmpModel> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                SetProperty(ref employees, value);
            }
        }
        #endregion


        #region Methods

        private async Task GetDeparments()
        {
            IsLoading = true;
            try
            {
                var request = await userServices.GetDepartments();

                if (request.Item2)
                {
                    departmentslist = new ObservableCollection<string>(request.Item1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IsLoading = false;
        }


        private async Task GetEmployees(string department )
        {
            IsLoading = true;
            try
            {
                if (string.IsNullOrEmpty(department))
                {
                    department= Preferences.Get("Department", "");
                }
                departmentitem = department;
                var request = await userServices.GetEmployeesByDepartment(department);

                if (request.Item2)
                {
                    Employees = new ObservableCollection<HREmpModel>(request.Item1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IsLoading = false;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var role = Preferences.Get("role", 0);
            if (role == 3)
            {
                AppearDropList = true;
            }
            await GetDeparments();
            await GetEmployees(Preferences.Get("Department", ""));
           
        }

        #endregion
    }
}
