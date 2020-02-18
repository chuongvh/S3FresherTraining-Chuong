using System;

namespace MVC.Core.Extension
{
    public static class DataTypeExtensions
    {
        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }

        public static bool IsEmpty(this Guid? guid)
        {
            return !guid.HasValue || guid.Value == Guid.Empty;
        }

        public static bool IsNullable<T>()
        {
            var typeOfValue = typeof(T);
            return (typeOfValue.IsGenericType && typeOfValue.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static object GetPropValue<TObjType>(this TObjType obj, string propertyName) where TObjType : class
        {
            if (obj == null) return null;

            var propObj = typeof(TObjType).GetProperty(propertyName);
            if (propObj != null)
            {
                var val = propObj.GetValue(obj);
                return val;
            }
            return null;
        }

        public static string GetPropValueAsStr<TObjType>(this TObjType obj, string propertyName) where TObjType : class
        {
            object val = obj?.GetPropValue(propertyName);
            return val?.ToString() ?? string.Empty;
        }

        public static TPropType GetPropValue<TPropType>(this object obj, string propertyName)
        {
            if (obj == null) return default(TPropType);

            var val = obj.GetPropValue(propertyName);
            if (val != null) return val.ToType<TPropType>();

            return default(TPropType);
        }

        public static T ToType<T>(this object obj)
        {
            if (obj == null) return default(T);
            try
            {
                var typeOfT = typeof(T);
                if (typeOfT.BaseType == typeof(Enum) || typeOfT.IsEnum)
                    return (T) Enum.Parse(typeOfT, obj.ToString(), true);

                return (T) Convert.ChangeType(obj, typeOfT);
            }
            catch
            {
                // ignored
            }
            return default(T);
        }

        public static TEnumType ToEnum<TEnumType>(this string value)
        {
            try
            {
                var typeOfEnum = typeof(TEnumType);
                return (TEnumType) Enum.Parse(typeOfEnum, value, true);
            }
            catch
            {
                // ignored
            }
            return default(TEnumType);
        }

        public static TEnumType ToEnum<TEnumType>(this int value)
        {
            return value.ToString().ToEnum<TEnumType>();
        }

        public static bool Is(this string value, Enum enumVal)
        {
            try
            {
                var typeOfEnum = enumVal.GetType();
                var enumVal1 = (Enum) Enum.Parse(typeOfEnum, value, true);
                return enumVal.Equals(enumVal1);
            }
            catch
            {
                // ignored
            }
            return false;
        }

        public static bool Is(this int value, Enum enumVal)
        {
            return value.ToString().Is(enumVal);
        }

        /// <summary>
        /// Get the int value of enum
        /// </summary>
        /// <param name="enum">The enum</param>
        /// <returns></returns>
        public static int Value(this Enum @enum)
        {
            return Convert.ToInt32(@enum);
        }

        /// <summary>
        /// Get the name of enum value
        /// </summary>
        /// <param name="enum">The enum</param>
        /// <returns></returns>
        public static string Name(this Enum @enum)
        {
            return Enum.GetName(@enum.GetType(), @enum);
        }
    }
}