using System;
using HrApp.Model;
using HrApp.Model.OdooModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Prism.Services;
using Newtonsoft.Json;

namespace HrApp.ViewModel.OnlineServicesViewModels
{
	public class DetailsandActionsViewModel<T>:ViewModelBase
	{
        bool isShowRejectionReason;
        public bool IsShowRejectionReason { get { return isShowRejectionReason; } set { isShowRejectionReason = value; RaisePropertyChanged(); } }

        string rejectionReason = "";
        public string RejectionReason { get { return rejectionReason; } set { rejectionReason = value; RaisePropertyChanged(); } }

        Services.Interface.IOnlineServices _onlineServices;
        public DetailsandActionsViewModel(Services.Interface.IOnlineServices onlineServices, INavigationService navigationService, IPageDialogService pageDialogService, Services.Interface.IUserServices userServices) : base(navigationService, pageDialogService, userServices)
        {
            _onlineServices = onlineServices;
		}

      protected  async Task<T> GetRequestDetails()
        {
            try
            {
                IsLoading = true;

                var model = new BaseOdoModel<GetRequestDetailsBody>()
                {
                    @params = new GetRequestDetailsBody()
                    {
                        res_id = res_id,
                        res_model = res_model
                    }
                };
                var resp = await _onlineServices.GetRequestDeatils<T>(model);
                if (resp.Item2)
                {

                    var result = resp.Item1.result.data;
                    var data = result[0];
                   
                    return data;
                }
                IsLoading = false;

                return default(T);

            }
            catch (Exception ex)
            {
                IsLoading = false;

                return default(T);


            }
            finally { IsLoading = false; }
        }

       public static string res_model = "";
       public static int res_id = 0;

        protected async Task Cancelrequest(GetRequestDetailsBody cancelBody)
        {
            try
            {
                IsLoading = true;

                var model = new BaseOdoModel<GetRequestDetailsBody>()
                {
                    @params = cancelBody
                };
                var resp = await _onlineServices.CancelRequest(model);
                var result = await resp.Content.ReadAsStringAsync();
                if (resp.IsSuccessStatusCode)
                {
                    await DialogService.DisplayAlertAsync("", "Your Action has been submitted successfully", "Ok");
                }
               
                IsLoading = false;

             

            }
            catch (Exception ex)
            {
                IsLoading = false;

             


            }
            finally { IsLoading = false; }
        }



        public override async void Initialize(INavigationParameters parameters)
        {


            base.Initialize(parameters);
        }
        public DelegateCommand ApproveRequestCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await ApproveRejectRequest(1);
                });
            }
        }



        public DelegateCommand RejectCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {

                    IsShowRejectionReason = true;
                });

            }
        }
        public DelegateCommand CancelRejectCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {

                    IsShowRejectionReason = false;
                });

            }
        }

        public DelegateCommand RejectRequestActionCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    await ApproveRejectRequest(2);
                });
            }
        }

        async Task ApproveRejectRequest(int actionType)
        {
            try
            {
                IsLoading = true;

                {
                    var model = new ApproveeRejectModel()
                    {

                        employee_id = Preferences.Get("userId", 0),
                        res_id = res_id,
                        res_model = res_model,
                        reason = RejectionReason

                    };
                    var body = new BaseOdoModel<ApproveeRejectModel>()
                    {
                        @params = model
                    };
                    string actionText = "";
                    HttpResponseMessage resp = new HttpResponseMessage();
                    if (actionType == 1)
                    {
                        resp = await _onlineServices.ApproveRequest<ApproveeRejectModel>(body);
                        actionText = "Approved";
                    }
                    else
                    {
                        resp = await _onlineServices.RejectRequest<ApproveeRejectModel>(body);
                        actionText = "Rejected";
                    }
                    //  resp = await _onlineServices.ApproveRequest<ApproveeRejectModel>(body, "overtime/create_request");
                    var result = await resp.Content.ReadAsStringAsync();
                    if (resp.IsSuccessStatusCode)
                    {
                        // await DialogService.DisplayAlertAsync("", "Your request has been submitted successfully", "Ok");
                        await DialogService.DisplayAlertAsync("", "Your Action has been submitted successfully", "Ok");
                        await NavigationService.GoBackAsync();

                    }
                                        else
                    {
                        await DialogService.DisplayAlertAsync("", "Erro Occured", "Cancel");

                    }
                    FCMNotification notification = new FCMNotification();
                    notification.title = "Request Status Changed";
                    notification.body = "Your request has been "+ actionText+" By"+Preferences.Get("UserName","");
                    FCMData data = new FCMData();
                    data.key1 = "";
                    data.key2 = "";
                    data.key3 = "";
                    data.key4 = "";

                    var notbody = new FCMBody()
                    {
                        data = data,
                        notification = notification,
                        registration_ids = new[] { Preferences.Get("FCMToken", "") }
                    };
                    await SendNotification(notbody);

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


        public async Task<bool> SendNotification(FCMBody fcmBody)
        {
            try
            {
                var httpContent = JsonConvert.SerializeObject(fcmBody);
                var client = new HttpClient();
                var authorization = string.Format("key={0}", "AAAAiKlSHzc:APA91bEKvyWWCvj209HzD7a7LuzZ3p2VSYVRt6zbKGL1zqBJnvjN2yrFOXnThnaB8lwtnPcTW5aWx3sKjRvXZpRFy9QazfugEfGMibzyRQx_f2VCHEvExBWc7Z2-8azA9eiM0h9KsBrT");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorization);
                var stringContent = new StringContent(httpContent);
                stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                string uri = "https://fcm.googleapis.com/fcm/send";
                var response = await client.PostAsync(uri, stringContent).ConfigureAwait(false);
                var result = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (TaskCanceledException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

