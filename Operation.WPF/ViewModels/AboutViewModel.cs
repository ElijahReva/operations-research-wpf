using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Operation.WPF.Services;

namespace Operation.WPF.ViewModels
{
    public class AboutViewModel 
        : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public AboutViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public string Text { get; } = "AboutAboutAboutAboutAboutAboutAbout" + Environment.NewLine +
                                      "AboutAboutAbout" + Environment.NewLine +
                                      "AboutAbout" + Environment.NewLine +
                                      "About" + Environment.NewLine +
                                      "About";

        public RelayCommand GoBackCommand => new RelayCommand(() =>
        {
            this.navigationService.Navigate<MainViewModel>();
        });
    }
}
