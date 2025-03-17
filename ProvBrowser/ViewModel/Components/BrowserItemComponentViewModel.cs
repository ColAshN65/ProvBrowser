using BrowserCore.Eventargs;
using CefSharp;
using CefSharp.Wpf;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProvBrowser.Model.Browser;

namespace ProvBrowser.ViewModel;

public partial class BrowserItemComponentViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _title = "Загрузка...";
    public string BrowserTitle
    {
        get => Title;
        set
        {
            if (value is not null && value.Length > 15)
            {
                value = value.Remove(12);
                value += "...";
            }
            Title = value;
        }
    }

    [ObservableProperty]
    private string? _url;

    [ObservableProperty]
    private IWpfWebBrowser _webBrowser;

    public Guid Id { get; private set; }


    public BrowserItemComponentViewModel(BrowserTabModel browserTab, ILifeSpanHandler lifeSpanHandler)
    {
        Url = browserTab.Url;
        mainLifeSpanHandler = lifeSpanHandler;
        isFavorite = browserTab.IsFavorite;
        Id = browserTab.Id;
    }

    public RelayCommand BackCommand
    {
        get => new RelayCommand(() =>
        {
            WebBrowser.Back();
        });
    }
    public RelayCommand ReloadCommand
    {
        get => new RelayCommand(() =>
        {
            WebBrowser.Reload();
        });
    }
    public RelayCommand ForwardCommand
    {
        get => new RelayCommand(() =>
        {
            WebBrowser.Forward();
        });
    }
    public RelayCommand FavoriteCommand
    {
        get => new RelayCommand(() =>
        {

        });
    }
    public RelayCommand HomeCommand
    {
        get => new RelayCommand(() =>
        {
        });
    }
    public RelayCommand CloseCommand
    {
        get => new RelayCommand(() =>
        {
            Closed?.Invoke(this, Id);
        });
    }

    public event EventHandler<LinkedEventArgs> Linked;
    public event EventHandler<Guid> Closed;
    public event EventHandler<bool> FavoriteToggle;


    private ILifeSpanHandler mainLifeSpanHandler;
    private bool isFavorite;

    partial void OnWebBrowserChanged(IWpfWebBrowser value)
    {
        if (value is not null)
        {
            value.LifeSpanHandler = mainLifeSpanHandler;
        }
        _webBrowser = value;
        OnPropertyChanged();
    }
}
