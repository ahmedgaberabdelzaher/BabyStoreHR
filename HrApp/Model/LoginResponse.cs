using System;
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
}
