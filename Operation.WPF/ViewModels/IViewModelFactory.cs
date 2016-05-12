using GalaSoft.MvvmLight;

namespace Operation.WPF.ViewModels
{
    public interface IViewModelFactory
    {
        T ResolveViewModel<T>() where T : ViewModelBase;
    }
}