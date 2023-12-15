using System;
namespace HrApp.Model
{
    public class Params
    {
        public string db { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }

    public class AuthonticateModel
    {
        public string jsonrpc { get; set; }
        public Params @params { get; set; }
    }

    public class BaseOdoModel<T>
    {
        public string jsonrpc { get; set; } = "2.0";
        public T @params { get; set; }
    }
}

