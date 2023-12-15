using System;
namespace HrApp.Model.OdooModels
{
	public class BuissnessCardRequestBody
	{
        public int employee_id { get; set; }
        public string business_name_ar { get; set; }
        public string business_name_en { get; set; }
        public string business_job_ar { get; set; }
        public string business_job_en { get; set; }
        public string business_work_mobile { get; set; }
    }
}

