using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using WpfLibrary.Navigation.Builders;
using WpfLibrary.Navigation.Default;

namespace WpfLibrary.Navigation;

/// <summary>
///     Пользовательский элемент управления. Пытается установить в качестве Content View, соответствующую ViewModel с помощью
///     реализации INavigationService, если такая была задана.
/// </summary>
public class NavigationControl : UserControl
{
    /// <summary>
    ///     Статический экземпляр сервиса, который используется для поиска соответствующего Content. По умолчанию null.
    /// </summary>
    public static INavigationService NavigationService;
    public NavigationControl()
    {
        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (NavigationService is not null && e.NewValue is INotifyPropertyChanged)
        {
            var view = NavigationService.LocateView(e.NewValue.GetType());
            Content = view;
        }

        if (e.NewValue is null)
            Content = null;
    }
}
