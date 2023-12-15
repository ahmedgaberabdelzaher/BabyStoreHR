using System;
namespace HrApp.Model.OdooModels
{
	public class RenewalResidanceRequestBody:GetLeavesBody
	{
        public string location { get; set; }
        public int duration { get; set; }
        public string expiration_date { get; set; }
    }
    public class RenewalResidanceRequestModel:BaseRequestModel
    {

        public string location { get; set; }
        public int duration { get; set; }
        public string expiration_date { get; set; }
    }
}

