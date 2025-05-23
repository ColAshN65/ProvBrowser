﻿using BrowserCore.Eventargs;
using BrowserCore.Model;
using BrowserCore.Services.SearchEngine.Base;
using CefSharp;
using CefSharp.Wpf;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FeatureServices.Transcribing.Base;
using WPFMediaServices.Audio.Base;

namespace ProvBrowser.ViewModel.Components.TabItems;

public partial class BrowserItemComponentViewModel : ObservableObject, IDisposable
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

    public BrowserItemComponentViewModel(
        IRecordingService recordingService, 
        IFileTranscribationService transcribationService,
        ISearchEngineProviderService engineProviderService,
        BrowserTabModel browserTab, ILifeSpanHandler lifeSpanHandler)
    {
        this.recordingService = recordingService;
        this.transcribationService = transcribationService;
        this.engineProviderService = engineProviderService;

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

    public RelayCommand RecordCommand
    {
        get => new RelayCommand(StartRecord);
    }
    public RelayCommand RecordStopCommand
    {
        get => new RelayCommand(StopRecord);
    }

    private async void StopRecord()
    {
        recordingService.StopRecording();
        var result = await transcribationService.SpeechToTextAsync(recordingService.GetFileName());
        if(result.IsSuccess)
            Url = engineProviderService.GetSearchPageUrl(result.Text);
    }
    

    private void StartRecord()
    {
        recordingService.StartRecording();
    }

    public event EventHandler<LinkedEventArgs> Linked;
    public event EventHandler<Guid> Closed;
    public event EventHandler<bool> FavoriteToggle;


    private readonly IRecordingService recordingService;
    private readonly IFileTranscribationService transcribationService;
    private readonly ISearchEngineProviderService engineProviderService;
    private readonly ILifeSpanHandler mainLifeSpanHandler;
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

    public void Dispose()
    {
        Linked = null;
        Closed = null;
        FavoriteToggle = null;

        recordingService?.Dispose();
    }
}
