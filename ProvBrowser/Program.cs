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
using System.Windows.Controls;
using ProvBrowser.View.Screens;
using CommunityToolkit.Mvvm.ComponentModel;
using BrowserCore.Services.TabManager.Base;
using SupportServices.FileManager;

namespace ProvBrowser;

public class Program : ObservableObject
{
    [STAThread]
    public static void Main()
    {
        INavigationService navigation = MainNavigationServiceBuilder.BuildService();
        NavigationControl.NavigationService = navigation;
        NavigationTabControl.NavigationService = navigation;

        var fileManagerService = new CacheFileManagerService("cache");

        MainDispatcherService mainDispatcherService = new MainDispatcherService(Dispatcher.CurrentDispatcher);
        MainTabManagerService mainTabManagerService = new MainTabManagerService();
        var notificationService = new MessageBoxNotificationService();

        IServiceCollection serviceCollection = null;

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                serviceCollection = services;
                 
                services.BuildRecognizingConfiguration(notificationService, fileManagerService);
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

        var browsersTab = host.Services.GetService<BrowsersTabComponentViewModel>();

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

        //Высвобождение всех ресурсов и файловых потоков, занятых браузером.
        browsersTab.Dispose();

        //Очистка основного файлового менеджера
        fileManagerService.Dispose();
    }
}