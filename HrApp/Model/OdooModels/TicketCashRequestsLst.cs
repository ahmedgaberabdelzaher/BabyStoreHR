using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class TicketCashRequestsLst:BaseRequestModel
	{
        public string note { get; set; }
        public string contract_date { get; set; }
        public double amount { get; set; }
        public string join_date { get; set; }
        public object payment_id { get; set; }
    }

    

}

