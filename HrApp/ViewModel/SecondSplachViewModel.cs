using HrApp.Model;
using HrApp.Services.Interface;
using HrApp.View;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HrApp.ViewModel
{
    public class SecondSplachViewModel : ViewModelBase
    {
    
        private IUserServices _userServices;
        public System.Timers.Timer timer;
        private string _navto="";

        public string Navto
        {
            get { return _navto; }
            set { _navto = value; }
        }

        public DelegateCommand SkipTapped
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                  //  timer.Close();
                   await navigate();
                });
            }
        }

        public async Task navigate()
        {

            if (!string.IsNullOrEmpty(Navto))
            {

           
               // await NavigationService.NavigateAsync("/LogIn");
              //  await NavigationService.NavigateAsync("/LogIn");

                 await NavigationService.NavigateAsync(Navto);


            }
            else
            {
                for (int i = 0; i < 25; i++)
                {
                    await Task.Delay(500);
                    if (!string.IsNullOrEmpty(Navto))
                    {
                        
                        await NavigationService.NavigateAsync(Navto);
                        break;
                    }

                }
            }
        }

        public SecondSplachViewModel(IUserServices userServices, INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            _userServices = userServices;
            Device.StartTimer(new TimeSpan(0, 0, 4), () =>
            {

                Device.BeginInvokeOnMainThread(async() =>
                {
                  await  navigate();
                });
                return false;
            });



        }


        public async  override void OnNavigatedTo(INavigationParameters parameters)
        {
          
            base.OnNavigatedTo(parameters);
        }
        public async override void Initialize(INavigationParameters parameters)
        {
            Navto = await CheckLoginAsync();
           
            base.Initialize(parameters);    
        }


        async Task<string> CheckLoginAsync()
        {
            if (Preferences.Get("IsLogedIn", false))
            {
                return "/Home";
            }
            else
            {
                return "/LogIn";
            }
            /*  try
              {
                  var EmployeeId = await SecureStorage.GetAsync("user");
                  var Password = await SecureStorage.GetAsync("passwerd");
                  var model = new NewUserModel() { Username = EmployeeId, Password = Password };
                  var resp = await _userServices.Login(model);
                  if (resp.IsSuccessStatusCode)
                  {
                      var result = await resp.Content.ReadAsStringAsync();
                      var userData = JsonConvert.DeserializeObject<LoginResponseNew>(result);


                      if (userData.statuscode == 1)
                      {
                          if (userData.stuffRecord != null)
                          {


                              Preferences.Set("Department", userData.stuffRecord.department);
                              Preferences.Set("UserName", userData.stuffRecord.name);
                              Preferences.Set("Ballance", userData.stuffRecord.leavE_BALANCE);
                              Preferences.Set("userId", userData.stuffRecord.stafF_ID);
                              Preferences.Set("role", userData.stuffRecord.employeeType);
                              string user = JsonConvert.SerializeObject(userData.stuffRecord);
                              Preferences.Set("User", user);

                          }
                          await SecureStorage.SetAsync("user", EmployeeId);
                          await SecureStorage.SetAsync("passwerd", Password);
                          //   return "/Home";
                          return "/LogIn";



                      }
                      else
                      {
                          return "/LogIn";

                      }


                  }
                  else{ 
                      return "/LogIn"; }
              }
              catch (Exception ex)
              {
                  return "/LogIn";


              }*/

        }
    }
}

        

    

