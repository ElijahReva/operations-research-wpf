using System;
using System.Globalization;

namespace Operation.WPF.Converters
{
    public class InverseBoolConverter : ConvertorBase<InverseBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
