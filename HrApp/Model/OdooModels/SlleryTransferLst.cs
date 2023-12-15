using System;
using System.Collections.Generic;
using HrApp.Resources;

namespace HrApp.Model.OdooModels
{
	public class SlleryTransferLst: BaseRequestModel
    {

        public dynamic current_bank_name { get; set; }
        public dynamic current_iban_number { get; set; }
        public dynamic new_bank_id { get; set; }
        public dynamic new_iban_number { get; set; }

    }

    public class RequestStatus
    {
        public string state { get; set; }
        public string status
        {
            get
            {
                if (state == "draft")
                {
                    return LangaugeResource.New;
                }
               else if (state == "waiting")
                {
                    return LangaugeResource.Waiting;
                }
                else if (state == "in_progress")
                {
                    return LangaugeResource.InProgress;
                }
                else if (state == "rejected")
                {
                    return LangaugeResource.Rejected;
                }
                else if (state == "approved")
                {
                    return LangaugeResource.Approved;
                }
                else if (state == "canceled")
                {
                    return LangaugeResource.Canceled;
                }
                return state;
            }
        }
    }




}

