using System;
namespace HrApp.Model.OdooModels
{
	public class BackFromVacationRequest:BaseRequestModel
	{
        public string return_date { get; set; }
    }

    public class BackFromVacationRequestBody:GetLeavesBody
    {
        public string return_date { get; set; }
    }
}

