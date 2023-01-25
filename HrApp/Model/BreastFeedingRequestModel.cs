using System;
namespace HrApp.Model
{
    public class BreastFeedingRequestModel
    {

        public int StuffId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string StuffFirstNameLastName { get; set; }

        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public string Department { get; set; }
  
    }
}
