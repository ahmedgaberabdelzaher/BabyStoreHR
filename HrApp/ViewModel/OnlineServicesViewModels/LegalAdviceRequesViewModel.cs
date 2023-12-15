using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Unity.Extension;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class LegalAdviceRequesViewModel : DetailsandActionsViewModel<LegalAdviceRequest>
    {

        ObservableCollection<LegalAdviceRequest> requests = new ObservableCollection<LegalAdviceRequest>();
        public ObservableCollection<LegalAdviceRequest> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }

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
        string employeeName;
        public string EmployeeName { get { return employeeName; } set { employeeName = value; RaisePropertyChanged(); } }

        string legal_type;
        public string Legal_type { get { return legal_type; } set { legal_type = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        userData selectedEmployee;
        public userData SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; RaisePropertyChanged(); } }

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public LegalAdviceRequesViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            SetLegalTypes();
            GetLegalRequestLst();

        }

        public DelegateCommand<LegalAdviceRequest> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<LegalAdviceRequest>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.legal.advice.request"
                            };
                            await Cancelrequest(body);
                            await GetLegalRequestLst();
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


        string values = "legal advice/create_contract/review_contract/official_complaint";
        Dictionary<string, string> legalDeviceTyes = new Dictionary<string, string>();
        public void SetLegalTypes()
        {
            legalDeviceTyes.Add("Legal advice", "legal_advice");
            legalDeviceTyes.Add("Create contract", "create_contract");
            legalDeviceTyes.Add("Official complaint", "official_complaint");
            legalDeviceTyes.Add("Review Contract", "review_contract");

        }
        public DelegateCommand SelectLegalTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var Types = values.Split('/');
                    var Assests = await GetReasonnsLst();
                    if (Assests != null)
                    {
                        var rs = await DialogService.DisplayActionSheetAsync("Select Legal Type", "Cancel", "", legalDeviceTyes.Keys.ToArray());
                        if (rs != null && rs != "Cancel")
                        {
                            Legal_type = rs;
                        }
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "No Data Found", "Ok");
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
            Legal_type = "";

        }

        public DelegateCommand SendRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendLegalRequest();
                });
            }
        }


        async Task SendLegalRequest()
        {
            try
            {
                IsLoading = true;
                if (!string.IsNullOrEmpty(legal_type))
                {


                    var model = new LegalAdviceRequestBody()
                    {

                        employee_id = Preferences.Get("userId", 0),
                       legal_type=legalDeviceTyes[Legal_type]
                    };
                    var body = new BaseOdoModel<LegalAdviceRequestBody>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendLegalAdviceRequest(body);
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetLegalRequestLst();

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

        async Task GetLegalRequestLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.LegalAdviceRequestLst(new BaseOdoModel<GetLeavesBody>()
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
        public void SetDetailsData(LegalAdviceRequest data)
        {

            Legal_type = legalDeviceTyes.First(c => c.Value == data.legal_type).Key;
            EmployeeName = data.employee_id[1].ToString();

        }


    }

}

