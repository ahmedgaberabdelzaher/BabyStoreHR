using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class TerminationRequestBody:GetLeavesBody
	{
		public int termination_reason_id { get; set; }
        public string the_last_working_day { get; set; }
    }
    public class TerminationRequest : BaseRequestModel
    {
        public List<object> termination_reason_id { get; set; }
        public string the_last_working_day { get; set; }
    }
}

