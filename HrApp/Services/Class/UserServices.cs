using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using HrApp.Helpers;
using HrApp.Model;
using HrApp.Model.OdooModels;
using HrApp.Services.Interface;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Essentials;

namespace HrApp.Services.Class
{
    public class UserServices:IUserServices
    {
        public async Task<HttpResponseMessage> Register(NewUserModel model)
        {
            var response = await HttpManager.PostAsync(App.BaseAuth + $"Register/RegisterApi", model).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> Login(BaseOdoModel<NewUserModel> model)
        {
            var response = await HttpManager.PostAsync(App.BaseAuth+$"mobile_login", model).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> ResetPassword(BaseOdoModel<RessetUserPasswordModel> model)
        {
            var response = await HttpManager.PostAsync(App.BaseAuth + $"reset_password", model).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> Authonticate(AuthonticateModel model)
        {
            var response = await HttpManager.PostAsync(App.BaseAuth+$"web/session/authenticate", model).ConfigureAwait(false);
            return response;
        }
        public async Task<HttpResponseMessage> LeaveRequest(LeaveRequestBody model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/EmpLeavesOperations/AddNewEmpLeave/", model).ConfigureAwait(false);
            return response;
        }

      
        public async Task<Tuple<ObservableCollection<HREmpModel>, bool, string>> GetDepartmentStuff()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<HREmpModel>>(App.BaseUrl + $"api/CommonServices/GetDepartmentStuff/{Preferences.Get("userId",0)}").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<HREmpModel>, bool, string>> GetEmployeesByDepartment(string department)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<HREmpModel>>(App.BaseUrl + $"api/CommonServices/GetEmployeesByDepartment/{department}").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<OdooResponse<ObservableCollection<userData>>, bool, string>> GetAllEmployees()
        {
            var response = await HttpManager.GetAsyncWithBody<OdooResponse<ObservableCollection<userData>>>(App.BaseUrl + $"employees",new BaseOdoModel<LookUpModel>() { @params = new LookUpModel() { Id = 1, Name = "ESS" } }).ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeavesLst(int LeaveCode)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<LeavesModel>>(App.BaseUrl + $"api/EmpLeavesOperations/GetLeavesByLeaveCode/{LeaveCode}/{Preferences.Get("userId", 0)}").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<HrOfficersModel>, bool, string>> GetHrOfficers()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<HrOfficersModel>>(App.BaseUrl + $"api/CommonServices/GetAllOfficers").ConfigureAwait(false);

            return response;
        }

        public async Task<Tuple<ObservableCollection<CategoryLink>, bool, string>> GetCategoryLinks()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<CategoryLink>>(App.BaseUrl + $"api/CommonServices/GetQuickLinks").ConfigureAwait(false);

            return response;
        }
        public async Task<Tuple<ObservableCollection<DigitalValidModel>, bool, string>> GetDigitalValet()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<DigitalValidModel>>(App.BaseUrl + $"api/CommonServices/GetDigitalValet/{Preferences.Get("userId", 0)}").ConfigureAwait(false);

            return response;
        }

      //  https://tmsapp.westeurope.cloudapp.azure.com:4434/HR/Register/GenerateVerificationCode
        public async Task<HttpResponseMessage> GenerateVerificationCode(NewUserModel model)
        {
            var response = await HttpManager.PostAsync(App.BaseAuth + $"Register/GenerateVerificationCode", model).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> VerifyCode(NewUserModel model)
        {
            var response = await HttpManager.PostAsync(App.BaseAuth + $"Register/VerifyCode", model).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> GetDays(DaysModel model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/CommonServices/GetTotalDays", model);

            return response;
        }

        public async Task<HttpResponseMessage> CheckinCheckOut(BaseOdoModel<CheckInOutModel> model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"check_in_out_attendance", model);

            return response;
        }
        /* public async Task<Tuple<DaysModel, bool, string>> GetDays( DaysModel model)
         {
             var response = await HttpManager.PostAsync<DaysModel>(App.BaseUrl + $"api/CommonServices/GetTotalDays",model);

             return response;
         }*/
        public async Task Gettoken()
        {

            // var response = await HttpManager.PostAsync(App.BaseAuth + $"connect/token", model).ConfigureAwait(false);

            try
            {

                var client = new RestClient(App.BaseAuth + "connect/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("postman-token", "43f2315c-0328-518d-ec4a-33362701387c");
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&scope=api1&client_id=HRAPP&client_secret=DD1AB2B2-B635-4510-888F-3667F057225E", ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);

                var responseJson = response.Content;
                var JsonObject = JsonConvert.DeserializeObject<CredentialsModel>(responseJson);
                System.Globalization.DateTimeFormatInfo DTFormat;
                DTFormat = new System.Globalization.CultureInfo("en-US", false).DateTimeFormat;
                DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                var ex = DateTime.Now.AddSeconds(JsonObject.expires_in).ToString(DTFormat);
                await SecureStorage.SetAsync("AccessToken", JsonObject.access_token);
                await SecureStorage.SetAsync("AccessTokenexpires", ex.ToString()); ;


            }
            catch
            { 
            }


        }



        public async Task<Tuple<StuffRecord, bool, string>> Getuserinfo(long? userId=null)
        {
            try
            {
                if (userId == null)
                {
                    userId = Preferences.Get("userId", 0);
                }
                var response = await HttpManager.GetAsync<StuffRecord>(App.BaseUrl + $"api/OEmployeeProfile/GetEmployeeById/{userId}").ConfigureAwait(false);

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
          
        }

        public async Task<Tuple<ObservableCollection<string>, bool, string>> GetDepartments()
        {
            try
            {
  var response = await HttpManager.GetAsync<ObservableCollection<string>>(App.BaseUrl + $"api/CommonServices/GetAllDepartments").ConfigureAwait(false);

            return response;
            }
            catch (Exception ex)
            {
                return null;
            }
          
           
        }
    }
}
