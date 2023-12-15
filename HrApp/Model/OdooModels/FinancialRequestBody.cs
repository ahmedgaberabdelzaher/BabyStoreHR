using System;
namespace HrApp.Model.OdooModels
{
	public class FinancialRequestBody:GetLeavesBody
	{
		public double financial_amount { get; set; }
		public string financial_address { get; set; }
	}

    public class FinancialRequest : BaseRequestModel
    {
        public double financial_amount { get; set; }
        public string financial_address { get; set; }
    }
}

