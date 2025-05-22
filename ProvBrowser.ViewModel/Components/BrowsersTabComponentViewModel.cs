using BrowserCore.Eventargs;
using BrowserCore.Handlers;
using BrowserCore.Model;
using BrowserCore.Services.SearchEngine.Base;
using BrowserCore.Services.TabManager.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FeatureServices.Transcribing.Base;
using ProvBrowser.ViewModel.Components.TabItems;
using Services.Audio;
using WpfLibrary.Navigation;
using WpfLibrary.Services.Threading.Base;
namespace ProvBrowser.ViewModel.Components;

public partial class BrowsersTabComponentViewModel : ObservableObject, IDisposable
{
    public NavigationCollection BrowsersTabs { get; set; } = new NavigationCollection();
    public BrowsersTabComponentViewModel(
        NAudioRecordingServiceBuilder recordingServiceBuilder, IFileTranscribationService transcribationService, 
        IDispatcherService dispatcherService, 
        ITabManagerService tabManagerService,
        ISearchEngineProviderService engineProviderService)
    {
        this.recordingServiceBuilder = recordingServiceBuilder;
        this.transcribationService = transcribationService;

        this.dispatcherService = dispatcherService;
        this.tabManagerService = tabManagerService;

        this.engineProviderService = engineProviderService;

        lifeSpanHandler.Popup += OnBrowserLinked;

        addTabitemComponent = new AddTabitemComponentViewModel(null, transcribationService, engineProviderService, lifeSpanHandler);
    }
    public RelayCommand LoadCommand
    {
        get => new RelayCommand(() =>
        {
            foreach (BrowserTabModel model in tabManagerService.GetSavedTabs())
            {
                BrowsersTabs.Add(addTabitemComponent);

                addTabitemComponent.GotFocus += GotFocus;

                AddNewTab(model);
            }
        });
    }

    private void GotFocus(object sender, EventArgs e)
    {
        BrowserTabModel tabModel = new BrowserTabModel(Guid.NewGuid(), "Бег", engineProviderService.GetHomePageUrl(), false);
        tabManagerService.AddTabModel(tabModel);
        AddNewTab(tabModel);
    }

    private readonly IDispatcherService dispatcherService;
    private readonly ITabManagerService tabManagerService;
    private readonly ISearchEngineProviderService engineProviderService;

    private readonly NAudioRecordingServiceBuilder recordingServiceBuilder;
    private readonly IFileTranscribationService transcribationService;


    private readonly CustomLifeSpanHandler lifeSpanHandler = new CustomLifeSpanHandler();
    private readonly AddTabitemComponentViewModel addTabitemComponent;

    private void OnBrowserLinked(object? sender, LinkedEventArgs e)
    {
        BrowserTabModel newTab = new BrowserTabModel(Guid.NewGuid(),"Новый", e.NewUrl, false);
        tabManagerService.AddTabModel(newTab);
        AddNewTab(newTab);
    }
    private void AddNewTab(BrowserTabModel browserTabModel)
    {
        dispatcherService.InvokeAsync(new Action(() =>
        {
            BrowserItemComponentViewModel browserItemComponentViewModel
                = new BrowserItemComponentViewModel(recordingServiceBuilder.BuildService(browserTabModel.Id), transcribationService, engineProviderService, browserTabModel, lifeSpanHandler);

            browserItemComponentViewModel.Closed += ItemClosed;

            BrowsersTabs.Insert(BrowsersTabs.Count - 1, browserItemComponentViewModel);

            BrowsersTabs.SelectedIndex = BrowsersTabs.Count - 2;
        }));
    }

    private void ItemClosed(object? sender, Guid e)
    {
        var index = BrowsersTabs.IndexOf(BrowsersTabs.FirstOrDefault(X => ((BrowserItemComponentViewModel)X).Id == e));
        if (index != -1)
        {
            if(BrowsersTabs.Count > 2 && index == BrowsersTabs.Count - 2)
                BrowsersTabs.SelectedIndex = BrowsersTabs.Count - 3;

            BrowsersTabs.Remove(BrowsersTabs[index]);
        }
    }

    public void Dispose()
    {
        foreach (var browserTab in BrowsersTabs)
        {
            if (browserTab is IDisposable disposable) disposable.Dispose();
        }
    }
}