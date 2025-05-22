using ProvBrowser.View.Windows;
using ProvBrowser.ViewModel.Windows;
using System.Reflection;
using WpfLibrary.Navigation;
using WpfLibrary.Navigation.Builders;
using WpfLibrary.Navigation.Default;

namespace ProvBrowser.Builders;

public static class MainNavigationServiceBuilder
{
    public static DynamicNavigationSettings BuildSettings()
    {
        return new DynamicNavigationSettings(
            //Различия в пространствах имен.
            "View",
            "ViewModel",
            //Различия суффиксов в типах.
            "",
            "ViewModel",
            //Сборки, в которых находятся View и ViewModel.
            Assembly.GetAssembly(typeof(MainWindow)),
            Assembly.GetAssembly(typeof(MainWindowViewModel)));
    }

    public static INavigationService BuildService()
        => new DefaultNavigationServiceBuilder(BuildSettings()).Build();
}
