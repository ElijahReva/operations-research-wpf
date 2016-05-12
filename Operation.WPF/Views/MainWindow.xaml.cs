using System;
using System.Windows;

namespace Operation.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();
           
        }
       
        private void Exit(object sender, RoutedEventArgs e)
        {
                Environment.Exit(0);
        }

        
    }
}
