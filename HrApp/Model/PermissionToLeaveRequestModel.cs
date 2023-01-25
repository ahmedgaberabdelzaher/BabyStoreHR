using System;
namespace HrApp.Model
{
    public class PermissionToLeaveRequestModel
    {
       public DateTime REQUEST_DATE { get; set; }
        public string TOTAL_PERM { get; set; }
        public string REASON { get; set; }
        public TimeSpan TIME_OUT { get; set; }
        public TimeSpan TIME_IN { get; set; }
        public string Department { get; set; }
        public string StuffFirstNameLastName { get; set; }

        public int STAFF_ID { get; set; }
        public int ENTERED_BY { get; set; }
        public DateTime LeavePermissionDate { get; set; }
    }
}
