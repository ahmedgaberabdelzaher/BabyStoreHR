using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
    public class Attendance
    {
        public int id { get; set; }
        public dynamic employee_id { get; set; }
        public dynamic department_id { get; set; }
        public string check_in { get; set; }
        public string check_out { get; set; }
        public double worked_hours { get; set; }
        public string __last_update { get; set; }
        public string display_name { get; set; }
        public dynamic create_uid { get; set; }
        public string create_date { get; set; }
        public dynamic write_uid { get; set; }
        public string write_date { get; set; }
    }

    public class AttendanceData
    {
        public string employee_name { get; set; }
        public string pin { get; set; }
        public Attendance attendance { get; set; }
        public double total_overtime { get; set; }
    }

}

