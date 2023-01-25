using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model.OverTimeModels
{
    //HRS_APP_OVERTIME
    public class OverTimeModel
    {

        /*  public int Id { get; set; }
          public string REQ_MONTH { get; set; }
          public string REQ_YEAR { get; set; }
          public int STAFF_ID { get; set; }
          public int DAYS { get; set; }
          public int MNG_APPROVE { get; set; }
          public DateTime? MNG_APP_DATE { get; set; }
          public int HR_APPROVE { get; set; }
          public int ASSIGN_TO { get; set; }
          public string REMARKS { get; set; }
          public TimeSpan TIME_IN { get; set; }
          public TimeSpan TIME_OUT { get; set; }
          public DateTime REQ_DATE { get; set; }
          public int ENTERED_BY { get; set; }
          public int MANAGER_PREVENT { get; set; }
          public int HR_DONE { get; set; }
          public int HR_REJECT { get; set; }
          public string Department { get; set; }
          public List<OverTimeModel> RowsByStuffId { get; set; }
          public List<OverTimeModel> RowsByDepartment { get; set; }
          public string StatusName { get; set; }
          public List<OverTimeModel> HrManagerPendigRows { get; set; }
          public List<OverTimeModel> HrOfficerPendigRows { get; set; }

  */

        public int id { get; set; }
        public string reQ_MONTH { get; set; }
        public string reQ_YEAR { get; set; }
        public int stafF_ID { get; set; }
        public string refNO { get; set; }
        public TimeSpan hour { get; set; }
        public int isEditDeleteAllowed { get; set; }
        public string StuffFirstNameLastName { get; set; }
        public int days { get; set; }

        public int mnG_APPROVE { get; set; }
        public object mnG_APP_DATE { get; set; }
        public int hR_APPROVE { get; set; }
        public int assigN_TO { get; set; }
        public string remarks { get; set; }
        public string timE_IN { get; set; }

        public string timE_OUT { get; set; }
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
        public IList<OverTime> overtimeItems { get; set; }


    }
    public class OverTime
    {
      
        public DateTime Date { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }

        public string Notes { get; set; }
        public int ? Day { get; set; }

        public string TimeInString { get; set; }
     
        public string TimeOutString { get; set; }


        public TimeSpan Hours
        {
            get
            {
                    if (TimeOut < TimeIn)
                {
                   return TimeOut.Add(new TimeSpan(24, 0, 0)).Subtract(TimeIn);
                }
                else
                {
                    return TimeOut.Subtract(TimeIn);
                }
            }

            
        }

    }


}
