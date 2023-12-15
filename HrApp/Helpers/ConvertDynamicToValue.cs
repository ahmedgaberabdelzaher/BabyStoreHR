using System;
using Newtonsoft.Json.Linq;

namespace HrApp.Helpers
{
	public static class ConvertDynamicToValue
	{
		public static string Convert(dynamic Dynamicvalue)
			{
			string value = "";
            Type t = Dynamicvalue.GetType();
            if (Dynamicvalue is JArray)
			{
                value= Dynamicvalue[1].ToString();

            }
			else
			{
				value= Dynamicvalue.ToString();

            }
			return value;

        }
	}
}

