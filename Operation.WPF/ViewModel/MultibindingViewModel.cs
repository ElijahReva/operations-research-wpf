using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Operation.WPF.ViewModel
{
    public class MultibindingViewModel : ViewModelBase
    {

        private double _left = 0;
        public double Left
        {
            get { return _left; }

            set
            {
                if (Math.Abs(_left - value) < double.Epsilon)
                {
                    return;
                }
                _left = value;
                RaisePropertyChanged();
            }
        }

        private double _right = 0;
        public double Right
        {
            get { return _right; }

            set
            {
                if (Math.Abs(_right - value) < double.Epsilon)
                {
                    return;
                }
                _right = value;
                RaisePropertyChanged();
            }
        }
                                      
       
        private ObservableCollection<string> _resultList = new ObservableCollection<string>();
        public ObservableCollection<string> ResultList
        {
            get { return _resultList; }

            private set
            {
                if (_resultList == value)
                {
                    return;
                }

                _resultList = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand calculate;
        public RelayCommand Calculate => calculate ?? (calculate = new RelayCommand(ExecuteCalculate));

        private void ExecuteCalculate()
        {
            try
            {
                var result = Left / Right;
                ResultList.Add(result.ToString());
            }
            catch (Exception ex)
            {
                ResultList.Add($"{DateTime.Now} - {ex.Message}");
            }
        }
    }
}