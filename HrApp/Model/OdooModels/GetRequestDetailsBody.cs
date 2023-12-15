using System;
namespace HrApp.Model.OdooModels
{
	public class GetRequestDetailsBody
	{
        public string res_model { get; set; }
        public int res_id { get; set; }
    }
  public class ApproveeRejectModel: GetRequestDetailsBody
    {
        public int employee_id { get; set; }
        public string reason { get; set; }
    }


}

