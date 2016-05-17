using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<string> operators = new ObservableCollection<string> { "+", "-", "*", "/" };
        /// <summary>
        /// Sets and gets the PropertyName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> Operators
        {
            get { return operators; }

            set
            {
                if (operators == value)
                {
                    return;
                }

                operators = value;
                RaisePropertyChanged();
            }
        }

    }
}
