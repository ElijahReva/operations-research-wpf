using GalaSoft.MvvmLight;
using Operation.WPF.ViewModels;

namespace Operation.WPF.Services
{
    public class NavigationService 
        : INavigationService
    {
        private readonly ViewModelFactory factory;

        public NavigationService(ViewModelFactory factory)
        {
            this.factory = factory;
        }

        public void Navigate<T>() where T : ViewModelBase
        {
            var shell = factory.ResolveViewModel<ShellViewModel>();
            shell.CurrentViewModel = factory.ResolveViewModel<T>();
        }
    }
}