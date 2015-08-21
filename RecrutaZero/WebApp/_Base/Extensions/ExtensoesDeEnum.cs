using System;
using System.ComponentModel;

namespace RecrutaZero.WebApp._Base.Extensions
{
    public static class ExtensoesDeEnum
    {
        public static string ToDescription(this Enum @enum)
        {
            var type = @enum.GetType();
            var memInfo = type.GetMember(@enum.ToString());

            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return @enum.ToString();
        }
    }
}