using System;
namespace HrApp.Model
{
    public class LeaveRequestBody
    {
        public int STAFF_ID { get; set; }
        public int LEAVE_CODE { get; set; }
        public DateTime DATE_FROM { get; set; }
        public DateTime DATE_TO { get; set; }
        public int NO_DAYS { get; set; }
        public string ADDRESS { get; set; }
        public string StuffFirstNameLastName { get; set; }


        public int DEPUTIZED { get; set; }
        public bool ADVANCED_SALARY { get; set; }
        public bool INCASHMENT { get; set; }
        public DateTime REQ_DATE { get; set; }
        public int ENTERED_BY { get; set; }
        public int UNPAID_DAYS { get; set; }
        public string TEL_NO { get; set; }
        public string REMARKS { get; set; }
        public string Department { get; set; }
        public byte[] SickFile { get; set; }
        public string SickFileName { get; set; }
        public string SickFileExtension { get; set; }

    }
}
