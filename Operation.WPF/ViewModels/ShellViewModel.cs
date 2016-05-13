using System;
using System.Collections.Generic;
using Autofac;
using GalaSoft.MvvmLight;
using Operation.WPF.Services;

namespace Operation.WPF.ViewModels
{
    public class ShellViewModel:
        ViewModelBase, INavigationService, IViewModelFactory
    {
        private readonly Lazy<IEnumerable<ViewModelBase>> viewModels;

        public ShellViewModel(Lazy<IEnumerable<ViewModelBase>> viewModels)
        {
            this.viewModels = viewModels;
        }

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { currentViewModel = value; RaisePropertyChanged(); }
        }

        public void Navigate<T>() where T : ViewModelBase
        {
            foreach (var baseViewModel in viewModels.Value)
            {
                if (baseViewModel is T)
                {
                    CurrentViewModel = baseViewModel as T;
                }
            }
        }

        public T ResolveViewModel<T>() where T : ViewModelBase
        {
            foreach (var baseViewModel in viewModels.Value)
            {
                if (baseViewModel is T)
                {
                    return baseViewModel as T;
                }
            }
            throw new TypeLoadException();
        }
    }
}