using System;
namespace HrApp.Model.OdooModels
{
	public class SalaryIncreaserRequestBody:GetLeavesBody
	{
		public double amount { get; set; }
		public string increase_type { get; set; }
	}
    public class SalaryIncreaserRequestModel : BaseRequestModel
    {
        public double amount { get; set; }
        public string increase_type { get; set; }
    }
}

