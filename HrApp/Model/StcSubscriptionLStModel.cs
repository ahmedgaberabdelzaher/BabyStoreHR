using System;
namespace HrApp.Model
{
    public class StcSubscriptionLStModel
    {
        public int Id { get; set; }
        public int StuffId { get; set; }
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }
        public string RefNO { get; set; }
        public string Commitment { get; set; }
        public string Notes { get; set; }
        public string department { get; set; }

        public string StuffName { get; set; }
        public int isEditDeleteAllowed { get; set; }
        public string StuffFirstNameLastName { get; set; }
        public int? ServiceType { get; set; }
        public string ServiceTypeName { get; set; }


        public int HR_DONE { get; set; }
        public int ASSIGN_TO { get; set; }
        public string Department { get; set; }
        public string statusName { get; set; }

    }
    public class StcTyps
    {
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public int type { get; set; }
        public string descriptionAr { get; set; }
        public string descriptionEn { get; set; }
        public object code { get; set; }

    }
}
