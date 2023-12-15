using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using HrApp.Model;
using HrApp.Model.OdooModels;
using HrApp.Services.Interface;
using HrApp.ViewModel.OnlineServicesViewModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace HrApp.ViewModel
{
    public class LeavesListViewModel : DetailsandActionsViewModel<LeaveRequestsModel>
    {
        ObservableCollection<LeaveRequestsModel> leaves = new ObservableCollection<LeaveRequestsModel>();
        public ObservableCollection<LeaveRequestsModel> Leaves { get { return leaves; } set { leaves = value; RaisePropertyChanged(); } }

        LeaveRequestsModel _SelectedLeave;
        public LeaveRequestsModel SelectedLeave { get { return _SelectedLeave; } set { _SelectedLeave = value; RaisePropertyChanged(); } }
        private string _leaveTypeName;

        public string leaveTypeName
        {
            get { return _leaveTypeName; }
            set { _leaveTypeName = value; RaisePropertyChanged(); }
        }

       

        IUserServices _userServices;
        ILeaveServices _leaveServices;
        IOnlineServices _onlineServices;
        public LeavesListViewModel(ILeaveServices leaveServices,IUserServices userServices, INavigationService navigationServices, IPageDialogService pageDialogService,IOnlineServices onlineServices) : base(onlineServices,navigationServices, pageDialogService,userServices)
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
        int requestTypeId;
        public bool IsShowNewRequest { get { return _IsShowNewRequest; } set { _IsShowNewRequest = value; RaisePropertyChanged(); } }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters!=null&&parameters.Count>0)
            {
                 requestTypeId =int.Parse( parameters["RequesttypeId"].ToString());
                leaveTypeName = parameters["RequesttypeName"].ToString();
                var LeaaveTypeCode = Preferences.Get("LeaveCode", 0);
                if (parameters["IsFromManager"]!=null)
                {
                    isManager = parameters["IsFromManager"].ToString();
                  
                }
                IsShowNewRequest = true;
                var isManagerView = isManager == "0" ? true : false;
                if (IsShowNewRequest)
                {
                   // await GetLeavesLst(requestTypeId);
                }
                else
                {
                  await  GetPendingManagerLeavesLst(requestTypeId);
                }
            }
            await GetLeavesLst(requestTypeId);

            // leaveTypeName = App.LeaveTypes.Where(c => c.Id == Preferences.Get("LeaveCode", 0)).First().Name;
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

 public DelegateCommand<LeaveRequestsModel> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<LeaveRequestsModel>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.leave.request"
                            };
                            await Cancelrequest(body);
                            await GetLeavesLst();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        IsLoading = false;
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

        public DelegateCommand NewRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("RequestTypeName", leaveTypeName);
                    parameters.Add("RequesttypeId", requestTypeId);

                    await NavigationService.NavigateAsync("LeaveRequest", parameters);
                });

            }
        }

        async Task GetPendingManagerLeavesLst(int leaveCode)
        {
            try
            {
                Leaves = new ObservableCollection<LeaveRequestsModel>();
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
                   /* var list = resp.Item1.OrderByDescending(i => i.reQ_DATE).ToList();
                    list.ForEach(i => Leaves.Add(i));*/
                  
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

     

        async Task GetLeavesLst(int leaveCode=0)
        {
            try
            {
                Leaves = new ObservableCollection<LeaveRequestsModel>();
                IsLoading = true;
                var resp = await _leaveServices.GeEmptLeaveRequests(new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {
                        employee_id = Preferences.Get("userId", 0)
                    }
                });

                if (resp.Item2)
                {

                    /*var list = resp.Item1.OrderByDescending(i => i.reQ_DATE).ToList();
                    list.ForEach(i => Leaves.Add(i)); */

                    Leaves = resp.Item1.result.data;
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
