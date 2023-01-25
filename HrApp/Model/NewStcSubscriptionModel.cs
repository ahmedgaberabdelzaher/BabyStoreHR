using System;
namespace HrApp.Model
{
    public class NewStcSubscriptionModel
    {
        public int StuffId { get; set; }
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Commitment { get; set; }
        public string Notes { get; set; }
        public string Department { get; set; }
        public string TypeName { get; set; }
        public int ServiceType { get; set; }
    }
}
