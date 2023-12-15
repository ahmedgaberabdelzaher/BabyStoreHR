using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class MedicalInsuranceModel:GetLeavesBody
	{
        public List<int> relative_ids { get; set; }
        public string insurance_for { get; set; }
    }

    public class MedicalInsuranceRequests : BaseRequestModel
    {
        public List<int> relative_ids { get; set; }
        public string insurance_for { get; set; }
    }
}

