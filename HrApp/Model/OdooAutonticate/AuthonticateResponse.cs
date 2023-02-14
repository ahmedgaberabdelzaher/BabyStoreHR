using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Polly;

namespace HrApp.Model.OdooAutonticate
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class _1
    {
        public int id { get; set; }
        public string name { get; set; }
        public int company { get; set; }
    }

    public class _148
    {
        public string symbol { get; set; }
        public string position { get; set; }
        public List<int> digits { get; set; }
    }

    public class _2
    {
        public int id { get; set; }
        public string name { get; set; }
        public int company { get; set; }
    }

    public class _3
    {
        public int id { get; set; }
        public string name { get; set; }
        public int company { get; set; }
    }

    public class AllowedBranches
    {
        [JsonProperty("1")]
        public _1 _1 { get; set; }

        [JsonProperty("2")]
        public _2 _2 { get; set; }

        [JsonProperty("3")]
        public _3 _3 { get; set; }
    }

    public class AllowedCompanies
    {
        [JsonProperty("1")]
        public _1 _1 { get; set; }
    }

    public class CacheHashes
    {
        public string translations { get; set; }
        public string load_menus { get; set; }
        public string qweb { get; set; }
        public string assets_discuss_public { get; set; }
    }

    public class CompaniesCurrencyId
    {
        [JsonProperty("1")]
        public int _1 { get; set; }
    }

    public class Currencies
    {
        [JsonProperty("148")]
        public _148 _148 { get; set; }
    }

    public class Result
    {
        public int uid { get; set; }
        public bool is_system { get; set; }
        public bool is_admin { get; set; }
        public UserContext user_context { get; set; }
        public string db { get; set; }
        public string server_version { get; set; }
        public List<object> server_version_info { get; set; }
        public string support_url { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string partner_display_name { get; set; }
        public int company_id { get; set; }
        public int partner_id { get; set; }

        [JsonProperty("web.base.url")]
        public string webbaseurl { get; set; }
        public int active_ids_limit { get; set; }
        public object profile_session { get; set; }
        public object profile_collectors { get; set; }
        public object profile_params { get; set; }
        public int max_file_upload_size { get; set; }
        public bool home_action_id { get; set; }
        public CacheHashes cache_hashes { get; set; }
        public Currencies currencies { get; set; }
        public UserCompanies user_companies { get; set; }
        public bool show_effect { get; set; }
        public bool display_switch_company_menu { get; set; }
        public List<int> user_id { get; set; }
        public int max_time_between_keys_in_ms { get; set; }
        public int company_currency_id { get; set; }
        public CompaniesCurrencyId companies_currency_id { get; set; }
        public string warning { get; set; }
        public string expiration_date { get; set; }
        public string expiration_reason { get; set; }
        public List<string> web_tours { get; set; }
        public bool tour_disable { get; set; }
        public string notification_type { get; set; }
        public bool map_box_token { get; set; }
        public bool odoobot_initialized { get; set; }
        public bool ocn_token_key { get; set; }
        public bool fcm_project_id { get; set; }
        public int inbox_action { get; set; }
        public bool iap_company_enrich { get; set; }
        public UserBranches user_branches { get; set; }
        public bool display_switch_branch_menu { get; set; }
        public List<int> allowed_branch_ids { get; set; }
    }

    public class AuthonticateResponse
    {
        public string jsonrpc { get; set; }
        public object id { get; set; }
        public Result result { get; set; }
        public Error error { get; set; }
    }

    public class UserBranches
    {
        public int current_branch { get; set; }
        public AllowedBranches allowed_branches { get; set; }
    }

    public class UserCompanies
    {
        public int current_company { get; set; }
        public AllowedCompanies allowed_companies { get; set; }
    }

    public class UserContext
    {
        public string lang { get; set; }
        public string tz { get; set; }
        public int uid { get; set; }
    }

    public class AutherrorData
    {
        public string name { get; set; }
        public string debug { get; set; }
        public string message { get; set; }
        public List<string> arguments { get; set; }
       // public Context context { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
        public AutherrorData data { get; set; }
    }


}

