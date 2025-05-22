using BrowserCore.Model;
using BrowserCore.Services.SearchEngine.Base;
using CefSharp;
using CommunityToolkit.Mvvm.Input;
using FeatureServices.Transcribing.Base;
using WPFMediaServices.Audio.Base;

namespace ProvBrowser.ViewModel.Components.TabItems;

public partial class AddTabitemComponentViewModel : BrowserItemComponentViewModel
{
    public AddTabitemComponentViewModel(IRecordingService recordingService, IFileTranscribationService transcribationService,
        ISearchEngineProviderService engineProviderService, ILifeSpanHandler lifeSpanHandler)
        : base(recordingService, transcribationService, engineProviderService, new BrowserTabModel(Guid.Empty, "Добавить...", "", false), lifeSpanHandler)
    {
    }

    public RelayCommand GotFocusCommand
    {
        get => new RelayCommand(() => { GotFocus?.Invoke(this, EventArgs.Empty); });
    }

    public event EventHandler GotFocus;

    public void Dispose()
    {
        GotFocus = null;
        base.Dispose();
    }
}
