using System;
namespace HrApp.Model
{
    public class BreastFeedingListModel
    {
        public int Id { get; set; }
        public int StuffId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string department { get; set; }

        public string RefNO { get; set; }
        public string Notes { get; set; }
        public string StuffName { get; set; }
        public int isEditDeleteAllowed { get; set; }
        public string StuffFirstNameLastName { get; set; }

        public string Department { get; set; }
        public string statusName { get; set; }
        public int mnG_APPROVE { get; set; }
        public int hR_APPROVE { get; set; }
        public int assigN_TO { get; set; }
        public int manageR_PREVENT { get; set; }
        public int hR_DONE { get; set; }
    }
}
