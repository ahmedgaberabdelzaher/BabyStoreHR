using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HrApp.Helpers;
using HrApp.Model;
using HrApp.Services.Interface;

namespace HrApp.Services.Class
{
    public class StaffService : IStaffService
    {
        public async Task<Tuple<List<EventModel>, bool,string>> GetDepartmentScedule(int id, DateTime date)
        {
            var response = await HttpManager.GetAsync<List<EventModel>>(App.BaseUrl + $"api/CommonServices/GetDepartmentScedule/{id}/InformationTechnology/{date.ToString("s")}").ConfigureAwait(false);
            return response;
        }

        public async Task<Tuple<List<EventModel>, bool, string>> GetEmployeeAttendance(int id, DateTime fromDate, DateTime todate)
        {
            var response = await HttpManager.GetAsync<List<EventModel>>(App.BaseUrl + $"api/CommonServices/GetEmployeeAtendane/{id}/{fromDate.ToString("s")}/{todate.ToString("s")}").ConfigureAwait(false);
            return response;
        }
    }
}
