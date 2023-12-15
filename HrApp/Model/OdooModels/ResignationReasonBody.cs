using System;
namespace HrApp.Model.OdooModels
{
	public class ResignationReasonBody
	{
        public int employee_id { get; set; }
        public int resignation_reason_id { get; set; }
        public string the_last_working_day { get; set; }
    }

}

