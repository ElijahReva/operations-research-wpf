using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Operation.WPF.Contorls
{
    /// <summary>
    /// Interaction logic for OperationBox.xaml
    /// </summary>
    public partial class OperationBox : UserControl
    {
        public OperationBox()
        {
            InitializeComponent();
        }

        public static DependencyProperty OperatorsListProperty;
        public static DependencyProperty SelectedOperatorProperty;

        static OperationBox()
        {
            OperatorsListProperty = DependencyProperty.Register("OperationsList", typeof(IEnumerable), typeof(OperationBox));
            SelectedOperatorProperty = DependencyProperty.Register("SelectedOperator", typeof(object), typeof(OperationBox));
        }

        public IEnumerable OperatorsList
        {
            get { return (IEnumerable)GetValue(OperatorsListProperty); }
            set { SetValue(OperatorsListProperty, value); }
        }

        public object SelectedOperator
        {
            get { return GetValue(SelectedOperatorProperty); }
            set { SetValue(SelectedOperatorProperty, value); }
        }
    }
}
