using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace S3Train.Core.Extension
{
    public static class AttributeExtension
    {
        public static string GetDisplayName<T>(this T value)
        {
            return GetAttributeValue<DisplayAttribute, string>(value, arg => arg.GetName());
        }

        public static string GetDecription<T>(this T value)
        {
            return GetAttributeValue<DescriptionAttribute, string>(value, arg => arg.Description);
        }

        public static TV GetAttributeValue<T, TV>(this object enumeration, Func<T, TV> expression)
            where T : Attribute
        {
            var memberInfo = enumeration.GetType().GetMember(enumeration.ToString());

            if (!memberInfo.Any())
                return default(TV);

            var attribute = Attribute.GetCustomAttribute(memberInfo[0], typeof(T));
            if (attribute == null)
                return default(TV);

            return expression((T)attribute);
        }
    }
}
