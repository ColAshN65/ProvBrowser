using BrowserCore.Eventargs;
using BrowserCore.Handlers;
using CefSharp.Handler;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM.Core.Commands.Base;
using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using ProvBrowser.Model.Browser;
using ProvBrowser.Services.Browser;
using ProvBrowser.Services.Threading;
using ProvBrowser.Utilities;
using ProvBrowser.View;
using ProvBrowser.View.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml.Linq;

namespace ProvBrowser.ViewModel.Components;

public partial class BrowsersTabComponentViewModel : ObservableObject
{
    [ObservableProperty]
    private int _selectedIndex = -1;
    public ObservableCollection<TabItem> BrowsersTabs { get; set; } = new ObservableCollection<TabItem>();
    public BrowsersTabComponentViewModel(IDispatcherService dispatcherService, ITabManagerService tabManagerService)
    {
        this.dispatcherService = dispatcherService;
        this.tabManagerService = tabManagerService;

        lifeSpanHandler.Popup += OnBrowserLinked;
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

    private void GotFocus(object sender, RoutedEventArgs e)
    {
        BrowserTabModel tabModel = new BrowserTabModel(Guid.NewGuid(), "Бег", "https://www.google.ru/?hl=ru", false);
        tabManagerService.AddTabModel(tabModel);
        AddNewTab(tabModel);
    }

    private IDispatcherService dispatcherService;
    private ITabManagerService tabManagerService;   
    private CustomLifeSpanHandler lifeSpanHandler = new CustomLifeSpanHandler();
    private AddTabitemComponent addTabitemComponent = new AddTabitemComponent();

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
            BrowserItemComponent browserItemComponent = new BrowserItemComponent();
            BrowserItemComponentViewModel browserItemComponentViewModel = new BrowserItemComponentViewModel(browserTabModel, lifeSpanHandler);

            browserItemComponentViewModel.Closed += ItemClosed;

            browserItemComponent.DataContext = browserItemComponentViewModel;
            BrowsersTabs.Insert(BrowsersTabs.Count - 1, browserItemComponent);

            SelectedIndex = BrowsersTabs.Count - 2;
            
        }));
    }

    private void ItemClosed(object? sender, Guid e)
    {
        var index = BrowsersTabs.IndexOf(BrowsersTabs.FirstOrDefault(X => ((BrowserItemComponentViewModel)X.DataContext).Id == e));
        if (index != -1)
        {
            if(BrowsersTabs.Count > 2 && index == BrowsersTabs.Count - 2)
                SelectedIndex = BrowsersTabs.Count - 3;

            BrowserItemComponent currentTab = (BrowserItemComponent)BrowsersTabs[index];
            BrowserItemComponentViewModel currentViewModel = (BrowserItemComponentViewModel)currentTab.DataContext;

            currentViewModel = null;

            BrowsersTabs.Remove(BrowsersTabs[index]);
        }
    }
}