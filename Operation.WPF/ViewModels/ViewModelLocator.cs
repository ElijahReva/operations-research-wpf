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


using System;
using Autofac;
using GalaSoft.MvvmLight;
using Operation.WPF.Services;

namespace Operation.WPF.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private readonly ViewModelFactory factory;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();
            ////if (ViewModelBase.IsInDesignModeStatic) 
            ////{ 
            ////    // Create design time view services and models           
            ////} 
            ////else 
            ////{ 
            ////    // Create run time view services and models                 
            ////}                               
            builder.RegisterInstance(this).As<ViewModelLocator>().SingleInstance();

            builder.RegisterType<ShellViewModel>().As<INavigationService>();
            builder.RegisterType<ShellViewModel>();
            builder.RegisterType<MainViewModel>().As<ViewModelBase>();
            builder.RegisterType<PointViewModel>().As<ViewModelBase>();
            builder.RegisterType<AboutViewModel>().As<ViewModelBase>();
            builder.RegisterType<ViewModelFactory>();
            var container = builder.Build();

            
            using (var scope = container.BeginLifetimeScope())
            {
                factory = scope.Resolve<ViewModelFactory>();
                shell = scope.Resolve<ShellViewModel>();
                shell.CurrentViewModel = factory.ResolveViewModel<MainViewModel>();
            }
            
        }

        private ShellViewModel shell;
        public ShellViewModel Shell
        {
            get { return shell; }
        }

        public MainViewModel Main => factory.ResolveViewModel<MainViewModel>();
        public PointViewModel Points => factory.ResolveViewModel<PointViewModel>();
        public AboutViewModel About => factory.ResolveViewModel<AboutViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

       
    }
}