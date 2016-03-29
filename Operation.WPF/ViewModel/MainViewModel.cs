using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;     
using MvvmDialogs;                 

namespace Operation.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogBuilder;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            _dialogBuilder = SimpleIoc.Default.GetInstance<IDialogService>(); 

        }

        /// <summary>
        /// The <see cref="IsEditable" /> property's name.
        /// </summary>
        public const string IsEditablePropertyName = "IsEditable";

        private bool _isEditable = true;

        /// <summary>
        /// Sets and gets the IsEditable property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsEditable
        {
            get
            {
                return _isEditable;
            }

            set
            {
                if (_isEditable == value)
                {
                    return;
                }

                _isEditable = value;
                RaisePropertyChanged(IsEditablePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ConditionCount" /> property's name.
        /// </summary>
        public const string ConditionCountName = "ConditionCount";

        private int _conditionCount;

        /// <summary>
        /// Sets and gets the ConditionCount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ConditionCount
        {
            get
            {
                return _conditionCount;
            }

            set
            {
                if (_conditionCount == value)
                {
                    return;
                }

                _conditionCount = value;
                RaisePropertyChanged(ConditionCountName);
            }
        }

        /// <summary>
        /// The <see cref="VarCount" /> property's name.
        /// </summary>
        public const string VarCountPropertyName = "VarCount";

        private int _varCount;

        /// <summary>
        /// Sets and gets the VarCount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int VarCount
        {
            get
            {
                return _varCount;
            }

            set
            {
                if (_varCount == value)
                {
                    return;
                }

                _varCount = value;
                RaisePropertyChanged(VarCountPropertyName);
            }
        }


        private void ExecuteClearCommand()
        {

            VarCount = 0;
            ConditionCount = 0;
            FunctionCoefs = new List<int>();
            IsEditable = true;
        }


        private RelayCommand _createCommand;

        public RelayCommand CreateCommand => _createCommand
                                             ?? (_createCommand = new RelayCommand(ExecuteCreateCommand, CanExecuteCreateCommand));

        private bool CanExecuteCreateCommand()
        {
            return _varCount > 0 && _varCount < 10 && _conditionCount > 0 && _conditionCount < 10;
        }

        private RelayCommand _clearCommand;


        public RelayCommand ClearCommand => _clearCommand
                                            ?? (_clearCommand = new RelayCommand(ExecuteClearCommand));

        private void ExecuteCreateCommand()
        {
            IsEditable = false;
            _dialogBuilder.ShowMessageBox(
                          this,
                          $"Переменных - {VarCount}, Условий  - {ConditionCount}",
                          "",
                          MessageBoxButton.OK,
                          MessageBoxImage.Warning);
        }

        private IEnumerable<string> _limits = new List<string> { "Min", "Max" };
        public IEnumerable<string> Limits
        {
            get { return _limits; }
            set { _limits = value; RaisePropertyChanged(); }
        }

        private string _selectedLim;
        public string SelectedLim
        {
            get { return _selectedLim; }
            set { _selectedLim = value; RaisePropertyChanged(); }
        }


        private IEnumerable<int> _functionCoefs;
        public IEnumerable<int> FunctionCoefs
        {
            get { return _functionCoefs; }
            set { _functionCoefs = value; RaisePropertyChanged(); }
        }



        private RelayCommand<string> _changeLocaleCommand;


        public RelayCommand<string> ChangeLocaleCommand => _changeLocaleCommand
                                            ?? (_changeLocaleCommand = new RelayCommand<string>(ExecuteChangeLocaleCommand));

        private void ExecuteChangeLocaleCommand(string locale)
        {
            switch (locale)
            {
                case "en-US":                                  
                    break;
                case "ru-RU":                                                                   
                    break;
                case "ua-UA":                                                                         
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
