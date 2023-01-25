using System;
namespace HrApp.Model
{
    public class CertificateRequestModel
    {
    public DateTime REQUEST_DATE { get; set; }
    public int ENTERED_BY { get; set; }
    public int CERT_TYPE { get; set; }
    public int LANG { get; set; }
        public int SALARY { get; set; }
        public string StuffFirstNameLastName { get; set; }

        public int BANK { get; set; }
        public string REMARKS { get; set; }
        public int STAFF_ID { get; set; }
        public string Department { get; set; }
    }
}
