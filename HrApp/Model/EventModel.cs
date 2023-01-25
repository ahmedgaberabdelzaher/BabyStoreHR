using System;
using System.Globalization;
using Newtonsoft.Json;

namespace HrApp.Model
{
    public class EventModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("employeeId")]
        public long EmployeeId { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("fromTime")]
        public DateTime? FromTime { get; set; }

        [JsonProperty("toTime")]
        public DateTime? ToTime { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public string FromTo
        {
            get
            {
                string from = FromTime == null ? " " : FromTime.Value.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                string to = ToTime == null ? " " : ToTime.Value.ToString("hh:mm");
                return $"{from} - {to}";
            }

        }

        public string FromatedTime
        {
            get
            {
                return Date == null ? " " : FromTime.Value.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            }

        }
    }
}
