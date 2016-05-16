using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Operation.WPF.Helpers;
using Operation.WPF.Services;

namespace Operation.WPF.ViewModels
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
        private readonly INavigationService navigationService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
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


        private int _conditionCount;
        public int ConditionCount
        {
            get { return _conditionCount; }

            set
            {
                if (_conditionCount == value) { return; }
                _conditionCount = value;
                RaisePropertyChanged();
            }
        }


        private int _varCount;
        public int VarCount
        {
            get { return _varCount; }
            set
            {
                if (_varCount == value)
                {
                    return;
                }

                _varCount = value;
                RaisePropertyChanged();
            }
        }





        private RelayCommand _generateCommand;
        public RelayCommand GenerateCommand => _generateCommand
                                             ?? (_generateCommand = new RelayCommand(ExecuteGenerateCommand));

        private void ExecuteGenerateCommand()
        {
            IsEditable = false;
            this.Generate();
        }

       

        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand => _clearCommand
                                            ?? (_clearCommand = new RelayCommand(ExecuteClearCommand));

        private void ExecuteClearCommand()
        {

            VarCount = 0;
            ConditionCount = 0;
            FunctionCoefs = String.Empty;
            IsEditable = true;
            Log.Clear();
        }

        private RelayCommand solveCommand;
        public RelayCommand SolveCommand => solveCommand
                                            ?? (solveCommand = new RelayCommand(ExecuteSolveCommand, CanExecuteSolveCommand));

        private bool CanExecuteSolveCommand()
        {
            return FunctionCoefs.Length > 2;
        }

        private void ExecuteSolveCommand()
        {
            var intList = FunctionCoefs.ToIntList();
            string result = intList.Aggregate(String.Empty, (current, i) => current + (i + " "));
            Xceed.Wpf.Toolkit.MessageBox.Show(Application.Current.MainWindow, result);
        }



        private IEnumerable<string> _limits = new List<string> { "Min", "Max" };
        public IEnumerable<string> Limits
        {
            get { return _limits; }
            set { _limits = value; RaisePropertyChanged(); }
        }

        private string _selectedLim = String.Empty;
        public string SelectedLim
        {
            get { return _selectedLim; }
            set { _selectedLim = value; RaisePropertyChanged(); }
        }


        private string _functionCoefs = String.Empty;
        public string FunctionCoefs
        {
            get { return _functionCoefs; }
            set { _functionCoefs = value; RaisePropertyChanged(); }
        }



        private string[] _columnHeaders;
        public string[] ColumnHeaders
        {
            get { return _columnHeaders; }
            set { _columnHeaders = value; RaisePropertyChanged(); }
        }

        private string[] _rowHeaders;
        public string[] RowHeaders
        {
            get { return _rowHeaders; }
            set { _rowHeaders = value; RaisePropertyChanged(); }
        }

        private int[,] _mainCoefs;
        public int[,] MainCoefs
        {
            get { return _mainCoefs; }
            set { _mainCoefs = value; RaisePropertyChanged(); }
        }

        void Generate()
        {
            var r = new Random();
            var columns = VarCount + 1;
            var colHead = new string[columns];
            var result = new int[columns, ConditionCount];  
            var rowHeaders = new string[ConditionCount];
            for (int i = 0; i < columns; i++)
            {

                colHead[i] = "x" + i;
                for (int j = 0; j < ConditionCount; j++)
                {
                    result[i, j] = r.Next(0, 10);
                }
            }

            for (int i = 0; i < ConditionCount; i++)
            {
                rowHeaders[i] = "Condition " + i;
            }
            MainCoefs = result;
            ColumnHeaders = colHead;
            RowHeaders = rowHeaders;

        }

        public Func<string, string, bool> OkCancelDialog  => (message, caption) => Xceed.Wpf.Toolkit.MessageBox.Show(message, caption, MessageBoxButton.OKCancel) == MessageBoxResult.OK;

        public ObservableCollection<string> Log { get; } = new ObservableCollection<string>();

        
        public RelayCommand Ping => new RelayCommand(() =>
        { Log.Add(OkCancelDialog("Test caption", "Why you must choose?") ? "Ok button pressed" : "Action canceled"); });

        public RelayCommand Nav => new RelayCommand(() =>
        {
            this.navigationService.Navigate<AboutViewModel>();    
        });
        public RelayCommand GoChooseView => new RelayCommand(() =>
        {
            this.navigationService.Navigate<ChooseViewModel>();    
        });
    }
}
