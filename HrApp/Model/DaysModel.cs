using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model
{
  public  class DaysModel
    {
        public int status { get; set; } 
        public double total_Dayes { get; set; }
        public string message { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public int leaveType { get; set; }
        public int stuffId { get; set; }
    }
}
