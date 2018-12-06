using System;
using System.Collections.Generic;
using System.Linq;

namespace PEngine.Common.Data
{
    public static class DataHelper
    {
        public static T ParseEnum<T>(string member)
        {
            // upper case first char
            member = member[0].ToString().ToUpper() + member.Substring(1);
            return (T)Enum.Parse(typeof(T), member);
        }

        public static string UnparseEnum(object enumMember)
        {
            var str = enumMember.ToString();
            return str[0].ToString().ToLower() + str.Substring(1);
        }

        public static int GetFirstFreeInRange(IEnumerable<int> range, int first = 0)
        {
            var max = range.Max();
            for (var i = first; i < max; i++)
            {
                if (!range.Contains(i))
                {
                    return i;
                }
            }
            // end of range is first free
            return max + 1;
        }
    }
}
