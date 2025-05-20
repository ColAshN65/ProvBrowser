using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProvBrowser.ViewModel.Windows;
using System.Windows.Threading;
using ProvBrowser.ViewModel.Screens;
using ProvBrowser.ViewModel.Components;
using ProvBrowser.Services.Browser;
using WpfLibrary.Navigation;
using ProvBrowser.Builders;
using WpfLibrary.Services.Threading;
using SupportServices.Notification.Base;
using WpfLibrary.Services.Threading.Base;
using WpfLibrary.Services.Notification;

namespace ProvBrowser;

public class Program
{
    [STAThread]
    public static void Main()
    {
        NavigationControl.NavigationService = MainNavigationServiceBuilder.BuildService();

        MainDispatcherService mainDispatcherService = new MainDispatcherService(Dispatcher.CurrentDispatcher);
        MainTabManagerService mainTabManagerService = new MainTabManagerService();
        var notificationService = new MessageBoxNotificationService();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.BuildRecognizingConfiguration(notificationService);
                services.BuildBrowserCoreConfiguration();

                services.AddSingleton<INotificationService>(notificationService);
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

        try
        {
            // запускаем приложения
            app?.Run();
        }
        catch (Exception ex)
        {
            notificationService.NotifyException("Возникло нобработанное исключение в программе!", ex);
        }
        
    }
}