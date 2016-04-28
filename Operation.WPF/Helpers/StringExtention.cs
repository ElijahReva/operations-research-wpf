using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Operation.WPF.Helpers
{
    public static class StringExtention
    {
        public static List<int> ToIntList(this string input)
        {
            var result = new List<int>();
            var trimAll = input.TrimAll();
            var numbers = trimAll.Split(' ');
            if (!(numbers.Length > 1)) return result;
            result.AddRange(numbers.Select(int.Parse));
            return result;
        }

        public static string TrimAll(this string input)
        {
            return Regex.Replace(input, @"\s\s+", " ").Trim();
        }
    }
}