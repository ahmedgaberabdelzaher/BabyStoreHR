using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using HrApp.Model;

namespace HrApp.Services.Interface
{
    public interface IUserServices
    {
        Task Gettoken();
        Task<HttpResponseMessage> Register(NewUserModel model);
        Task<HttpResponseMessage> GenerateVerificationCode(NewUserModel model);
        Task<HttpResponseMessage> VerifyCode(NewUserModel model);
        Task<Tuple<StuffRecord, bool, string>> Getuserinfo(long? userId = null);

        Task<HttpResponseMessage> GetDays(DaysModel Model);
        Task<Tuple<ObservableCollection<string>, bool, string>> GetDepartments();

        Task<HttpResponseMessage> Login(NewUserModel model);
        Task<HttpResponseMessage> LeaveRequest(LeaveRequestBody model);
        Task<Tuple<ObservableCollection<HREmpModel>, bool, string>> GetDepartmentStuff();
        Task<Tuple<ObservableCollection<HREmpModel>, bool, string>> GetEmployeesByDepartment(string Department);
        Task<Tuple<ObservableCollection<LeavesModel>, bool, string>> GetLeavesLst(int LeaveCode);
        Task<Tuple<ObservableCollection<HrOfficersModel>, bool, string>> GetHrOfficers();
        Task<Tuple<ObservableCollection<CategoryLink>, bool, string>> GetCategoryLinks();
        Task<Tuple<ObservableCollection<DigitalValidModel>, bool, string>> GetDigitalValet();
        Task<HttpResponseMessage> Authonticate(AuthonticateModel model);
    }
}
