using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class PermissionsRequests:RequestStatus
	{
        public int id { get; set; }
        public string approval_status { get; set; }
   
        public int approvals_count { get; set; }

        public List<object> next_user_ids { get; set; }
        public string stage_name { get; set; }
        public string display_name { get; set; }
        public string create_date { get; set; }
        
       
        public string name { get; set; }
        public List<object> employee_id { get; set; }
       
        public object employee_manager_id { get; set; }
     
        public object department_id { get; set; }
     
        public object job_title_name { get; set; }
        public object nationality_id { get; set; }
        public object email { get; set; }
        public object phone { get; set; }
       
        public string note { get; set; }
        public object active { get; set; }
                
        public string type { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public double no_of_hours { get; set; }
    }

   


}

