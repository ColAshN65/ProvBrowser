using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfLibrary.Navigation.Events;

namespace WpfLibrary.Navigation;

public class NavigationTabControl : TabControl
{
    /// <summary>
    ///     Статический экземпляр сервиса, который используется для поиска соответствующего Content. По умолчанию null.
    /// </summary>
    public static INavigationService NavigationService;

    public NavigationTabControl()
    {
        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue is not null &&
            e.OldValue is IDisposable oldDataContext)
            oldDataContext.Dispose();

        if (e.NewValue is not null && 
            e.NewValue is NavigationCollection navigationCollection)
        {
            navigationCollection.ItemAdded += OnViewModelAdded;
            navigationCollection.ItemDeleted += OnViewModelDeleted;
            navigationCollection.ItemInserted += OnViewModelInserted;
        }
    }
    private void OnViewModelAdded(object sender, ItemChangedEventArgs<INotifyPropertyChanged> e)
    {
        TabItem tabItem = (TabItem)NavigationService.LocateView(e.Item.GetType());
        tabItem.DataContext = e.Item;
        Items.Add(tabItem);
    }
    private void OnViewModelInserted(object sender, ItemChangedEventArgs<INotifyPropertyChanged> e)
    {
        TabItem tabItem = (TabItem)NavigationService.LocateView(e.Item.GetType());
        tabItem.DataContext = e.Item;
        Items.Insert(e.Index, tabItem);
    }
    private void OnViewModelDeleted(object sender, ItemChangedEventArgs<INotifyPropertyChanged> e)
    {
        Items.RemoveAt(e.Index);
    }
}
