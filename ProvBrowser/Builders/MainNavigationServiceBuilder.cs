using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary.Navigation;
using WpfLibrary.Navigation.Builders;
using WpfLibrary.Navigation.Default;

namespace ProvBrowser.Builders;

public class MainNavigationServiceBuilder
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
            Assembly.GetExecutingAssembly(),
            Assembly.GetExecutingAssembly());
    }

    public static INavigationService BuildService()
        => new DefaultNavigationServiceBuilder(BuildSettings()).Build();
}
