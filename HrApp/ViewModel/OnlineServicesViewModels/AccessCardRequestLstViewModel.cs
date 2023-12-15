using System;
using System.Collections.ObjectModel;
using HrApp.Model;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Linq;
using System.Collections.Generic;
using HrApp.Model.OdooModels;
using static Xamarin.Essentials.Permissions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using HrApp.View;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	public class AccessCardRequestLstViewModel:DetailsandActionsViewModel<AccessCardRequests>
	{
        ObservableCollection<Model.LookUpModel> menuItems = new ObservableCollection<Model.LookUpModel>();
        public ObservableCollection<Model.LookUpModel> MenuItems { get { return menuItems; } set { menuItems = value; RaisePropertyChanged(); } }

        Model.LookUpModel selectedRequest;
        public Model.LookUpModel SelectedRequest { get { return selectedRequest; } set { selectedRequest = value; RaisePropertyChanged(); } }

        ObservableCollection<AccessCardRequests> requests = new ObservableCollection<AccessCardRequests>();
        public ObservableCollection<AccessCardRequests> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


        string employeeName;
        public string EmployeeName { get { return employeeName; } set { employeeName = value; RaisePropertyChanged(); } }

        string requestType;
        public string RequestType { get { return requestType; } set { requestType = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

        userData selectedEmployee;
        public userData SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; RaisePropertyChanged(); } }

        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public AccessCardRequestLstViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService,userServices)
        {
            _onlineServices = onlineServices;
            GetAccessCardRequestLst();

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
                        EmpLst= await GetAllEmployee();
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

        public DelegateCommand<AccessCardRequests> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<AccessCardRequests>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.access.card.request"
                            };
                            await Cancelrequest(body);
                            await GetAccessCardRequestLst();
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


        public DelegateCommand SelectAccessCardRequestTypeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    var rs = await DialogService.DisplayActionSheetAsync("Select Request Type", "Cancel", "","New", "scrap");
                    if (rs != null && rs != "Cancel")
                    {
                        RequestType = rs;
                    }
                });
            }
        }


        public DelegateCommand AddNewRequestCommand
        {
            get
            {
                return new DelegateCommand( () =>
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
            SelectedEmployee = new userData();
            RequestType = "";
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
                {
                    {
                        {
                            var model = new AccessCardRequestBody()
                            {

                                employee_id = Preferences.Get("userId", 0),
                                request_type = RequestType
                            };
                            var AccessCardModel = new BaseOdoModel<AccessCardRequestBody>()
                            {
                                @params = model
                            };
                            var resp = await _onlineServices.SendAccessCardRequest(AccessCardModel);
                            var result = await resp.Content.ReadAsStringAsync();
                            if (resp.IsSuccessStatusCode)
                            {
                                CleareNewRequestData();
                                // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await GetAccessCardRequestLst();

                            }
                            else
                            {
                                await DialogService.DisplayAlertAsync("", "Erro Occured", "Cancel");

                            }

                        }
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

        async Task GetAccessCardRequestLst()
        {
            try
            {
               // Requests = new ObservableCollection<AccessCardRequests>();
                IsLoading = true;
                var resp = await _onlineServices.AccessCardRequestLst(new BaseOdoModel<GetLeavesBody>()
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
        public void SetDetailsData(AccessCardRequests data)
        {

            RequestType = data.request_type;
            EmployeeName = data.employee_id[1].ToString();

        }


    }
}

