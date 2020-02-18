using System;
using System.Globalization;

namespace MVC.Core.Extension.Helper
{
    public static class DateTimeHelper
    {
        public const string DATE_TIME_WITH_TIME_ZONE_FORMAT = "yyyy-MM-ddTHH:mm:sszzz";

        public static DateTime CurrentDateTime => DateTime.Now;

        public static DateTime CurrentDate => DateTime.Today;

        public static DateTime CurrentTime => DateTime.Now.ToLocalTime();

        /// <summary>
        /// Parses date with exact format and ignore culture
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="parseFormat">parse format</param>
        /// <returns></returns>
        public static DateTime ParseExact(string date, string parseFormat)
        {
            return DateTime.ParseExact(date, parseFormat, CultureInfo.InvariantCulture);
        }
    }
}