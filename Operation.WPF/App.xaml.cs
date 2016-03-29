using System.Windows;
using Operation.WPF.LangManager;

namespace Operation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            LocalizationManager.Instance.LocalizationProvider = new ResxLocalizationProvider();
            base.OnStartup(e);
        }
    }
}
