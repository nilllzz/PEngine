using System;

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
    }
}
