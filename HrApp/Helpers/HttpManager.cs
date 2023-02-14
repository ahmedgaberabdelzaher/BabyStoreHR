using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HrApp.Helpers;
using Polly;
using Xamarin.Essentials;
using Prism.Navigation;

using Prism.Ioc;
using HrApp;
using HrApp.Resources;
using System.Net.Http.Headers;

namespace HrApp.Helpers
{ 
    public static class HttpManager
    {

        public static INavigationService AppNavigationService => (Application.Current as App).Container.Resolve<INavigationService>();

        static App app = Application.Current as App;

        public static async Task<Tuple<T, bool, string>> GetListAsync<T>(string requestUrl) where T : class
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    var AccessToken = await SecureStorage.GetAsync("AccessToken");

                    var client = new System.Net.Http.HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + AccessToken);


                    //  client.DefaultRequestHeaders.Add("Authorization",app.CurrentToken);
                    var response = client.GetAsync(requestUrl).GetAwaiter().GetResult();
                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseJson = await response.Content.ReadAsStringAsync();
                            var JsonObject = JsonConvert.DeserializeObject<T>(responseJson);

                            return Tuple.Create(JsonObject, true, "");
                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            MainThread.BeginInvokeOnMainThread(async () =>
                            {
                                // await AppNavigationService.NavigateAsync("CustomerApp:///NavigationPage/Login");
                              //  Application.Current.MainPage = new NavigationPage(new Login());
                                Preferences.Remove("UserLogged");


                            });
                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.SessionExpired);
                        }
                        else
                        {

                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.ServerError);
                        }
                    }
                    else
                    {
                        return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.ServerErrorOrNoInternetConnection);
                    }

                }
                else
                {
                    return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.NoInternet);
                }

            }
            catch (System.Exception exp)
            {
                return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, exp.Message);
            }

        }


           public static async Task<Tuple<T, bool, string>> GetAsync<T>(string requestUrl) where T : class

        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                  var AccessToken = await SecureStorage.GetAsync("AccessToken");

                    var client = new System.Net.Http.HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + AccessToken);
                 //   client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhaG1kIiwianRpIjoiNWVmYjk4NzItMDA3OS00MTQzLWI4ZDctZTM3MTBmN2NjZGI2IiwiZW1haWwiOiIxMjEyMUB5LmNvbSIsImV4cCI6MjEwMjQxOTQxOH0.4Uf9ZvOj21OsC2RasT2sHSBH-cceXveHLUDriCdLRMI");
                    
                   // client.DefaultRequestHeaders.Add("Accept-Language","ar");
                   client.DefaultRequestHeaders.Add("LanguageId", Preferences.Get("Language", "2"));
                    var lang = Preferences.Get("LanguageId", "ar") == "en" ? "en" : "ar";
                    if (requestUrl.Contains("?"))
                    {
                        //  requestUrl = $"{requestUrl}&culture={lang}";
                        requestUrl =requestUrl+"&"+lang;

                    }
                    else
                    {
                        requestUrl = $"{requestUrl}?culture={lang}";

                    }

                    var response = await Policy
                    .Handle<HttpRequestException>(ex => !ex.Message.ToLower().Contains("404"))
                    .RetryAsync
                    (
                        retryCount: 3,
                        onRetry: (ex, time) =>
                        {
                            Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                        }
                    )
                    .ExecuteAsync(async () =>
                    {
                        Console.WriteLine($"Trying to fetch remote data...");

                        var resultJson = await client.GetAsync(requestUrl);

                        return resultJson;
                    });

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            try
                            {
                                var responseJson = await response.Content.ReadAsStringAsync();
                                var JsonObject = JsonConvert.DeserializeObject<T>(responseJson);
                                return Tuple.Create(JsonObject, true, "");

                            }
                            catch (Exception ex)
                            { throw ex; }




                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            MainThread.BeginInvokeOnMainThread( () =>
                            {
                                // await AppNavigationService.NavigateAsync("CustomerApp:///NavigationPage/Login");
                              //  Application.Current.MainPage = new NavigationPage(new Login());
                                Preferences.Remove("UserLogged");


                            });
                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.SessionExpired);
                        }
                        else
                        {

                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false,LangaugeResource.ServerError);
                        }
                    }
                    else
                    {
                        return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.ServerErrorOrNoInternetConnection);
                    }

                }
                else
                {
                    return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.NoInternet);
                }

            }
            catch (System.Exception exp)
            {
                return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, exp.Message);
            }

        }

        public static async Task<Tuple<T, bool, string>> GetAsyncWithBody<T>(string requestUrl, object Data) where T : class

        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    var AccessToken = await SecureStorage.GetAsync("AccessToken");

                    var client = new System.Net.Http.HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + AccessToken);
                    //   client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhaG1kIiwianRpIjoiNWVmYjk4NzItMDA3OS00MTQzLWI4ZDctZTM3MTBmN2NjZGI2IiwiZW1haWwiOiIxMjEyMUB5LmNvbSIsImV4cCI6MjEwMjQxOTQxOH0.4Uf9ZvOj21OsC2RasT2sHSBH-cceXveHLUDriCdLRMI");
                    client.DefaultRequestHeaders.Add("x-openerp-Session-id", Preferences.Get("SesseionId", ""));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                    jobject = JsonConvert.SerializeObject(Data);
                    var JsonObjectbody = jobject;
                    //   Console.WriteLine(JsonObject);
                    var content = new StringContent(JsonObjectbody, Encoding.UTF8, "application/json");
                    httpRequestMessage.Content = content;
                    

                    var response = await Policy
                    .Handle<HttpRequestException>(ex => !ex.Message.ToLower().Contains("404"))
                    .RetryAsync
                    (
                        retryCount: 3,
                        onRetry: (ex, time) =>
                        {
                            Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                        }
                    )
                    .ExecuteAsync(async () =>
                    {
                        Console.WriteLine($"Trying to fetch remote data...");

                        var resultJson = await client.SendAsync(httpRequestMessage);

                        return resultJson;
                    });

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            try
                            {
                                var responseJson = await response.Content.ReadAsStringAsync();
                                var JsonObject = JsonConvert.DeserializeObject<T>(responseJson);
                                return Tuple.Create(JsonObject, true, "");

                            }
                            catch (Exception ex)
                            { throw ex; }




                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                // await AppNavigationService.NavigateAsync("CustomerApp:///NavigationPage/Login");
                                //  Application.Current.MainPage = new NavigationPage(new Login());
                                Preferences.Remove("UserLogged");


                            });
                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.SessionExpired);
                        }
                        else
                        {

                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.ServerError);
                        }
                    }
                    else
                    {
                        return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.ServerErrorOrNoInternetConnection);
                    }

                }
                else
                {
                    return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.NoInternet);
                }

            }
            catch (System.Exception exp)
            {
                return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, exp.Message);
            }

        }


        public static async Task<Tuple<T, bool, string>> DeleteAsync<T>(string requestUrl) where T : class

        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    var client = new System.Net.Http.HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + Preferences.Get("UserToken", ""));
                    client.DefaultRequestHeaders.Add("Accept-Language", Preferences.Get("LanguageId", "ar"));

                    var response = await Policy
                    .Handle<HttpRequestException>(ex => !ex.Message.ToLower().Contains("404"))
                    .RetryAsync
                    (
                        retryCount: 3,
                        onRetry: (ex, time) =>
                        {
                            Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                        }
                    )
                    .ExecuteAsync(async () =>
                    {
                        Console.WriteLine($"Trying to fetch remote data...");

                        var resultJson = await client.DeleteAsync(requestUrl);

                        return resultJson;
                    });

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            try
                            {
                                var responseJson = await response.Content.ReadAsStringAsync();
                                var JsonObject = JsonConvert.DeserializeObject<T>(responseJson);
                                return Tuple.Create(JsonObject, true, "");

                            }
                            catch (Exception ex)
                            { throw ex; }

                        }

                        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            MainThread.BeginInvokeOnMainThread(async () =>
                            {
                                // await AppNavigationService.NavigateAsync("CustomerApp:///NavigationPage/Login");
                             //   Application.Current.MainPage = new NavigationPage(new Login());


                            });
                            Preferences.Remove("UserLogged");

                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.SessionExpired);
                        }
                        else
                        {

                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.ServerError);
                        }
                    }
                    else
                    {
                        return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.ServerErrorOrNoInternetConnection);
                    }

                }
                else
                {
                    return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.NoInternet);
                }

            }
            catch (System.Exception exp)
            {
                return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.ServerErrorOrNoInternetConnection);
            }

        }

        public static async Task<Tuple<bool, string>> GetAsyncString(string requestUrl)
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {

                    var AccessToken = await SecureStorage.GetAsync("AccessToken");

                    var client = new System.Net.Http.HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + AccessToken);
                    

                    var response = await Policy
                    .Handle<HttpRequestException>(ex => !ex.Message.ToLower().Contains("404"))
                    .RetryAsync
                    (
                        retryCount: 3,
                        onRetry: (ex, time) =>
                        {
                            Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                        }
                    )
                    .ExecuteAsync(async () =>
                    {
                        Console.WriteLine($"Trying to fetch remote data...");

                        var resultJson = await client.GetAsync(requestUrl);

                        return resultJson;
                    });

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            var responseJson = await response.Content.ReadAsStringAsync();
                            return Tuple.Create(true, "");



                        }
                        else
                        {
                            return Tuple.Create(false, LangaugeResource.ServerError);
                        }
                    }
                    else
                    {
                        return Tuple.Create(false, LangaugeResource.ServerErrorOrNoInternetConnection);
                    }

                }
                else
                {
                    return Tuple.Create(false, LangaugeResource.NoInternet);
                }

            }
            catch (System.Exception exp)
            {
                return Tuple.Create(false, LangaugeResource.ServerErrorOrNoInternetConnection);
            }

        }


        static string jobject;
        public static async Task<HttpResponseMessage> PostAsync<T>(string requestUrl, T Data) where T : class
        {

            try
            {
                if (NetworkCheck.IsInternet())
                {
                   
                    var AccessToken = await SecureStorage.GetAsync("AccessToken");

                    var client = new System.Net.Http.HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + AccessToken);

                    jobject = JsonConvert.SerializeObject(Data);
                    var JsonObject = jobject;
                 //   Console.WriteLine(JsonObject);
                    var content = new StringContent(JsonObject, Encoding.UTF8, "application/json");
                    if (Data == null)
                    {
                        content = null;
                    }
                    var response =await client.PostAsync(requestUrl, content).ConfigureAwait(false);
                            
                           
                       
                    // var response = await client.PostAsync(requestUrl, content).ConfigureAwait(false) ;
                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseJson = await response.Content.ReadAsStringAsync();
                            return response;
                        }

                        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            MainThread.BeginInvokeOnMainThread(async () =>
                            {
                                // await AppNavigationService.NavigateAsync("CustomerApp:///NavigationPage/Login");
                               // Application.Current.MainPage = new NavigationPage(new Login());


                            });
                            Preferences.Remove("UserLogged");

                            //    return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LangaugeResource.SessionExpired);
                            return new HttpResponseMessage() { StatusCode = response.StatusCode, ReasonPhrase = LangaugeResource.SessionExpired };
                        }
                        else
                        {

                            return new HttpResponseMessage() { StatusCode = response.StatusCode, ReasonPhrase = LangaugeResource.ServerError };
                        }
                    }
                    else
                    {
                        return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest, ReasonPhrase = LangaugeResource.ServerErrorOrNoInternetConnection };
                    }

                }
                else
                {
                    return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest, ReasonPhrase = LangaugeResource.NoInternet };
                }

            }
            catch (System.Exception exp)
            {
                return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest, ReasonPhrase = exp.Message};
            }

        }

        public static async Task<HttpResponseMessage> PutAsync<T>(string requestUrl, T Data) where T : class
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {

                    var AccessToken = await SecureStorage.GetAsync("AccessToken");

                    var client = new System.Net.Http.HttpClient();

                    if (!requestUrl.Contains("Authenticate") && !requestUrl.Contains("ForgetPassword"))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + AccessToken);

                    }
                    client.DefaultRequestHeaders.Add("Accept-Language", Preferences.Get("LanguageId", "ar"));
                    //   client.DefaultRequestHeaders.Add("Authorization", app.CurrentToken);
                    var JsonObject = JsonConvert.SerializeObject(Data);
                    var content = new StringContent(JsonObject, Encoding.UTF8, "application/json");
                    var response = await Policy
                    .Handle<HttpRequestException>(ex => !ex.Message.ToLower().Contains("404"))
                    .RetryAsync
                    (
                        retryCount: 3,
                        onRetry: (ex, time) =>
                        {
                            Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                        }
                    )
                    .ExecuteAsync(async () =>
                    {
                        Console.WriteLine($"Trying to fetch remote data...");
                        HttpResponseMessage resultJson = new HttpResponseMessage();
                        if (requestUrl.Contains("ForgetPassword"))
                        {
                            resultJson = await client.PutAsync(requestUrl, null).ConfigureAwait(false);
                        }
                        else
                        {
                            resultJson = await client.PutAsync(requestUrl, content).ConfigureAwait(false);
                        }
                        return resultJson;
                    });
                    // var response = await client.PostAsync(requestUrl, content).ConfigureAwait(false) ;
                    //           var response = await client.PutAsync(requestUrl, content);
                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseJson = await response.Content.ReadAsStringAsync();
                            return response;
                        }
                        else
                        {
                            return new HttpResponseMessage() { StatusCode = response.StatusCode, ReasonPhrase = LangaugeResource.ServerError };
                        }
                    }
                    else
                    {
                        return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest, ReasonPhrase = LangaugeResource.ServerErrorOrNoInternetConnection };
                    }

                }
                else
                {
                    return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest, ReasonPhrase = LangaugeResource.NoInternet };
                }

            }
            catch (System.Exception exp)
            {
                return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest, ReasonPhrase = LangaugeResource.ServerErrorOrNoInternetConnection };
            }

        }

    }
}