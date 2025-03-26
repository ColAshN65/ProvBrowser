using System.Windows;

namespace WpfLibrary.Navigation;

public interface INavigationService
{
    public FrameworkElement LocateView(Type viewModelType);
}
