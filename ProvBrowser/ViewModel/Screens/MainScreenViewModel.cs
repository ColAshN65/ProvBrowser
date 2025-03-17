using CommunityToolkit.Mvvm.ComponentModel;
using MVVM.Core.ViewModel;
using ProvBrowser.Utilities;
using ProvBrowser.View.Components;
using ProvBrowser.ViewModel.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProvBrowser.ViewModel.Screens;

public partial class MainScreenViewModel : ObservableObject
{
    [ObservableProperty]
    private VmContainer? _mainContent;

    public MainScreenViewModel(BrowsersTabComponentViewModel browsersTabViewModel)
    {
        MainContent = new VmContainer(
            new BrowsersTabComponent(),
            browsersTabViewModel);
    }
}
