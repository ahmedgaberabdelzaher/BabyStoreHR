using System;
namespace HrApp.Model.OdooModels
{
	public class PermissionsRequestBody
	{
        public int employee_id { get; set; }
        public string type { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
    }
}

