using System;
namespace HrApp.Model
{
    public class LeaveResumtionsModel
    {
        public string refNO { get; set; }
        public int id { get; set; }
        public int leavE_SERIAL { get; set; }
        public DateTime resumptioN_DATE { get; set; }
        public int resumptioN_TYPE { get; set; }
        public DateTime entereD_DATE { get; set; }
        public string remarks { get; set; }
        public int hR_APPROVE { get; set; }
        public int hR_DONE { get; set; }
        public string StuffName { get; set; }

        public int isEditDeleteAllowed { get; set; }
        public string StuffFirstNameLastName { get; set; }

        public int hR_REJECT { get; set; }
        public int assigN_TO { get; set; }
        public string department { get; set; }
        public string statusName { get; set; }
        public object resList { get; set; }
        public object hrManagerPendigRows { get; set; }
        public object hrOfficerPendigRows { get; set; }
        public LeavesModel leaveObject { get; set; }
        public string resumptionTypeName { get; set; }
    }
}
