using System;
namespace HrApp.Model.OdooModels
{
	public class  PendingRequests
	{
        public string request_type { get; set; }
        public string request_no { get; set; }
        public string res_model { get; set; }
        public int res_id { get; set; }
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string manager_name { get; set; }
        public string date { get; set; }
    }

}

