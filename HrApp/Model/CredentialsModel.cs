using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model
{
  public  class CredentialsModel
    {
        /*   public string grant_type { get; set; }
           public string scope { get; set; }
           public string client_id { get; set; }
           public string client_secret { get; set; }
   */
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }

    }


}
