using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class BuisnessTravelRequestBody
	{
        public int employee_id { get; set; }
        public string description { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public bool eligible_for_ticket { get; set; }
        public string travel_type { get; set; }
        public string way_to_travel { get; set; }
        public string ticket_type { get; set; }
        public List<int> travel_cover_ids { get; set; }
    }
}

