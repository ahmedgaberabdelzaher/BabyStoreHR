using System;
namespace HrApp.Model.OdooModels
{
	public class LeaveRequestModel
	{
        public int employee_id { get; set; }
        public int leave_type_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string expected_return_date { get; set; }
        public int replacement_employee_id { get; set; }
        public string replacement_mobile { get; set; }
        public bool exit_re_entry_visa { get; set; }
    }
}

