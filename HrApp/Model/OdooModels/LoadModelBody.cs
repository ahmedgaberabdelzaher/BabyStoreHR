using System;
namespace HrApp.Model.OdooModels
{
	public class LoanModelBody:GetLeavesBody
	{
		public double amount { get; set; }
        public string payment_date { get; set; }
        public int installment { get; set; }
    }
    public class LoadRequestModel : BaseRequestModel
    {
        public double amount { get; set; }
        public int installment { get; set; }
        public string payment_date { get; set; }

    }
}

