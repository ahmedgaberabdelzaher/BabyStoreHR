using System;
using System.Threading.Tasks;
using HrApp.Model;
using HrApp.Model.OdooAutonticate;
using HrApp.Model.Response;
using HrApp.Services.Interface;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using HrApp.Resources;
using System.Net;
using System.Linq;
using HrApp.Helpers;
using HrApp.Model.OdooModels;

namespace HrApp.ViewModel
{
    public class UserViewModel:ViewModelBase
    {
        bool _ShowVerify;

        public string isreset = "0";
        bool _OpenCodePopUp;
        public bool ShowVerify { get { return _ShowVerify; } set { _ShowVerify = value; RaisePropertyChanged(); } }
        public bool OpenCodePopUp { get { return _OpenCodePopUp; } set { _OpenCodePopUp = value; RaisePropertyChanged(); } }

        IUserServices _userServices;
        public UserViewModel(INavigationService navigationServices,IUserServices userServices,IPageDialogService pageDialogService):base(navigationServices,pageDialogService)
        {
            _userServices = userServices;
            isreset = "0";
        }
        string employeeId;
        string mobileNo;
        string _VerificationCode;
        public string VerificationCode { get { return _VerificationCode; } set { _VerificationCode = value;
               

                RaisePropertyChanged(); } }
        
              int _VrificationState;
        public int VrificationState { get { return _VrificationState; } set { _VrificationState = value; RaisePropertyChanged(); } }

        public string EmployeeId { get { return employeeId; } set { employeeId = value; RaisePropertyChanged(); } }
        public string MobileNo { get { return mobileNo; } set { mobileNo = value; RaisePropertyChanged(); } }
        int _VreficationCode;
        public int VreficationCode { get { return _VreficationCode; } set { _VreficationCode = value; RaisePropertyChanged(); } }


        string password;
        public string Password { get { return password; } set { password = value; RaisePropertyChanged(); } }

        string confirmPassword;
        public string ConfirmPassword { get { return confirmPassword; } set { confirmPassword = value; RaisePropertyChanged(); } }

