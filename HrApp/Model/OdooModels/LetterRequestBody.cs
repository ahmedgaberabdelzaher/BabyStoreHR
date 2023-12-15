using System;
namespace HrApp.Model.OdooModels
{
	public class LetterRequestBody
	{
        public int employee_id { get; set; }
        public int letter_type_id { get; set; }
        public int letter_detail_id { get; set; }
        public int certified_company_id { get; set; }
        public string directed_to { get; set; }
        public bool electronic_letter { get; set; }
    }
}

