using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class AccessCardRequests:BaseRequestModel
	{
      

        public bool in_preparation_period { get; set; }
        public string request_type { get; set; }

    }
}

