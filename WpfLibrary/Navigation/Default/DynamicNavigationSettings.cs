using System.Reflection;
using WpfLibrary.Navigation.Helpers.Validators;

namespace WpfLibrary.Navigation.Default;

/// <summary>
///     Набор настроек для динамической навигации, которая включает в себя различия в сборках, 
///     пространствах имен и суффиксах при идентичном наименовании.
/// </summary>
public class DynamicNavigationSettings
{
    #region Backing fields

    private string _viewNamespace;
    private string _viewModelNamespace;
    private string _viewSuffix;
    private string _viewModelSuffix;
    private Assembly? _viewAssembly;
    private Assembly? _viewModelAssembly;

    private static DynamicNavigationSettings _default;

    #endregion

    #region Properties
    /// <summary>
    ///     Статические настройки по умолчанию.
    /// </summary>
    public static DynamicNavigationSettings Default
    {
        get => _default;
        set
        {
            SettingsValidator.Validate(value);
            _default = value;
        }
    }

    /// <summary>
    ///     Отличительная часть пространства имен с View. Обычно это "View".
    /// </summary>
    public string ViewNamespace
    {
        get => _viewNamespace;
        set
        {
            NamespaceValidator.Validate(value);
            _viewNamespace = value;
        }
    }

    /// <summary>
    ///     Отличительная часть пространства имен с ViewModel. Обычно это "ViewModel".
    /// </summary>
    public string ViewModelNamespace
    {
        get => _viewModelNamespace;
        set
        {
            NamespaceValidator.Validate(value);
            _viewModelNamespace = value;
        }
    }

    /// <summary>
    ///     Отличительный суффикс в наименовании View.
    /// </summary>
    public string ViewSuffix
    {
        get => _viewSuffix;
        set
        {
            TypeSuffixValidator.Validate(value);
            _viewSuffix = value;
        }
    }

    /// <summary>
    ///     Отличительный суффикс в наименовании ViewModel.
    /// </summary>
    public string ViewModelSuffix
    {
        get => _viewModelSuffix;
        set
        {
            TypeSuffixValidator.Validate(value);
            _viewModelSuffix = value;
        }
    }

    /// <summary>
    ///     Сборка, в которой находятся View.
    /// </summary>
    public Assembly? ViewAssembly
    {
        get => _viewAssembly;
        set
        {
            AssemblyValidator.Validate(value);
            _viewAssembly = value;
        }
    }

    /// <summary>
    ///     Сборка, в которой находятся ViewModel.
    /// </summary>
    public Assembly? ViewModelAssembly
    {
        get => _viewModelAssembly;
        set
        {
            AssemblyValidator.Validate(value);
            _viewModelAssembly = value;
        }
    }

    #endregion

    public DynamicNavigationSettings() : this(Default)
    { }
    public DynamicNavigationSettings(DynamicNavigationSettings source) : this(viewNamespace: source.ViewNamespace, viewModelNamespace: source.ViewModelNamespace,
        viewSuffix: source.ViewSuffix, viewModelSuffix: source.ViewModelSuffix,
        viewAssembly: source.ViewAssembly, viewModelAssembly: source.ViewModelAssembly)
    { }
    public DynamicNavigationSettings(string viewNamespace = null,
        string viewModelNamespace = null,
        string viewSuffix = null, string viewModelSuffix = null,
        Assembly? viewAssembly = null, Assembly? viewModelAssembly = null)
    {
        ViewNamespace = viewNamespace ?? Default.ViewNamespace;
        ViewModelNamespace = viewModelNamespace ?? Default.ViewModelNamespace;
        ViewSuffix = viewSuffix ?? Default.ViewSuffix;
        ViewModelSuffix = viewModelSuffix ?? Default.ViewModelSuffix;
        ViewAssembly = viewAssembly ?? Default.ViewAssembly;
        ViewModelAssembly = viewModelAssembly ?? Default.ViewAssembly;
    }
}