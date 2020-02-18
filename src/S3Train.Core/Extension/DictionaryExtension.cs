using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace MVC.Core.Extension
{
    /// <summary>
    /// Extension for collection
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="this">The this</param>
        /// <param name="that">The that</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite]</param>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> @this, IDictionary<TKey, TValue> that,
            bool overwrite = true)
        {
            if (that == null || that.Count == 0) return;

            foreach (TKey key in that.Keys)
            {
                if (@this.ContainsKey(key))
                {
                    if (overwrite)
                        @this[key] = that[key];
                }
                else
                {
                    @this.Add(key, that[key]);
                }
            }
        }


        /// <summary>
        ///     An IDictionary&lt;TKey,TValue&gt; extension method that adds if not contains key.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool AddIfNotContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key,
            TValue value)
        {
            if (@this.ContainsKey(key)) return false;

            @this.Add(key, value);

            return true;
        }

        /// <summary>
        ///     An IDictionary&lt;TKey,TValue&gt; extension method that adds if not contains key.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="key">The key.</param>
        /// <param name="valueFactory">The value factory.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool AddIfNotContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key,
            Func<TValue> valueFactory)
        {
            if (@this.ContainsKey(key)) return false;

            @this.Add(key, valueFactory());

            return true;
        }

        /// <summary>
        ///     An IDictionary&lt;TKey,TValue&gt; extension method that adds if not contains key.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="key">The key.</param>
        /// <param name="valueFactory">The value factory.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool AddIfNotContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key,
            Func<TKey, TValue> valueFactory)
        {
            if (@this.ContainsKey(key)) return false;

            @this.Add(key, valueFactory(key));

            return true;
        }

        /// <summary>
        ///     Uses the specified functions to add a key/value pair to the IDictionary&lt;TKey, TValue&gt; if the key does
        ///     not already exist, or to update a key/value pair in the IDictionary&lt;TKey, TValue&gt;> if the key already
        ///     exists.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="key">The key to be added or whose value should be updated.</param>
        /// <param name="value">The value to be added or updated.</param>
        /// <returns>The new value for the key.</returns>
        public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue value)
        {
            if (@this.ContainsKey(key))
                @this[key] = value;
            else
                @this.Add(new KeyValuePair<TKey, TValue>(key, value));

            return @this[key];
        }

        /// <summary>
        ///     Uses the specified functions to add a key/value pair to the IDictionary&lt;TKey, TValue&gt; if the key does
        ///     not already exist, or to update a key/value pair in the IDictionary&lt;TKey, TValue&gt;> if the key already
        ///     exists.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="key">The key to be added or whose value should be updated.</param>
        /// <param name="addValue">The value to be added for an absent key.</param>
        /// <param name="updateValueFactory">
        ///     The function used to generate a new value for an existing key based on the key's
        ///     existing value.
        /// </param>
        /// <returns>
        ///     The new value for the key. This will be either be addValue (if the key was absent) or the result of
        ///     updateValueFactory (if the key was present).
        /// </returns>
        public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue addValue,
            Func<TKey, TValue, TValue> updateValueFactory)
        {
            if (@this.ContainsKey(key))
                @this[key] = updateValueFactory(key, @this[key]);
            else
                @this.Add(new KeyValuePair<TKey, TValue>(key, addValue));

            return @this[key];
        }

        /// <summary>
        ///     Uses the specified functions to add a key/value pair to the IDictionary&lt;TKey, TValue&gt; if the key does
        ///     not already exist, or to update a key/value pair in the IDictionary&lt;TKey, TValue&gt;> if the key already
        ///     exists.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="key">The key to be added or whose value should be updated.</param>
        /// <param name="addValueFactory">The function used to generate a value for an absent key.</param>
        /// <param name="updateValueFactory">
        ///     The function used to generate a new value for an existing key based on the key's
        ///     existing value.
        /// </param>
        /// <returns>
        ///     The new value for the key. This will be either be the result of addValueFactory (if the key was absent) or
        ///     the result of updateValueFactory (if the key was present).
        /// </returns>
        public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key,
            Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
        {
            if (@this.ContainsKey(key))
                @this[key] = updateValueFactory(key, @this[key]);
            else
                @this.Add(new KeyValuePair<TKey, TValue>(key, addValueFactory(key)));

            return @this[key];
        }

        /// <summary>
        ///     An IDictionary&lt;TKey,TValue&gt; extension method that query if '@this' contains all key.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="keys">A variable-length parameters list containing keys.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool ContainsAllKey<TKey, TValue>(this IDictionary<TKey, TValue> @this, params TKey[] keys)
        {
            return keys.All(@this.ContainsKey);
        }

        /// <summary>
        ///     An IDictionary&lt;TKey,TValue&gt; extension method that query if '@this' contains any key.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="keys">A variable-length parameters list containing keys.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool ContainsAnyKey<TKey, TValue>(this IDictionary<TKey, TValue> @this, params TKey[] keys)
        {
            return keys.Any(@this.ContainsKey);
        }

        /// <summary>
        ///     Adds a key/value pair to the IDictionary&lt;TKey, TValue&gt; if the key does not already exist.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value to be added, if the key does not already exist.</param>
        /// <returns>
        ///     The value for the key. This will be either the existing value for the key if the key is already in the
        ///     dictionary, or the new value if the key was not in the dictionary.
        /// </returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue value)
        {
            if (@this.ContainsKey(key)) return @this[key];

            @this.Add(new KeyValuePair<TKey, TValue>(key, value));

            return @this[key];
        }

        /// <summary>
        ///     Adds a key/value pair to the IDictionary&lt;TKey, TValue&gt; by using the specified function, if the key does
        ///     not already exist.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">TThe function used to generate a value for the key.</param>
        /// <returns>
        ///     The value for the key. This will be either the existing value for the key if the key is already in the
        ///     dictionary, or the new value for the key as returned by valueFactory if the key was not in the dictionary.
        /// </returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key,
            Func<TKey, TValue> valueFactory)
        {
            if (@this.ContainsKey(key)) return @this[key];

            @this.Add(new KeyValuePair<TKey, TValue>(key, valueFactory(key)));

            return @this[key];
        }

        /// <summary>
        ///     An IDictionary&lt;TKey,TValue&gt; extension method that removes if contains key.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="key">The key.</param>
        public static void RemoveIfContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key)
        {
            if (!@this.ContainsKey(key)) return;

            @this.Remove(key);
        }

        /// <summary>
        ///     An IDictionary&lt;TKey,TValue&gt; extension method that converts the @this to a sorted dictionary.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a SortedDictionary&lt;TKey,TValue&gt;</returns>
        public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
            this IDictionary<TKey, TValue> @this)
        {
            return new SortedDictionary<TKey, TValue>(@this);
        }

        /// <summary>
        ///     An IDictionary&lt;TKey,TValue&gt; extension method that converts the @this to a sorted dictionary.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>@this as a SortedDictionary&lt;TKey,TValue&gt;</returns>
        public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
            this IDictionary<TKey, TValue> @this, IComparer<TKey> comparer)
        {
            return new SortedDictionary<TKey, TValue>(@this, comparer);
        }

        /// <summary>
        /// To the dictionary.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(this NameValueCollection @this)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            if (@this == null) return dict;

            foreach (string key in @this.AllKeys)
            {
                dict.Add(key, @this[key]);
            }

            return dict;
        }

        /// <summary>
        /// To the dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="list">The list</param>
        /// <param name="keySelector">The key selector</param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<TValue> list,
            Func<TValue, TKey> keySelector)
        {
            var dictionary = new Dictionary<TKey, TValue>();

            if (list != null)
            {
                foreach (TValue item in list)
                {
                    dictionary.Add(keySelector(item), item);
                }
            }


            return dictionary;
        }

        /// <summary>
        /// Convert an object of a class to dictionary, all keys are object's properties
        /// </summary>
        /// <param name="obj">the object which need to be converted</param>
        /// <returns></returns>
        public static IDictionary<string, VT> ToDictionary<T, VT>(this T obj) where T : class
        {
            var dict = new Dictionary<string, VT>();
            obj.GetType().GetProperties().All(p =>
            {
                if (p == null)
                {
                    return false;
                }
                var val = p.GetValue(obj, null);
                if (val is VT)
                {
                    dict[p.Name] = (VT) val;
                }
                else
                {
                    return false;
                }
                return true;
            });
            return dict;
        }

        /// <summary>
        /// Clones the specified dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalDictionary">original dictionary</param>
        /// <returns></returns>
        public static IDictionary<string, T> Clone<T>(this IDictionary<string, T> originalDictionary)
        {
            var clonedDict = new Dictionary<string, T>();
            clonedDict.AddRange(originalDictionary);
            return clonedDict;
        }

        /// <summary>
        /// Replaces the key for a dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalDictionary">original dictionary</param>
        /// <param name="oldKey">old key</param>
        /// <param name="newKey">new key</param>
        /// <returns></returns>
        public static IDictionary<string, T> ReplaceKey<T>(this IDictionary<string, T> originalDictionary,
            string oldKey, string newKey)
        {
            var newDict = originalDictionary.Clone();
            if (newDict.ContainsKey(oldKey))
            {
                var oldValue = newDict[oldKey];
                newDict.Remove(oldKey);
                newDict[newKey] = oldValue;
            }
            return newDict;
        }

        /// <summary>
        /// Boxes the dictionary
        /// </summary>
        /// <param name="originalDictionary">original dictionary</param>
        /// <returns></returns>
        public static IDictionary<string, object> Box(this IDictionary<string, string> originalDictionary)
        {
            var newDictionary = new Dictionary<string, object>();
            foreach (var p in originalDictionary)
            {
                newDictionary.Add(p.Key, p.Value);
            }
            return newDictionary;
        }

        /// <summary>
        /// Gets the value (include case when key not exist)
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>Value or default</returns>
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue fallback = default(TValue))
        {
            TValue result;
            return dictionary.TryGetValue(key, out result) ? result : fallback;
        }
    }
}