using ProvBrowser.View;
using ProvBrowser.ViewModel;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Windows;
using CefSharp;
using CefSharp.Wpf;
using MVVM.Core.Locators;

namespace ProvBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            //ViewLocator.UseSettings(new LocatorSettings("ProvBrowser.View", "ProvBrowser.ViewModel", "View", "ViewModel"));
        }
        private MainWindowView Window { get; set; }
        public MainWindowViewModel MainViewModel { get; set; }



        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainViewModel = new MainWindowViewModel();
            Window = new MainWindowView { DataContext = MainViewModel };
            Window.Show();
        }

    }

}
