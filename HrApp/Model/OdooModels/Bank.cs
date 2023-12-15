using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class Bank
	{
        public int id { get; set; }
        public int sequence { get; set; }
        public string name { get; set; }
        public string __last_update { get; set; }
        public string display_name { get; set; }
        public List<object> create_uid { get; set; }
        public string create_date { get; set; }
        public List<object> write_uid { get; set; }
        public string write_date { get; set; }
    }

   


}

