using CefSharp.Wpf;
using MVVM.Core.Commands.Base;
using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using ProvBrowser.Utilities;
using ProvBrowser.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProvBrowser.ViewModel
{
    public class MainWindowViewModel : SimpleViewModel
    {
        public VmContainer MainContent
        {
            get => _mainContent;
            set => Set(ref  _mainContent, value); 
        }
        private VmContainer _mainContent;

        public MainWindowViewModel()
        {
            MainContent = new VmContainer(new TabBrowswerView(), new TabBrowserViewModel());
        }
    }
}
