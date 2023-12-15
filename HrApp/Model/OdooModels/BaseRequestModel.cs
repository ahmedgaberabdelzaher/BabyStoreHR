using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class BaseRequestModel:RequestStatus
	{
        public int id { get; set; }
      //  public List<object> next_user_ids { get; set; }
        public string stage_name { get; set; }
        public string display_name { get; set; }
        public string create_date { get; set; }

        public string name { get; set; }
        public List<object> employee_id { get; set; }

      //  public List<object> employee_manager_id { get; set; }

      //  public List<object> department_id { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string reject_reason { get; set; }
       // public List<object> employee_manager_id { get; set; }
        public bool is_direct_manager { get; set; }
        public string employee_manager_arabic_name { get; set; }
       // public List<object> department_id { get; set; }
        public string department_name_ar { get; set; }
        public string job_title_name { get; set; }
        public string app_token { get; set; }
    }
}

