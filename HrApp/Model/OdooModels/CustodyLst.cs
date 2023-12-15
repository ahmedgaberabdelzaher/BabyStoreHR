using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class CustodyLst:BaseRequestModel
	{
        public dynamic property_id { get; set; }
        // public List<object> property_id { get; set; }
        public List<object> resignation_reason_id { get; set; }
        public string the_last_working_day { get; set; }
    }

}

