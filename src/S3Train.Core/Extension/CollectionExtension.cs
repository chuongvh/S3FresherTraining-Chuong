using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Core.Extension
{
    /// <summary>
    /// Extension for collection
    /// </summary>
    public static class CollectionExtension
    {
        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>
        ///   <c>true</c> if the specified this is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty<T>(this ICollection<T> @this)
        {
            return @this.Count == 0;
        }

        /// <summary>
        /// Determines whether [is not empty].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>
        ///   <c>true</c> if [is not empty] [the specified this]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotEmpty<T>(this ICollection<T> @this)
        {
            return @this.Count != 0;
        }

        /// <summary>
        /// Determines whether [is null or empty].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>
        ///   <c>true</c> if [is null or empty] [the specified this]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> @this)
        {
            return @this == null || @this.Count == 0;
        }

        /// <summary>
        /// Determines whether [is not null or empty].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>
        ///   <c>true</c> if [is not null or empty] [the specified this]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNullOrEmpty<T>(this ICollection<T> @this)
        {
            return @this != null && @this.Count != 0;
        }

        /// <summary>
        /// Adds if.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool AddIf<T>(this ICollection<T> @this, Func<T, bool> predicate, T value)
        {
            if (!predicate(value)) return false;
            @this.Add(value);
            return true;
        }

        /// <summary>
        /// Adds if not contains.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool AddIfNotContains<T>(this ICollection<T> @this, T value)
        {
            if (@this.Contains(value)) return false;
            @this.Add(value);
            return true;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="values">The values.</param>
        public static void AddRange<T>(this ICollection<T> @this, params T[] values)
        {
            foreach (T value in values)
            {
                @this.Add(value);
            }
        }

        /// <summary>
        /// Adds the range if.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="values">The values.</param>
        public static void AddRangeIf<T>(this ICollection<T> @this, Func<T, bool> predicate, params T[] values)
        {
            foreach (T value in values)
            {
                if (predicate(value))
                {
                    @this.Add(value);
                }
            }
        }

        /// <summary>
        /// Adds the range if not contains.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="values">The values.</param>
        public static void AddRangeIfNotContains<T>(this ICollection<T> @this, params T[] values)
        {
            foreach (T value in values)
            {
                if (!@this.Contains(value))
                {
                    @this.Add(value);
                }
            }
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
        public static bool ContainsAll<T>(this ICollection<T> @this, params T[] values)
        {
            foreach (T value in values)
            {
                if (!@this.Contains(value))
                {
                    return false;
                }
            }

            return true;
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
        public static bool ContainsAny<T>(this ICollection<T> @this, params T[] values)
        {
            foreach (T value in values)
            {
                if (@this.Contains(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes if.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="value">The value.</param>
        /// <param name="predicate">The predicate.</param>
        public static void RemoveIf<T>(this ICollection<T> @this, T value, Func<T, bool> predicate)
        {
            if (predicate(value))
            {
                @this.Remove(value);
            }
        }

        /// <summary>
        /// Removes if contains.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="value">The value.</param>
        public static void RemoveIfContains<T>(this ICollection<T> @this, T value)
        {
            if (@this.Contains(value))
            {
                @this.Remove(value);
            }
        }

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="values">The values.</param>
        public static void RemoveRange<T>(this ICollection<T> @this, params T[] values)
        {
            foreach (T value in values)
            {
                @this.Remove(value);
            }
        }

        /// <summary>
        /// Removes the range if.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="values">The values.</param>
        public static void RemoveRangeIf<T>(this ICollection<T> @this, Func<T, bool> predicate, params T[] values)
        {
            foreach (T value in values)
            {
                if (predicate(value))
                {
                    @this.Remove(value);
                }
            }
        }

        /// <summary>
        /// Removes the range if contains.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="values">The values.</param>
        public static void RemoveRangeIfContains<T>(this ICollection<T> @this, params T[] values)
        {
            foreach (T value in values)
            {
                if (@this.Contains(value))
                {
                    @this.Remove(value);
                }
            }
        }

        /// <summary>
        /// Removes the where.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="predicate">The predicate.</param>
        public static void RemoveWhere<T>(this ICollection<T> @this, Func<T, bool> predicate)
        {
            List<T> list = @this.Where(predicate).ToList();
            foreach (T item in list)
            {
                @this.Remove(item);
            }
        }

        /// <summary>
        /// Append a new item to the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list</param>
        /// <param name="item">The item</param>
        /// <returns></returns>
        public static List<T> AppendItem<T>(this List<T> list, T item)
        {
            list.Add(item);

            return list;
        }

        /// <summary>
        /// Removes the item from the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list</param>
        /// <param name="item">The item</param>
        /// <returns></returns>
        public static List<T> RemoveItem<T>(this List<T> list, T item)
        {
            list.Remove(item);

            return list;
        }
    }
}