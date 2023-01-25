using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HrApp.Model;

namespace HrApp.Services.Interface
{
    public interface IStaffService
    {
        Task<Tuple<List<EventModel>, bool, string>> GetDepartmentScedule(int id, DateTime date);
        Task<Tuple<List<EventModel>, bool, string>> GetEmployeeAttendance(int id, DateTime fromDate, DateTime todate);
    }
}
