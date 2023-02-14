using System;
using System.Collections.Generic;

namespace HrApp.Model.OnlineServicesModels
{

    public class Result
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Dictionary<string,string> data { get; set; }
    }

    public class OnlineServiceMenuModel
    {
        public string jsonrpc { get; set; }
        public object id { get; set; }
        public Result result { get; set; }
    }
}

