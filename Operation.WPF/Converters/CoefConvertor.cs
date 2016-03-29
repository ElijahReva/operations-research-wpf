using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Operation.WPF.Converters
{
    public class CoefConvertor : ConvertorBase<CoefConvertor>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ints = ((List<int>)value);
            return ints != null ? ints.Aggregate(string.Empty, (current, i) => current + (i.ToString() + " ")) : string.Empty;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = ((string)value);
            return s == null ? new List<int>() : s.ToIntList();
        }
    }
}