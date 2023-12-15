using System;
using HrApp.Model.OdooModels;

namespace HrApp.Model
{
	public class RenewalPassportRequestBody
	{
        public int employee_id { get; set; }
        public string name_of_passport_ar { get; set; }
        public string name_of_passport_en { get; set; }
        public string passport_no { get; set; }
        public string expiration_date { get; set; }
    }
    public class RenewalPassportRequest:BaseRequestModel
    {
        public string name_of_passport_ar { get; set; }
        public string name_of_passport_en { get; set; }
        public string passport_no { get; set; }
        public string expiration_date { get; set; }
    }

}

