using System.Collections.Generic;
using System.Linq;

namespace Operation.WPF.Converters
{
    public static class StringExtention
    {
        public static List<int> ToIntList(this string source)
        {
            var result = new List<int>();
            var numbers = source?.Trim().Split(' ');
            if (!(numbers?.Length > 1)) return result;
            result.AddRange(numbers.Select(int.Parse));
            return result;
        }
    }
}