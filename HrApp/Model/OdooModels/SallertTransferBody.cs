using System;
namespace HrApp.Model.OdooModels
{
	public class SallertTransferBody
	{
      public int employee_id { get; set; }
        public int new_bank_id { get; set; }
        public string new_iban_number { get; set; }
    }
}

