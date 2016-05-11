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
        private readonly ViewModelFactory _factory;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator(ViewModelFactory factory)
        {
            _factory = factory;
        }

        public ViewModelLocator()
        {
            throw new System.NotImplementedException();
        }

        public MainViewModel Main => _factory.ResolveViewModel<MainViewModel>();
        public PointViewModel Points => _factory.ResolveViewModel<PointViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
                  
}