using System.Windows;

namespace Operation.WPF.Helpers
{
    public class VariablesWrapper : DependencyObject
    {
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register("Count", typeof(int),
                typeof(VariablesWrapper), new FrameworkPropertyMetadata(int.MaxValue));

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set
            {
                SetValue(CountProperty, value);
            }
        }


    }
}