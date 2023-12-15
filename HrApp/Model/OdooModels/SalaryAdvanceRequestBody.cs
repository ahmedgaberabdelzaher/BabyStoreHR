using System;
namespace HrApp.Model.OdooModels
{
	public class SalaryAdvanceRequestBody:GetLeavesBody
	{
		public double amount { get; set; }
		public string reason { get; set; }
        public string date { get; set; }
    }
    public class SalaryAdvanceRequest: BaseRequestModel
    {
        public double amount { get; set; }
        public string reason { get; set; }
        public string date { get; set; }
    }
}

