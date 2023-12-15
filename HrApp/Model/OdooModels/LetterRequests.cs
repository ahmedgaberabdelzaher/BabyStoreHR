using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class LetterRequests:BaseRequestModel
	{

    
        public List<object> letter_type_id { get; set; }
        public List<object> letter_detail_id { get; set; }
        public List<object> certified_company_id { get; set; }
        public string directed_to { get; set; }
        public bool electronic_letter { get; set; }
    }



}

