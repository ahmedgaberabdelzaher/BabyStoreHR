using System;
namespace HrApp.Model
{
    public class EncashmentLeaves
    {
        public int id { get; set; }
        public int stuffId { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string StuffFirstNameLastName { get; set; }

        public int balance { get; set; }

        public string APPROVED_Comments { get; set; }
        public int APPROVED_Encashment_Days { get; set; }
        public object refNO { get; set; }
        public string leaveBalance { get; set; }
        public int encashment_Days { get; set; }
        public int isEditDeleteAllowed { get; set; }

        public string notes { get; set; }
        public int hR_APPROVE { get; set; }
        public int hR_DONE { get; set; }
        public int assigN_TO { get; set; }
        public string department { get; set; }
        public int hR_REJECT { get; set; }
        public string statusName { get; set; }
        public object rowsByStuffId { get; set; }
        public object hrManagerPendigRows { get; set; }
        public object hrOfficerPendigRows { get; set; }
        public object encashmentList { get; set; }

    }

}
