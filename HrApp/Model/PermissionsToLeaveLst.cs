using System;
namespace HrApp.Model
{
    public class PermissionsToLeaveLst
    {
        public int Id { get; set; }
        public DateTime REQUEST_DATE { get; set; }
        public int STAFF_ID { get; set; }
        public string TOTAL_PERM { get; set; }
        public string REASON { get; set; }
        public TimeSpan TIME_OUT { get; set; }
        public TimeSpan TIME_IN { get; set; }
        public int MNG_APPROVE { get; set; }
        public string StuffName { get; set; }
        public int isEditDeleteAllowed { get; set; }
        public string department { get; set; }

        
        public string StuffFirstNameLastName { get; set; }

        public DateTime? MNG_APP_DATE { get; set; }
        public int HR_APPROVE { get; set; }
        public int ASSIGN_TO { get; set; }
        public string ENTERED_BY { get; set; }
        public int MANAGER_PREVENT { get; set; }
        public int HR_DONE { get; set; }
        public string Department { get; set; }
        public string statusName { get; set; }
        public string RefNO { get; set; }
        public DateTime LeavePermissionDate { get; set; }


    }
}
