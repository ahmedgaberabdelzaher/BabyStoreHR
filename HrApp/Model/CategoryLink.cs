using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HrApp.Model
{
    public class CategoryLink
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
        [JsonProperty("urLs")]
        public List<string> UrLs { get; set; }
      
        public List<string> titles { get; set; }

    }
}
