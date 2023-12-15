using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class EmployeeTransferRequestBody:GetLeavesBody
	{
		public int new_department_id { get; set; }
        public string start_date { get; set; }
    }

    public class EmployeeTransferRequestModel:BaseRequestModel
    {
        public List<object> new_department_id { get; set; }
        public string start_date { get; set; }
    }
}

