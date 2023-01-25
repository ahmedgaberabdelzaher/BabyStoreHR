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
    public class LeavesListViewModel : ViewModelBase
    {
        ObservableCollection<LeavesModel> leaves = new ObservableCollection<LeavesModel>();
        public ObservableCollection<LeavesModel> Leaves { get { return leaves; } set { leaves = value; RaisePropertyChanged(); } }

        LeavesModel _SelectedLeave;
        public LeavesModel SelectedLeave { get { return _SelectedLeave; } set { _SelectedLeave = value; RaisePropertyChanged(); } }
        private string _leaveTypeName;

        public string leaveTypeName
        {
            get { return _leaveTypeName; }
            set { _leaveTypeName = value; RaisePropertyChanged(); }
        }

       

        IUserServices _userServices;
        ILeaveServices _leaveServices;
        public LeavesListViewModel(ILeaveServices leaveServices,IUserServices userServices, INavigationService navigationServices, IPageDialogService pageDialogService) : base(navigationServices, pageDialogService)
        {
            _userServices = userServices;
            _leaveServices = leaveServices;
         //   SendLeaveRequestCommand = new DelegateCommand(async () => { await SendLeaveRequest(); });
          
        }
        int code = 0;
        public async override void Initialize(INavigationParameters parameters)
        {
            /*parameters.Add("LeaaveTypeName", "Annual");
            parameters.Add("LeaveCode", 1);*/
           // if (parameters!=null&&parameters.Count>0)
          
            base.Initialize(parameters);
        }
         string isManager = "0";
        bool _IsShowNewRequest;
        public bool IsShowNewRequest { get { return _IsShowNewRequest; } set { _IsShowNewRequest = value; RaisePropertyChanged(); } }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            {
                // var LeaaveTypeCode =int.Parse( parameters["LeaveCode"].ToString());
                //LeaaveTypeName = parameters["LeaaveTypeName"].ToString();
                var LeaaveTypeCode = Preferences.Get("LeaveCode", 0);
                if (parameters["IsFromManager"]!=null)
                {
                    isManager = parameters["IsFromManager"].ToString();
                  
                }
                IsShowNewRequest = isManager == "0" ? true : false;
                if (IsShowNewRequest)
                {
                    await GetLeavesLst(LeaaveTypeCode);
                }
                else
                {
                  await  GetPendingManagerLeavesLst(LeaaveTypeCode);
                }

            }
            leaveTypeName = App.LeaveTypes.Where(c => c.Id == Preferences.Get("LeaveCode", 0)).First().Name;
            base.OnNavigatedTo(parameters);
        }

        public DelegateCommand GoToDetailsCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (SelectedLeave!=null)
                    {
                        var parameters = new NavigationParameters();
                        parameters.Add("IsFromManager", isManager);
                        parameters.Add("details", SelectedLeave);
                       
                        await NavigationService.NavigateAsync("LeaveRequestDetails", parameters);
                        SelectedLeave = null;
                    }

                });

            }
        }


        public DelegateCommand LeaveRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    var leaveTypeName = App.LeaveTypes.Where(c => c.Id == Preferences.Get("LeaveCode", 0)).First().Name;
                    parameters.Add("LeaaveTypeName", leaveTypeName);
                    parameters.Add("LeaveCode", Preferences.Get("LeaveCode", 0));
                   
                    await NavigationService.NavigateAsync("LeaveRequest", parameters);
                });

            }
        }

        async Task GetPendingManagerLeavesLst(int leaveCode)
        {
            try
            {
                Leaves = new ObservableCollection<LeavesModel>();
                IsLoading = true;

                string endPoint = "";
                if (Preferences.Get("role", 0) == 2)
                {
                    endPoint = $"GetManagerPendingData/{leaveCode}/{Preferences.Get("Department", "")}";
                }
               else if(Preferences.Get("role", 0) == 3)
                {
                    endPoint = $"GetHRManagerPendingData/{leaveCode}";

                }
                else if (Preferences.Get("role", 0) == 4)
                {
                    endPoint = $"GetHROfficerPendingData/{Preferences.Get("userId", 0)}/{leaveCode}";
                }
                var resp = await _leaveServices.GetLeaveRequests(endPoint);
                if (resp.Item2)
                {
                    var list = resp.Item1.OrderByDescending(i => i.reQ_DATE).ToList();
                    list.ForEach(i => Leaves.Add(i));
                  
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

     

        async Task GetLeavesLst(int leaveCode)
        {
            try
            {
                Leaves = new ObservableCollection<LeavesModel>();
                IsLoading = true;
                var resp = await _userServices.GetLeavesLst(leaveCode);
                if (resp.Item2)
                { var list = resp.Item1.OrderByDescending(i => i.reQ_DATE).ToList();
                    list.ForEach(i => Leaves.Add(i)); 
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
