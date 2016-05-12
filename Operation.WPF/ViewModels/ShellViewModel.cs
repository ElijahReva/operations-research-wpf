using System.Collections.Generic;
using Autofac;
using GalaSoft.MvvmLight;
using Operation.WPF.Services;

namespace Operation.WPF.ViewModels
{
    public class ShellViewModel:
        ViewModelBase, INavigationService
    {
        private readonly IComponentContext context;

        public ShellViewModel(IComponentContext context)
        {
            this.context = context;
        }

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { currentViewModel = value; RaisePropertyChanged(); }
        }

        public void Navigate<T>() where T : ViewModelBase
        {
            var viewModels = context.Resolve<IEnumerable<ViewModelBase>>();
            foreach (var baseViewModel in viewModels)
            {
                if (baseViewModel is T)
                {
                    CurrentViewModel = baseViewModel as T;
                }
            }
        }
    }
}