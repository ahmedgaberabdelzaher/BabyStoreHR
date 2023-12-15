using System;
using System.Globalization;

namespace HrApp.Helpers
{
	public static class DateTimeHelper
	{
		public static DateTime ConvertStringTodate(string dateStr)
		{
		return	DateTime.ParseExact(dateStr, "yyyy-MM-dd HH:m:ss", CultureInfo.InvariantCulture);

        }
        public static DateTime ConvertStringTodateonly(string dateStr)
        {
            return DateTime.ParseExact(dateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        }
        public static DateTime DateTimeFormater(DateTime dateTime)
        {
            try
            {
                System.Globalization.DateTimeFormatInfo DTFormat;
                DTFormat = new System.Globalization.CultureInfo("en-US", false).DateTimeFormat;
                DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                return DateTime.Parse(dateTime.ToString(DTFormat.ShortDatePattern, new CultureInfo("en-US")));
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }


        }
    }
}

