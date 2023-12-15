using System;
using System.Collections.Generic;

namespace HrApp.Model.OdooModels
{
	public class BuissnessCardRequestLst:BaseRequestModel
	{
            public string business_name_ar { get; set; }
            public string business_name_en { get; set; }
            public string business_job_ar { get; set; }
            public string business_job_en { get; set; }
            public string business_work_mobile { get; set; }
        }

    }