       /* public DelegateCommand ResendCodeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await ResendCode();
                });
            }
        }*/
        public DelegateCommand ColseCodePopUpCommand
        {
            get
            {
                return new DelegateCommand( () =>
                {
                    VerificationCode = string.Empty;
                    OpenCodePopUp = false;
                });
            }
        }
        public DelegateCommand RegisterCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await Register();
                });
            }
        }
        public DelegateCommand VerifyCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await Verification();
                });
            }
        }


        public DelegateCommand RequstVerificationcommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await Register();
                });
            }
        }

        public async Task RequstVerificationCode()
        {
            try
            {
                IsLoading = true;

                var model = new NewUserModel() { Username = this.EmployeeId, Password = this.Password, ConfirmPassword = this.ConfirmPassword,Reset=int.Parse(isreset), PhoneNumber = this.MobileNo };

                var result =  await  _userServices.GenerateVerificationCode(model);
                var response = await result.Content.ReadAsStringAsync();
                var JsonObject = JsonConvert.DeserializeObject<responseVreficationCodeModel>(response);


                if (JsonObject.statusCode == 1)
                {
                    //  ShowVerify = true;
                    OpenCodePopUp = true;

                }
                else if (JsonObject.statusCode == 2)
                {
                    await DialogService.DisplayAlertAsync($"{JsonObject.statusDescription}", "Please, enter valid User Name(Employee ID) ", "OK");
                    EmployeeId = string.Empty;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task Verification()
        {
            if (!string.IsNullOrEmpty(VerificationCode))
            {
                var model = new NewUserModel() { Code = VerificationCode, Username = this.EmployeeId, Password = this.Password, Reset=int.Parse(isreset) ,ConfirmPassword = this.ConfirmPassword, PhoneNumber = this.MobileNo };

                var result = await _userServices.VerifyCode(model);              
                var response = await result.Content.ReadAsStringAsync();
                var JsonObject = JsonConvert.DeserializeObject<responseVreficationCodeModel>(response);
                
                if (JsonObject.statusCode == 1)
                {
                    await DialogService.DisplayAlertAsync("", JsonObject.statusDescription, "OK");
                 
                    await SecureStorage.SetAsync("user", EmployeeId);
                    await SecureStorage.SetAsync("passwerd", Password);
                    
                     OpenCodePopUp = false;
                    await NavigationService.GoBackAsync();
                    VerificationCode = string.Empty;
                  
                }
                else
                { 
                  var action =  await DialogService.DisplayAlertAsync($"{JsonObject.statusDescription}", "Resend verification code", "yes","Cancel");
                    if (action)
                    {
                        await RequstVerificationCode();

                    }
                    else
                    {
                        await NavigationService.GoBackAsync();
                    }

                }
            }
         
        }

        public DelegateCommand LoginCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await OdooLogin();
                });
            }
        }
        public DelegateCommand resetenavCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var parameters = new NavigationParameters();
                    parameters.Add("Isresete", "1");
                    await NavigationService.NavigateAsync("ResetPassword", parameters);
                });
            }
        }
        public DelegateCommand GoToRegisterCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                   
                    var parameters = new NavigationParameters();
                    parameters.Add("Isresete", "0");
                    await NavigationService.NavigateAsync("Register");
                });
            }
        }

        async  Task Register( )
        {
            try
            {
                IsLoading = true;
                if (Password!=ConfirmPassword)
                {
                    await DialogService.DisplayAlertAsync("", "Password and Confirm password not matched", "OK");
                    return;
                }
                //    var model = new NewUserModel() { Username =this.EmployeeId, Password = this.Password,ConfirmPassword=this.ConfirmPassword, Reset=int.Parse(isreset), PhoneNumber=this.MobileNo};
                var model = new BaseOdoModel<RessetUserPasswordModel>() { jsonrpc = "2.0", @params = new RessetUserPasswordModel() { name = this.EmployeeId, new_password = this.Password }};
                #region odoo authonticate
                var authmodel = new AuthonticateModel() { jsonrpc = "2.0", @params = new Params() { db = App.OdoDBName, login = App.OdoDUserame, password = App.OdoPasssword } };
                var authresp = await _userServices.Authonticate(authmodel);
                if (authresp.IsSuccessStatusCode)
                {
                    var result = await authresp.Content.ReadAsStringAsync();
                    var userData = JsonConvert.DeserializeObject<AuthonticateResponse>(result);
                    if (userData.error == null)
                    {
                        var responseHeaders = authresp.Headers.GetValues("Set-Cookie");
                        if (responseHeaders != null)
                        {
                            var headerValues = responseHeaders.ToList();
                            var SetCookiesHeader = headerValues[0].Split('=');
                            var sessiondId = SetCookiesHeader[1].Split(';')[0];
                            Preferences.Set("SesseionId", sessiondId);

                        }
                    }
                }
                        #endregion

                        var resp = await _userServices.ResetPassword(model);
                if (resp.IsSuccessStatusCode)
                {
                    var result = await resp.Content.ReadAsStringAsync();
                  //  var userData = JsonConvert.DeserializeObject<LoginResponse>(result);
                    /* if (calenderData.data != null)
                     {
                         return calenderData.data;
                     }*/
                  //  if (userData.statuscode == 1)
                    {
                        await DialogService.DisplayAlertAsync("", "Password Changes Succssesfuly", "OK");
                      /*  OpenCodePopUp = true;
                        await SecureStorage.SetAsync("user", EmployeeId);
                        await SecureStorage.SetAsync("passwerd", Password);*/
                        await NavigationService.GoBackAsync();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                await SecureStorage.SetAsync("user", ex.Message);
                IsLoading = false;
            }
            finally
            {
                IsLoading = false;
            }
      
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters != null && parameters.Count > 0)
            {
                isreset = parameters["Isresete"] as string;
            }
        }
        async  Task GetToken()
        {
          /*var  credentialsmodel = new CredentialsModel {
          client_id= "HRAPP",
          scope= "api1",
          client_secret= "DD1AB2B2-B635-4510-888F-3667F057225E",
          grant_type= "client_credentials"
          };*/

         await  _userServices.Gettoken();
        
        }
        /*
        async Task Login()
        {
            try
            {
                IsLoading = true;
                if (string.IsNullOrEmpty(EmployeeId)||string.IsNullOrEmpty(Password))
                {
                    await DialogService.DisplayAlertAsync("", "Please fill all data", "Ok");
                    return;
                }
                string token = Preferences.Get("FCMToken", "");
                //await DialogService.DisplayAlertAsync("",token, "Ok");
                string deviceType = "0";
                var manufacturer = Xamarin.Essentials.DeviceInfo.Manufacturer;
                if (manufacturer == "HUAWEI"&& Preferences.Get("HCM",false))
                {
                    deviceType = "1";
                }
                    var model = new NewUserModel() { Username = this.EmployeeId, Password = this.Password,AppVersion=1,FirebaseDeviceToken= token,DeviceType= deviceType };
                var resp = await _userServices.Login(model);
                
                 
                if (resp.IsSuccessStatusCode)
                {
                     await GetToken();
                    var result = await resp.Content.ReadAsStringAsync();
                   var userData = JsonConvert.DeserializeObject<LoginResponseNew>(result);
                   
                    bool isWelcome = false;
                    if (userData.statuscode == 1)
                    {
                        if (userData.stuffRecord!=null)
                        {
                            var date =DateTime.Now.AddYears(-10)- userData.stuffRecord.joininG_DATE;
                            /*if (DateTime.Now.AddYears(-10)>= userData.stuffRecord.joininG_DATE)
                            {
                                isWelcome = true;
                            }*/
                          /*  if (userData.stuffRecord.isThankyou == 1)
                            {
                                isWelcome = true;
                            }
                            Preferences.Set("Department", userData.stuffRecord.department);
                            Preferences.Set("UserName", userData.stuffRecord.name);
                            Preferences.Set("Ballance", userData.stuffRecord.leavE_BALANCE);
                            Preferences.Set("userId", userData.stuffRecord.stafF_ID);
                            Preferences.Set("role", userData.stuffRecord.employeeType);
                            Preferences.Set("IsAgent", userData.stuffRecord.isLiveAgent);

                            string user = JsonConvert.SerializeObject(userData.stuffRecord);
                            Preferences.Set("User",user);

                        }
                        Preferences.Set("IsLogedIn", true);
                      //  await SecureStorage.SetAsync("user", EmployeeId);
                        //await SecureStorage.SetAsync("passwerd", Password);
                        if (isWelcome)
                        {
                            await NavigationService.NavigateAsync("/WelcomePage");
                        }
                        else
                        {
                            await NavigationService.NavigateAsync("/Home");
                           // await NavigationService.NavigateAsync("../Profile");


                        }
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", userData.statusdescription, "OK");
                    }
                
               
                }
            }
            catch (Exception ex)
            {
                await DialogService.DisplayAlertAsync("", ex.Message, "OK");

                IsLoading = false;
            }
            finally
            {
                IsLoading = false;
            }

        }
*/
        async Task OdooLogin()
        {
            try
            {
                IsLoading = true;
                if (string.IsNullOrEmpty(EmployeeId) || string.IsNullOrEmpty(Password))
                {
                    await DialogService.DisplayAlertAsync("", "Please fill all data", "Ok");
                    return;
                }
                string token = Preferences.Get("FCMToken", "");
                //await DialogService.DisplayAlertAsync("",token, "Ok");
                string deviceType = "0";
                var manufacturer = Xamarin.Essentials.DeviceInfo.Manufacturer;
                if (manufacturer == "HUAWEI" && Preferences.Get("HCM", false))
                {
                    deviceType = "1";
                }
                var model = new AuthonticateModel() { jsonrpc= "2.0", @params=new Params() { db= App.OdoDBName, login= App.OdoDUserame, password=App.OdoPasssword }};
                var resp = await _userServices.Authonticate(model);
                if (resp.IsSuccessStatusCode)
                {
                    var result = await resp.Content.ReadAsStringAsync();
                    var userData = JsonConvert.DeserializeObject<AuthonticateResponse>(result);
                    if (userData.error == null)
                    {
                        var responseHeaders = resp.Headers.GetValues("Set-Cookie");
                        if (responseHeaders != null)
                        {
                            var headerValues = responseHeaders.ToList();
                            var SetCookiesHeader = headerValues[0].Split('=');
                            var sessiondId = SetCookiesHeader[1].Split(';')[0];
                            Preferences.Set("SesseionId", sessiondId);
                            
                        } 
                        if (userData.result != null)
                        {
                            var Loginmodel = new BaseOdoModel<NewUserModel>() { jsonrpc = "2.0", @params = new NewUserModel() { name = this.EmployeeId, password = this.password,token=token } };
                            var Loginresp = await _userServices.Login(Loginmodel);
                            if (Loginresp.IsSuccessStatusCode)
                            {
                                var Loginresult = await Loginresp.Content.ReadAsStringAsync();
                                var userRecordData = JsonConvert.DeserializeObject<OdooResponse<userData>>(Loginresult);
                                if (userRecordData.result!=null&&userRecordData.result.success)
                                {
                                     string user = JsonConvert.SerializeObject(userRecordData.result.data);
                                    var data = userRecordData.result.data;
                                    Preferences.Set("User", user);
                                     Preferences.Set("Department", data.department);
                                    Preferences.Set("UserName", data.name_en);
                                   Preferences.Set("Ballance", data.Leaves_balance);
                                    Preferences.Set("userId", data.id);
                                    Preferences.Set("role", data.rule);
                                    Preferences.Set("IsLogedIn", true);
                                    if (data.last_check_in != "false")
                                    {

                                        var checkinDate = DateTimeHelper.ConvertStringTodate(data.last_check_in);
                                        if (checkinDate.Date==DateTime.Now.Date)
                                        {
                                            Preferences.Set("IsTodayCheckedIn", true);
                                            Preferences.Set("TodayCheckedInTime", checkinDate);

                                        }
                                    }
                                    if (data.last_check_out != "false")
                                    {

                                        var checkOutDate = DateTimeHelper.ConvertStringTodate(data.last_check_out);
                                        if (checkOutDate.Date == DateTime.Now.Date)
                                        {
                                            Preferences.Set("IsTodayCheckedOut", true);
                                            Preferences.Set("TodayCheckedOutTime", checkOutDate);

                                        }
                                    }
                                    await NavigationService.NavigateAsync("../Home");

                                    return;
                                }
                                //  await SecureStorage.SetAsync("user", EmployeeId);
                                //await SecureStorage.SetAsync("passwerd", Password);
                        
                            }

                            }
                               
                            // await NavigationService.NavigateAsync("../Profile");
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("", LangaugeResource.InvalidCredentials, LangaugeResource.Ok);
                    }

                    await DialogService.DisplayAlertAsync("", LangaugeResource.InvalidCredentials, LangaugeResource.Ok);

                }
            }
            catch (Exception ex)
            {
                await DialogService.DisplayAlertAsync("", ex.Message, LangaugeResource.Ok);

                IsLoading = false;
            }
            finally
            {
                IsLoading = false;
            }

        }
    }
}
