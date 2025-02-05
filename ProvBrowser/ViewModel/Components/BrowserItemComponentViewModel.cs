using BrowserCore.Eventargs;
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
    private string? _title;


    [ObservableProperty]
    private string? _url;

    //[ObservableProperty]

    private IWpfWebBrowser _webBrowser;

    public IWpfWebBrowser WebBrowser
    {
        get => _webBrowser;
        set
        {
            if (value is not null)
            {
                /*CustomLifeSpanHandler lifespanHandler = new CustomLifeSpanHandler();
                lifespanHandler.Popup += Linked;*/
                value.LifeSpanHandler = mainLifeSpanHandler;
            }

            _webBrowser = value;
            OnPropertyChanged();

            
        }
    }

    private CustomLifeSpanHandler mainLifeSpanHandler = new CustomLifeSpanHandler();
    public BrowserItemComponentViewModel(string url)
    {
        Url = url;
    }
    public BrowserItemComponentViewModel(string url, CustomLifeSpanHandler lifeSpanHandler)
    {
        Url = url;
        mainLifeSpanHandler = lifeSpanHandler;
    }

    public BaseCommand TestCommand
    {
        get => new BaseCommand((obj) =>
        {


        });
    }

    public event EventHandler<LinkedEventArgs> Linked;
}
