using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model.OverTimeModels
{
    public class OverTimeResponseModel
    {
        public int id { get; set; }
        public string reQ_MONTH { get; set; }
        public string reQ_YEAR { get; set; }
        public int stafF_ID { get; set; }
        public string refNO { get; set; }
        public string StuffName { get; set; }
        public int isEditDeleteAllowed { get; set; }
        public string StuffFirstNameLastName { get; set; }

        public int days { get; set; }
        public int mnG_APPROVE { get; set; }
        public object mnG_APP_DATE { get; set; }
        public int hR_APPROVE { get; set; }
        public int assigN_TO { get; set; }
        public string remarks { get; set; }
        public TimeSpan timE_IN { get; set; }
        public TimeSpan timE_OUT { get; set; }
        public DateTime reQ_DATE { get; set; }
        public int entereD_BY { get; set; }
        public int manageR_PREVENT { get; set; }
        public int hR_DONE { get; set; }
        public int hR_REJECT { get; set; }
        public string department { get; set; }
        public object rowsByStuffId { get; set; }
        public object rowsByDepartment { get; set; }
        public string statusName { get; set; }
        public object hrManagerPendigRows { get; set; }
        public object hrOfficerPendigRows { get; set; }
        public object managerPendigRows { get; set; }
        public object approvedRejected { get; set; }
        public object approvedOnlyData { get; set; }


    }
}
