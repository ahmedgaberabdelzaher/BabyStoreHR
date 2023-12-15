using System;
namespace HrApp.Model.OdooModels
{
	public class OverTimeRequestModel:GetLeavesBody
	{
		public string date_from { get; set; }
		public string date_to { get; set; }
		public string work_location { get; set; }
	}
    public class OverTimeRequest : BaseRequestModel
    {
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string work_location { get; set; }
        public double hours { get; set; }
        public double hour_rate { get; set; }
        public double hour_amount { get; set; }
    }
}

