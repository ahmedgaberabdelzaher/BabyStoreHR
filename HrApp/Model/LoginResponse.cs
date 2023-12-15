using System;
using Xamarin.Essentials;

namespace HrApp.Model
{
    public class LoginResponse
    {
        public int statuscode { get; set; }
        public string statusdescription { get; set; }
    }
    public class LoginResponseNew: LoginResponse
    {
        public StuffRecord stuffRecord { get; set; }
    }
    public class StuffRecord
    {
        
            public string StuffFirstNameLastName { get; set; }
        public int stafF_ID { get; set; }
        public DateTime joininG_DATE { get; set; }
        public string civiL_ID { get; set; }
        public string name { get; set; }
        public string photograph { get; set; }
        public DateTime birtH_DATE { get; set; }
        public string designation { get; set; }
        public string mobilE_NO { get; set; }
         public int isLiveAgent { get; set; }
        public int isThankyou { get; set; }

        public string department { get; set; }
        public int contacT_NO { get; set; }
        public string banK_NAME { get; set; }
        public string ibaN_NO { get; set; }
        public int leavE_BALANCE { get; set; }
        public string email { get; set; }
        public int employeeType { get; set; }
       
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class userData
    {
        public int id { get; set; }
        public string name_en { get; set; }
        public string name_ar { get; set; }
        public string code { get; set; }
        public string barcode { get; set; }
        public string identification_id { get; set; }
        public string bank { get; set; }
        public string iban { get; set; }
        public string employee_manager_id { get; set; }
        public string department { get; set; }
        public string job_title { get; set; }
        public string nationality { get; set; }
        public string work_email { get; set; }
        public string phone { get; set; }
        public string company { get; set; }
        public double Leaves_balance { get; set; }
        public string joining_date { get; set; }
        public string last_check_in { get; set; }
        public string last_check_out { get; set; }
        public string rule { get; set; }
        public string name
        {
            get
            {
                if (Preferences.Get("LanguageId", "en") == "en")
                {
                    return name_en;
                }
                else
                {
                    if (!string.IsNullOrEmpty(name_ar) && name_ar != "false")
                    {
                        return name_ar;
                    }
                }
                return name_en;
            }
        }
        public double currentSallery { get; set; } = 0.0;
        public string image { get; set; }

    }

    public class OdooResponseResult<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }

    public class OdooResponse<T>
    {
        public string jsonrpc { get; set; }
        public object id { get; set; }
        public OdooResponseResult<T> result { get; set; }
    }



}
