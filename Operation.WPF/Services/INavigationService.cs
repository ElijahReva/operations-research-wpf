using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Operation.WPF.Services
{
    public interface INavigationService
    {
        void Navigate<T>() where T : ViewModelBase;
    }
}
