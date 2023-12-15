using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class MedicalInsuranceViewModel : DetailsandActionsViewModel<MedicalInsuranceRequests>
    {
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<MedicalInsuranceRequests> requests = new ObservableCollection<MedicalInsuranceRequests>();
        public ObservableCollection<MedicalInsuranceRequests> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }

        CustodyProperityLst selectedReason;
        CustodyProperityLst SelectedReason { get { return selectedReason; } set { selectedReason = value; RaisePropertyChanged(); } }

        ObservableCollection<CustodyProperityLst> reasons = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> Reasons { get { return reasons; } set { reasons = value; RaisePropertyChanged(); } }

        ObservableCollection<CustodyProperityLst> selectedRelatives = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> SelectedRelatives { get { return selectedRelatives; } set { selectedRelatives = value; RaisePropertyChanged(); } }


        string insuranceFor;
        public string InsuranceFor { get { return insuranceFor; } set { insuranceFor = value; RaisePropertyChanged(); } }

        string reason = "";
        public string Reason { get { return reason; } set { reason = value; RaisePropertyChanged(); } }



        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        double amount = 0.0;
        public double Amount { get { return amount; } set { amount = value; RaisePropertyChanged(); } }


        DateTime lastWorkingDay = DateTime.Now;
        public DateTime LaymenlastWorkingDaytDate { get { return lastWorkingDay; } set { lastWorkingDay = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public MedicalInsuranceViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetAllRequests();
            SetTypes();

        }
        Dictionary<string, string> RelativeTypeLst = new Dictionary<string, string>();
        public void SetTypes()
        {
            RelativeTypeLst.Add("Employee", "employee");
            RelativeTypeLst.Add("Employee Family", "employee_family");
            RelativeTypeLst.Add("Relatives", "relatives");
        }

        public DelegateCommand<MedicalInsuranceRequests> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<MedicalInsuranceRequests>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.medical.insurance.request"
                            };
                            await Cancelrequest(body);
                            await GetAllRequests();
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

        public DelegateCommand<CustodyProperityLst> UnSelectRelativeCommand
        {
            get
            {
                return new DelegateCommand<CustodyProperityLst>(async (e) =>
                {
                    if (e != null && SelectedRelatives != null && SelectedRelatives.Count > 0)
                    {
                        SelectedRelatives.Remove(e);
                    }
                });
            }
        }

        public DelegateCommand SelectLerativeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var Data = await GetRelativeLst();
                    if (Data != null)
                    {
                        var rs = await DialogService.DisplayActionSheetAsync("Select Relative ", "Cancel", "", Data.Select(c => c.name).ToArray());
                        if (rs != null && rs != "Cancel")
                        {
                            var selectedItem = Data.First(c => c.name == rs);
                            if (!SelectedRelatives.Contains(selectedItem))
                            {
                                SelectedRelatives.Add(selectedItem);
                            }

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


        public DelegateCommand SelecInsuranceForCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {


                    var rs = await DialogService.DisplayActionSheetAsync("Insurance For: ", "Cancel", "", RelativeTypeLst.Keys.ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        InsuranceFor = rs;

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
            selectedRelatives = new ObservableCollection<CustodyProperityLst>();
           
        }

        public DelegateCommand SendRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendRequest();
                });
            }
        }


        async Task SendRequest()
        {
            try
            {
                IsLoading = true;

                if (!string.IsNullOrEmpty(InsuranceFor))
                {
                    var model = new MedicalInsuranceModel()
                    {

                        employee_id = Preferences.Get("userId", 0),
                        insurance_for = RelativeTypeLst[InsuranceFor],
                        relative_ids = SelectedRelatives?.Select(c => c.id).ToList()


                    };
                    var body = new BaseOdoModel<MedicalInsuranceModel>()
                    {
                        @params = model
                    };
                    var resp = await _onlineServices.SendRequest<MedicalInsuranceModel>(body, "medical_insurance/create_request");
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        CleareNewRequestData();
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await GetAllRequests();

                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "Erro Occured", "Cancel");

                    }

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
        async Task<ObservableCollection<CustodyProperityLst>> GetRelativeLst()
        {
            try
            {
                IsLoading = true;

                var model = new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {
                        employee_id = Preferences.Get("userId", 0)
                    }
                };
                var resp = await _onlineServices.GetRequests<CustodyProperityLst>(model, "hr_relative");
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

        async Task GetAllRequests()
        {
            try
            {
                IsLoading = true;
                var model = new BaseOdoModel<GetLeavesBody>()
                {
                    @params = new GetLeavesBody()
                    {
                        employee_id = Preferences.Get("userId", 0)
                    }
                };
                var resp = await _onlineServices.GetRequests<MedicalInsuranceRequests>(model, "medical_insurance");
                if (resp.Item2)
                {

                    /*var list = resp.Item1.OrderByDescending(i => i.reQ_DATE).ToList();
                    list.ForEach(i => Leaves.Add(i)); */

                    Requests = resp.Item1.result.data;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                IsLoading = false;

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
        public void SetDetailsData(MedicalInsuranceRequests data)
        {

            InsuranceFor=RelativeTypeLst.FirstOrDefault(x => x.Value == data.insurance_for).Key;
            EmployeeName = data.employee_id[1].ToString();
        }



    }

}

