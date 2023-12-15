using System;
namespace HrApp.Model.OdooModels
{
	public class AttentionRequestBody:GetLeavesBody
	{
		public string message { get; set; }
	}
    public class AttentionRequestModel : BaseRequestModel
    {
        public string message { get; set; }
    }
}

