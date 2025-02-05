using BrowserCore.Handlers;
using CefSharp;
using CefSharp.Wpf;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVM.Core.Commands.Base;
using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using ProvBrowser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProvBrowser.ViewModel;

public partial class BrowserItemComponentViewModel : ObservableObject
{
    [ObservableProperty]
    private string? title;


    [ObservableProperty]
    private string? url;

    [ObservableProperty]
    private IWpfWebBrowser webBrowser;

    public BrowserItemComponentViewModel(string url)
    {
        Url = url;

    }

    public BaseCommand TestCommand
    {
        get => new BaseCommand((obj) =>
        {


        });
    }
}
