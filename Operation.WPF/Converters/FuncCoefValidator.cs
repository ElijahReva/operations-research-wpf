using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using Operation.WPF.Helpers;

namespace Operation.WPF.Converters
{
    public class FuncCoefValidator : ValidationRule
    {
        public VariablesWrapper Variables { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var age = new List<int>();
            try
            {
                var str = (string)value;
                if (str.Length > 0)
                {
                    age = str.ToIntList();
                }
                else
                {
                    return new ValidationResult(false, "Empty string");
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }
            if (age.Count == 0 || age.Count != Variables.Count)
            {
                return new ValidationResult(false, "You must enter  exact numbers int as variables!");
            }
            return new ValidationResult(true, null);

        }
    }
}