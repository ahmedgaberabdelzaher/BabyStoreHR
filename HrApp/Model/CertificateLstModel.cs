using System;
namespace HrApp.Model
{
    public class CertificateLstModel
    {
        public int id { get; set; }
        public int stafF_ID { get; set; }
        public DateTime requesT_DATE { get; set; }
        public string cerT_TYPE { get; set; }
        public int entereD_BY { get; set; }
        public string department { get; set; }

        public int mnG_APPROVE { get; set; }
        public int hR_APPROVE { get; set; }
        public int assigN_TO { get; set; }
        public int mnG_REJECT { get; set; }
        public int isEditDeleteAllowed { get; set; }
        public string StuffFirstNameLastName { get; set; }

        public int hR_REJECT { get; set; }
        public int lang { get; set; }
        public bool salary { get; set; }
        public string StuffName { get; set; }

        public bool bank { get; set; }
        public int manageR_PREVENT { get; set; }
        public int hR_DONE { get; set; }
        public object refNO { get; set; }
        public string remarks { get; set; }
        public object rowsByStuffId { get; set; }
        public string statusName { get; set; }
        public object hrManagerPendigRows { get; set; }
        public object hrOfficerPendigRows { get; set; }
        public object certList { get; set; }
        public object approvedRejectedData { get; set; }
        public object approvedOnlyData { get; set; }
        public string cerT_TYPE_NAME { get; set; }
        public string banK_Name { get; set; }
            
    }



}
