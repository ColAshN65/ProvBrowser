using System.Reflection;
using MVVM.Core.Locators.Helpers.Validators;

namespace MVVM.Core.Locators;

public class LocatorSettings
{
    #region Backing fields

    private string _viewNamespace;
    private string _viewModelNamespace;
    private string _viewSuffix;
    private string _viewModelSuffix;
    private Assembly? _viewAssembly;
    private Assembly? _viewModelAssembly;

    private static LocatorSettings _default;

    #endregion

    #region Properties

    public static LocatorSettings Default
    {
        get => _default;
        set
        {
            SettingsValidator.Validate(value);
            _default = value;
        }
    }

    public string ViewNamespace
    {
        get => _viewNamespace;
        set
        {
            NamespaceValidator.Validate(value);
            _viewNamespace = value;
        }
    }

    public string ViewModelNamespace
    {
        get => _viewModelNamespace;
        set
        {
            NamespaceValidator.Validate(value);
            _viewModelNamespace = value;
        }
    }

    public string ViewSuffix
    {
        get => _viewSuffix;
        set
        {
            TypeSuffixValidator.Validate(value);
            _viewSuffix = value;
        }
    }


    public string ViewModelSuffix
    {
        get => _viewModelSuffix;
        set
        {
            TypeSuffixValidator.Validate(value);
            _viewModelSuffix = value;
        }
    }
    public Assembly? ViewAssembly
    {
        get => _viewAssembly;
        set
        {
            AssemblyValidator.Validate(value);
            _viewAssembly = value;
        }
    }
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

    #region Constructors

    public LocatorSettings() : this(Default)
    { }
    public LocatorSettings(LocatorSettings source) : this(viewNamespace: source.ViewNamespace, viewModelNamespace: source.ViewModelNamespace, 
        viewSuffix: source.ViewSuffix, viewModelSuffix: source.ViewModelSuffix, 
        viewAssembly: source.ViewAssembly, viewModelAssembly: source.ViewModelAssembly)
    { }
    public LocatorSettings(string viewNamespace = null,
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

    #endregion
}
