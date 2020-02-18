using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Core.Extension
{
    /// <summary>
    /// Extension for collection
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>
        ///   <c>true</c> if the specified this is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty<T>(this IEnumerable<T> @this)
        {
            return !@this.Any();
        }

        /// <summary>
        /// Determines whether [is not empty].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>
        ///   <c>true</c> if [is not empty] [the specified this]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> @this)
        {
            return @this.Any();
        }

        /// <summary>
        /// Determines whether [is not null or empty].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>
        ///   <c>true</c> if [is not null or empty] [the specified this]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this != null && @this.Any();
        }

        /// <summary>
        /// Determines whether [is null or empty].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>
        ///   <c>true</c> if [is null or empty] [the specified this]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this == null || !@this.Any();
        }

        /// <summary>
        /// Join string with separator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string StringJoin<T>(this IEnumerable<T> @this, string separator = ", ")
        {
            return string.Join(separator, @this);
        }

        /// <summary>
        /// Fors the each.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            T[] array = @this.ToArray();
            foreach (T t in array)
            {
                action(t);
            }
            return array;
        }

        /// <summary>
        /// Fors the each.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> @this, Action<T, int> action)
        {
            T[] array = @this.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                action(array[i], i);
            }

            return array;
        }

        /// <summary>
        /// Determines whether the specified values contains any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="values">The values.</param>
        /// <returns>
        ///   <c>true</c> if the specified values contains any; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsAny<T>(this IEnumerable<T> @this, params T[] values)
        {
            T[] list = @this.ToArray();
            foreach (T value in values)
            {
                if (list.Contains(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified values contains all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="values">The values.</param>
        /// <returns>
        ///   <c>true</c> if the specified values contains all; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsAll<T>(this IEnumerable<T> @this, params T[] values)
        {
            T[] list = @this.ToArray();
            foreach (T value in values)
            {
                if (!list.Contains(value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// To the hashtable.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        public static Hashtable ToHashtable(this IDictionary @this)
        {
            return new Hashtable(@this);
        }

        /// <summary>
        /// Convert to IList, return empty list if null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IList<T> ToNotNullList<T>(this IEnumerable<T> @this)
        {
            return @this?.ToList() ?? new List<T>();
        }
    }
}