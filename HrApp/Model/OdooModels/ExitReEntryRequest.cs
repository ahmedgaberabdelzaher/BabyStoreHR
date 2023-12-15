using System;
namespace HrApp.Model.OdooModels
{
	public class ExitReEntryRequestBody:GetLeavesBody
	{
        public string leave_from { get; set; }
        public string leave_to { get; set; }
        public string duration_type { get; set; }
        public int duration { get; set; }
    }
    public class ExitReEntryRequest : BaseRequestModel
    {
        public string leave_from { get; set; }
        public string leave_to { get; set; }
        public string duration_type { get; set; }
        public int duration { get; set; }
    }
}

