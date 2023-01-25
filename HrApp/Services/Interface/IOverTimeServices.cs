using HrApp.Model.OverTimeModels;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace HrApp.Services.Interface
{
    public interface IOverTimeServices
    {
        Task<HttpResponseMessage> OverTimeApprove(int OverID, int ASSIGN_TO);
        Task<HttpResponseMessage> OverTimeReject(int OverID);
        Task<HttpResponseMessage> AddAppOvertimeRecord(OverTimeModel Model);
        Task<HttpResponseMessage> OvertimeDelete(int LeaveId);


        Task<Tuple<ObservableCollection<OverTimeModel>, bool, string>> GetOverTimeApproved();
        //ToDo Add Aproved and Pendeing  here
        Task<Tuple<ObservableCollection<OverTimeModel>, bool, string>> GetOverTimeRequests(string endpoint);
        Task<Tuple<ObservableCollection<OverTimeModel>, bool, string>> GetOverTimeById(int ID);
        Task<Tuple<ObservableCollection<OverTimeModel>, bool, string>> GetOverTimeRequestsByStuffId();



    }
}
