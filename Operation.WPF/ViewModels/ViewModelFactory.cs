using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace Operation.WPF.ViewModels
{
    public class ViewModelFactory: IViewModelFactory
    {
        private readonly IEnumerable<ViewModelBase> _viewModels;

        public ViewModelFactory(IEnumerable<ViewModelBase> viewModels)
        {
            _viewModels = viewModels;
        }

        public T ResolveViewModel<T>() where T : ViewModelBase
        {
            foreach (var baseViewModel in _viewModels)
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
