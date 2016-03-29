using System.Windows;

namespace Operation.WPF.Converters
{
    public class VariablesWrapper : DependencyObject
    {
        public static readonly DependencyProperty VariableCountProperty =
            DependencyProperty.Register("VariableCount", typeof(int),
                typeof(VariablesWrapper), new FrameworkPropertyMetadata(int.MaxValue));

        public int VariableCount
        {
            get { return (int)GetValue(VariableCountProperty); }
            set { SetValue(VariableCountProperty, value); }
        }


    }
}