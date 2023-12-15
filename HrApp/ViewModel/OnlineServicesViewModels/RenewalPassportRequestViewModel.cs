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
using HrApp.Helpers;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	
    public class RenewalPassportRequestViewModel : DetailsandActionsViewModel<RenewalPassportRequest>
    {

        ObservableCollection<RenewalPassportRequest> requests = new ObservableCollection<RenewalPassportRequest>();
        public ObservableCollection<RenewalPassportRequest> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


        string name_of_passport_ar = "";
        public string Name_of_passport_ar { get { return name_of_passport_ar; } set { name_of_passport_ar = value; RaisePropertyChanged(); } }

        string name_of_passport_en = "";
        public string Name_of_passport_en { get { return name_of_passport_en; } set { name_of_passport_en = value; RaisePropertyChanged(); } }

        string passport_no = "";
        public string Passport_nopassport_no { get { return passport_no; } set { passport_no = value; RaisePropertyChanged(); } }

        string business_job_en = "";
        public string Business_job_EN { get { return business_job_en; } set { business_job_en = value; RaisePropertyChanged(); } }


        DateTime expiration_date = DateTime.Now;
        public DateTime Expiration_date { get { return expiration_date; } set { expiration_date = value; RaisePropertyChanged(); } }

        ObservableCollection<userData> empLst = new ObservableCollection<userData>();
        public ObservableCollection<userData> EmpLst { get { return empLst; } set { empLst = value; RaisePropertyChanged(); } }


        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public RenewalPassportRequestViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetRenewalPassportRequesLst();

        }



        public DelegateCommand<RenewalPassportRequest> CancelRequestCommand
        {
            get
            {
                return new DelegateCommand<RenewalPassportRequest>(async (e) =>
                {
                    try
                    {
                        IsLoading = true;
                        if (e != null)
                        {
                            var body = new GetRequestDetailsBody()
                            {
                                res_id = e.id,
                                res_model = "ess.renewal.passport.request"
                            };
                            await Cancelrequest(body);
                            await GetRenewalPassportRequesLst();
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
        }

        public DelegateCommand SendRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await SendRenewalPassportReque();
                });
            }
        }


        async Task SendRenewalPassportReque()
        {
            try
            {
                IsLoading = true;
                {
                    {
                        {
                            var model = new RenewalPassportRequestBody()
                            {

                                employee_id = Preferences.Get("userId", 0),
                                expiration_date = expiration_date.ToString("yyyy-MM-dd"),
                                 name_of_passport_ar=Name_of_passport_ar,
                                  name_of_passport_en=Name_of_passport_en,
                                   passport_no=Passport_nopassport_no
                            };
                            var body = new BaseOdoModel<RenewalPassportRequestBody>()
                            {
                                @params = model
                            };
                            var resp = await _onlineServices.SendRenewPassportRequest(body);
                            var result = await resp.Content.ReadAsStringAsync();
                            if (resp.IsSuccessStatusCode)
                            {
                                CleareNewRequestData();
                                // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await GetRenewalPassportRequesLst();

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

        async Task GetRenewalPassportRequesLst()
        {
            try
            {
                // Requests = new ObservableCollection<AccessCardRequests>();
                IsLoading = true;
                var resp = await _onlineServices.enewalPassportRequesLst(new BaseOdoModel<GetLeavesBody>()
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
        public void SetDetailsData(RenewalPassportRequest data)
        {

            expiration_date= DateTimeHelper.ConvertStringTodateonly(data.expiration_date);
            Name_of_passport_ar = data.name_of_passport_ar;
            Name_of_passport_en = data.name_of_passport_en;
            Passport_nopassport_no = data.passport_no;
            EmployeeName = data.employee_id[1].ToString();

        }

    }

}

