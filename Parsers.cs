using System;
using System.Globalization;

namespace StringParserExtensions
{
    public static class Parsers
    {
        public static bool EqualsInvariantCase(this string test, string other)
        {
            return String.Equals(test, other, StringComparison.OrdinalIgnoreCase);
        }

        public static bool? AsBool(this string strToParse)
        {
            bool val;

            if (!bool.TryParse(strToParse, out val))
                return null;

            return val;
        }

        public static int? AsInt(this string strToParse)
        {
            int val;

            if (!int.TryParse(strToParse, out val))
                return null;

            return val;
        }

        public static float? AsFloat(this string strToParse)
        {
            float val;

            strToParse = strToParse.TrimEnd('f', 'F');

            if (!float.TryParse(strToParse, out val))
                return null;

            return val;
        }

        public static double? AsDouble(this string strToParse)
        {
            double val;

            if (!double.TryParse(strToParse, out val))
                return null;

            return val;
        }

        public static DateTime? AsDatetime(this string strToParse)
        {
            DateTime val;

            if (!DateTime.TryParse(strToParse, out val))
                return val;

            return null;
        }

        public static DateTime? AsDatetime(this string strToParse, IFormatProvider formatProvider, DateTimeStyles styles)
        {
            DateTime val;

            if (!DateTime.TryParse(strToParse, formatProvider, styles, out val))
                return val;

            return null;
        }

        public static Guid? AsGuid(this string strToParse)
        {
            Guid val;

            if (!Guid.TryParse(strToParse, out val))
                return val;

            return null;
        }

        /// <summary>
        /// <para>Please be carefull that the type you supply is an enum, you'll get an exception if it isn't</para>
        /// <para>No way of doing enum constraints in C# :( http://stackoverflow.com/a/1331811/68268 </para>
        /// </summary>
        public static T? AsEnum<T>(this string strToParse)
            where T : struct // 
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("Only for enums!");

            T res;

            if (Enum.TryParse(strToParse, true, out res))
                return res;

            return null;
        }
    }
}
