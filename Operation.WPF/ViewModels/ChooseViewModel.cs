using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Operation.WPF.Services;

namespace Operation.WPF.ViewModels
{
    public class ChooseViewModel
        : ViewModelBase
    {
        private readonly INavigationService navigation;

        public ChooseViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
        }
        
        public RelayCommand GoBack => new RelayCommand(() =>
        {
            this.navigation.Navigate<MainViewModel>();
        });
    }
}
