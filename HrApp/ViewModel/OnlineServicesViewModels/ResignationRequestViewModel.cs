using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;
using Xamarin.Forms;
using HrApp.Helpers;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class ResignationRequestViewModel : DetailsandActionsViewModel<CustodyLst>
    {

        ObservableCollection<CustodyLst> requests = new ObservableCollection<CustodyLst>();
        public ObservableCollection<CustodyLst> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }

        ObservableCollection<CustodyProperityLst> resignationReasonLst = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> ResignationReasonLst { get { return resignationReasonLst; } set { resignationReasonLst = value; RaisePropertyChanged(); } }

        CustodyProperityLst selectedReason;
        public CustodyProperityLst SelectedReason { get { return selectedReason; } set { selectedReason = value; RaisePropertyChanged(); } }

        DateTime _lastWorkingDay = DateTime.Now; 
        public DateTime LastWorkingDay
        {
            get { return _lastWorkingDay; }
            set
            {

                _lastWorkingDay = value;
                RaisePropertyChanged();
            }
        }
      
        string reasonName;
        public string ReasonName { get { return reasonName; } set { reasonName = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

      
        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public ResignationRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetCustodyRequestLst();

        }


        public DelegateCommand<CustodyLst> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<CustodyLst>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.resignation.request"
                            };
                            await Cancelrequest(body);
                            await GetCustodyRequestLst();
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


        public DelegateCommand SelectReasonCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var Assests = await GetReasonnsLst();
                    if (Assests != null)
                    {
                        var rs = await DialogService.DisplayActionSheetAsync("Select Request Type", "Cancel", "", Assests.Select(c => c.name).ToArray());
                        if (rs != null && rs != "Cancel")
                        {
                            ReasonName = rs;
                            SelectedReason = Assests.First(c => c.name == ReasonName);
                        }
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "No Reasons Found", "Ok");
                        IsLoading = false;
                    }
                    IsLoading = false;


                });
            }
        }


        public DelegateCommand AddNewRequestCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsNewRequest = true;
                });
            }
        }

        public DelegateCommand CloseNewRequestCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CleareNewRequestData();
                });
            }
        }

        private void CleareNewRequestData()
        {
            IsNewRequest = false;
            SelectedReason = new Model.OdooModels.CustodyProperityLst();

        }

        public DelegateCommand SendResignationRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendResignationRequest();
                });
            }
        }


        async Task SendResignationRequest()
        {
            try
            {
                IsLoading = true;
                if (!string.IsNullOrEmpty(ReasonName))
                {


                    var model = new ResignationReasonBody()
                    {

                        employee_id = Preferences.Get("userId", 0),
                        resignation_reason_id = SelectedReason.id,
                        the_last_working_day = LastWorkingDay.Date.ToString("yyyy-MM-dd"),
                    };
                    var body = new BaseOdoModel<ResignationReasonBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendResignationRequest(body);
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetCustodyRequestLst();

                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "Erro Occured", "Cancel");

                    }




                }
                else
                {
                    await DialogService.DisplayAlertAsync("", "Enter All request Data", "Ok");

                }
            }

            //   }
            catch (Exception ex)
            {
                IsLoading = false;

            }
            finally
            {
                IsLoading = false;
            }

        }

        async Task GetCustodyRequestLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.GetResignationstLst(new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {
                        employee_id = Preferences.Get("userId", 0)
                    }
                });

                if (resp.Item2)
                {

                    Requests = resp.Item1.result.data;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

            }
        }

        async Task<ObservableCollection<CustodyProperityLst>> GetReasonnsLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.ResignationReasonstLst(new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {

                    }
                });

                if (resp.Item2)
                {

                    var data = resp.Item1.result.data;
                    return data;
                }
                IsLoading = false;

                return null;

            }
            catch (Exception ex)
            {
                IsLoading = false;

                return null;


            }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                if (parameters != null && parameters.Count > 0)
                {

                    res_model = parameters["res_model"].ToString();
                    res_id = int.Parse(parameters["res_id"].ToString());
                    var data = await GetRequestDetails();
                    SetDetailsData(data);
                }

            }
            catch (Exception ex)
            {

            }
        }
        public void SetDetailsData(CustodyLst data)
        {
            ReasonName = data.resignation_reason_id[1].ToString(); 
            LastWorkingDay = DateTimeHelper.ConvertStringTodateonly(data.the_last_working_day);
            EmployeeName = data.employee_id[1].ToString();

        }


    }

}

