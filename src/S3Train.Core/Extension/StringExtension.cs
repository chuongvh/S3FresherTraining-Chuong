using System;
using System.Globalization;

namespace MVC.Core.Extension
{
    /// <summary>
    /// Extension method for string
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Determines whether [is null or empty] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// If the value is NOT null or empty
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is not empty] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Check if the value is null or whitespace only
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>
        ///   <c>true</c> if [is null or white space] [the specified value]; otherwise, <c>false</c>
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Check if the value is NOT null and whitespace only
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>
        ///   <c>true</c> if [is not null or white space] [the specified value]; otherwise, <c>false</c>
        /// </returns>
        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Trim and lower case the value
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string TransformLower(this string value)
        {
            return value?.Trim().ToLower();
        }


        /// <summary>
        /// Trim and upper case the value
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string TransformUpper(this string value)
        {
            return value?.Trim().ToUpper();
        }

        /// <summary>
        /// Trim the value safely
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string TrimSafe(this string value)
        {
            return value?.Trim();
        }

        /// <summary>
        /// Trim the suffix string if any
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="suffix">The suffix</param>
        /// <returns></returns>
        public static string TrimEnd(this string value, string suffix)
        {
            if (value.IsNullOrEmpty() || suffix.IsNullOrEmpty() ||
                !value.EndsWith(suffix, StringComparison.OrdinalIgnoreCase)) return value;

            return value.Substring(0, value.Length - suffix.Length);
        }

        /// <summary>
        /// Truncates the string if it exceeds the max length
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="maxLength">The maximum length</param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        /// <summary>
        /// Escape the double quote (for using in javascript) by replacing " with ""
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static string EscapeJavascriptDoubleQuote(this string value)
        {
            return value.Replace("\"", "\\\"");
        }

        /// <summary>
        /// Shortcut to string.Format
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="args">The arguments</param>
        /// <returns></returns>
        public static string FormatString(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        /// <summary>
        /// Splits the and remove empty.
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="separator">separator</param>
        /// <returns></returns>
        public static string[] SplitAndRemoveEmpty(this string value, char separator)
        {
            return value.SplitAndRemoveEmpty(new char[] { separator });
        }

        /// <summary>
        /// Splits the and remove empty.
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="separators">separators</param>
        /// <returns></returns>
        public static string[] SplitAndRemoveEmpty(this string value, char[] separators)
        {
            return value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Replace string with comparison option such as ignore case, etc
        /// </summary>
        /// <param name="source">source string</param>
        /// <param name="oldString">string to be replaced</param>
        /// <param name="newString">new string</param>
        /// <param name="comparison">comparison option</param>
        /// <returns></returns>
        public static string Replace(this string source, string oldString,
            string newString, StringComparison comparison)
        {
            var index = source.IndexOf(oldString, comparison);

            while (index > -1)
            {
                source = source.Remove(index, oldString.Length);
                source = source.Insert(index, newString);
                index = source.IndexOf(oldString, index + newString.Length, comparison);
            }

            return source;
        }

        /// <summary>
        /// Compare if two strings are equal (ignore case)
        /// </summary>
        /// <param name="firstString">first string</param>
        /// <param name="secondString">second string</param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string firstString, string secondString)
        {
            return firstString.Equals(secondString, StringComparison.InvariantCultureIgnoreCase);
        }

        public static CultureInfo AppCulture = new CultureInfo("en-Us");

        public static string ToStringCulture(this decimal value) => value.ToString(AppCulture);
        public static string ToStringCulture(this double value) => value.ToString(AppCulture);
        public static string ToStringCulture(this float value) => value.ToString(AppCulture);
    }
}