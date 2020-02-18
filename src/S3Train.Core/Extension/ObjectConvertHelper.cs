using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MVC.Core.Extension
{
    public static class ObjectConvertHelper
    {
        /// <summary>
        /// Converts the object.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceObj">source object</param>
        /// <returns></returns>
        public static T ConvertObject<S, T>(this S sourceObj)
            where S : class
            where T : class, new()
        {
            if (sourceObj == null)
            {
                return null;
            }
            else
            {
                var convertedObj = new T();
                CopyPropertyValues(sourceObj, convertedObj);
                return convertedObj;
            }
        }

        /// <summary>
        /// Clones the specified source object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceObj">source object</param>
        /// <returns></returns>
        public static T Clone<T>(T sourceObj) where T : class
        {
            var convertedObj = Activator.CreateInstance(sourceObj.GetType());
            CopyPropertyValues(sourceObj, convertedObj);
            return convertedObj as T;
        }

        /// <summary>
        /// Converts the list.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList">source list</param>
        /// <returns></returns>
        public static IEnumerable<T> ConvertList<S, T>(IEnumerable<S> sourceList)
            where S : class
            where T : class, new()
        {
            if (sourceList == null)
            {
                return null;
            }
            else if (!sourceList.Any())
            {
                return new List<T>();
            }
            else
            {
                var targetList = new List<T>(sourceList.Count());
                foreach (var sourceObj in sourceList)
                {
                    targetList.Add(ConvertObject<S, T>(sourceObj));
                }
                return targetList;
            }
        }

        /// <summary>
        /// Copies the property values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fromObj">from object</param>
        /// <param name="toObj">to object</param>
        /// <param name="propertyFilters">property filters</param>
        /// <param name="isExclusive">indicate if [is exclusive]</param>
        public static void CopyPropertyValues<T>(T fromObj, T toObj, string[] propertyFilters = null,
            bool isExclusive = true) where T : class
        {
            if (fromObj != null && toObj != null)
            {
                var allProps = fromObj.GetType().GetProperties();
                bool copyValue;
                foreach (PropertyInfo propInfo in allProps)
                {
                    copyValue = (propertyFilters == null || propertyFilters.Length == 0)
                                || (isExclusive == true && !propertyFilters.Contains(propInfo.Name))
                                || (isExclusive == false && propertyFilters.Contains(propInfo.Name));
                    if (copyValue && (propInfo.GetSetMethod() != null))
                    {
                        propInfo.SetValue(toObj, propInfo.GetValue(fromObj, null), null);
                    }
                }
            }
        }

        /// <summary>
        /// Copies the property values.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceObj">source object</param>
        /// <param name="toObj">to object</param>
        /// <param name="propertyFilters">property filters</param>
        /// <param name="isExclusive">indicate if [is exclusive]</param>
        public static void CopyPropertyValues<S, T>(S sourceObj, T toObj, string[] propertyFilters = null,
            bool isExclusive = true)
            where S : class
            where T : class
        {
            if (sourceObj != null && toObj != null)
            {
                var sourceProps = sourceObj.GetType().GetProperties();
                var toProps = toObj.GetType().GetProperties();
                if (toProps != null && sourceProps != null)
                {
                    var copyValue = false;
                    foreach (PropertyInfo toPropInfo in toProps)
                    {
                        foreach (PropertyInfo srcPropInfo in sourceProps)
                        {
                            copyValue = toPropInfo.Name.Equals(srcPropInfo.Name)
                                        && toPropInfo.PropertyType.FullName.Equals(srcPropInfo.PropertyType.FullName)
                                        && ((propertyFilters == null || propertyFilters.Length == 0)
                                            || (isExclusive && !propertyFilters.Contains(srcPropInfo.Name))
                                            || (!isExclusive && propertyFilters.Contains(srcPropInfo.Name)));
                            if (copyValue && (toPropInfo.GetSetMethod() != null))
                            {
                                toPropInfo.SetValue(toObj, srcPropInfo.GetValue(sourceObj, null), null);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Copies the property values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="D"></typeparam>
        /// <param name="fromDict">from dictionary</param>
        /// <param name="toObj">to object</param>
        public static void CopyPropertyValues<T, D>(IDictionary<string, D> fromDict, T toObj) where T : class
        {
            if (fromDict != null && toObj != null)
            {
                var allProps = toObj.GetType().GetProperties();
                string matchKey = null;
                foreach (PropertyInfo propInfo in allProps)
                {
                    matchKey = fromDict.Keys.FirstOrDefault(k =>
                        k.Equals(propInfo.Name, StringComparison.InvariantCultureIgnoreCase));
                    if (matchKey != null && (propInfo.GetSetMethod() != null))
                    {
                        propInfo.SetValue(toObj, fromDict[matchKey], null);
                    }
                }
            }
        }
    }
}