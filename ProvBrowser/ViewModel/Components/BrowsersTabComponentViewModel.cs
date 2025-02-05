using BrowserCore.Eventargs;
using BrowserCore.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVM.Core.Commands.Base;
using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using ProvBrowser.Utilities;
using ProvBrowser.View;
using ProvBrowser.View.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProvBrowser.ViewModel.Components;

public partial class BrowsersTabComponentViewModel : ObservableObject
{
    private CustomLifeSpanHandler lifeSpanHandler = new CustomLifeSpanHandler();

    [ObservableProperty]
    public VmContainerCollection browsersCollection = new VmContainerCollection();
    public BrowsersTabComponentViewModel()
    {
        BrowsersCollection.AddContainer(new VmContainer(
                new BrowserItemComponent(),
                new BrowserItemComponentViewModel("https://www.google.ru/?hl=ru", lifeSpanHandler)));

        BrowsersCollection.CollectionChanged += BrowserCollectionChanged;



        lifeSpanHandler.Popup += OnBrowserLinked;
        /*Test.Add(new VmContainer(
                new BrowserItemComponent(),
                new BrowserItemComponentViewModel("https://www.google.ru/?hl=ru")));*/

    }

    private void BrowserCollectionChanged(object? sender, EventArgs e)
    {
        //((BrowserItemComponent)BrowsersCollection.Views.Last()).Linked

        ((BrowserItemComponentViewModel)BrowsersCollection.ViewModels.Last()).Linked += OnBrowserLinked;
    }

    private void OnBrowserLinked(object? sender, LinkedEventArgs e)
    {
        BrowsersCollection.AddContainer(new VmContainer(
                new BrowserItemComponent(),
                new BrowserItemComponentViewModel(e.NewUrl, lifeSpanHandler)));
    }
}