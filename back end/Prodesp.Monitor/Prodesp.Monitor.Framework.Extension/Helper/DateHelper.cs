using System;
using System.Globalization;

namespace Prodesp.Monitor.Framework.Extension.Helper
{
    public static class DateHelper
    {
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public static DateTime? ToDateTimeBr(string value)
        {
            var date = Gsnet.Framework.HelperConvert.ToDateTimeBr(value);
            return Gsnet.Framework.HelperValidation.IsValidDate(date) ? date : default(DateTime?);
        }

        public static string ToDateTimeString(this DateTime? date)
        {
            return date.HasValue ? ToDateTimeString(date.Value) : "";
        }

        public static string ToDateTimeString(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy hh:mm:ss tt", new CultureInfo("en-US", false).DateTimeFormat);
        }

        public static string ToDateString(this DateTime? date)
        {
            return date.HasValue ? ToDateTimeString(date.Value) : "";
        }

        public static string ToDateString(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy", new CultureInfo("pt-BR", false).DateTimeFormat);
        }
    }
}
