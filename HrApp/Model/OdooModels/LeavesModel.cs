using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class LeaveRequestsModel:BaseRequestModel
	{
        // public int employee_id { get; set; }
        public List<object> replacement_employee_id { get; set; }
        public string employee_name { get; set; }

        public string start_date { get; set; }
        public string end_date { get; set; }
        public string expected_return_date { get; set; }
        public List<object> leave_type_id { get; set; }
        public string leave_type_name
        {
            get
            {
                if (leave_type_id!=null&&leave_type_id.Count>0)
                {
                    return leave_type_id[1].ToString();
                }
                return "";
            }
        }
        // public int replacement_employee_id { get; set; }
        public string replacement_employee_name
        {
            get
            {
                if (replacement_employee_id != null && replacement_employee_id.Count > 0)
                {
                    return replacement_employee_id[1].ToString();
                }
                return "";
            }
        }
        public string replacement_mobile { get; set; }
        public bool leave_or_return { get; set; }       
    }
}

