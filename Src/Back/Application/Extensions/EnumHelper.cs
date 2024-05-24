using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class EnumHelper
    {
        public static string GetEnumMemberValue<T>(T enumValue) where T : Enum
        {
            var attribute = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault()?.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();

            if (attribute != null)
                return attribute.Value;

            return string.Empty;
        }
    }
}
