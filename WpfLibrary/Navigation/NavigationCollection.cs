using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfLibrary.Navigation.Events;

namespace WpfLibrary.Navigation;

public partial class NavigationCollection : ObservableCollection<INotifyPropertyChanged>, IDisposable
{
    private int _selectedIndex;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = value;
            OnPropertyChanged(new PropertyChangedEventArgs("SelectedIndex"));
        }
    }

    public event ItemChangedEventHandler<INotifyPropertyChanged> ItemAdded;
    public event ItemChangedEventHandler<INotifyPropertyChanged> ItemDeleted;
    public event ItemChangedEventHandler<INotifyPropertyChanged> ItemInserted;

    public void Add(INotifyPropertyChanged item)
    {
        base.Add(item);
        ItemAdded?.Invoke(this, new ItemChangedEventArgs<INotifyPropertyChanged>(item, Count - 1));
    }

    public void Insert(int index, INotifyPropertyChanged item)
    {
        base.Insert(index, item);
        ItemInserted?.Invoke(this, new ItemChangedEventArgs<INotifyPropertyChanged>(item, index));
    }

    public void Remove(INotifyPropertyChanged item)
    {
        int index = IndexOf(item);
        base.Remove(item);
        ItemDeleted?.Invoke(this, new ItemChangedEventArgs<INotifyPropertyChanged>(item, index));
    }

    public void RemoveAt(int index)
    {
        INotifyPropertyChanged item = Items[index];
        base.RemoveAt(index);
        ItemDeleted?.Invoke(this, new ItemChangedEventArgs<INotifyPropertyChanged>(item, index));
    }

    public void Dispose()
    {
        ItemAdded = null;
        ItemDeleted = null;
        ItemInserted = null;
    }
}
