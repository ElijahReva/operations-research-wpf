using System.Windows;
using Autofac;
using Operation.WPF.ViewModel;

namespace Operation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var container = new ContainerBuilder();
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models          
            ////}
            ////else
            ////{
            ////    // Create run time view services and models                
            ////}                              
            container.RegisterType<MainViewModel>();
            container.RegisterType<PointViewModel>();
            container.RegisterType<ViewModelLocator>();
            container.RegisterType<ViewModelFactory>();
            Application.Current.MainWindow = new Shell();
        }
    }
}
