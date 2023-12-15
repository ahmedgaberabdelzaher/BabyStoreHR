using System;
namespace HrApp.Model
{
    public class EncashmentLeaveModel
    {
        public int StuffId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double LeaveBalance { get; set; }
        public string StuffFirstNameLastName { get; set; }
        public int APPROVED_Encashment_Days { get; set; }
        public string APPROVED_Comments { get; set; }
        public double balance { get; set; }
        public int Encashment_Days { get; set; }

        public string Notes { get; set; }
        public string Department { get; set; }
    }
}
