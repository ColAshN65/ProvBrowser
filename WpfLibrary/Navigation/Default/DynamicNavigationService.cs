using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfLibrary.Navigation.Esceptions;
using WpfLibrary.Navigation.Exceptions;

namespace WpfLibrary.Navigation.Default;

/// <summary>
///     Динамическая реализация сервиса навигации, который при каждом вызове метода <see cref="LocateView(Type)"/> ищет подходящий тип View.
/// </summary>
public class DynamicNavigationService : INavigationService
{
    public DynamicNavigationSettings Settings;
    public INamespaceTransformer NamespaceTransformer;

    /// <param name="settings">Набор параметров, отвечающих за различие в расположении и наименовании типов View и ViewModel</param>
    /// <param name="namespaceTransformer">Трансформер, отвечающий за преобразование пространства имен. Если = null, то поиск будет осуществлятся в пространстве имен типа ViewModel.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public DynamicNavigationService(DynamicNavigationSettings settings, INamespaceTransformer namespaceTransformer = null)
    {
        if (settings is null)
            throw new ArgumentNullException(nameof(settings));

        this.Settings = settings;
        this.NamespaceTransformer = namespaceTransformer;
    }

    /// <summary>
    ///     Ищет экземпляр View (наследник <see cref="FrameworkElement"/>) в соответствии с имеющимися параметрами.
    /// </summary>
    /// <param name="viewModelType">
    ///     Экземпляр ViewModel, название типа которого идентично названию View за исключением суффикса.
    /// </param>
    /// <returns>Экземпляр найденной View.</returns>
    /// <exception cref="NonFindException"></exception>
    /// <exception cref="InstanceInitializeFailException"></exception>
    public FrameworkElement LocateView(Type viewModelType)
    {
        //Конвертация пространства имен
        StringBuilder path = new StringBuilder(viewModelType.Namespace);
        if (NamespaceTransformer != null)
            path = NamespaceTransformer.Transform(path);
        path.Append(".");

        //Конвертация суффикса
        var viewName = viewModelType.Name.Replace(Settings.ViewModelSuffix, Settings.ViewSuffix);
        path.Append(viewName);

        //Поиск типа в соответствующей сборке
        var stringPath = path.ToString();
        var type = Settings.ViewAssembly.GetType(stringPath);

        if (type == null || typeof(Type).IsAssignableFrom(type))
            throw new NonFindException("View type not found");

        //Получиение конструкторов
        var constructors = type.GetConstructors();

        try
        {
            var result = constructors[0].Invoke([]);
            return (FrameworkElement)result;
        }
        catch (Exception ex)
        {
            throw new InstanceInitializeFailException($"The Instance of {type} cannot be initialized.");
        }
    }
}
