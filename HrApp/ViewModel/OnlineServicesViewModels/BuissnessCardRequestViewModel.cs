using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class BuissnessCardRequestViewModel : DetailsandActionsViewModel<BuissnessCardRequestLst>
    {
        
        ObservableCollection<BuissnessCardRequestLst> requests = new ObservableCollection<BuissnessCardRequestLst>();
        public ObservableCollection<BuissnessCardRequestLst> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


        string business_name_ar="";
        public string Business_name_ar { get { return business_name_ar; } set { business_name_ar = value; RaisePropertyChanged(); } }

        string business_name_en="";
        public string Business_name_EN { get { return business_name_en; } set { business_name_en = value; RaisePropertyChanged(); } }

        string business_job_ar="";
        public string Business_job_ar { get { return business_job_ar; } set { business_job_ar = value; RaisePropertyChanged(); } }

        string business_job_en="";
        public string Business_job_EN { get { return business_job_en; } set { business_job_en = value; RaisePropertyChanged(); } }


        string business_work_mobile="";
        public string Business_work_mobile { get { return business_work_mobile; } set { business_work_mobile = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }

     
        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public BuissnessCardRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetBuissnessCardRequestLst();

        }


        public DelegateCommand<BuissnessCardRequestLst> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<BuissnessCardRequestLst>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.business.card.request"
                            };
                            await Cancelrequest(body);
                            await GetBuissnessCardRequestLst();
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
           Business_name_ar= Business_name_EN=Business_job_ar= Business_job_EN=Business_work_mobile= "";
        }

        public DelegateCommand AddAccessCardRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendBuisnessCardRequest();
                });
            }
        }


        async Task SendBuisnessCardRequest()
        {
            try
            {
                IsLoading = true;
                {
                    {
                        {
                            var model = new BuissnessCardRequestBody()
                            {

                                employee_id = Preferences.Get("userId", 0),
                                business_job_ar=Business_job_ar,
                                business_job_en=Business_job_EN,
                                 business_name_ar=Business_name_ar,
                                 business_name_en=Business_name_EN,
                                 business_work_mobile=Business_work_mobile
                            };
                            var body = new BaseOdoModel<BuissnessCardRequestBody>()
                            {
                                @params = model
                            };
                            var resp = await _onlineServices.SendBuisnessCardRequest(body);
                            var result = await resp.Content.ReadAsStringAsync();
                            if (resp.IsSuccessStatusCode)
                            {
                                CleareNewRequestData();
                                // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await GetBuissnessCardRequestLst();

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

        async Task GetBuissnessCardRequestLst()
        {
            try
            {
                // Requests = new ObservableCollection<AccessCardRequests>();
                IsLoading = true;
                var resp = await _onlineServices.BuissnessCrdRequestsLst(new BaseOdoModel<GetLeavesBody>()
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
        public void SetDetailsData(BuissnessCardRequestLst data)
        {
            Business_job_ar = data.business_job_ar;
            Business_job_EN = data.business_job_en;
            Business_name_ar = data.business_name_ar;
            Business_name_EN = data.business_name_en;
            Business_work_mobile = data.business_work_mobile;
            EmployeeName = data.employee_id[1].ToString();

        }
    }

}

