using CefSharp;
using ProvBrowser.View.Windows;
using ProvBrowser.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProvBrowser;

public partial class App : Application
{
    private MainWindowViewModel mainViewModel;
    private MainWindow mainWindow;


    public void Initialize(MainWindowViewModel mainViewModel)
    {
        this.mainWindow = new MainWindow();
        mainWindow.DataContext = mainViewModel;
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        mainWindow.Show();  // отображаем главное окно на экране
        base.OnStartup(e);
    }

    /*void LoadResources()
    {
        this.Resources = new ResourceDictionary();

        this.Resources.MergedDictionaries.Add(
            new ResourceDictionary()
            { Source = new Uri("pack://application:,,,/WpfLibrary;component/Styles/MainDictionary.xaml") });
    }*/
}
