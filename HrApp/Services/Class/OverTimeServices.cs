using HrApp.Helpers;
using HrApp.Model.OverTimeModels;
using HrApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HrApp.Services.Class
{
    public class OverTimeServices : IOverTimeServices
    {
        public async Task<HttpResponseMessage> AddAppOvertimeRecord(OverTimeModel Model)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/OvertimeOperations/AddNewAppOvertime", Model);
            return response;
        }

        public async Task<Tuple<ObservableCollection<OverTimeModel>, bool, string>> GetOverTimeById(int ID)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<OverTimeModel>>(App.BaseUrl + $"api/OvertimeOperations/GetAppOvertimeById/{ID}");

            return response;
        }

        public async Task<Tuple<ObservableCollection<OverTimeModel>, bool, string>> GetOverTimeApproved()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<OverTimeModel>>(App.BaseUrl + $"api/OvertimeOperations/AppOvertimeList");

            return response;
        }

        public async Task<Tuple<ObservableCollection<OverTimeModel>, bool, string>> GetOverTimeRequests(string endpoint)
        {
            var response = await HttpManager.GetAsync<ObservableCollection<OverTimeModel>>(App.BaseUrl + $"api/OvertimeOperations/{endpoint}").ConfigureAwait(false);

            return response;

        }

        public async Task<Tuple<ObservableCollection<OverTimeModel>, bool, string>> GetOverTimeRequestsByStuffId()
        {
            var response = await HttpManager.GetAsync<ObservableCollection<OverTimeModel>>(App.BaseUrl + $"api/OvertimeOperations/GetAppOvertimeByStuffId/{Preferences.Get("userId", 0)}").ConfigureAwait(false);

            return response;
        }

        public async Task<HttpResponseMessage> OverTimeApprove( int OverID,int ASSIGN_TO)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/OvertimeOperations/OverTimeApprove/{OverID}/{ASSIGN_TO}/{Preferences.Get("userId", 0)}", new { }).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> OverTimeReject(int OverID)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/OvertimeOperations/OverTimeReject/{OverID}", new { }).ConfigureAwait(false);
            return response;
        }

        public async Task<HttpResponseMessage> OvertimeDelete(int LeaveId)
        {
            var response = await HttpManager.PostAsync(App.BaseUrl + $"api/OvertimeOperations/RemoveAppOvertime/{LeaveId}",new { }).ConfigureAwait(false);
            return response;
        }
    }
}
