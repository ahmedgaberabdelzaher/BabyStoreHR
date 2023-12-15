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
	
    public class EmailRequestsViewModel : DetailsandActionsViewModel<AccessCardRequests>
    {
        
        
        ObservableCollection<AccessCardRequests> requests = new ObservableCollection<AccessCardRequests>();
        public ObservableCollection<AccessCardRequests> Requests { get { return requests; } set { requests = value; RaisePropertyChanged(); } }


     
        bool isNewRequest;
        public bool IsNewRequest { get { return isNewRequest; } set { isNewRequest = value; RaisePropertyChanged(); } }


        Services.Interface.IOnlineServices _onlineServices;
        public EmailRequestsViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(onlineServices,navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
            GetEmailtLst();

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
                                res_model = "ess.email.request"
                            };
                            await Cancelrequest(body);
                            await GetEmailtLst();
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
                return new DelegateCommand(async () =>
                {
                    var res =await DialogService.DisplayAlertAsync("Confirmation", "Are you sure you want to send email request", "Yes", "No");
                    if (res)
                    {
                        await SendEmailRequest()
;                    }
                });
            }
        }





        async Task SendEmailRequest()
        {
            try
            {
                IsLoading = true;
                {
                    {
                        {
                            var model = new BaseOdoModel<GetLeavesBody>()
                            {
                                @params = new GetLeavesBody()
                                {
                                    employee_id = Preferences.Get("userId", 0)
                                }
                            };
                             var resp = await _onlineServices.SendEmailRequest(model);
                            var result = await resp.Content.ReadAsStringAsync();
                            if (resp.IsSuccessStatusCode)
                            {
                                // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                                await GetEmailtLst();

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

        async Task GetEmailtLst()
        {
            try
            {
                IsLoading = true;
                var resp = await _onlineServices.EmailRequestLst(new BaseOdoModel<GetLeavesBody>()
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
            EmployeeName = data.employee_id[1].ToString();
        }
    }

}

