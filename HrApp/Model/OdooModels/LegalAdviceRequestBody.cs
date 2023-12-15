using System;
namespace HrApp.Model.OdooModels
{
	public class LegalAdviceRequestBody:GetLeavesBody
	{
		public string legal_type { get; set; }
	}

    public class LegalAdviceRequest : BaseRequestModel
    {
        public string legal_type { get; set; }
    }

}

