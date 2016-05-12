using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Operation.WPF.ViewModels
{
    public class AboutViewModel 
        : ViewModelBase
    {
        public AboutViewModel() 
        {

        }

        public string Text { get; } = "AboutAboutAboutAboutAboutAboutAbout" + Environment.NewLine +
                                      "AboutAboutAbout" + Environment.NewLine +
                                      "AboutAbout" + Environment.NewLine +
                                      "About" + Environment.NewLine +
                                      "About";
    }
}
