using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MVC.Core.Extension
{
    /// <summary>
    /// Convert utilities
    /// </summary>
    public static class ConvertExtension
    {
        #region AsIntNull

        /// <summary>
        /// Convert string to int?
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static int? AsIntNull(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            return Convert.ToInt32(value);
        }

        #endregion AsIntNull

        #region AsInt

        /// <summary>
        /// Convert string to int
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns></returns>
        public static int AsInt(this string value, int defaultValue = 0)
        {
            if (value.IsNullOrEmpty()) return defaultValue;

            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Convert from int? to int with default value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int AsInt(this int? value, int defaultValue = 0)
        {
            if (!value.HasValue) return defaultValue;
            return value.Value;
        }

        #endregion AsInt

        #region AsDecimalNull

        /// <summary>
        /// Convert string to decimal?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? AsDecimalNull(this string value)
        {
            if (value.IsNullOrEmpty()) return null;
            return Convert.ToDecimal(value);
        }

        #endregion

        #region AsDecimal

        /// <summary>
        /// Convert string to decimal
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static decimal AsDecimal(this string value)
        {
            return Convert.ToDecimal(value);
        }

        #endregion AsDecimal

        #region AsDatetime

        /// <summary>
        /// Convert string to DateTime
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        public static DateTime AsDatetime(this string value, CultureInfo culture = null)
        {
            if (culture != null)
                return Convert.ToDateTime(value, culture);

            return Convert.ToDateTime(value);
            //return Convert.ToDateTime(value, AppCulture);
        }

        #endregion AsDatetime

        #region AsDatetimeNull

        /// <summary>
        ///  Convert string to DateTime?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? AsDatetimeNull(this string value)
        {
            if (value.IsNullOrEmpty()) return null;
            return Convert.ToDateTime(value);
        }

        #endregion

        #region AsString

        /// <summary>
        /// Convert from bool? to string as db type value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string AsString(this bool? value)
        {
            if (value == null) return "0";
            if (value == true) return "1";
            return "0";
        }

        /// <summary>
        ///  Convert from string null to empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string AsString(this string value)
        {
            if (value == null) return string.Empty;
            return value;
        }

        /// <summary>
        /// Ases the string format.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static string AsStringFormat(this DateTime date, string format = "dd/MM/yyyy HH:ss:mm")
        {
            return date.ToString(format);
        }

        /// <summary>
        /// Ases the string format.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static string AsStringFormat(this DateTime? date, string format = "dd/MM/yyyy HH:ss:mm")
        {
            if (date == null) return null;
            return date.Value.ToString(format);
        }

        #endregion

        #region AsBool

        public static bool AsBool(this bool? value)
        {
            if (!value.HasValue) return false;
            return value.Value;
        }

        #endregion

        #region ToXmlString

        /// <summary>
        /// To the XML string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToXmlString(this object obj)
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                ser.Serialize(stream, obj);
                return (Encoding.UTF8.GetString(stream.GetBuffer()));
            }
        }

        #endregion

        #region ToExpando

        /// <summary>
        /// Convert hash to expando object for Dapper condition
        /// </summary>
        /// <param name="hs">The hs</param>
        /// <returns></returns>
        public static object ToExpando(this Hashtable hs)
        {
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando;

            foreach (var key in hs.Keys)
            {
                expandoDic.Add(key.ToString(), hs[key]);
            }

            return expando;
        }

        #endregion ToExpando
    }
}