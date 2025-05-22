using CommunityToolkit.Mvvm.ComponentModel;
using ProvBrowser.ViewModel.Screens;

namespace ProvBrowser.ViewModel.Windows;
public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private MainScreenViewModel _screenViewModel;

    public MainWindowViewModel(MainScreenViewModel mainScreenViewModel)
    {
        ScreenViewModel = mainScreenViewModel;
    }
}
