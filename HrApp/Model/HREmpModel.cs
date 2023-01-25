using System;
namespace HrApp.Model
{
    public class HREmpModel
    {
        public int stafF_ID { get; set; }
        public string civiL_ID { get; set; }
        public string name { get; set; }
        public string photograph { get; set; }
        public string designation { get; set; }
        public string mobilE_NO { get; set; }

        public string department { get; set; }
        public string banK_NAME { get; set; }
        public string ibaN_NO { get; set; }
        public string email { get; set; }
        public string contacT_NO { get; set; }


        public string UserImage
        {
            get
            {
               return string.IsNullOrEmpty(photograph) ? "ProfileIconDefault.png" : photograph;
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
