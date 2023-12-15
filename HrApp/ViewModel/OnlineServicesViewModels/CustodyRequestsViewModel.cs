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

namespace HrApp.ViewModel.OnlineServicesViewModels
{

    public class CustodyRequestsViewModel :DetailsandActionsViewModel<CustodyLst>
    {
        
        ObservableCollection<CustodyLst> requests = new ObservableCollection<CustodyLst>();
        public ObservableCollection<CustodyLst> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }

        ObservableCollection<CustodyProperityLst> custodyProperityLst = new ObservableCollection<CustodyProperityLst>();
        public ObservableCollection<CustodyProperityLst> CustodyProperityLst { get { return custodyProperityLst; } set { custodyProperityLst = value; RaisePropertyChanged(); } }

        CustodyProperityLst selectedAsset;
        public CustodyProperityLst SelectedAsset { get { return selectedAsset; } set { selectedAsset = value; RaisePropertyChanged(); } }


        string employeeName;
        public string EmployeeName { get { return employeeName; } set { employeeName = value; RaisePropertyChanged(); } }

        string properityName;
        public string ProperityName { get { return properityName; } set { properityName = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        userData selectedEmployee;
        public userData SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; RaisePropertyChanged(); } }

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public CustodyRequestsViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
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
                                res_model = "ess.custody.request"
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

        public DelegateCommand SelectEmployeeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    IsLoading = true;
                    if (EmpLst == null || EmpLst.Count <= 0)
                    {
                        EmpLst = await GetAllEmployee();
                    }

                    var rs = await DialogService.DisplayActionSheetAsync("Select Employee", "Cancel", "", EmpLst.Select(c => c.name_en).ToArray());
                    if (rs != null && rs != "Cancel")
                    {
                        EmployeeName = rs;
                        SelectedEmployee = EmpLst.First(c => c.name_en == rs);

                    }
                    IsLoading = false;
                });
            }
        }

        public DelegateCommand SelectAssetCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var Assests = await GetAssetsLst();
                    if (Assests != null)
                    {
                        var rs = await DialogService.DisplayActionSheetAsync("Select Request Type", "Cancel", "", Assests.Select(c => c.name).ToArray());
                        if (rs != null && rs != "Cancel")
                        {
                            ProperityName = rs;
                            SelectedAsset = Assests.First(c => c.name == ProperityName);
                        }
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", "No assets Found", "Ok");
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
            SelectedAsset = new Model.OdooModels.CustodyProperityLst();
           
        }

        public DelegateCommand AddAccessCardRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendAccessCardRequest();
                });
            }
        }


        async Task SendAccessCardRequest()
        {
            try
            {
                IsLoading = true;
                if (!string.IsNullOrEmpty(ProperityName))
{
                    
                      
                            var model = new GetLeavesBody()
                            {

                                employee_id = Preferences.Get("userId", 0),
                                property_id = SelectedAsset.id
                            };
                            var custodyBody = new BaseOdoModel<GetLeavesBody>()
                            {
                                @params = model
                            };
                            var resp = await _onlineServices.SendCustodyRequest(custodyBody);
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
                var resp = await _onlineServices.CustodyRequestLst(new BaseOdoModel<GetLeavesBody>()
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

        async Task<ObservableCollection<CustodyProperityLst>> GetAssetsLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.CustodyProberitytLst(new BaseOdoModel<GetLeavesBody>()
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
                return null;

                IsLoading = false;
            }
            catch (Exception ex)
            {
                return null;
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
        public void SetDetailsData(CustodyLst data)
        {
            EmployeeName = data.employee_id[1].ToString();
       //     SelectedAsset.name = data.property_id[1].ToString();
       
            ProperityName= data.property_id[1].ToString();

        }

    }

}

