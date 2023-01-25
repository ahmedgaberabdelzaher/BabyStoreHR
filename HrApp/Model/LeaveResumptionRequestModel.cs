using System;
namespace HrApp.Model
{
    public class LeaveResumptionRequestModel
    {
        public int LEAVE_SERIAL { get; set; }
        public DateTime RESUMPTION_DATE { get; set; }
        public int RESUMPTION_TYPE { get; set; }
        public string StuffFirstNameLastName { get; set; }

        public DateTime ENTERED_DATE { get; set; }
        public string REMARKS { get; set; }

        public string Department { get; set; }
        public int StaffId { get; set; }
    }
}
