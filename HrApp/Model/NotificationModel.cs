using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model
{
   public class NotificationModel
    {
        public int id { get; set; }
        public int employeeId { get; set; }
        public int requestId { get; set; }
        public string requestRef { get; set; }
        public int requestTypes { get; set; }
        public DateTime notificationDate { get; set; }
        public string StuffFirstNameLastName { get; set; }
        public string department { get; set; }

        public int notificationStatus { get; set; }
        public int notificationType { get; set; }
        public int requestStatus { get; set; }
        public int employeeType { get; set; }
        public string requestTypeName { get; set; }
    }
}
