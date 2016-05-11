using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Operation.WPF.ViewModel
{
    public class ViewModelFactory
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
