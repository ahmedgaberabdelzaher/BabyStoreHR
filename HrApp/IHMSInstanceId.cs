using System;
using System.Threading.Tasks;

namespace HrApp
{
    public interface IHMSInstanceId
    {
        event OnNewTokenHandler OnNewToken;
        event OnTokenErrorHandler OnTokenError;
        void Initialize();
        void GetToken();
        Task<string> GetAAIDAsync();
        void DeleteAAID();
        void DeleteToken();
    }
    public delegate void OnNewTokenHandler(string token);
    public delegate void OnTokenErrorHandler(Exception exception);
}

