using CommunityToolkit.Mvvm.ComponentModel;
using ProvBrowser.ViewModel.Components;

namespace ProvBrowser.ViewModel.Screens;

public partial class MainScreenViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject _mainViewModel;

    public MainScreenViewModel(BrowsersTabComponentViewModel browsersTabViewModel)
    { 
        MainViewModel = browsersTabViewModel;
    }
}
