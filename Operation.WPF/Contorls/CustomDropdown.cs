using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Operation.WPF.Contorls
{
    public class CustomDropdown
        : ComboBox
    {
        public IEnumerable<ImageSource> Source
        {
            set { base.SetValue(SourceProperty, value); }
        }
        public static readonly DependencyProperty SourceProperty =
          DependencyProperty.Register("Source", typeof(IEnumerable<ImageSource>), typeof(IEnumerable<ImageSource>));
    }
}
