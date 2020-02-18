using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MVC.Core.Extension
{
    public static class CommonHelper
    {
        public static int Int(HttpStatusCode code)
        {
            return (int)code;
        }

        public static string Str(HttpStatusCode code)
        {
            return Int(code).ToString();
        }

        public static string Str(int code)
        {
            return code.ToString();
        }

        public static string NullToEmpty(string input)
        {
            return If(!string.IsNullOrWhiteSpace(input), input, string.Empty);
        }

        public static T If<T>(bool condition, T valueIfTrue, T valueIfFalse = default(T))
        {
            return condition ? valueIfTrue : valueIfFalse;
        }

        public static string StrIf<T>(bool condition, T valueIfTrue, T valueIfFalse = default(T))
        {
            var ret = If(condition, valueIfTrue, valueIfFalse);
            var retStr = ret != null ? ret.ToString() : string.Empty;
            return retStr;
        }

        public static bool IsNullEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullEmpty<T>(IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        public static int TryParseInt(string value)
        {
            int.TryParse(value, out var i);
            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startChar"></param>
        /// <param name="endChar"></param>
        /// <returns></returns>
        public static string GetPlaceHolderValue(string value, char startChar, char endChar)
        {
            var placeHolderValue = "";
            if (!string.IsNullOrEmpty(value) && value.IndexOf(startChar) != -1)
            {
                var start = value.IndexOf(startChar);
                var end = value.IndexOf(endChar);
                placeHolderValue = value.Substring(start + 1, (end - start - 1));
            }
            return placeHolderValue;
        }

        public static bool MatchAuthorization(string inputCode, string rule)
        {
            var result = false;
            rule = rule + "|*";
            var matchItems = rule.Split('|');
            var isEmptyCode = string.IsNullOrEmpty(inputCode);

            foreach (string item in matchItems)
            {
                if (item.Length > 1 && item.IndexOf('-') == 0)
                {
                    var symbol = item.Substring(1);
                    if (symbol == "*")
                    {
                        if (!isEmptyCode)
                        {
                            break;
                        }
                    }
                    if (symbol == "?")
                    {
                        if (isEmptyCode)
                        {
                            break;
                        }
                    }
                    if (!isEmptyCode && symbol == inputCode)
                    {
                        break;
                    }
                }
                else if (item.IndexOf('-') != 0)
                {
                    var symbol = item;
                    if (symbol == "*")
                    {
                        if (!isEmptyCode)
                        {
                            result = true;
                            break;
                        }
                    }
                    if (symbol == "?")
                    {
                        if (isEmptyCode)
                        {
                            result = true;
                            break;
                        }
                    }
                    if (!isEmptyCode && symbol == inputCode)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Check invalid char
        /// </summary>
        /// <param name="invalidChars">The invalid chars</param>
        /// <param name="value">value to check</param>
        /// <returns>
        /// True is has invalid char in value
        /// </returns>
        public static bool InvalidChars(string[] invalidChars, string value)
        {
            if (invalidChars.Length == 0 || string.IsNullOrEmpty(value)) return false;

            foreach (string c in invalidChars)
            {
                if (value.Contains(c))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check exist special chars
        /// </summary>
        /// <param name="detail">value to check</param>
        /// <param name="pattern">pattenr special</param>
        /// <returns>True is has special</returns>
        public static bool ExistSpecialChar(string detail, string pattern = "[<>'()]")
        {
            return IsMatchRegularExpression(detail, pattern);
        }

        /// <summary>
        /// Checks the special character exist in string.
        /// </summary>
        /// <param name="hsInput">The hs input.</param>
        /// <param name="key">The key.</param>
        /// <param name="invalidChars">The invalid chars.</param>
        /// <returns>
        /// True is not contain invalid chars
        /// </returns>
        public static bool CheckSpecialChar(Hashtable hsInput, string key, string[] invalidChars = null)
        {
            if (invalidChars == null) invalidChars = new[] { "<", ">" };
            foreach (DictionaryEntry entry in hsInput)
            {
                if (entry.Value == null) continue;

                if (entry.Key.Equals(key))
                {
                    foreach (var c in invalidChars)
                    {
                        if (entry.Value.ToString().Contains(c))
                            return false;
                    }
                }
                else
                {
                    if (ExistSpecialChar(entry.Value.ToString()))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the special character exist in string. Hint error: E00002
        /// </summary>
        /// <param name="objClass">The object class.</param>
        /// <param name="key">The key.</param>
        /// <param name="invalidChars">The invalid chars.</param>
        /// <returns>True is valid, false is not valid because have special char</returns>
        public static bool CheckSpecialChar(object objClass, string key, string[] invalidChars = null)
        {
            if (!objClass.GetType().GetTypeInfo().IsClass) return false;
            var hsInput = ObjectToHashtable(objClass);

            if (invalidChars == null) invalidChars = new[] { "<", ">" };
            foreach (DictionaryEntry entry in hsInput)
            {
                if (entry.Value == null) continue;

                if (entry.Key.Equals(key))
                {
                    foreach (var c in invalidChars)
                    {
                        if (entry.Value.ToString().Contains(c))
                            return false;
                    }
                }
                else
                {
                    if (ExistSpecialChar(entry.Value.ToString()))
                        return false;
                }
            }

            // return if not have special char
            return true;
        }

        /// <summary>
        /// Check email in pattern
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool ValidateEmailFormat(string email,
            string pattern =
                @"^(\s+)?\w+([-+.']\w+)*@[a-z0-9A-Z]+([-.][a-z0-9A-Z]+)*\.[a-z0-9A-Z]+([-.][a-z0-9A-Z]+)*(\s+)?$")
        {
            return IsMatchRegularExpression(email, pattern);
        }

        /// <summary>
        /// Determines whether [is match regular expression] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>
        ///   <c>true</c> if [is match regular expression] [the specified input]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMatchRegularExpression(string input, string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Fills the field and mandatory check.
        /// </summary>
        /// <param name="hs">The hs.</param>
        /// <param name="mandatoryDic">The mandatory dic.</param>
        /// <param name="notValidKey">The not valid key.</param>
        /// <returns></returns>
        public static bool FillFieldAndMandatoryCheck(Hashtable hs, Dictionary<string, int> mandatoryDic,
            out string notValidKey)
        {
            notValidKey = "";
            foreach (KeyValuePair<string, int> item in mandatoryDic)
            {
                if (!hs.Contains(item.Key) || hs[item.Key] == null)
                {
                    hs[item.Key] = DBNull.Value;
                }
                if (item.Value == 1)
                {
                    if (!hs.Contains(item.Key) || hs[item.Key] == null || string.IsNullOrEmpty(hs[item.Key].ToString()))
                    {
                        notValidKey = item.Key;
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Fills the field and mandatory check.
        /// </summary>
        /// <param name="objClass">The object class.</param>
        /// <param name="mandatoryDic">The mandatory dic.</param>
        /// <param name="notValidKey">The not valid key</param>
        /// <returns></returns>
        public static bool FillFieldAndMandatoryCheck(object objClass, Dictionary<string, int> mandatoryDic,
            out string notValidKey)
        {
            notValidKey = "";
            if (!objClass.GetType().GetTypeInfo().IsClass) return false;
            var hs = ObjectToHashtable(objClass);
            if (hs.Count == 0) return false;

            return FillFieldAndMandatoryCheck(hs, mandatoryDic, out notValidKey);
        }

        /// <summary>
        /// Objects to hashtable.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static Hashtable ObjectToHashtable(object obj)
        {
            var resultHash = new Hashtable();

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                var propName = prop.Name;
                var val = obj.GetType().GetProperty(propName)?.GetValue(obj, null);

                resultHash.Add(propName, val?.ToString());
            }

            return resultHash;
        }


        /// <summary>
        /// Hastables the trim.
        /// </summary>
        /// <param name="hs">The hashtable</param>
        /// <returns></returns>
        public static Hashtable HastableTrim(Hashtable hs)
        {
            var tempHs = (Hashtable)hs.Clone();
            foreach (DictionaryEntry de in hs)
            {
                if (de.Value is string)
                    tempHs[de.Key] = de.Value.ToString().Trim();

                if (de.Value is Hashtable hashtable)
                    tempHs[de.Key] = HastableTrim(hashtable);
            }
            return tempHs;
        }


        /// <summary>
        /// Objects the class trim all properties is string.
        /// This function like HastableTrim
        /// </summary>
        /// <param name="obj">The object class</param>
        public static void ObjectClassTrimString(Object obj)
        {
            if (!obj.GetType().GetTypeInfo().IsClass) return;

            // Trim for property is string
            var props = obj.GetType()
                // is public props 
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                // Ignore non-string properties
                .Where(prop => prop.PropertyType == typeof(string))
                // Ignore indexers
                .Where(prop => prop.GetIndexParameters().Length == 0)
                // Must be both readable and writable
                .Where(prop => prop.CanWrite && prop.CanRead);


            foreach (PropertyInfo prop in props)
            {
                var value = (string)prop.GetValue(obj, null);
                if (value != null)
                {
                    value = value.Trim();
                    prop.SetValue(obj, value, null);
                }
            }
        }

    }
}