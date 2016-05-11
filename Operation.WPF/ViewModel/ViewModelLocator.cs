/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Operation.WPF"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/


using Autofac;
using Microsoft.Practices.ServiceLocation;

namespace Operation.WPF.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
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
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public PointViewModel Points => ServiceLocator.Current.GetInstance<PointViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
                  
}