using System;
using System.Linq;

namespace HrApp.Model
{
    public class LeavesModel
    {
        public int id { get; set; }
        public int stafF_ID { get; set; }
        public int leavE_CODE { get; set; }
        public DateTime datE_FROM { get; set; }
        public DateTime datE_TO { get; set; }
        public string StuffFirstNameLastName { get; set; }
        public int isEditDeleteAllowed { get; set; }
        public int nO_DAYS { get; set; }
        public string address { get; set; }
        public int deputized { get; set; }
        public bool advanceD_SALARY { get; set; }
        public bool incashment { get; set; }
        public int mnG_APPROVE { get; set; }
        public object mnG_APP_DATE { get; set; }
        public int hR_APPROVE { get; set; }
        public int assigN_TO { get; set; }
        public DateTime reQ_DATE { get; set; }
        public int entereD_BY { get; set; }
        public int unpaiD_DAYS { get; set; }
        public string teL_NO { get; set; }
        public int manageR_PREVENT { get; set; }
        public int hR_DONE { get; set; }
        public int hoD_APPROVE { get; set; }
        public string remarks { get; set; }
        public int balance { get; set; }

       
        public string department { get; set; }
        public object rowsByStuffId { get; set; }
        public object rowsByDepartment { get; set; }
        public object statusName { get; set; }
        public object hrManagerPendigRows { get; set; }
        public object hrOfficerPendigRows { get; set; }
        public object empList { get; set; }
        public string refNO { get; set; }
        public string leaveName
        {
            get
            {
                if (leavE_CODE!=0)
                {
                    return App.LeaveTypes.First(c => c.Id == leavE_CODE).Name;
                }
                return "";
            } }
        public string filecontentstring { get; set; }
    }
}
