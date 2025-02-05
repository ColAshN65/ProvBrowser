using CefSharp.Wpf;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVM.Core.Commands.Base;
using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using ProvBrowser.Utilities;
using ProvBrowser.View;
using ProvBrowser.View.Screens;
using ProvBrowser.ViewModel.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProvBrowser.ViewModel.Windows;
public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private VmContainer _screen;

    public MainWindowViewModel()
    {
        Screen = new VmContainer(
            new MainScreen(),
            new MainScreenViewModel());
    }
}
