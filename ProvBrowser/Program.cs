using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProvBrowser.View.Windows;
using ProvBrowser.ViewModel.Windows;
using System.Windows.Threading;
using ProvBrowser.ViewModel.Screens;
using ProvBrowser.View.Components;
using ProvBrowser.ViewModel.Components;
using ProvBrowser.Services.Browser;
using System.Reflection;
using WpfLibrary.Navigation;
using WpfLibrary.Navigation.Default;
using ProvBrowser.Builders;
using Services.Threading;
using Services.Threading.Base;

namespace ProvBrowser;

public class Program
{
    [STAThread]
    public static void Main()
    {
        NavigationControl.NavigationService = MainNavigationServiceBuilder.BuildService();

        MainDispatcherService mainDispatcherService = new MainDispatcherService(Dispatcher.CurrentDispatcher);
        MainTabManagerService mainTabManagerService = new MainTabManagerService();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.BuildRecognizingConfiguration();
                services.BuildBrowserCoreConfiguration();
                
                services.AddSingleton<IDispatcherService>(mainDispatcherService);
                services.AddSingleton<ITabManagerService>(mainTabManagerService);

                services.AddSingleton<App>();

                services.AddSingleton<MainWindowViewModel>();

                services.AddSingleton<MainScreenViewModel>();

                services.AddSingleton<BrowsersTabComponentViewModel>();
            })
            .Build();

        // получаем сервис - объект класса App
        var app = host.Services.GetService<App>();

        app.InitializeComponent();

        app.Initialize(host.Services.GetService<MainWindowViewModel>());

        // запускаем приложения
        app?.Run();
    }
}