using Client.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Extensions
{
    public static class StringExtension 
    {
        public static string ReplaceValues(this string value)
        {
            return value;
        }

        public static string ToTitleOnTable(this string value, int length)
        {
            string temp = "";
            if (value.Length > length)
            {
                temp = value.Substring(0, length) + "...";
            }
            else
            {
                temp = value;
            }
            return temp;
        }
        public static string ToUrlSegment(this string value, int maxLength)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            string segment = value.NormalizeVNString();



            if (segment.Length > maxLength)
            {
                segment = segment.Substring(0, maxLength);
            }

            return segment;
        }
    }
}
